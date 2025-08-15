<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeckEditor
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDeckEditor))
        Me.lblDeckName = New System.Windows.Forms.Label()
        Me.txtQuestionText = New System.Windows.Forms.TextBox()
        Me.txtAnswer = New System.Windows.Forms.TextBox()
        Me.dgvQuestions = New System.Windows.Forms.DataGridView()
        Me.btnAddQuestion = New System.Windows.Forms.Button()
        Me.btnUpdateQuestion = New System.Windows.Forms.Button()
        Me.btnSaveChanges = New System.Windows.Forms.Button()
        Me.btnDeleteQuestion = New System.Windows.Forms.Button()
        CType(Me.dgvQuestions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblDeckName
        '
        Me.lblDeckName.AutoSize = True
        Me.lblDeckName.BackColor = System.Drawing.Color.Transparent
        Me.lblDeckName.Location = New System.Drawing.Point(19, 21)
        Me.lblDeckName.Name = "lblDeckName"
        Me.lblDeckName.Size = New System.Drawing.Size(137, 13)
        Me.lblDeckName.TabIndex = 0
        Me.lblDeckName.Text = "Editing Deck: [Deck Name]"
        '
        'txtQuestionText
        '
        Me.txtQuestionText.Font = New System.Drawing.Font("Constantia", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuestionText.Location = New System.Drawing.Point(22, 343)
        Me.txtQuestionText.Name = "txtQuestionText"
        Me.txtQuestionText.Size = New System.Drawing.Size(373, 23)
        Me.txtQuestionText.TabIndex = 3
        '
        'txtAnswer
        '
        Me.txtAnswer.Font = New System.Drawing.Font("Constantia", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnswer.Location = New System.Drawing.Point(489, 343)
        Me.txtAnswer.Name = "txtAnswer"
        Me.txtAnswer.Size = New System.Drawing.Size(373, 23)
        Me.txtAnswer.TabIndex = 4
        '
        'dgvQuestions
        '
        Me.dgvQuestions.AllowUserToAddRows = False
        Me.dgvQuestions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvQuestions.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Constantia", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SaddleBrown
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvQuestions.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Constantia", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SaddleBrown
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvQuestions.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvQuestions.Location = New System.Drawing.Point(23, 21)
        Me.dgvQuestions.Name = "dgvQuestions"
        Me.dgvQuestions.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Constantia", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SaddleBrown
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvQuestions.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvQuestions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvQuestions.Size = New System.Drawing.Size(839, 309)
        Me.dgvQuestions.TabIndex = 5
        '
        'btnAddQuestion
        '
        Me.btnAddQuestion.BackColor = System.Drawing.Color.Transparent
        Me.btnAddQuestion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddQuestion.FlatAppearance.BorderSize = 0
        Me.btnAddQuestion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnAddQuestion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnAddQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddQuestion.Location = New System.Drawing.Point(23, 405)
        Me.btnAddQuestion.Name = "btnAddQuestion"
        Me.btnAddQuestion.Size = New System.Drawing.Size(144, 74)
        Me.btnAddQuestion.TabIndex = 6
        Me.btnAddQuestion.Text = "       "
        Me.btnAddQuestion.UseVisualStyleBackColor = False
        '
        'btnUpdateQuestion
        '
        Me.btnUpdateQuestion.BackColor = System.Drawing.Color.Transparent
        Me.btnUpdateQuestion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpdateQuestion.FlatAppearance.BorderSize = 0
        Me.btnUpdateQuestion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnUpdateQuestion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnUpdateQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdateQuestion.Location = New System.Drawing.Point(230, 381)
        Me.btnUpdateQuestion.Name = "btnUpdateQuestion"
        Me.btnUpdateQuestion.Size = New System.Drawing.Size(165, 98)
        Me.btnUpdateQuestion.TabIndex = 7
        Me.btnUpdateQuestion.Text = "       "
        Me.btnUpdateQuestion.UseVisualStyleBackColor = False
        '
        'btnSaveChanges
        '
        Me.btnSaveChanges.BackColor = System.Drawing.Color.Transparent
        Me.btnSaveChanges.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSaveChanges.FlatAppearance.BorderSize = 0
        Me.btnSaveChanges.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnSaveChanges.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnSaveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveChanges.Location = New System.Drawing.Point(720, 405)
        Me.btnSaveChanges.Name = "btnSaveChanges"
        Me.btnSaveChanges.Size = New System.Drawing.Size(142, 73)
        Me.btnSaveChanges.TabIndex = 8
        Me.btnSaveChanges.Text = "       "
        Me.btnSaveChanges.UseVisualStyleBackColor = False
        '
        'btnDeleteQuestion
        '
        Me.btnDeleteQuestion.BackColor = System.Drawing.Color.Transparent
        Me.btnDeleteQuestion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDeleteQuestion.FlatAppearance.BorderSize = 0
        Me.btnDeleteQuestion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnDeleteQuestion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnDeleteQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteQuestion.Location = New System.Drawing.Point(468, 398)
        Me.btnDeleteQuestion.Name = "btnDeleteQuestion"
        Me.btnDeleteQuestion.Size = New System.Drawing.Size(178, 80)
        Me.btnDeleteQuestion.TabIndex = 9
        Me.btnDeleteQuestion.Text = "       "
        Me.btnDeleteQuestion.UseVisualStyleBackColor = False
        '
        'frmDeckEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SaddleBrown
        Me.BackgroundImage = Global.Quizzard.My.Resources.Resources.bgDeckEditor
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(889, 501)
        Me.Controls.Add(Me.btnDeleteQuestion)
        Me.Controls.Add(Me.btnSaveChanges)
        Me.Controls.Add(Me.btnUpdateQuestion)
        Me.Controls.Add(Me.btnAddQuestion)
        Me.Controls.Add(Me.dgvQuestions)
        Me.Controls.Add(Me.txtAnswer)
        Me.Controls.Add(Me.txtQuestionText)
        Me.Controls.Add(Me.lblDeckName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmDeckEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Deck Editor"
        CType(Me.dgvQuestions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblDeckName As Label
    Friend WithEvents txtQuestionText As TextBox
    Friend WithEvents txtAnswer As TextBox
    Friend WithEvents dgvQuestions As DataGridView
    Friend WithEvents btnAddQuestion As Button
    Friend WithEvents btnUpdateQuestion As Button
    Friend WithEvents btnSaveChanges As Button
    Friend WithEvents btnDeleteQuestion As Button
End Class
