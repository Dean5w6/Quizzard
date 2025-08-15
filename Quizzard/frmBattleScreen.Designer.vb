<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBattleScreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBattleScreen))
        Me.picEnemySprite = New System.Windows.Forms.PictureBox()
        Me.picPlayerSprite = New System.Windows.Forms.PictureBox()
        Me.btnSubmitAnswer = New System.Windows.Forms.Button()
        Me.txtPlayerAnswer = New System.Windows.Forms.TextBox()
        Me.lblTimer = New System.Windows.Forms.Label()
        Me.lblQuestionText = New System.Windows.Forms.Label()
        Me.pbPlayerHP = New System.Windows.Forms.ProgressBar()
        Me.lblPlayerHP = New System.Windows.Forms.Label()
        Me.lblPlayerName = New System.Windows.Forms.Label()
        Me.pbEnemyHP = New System.Windows.Forms.ProgressBar()
        Me.lblEnemyHP = New System.Windows.Forms.Label()
        Me.lblEnemyName = New System.Windows.Forms.Label()
        Me.picPlayerAttack = New System.Windows.Forms.PictureBox()
        CType(Me.picEnemySprite, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPlayerSprite, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPlayerAttack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picEnemySprite
        '
        Me.picEnemySprite.BackColor = System.Drawing.Color.Transparent
        Me.picEnemySprite.Location = New System.Drawing.Point(649, 412)
        Me.picEnemySprite.Name = "picEnemySprite"
        Me.picEnemySprite.Size = New System.Drawing.Size(224, 190)
        Me.picEnemySprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picEnemySprite.TabIndex = 13
        Me.picEnemySprite.TabStop = False
        '
        'picPlayerSprite
        '
        Me.picPlayerSprite.BackColor = System.Drawing.Color.Transparent
        Me.picPlayerSprite.Image = Global.Quizzard.My.Resources.Resources.char1Idle
        Me.picPlayerSprite.Location = New System.Drawing.Point(165, 189)
        Me.picPlayerSprite.Name = "picPlayerSprite"
        Me.picPlayerSprite.Size = New System.Drawing.Size(174, 267)
        Me.picPlayerSprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picPlayerSprite.TabIndex = 14
        Me.picPlayerSprite.TabStop = False
        '
        'btnSubmitAnswer
        '
        Me.btnSubmitAnswer.BackColor = System.Drawing.Color.Transparent
        Me.btnSubmitAnswer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSubmitAnswer.FlatAppearance.BorderSize = 0
        Me.btnSubmitAnswer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnSubmitAnswer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnSubmitAnswer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmitAnswer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSubmitAnswer.Location = New System.Drawing.Point(642, 637)
        Me.btnSubmitAnswer.Name = "btnSubmitAnswer"
        Me.btnSubmitAnswer.Size = New System.Drawing.Size(100, 28)
        Me.btnSubmitAnswer.TabIndex = 24
        Me.btnSubmitAnswer.Text = "Submit Answer"
        Me.btnSubmitAnswer.UseVisualStyleBackColor = False
        '
        'txtPlayerAnswer
        '
        Me.txtPlayerAnswer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPlayerAnswer.ForeColor = System.Drawing.Color.Navy
        Me.txtPlayerAnswer.Location = New System.Drawing.Point(324, 637)
        Me.txtPlayerAnswer.Name = "txtPlayerAnswer"
        Me.txtPlayerAnswer.Size = New System.Drawing.Size(315, 20)
        Me.txtPlayerAnswer.TabIndex = 18
        '
        'lblTimer
        '
        Me.lblTimer.AutoSize = True
        Me.lblTimer.BackColor = System.Drawing.Color.Transparent
        Me.lblTimer.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimer.ForeColor = System.Drawing.Color.White
        Me.lblTimer.Location = New System.Drawing.Point(380, 38)
        Me.lblTimer.Name = "lblTimer"
        Me.lblTimer.Size = New System.Drawing.Size(39, 29)
        Me.lblTimer.TabIndex = 23
        Me.lblTimer.Text = "40"
        '
        'lblQuestionText
        '
        Me.lblQuestionText.BackColor = System.Drawing.Color.Transparent
        Me.lblQuestionText.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblQuestionText.Location = New System.Drawing.Point(51, 505)
        Me.lblQuestionText.Name = "lblQuestionText"
        Me.lblQuestionText.Size = New System.Drawing.Size(699, 109)
        Me.lblQuestionText.TabIndex = 22
        Me.lblQuestionText.Text = "lblQuestionText"
        '
        'pbPlayerHP
        '
        Me.pbPlayerHP.ForeColor = System.Drawing.Color.Green
        Me.pbPlayerHP.Location = New System.Drawing.Point(12, 34)
        Me.pbPlayerHP.Name = "pbPlayerHP"
        Me.pbPlayerHP.Size = New System.Drawing.Size(205, 23)
        Me.pbPlayerHP.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbPlayerHP.TabIndex = 20
        '
        'lblPlayerHP
        '
        Me.lblPlayerHP.AutoSize = True
        Me.lblPlayerHP.BackColor = System.Drawing.Color.Transparent
        Me.lblPlayerHP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblPlayerHP.Location = New System.Drawing.Point(12, 60)
        Me.lblPlayerHP.Name = "lblPlayerHP"
        Me.lblPlayerHP.Size = New System.Drawing.Size(61, 13)
        Me.lblPlayerHP.TabIndex = 21
        Me.lblPlayerHP.Text = "lblPlayerHP"
        '
        'lblPlayerName
        '
        Me.lblPlayerName.AutoSize = True
        Me.lblPlayerName.BackColor = System.Drawing.Color.Transparent
        Me.lblPlayerName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblPlayerName.Location = New System.Drawing.Point(12, 18)
        Me.lblPlayerName.Name = "lblPlayerName"
        Me.lblPlayerName.Size = New System.Drawing.Size(74, 13)
        Me.lblPlayerName.TabIndex = 20
        Me.lblPlayerName.Text = "lblPlayerName"
        '
        'pbEnemyHP
        '
        Me.pbEnemyHP.ForeColor = System.Drawing.Color.DarkRed
        Me.pbEnemyHP.Location = New System.Drawing.Point(584, 34)
        Me.pbEnemyHP.Name = "pbEnemyHP"
        Me.pbEnemyHP.Size = New System.Drawing.Size(205, 23)
        Me.pbEnemyHP.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbEnemyHP.TabIndex = 22
        '
        'lblEnemyHP
        '
        Me.lblEnemyHP.BackColor = System.Drawing.Color.Transparent
        Me.lblEnemyHP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblEnemyHP.Location = New System.Drawing.Point(524, 60)
        Me.lblEnemyHP.Name = "lblEnemyHP"
        Me.lblEnemyHP.Size = New System.Drawing.Size(265, 13)
        Me.lblEnemyHP.TabIndex = 19
        Me.lblEnemyHP.Text = "lblEnemyHP"
        Me.lblEnemyHP.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblEnemyName
        '
        Me.lblEnemyName.BackColor = System.Drawing.Color.Transparent
        Me.lblEnemyName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblEnemyName.Location = New System.Drawing.Point(524, 18)
        Me.lblEnemyName.Name = "lblEnemyName"
        Me.lblEnemyName.Size = New System.Drawing.Size(265, 13)
        Me.lblEnemyName.TabIndex = 18
        Me.lblEnemyName.Text = "lblEnemyName"
        Me.lblEnemyName.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'picPlayerAttack
        '
        Me.picPlayerAttack.BackColor = System.Drawing.Color.Transparent
        Me.picPlayerAttack.Location = New System.Drawing.Point(415, 112)
        Me.picPlayerAttack.Name = "picPlayerAttack"
        Me.picPlayerAttack.Size = New System.Drawing.Size(224, 190)
        Me.picPlayerAttack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picPlayerAttack.TabIndex = 25
        Me.picPlayerAttack.TabStop = False
        '
        'frmBattleScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Quizzard.My.Resources.Resources.s1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(799, 687)
        Me.Controls.Add(Me.picPlayerAttack)
        Me.Controls.Add(Me.picEnemySprite)
        Me.Controls.Add(Me.pbEnemyHP)
        Me.Controls.Add(Me.pbPlayerHP)
        Me.Controls.Add(Me.lblEnemyName)
        Me.Controls.Add(Me.lblEnemyHP)
        Me.Controls.Add(Me.btnSubmitAnswer)
        Me.Controls.Add(Me.txtPlayerAnswer)
        Me.Controls.Add(Me.lblPlayerHP)
        Me.Controls.Add(Me.lblPlayerName)
        Me.Controls.Add(Me.lblTimer)
        Me.Controls.Add(Me.lblQuestionText)
        Me.Controls.Add(Me.picPlayerSprite)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBattleScreen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stage 1"
        CType(Me.picEnemySprite, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPlayerSprite, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPlayerAttack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents picEnemySprite As PictureBox
    Friend WithEvents picPlayerSprite As PictureBox
    Friend WithEvents lblEnemyHP As Label
    Friend WithEvents lblEnemyName As Label
    Friend WithEvents lblTimer As Label
    Friend WithEvents lblQuestionText As Label
    Friend WithEvents lblPlayerHP As Label
    Friend WithEvents lblPlayerName As Label
    Friend WithEvents pbPlayerHP As ProgressBar
    Friend WithEvents pbEnemyHP As ProgressBar
    Friend WithEvents txtPlayerAnswer As TextBox
    Friend WithEvents btnSubmitAnswer As Button
    Friend WithEvents picPlayerAttack As PictureBox
End Class
