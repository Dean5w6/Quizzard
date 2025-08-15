<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLobby
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLobby))
        Me.lblEnemyName = New System.Windows.Forms.Label()
        Me.lblLevelInfo = New System.Windows.Forms.Label()
        Me.btnClaimReward = New System.Windows.Forms.Button()
        Me.lblQuestDescription = New System.Windows.Forms.Label()
        Me.btnStartBattle = New System.Windows.Forms.Button()
        Me.btnResetQuestions = New System.Windows.Forms.Button()
        Me.btnBackToMenu = New System.Windows.Forms.Button()
        Me.btnCharacterShop = New System.Windows.Forms.Button()
        Me.picEnemyPreview = New System.Windows.Forms.PictureBox()
        Me.lblQuizzite = New System.Windows.Forms.Label()
        Me.btnPlayerStats = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.picEnemyPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblEnemyName
        '
        Me.lblEnemyName.AutoSize = True
        Me.lblEnemyName.BackColor = System.Drawing.Color.Transparent
        Me.lblEnemyName.Location = New System.Drawing.Point(198, 141)
        Me.lblEnemyName.Name = "lblEnemyName"
        Me.lblEnemyName.Size = New System.Drawing.Size(77, 13)
        Me.lblEnemyName.TabIndex = 1
        Me.lblEnemyName.Text = "lblEnemyName"
        Me.lblEnemyName.Visible = False
        '
        'lblLevelInfo
        '
        Me.lblLevelInfo.AutoSize = True
        Me.lblLevelInfo.BackColor = System.Drawing.Color.Transparent
        Me.lblLevelInfo.ForeColor = System.Drawing.Color.White
        Me.lblLevelInfo.Location = New System.Drawing.Point(77, 59)
        Me.lblLevelInfo.Name = "lblLevelInfo"
        Me.lblLevelInfo.Size = New System.Drawing.Size(61, 13)
        Me.lblLevelInfo.TabIndex = 2
        Me.lblLevelInfo.Text = "lblLevelInfo"
        '
        'btnClaimReward
        '
        Me.btnClaimReward.BackColor = System.Drawing.Color.Transparent
        Me.btnClaimReward.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClaimReward.Enabled = False
        Me.btnClaimReward.FlatAppearance.BorderSize = 0
        Me.btnClaimReward.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnClaimReward.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnClaimReward.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClaimReward.Location = New System.Drawing.Point(640, 271)
        Me.btnClaimReward.Name = "btnClaimReward"
        Me.btnClaimReward.Size = New System.Drawing.Size(111, 41)
        Me.btnClaimReward.TabIndex = 7
        Me.btnClaimReward.Text = "        "
        Me.btnClaimReward.UseVisualStyleBackColor = False
        '
        'lblQuestDescription
        '
        Me.lblQuestDescription.BackColor = System.Drawing.Color.Transparent
        Me.lblQuestDescription.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblQuestDescription.Location = New System.Drawing.Point(627, 156)
        Me.lblQuestDescription.Name = "lblQuestDescription"
        Me.lblQuestDescription.Size = New System.Drawing.Size(139, 100)
        Me.lblQuestDescription.TabIndex = 4
        Me.lblQuestDescription.Text = "Quest Description"
        '
        'btnStartBattle
        '
        Me.btnStartBattle.BackColor = System.Drawing.Color.Transparent
        Me.btnStartBattle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStartBattle.FlatAppearance.BorderSize = 0
        Me.btnStartBattle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnStartBattle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnStartBattle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStartBattle.Location = New System.Drawing.Point(718, 408)
        Me.btnStartBattle.Name = "btnStartBattle"
        Me.btnStartBattle.Size = New System.Drawing.Size(154, 70)
        Me.btnStartBattle.TabIndex = 8
        Me.btnStartBattle.Text = "        "
        Me.btnStartBattle.UseVisualStyleBackColor = False
        '
        'btnResetQuestions
        '
        Me.btnResetQuestions.BackColor = System.Drawing.Color.Transparent
        Me.btnResetQuestions.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnResetQuestions.FlatAppearance.BorderSize = 0
        Me.btnResetQuestions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnResetQuestions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnResetQuestions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResetQuestions.Location = New System.Drawing.Point(517, 408)
        Me.btnResetQuestions.Name = "btnResetQuestions"
        Me.btnResetQuestions.Size = New System.Drawing.Size(176, 70)
        Me.btnResetQuestions.TabIndex = 9
        Me.btnResetQuestions.Text = "        "
        Me.btnResetQuestions.UseVisualStyleBackColor = False
        '
        'btnBackToMenu
        '
        Me.btnBackToMenu.BackColor = System.Drawing.Color.Transparent
        Me.btnBackToMenu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBackToMenu.FlatAppearance.BorderSize = 0
        Me.btnBackToMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnBackToMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnBackToMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBackToMenu.Location = New System.Drawing.Point(23, 408)
        Me.btnBackToMenu.Name = "btnBackToMenu"
        Me.btnBackToMenu.Size = New System.Drawing.Size(107, 70)
        Me.btnBackToMenu.TabIndex = 11
        Me.btnBackToMenu.Text = "        "
        Me.btnBackToMenu.UseVisualStyleBackColor = False
        '
        'btnCharacterShop
        '
        Me.btnCharacterShop.BackColor = System.Drawing.Color.Transparent
        Me.btnCharacterShop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCharacterShop.FlatAppearance.BorderSize = 0
        Me.btnCharacterShop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnCharacterShop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnCharacterShop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCharacterShop.Location = New System.Drawing.Point(151, 408)
        Me.btnCharacterShop.Name = "btnCharacterShop"
        Me.btnCharacterShop.Size = New System.Drawing.Size(173, 70)
        Me.btnCharacterShop.TabIndex = 10
        Me.btnCharacterShop.Text = "        "
        Me.btnCharacterShop.UseVisualStyleBackColor = False
        '
        'picEnemyPreview
        '
        Me.picEnemyPreview.Location = New System.Drawing.Point(737, 12)
        Me.picEnemyPreview.Name = "picEnemyPreview"
        Me.picEnemyPreview.Size = New System.Drawing.Size(139, 160)
        Me.picEnemyPreview.TabIndex = 12
        Me.picEnemyPreview.TabStop = False
        Me.picEnemyPreview.Visible = False
        '
        'lblQuizzite
        '
        Me.lblQuizzite.AutoSize = True
        Me.lblQuizzite.BackColor = System.Drawing.Color.Transparent
        Me.lblQuizzite.ForeColor = System.Drawing.Color.White
        Me.lblQuizzite.Location = New System.Drawing.Point(77, 27)
        Me.lblQuizzite.Name = "lblQuizzite"
        Me.lblQuizzite.Size = New System.Drawing.Size(39, 13)
        Me.lblQuizzite.TabIndex = 13
        Me.lblQuizzite.Text = "Label1"
        '
        'btnPlayerStats
        '
        Me.btnPlayerStats.BackColor = System.Drawing.Color.Transparent
        Me.btnPlayerStats.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPlayerStats.FlatAppearance.BorderSize = 0
        Me.btnPlayerStats.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnPlayerStats.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnPlayerStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPlayerStats.Location = New System.Drawing.Point(349, 408)
        Me.btnPlayerStats.Name = "btnPlayerStats"
        Me.btnPlayerStats.Size = New System.Drawing.Size(144, 70)
        Me.btnPlayerStats.TabIndex = 14
        Me.btnPlayerStats.Text = "        "
        Me.btnPlayerStats.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.Quizzard.My.Resources.Resources.quizzite
        Me.PictureBox1.Location = New System.Drawing.Point(37, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(34, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        '
        'frmLobby
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Coral
        Me.BackgroundImage = Global.Quizzard.My.Resources.Resources.lobbyBG
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(888, 501)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnClaimReward)
        Me.Controls.Add(Me.btnPlayerStats)
        Me.Controls.Add(Me.lblQuestDescription)
        Me.Controls.Add(Me.lblQuizzite)
        Me.Controls.Add(Me.picEnemyPreview)
        Me.Controls.Add(Me.btnBackToMenu)
        Me.Controls.Add(Me.btnCharacterShop)
        Me.Controls.Add(Me.btnResetQuestions)
        Me.Controls.Add(Me.btnStartBattle)
        Me.Controls.Add(Me.lblLevelInfo)
        Me.Controls.Add(Me.lblEnemyName)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLobby"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lobby"
        CType(Me.picEnemyPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblEnemyName As Label
    Friend WithEvents lblLevelInfo As Label
    Friend WithEvents lblQuestDescription As Label
    Friend WithEvents btnClaimReward As Button
    Friend WithEvents btnStartBattle As Button
    Friend WithEvents btnResetQuestions As Button
    Friend WithEvents btnBackToMenu As Button
    Friend WithEvents btnCharacterShop As Button
    Friend WithEvents picEnemyPreview As PictureBox
    Friend WithEvents lblQuizzite As Label
    Friend WithEvents btnPlayerStats As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
