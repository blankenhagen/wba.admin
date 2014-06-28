<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAuftrag
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAuftrag))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.EndeMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AuftragMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AuftragNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BenutzerToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.AuftraegeToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.FilterGroupBox = New System.Windows.Forms.GroupBox()
        Me.FilterComboBox = New System.Windows.Forms.ComboBox()
        Me.ClearButton = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.FilterButton = New System.Windows.Forms.Button()
        Me.FilterTextBox = New System.Windows.Forms.TextBox()
        Me.AuftragDataGridView = New System.Windows.Forms.DataGridView()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.FilterGroupBox.SuspendLayout()
        CType(Me.AuftragDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EndeMenuItem, Me.AuftragMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1195, 24)
        Me.MenuStrip.TabIndex = 2
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'EndeMenuItem
        '
        Me.EndeMenuItem.Name = "EndeMenuItem"
        Me.EndeMenuItem.Size = New System.Drawing.Size(45, 20)
        Me.EndeMenuItem.Text = "Ende"
        '
        'AuftragMenuItem
        '
        Me.AuftragMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AuftragNew})
        Me.AuftragMenuItem.Name = "AuftragMenuItem"
        Me.AuftragMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.AuftragMenuItem.Text = "Auftrag"
        '
        'AuftragNew
        '
        Me.AuftragNew.Name = "AuftragNew"
        Me.AuftragNew.Size = New System.Drawing.Size(96, 22)
        Me.AuftragNew.Text = "Neu"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.BenutzerToolStripStatusLabel, Me.ToolStripStatusLabel3, Me.AuftraegeToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 519)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1195, 22)
        Me.StatusStrip.SizingGrip = False
        Me.StatusStrip.TabIndex = 44
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(78, 17)
        Me.ToolStripStatusLabel1.Text = "Angemeldet: "
        '
        'BenutzerToolStripStatusLabel
        '
        Me.BenutzerToolStripStatusLabel.AutoSize = False
        Me.BenutzerToolStripStatusLabel.Name = "BenutzerToolStripStatusLabel"
        Me.BenutzerToolStripStatusLabel.Size = New System.Drawing.Size(1010, 17)
        Me.BenutzerToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(56, 17)
        Me.ToolStripStatusLabel3.Text = "Aufträge:"
        '
        'AuftraegeToolStripStatusLabel
        '
        Me.AuftraegeToolStripStatusLabel.Name = "AuftraegeToolStripStatusLabel"
        Me.AuftraegeToolStripStatusLabel.Size = New System.Drawing.Size(25, 17)
        Me.AuftraegeToolStripStatusLabel.Text = "999"
        '
        'FilterGroupBox
        '
        Me.FilterGroupBox.Controls.Add(Me.FilterComboBox)
        Me.FilterGroupBox.Controls.Add(Me.ClearButton)
        Me.FilterGroupBox.Controls.Add(Me.FilterButton)
        Me.FilterGroupBox.Controls.Add(Me.FilterTextBox)
        Me.FilterGroupBox.Location = New System.Drawing.Point(12, 27)
        Me.FilterGroupBox.Name = "FilterGroupBox"
        Me.FilterGroupBox.Size = New System.Drawing.Size(1171, 52)
        Me.FilterGroupBox.TabIndex = 50
        Me.FilterGroupBox.TabStop = False
        Me.FilterGroupBox.Text = "Filter"
        '
        'FilterComboBox
        '
        Me.FilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FilterComboBox.FormattingEnabled = True
        Me.FilterComboBox.Items.AddRange(New Object() {"RUECK", "AUFNR", "IDNR"})
        Me.FilterComboBox.Location = New System.Drawing.Point(6, 19)
        Me.FilterComboBox.Name = "FilterComboBox"
        Me.FilterComboBox.Size = New System.Drawing.Size(89, 21)
        Me.FilterComboBox.TabIndex = 42
        Me.ToolTip1.SetToolTip(Me.FilterComboBox, "Auswahl Tabellen Spalte")
        '
        'ClearButton
        '
        Me.ClearButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ClearButton.ImageIndex = 1
        Me.ClearButton.ImageList = Me.ImageList1
        Me.ClearButton.Location = New System.Drawing.Point(198, 18)
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.Size = New System.Drawing.Size(23, 23)
        Me.ClearButton.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.ClearButton, "Filter löschen" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Alle anzeigen")
        Me.ClearButton.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Fuchsia
        Me.ImageList1.Images.SetKeyName(0, "filter.bmp")
        Me.ImageList1.Images.SetKeyName(1, "clear.bmp")
        '
        'FilterButton
        '
        Me.FilterButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.FilterButton.ImageIndex = 0
        Me.FilterButton.ImageList = Me.ImageList1
        Me.FilterButton.Location = New System.Drawing.Point(227, 18)
        Me.FilterButton.Name = "FilterButton"
        Me.FilterButton.Size = New System.Drawing.Size(23, 23)
        Me.FilterButton.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.FilterButton, "Filter anwenden")
        Me.FilterButton.UseVisualStyleBackColor = True
        '
        'FilterTextBox
        '
        Me.FilterTextBox.Location = New System.Drawing.Point(101, 20)
        Me.FilterTextBox.Name = "FilterTextBox"
        Me.FilterTextBox.Size = New System.Drawing.Size(91, 20)
        Me.FilterTextBox.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.FilterTextBox, "Eingabe Filter")
        '
        'AuftragDataGridView
        '
        Me.AuftragDataGridView.AllowUserToAddRows = False
        Me.AuftragDataGridView.AllowUserToDeleteRows = False
        Me.AuftragDataGridView.AllowUserToOrderColumns = True
        Me.AuftragDataGridView.AllowUserToResizeColumns = False
        Me.AuftragDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Tan
        Me.AuftragDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.AuftragDataGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AuftragDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AuftragDataGridView.Location = New System.Drawing.Point(12, 85)
        Me.AuftragDataGridView.MultiSelect = False
        Me.AuftragDataGridView.Name = "AuftragDataGridView"
        Me.AuftragDataGridView.ReadOnly = True
        Me.AuftragDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.AuftragDataGridView.Size = New System.Drawing.Size(1171, 419)
        Me.AuftragDataGridView.TabIndex = 51
        '
        'FormAuftrag
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1195, 541)
        Me.ControlBox = False
        Me.Controls.Add(Me.AuftragDataGridView)
        Me.Controls.Add(Me.FilterGroupBox)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormAuftrag"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Aufträge"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.FilterGroupBox.ResumeLayout(False)
        Me.FilterGroupBox.PerformLayout()
        CType(Me.AuftragDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents EndeMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AuftragMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AuftragNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BenutzerToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents AuftraegeToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents FilterGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents FilterComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ClearButton As System.Windows.Forms.Button
    Friend WithEvents FilterButton As System.Windows.Forms.Button
    Friend WithEvents FilterTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AuftragDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class
