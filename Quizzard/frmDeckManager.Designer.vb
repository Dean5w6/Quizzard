<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeckManager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDeckManager))
        Me.dgvDecks = New System.Windows.Forms.DataGridView()
        Me.btnCreateNew = New System.Windows.Forms.Button()
        Me.btnEditSelected = New System.Windows.Forms.Button()
        Me.btnDeleteSelected = New System.Windows.Forms.Button()
        Me.btnBackToMenu = New System.Windows.Forms.Button()
        Me.btnSelectDeck = New System.Windows.Forms.Button()
        CType(Me.dgvDecks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDecks
        '
        Me.dgvDecks.AllowUserToAddRows = False
        Me.dgvDecks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDecks.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Constantia", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Chocolate
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDecks.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDecks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Constantia", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Chocolate
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDecks.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDecks.Location = New System.Drawing.Point(25, 23)
        Me.dgvDecks.Name = "dgvDecks"
        Me.dgvDecks.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Constantia", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Chocolate
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDecks.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDecks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDecks.Size = New System.Drawing.Size(837, 355)
        Me.dgvDecks.TabIndex = 0
        '
        'btnCreateNew
        '
        Me.btnCreateNew.BackColor = System.Drawing.Color.Transparent
        Me.btnCreateNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCreateNew.FlatAppearance.BorderSize = 0
        Me.btnCreateNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnCreateNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnCreateNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreateNew.Location = New System.Drawing.Point(214, 400)
        Me.btnCreateNew.Name = "btnCreateNew"
        Me.btnCreateNew.Size = New System.Drawing.Size(132, 79)
        Me.btnCreateNew.TabIndex = 1
        Me.btnCreateNew.Text = "         "
        Me.btnCreateNew.UseVisualStyleBackColor = False
        '
        'btnEditSelected
        '
        Me.btnEditSelected.BackColor = System.Drawing.Color.Transparent
        Me.btnEditSelected.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEditSelected.FlatAppearance.BorderSize = 0
        Me.btnEditSelected.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnEditSelected.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnEditSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditSelected.Location = New System.Drawing.Point(429, 400)
        Me.btnEditSelected.Name = "btnEditSelected"
        Me.btnEditSelected.Size = New System.Drawing.Size(159, 79)
        Me.btnEditSelected.TabIndex = 2
        Me.btnEditSelected.Text = "         "
        Me.btnEditSelected.UseVisualStyleBackColor = False
        '
        'btnDeleteSelected
        '
        Me.btnDeleteSelected.BackColor = System.Drawing.Color.Transparent
        Me.btnDeleteSelected.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDeleteSelected.FlatAppearance.BorderSize = 0
        Me.btnDeleteSelected.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnDeleteSelected.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnDeleteSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteSelected.Location = New System.Drawing.Point(679, 400)
        Me.btnDeleteSelected.Name = "btnDeleteSelected"
        Me.btnDeleteSelected.Size = New System.Drawing.Size(183, 79)
        Me.btnDeleteSelected.TabIndex = 3
        Me.btnDeleteSelected.Text = "         "
        Me.btnDeleteSelected.UseVisualStyleBackColor = False
        '
        'btnBackToMenu
        '
        Me.btnBackToMenu.BackColor = System.Drawing.Color.Transparent
        Me.btnBackToMenu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBackToMenu.FlatAppearance.BorderSize = 0
        Me.btnBackToMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnBackToMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnBackToMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBackToMenu.Location = New System.Drawing.Point(25, 407)
        Me.btnBackToMenu.Name = "btnBackToMenu"
        Me.btnBackToMenu.Size = New System.Drawing.Size(100, 82)
        Me.btnBackToMenu.TabIndex = 4
        Me.btnBackToMenu.Text = "         "
        Me.btnBackToMenu.UseVisualStyleBackColor = False
        '
        'btnSelectDeck
        '
        Me.btnSelectDeck.BackColor = System.Drawing.Color.White
        Me.btnSelectDeck.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSelectDeck.FlatAppearance.BorderSize = 0
        Me.btnSelectDeck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnSelectDeck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnSelectDeck.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectDeck.Font = New System.Drawing.Font("Constantia", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectDeck.Location = New System.Drawing.Point(742, 337)
        Me.btnSelectDeck.Name = "btnSelectDeck"
        Me.btnSelectDeck.Size = New System.Drawing.Size(100, 23)
        Me.btnSelectDeck.TabIndex = 5
        Me.btnSelectDeck.Text = "Select Deck"
        Me.btnSelectDeck.UseVisualStyleBackColor = False
        '
        'frmDeckManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Quizzard.My.Resources.Resources.bgDeckManager
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(892, 501)
        Me.Controls.Add(Me.btnSelectDeck)
        Me.Controls.Add(Me.btnBackToMenu)
        Me.Controls.Add(Me.btnDeleteSelected)
        Me.Controls.Add(Me.btnEditSelected)
        Me.Controls.Add(Me.btnCreateNew)
        Me.Controls.Add(Me.dgvDecks)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmDeckManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Deck Manager"
        CType(Me.dgvDecks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvDecks As DataGridView
    Friend WithEvents btnCreateNew As Button
    Friend WithEvents btnEditSelected As Button
    Friend WithEvents btnDeleteSelected As Button
    Friend WithEvents btnBackToMenu As Button
    Friend WithEvents btnSelectDeck As Button
End Class
