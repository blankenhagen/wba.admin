<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormParameter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormParameter))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.DialogMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DialogSchliessen = New System.Windows.Forms.ToolStripMenuItem()
        Me.BearbeitenMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BearbeitenNeuerParameter = New System.Windows.Forms.ToolStripMenuItem()
        Me.BearbeitenAendernParameter = New System.Windows.Forms.ToolStripMenuItem()
        Me.BearbeitenLoeschenParameter = New System.Windows.Forms.ToolStripMenuItem()
        Me.BearbeitenKopierenParameter = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BearbeitenParameterDetails = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnzeigenMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnzeigenHistorie = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BenutzerToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ParameterToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlTreeView = New System.Windows.Forms.Panel()
        Me.lblName = New System.Windows.Forms.Label()
        Me.trvWarmbehandlung = New System.Windows.Forms.TreeView()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlProgramm = New System.Windows.Forms.Panel()
        Me.AufheizzeitLabel = New System.Windows.Forms.Label()
        Me.AbschreckzeitLabel = New System.Windows.Forms.Label()
        Me.GluehzeitLabel = New System.Windows.Forms.Label()
        Me.SollwertLabel = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblBemerkung = New System.Windows.Forms.Label()
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.pnlTreeView.SuspendLayout()
        Me.pnlProgramm.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DialogMenuItem, Me.BearbeitenMenuItem, Me.AnzeigenMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(502, 24)
        Me.MenuStrip.TabIndex = 2
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'DialogMenuItem
        '
        Me.DialogMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DialogSchliessen})
        Me.DialogMenuItem.Name = "DialogMenuItem"
        Me.DialogMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.DialogMenuItem.Text = "Dialog"
        '
        'DialogSchliessen
        '
        Me.DialogSchliessen.Name = "DialogSchliessen"
        Me.DialogSchliessen.Size = New System.Drawing.Size(128, 22)
        Me.DialogSchliessen.Text = "Schliessen"
        '
        'BearbeitenMenuItem
        '
        Me.BearbeitenMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BearbeitenNeuerParameter, Me.BearbeitenAendernParameter, Me.BearbeitenLoeschenParameter, Me.BearbeitenKopierenParameter, Me.ToolStripSeparator1, Me.BearbeitenParameterDetails})
        Me.BearbeitenMenuItem.Name = "BearbeitenMenuItem"
        Me.BearbeitenMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.BearbeitenMenuItem.Text = "Bearbeiten"
        '
        'BearbeitenNeuerParameter
        '
        Me.BearbeitenNeuerParameter.Name = "BearbeitenNeuerParameter"
        Me.BearbeitenNeuerParameter.Size = New System.Drawing.Size(168, 22)
        Me.BearbeitenNeuerParameter.Text = "Neu"
        '
        'BearbeitenAendernParameter
        '
        Me.BearbeitenAendernParameter.Name = "BearbeitenAendernParameter"
        Me.BearbeitenAendernParameter.Size = New System.Drawing.Size(168, 22)
        Me.BearbeitenAendernParameter.Text = "Ändern"
        '
        'BearbeitenLoeschenParameter
        '
        Me.BearbeitenLoeschenParameter.Name = "BearbeitenLoeschenParameter"
        Me.BearbeitenLoeschenParameter.Size = New System.Drawing.Size(168, 22)
        Me.BearbeitenLoeschenParameter.Text = "Löschen"
        '
        'BearbeitenKopierenParameter
        '
        Me.BearbeitenKopierenParameter.Name = "BearbeitenKopierenParameter"
        Me.BearbeitenKopierenParameter.Size = New System.Drawing.Size(168, 22)
        Me.BearbeitenKopierenParameter.Text = "Kopieren"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(165, 6)
        '
        'BearbeitenParameterDetails
        '
        Me.BearbeitenParameterDetails.Name = "BearbeitenParameterDetails"
        Me.BearbeitenParameterDetails.Size = New System.Drawing.Size(168, 22)
        Me.BearbeitenParameterDetails.Text = "Details bearbeiten"
        '
        'AnzeigenMenuItem
        '
        Me.AnzeigenMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnzeigenHistorie})
        Me.AnzeigenMenuItem.Name = "AnzeigenMenuItem"
        Me.AnzeigenMenuItem.Size = New System.Drawing.Size(68, 20)
        Me.AnzeigenMenuItem.Text = "Anzeigen"
        '
        'AnzeigenHistorie
        '
        Me.AnzeigenHistorie.Name = "AnzeigenHistorie"
        Me.AnzeigenHistorie.Size = New System.Drawing.Size(115, 22)
        Me.AnzeigenHistorie.Text = "Historie"
        '
        'StatusStrip
        '
        Me.StatusStrip.AutoSize = False
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.BenutzerToolStripStatusLabel, Me.ToolStripStatusLabel2, Me.ParameterToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 346)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(502, 22)
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
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(64, 17)
        Me.ToolStripStatusLabel2.Text = "Parameter:"
        '
        'ParameterToolStripStatusLabel
        '
        Me.ParameterToolStripStatusLabel.Name = "ParameterToolStripStatusLabel"
        Me.ParameterToolStripStatusLabel.Size = New System.Drawing.Size(25, 17)
        Me.ParameterToolStripStatusLabel.Text = "999"
        Me.ParameterToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlTreeView
        '
        Me.pnlTreeView.Controls.Add(Me.lblName)
        Me.pnlTreeView.Controls.Add(Me.trvWarmbehandlung)
        Me.pnlTreeView.Location = New System.Drawing.Point(12, 27)
        Me.pnlTreeView.Name = "pnlTreeView"
        Me.pnlTreeView.Size = New System.Drawing.Size(162, 316)
        Me.pnlTreeView.TabIndex = 45
        '
        'lblName
        '
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(1, 1)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(156, 20)
        Me.lblName.TabIndex = 42
        Me.lblName.Text = "Name"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'trvWarmbehandlung
        '
        Me.trvWarmbehandlung.HideSelection = False
        Me.trvWarmbehandlung.ImageIndex = 6
        Me.trvWarmbehandlung.ImageList = Me.ImageList
        Me.trvWarmbehandlung.ItemHeight = 20
        Me.trvWarmbehandlung.Location = New System.Drawing.Point(1, 24)
        Me.trvWarmbehandlung.Name = "trvWarmbehandlung"
        Me.trvWarmbehandlung.SelectedImageIndex = 6
        Me.trvWarmbehandlung.Size = New System.Drawing.Size(158, 284)
        Me.trvWarmbehandlung.TabIndex = 37
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
        '
        'pnlProgramm
        '
        Me.pnlProgramm.Controls.Add(Me.AufheizzeitLabel)
        Me.pnlProgramm.Controls.Add(Me.AbschreckzeitLabel)
        Me.pnlProgramm.Controls.Add(Me.GluehzeitLabel)
        Me.pnlProgramm.Controls.Add(Me.SollwertLabel)
        Me.pnlProgramm.Controls.Add(Me.Label5)
        Me.pnlProgramm.Controls.Add(Me.Label4)
        Me.pnlProgramm.Controls.Add(Me.Label3)
        Me.pnlProgramm.Controls.Add(Me.Label1)
        Me.pnlProgramm.Controls.Add(Me.Label2)
        Me.pnlProgramm.Controls.Add(Me.lblBemerkung)
        Me.pnlProgramm.Location = New System.Drawing.Point(177, 28)
        Me.pnlProgramm.Name = "pnlProgramm"
        Me.pnlProgramm.Size = New System.Drawing.Size(320, 315)
        Me.pnlProgramm.TabIndex = 46
        '
        'AufheizzeitLabel
        '
        Me.AufheizzeitLabel.BackColor = System.Drawing.SystemColors.Window
        Me.AufheizzeitLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AufheizzeitLabel.Location = New System.Drawing.Point(5, 285)
        Me.AufheizzeitLabel.Name = "AufheizzeitLabel"
        Me.AufheizzeitLabel.Size = New System.Drawing.Size(107, 20)
        Me.AufheizzeitLabel.TabIndex = 57
        Me.AufheizzeitLabel.Tag = "4"
        Me.AufheizzeitLabel.Text = "Label9"
        Me.AufheizzeitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AbschreckzeitLabel
        '
        Me.AbschreckzeitLabel.BackColor = System.Drawing.SystemColors.Window
        Me.AbschreckzeitLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AbschreckzeitLabel.Location = New System.Drawing.Point(5, 237)
        Me.AbschreckzeitLabel.Name = "AbschreckzeitLabel"
        Me.AbschreckzeitLabel.Size = New System.Drawing.Size(107, 20)
        Me.AbschreckzeitLabel.TabIndex = 56
        Me.AbschreckzeitLabel.Tag = "3"
        Me.AbschreckzeitLabel.Text = "Label8"
        Me.AbschreckzeitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GluehzeitLabel
        '
        Me.GluehzeitLabel.BackColor = System.Drawing.SystemColors.Window
        Me.GluehzeitLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GluehzeitLabel.Location = New System.Drawing.Point(5, 183)
        Me.GluehzeitLabel.Name = "GluehzeitLabel"
        Me.GluehzeitLabel.Size = New System.Drawing.Size(107, 20)
        Me.GluehzeitLabel.TabIndex = 55
        Me.GluehzeitLabel.Tag = "2"
        Me.GluehzeitLabel.Text = "Label7"
        Me.GluehzeitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SollwertLabel
        '
        Me.SollwertLabel.BackColor = System.Drawing.SystemColors.Window
        Me.SollwertLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SollwertLabel.Location = New System.Drawing.Point(5, 133)
        Me.SollwertLabel.Name = "SollwertLabel"
        Me.SollwertLabel.Size = New System.Drawing.Size(107, 20)
        Me.SollwertLabel.TabIndex = 54
        Me.SollwertLabel.Tag = "1"
        Me.SollwertLabel.Text = "Label6"
        Me.SollwertLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 270)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 13)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "Aufheizzeit [ hh:mm ]"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 221)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 13)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Abschreckzeit [ ss,s ]"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "Glühzeit [ mm:ss ]"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Sollwert [ °C ]"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Bemerkung"
        '
        'lblBemerkung
        '
        Me.lblBemerkung.AutoEllipsis = True
        Me.lblBemerkung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBemerkung.Location = New System.Drawing.Point(3, 23)
        Me.lblBemerkung.Name = "lblBemerkung"
        Me.lblBemerkung.Size = New System.Drawing.Size(313, 87)
        Me.lblBemerkung.TabIndex = 39
        Me.lblBemerkung.Text = "Bemerkung"
        '
        'FormParameter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(502, 368)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlProgramm)
        Me.Controls.Add(Me.pnlTreeView)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormParameter"
        Me.Text = "Warmbehandlungs-Parameter ( Lösungsglühen )"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.pnlTreeView.ResumeLayout(False)
        Me.pnlProgramm.ResumeLayout(False)
        Me.pnlProgramm.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents DialogMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DialogSchliessen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BearbeitenMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BearbeitenNeuerParameter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BearbeitenAendernParameter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BearbeitenLoeschenParameter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BearbeitenParameterDetails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlTreeView As System.Windows.Forms.Panel
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents trvWarmbehandlung As System.Windows.Forms.TreeView
    Friend WithEvents pnlProgramm As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblBemerkung As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AnzeigenMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnzeigenHistorie As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BearbeitenKopierenParameter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AufheizzeitLabel As System.Windows.Forms.Label
    Friend WithEvents AbschreckzeitLabel As System.Windows.Forms.Label
    Friend WithEvents GluehzeitLabel As System.Windows.Forms.Label
    Friend WithEvents SollwertLabel As System.Windows.Forms.Label
    Friend WithEvents BenutzerToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ParameterToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
End Class
