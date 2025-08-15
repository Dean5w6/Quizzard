Imports System.Drawing.Text
Imports System.Runtime.InteropServices
Imports System.Linq
Imports System.IO

Public Class frmPlayerStats
    Private pixelFontCollection As New PrivateFontCollection()
    Private tempFontPath As String = String.Empty
    Private ReadOnly currentPlayerId As Integer = 1

    Private Sub frmPlayerStats_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeFont()
        ApplyCustomFont()
        LoadAndDisplayStats()
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

        For Each lbl As Label In FindAllControls(Of Label)(Me)
            lbl.Font = New Font(pixelFontCollection.Families(0), 10)
        Next

        For Each btn As Button In FindAllControls(Of Button)(Me)
            btn.Font = New Font(pixelFontCollection.Families(0), 10)
        Next
    End Sub

    Private Sub frmPlayerStats_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Not String.IsNullOrEmpty(tempFontPath) AndAlso File.Exists(tempFontPath) Then
                File.Delete(tempFontPath)
            End If
        Catch ex As Exception
        End Try
    End Sub



    Private Sub LoadAndDisplayStats()
        Dim playerData As DataRow = DatabaseManager.GetPlayerProgress(currentPlayerId)
        If playerData Is Nothing Then
            MessageBox.Show("Could not load player stats.", "Error")
            Return
        End If

        Dim selectedCharacterId As Integer = CInt(playerData("SelectedCharacterID"))
        Try
            Dim spriteName As String = $"char{selectedCharacterId}"
            PictureBox1.Image = CType(My.Resources.ResourceManager.GetObject(spriteName), Image)
        Catch ex As Exception
            PictureBox1.Image = Nothing
        End Try

        lblPlayerLevel.Text = "LEVEL: " & playerData("PlayerLevel").ToString()
        lblExperience.Text = $"EXP: {playerData("CurrentEXP")} / {playerData("EXPToNextLevel")}"
        lblSkillPoints.Text = "SKILL POINTS: " & playerData("UnspentSkillPoints").ToString()

        lblIntelValue.Text = "INT: " + playerData("Stat_Intelligence").ToString()
        lblFocusValue.Text = "FOC: " + playerData("Stat_Focus").ToString()
        lblResilValue.Text = "RES: " + playerData("Stat_Resilience").ToString()
        lblLuckValue.Text = "LCK: " + playerData("Stat_Luck").ToString()

        pbExperience.Maximum = CInt(playerData("EXPToNextLevel"))
        pbExperience.Value = CInt(playerData("CurrentEXP"))

        Dim hasPoints As Boolean = (CInt(playerData("UnspentSkillPoints")) > 0)
        btnIncreaseIntel.Enabled = hasPoints
        btnIncreaseFocus.Enabled = hasPoints
        btnIncreaseResil.Enabled = hasPoints
        btnIncreaseLuck.Enabled = hasPoints
    End Sub

    Private Sub btnIncreaseIntel_Click(sender As Object, e As EventArgs) Handles btnIncreaseIntel.Click
        If DatabaseManager.UpgradePlayerStat(currentPlayerId, "Stat_Intelligence") Then
            LoadAndDisplayStats()
        Else
            MessageBox.Show("Not enough skill points!", "Upgrade Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnIncreaseFocus_Click(sender As Object, e As EventArgs) Handles btnIncreaseFocus.Click
        If DatabaseManager.UpgradePlayerStat(currentPlayerId, "Stat_Focus") Then
            LoadAndDisplayStats()
        Else
            MessageBox.Show("Not enough skill points!", "Upgrade Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnIncreaseResil_Click(sender As Object, e As EventArgs) Handles btnIncreaseResil.Click
        If DatabaseManager.UpgradePlayerStat(currentPlayerId, "Stat_Resilience") Then
            LoadAndDisplayStats()
        Else
            MessageBox.Show("Not enough skill points!", "Upgrade Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnIncreaseLuck_Click(sender As Object, e As EventArgs) Handles btnIncreaseLuck.Click
        If DatabaseManager.UpgradePlayerStat(currentPlayerId, "Stat_Luck") Then
            LoadAndDisplayStats()
        Else
            MessageBox.Show("Not enough skill points!", "Upgrade Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Function FindAllControls(Of T As Control)(ByVal parent As Control) As IEnumerable(Of T)
        Dim result As New List(Of T)
        For Each ctrl As Control In parent.Controls
            If TypeOf ctrl Is T Then result.Add(CType(ctrl, T))
            result.AddRange(FindAllControls(Of T)(ctrl))
        Next
        Return result
    End Function
End Class