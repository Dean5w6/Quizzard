Imports System.Drawing.Text
Imports System.Runtime.InteropServices
Imports System.Linq
Imports System.IO

Public Class frmLobby
    Private pixelFontCollection As New PrivateFontCollection()
    Private tempFontPath As String = String.Empty

    Private ReadOnly currentPlayerId As Integer = 1
    Private currentLevel As Integer

    Private Sub frmLobby_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeFont()
        ApplyCustomFont()
        LoadLobbyData()
    End Sub

    Private Sub frmLobby_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Not String.IsNullOrEmpty(tempFontPath) AndAlso File.Exists(tempFontPath) Then
                File.Delete(tempFontPath)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub LoadLobbyData()
        Try
            Dim playerData As DataRow = DatabaseManager.GetPlayerProgress(currentPlayerId)
            If playerData Is Nothing Then
                MessageBox.Show("Could not load player data. Returning to Main Menu.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                btnBackToMenu_Click(Nothing, Nothing)
                Return
            End If

            currentLevel = CInt(playerData("CurrentLevel"))
            Dim currentQuizzite = CInt(playerData("Quizzite"))
            lblLevelInfo.Text = $"Stage: {currentLevel}"
            lblQuizzite.Text = $"Quizzite: {currentQuizzite}"

            Dim enemyData As DataRow = DatabaseManager.GetEnemyForLevel(currentLevel)
            If enemyData Is Nothing Then
                lblEnemyName.Text = "COMING SOON"
                picEnemyPreview.Image = Nothing
                btnStartBattle.Enabled = False
            Else
                lblEnemyName.Text = enemyData("EnemyName").ToString().ToUpper()
                btnStartBattle.Enabled = True
            End If

            LoadActiveQuest(playerData)

        Catch ex As Exception
            MessageBox.Show("An error occurred while loading lobby data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadActiveQuest(ByVal playerData As DataRow)
        If IsDBNull(playerData("ActiveQuestID")) Then
            DatabaseManager.ClaimRewardAndAssignNewQuest(currentPlayerId)
            LoadLobbyData()
            Return
        End If

        Dim questId As Integer = CInt(playerData("ActiveQuestID"))
        Dim questData As DataRow = DatabaseManager.GetQuestDetails(questId)

        If questData Is Nothing Then
            lblQuestDescription.Text = "Could not load quest details."
            btnClaimReward.Enabled = False
            Return
        End If

        Dim questDesc As String = questData("Description").ToString()
        Dim questProgress As Integer = CInt(playerData("QuestProgress"))
        Dim questGoal As Integer = CInt(questData("CompletionValue"))

        If questProgress >= questGoal Then
            lblQuestDescription.Text = questDesc & " (COMPLETE!)"
            Me.BackgroundImage = My.Resources.lobbyBG1
            btnClaimReward.Enabled = True
            btnClaimReward.Text = "    "
        Else
            lblQuestDescription.Text = $"{questDesc} ({questProgress} / {questGoal})"
            btnClaimReward.Enabled = False
            btnClaimReward.Text = "     "
        End If
    End Sub

    Private Sub btnStartBattle_Click(sender As Object, e As EventArgs) Handles btnStartBattle.Click
        Select Case currentLevel
            Case 1
                Dim battleForm As New frmBattleScreen(currentLevel)
                battleForm.Show()
                Me.Hide()
            Case 2
                Dim stage2Form As New frmStage2(currentLevel)
                stage2Form.Show()
                Me.Hide()
            Case Else
                MessageBox.Show("This level is still under construction! Loading Stage 1 for now.", "Content Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim battleForm As New frmBattleScreen(currentLevel)
                battleForm.Show()
                Me.Hide()
        End Select
    End Sub

    Private Sub btnPlayerStats_Click(sender As Object, e As EventArgs) Handles btnPlayerStats.Click
        Dim statsForm As New frmPlayerStats()
        statsForm.Show()
        Me.Hide()
    End Sub

    Private Sub btnClaimReward_Click(sender As Object, e As EventArgs) Handles btnClaimReward.Click
        DatabaseManager.ClaimRewardAndAssignNewQuest(currentPlayerId)
        LoadLobbyData()
        Me.BackgroundImage = My.Resources.lobbyBG
    End Sub

    Private Sub btnResetQuestions_Click(sender As Object, e As EventArgs) Handles btnResetQuestions.Click
        Dim deckIdToReset = 1
        Dim result = MessageBox.Show("Reset progress for the main deck? You will be able to answer all its questions again.", "Confirm Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            If DatabaseManager.ResetAnsweredQuestionsForDeck(currentPlayerId, deckIdToReset) Then
                MessageBox.Show("Deck progress has been reset!")
            End If
        End If
    End Sub

    Private Sub btnBackToMenu_Click(sender As Object, e As EventArgs) Handles btnBackToMenu.Click
        Dim mainMenu = Application.OpenForms.OfType(Of frmMainMenu).FirstOrDefault()
        If mainMenu IsNot Nothing Then
            mainMenu.Show()
        Else
            Dim newMainMenu As New frmMainMenu()
            newMainMenu.Show()
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
        lblLevelInfo.Font = New Font(pixelFontCollection.Families(0), 12)
        lblQuizzite.Font = New Font(pixelFontCollection.Families(0), 12)
        lblEnemyName.Font = New Font(pixelFontCollection.Families(0), 14)
        lblQuestDescription.Font = New Font(pixelFontCollection.Families(0), 6)

        For Each btn As Button In FindAllControls(Of Button)(Me)
            btn.Font = New Font(pixelFontCollection.Families(0), 12)
        Next
    End Sub

    Private Function FindAllControls(Of T As Control)(ByVal parent As Control) As IEnumerable(Of T)
        Dim result As New List(Of T)
        For Each ctrl As Control In parent.Controls
            If TypeOf ctrl Is T Then result.Add(CType(ctrl, T))
            result.AddRange(FindAllControls(Of T)(ctrl))
        Next
        Return result
    End Function

    Private Sub btnCharacterShop_Click(sender As Object, e As EventArgs) Handles btnCharacterShop.Click
        Dim shopForm As New frmCharacterShop()
        shopForm.Show()
        Me.Hide()
    End Sub
End Class