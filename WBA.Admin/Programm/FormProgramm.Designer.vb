<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProgramm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProgramm))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.EndeMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgrammMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgrammNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgrammEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgrammDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgrammCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.HistoryMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WarmbehandlungTreeView = New System.Windows.Forms.TreeView()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.ProgrammPanel = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProgrammSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.ProgrammListView = New System.Windows.Forms.ListView()
        Me.ChartPanel = New System.Windows.Forms.Panel()
        Me.CollapseButton = New System.Windows.Forms.Button()
        Me.BemerkungLabel = New System.Windows.Forms.Label()
        Me.TreeViewPanel = New System.Windows.Forms.Panel()
        Me.NameLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FilterComboBox = New System.Windows.Forms.ComboBox()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BenutzerToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ProgrammeToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip.SuspendLayout()
        Me.ProgrammPanel.SuspendLayout()
        Me.ProgrammSplitContainer.Panel1.SuspendLayout()
        Me.ProgrammSplitContainer.Panel2.SuspendLayout()
        Me.ProgrammSplitContainer.SuspendLayout()
        Me.TreeViewPanel.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EndeMenuItem, Me.ProgrammMenuItem, Me.HistoryMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(807, 24)
        Me.MenuStrip.TabIndex = 1
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'EndeMenuItem
        '
        Me.EndeMenuItem.Name = "EndeMenuItem"
        Me.EndeMenuItem.Size = New System.Drawing.Size(45, 20)
        Me.EndeMenuItem.Text = "Ende"
        '
        'ProgrammMenuItem
        '
        Me.ProgrammMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgrammNew, Me.ProgrammEdit, Me.ProgrammDelete, Me.ProgrammCopy})
        Me.ProgrammMenuItem.Name = "ProgrammMenuItem"
        Me.ProgrammMenuItem.Size = New System.Drawing.Size(76, 20)
        Me.ProgrammMenuItem.Text = "Programm"
        '
        'ProgrammNew
        '
        Me.ProgrammNew.Name = "ProgrammNew"
        Me.ProgrammNew.Size = New System.Drawing.Size(152, 22)
        Me.ProgrammNew.Text = "Neu"
        '
        'ProgrammEdit
        '
        Me.ProgrammEdit.Name = "ProgrammEdit"
        Me.ProgrammEdit.Size = New System.Drawing.Size(152, 22)
        Me.ProgrammEdit.Text = "Bearbeiten"
        '
        'ProgrammDelete
        '
        Me.ProgrammDelete.Name = "ProgrammDelete"
        Me.ProgrammDelete.Size = New System.Drawing.Size(152, 22)
        Me.ProgrammDelete.Text = "Löschen"
        '
        'ProgrammCopy
        '
        Me.ProgrammCopy.Name = "ProgrammCopy"
        Me.ProgrammCopy.Size = New System.Drawing.Size(152, 22)
        Me.ProgrammCopy.Text = "Kopieren"
        '
        'HistoryMenuItem
        '
        Me.HistoryMenuItem.Name = "HistoryMenuItem"
        Me.HistoryMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.HistoryMenuItem.Text = "Historie"
        '
        'WarmbehandlungTreeView
        '
        Me.WarmbehandlungTreeView.HideSelection = False
        Me.WarmbehandlungTreeView.ImageIndex = 8
        Me.WarmbehandlungTreeView.ImageList = Me.ImageList
        Me.WarmbehandlungTreeView.ItemHeight = 20
        Me.WarmbehandlungTreeView.Location = New System.Drawing.Point(0, 69)
        Me.WarmbehandlungTreeView.Name = "WarmbehandlungTreeView"
        Me.WarmbehandlungTreeView.SelectedImageIndex = 0
        Me.WarmbehandlungTreeView.Size = New System.Drawing.Size(170, 374)
        Me.WarmbehandlungTreeView.TabIndex = 37
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
        Me.ImageList.Images.SetKeyName(9, "Key.bmp")
        Me.ImageList.Images.SetKeyName(10, "Warning.bmp")
        '
        'ProgrammPanel
        '
        Me.ProgrammPanel.Controls.Add(Me.Label2)
        Me.ProgrammPanel.Controls.Add(Me.ProgrammSplitContainer)
        Me.ProgrammPanel.Controls.Add(Me.BemerkungLabel)
        Me.ProgrammPanel.Location = New System.Drawing.Point(191, 33)
        Me.ProgrammPanel.Name = "ProgrammPanel"
        Me.ProgrammPanel.Size = New System.Drawing.Size(604, 443)
        Me.ProgrammPanel.TabIndex = 39
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Bemerkung"
        '
        'ProgrammSplitContainer
        '
        Me.ProgrammSplitContainer.Location = New System.Drawing.Point(0, 69)
        Me.ProgrammSplitContainer.Name = "ProgrammSplitContainer"
        '
        'ProgrammSplitContainer.Panel1
        '
        Me.ProgrammSplitContainer.Panel1.Controls.Add(Me.ProgrammListView)
        Me.ProgrammSplitContainer.Panel1MinSize = 0
        '
        'ProgrammSplitContainer.Panel2
        '
        Me.ProgrammSplitContainer.Panel2.Controls.Add(Me.ChartPanel)
        Me.ProgrammSplitContainer.Panel2.Controls.Add(Me.CollapseButton)
        Me.ProgrammSplitContainer.Size = New System.Drawing.Size(604, 374)
        Me.ProgrammSplitContainer.SplitterDistance = 129
        Me.ProgrammSplitContainer.SplitterWidth = 1
        Me.ProgrammSplitContainer.TabIndex = 45
        '
        'ProgrammListView
        '
        Me.ProgrammListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ProgrammListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ProgrammListView.LabelWrap = False
        Me.ProgrammListView.Location = New System.Drawing.Point(0, 0)
        Me.ProgrammListView.Name = "ProgrammListView"
        Me.ProgrammListView.Scrollable = False
        Me.ProgrammListView.ShowGroups = False
        Me.ProgrammListView.Size = New System.Drawing.Size(122, 374)
        Me.ProgrammListView.TabIndex = 44
        Me.ProgrammListView.UseCompatibleStateImageBehavior = False
        '
        'ChartPanel
        '
        Me.ChartPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChartPanel.Location = New System.Drawing.Point(11, 0)
        Me.ChartPanel.Name = "ChartPanel"
        Me.ChartPanel.Size = New System.Drawing.Size(463, 374)
        Me.ChartPanel.TabIndex = 1
        '
        'CollapseButton
        '
        Me.CollapseButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.CollapseButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.CollapseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CollapseButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CollapseButton.Image = Global.WBA.Admin.My.Resources.Resources.collapse_left
        Me.CollapseButton.Location = New System.Drawing.Point(0, 0)
        Me.CollapseButton.Name = "CollapseButton"
        Me.CollapseButton.Size = New System.Drawing.Size(11, 374)
        Me.CollapseButton.TabIndex = 0
        Me.CollapseButton.UseVisualStyleBackColor = False
        '
        'BemerkungLabel
        '
        Me.BemerkungLabel.AutoEllipsis = True
        Me.BemerkungLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BemerkungLabel.Location = New System.Drawing.Point(0, 17)
        Me.BemerkungLabel.Name = "BemerkungLabel"
        Me.BemerkungLabel.Size = New System.Drawing.Size(604, 46)
        Me.BemerkungLabel.TabIndex = 39
        Me.BemerkungLabel.Text = "Bemerkung"
        '
        'TreeViewPanel
        '
        Me.TreeViewPanel.Controls.Add(Me.NameLabel)
        Me.TreeViewPanel.Controls.Add(Me.Label1)
        Me.TreeViewPanel.Controls.Add(Me.FilterComboBox)
        Me.TreeViewPanel.Controls.Add(Me.WarmbehandlungTreeView)
        Me.TreeViewPanel.Location = New System.Drawing.Point(12, 33)
        Me.TreeViewPanel.Name = "TreeViewPanel"
        Me.TreeViewPanel.Size = New System.Drawing.Size(173, 443)
        Me.TreeViewPanel.TabIndex = 40
        '
        'NameLabel
        '
        Me.NameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NameLabel.Location = New System.Drawing.Point(3, 46)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(153, 20)
        Me.NameLabel.TabIndex = 42
        Me.NameLabel.Text = "Name"
        Me.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Filter"
        '
        'FilterComboBox
        '
        Me.FilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FilterComboBox.FormattingEnabled = True
        Me.FilterComboBox.Items.AddRange(New Object() {"Alle", "Weichglühen", "Warmauslagern"})
        Me.FilterComboBox.Location = New System.Drawing.Point(0, 17)
        Me.FilterComboBox.Name = "FilterComboBox"
        Me.FilterComboBox.Size = New System.Drawing.Size(170, 21)
        Me.FilterComboBox.TabIndex = 41
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.BenutzerToolStripStatusLabel, Me.ToolStripStatusLabel3, Me.ProgrammeToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 488)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(807, 22)
        Me.StatusStrip.SizingGrip = False
        Me.StatusStrip.TabIndex = 43
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
        Me.BenutzerToolStripStatusLabel.Size = New System.Drawing.Size(620, 17)
        Me.BenutzerToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(73, 17)
        Me.ToolStripStatusLabel3.Text = "Programme:"
        '
        'ProgrammeToolStripStatusLabel
        '
        Me.ProgrammeToolStripStatusLabel.Name = "ProgrammeToolStripStatusLabel"
        Me.ProgrammeToolStripStatusLabel.Size = New System.Drawing.Size(25, 17)
        Me.ProgrammeToolStripStatusLabel.Text = "999"
        '
        'FormProgramm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(807, 510)
        Me.ControlBox = False
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.TreeViewPanel)
        Me.Controls.Add(Me.ProgrammPanel)
        Me.Controls.Add(Me.MenuStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormProgramm"
        Me.Text = "Warmbehandlungs-Programme ( Weichglühen + Warmauslagern )"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ProgrammPanel.ResumeLayout(False)
        Me.ProgrammPanel.PerformLayout()
        Me.ProgrammSplitContainer.Panel1.ResumeLayout(False)
        Me.ProgrammSplitContainer.Panel2.ResumeLayout(False)
        Me.ProgrammSplitContainer.ResumeLayout(False)
        Me.TreeViewPanel.ResumeLayout(False)
        Me.TreeViewPanel.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents EndeMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProgrammMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProgrammNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProgrammEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProgrammDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WarmbehandlungTreeView As System.Windows.Forms.TreeView
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents ProgrammPanel As System.Windows.Forms.Panel
    Friend WithEvents BemerkungLabel As System.Windows.Forms.Label
    Friend WithEvents TreeViewPanel As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FilterComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NameLabel As System.Windows.Forms.Label
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents HistoryMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProgrammCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BenutzerToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ProgrammeToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ProgrammListView As System.Windows.Forms.ListView
    Friend WithEvents ProgrammSplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents CollapseButton As System.Windows.Forms.Button
    Friend WithEvents ChartPanel As System.Windows.Forms.Panel
End Class
