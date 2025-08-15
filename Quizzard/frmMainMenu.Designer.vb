<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainMenu))
        Me.btnPlay = New System.Windows.Forms.Button()
        Me.btnDeckManager = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnOptions = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnPlay
        '
        Me.btnPlay.BackColor = System.Drawing.Color.Transparent
        Me.btnPlay.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPlay.FlatAppearance.BorderSize = 0
        Me.btnPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPlay.Location = New System.Drawing.Point(50, 259)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(252, 48)
        Me.btnPlay.TabIndex = 0
        Me.btnPlay.Text = "       "
        Me.btnPlay.UseVisualStyleBackColor = False
        '
        'btnDeckManager
        '
        Me.btnDeckManager.BackColor = System.Drawing.Color.Transparent
        Me.btnDeckManager.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDeckManager.FlatAppearance.BorderSize = 0
        Me.btnDeckManager.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnDeckManager.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnDeckManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeckManager.Location = New System.Drawing.Point(50, 328)
        Me.btnDeckManager.Name = "btnDeckManager"
        Me.btnDeckManager.Size = New System.Drawing.Size(289, 59)
        Me.btnDeckManager.TabIndex = 1
        Me.btnDeckManager.Text = "       "
        Me.btnDeckManager.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(50, 403)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(225, 47)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "       "
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnOptions
        '
        Me.btnOptions.Location = New System.Drawing.Point(870, 481)
        Me.btnOptions.Name = "btnOptions"
        Me.btnOptions.Size = New System.Drawing.Size(229, 63)
        Me.btnOptions.TabIndex = 2
        Me.btnOptions.Text = "options"
        Me.btnOptions.UseVisualStyleBackColor = True
        Me.btnOptions.Visible = False
        '
        'frmMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Global.Quizzard.My.Resources.Resources.bgMainMenu
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(887, 500)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnOptions)
        Me.Controls.Add(Me.btnDeckManager)
        Me.Controls.Add(Me.btnPlay)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMainMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main Menu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnPlay As Button
    Friend WithEvents btnDeckManager As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnOptions As Button
End Class
