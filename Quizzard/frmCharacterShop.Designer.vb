<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCharacterShop
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCharacterShop))
        Me.flpCharacterCards = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnPullCharacter = New System.Windows.Forms.Button()
        Me.btnBackToLobby = New System.Windows.Forms.Button()
        Me.lblPlayerQuizzite = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'flpCharacterCards
        '
        Me.flpCharacterCards.AutoScroll = True
        Me.flpCharacterCards.BackColor = System.Drawing.Color.Transparent
        Me.flpCharacterCards.Location = New System.Drawing.Point(55, 69)
        Me.flpCharacterCards.Name = "flpCharacterCards"
        Me.flpCharacterCards.Size = New System.Drawing.Size(792, 303)
        Me.flpCharacterCards.TabIndex = 0
        '
        'btnPullCharacter
        '
        Me.btnPullCharacter.BackColor = System.Drawing.Color.Transparent
        Me.btnPullCharacter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPullCharacter.FlatAppearance.BorderSize = 0
        Me.btnPullCharacter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnPullCharacter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnPullCharacter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPullCharacter.Location = New System.Drawing.Point(612, 401)
        Me.btnPullCharacter.Name = "btnPullCharacter"
        Me.btnPullCharacter.Size = New System.Drawing.Size(235, 79)
        Me.btnPullCharacter.TabIndex = 27
        Me.btnPullCharacter.Text = "         "
        Me.btnPullCharacter.UseVisualStyleBackColor = False
        '
        'btnBackToLobby
        '
        Me.btnBackToLobby.BackColor = System.Drawing.Color.Transparent
        Me.btnBackToLobby.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBackToLobby.FlatAppearance.BorderSize = 0
        Me.btnBackToLobby.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnBackToLobby.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnBackToLobby.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBackToLobby.Location = New System.Drawing.Point(49, 401)
        Me.btnBackToLobby.Name = "btnBackToLobby"
        Me.btnBackToLobby.Size = New System.Drawing.Size(128, 79)
        Me.btnBackToLobby.TabIndex = 26
        Me.btnBackToLobby.Text = "         "
        Me.btnBackToLobby.UseVisualStyleBackColor = False
        '
        'lblPlayerQuizzite
        '
        Me.lblPlayerQuizzite.AutoSize = True
        Me.lblPlayerQuizzite.BackColor = System.Drawing.Color.Transparent
        Me.lblPlayerQuizzite.ForeColor = System.Drawing.Color.White
        Me.lblPlayerQuizzite.Location = New System.Drawing.Point(92, 30)
        Me.lblPlayerQuizzite.Name = "lblPlayerQuizzite"
        Me.lblPlayerQuizzite.Size = New System.Drawing.Size(56, 13)
        Me.lblPlayerQuizzite.TabIndex = 25
        Me.lblPlayerQuizzite.Text = "Quizzite: 0"
        '
        'frmCharacterShop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackgroundImage = Global.Quizzard.My.Resources.Resources.characterShop
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(890, 501)
        Me.Controls.Add(Me.btnBackToLobby)
        Me.Controls.Add(Me.btnPullCharacter)
        Me.Controls.Add(Me.lblPlayerQuizzite)
        Me.Controls.Add(Me.flpCharacterCards)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCharacterShop"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Character Shop"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents flpCharacterCards As FlowLayoutPanel
    Friend WithEvents btnBackToLobby As Button
    Friend WithEvents lblPlayerQuizzite As Label
    Friend WithEvents btnPullCharacter As Button
End Class
