<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.ButtonPanel = New System.Windows.Forms.Panel()
        Me.AuftragButton = New System.Windows.Forms.Button()
        Me.MesswerteButton = New System.Windows.Forms.Button()
        Me.EndeButton = New System.Windows.Forms.Button()
        Me.HilfeButton = New System.Windows.Forms.Button()
        Me.BenutzerButton = New System.Windows.Forms.Button()
        Me.BauteilButton = New System.Windows.Forms.Button()
        Me.ParameterButton = New System.Windows.Forms.Button()
        Me.ParameterMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ProgrammMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoesungsgluehenMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HintergrundPictureBox = New System.Windows.Forms.PictureBox()
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.ConnectionPanel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ConnectionProgressBar = New System.Windows.Forms.ProgressBar()
        Me.ConnectionTimer = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ConnectionStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.ButtonPanel.SuspendLayout()
        Me.ParameterMenu.SuspendLayout()
        CType(Me.HintergrundPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ConnectionPanel.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonPanel
        '
        Me.ButtonPanel.BackColor = System.Drawing.Color.Transparent
        Me.ButtonPanel.Controls.Add(Me.AuftragButton)
        Me.ButtonPanel.Controls.Add(Me.MesswerteButton)
        Me.ButtonPanel.Controls.Add(Me.EndeButton)
        Me.ButtonPanel.Controls.Add(Me.HilfeButton)
        Me.ButtonPanel.Controls.Add(Me.BenutzerButton)
        Me.ButtonPanel.Controls.Add(Me.BauteilButton)
        Me.ButtonPanel.Controls.Add(Me.ParameterButton)
        Me.ButtonPanel.Location = New System.Drawing.Point(0, 389)
        Me.ButtonPanel.Name = "ButtonPanel"
        Me.ButtonPanel.Size = New System.Drawing.Size(567, 31)
        Me.ButtonPanel.TabIndex = 6
        '
        'AuftragButton
        '
        Me.HelpProvider1.SetHelpKeyword(Me.AuftragButton, "")
        Me.HelpProvider1.SetHelpNavigator(Me.AuftragButton, System.Windows.Forms.HelpNavigator.Topic)
        Me.AuftragButton.Location = New System.Drawing.Point(165, 3)
        Me.AuftragButton.Name = "AuftragButton"
        Me.HelpProvider1.SetShowHelp(Me.AuftragButton, True)
        Me.AuftragButton.Size = New System.Drawing.Size(75, 23)
        Me.AuftragButton.TabIndex = 13
        Me.AuftragButton.Text = "Auftrag"
        Me.AuftragButton.UseVisualStyleBackColor = True
        '
        'MesswerteButton
        '
        Me.HelpProvider1.SetHelpKeyword(Me.MesswerteButton, "")
        Me.HelpProvider1.SetHelpNavigator(Me.MesswerteButton, System.Windows.Forms.HelpNavigator.Topic)
        Me.MesswerteButton.Location = New System.Drawing.Point(84, 3)
        Me.MesswerteButton.Name = "MesswerteButton"
        Me.HelpProvider1.SetShowHelp(Me.MesswerteButton, True)
        Me.MesswerteButton.Size = New System.Drawing.Size(75, 23)
        Me.MesswerteButton.TabIndex = 12
        Me.MesswerteButton.Text = "Messwerte"
        Me.MesswerteButton.UseVisualStyleBackColor = True
        '
        'EndeButton
        '
        Me.HelpProvider1.SetHelpKeyword(Me.EndeButton, "Programmbearbeitung_beenden.htm")
        Me.HelpProvider1.SetHelpNavigator(Me.EndeButton, System.Windows.Forms.HelpNavigator.Topic)
        Me.EndeButton.Location = New System.Drawing.Point(3, 3)
        Me.EndeButton.Name = "EndeButton"
        Me.HelpProvider1.SetShowHelp(Me.EndeButton, True)
        Me.EndeButton.Size = New System.Drawing.Size(75, 23)
        Me.EndeButton.TabIndex = 11
        Me.EndeButton.Text = "Ende"
        Me.EndeButton.UseVisualStyleBackColor = True
        '
        'HilfeButton
        '
        Me.HelpProvider1.SetHelpKeyword(Me.HilfeButton, "Wie_bekomme_ich_Hilfe.htm")
        Me.HelpProvider1.SetHelpNavigator(Me.HilfeButton, System.Windows.Forms.HelpNavigator.Topic)
        Me.HilfeButton.Location = New System.Drawing.Point(489, 3)
        Me.HilfeButton.Name = "HilfeButton"
        Me.HelpProvider1.SetShowHelp(Me.HilfeButton, True)
        Me.HilfeButton.Size = New System.Drawing.Size(75, 23)
        Me.HilfeButton.TabIndex = 9
        Me.HilfeButton.Text = "Hilfe"
        Me.HilfeButton.UseVisualStyleBackColor = True
        '
        'BenutzerButton
        '
        Me.HelpProvider1.SetHelpKeyword(Me.BenutzerButton, "Benutzer.htm")
        Me.HelpProvider1.SetHelpNavigator(Me.BenutzerButton, System.Windows.Forms.HelpNavigator.Topic)
        Me.HelpProvider1.SetHelpString(Me.BenutzerButton, "")
        Me.BenutzerButton.Location = New System.Drawing.Point(408, 3)
        Me.BenutzerButton.Name = "BenutzerButton"
        Me.HelpProvider1.SetShowHelp(Me.BenutzerButton, True)
        Me.BenutzerButton.Size = New System.Drawing.Size(75, 23)
        Me.BenutzerButton.TabIndex = 8
        Me.BenutzerButton.Text = "Benutzer"
        Me.BenutzerButton.UseVisualStyleBackColor = True
        '
        'BauteilButton
        '
        Me.HelpProvider1.SetHelpKeyword(Me.BauteilButton, "Bauteil.htm")
        Me.HelpProvider1.SetHelpNavigator(Me.BauteilButton, System.Windows.Forms.HelpNavigator.Topic)
        Me.BauteilButton.Location = New System.Drawing.Point(327, 3)
        Me.BauteilButton.Name = "BauteilButton"
        Me.HelpProvider1.SetShowHelp(Me.BauteilButton, True)
        Me.BauteilButton.Size = New System.Drawing.Size(75, 23)
        Me.BauteilButton.TabIndex = 7
        Me.BauteilButton.Text = "Bauteil"
        Me.BauteilButton.UseVisualStyleBackColor = True
        '
        'ParameterButton
        '
        Me.HelpProvider1.SetHelpKeyword(Me.ParameterButton, "Parameter.htm")
        Me.HelpProvider1.SetHelpNavigator(Me.ParameterButton, System.Windows.Forms.HelpNavigator.Topic)
        Me.ParameterButton.Location = New System.Drawing.Point(246, 3)
        Me.ParameterButton.Name = "ParameterButton"
        Me.HelpProvider1.SetShowHelp(Me.ParameterButton, True)
        Me.ParameterButton.Size = New System.Drawing.Size(75, 23)
        Me.ParameterButton.TabIndex = 6
        Me.ParameterButton.Text = "Parameter"
        Me.ParameterButton.UseVisualStyleBackColor = True
        '
        'ParameterMenu
        '
        Me.ParameterMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgrammMenuItem, Me.LoesungsgluehenMenuItem})
        Me.ParameterMenu.Name = "ParameterMenu"
        Me.ParameterMenu.Size = New System.Drawing.Size(156, 48)
        '
        'ProgrammMenuItem
        '
        Me.ProgrammMenuItem.Name = "ProgrammMenuItem"
        Me.ProgrammMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.ProgrammMenuItem.Text = "Programm"
        '
        'LoesungsgluehenMenuItem
        '
        Me.LoesungsgluehenMenuItem.Name = "LoesungsgluehenMenuItem"
        Me.LoesungsgluehenMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.LoesungsgluehenMenuItem.Text = "Lösungsglühen"
        '
        'HintergrundPictureBox
        '
        Me.HintergrundPictureBox.Image = Global.WBA.Admin.My.Resources.Resources.wbadmin
        Me.HintergrundPictureBox.Location = New System.Drawing.Point(0, 53)
        Me.HintergrundPictureBox.Name = "HintergrundPictureBox"
        Me.HintergrundPictureBox.Size = New System.Drawing.Size(567, 333)
        Me.HintergrundPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.HintergrundPictureBox.TabIndex = 7
        Me.HintergrundPictureBox.TabStop = False
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), System.Drawing.Image)
        Me.LogoPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(568, 57)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LogoPictureBox.TabIndex = 8
        Me.LogoPictureBox.TabStop = False
        '
        'ConnectionPanel
        '
        Me.ConnectionPanel.Controls.Add(Me.Label1)
        Me.ConnectionPanel.Controls.Add(Me.ConnectionProgressBar)
        Me.ConnectionPanel.Location = New System.Drawing.Point(165, 162)
        Me.ConnectionPanel.Name = "ConnectionPanel"
        Me.ConnectionPanel.Size = New System.Drawing.Size(237, 60)
        Me.ConnectionPanel.TabIndex = 9
        Me.ConnectionPanel.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(201, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Verbindung zur Datenbank wird überprüft"
        '
        'ConnectionProgressBar
        '
        Me.ConnectionProgressBar.Location = New System.Drawing.Point(21, 27)
        Me.ConnectionProgressBar.Maximum = 30
        Me.ConnectionProgressBar.Name = "ConnectionProgressBar"
        Me.ConnectionProgressBar.Size = New System.Drawing.Size(198, 23)
        Me.ConnectionProgressBar.TabIndex = 0
        '
        'ConnectionTimer
        '
        Me.ConnectionTimer.Interval = 1000
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConnectionStatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 423)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(568, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 10
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ConnectionStatusLabel
        '
        Me.ConnectionStatusLabel.Name = "ConnectionStatusLabel"
        Me.ConnectionStatusLabel.Size = New System.Drawing.Size(129, 17)
        Me.ConnectionStatusLabel.Text = "ConnectionStatusLabel"
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "C:\Users\Blankenhagen\Documents\Visual Studio 2010\Projects\WBA.Admin\WBA.Admin\b" & _
    "in\Debug\WBA.Admin.chm"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(568, 445)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ConnectionPanel)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.Controls.Add(Me.ButtonPanel)
        Me.Controls.Add(Me.HintergrundPictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.TableOfContents)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMain"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.Text = "Datenverwaltung für Warmbehandlungs-Anlagen"
        Me.ButtonPanel.ResumeLayout(False)
        Me.ParameterMenu.ResumeLayout(False)
        CType(Me.HintergrundPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ConnectionPanel.ResumeLayout(False)
        Me.ConnectionPanel.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonPanel As System.Windows.Forms.Panel
    Friend WithEvents BenutzerButton As System.Windows.Forms.Button
    Friend WithEvents BauteilButton As System.Windows.Forms.Button
    Friend WithEvents ParameterButton As System.Windows.Forms.Button
    Friend WithEvents HintergrundPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents HilfeButton As System.Windows.Forms.Button
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ConnectionPanel As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ConnectionProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents ConnectionTimer As System.Windows.Forms.Timer
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ConnectionStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents EndeButton As System.Windows.Forms.Button
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents ParameterMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ProgrammMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoesungsgluehenMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MesswerteButton As System.Windows.Forms.Button
    Friend WithEvents AuftragButton As System.Windows.Forms.Button

End Class
