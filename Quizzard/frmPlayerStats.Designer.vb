<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlayerStats
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlayerStats))
        Me.lblSkillPoints = New System.Windows.Forms.Label()
        Me.lblLuckValue = New System.Windows.Forms.Label()
        Me.lblResilValue = New System.Windows.Forms.Label()
        Me.lblFocusValue = New System.Windows.Forms.Label()
        Me.lblIntelValue = New System.Windows.Forms.Label()
        Me.lblPlayerLevel = New System.Windows.Forms.Label()
        Me.lblExperience = New System.Windows.Forms.Label()
        Me.pbExperience = New System.Windows.Forms.ProgressBar()
        Me.btnBackToLobby = New System.Windows.Forms.Button()
        Me.btnIncreaseLuck = New System.Windows.Forms.Button()
        Me.btnIncreaseFocus = New System.Windows.Forms.Button()
        Me.btnIncreaseResil = New System.Windows.Forms.Button()
        Me.btnIncreaseIntel = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSkillPoints
        '
        Me.lblSkillPoints.AutoSize = True
        Me.lblSkillPoints.BackColor = System.Drawing.Color.Transparent
        Me.lblSkillPoints.ForeColor = System.Drawing.Color.White
        Me.lblSkillPoints.Location = New System.Drawing.Point(458, 367)
        Me.lblSkillPoints.Name = "lblSkillPoints"
        Me.lblSkillPoints.Size = New System.Drawing.Size(65, 13)
        Me.lblSkillPoints.TabIndex = 0
        Me.lblSkillPoints.Text = "lblSkillPoints"
        '
        'lblLuckValue
        '
        Me.lblLuckValue.AutoSize = True
        Me.lblLuckValue.BackColor = System.Drawing.Color.Transparent
        Me.lblLuckValue.ForeColor = System.Drawing.Color.White
        Me.lblLuckValue.Location = New System.Drawing.Point(459, 115)
        Me.lblLuckValue.Name = "lblLuckValue"
        Me.lblLuckValue.Size = New System.Drawing.Size(68, 13)
        Me.lblLuckValue.TabIndex = 5
        Me.lblLuckValue.Text = "lblLuckValue"
        '
        'lblResilValue
        '
        Me.lblResilValue.AutoSize = True
        Me.lblResilValue.BackColor = System.Drawing.Color.Transparent
        Me.lblResilValue.ForeColor = System.Drawing.Color.White
        Me.lblResilValue.Location = New System.Drawing.Point(459, 175)
        Me.lblResilValue.Name = "lblResilValue"
        Me.lblResilValue.Size = New System.Drawing.Size(67, 13)
        Me.lblResilValue.TabIndex = 4
        Me.lblResilValue.Text = "lblResilValue"
        '
        'lblFocusValue
        '
        Me.lblFocusValue.AutoSize = True
        Me.lblFocusValue.BackColor = System.Drawing.Color.Transparent
        Me.lblFocusValue.ForeColor = System.Drawing.Color.White
        Me.lblFocusValue.Location = New System.Drawing.Point(459, 235)
        Me.lblFocusValue.Name = "lblFocusValue"
        Me.lblFocusValue.Size = New System.Drawing.Size(73, 13)
        Me.lblFocusValue.TabIndex = 3
        Me.lblFocusValue.Text = "lblFocusValue"
        '
        'lblIntelValue
        '
        Me.lblIntelValue.AutoSize = True
        Me.lblIntelValue.BackColor = System.Drawing.Color.Transparent
        Me.lblIntelValue.ForeColor = System.Drawing.Color.White
        Me.lblIntelValue.Location = New System.Drawing.Point(459, 295)
        Me.lblIntelValue.Name = "lblIntelValue"
        Me.lblIntelValue.Size = New System.Drawing.Size(64, 13)
        Me.lblIntelValue.TabIndex = 6
        Me.lblIntelValue.Text = "lblIntelValue"
        '
        'lblPlayerLevel
        '
        Me.lblPlayerLevel.AutoSize = True
        Me.lblPlayerLevel.BackColor = System.Drawing.Color.Transparent
        Me.lblPlayerLevel.ForeColor = System.Drawing.Color.White
        Me.lblPlayerLevel.Location = New System.Drawing.Point(42, 45)
        Me.lblPlayerLevel.Name = "lblPlayerLevel"
        Me.lblPlayerLevel.Size = New System.Drawing.Size(73, 13)
        Me.lblPlayerLevel.TabIndex = 13
        Me.lblPlayerLevel.Text = "lblPlayerValue"
        '
        'lblExperience
        '
        Me.lblExperience.AutoSize = True
        Me.lblExperience.BackColor = System.Drawing.Color.Transparent
        Me.lblExperience.ForeColor = System.Drawing.Color.White
        Me.lblExperience.Location = New System.Drawing.Point(42, 69)
        Me.lblExperience.Name = "lblExperience"
        Me.lblExperience.Size = New System.Drawing.Size(70, 13)
        Me.lblExperience.TabIndex = 11
        Me.lblExperience.Text = "lblExperience"
        '
        'pbExperience
        '
        Me.pbExperience.BackColor = System.Drawing.Color.White
        Me.pbExperience.ForeColor = System.Drawing.Color.Green
        Me.pbExperience.Location = New System.Drawing.Point(45, 92)
        Me.pbExperience.Name = "pbExperience"
        Me.pbExperience.Size = New System.Drawing.Size(170, 23)
        Me.pbExperience.TabIndex = 17
        '
        'btnBackToLobby
        '
        Me.btnBackToLobby.BackColor = System.Drawing.Color.Transparent
        Me.btnBackToLobby.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBackToLobby.FlatAppearance.BorderSize = 0
        Me.btnBackToLobby.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnBackToLobby.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnBackToLobby.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBackToLobby.Location = New System.Drawing.Point(45, 401)
        Me.btnBackToLobby.Name = "btnBackToLobby"
        Me.btnBackToLobby.Size = New System.Drawing.Size(132, 79)
        Me.btnBackToLobby.TabIndex = 18
        Me.btnBackToLobby.Text = "        "
        Me.btnBackToLobby.UseVisualStyleBackColor = False
        '
        'btnIncreaseLuck
        '
        Me.btnIncreaseLuck.BackColor = System.Drawing.Color.Transparent
        Me.btnIncreaseLuck.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIncreaseLuck.Enabled = False
        Me.btnIncreaseLuck.FlatAppearance.BorderSize = 0
        Me.btnIncreaseLuck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnIncreaseLuck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnIncreaseLuck.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIncreaseLuck.ForeColor = System.Drawing.Color.White
        Me.btnIncreaseLuck.Location = New System.Drawing.Point(591, 106)
        Me.btnIncreaseLuck.Name = "btnIncreaseLuck"
        Me.btnIncreaseLuck.Size = New System.Drawing.Size(81, 41)
        Me.btnIncreaseLuck.TabIndex = 19
        Me.btnIncreaseLuck.Text = "+"
        Me.btnIncreaseLuck.UseVisualStyleBackColor = False
        '
        'btnIncreaseFocus
        '
        Me.btnIncreaseFocus.BackColor = System.Drawing.Color.Transparent
        Me.btnIncreaseFocus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIncreaseFocus.Enabled = False
        Me.btnIncreaseFocus.FlatAppearance.BorderSize = 0
        Me.btnIncreaseFocus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnIncreaseFocus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnIncreaseFocus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIncreaseFocus.ForeColor = System.Drawing.Color.White
        Me.btnIncreaseFocus.Location = New System.Drawing.Point(591, 227)
        Me.btnIncreaseFocus.Name = "btnIncreaseFocus"
        Me.btnIncreaseFocus.Size = New System.Drawing.Size(81, 41)
        Me.btnIncreaseFocus.TabIndex = 20
        Me.btnIncreaseFocus.Text = "+"
        Me.btnIncreaseFocus.UseVisualStyleBackColor = False
        '
        'btnIncreaseResil
        '
        Me.btnIncreaseResil.BackColor = System.Drawing.Color.Transparent
        Me.btnIncreaseResil.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIncreaseResil.Enabled = False
        Me.btnIncreaseResil.FlatAppearance.BorderSize = 0
        Me.btnIncreaseResil.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnIncreaseResil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnIncreaseResil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIncreaseResil.ForeColor = System.Drawing.Color.White
        Me.btnIncreaseResil.Location = New System.Drawing.Point(591, 167)
        Me.btnIncreaseResil.Name = "btnIncreaseResil"
        Me.btnIncreaseResil.Size = New System.Drawing.Size(81, 41)
        Me.btnIncreaseResil.TabIndex = 21
        Me.btnIncreaseResil.Text = "+"
        Me.btnIncreaseResil.UseVisualStyleBackColor = False
        '
        'btnIncreaseIntel
        '
        Me.btnIncreaseIntel.BackColor = System.Drawing.Color.Transparent
        Me.btnIncreaseIntel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIncreaseIntel.Enabled = False
        Me.btnIncreaseIntel.FlatAppearance.BorderSize = 0
        Me.btnIncreaseIntel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnIncreaseIntel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnIncreaseIntel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIncreaseIntel.ForeColor = System.Drawing.Color.White
        Me.btnIncreaseIntel.Location = New System.Drawing.Point(591, 287)
        Me.btnIncreaseIntel.Name = "btnIncreaseIntel"
        Me.btnIncreaseIntel.Size = New System.Drawing.Size(81, 41)
        Me.btnIncreaseIntel.TabIndex = 22
        Me.btnIncreaseIntel.Text = "+"
        Me.btnIncreaseIntel.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.Quizzard.My.Resources.Resources.char5
        Me.PictureBox1.Location = New System.Drawing.Point(147, 161)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(152, 150)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 23
        Me.PictureBox1.TabStop = False
        '
        'frmPlayerStats
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MidnightBlue
        Me.BackgroundImage = Global.Quizzard.My.Resources.Resources.bgPlayerStats
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(892, 501)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnIncreaseIntel)
        Me.Controls.Add(Me.btnIncreaseResil)
        Me.Controls.Add(Me.btnIncreaseFocus)
        Me.Controls.Add(Me.btnIncreaseLuck)
        Me.Controls.Add(Me.btnBackToLobby)
        Me.Controls.Add(Me.pbExperience)
        Me.Controls.Add(Me.lblPlayerLevel)
        Me.Controls.Add(Me.lblExperience)
        Me.Controls.Add(Me.lblIntelValue)
        Me.Controls.Add(Me.lblLuckValue)
        Me.Controls.Add(Me.lblResilValue)
        Me.Controls.Add(Me.lblFocusValue)
        Me.Controls.Add(Me.lblSkillPoints)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmPlayerStats"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stats"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblSkillPoints As Label
    Friend WithEvents lblLuckValue As Label
    Friend WithEvents lblResilValue As Label
    Friend WithEvents lblFocusValue As Label
    Friend WithEvents lblIntelValue As Label
    Friend WithEvents lblPlayerLevel As Label
    Friend WithEvents lblExperience As Label
    Friend WithEvents pbExperience As ProgressBar
    Friend WithEvents btnBackToLobby As Button
    Friend WithEvents btnIncreaseLuck As Button
    Friend WithEvents btnIncreaseFocus As Button
    Friend WithEvents btnIncreaseResil As Button
    Friend WithEvents btnIncreaseIntel As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
