Imports System.Linq

Public Class frmDeckManager

    Private Sub frmDeckManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDecks()
    End Sub

    Private Sub LoadDecks()
        Dim decksData As DataTable = DatabaseManager.GetAllDecks()

        dgvDecks.DataSource = decksData

        If dgvDecks.Columns.Contains("DeckID") Then
            dgvDecks.Columns("DeckID").Visible = False
        End If
        If dgvDecks.Columns.Contains("DeckName") Then
            dgvDecks.Columns("DeckName").HeaderText = "Deck Name"
        End If
        If dgvDecks.Columns.Contains("Category") Then
            dgvDecks.Columns("Category").HeaderText = "Category"
        End If
    End Sub

    Private Sub btnBackToMenu_Click(sender As Object, e As EventArgs) Handles btnBackToMenu.Click
        Dim mainMenu As Form = Application.OpenForms.OfType(Of frmMainMenu).FirstOrDefault()

        If mainMenu IsNot Nothing Then
            mainMenu.Show()
        End If

        Me.Close()
    End Sub


    Private Sub btnCreateNew_Click(sender As Object, e As EventArgs) Handles btnCreateNew.Click
        Dim newDeckName As String = InputBox("Please enter the name for the new deck:", "Create New Deck")

        If String.IsNullOrWhiteSpace(newDeckName) Then
            Return
        End If

        Dim newDeckCategory As String = InputBox($"Please enter the category for '{newDeckName}':", "Set Category")

        If String.IsNullOrWhiteSpace(newDeckCategory) Then
            Return
        End If

        If DatabaseManager.AddDeck(newDeckName, newDeckCategory) Then
            MessageBox.Show($"Deck '{newDeckName}' created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadDecks()
        End If
    End Sub

    Private Sub btnEditSelected_Click(sender As Object, e As EventArgs) Handles btnEditSelected.Click
        If dgvDecks.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a deck to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvDecks.SelectedRows(0)
        Dim deckId As Integer = CInt(selectedRow.Cells("DeckID").Value)
        Dim deckName As String = selectedRow.Cells("DeckName").Value.ToString()

        Dim editorForm As New frmDeckEditor(deckId, deckName)

        editorForm.Show()
        Me.Hide()
    End Sub

    Private Sub btnDeleteSelected_Click(sender As Object, e As EventArgs) Handles btnDeleteSelected.Click
        If dgvDecks.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a deck to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvDecks.SelectedRows(0)

        Dim deckIdToDelete As Integer = CInt(selectedRow.Cells("DeckID").Value)
        Dim deckNameToDelete As String = selectedRow.Cells("DeckName").Value.ToString()

        Dim confirmationMessage As String = $"Are you sure you want to permanently delete the deck '{deckNameToDelete}'?" & vbCrLf & "All questions inside it will also be deleted."
        Dim result As DialogResult = MessageBox.Show(confirmationMessage, "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            If DatabaseManager.DeleteDeck(deckIdToDelete) Then
                MessageBox.Show($"Deck '{deckNameToDelete}' has been deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                LoadDecks()
            Else
            End If
        End If
    End Sub

    Private Sub btnSelectDeck_Click(sender As Object, e As EventArgs) Handles btnSelectDeck.Click
        If dgvDecks.SelectedRows.Count = 0 Then
            MessageBox.Show("Please click on a deck from the list to select it.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvDecks.SelectedRows(0)

        Dim selectedDeckId As Integer = CInt(selectedRow.Cells("DeckID").Value)
        Dim selectedDeckName As String = selectedRow.Cells("DeckName").Value.ToString()
        Dim playerId As Integer = 1

        If DatabaseManager.SetPlayerSelectedDeck(playerId, selectedDeckId) Then
            MessageBox.Show($"'{selectedDeckName}' is now your active deck for battles!", "Deck Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Failed to select the deck. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class