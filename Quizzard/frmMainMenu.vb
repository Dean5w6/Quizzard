Imports System.Drawing.Text
Imports System.Runtime.InteropServices
Imports System.Linq
Imports System.IO

Public Class frmMainMenu
    Private pixelFontCollection As New PrivateFontCollection()

    Private tempFontPath As String = String.Empty

    Private Sub frmMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            tempFontPath = Path.ChangeExtension(Path.GetTempFileName(), ".ttf")

            File.WriteAllBytes(tempFontPath, My.Resources.PressStart2P_Regular)

            pixelFontCollection.AddFontFile(tempFontPath)

        Catch ex As Exception
            MessageBox.Show("Failed to extract or load the font file." & vbCrLf & ex.Message, "Font Loading Error")
            Return
        End Try

    End Sub

    Private Sub frmMainMenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Not String.IsNullOrEmpty(tempFontPath) AndAlso File.Exists(tempFontPath) Then
                File.Delete(tempFontPath)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        Me.Hide()
        Dim lobbyForm As New frmLobby()
        lobbyForm.Show()
    End Sub

    Private Sub btnDeckManager_Click(sender As Object, e As EventArgs) Handles btnDeckManager.Click
        Me.Hide()
        Dim deckManager As New frmDeckManager
        deckManager.Show()
    End Sub

    Private Sub btnOptions_Click(sender As Object, e As EventArgs) Handles btnOptions.Click
        frmStage2.Show()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub
End Class