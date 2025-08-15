Public Class frmDeckEditor
    Public DeckIdToEdit As Integer
    Public DeckNameToEdit As String

    Public Sub New()
        Me.New(-1, "No Deck Selected")
    End Sub

    Public Sub New(deckId As Integer, deckName As String)
        InitializeComponent()

        Me.DeckIdToEdit = deckId
        Me.DeckNameToEdit = deckName
    End Sub

    Private Sub frmDeckEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.DeckIdToEdit > 0 Then
            lblDeckName.Text = $"Editing Questions for: {DeckNameToEdit}"
            LoadQuestions()
        Else
            lblDeckName.Text = "No Deck Loaded"
            dgvQuestions.Enabled = False
            btnAddQuestion.Enabled = False
        End If
    End Sub

    Private Sub LoadQuestions()
        Dim questionsData As DataTable = DatabaseManager.GetQuestionsForDeck(Me.DeckIdToEdit)

        dgvQuestions.DataSource = questionsData

        If dgvQuestions.Columns.Contains("QuestionID") Then
            dgvQuestions.Columns("QuestionID").Visible = False
        End If
        If dgvQuestions.Columns.Contains("QuestionText") Then
            dgvQuestions.Columns("QuestionText").HeaderText = "Question"
        End If
        If dgvQuestions.Columns.Contains("Answer") Then
            dgvQuestions.Columns("Answer").HeaderText = "Answer"
        End If
    End Sub

    Private Sub btnSaveChanges_Click(sender As Object, e As EventArgs) Handles btnSaveChanges.Click
        Dim deckManagerForm As Form = Application.OpenForms("frmDeckManager")
        If deckManagerForm IsNot Nothing Then
            deckManagerForm.Show()
        End If

        Me.Close()
    End Sub

    Private Sub btnAddQuestion_Click(sender As Object, e As EventArgs) Handles btnAddQuestion.Click
        Dim newQuestion As String = txtQuestionText.Text.Trim()
        Dim newAnswer As String = txtAnswer.Text.Trim()

        If String.IsNullOrWhiteSpace(newQuestion) OrElse String.IsNullOrWhiteSpace(newAnswer) Then
            MessageBox.Show("Please enter both a question and an answer.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If DatabaseManager.AddQuestion(Me.DeckIdToEdit, newQuestion, newAnswer) Then
            MessageBox.Show("Question added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            txtQuestionText.Clear()
            txtAnswer.Clear()

            LoadQuestions()

            txtQuestionText.Focus()
        Else
        End If
    End Sub

    Private Sub btnDeleteQuestion_Click(sender As Object, e As EventArgs) Handles btnDeleteQuestion.Click
        If dgvQuestions.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a question to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvQuestions.SelectedRows(0)
        Dim questionIdToDelete As Integer = CInt(selectedRow.Cells("QuestionID").Value)
        Dim questionTextToDelete As String = selectedRow.Cells("QuestionText").Value.ToString()

        Dim message As String = $"Are you sure you want to delete the question: '{questionTextToDelete}'?"
        Dim result As DialogResult = MessageBox.Show(message, "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            If DatabaseManager.DeleteQuestion(questionIdToDelete) Then
                MessageBox.Show("Question deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadQuestions()
            End If
        End If
    End Sub

    Private Sub dgvQuestions_SelectionChanged(sender As Object, e As EventArgs) Handles dgvQuestions.SelectionChanged
        If dgvQuestions.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dgvQuestions.SelectedRows(0)
            txtQuestionText.Text = selectedRow.Cells("QuestionText").Value.ToString()
            txtAnswer.Text = selectedRow.Cells("Answer").Value.ToString()
        End If
    End Sub

    Private Sub btnUpdateQuestion_Click(sender As Object, e As EventArgs) Handles btnUpdateQuestion.Click
        If dgvQuestions.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a question to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim questionIdToUpdate As Integer = CInt(dgvQuestions.SelectedRows(0).Cells("QuestionID").Value)
        Dim updatedQuestion As String = txtQuestionText.Text.Trim()
        Dim updatedAnswer As String = txtAnswer.Text.Trim()

        If String.IsNullOrWhiteSpace(updatedQuestion) OrElse String.IsNullOrWhiteSpace(updatedAnswer) Then
            MessageBox.Show("Question and answer fields cannot be empty.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If DatabaseManager.UpdateQuestion(questionIdToUpdate, updatedQuestion, updatedAnswer) Then
            MessageBox.Show("Question updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadQuestions()
            txtQuestionText.Clear()
            txtAnswer.Clear()
        End If
    End Sub
End Class