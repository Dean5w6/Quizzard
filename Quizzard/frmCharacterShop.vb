Imports System.Drawing.Text
Imports System.Runtime.InteropServices
Imports System.Linq
Imports System.IO

Public Class frmCharacterShop
    Private pixelFontCollection As New PrivateFontCollection()
    Private tempFontPath As String = String.Empty
    Private ReadOnly currentPlayerId As Integer = 1
    Private Const PULL_COST As Integer = 250

    Private Sub frmCharacterShop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeFont()
        ApplyCustomFont()
        PopulateShop()
    End Sub

    Private Sub frmCharacterShop_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Not String.IsNullOrEmpty(tempFontPath) AndAlso File.Exists(tempFontPath) Then
                File.Delete(tempFontPath)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub PopulateShop()
        flpCharacterCards.Controls.Clear()

        Dim allCharacters As DataTable = DatabaseManager.GetAllCharacters()
        Dim unlockedCharIds As List(Of Integer) = DatabaseManager.GetPlayerUnlockedCharacters(currentPlayerId)
        Dim playerInfo As DataRow = DatabaseManager.GetPlayerProgress(currentPlayerId)

        lblPlayerQuizzite.Text = "Quizzite: " & playerInfo("Quizzite").ToString()
        btnPullCharacter.Text = ""
        Dim selectedCharId As Integer = CInt(playerInfo("SelectedCharacterID"))

        For Each charRow As DataRow In allCharacters.Rows
            Dim charId As Integer = CInt(charRow("CharacterID"))
            Dim isUnlocked As Boolean = unlockedCharIds.Contains(charId)

            Dim card As New Panel With {.Width = 200, .Height = 270, .Margin = New Padding(10)}
            Dim pic As New PictureBox With {.Dock = DockStyle.Top, .Height = 150, .SizeMode = PictureBoxSizeMode.Zoom}
            Dim nameLbl As New Label With {.Dock = DockStyle.Top, .TextAlign = ContentAlignment.MiddleCenter, .Font = New Font(pixelFontCollection.Families(0), 10, FontStyle.Bold)}
            Dim skillLbl As New Label With {.Dock = DockStyle.Fill, .TextAlign = ContentAlignment.TopCenter, .Font = New Font(pixelFontCollection.Families(0), 7)}
            Dim actionButton As New Button With {.Dock = DockStyle.Bottom, .Font = New Font(pixelFontCollection.Families(0), 9)}

            If isUnlocked Then
                nameLbl.Text = charRow("CharacterName").ToString()
                skillLbl.Text = charRow("SkillDescription").ToString()
            Else
                nameLbl.Text = "???"
                skillLbl.Text = "???"
            End If

            Try
                Dim resourceName As String = "char" & charId.ToString()
                pic.Image = CType(My.Resources.ResourceManager.GetObject(resourceName), Image)
            Catch ex As Exception
                pic.Image = Nothing
            End Try

            actionButton.Tag = charId

            If isUnlocked Then
                card.BorderStyle = BorderStyle.FixedSingle
                card.BackColor = Color.LightGreen
                If charId = selectedCharId Then
                    actionButton.Text = "SELECTED"
                    actionButton.Enabled = False
                Else
                    actionButton.Text = "SELECT"
                    AddHandler actionButton.Click, AddressOf SelectCharacter_Click
                End If
            Else
                card.BorderStyle = BorderStyle.None
                card.BackColor = Color.Gray
                actionButton.Text = "LOCKED"
                actionButton.Enabled = False
            End If

            card.Controls.Add(skillLbl)
            card.Controls.Add(actionButton)
            card.Controls.Add(nameLbl)
            card.Controls.Add(pic)

            flpCharacterCards.Controls.Add(card)
        Next
    End Sub

    Private Sub SelectCharacter_Click(sender As Object, e As EventArgs)
        Dim clickedButton As Button = CType(sender, Button)
        Dim charId As Integer = CInt(clickedButton.Tag)
        If DatabaseManager.SetSelectedCharacter(currentPlayerId, charId) Then
            PopulateShop()
        End If
    End Sub

    Private Sub btnPullCharacter_Click(sender As Object, e As EventArgs) Handles btnPullCharacter.Click
        Dim unlockedCharName As String = DatabaseManager.AttemptCharacterPull(currentPlayerId, PULL_COST)
        If Not String.IsNullOrEmpty(unlockedCharName) Then
            PopulateShop()
        End If
    End Sub

    Private Sub btnBackToLobby_Click(sender As Object, e As EventArgs) Handles btnBackToLobby.Click
        Dim lobby = Application.OpenForms.OfType(Of frmLobby).FirstOrDefault()
        If lobby IsNot Nothing Then
            lobby.Show()
        Else
            Dim newLobby As New frmLobby()
            newLobby.Show()
        End If
        Me.Close()
    End Sub

    Private Sub InitializeFont()
        Try
            tempFontPath = Path.ChangeExtension(Path.GetTempFileName(), ".ttf")
            File.WriteAllBytes(tempFontPath, My.Resources.PressStart2P_Regular)
            pixelFontCollection.AddFontFile(tempFontPath)
        Catch ex As Exception
            MessageBox.Show("Failed to load custom font: " & ex.Message, "Font Error")
        End Try
    End Sub

    Private Sub ApplyCustomFont()
        If pixelFontCollection.Families.Length = 0 Then Return
        lblPlayerQuizzite.Font = New Font(pixelFontCollection.Families(0), 12)
        btnBackToLobby.Font = New Font(pixelFontCollection.Families(0), 10)
        btnPullCharacter.Font = New Font(pixelFontCollection.Families(0), 12)
    End Sub
End Class