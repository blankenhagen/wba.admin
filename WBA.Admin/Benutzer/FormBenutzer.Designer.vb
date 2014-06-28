<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBenutzer
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
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBenutzer))
        Me.AnlagenDataGridView = New System.Windows.Forms.DataGridView()
        Me.RollenDataGridView = New System.Windows.Forms.DataGridView()
        Me.BenutzerTreeView = New System.Windows.Forms.TreeView()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BenutzerToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BenutzerCountToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.EndeMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BenutzerMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BenutzerNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.BenutzerEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.BenutzerDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AnlageAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnlageRemove = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.RolleAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.RolleRemove = New System.Windows.Forms.ToolStripMenuItem()
        Me.HistoryMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.AnlagenDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RollenDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'AnlagenDataGridView
        '
        Me.AnlagenDataGridView.AllowUserToAddRows = False
        Me.AnlagenDataGridView.AllowUserToDeleteRows = False
        Me.AnlagenDataGridView.AllowUserToResizeColumns = False
        Me.AnlagenDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.Tan
        Me.AnlagenDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle19
        Me.AnlagenDataGridView.BackgroundColor = System.Drawing.SystemColors.Window
        Me.AnlagenDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AnlagenDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.AnlagenDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AnlagenDataGridView.Location = New System.Drawing.Point(256, 30)
        Me.AnlagenDataGridView.MultiSelect = False
        Me.AnlagenDataGridView.Name = "AnlagenDataGridView"
        Me.AnlagenDataGridView.ReadOnly = True
        Me.AnlagenDataGridView.RowHeadersVisible = False
        Me.AnlagenDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.AnlagenDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.AnlagenDataGridView.Size = New System.Drawing.Size(331, 174)
        Me.AnlagenDataGridView.TabIndex = 1
        '
        'RollenDataGridView
        '
        Me.RollenDataGridView.AllowUserToAddRows = False
        Me.RollenDataGridView.AllowUserToDeleteRows = False
        Me.RollenDataGridView.AllowUserToResizeColumns = False
        Me.RollenDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.Tan
        Me.RollenDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle20
        Me.RollenDataGridView.BackgroundColor = System.Drawing.SystemColors.Window
        Me.RollenDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.RollenDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.RollenDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.RollenDataGridView.Location = New System.Drawing.Point(256, 210)
        Me.RollenDataGridView.MultiSelect = False
        Me.RollenDataGridView.Name = "RollenDataGridView"
        Me.RollenDataGridView.ReadOnly = True
        Me.RollenDataGridView.RowHeadersVisible = False
        Me.RollenDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.RollenDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.RollenDataGridView.Size = New System.Drawing.Size(331, 202)
        Me.RollenDataGridView.TabIndex = 2
        '
        'BenutzerTreeView
        '
        Me.BenutzerTreeView.HideSelection = False
        Me.BenutzerTreeView.ImageIndex = 8
        Me.BenutzerTreeView.ImageList = Me.ImageList
        Me.BenutzerTreeView.ItemHeight = 20
        Me.BenutzerTreeView.Location = New System.Drawing.Point(12, 30)
        Me.BenutzerTreeView.Name = "BenutzerTreeView"
        Me.BenutzerTreeView.SelectedImageIndex = 0
        Me.BenutzerTreeView.Size = New System.Drawing.Size(238, 382)
        Me.BenutzerTreeView.TabIndex = 38
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
        '
        'StatusStrip
        '
        Me.StatusStrip.AutoSize = False
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.BenutzerToolStripStatusLabel, Me.ToolStripStatusLabel2, Me.BenutzerCountToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 424)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(599, 22)
        Me.StatusStrip.SizingGrip = False
        Me.StatusStrip.TabIndex = 2
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(78, 17)
        Me.ToolStripStatusLabel1.Text = "Angemeldet: "
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BenutzerToolStripStatusLabel
        '
        Me.BenutzerToolStripStatusLabel.AutoSize = False
        Me.BenutzerToolStripStatusLabel.Name = "BenutzerToolStripStatusLabel"
        Me.BenutzerToolStripStatusLabel.Size = New System.Drawing.Size(430, 17)
        Me.BenutzerToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(56, 17)
        Me.ToolStripStatusLabel2.Text = "Benutzer:"
        '
        'BenutzerCountToolStripStatusLabel
        '
        Me.BenutzerCountToolStripStatusLabel.Name = "BenutzerCountToolStripStatusLabel"
        Me.BenutzerCountToolStripStatusLabel.Size = New System.Drawing.Size(25, 17)
        Me.BenutzerCountToolStripStatusLabel.Text = "999"
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EndeMenuItem, Me.BenutzerMenuItem, Me.HistoryMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(599, 24)
        Me.MenuStrip.TabIndex = 1
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'EndeMenuItem
        '
        Me.EndeMenuItem.Name = "EndeMenuItem"
        Me.EndeMenuItem.Size = New System.Drawing.Size(45, 20)
        Me.EndeMenuItem.Text = "Ende"
        '
        'BenutzerMenuItem
        '
        Me.BenutzerMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BenutzerNew, Me.BenutzerDelete, Me.BenutzerEdit, Me.ToolStripSeparator1, Me.AnlageAdd, Me.AnlageRemove, Me.ToolStripSeparator2, Me.RolleAdd, Me.RolleRemove})
        Me.BenutzerMenuItem.Name = "BenutzerMenuItem"
        Me.BenutzerMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.BenutzerMenuItem.Text = "Benutzer"
        '
        'BenutzerNew
        '
        Me.BenutzerNew.Name = "BenutzerNew"
        Me.BenutzerNew.Size = New System.Drawing.Size(183, 22)
        Me.BenutzerNew.Text = "Neu"
        '
        'BenutzerEdit
        '
        Me.BenutzerEdit.Name = "BenutzerEdit"
        Me.BenutzerEdit.Size = New System.Drawing.Size(183, 22)
        Me.BenutzerEdit.Text = "Bearbeiten"
        '
        'BenutzerDelete
        '
        Me.BenutzerDelete.Name = "BenutzerDelete"
        Me.BenutzerDelete.Size = New System.Drawing.Size(183, 22)
        Me.BenutzerDelete.Text = "Löschen"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(180, 6)
        '
        'AnlageAdd
        '
        Me.AnlageAdd.Name = "AnlageAdd"
        Me.AnlageAdd.Size = New System.Drawing.Size(183, 22)
        Me.AnlageAdd.Text = "Anlage hinzufügen..."
        '
        'AnlageRemove
        '
        Me.AnlageRemove.Name = "AnlageRemove"
        Me.AnlageRemove.Size = New System.Drawing.Size(183, 22)
        Me.AnlageRemove.Text = "Anlage entfernen..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(180, 6)
        '
        'RolleAdd
        '
        Me.RolleAdd.Name = "RolleAdd"
        Me.RolleAdd.Size = New System.Drawing.Size(183, 22)
        Me.RolleAdd.Text = "Rolle hinzufügen..."
        '
        'RolleRemove
        '
        Me.RolleRemove.Name = "RolleRemove"
        Me.RolleRemove.Size = New System.Drawing.Size(183, 22)
        Me.RolleRemove.Text = "Rolle entfernen..."
        '
        'HistoryMenuItem
        '
        Me.HistoryMenuItem.Name = "HistoryMenuItem"
        Me.HistoryMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.HistoryMenuItem.Text = "Historie"
        '
        'FormBenutzer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 446)
        Me.ControlBox = False
        Me.Controls.Add(Me.RollenDataGridView)
        Me.Controls.Add(Me.AnlagenDataGridView)
        Me.Controls.Add(Me.BenutzerTreeView)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormBenutzer"
        Me.Text = "Benutzer verwalten"
        CType(Me.AnlagenDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RollenDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AnlagenDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents RollenDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents EndeMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BenutzerMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BenutzerNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BenutzerDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HistoryMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AnlageAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnlageRemove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RolleAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RolleRemove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BenutzerEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents BenutzerTreeView As System.Windows.Forms.TreeView
    Friend WithEvents BenutzerToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BenutzerCountToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
End Class
