<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBauteil
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBauteil))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.EndeMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BauteilMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BauteilNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.BauteilEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.BauteilDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.HistoryMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HistoryBauteil = New System.Windows.Forms.ToolStripMenuItem()
        Me.HistoryEMP = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BenutzerToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BauteileToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.WarmbehandlungDataGridView = New System.Windows.Forms.DataGridView()
        Me.EMP_GroupBox = New System.Windows.Forms.GroupBox()
        Me.RemoveButton = New System.Windows.Forms.Button()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.AddButton = New System.Windows.Forms.Button()
        Me.BenutzerLabel = New System.Windows.Forms.Label()
        Me.EMP_Button = New System.Windows.Forms.Button()
        Me.ZeitstempelLabel = New System.Windows.Forms.Label()
        Me.FilterGroupBox = New System.Windows.Forms.GroupBox()
        Me.FilterComboBox = New System.Windows.Forms.ComboBox()
        Me.ClearButton = New System.Windows.Forms.Button()
        Me.FilterButton = New System.Windows.Forms.Button()
        Me.FilterTextBox = New System.Windows.Forms.TextBox()
        Me.BauteilDataGridView = New System.Windows.Forms.DataGridView()
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        CType(Me.WarmbehandlungDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EMP_GroupBox.SuspendLayout()
        Me.FilterGroupBox.SuspendLayout()
        CType(Me.BauteilDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EndeMenuItem, Me.BauteilMenuItem, Me.HistoryMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(510, 24)
        Me.MenuStrip.TabIndex = 2
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'EndeMenuItem
        '
        Me.EndeMenuItem.Name = "EndeMenuItem"
        Me.EndeMenuItem.Size = New System.Drawing.Size(45, 20)
        Me.EndeMenuItem.Text = "Ende"
        '
        'BauteilMenuItem
        '
        Me.BauteilMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BauteilNew, Me.BauteilEdit, Me.BauteilDelete})
        Me.BauteilMenuItem.Name = "BauteilMenuItem"
        Me.BauteilMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.BauteilMenuItem.Text = "Bauteil"
        '
        'BauteilNew
        '
        Me.BauteilNew.Name = "BauteilNew"
        Me.BauteilNew.Size = New System.Drawing.Size(130, 22)
        Me.BauteilNew.Text = "Neu"
        '
        'BauteilEdit
        '
        Me.BauteilEdit.Name = "BauteilEdit"
        Me.BauteilEdit.Size = New System.Drawing.Size(130, 22)
        Me.BauteilEdit.Text = "Bearbeiten"
        '
        'BauteilDelete
        '
        Me.BauteilDelete.Name = "BauteilDelete"
        Me.BauteilDelete.Size = New System.Drawing.Size(130, 22)
        Me.BauteilDelete.Text = "Löschen"
        '
        'HistoryMenuItem
        '
        Me.HistoryMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HistoryBauteil, Me.HistoryEMP})
        Me.HistoryMenuItem.Name = "HistoryMenuItem"
        Me.HistoryMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.HistoryMenuItem.Text = "Historie"
        '
        'HistoryBauteil
        '
        Me.HistoryBauteil.Name = "HistoryBauteil"
        Me.HistoryBauteil.Size = New System.Drawing.Size(152, 22)
        Me.HistoryBauteil.Text = "Bauteil"
        '
        'HistoryEMP
        '
        Me.HistoryEMP.Name = "HistoryEMP"
        Me.HistoryEMP.Size = New System.Drawing.Size(152, 22)
        Me.HistoryEMP.Text = "EMP"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.BenutzerToolStripStatusLabel, Me.ToolStripStatusLabel3, Me.BauteileToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 418)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(510, 22)
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
        Me.BenutzerToolStripStatusLabel.Size = New System.Drawing.Size(300, 17)
        Me.BenutzerToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(52, 17)
        Me.ToolStripStatusLabel3.Text = "Bauteile:"
        '
        'BauteileToolStripStatusLabel
        '
        Me.BauteileToolStripStatusLabel.Name = "BauteileToolStripStatusLabel"
        Me.BauteileToolStripStatusLabel.Size = New System.Drawing.Size(0, 17)
        Me.BauteileToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'WarmbehandlungDataGridView
        '
        Me.WarmbehandlungDataGridView.AllowUserToAddRows = False
        Me.WarmbehandlungDataGridView.AllowUserToDeleteRows = False
        Me.WarmbehandlungDataGridView.AllowUserToResizeColumns = False
        Me.WarmbehandlungDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Tan
        Me.WarmbehandlungDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.WarmbehandlungDataGridView.BackgroundColor = System.Drawing.SystemColors.Window
        Me.WarmbehandlungDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.WarmbehandlungDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.WarmbehandlungDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.WarmbehandlungDataGridView.Location = New System.Drawing.Point(6, 95)
        Me.WarmbehandlungDataGridView.MultiSelect = False
        Me.WarmbehandlungDataGridView.Name = "WarmbehandlungDataGridView"
        Me.WarmbehandlungDataGridView.ReadOnly = True
        Me.WarmbehandlungDataGridView.RowHeadersVisible = False
        Me.WarmbehandlungDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.WarmbehandlungDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.WarmbehandlungDataGridView.Size = New System.Drawing.Size(201, 135)
        Me.WarmbehandlungDataGridView.TabIndex = 45
        '
        'EMP_GroupBox
        '
        Me.EMP_GroupBox.Controls.Add(Me.RemoveButton)
        Me.EMP_GroupBox.Controls.Add(Me.AddButton)
        Me.EMP_GroupBox.Controls.Add(Me.BenutzerLabel)
        Me.EMP_GroupBox.Controls.Add(Me.EMP_Button)
        Me.EMP_GroupBox.Controls.Add(Me.ZeitstempelLabel)
        Me.EMP_GroupBox.Controls.Add(Me.WarmbehandlungDataGridView)
        Me.EMP_GroupBox.Location = New System.Drawing.Point(288, 140)
        Me.EMP_GroupBox.Name = "EMP_GroupBox"
        Me.EMP_GroupBox.Size = New System.Drawing.Size(213, 268)
        Me.EMP_GroupBox.TabIndex = 48
        Me.EMP_GroupBox.TabStop = False
        Me.EMP_GroupBox.Text = "Erstmusterprüfung"
        '
        'RemoveButton
        '
        Me.RemoveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RemoveButton.ImageIndex = 16
        Me.RemoveButton.ImageList = Me.ImageList
        Me.RemoveButton.Location = New System.Drawing.Point(111, 236)
        Me.RemoveButton.Name = "RemoveButton"
        Me.RemoveButton.Size = New System.Drawing.Size(96, 23)
        Me.RemoveButton.TabIndex = 48
        Me.RemoveButton.Text = "Entfernen"
        Me.RemoveButton.UseVisualStyleBackColor = True
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Fuchsia
        Me.ImageList.Images.SetKeyName(0, "clock-2.bmp")
        Me.ImageList.Images.SetKeyName(1, "flag-blue.bmp")
        Me.ImageList.Images.SetKeyName(2, "flag-green.bmp")
        Me.ImageList.Images.SetKeyName(3, "flag-red.bmp")
        Me.ImageList.Images.SetKeyName(4, "LED-Green.bmp")
        Me.ImageList.Images.SetKeyName(5, "LED-Red.bmp")
        Me.ImageList.Images.SetKeyName(6, "LED-Yellow.bmp")
        Me.ImageList.Images.SetKeyName(7, "lock.bmp")
        Me.ImageList.Images.SetKeyName(8, "unlock.bmp")
        Me.ImageList.Images.SetKeyName(9, "id-card.bmp")
        Me.ImageList.Images.SetKeyName(10, "Key.bmp")
        Me.ImageList.Images.SetKeyName(11, "search.bmp")
        Me.ImageList.Images.SetKeyName(12, "stamp.bmp")
        Me.ImageList.Images.SetKeyName(13, "User Add.bmp")
        Me.ImageList.Images.SetKeyName(14, "User Edit.bmp")
        Me.ImageList.Images.SetKeyName(15, "User.bmp")
        Me.ImageList.Images.SetKeyName(16, "minus.bmp")
        Me.ImageList.Images.SetKeyName(17, "plus.bmp")
        Me.ImageList.Images.SetKeyName(18, "filter.bmp")
        Me.ImageList.Images.SetKeyName(19, "clear.bmp")
        '
        'AddButton
        '
        Me.AddButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.AddButton.ImageIndex = 17
        Me.AddButton.ImageList = Me.ImageList
        Me.AddButton.Location = New System.Drawing.Point(6, 236)
        Me.AddButton.Name = "AddButton"
        Me.AddButton.Size = New System.Drawing.Size(99, 23)
        Me.AddButton.TabIndex = 47
        Me.AddButton.Text = "Zufügen"
        Me.AddButton.UseVisualStyleBackColor = True
        '
        'BenutzerLabel
        '
        Me.BenutzerLabel.Location = New System.Drawing.Point(6, 43)
        Me.BenutzerLabel.Name = "BenutzerLabel"
        Me.BenutzerLabel.Size = New System.Drawing.Size(201, 20)
        Me.BenutzerLabel.TabIndex = 46
        Me.BenutzerLabel.Text = "Benutzer"
        Me.BenutzerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'EMP_Button
        '
        Me.EMP_Button.Location = New System.Drawing.Point(6, 66)
        Me.EMP_Button.Name = "EMP_Button"
        Me.EMP_Button.Size = New System.Drawing.Size(201, 23)
        Me.EMP_Button.TabIndex = 16
        Me.EMP_Button.Text = "btnEMP"
        Me.EMP_Button.UseVisualStyleBackColor = True
        '
        'ZeitstempelLabel
        '
        Me.ZeitstempelLabel.Location = New System.Drawing.Point(6, 23)
        Me.ZeitstempelLabel.Name = "ZeitstempelLabel"
        Me.ZeitstempelLabel.Size = New System.Drawing.Size(201, 20)
        Me.ZeitstempelLabel.TabIndex = 15
        Me.ZeitstempelLabel.Text = "Zeitstempel"
        Me.ZeitstempelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FilterGroupBox
        '
        Me.FilterGroupBox.Controls.Add(Me.FilterComboBox)
        Me.FilterGroupBox.Controls.Add(Me.ClearButton)
        Me.FilterGroupBox.Controls.Add(Me.FilterButton)
        Me.FilterGroupBox.Controls.Add(Me.FilterTextBox)
        Me.FilterGroupBox.Location = New System.Drawing.Point(288, 27)
        Me.FilterGroupBox.Name = "FilterGroupBox"
        Me.FilterGroupBox.Size = New System.Drawing.Size(213, 107)
        Me.FilterGroupBox.TabIndex = 49
        Me.FilterGroupBox.TabStop = False
        Me.FilterGroupBox.Text = "Filter"
        '
        'FilterComboBox
        '
        Me.FilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FilterComboBox.FormattingEnabled = True
        Me.FilterComboBox.Items.AddRange(New Object() {"HTZ", "IDNR", "PL"})
        Me.FilterComboBox.Location = New System.Drawing.Point(6, 19)
        Me.FilterComboBox.Name = "FilterComboBox"
        Me.FilterComboBox.Size = New System.Drawing.Size(198, 21)
        Me.FilterComboBox.TabIndex = 42
        '
        'ClearButton
        '
        Me.ClearButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ClearButton.ImageIndex = 19
        Me.ClearButton.ImageList = Me.ImageList
        Me.ClearButton.Location = New System.Drawing.Point(129, 78)
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.Size = New System.Drawing.Size(75, 23)
        Me.ClearButton.TabIndex = 2
        Me.ClearButton.Text = "Clear"
        Me.ClearButton.UseVisualStyleBackColor = True
        '
        'FilterButton
        '
        Me.FilterButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.FilterButton.ImageIndex = 18
        Me.FilterButton.ImageList = Me.ImageList
        Me.FilterButton.Location = New System.Drawing.Point(6, 78)
        Me.FilterButton.Name = "FilterButton"
        Me.FilterButton.Size = New System.Drawing.Size(75, 23)
        Me.FilterButton.TabIndex = 1
        Me.FilterButton.Text = "Start"
        Me.FilterButton.UseVisualStyleBackColor = True
        '
        'FilterTextBox
        '
        Me.FilterTextBox.Location = New System.Drawing.Point(6, 46)
        Me.FilterTextBox.Name = "FilterTextBox"
        Me.FilterTextBox.Size = New System.Drawing.Size(198, 20)
        Me.FilterTextBox.TabIndex = 0
        '
        'BauteilDataGridView
        '
        Me.BauteilDataGridView.AllowUserToAddRows = False
        Me.BauteilDataGridView.AllowUserToDeleteRows = False
        Me.BauteilDataGridView.AllowUserToOrderColumns = True
        Me.BauteilDataGridView.AllowUserToResizeColumns = False
        Me.BauteilDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Tan
        Me.BauteilDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.BauteilDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.BauteilDataGridView.Location = New System.Drawing.Point(18, 33)
        Me.BauteilDataGridView.MultiSelect = False
        Me.BauteilDataGridView.Name = "BauteilDataGridView"
        Me.BauteilDataGridView.ReadOnly = True
        Me.BauteilDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.BauteilDataGridView.Size = New System.Drawing.Size(270, 375)
        Me.BauteilDataGridView.TabIndex = 46
        '
        'FormBauteil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(510, 440)
        Me.ControlBox = False
        Me.Controls.Add(Me.BauteilDataGridView)
        Me.Controls.Add(Me.FilterGroupBox)
        Me.Controls.Add(Me.EMP_GroupBox)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormBauteil"
        Me.Text = "Bauteile verwalten"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        CType(Me.WarmbehandlungDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EMP_GroupBox.ResumeLayout(False)
        Me.FilterGroupBox.ResumeLayout(False)
        Me.FilterGroupBox.PerformLayout()
        CType(Me.BauteilDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents EndeMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BauteilMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BauteilNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BauteilEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BauteilDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents WarmbehandlungDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents EMP_GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents EMP_Button As System.Windows.Forms.Button
    Friend WithEvents ZeitstempelLabel As System.Windows.Forms.Label
    Friend WithEvents RemoveButton As System.Windows.Forms.Button
    Friend WithEvents AddButton As System.Windows.Forms.Button
    Friend WithEvents BenutzerLabel As System.Windows.Forms.Label
    Friend WithEvents FilterGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents FilterButton As System.Windows.Forms.Button
    Friend WithEvents FilterTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BauteilDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents HistoryDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClearButton As System.Windows.Forms.Button
    Friend WithEvents FilterComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents HistoryMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HistoryBauteil As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HistoryEMP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BenutzerToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BauteileToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
End Class
