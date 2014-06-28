<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMesswerte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMesswerte))
        Me.AnlageComboBox = New System.Windows.Forms.ComboBox()
        Me.DateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.ZaehlzahlTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NummerLabel = New System.Windows.Forms.Label()
        Me.ExportpfadLabel = New System.Windows.Forms.Label()
        Me.BenutzerToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.EndeMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.EnterButton = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ChargeVerzeichnisButton = New System.Windows.Forms.Button()
        Me.KennzeichenComboBox = New System.Windows.Forms.ComboBox()
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'AnlageComboBox
        '
        Me.AnlageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AnlageComboBox.FormattingEnabled = True
        Me.AnlageComboBox.Location = New System.Drawing.Point(10, 151)
        Me.AnlageComboBox.Name = "AnlageComboBox"
        Me.AnlageComboBox.Size = New System.Drawing.Size(84, 21)
        Me.AnlageComboBox.TabIndex = 0
        '
        'DateTimePicker
        '
        Me.DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker.Location = New System.Drawing.Point(147, 152)
        Me.DateTimePicker.Name = "DateTimePicker"
        Me.DateTimePicker.Size = New System.Drawing.Size(96, 20)
        Me.DateTimePicker.TabIndex = 1
        '
        'ZaehlzahlTextBox
        '
        Me.ZaehlzahlTextBox.Location = New System.Drawing.Point(249, 152)
        Me.ZaehlzahlTextBox.MaxLength = 3
        Me.ZaehlzahlTextBox.Name = "ZaehlzahlTextBox"
        Me.ZaehlzahlTextBox.Size = New System.Drawing.Size(48, 20)
        Me.ZaehlzahlTextBox.TabIndex = 2
        Me.ZaehlzahlTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(8, 135)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Anlage"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.Location = New System.Drawing.Point(144, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Datum"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label3.Location = New System.Drawing.Point(248, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Zählzahl"
        '
        'NummerLabel
        '
        Me.NummerLabel.BackColor = System.Drawing.SystemColors.Window
        Me.NummerLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NummerLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NummerLabel.Location = New System.Drawing.Point(10, 105)
        Me.NummerLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.NummerLabel.Name = "NummerLabel"
        Me.NummerLabel.Size = New System.Drawing.Size(287, 20)
        Me.NummerLabel.TabIndex = 6
        Me.NummerLabel.Text = "HWO206 -99999999999"
        Me.NummerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ExportpfadLabel
        '
        Me.ExportpfadLabel.BackColor = System.Drawing.SystemColors.Window
        Me.ExportpfadLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ExportpfadLabel.Location = New System.Drawing.Point(10, 59)
        Me.ExportpfadLabel.Name = "ExportpfadLabel"
        Me.ExportpfadLabel.Size = New System.Drawing.Size(287, 20)
        Me.ExportpfadLabel.TabIndex = 87
        Me.ExportpfadLabel.Text = "Pfad2"
        Me.ExportpfadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BenutzerToolStripStatusLabel
        '
        Me.BenutzerToolStripStatusLabel.AutoSize = False
        Me.BenutzerToolStripStatusLabel.Name = "BenutzerToolStripStatusLabel"
        Me.BenutzerToolStripStatusLabel.Size = New System.Drawing.Size(230, 17)
        Me.BenutzerToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatusStrip
        '
        Me.StatusStrip.AutoSize = False
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.BenutzerToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 183)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(338, 22)
        Me.StatusStrip.SizingGrip = False
        Me.StatusStrip.TabIndex = 91
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(78, 17)
        Me.ToolStripStatusLabel1.Text = "Angemeldet: "
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EndeMenuItem, Me.ExportMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(338, 24)
        Me.MenuStrip.TabIndex = 92
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'EndeMenuItem
        '
        Me.EndeMenuItem.Name = "EndeMenuItem"
        Me.EndeMenuItem.Size = New System.Drawing.Size(45, 20)
        Me.EndeMenuItem.Text = "Ende"
        '
        'ExportMenuItem
        '
        Me.ExportMenuItem.Name = "ExportMenuItem"
        Me.ExportMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.ExportMenuItem.Text = "Export"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label7.Location = New System.Drawing.Point(8, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 13)
        Me.Label7.TabIndex = 93
        Me.Label7.Text = "Chargennummer"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label8.Location = New System.Drawing.Point(7, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 94
        Me.Label8.Text = "Exportpfad"
        '
        'EnterButton
        '
        Me.EnterButton.ImageIndex = 1
        Me.EnterButton.ImageList = Me.ImageList1
        Me.EnterButton.Location = New System.Drawing.Point(303, 149)
        Me.EnterButton.Name = "EnterButton"
        Me.EnterButton.Size = New System.Drawing.Size(24, 24)
        Me.EnterButton.TabIndex = 95
        Me.EnterButton.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Magenta
        Me.ImageList1.Images.SetKeyName(0, "OpenFolder.bmp")
        Me.ImageList1.Images.SetKeyName(1, "OK.bmp")
        '
        'ChargeVerzeichnisButton
        '
        Me.ChargeVerzeichnisButton.ImageIndex = 0
        Me.ChargeVerzeichnisButton.ImageList = Me.ImageList1
        Me.ChargeVerzeichnisButton.Location = New System.Drawing.Point(303, 57)
        Me.ChargeVerzeichnisButton.Name = "ChargeVerzeichnisButton"
        Me.ChargeVerzeichnisButton.Size = New System.Drawing.Size(24, 24)
        Me.ChargeVerzeichnisButton.TabIndex = 88
        Me.ChargeVerzeichnisButton.UseVisualStyleBackColor = True
        '
        'KennzeichenComboBox
        '
        Me.KennzeichenComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.KennzeichenComboBox.FormattingEnabled = True
        Me.KennzeichenComboBox.Location = New System.Drawing.Point(100, 151)
        Me.KennzeichenComboBox.Name = "KennzeichenComboBox"
        Me.KennzeichenComboBox.Size = New System.Drawing.Size(41, 21)
        Me.KennzeichenComboBox.TabIndex = 96
        '
        'FormMesswerte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(338, 205)
        Me.ControlBox = False
        Me.Controls.Add(Me.KennzeichenComboBox)
        Me.Controls.Add(Me.EnterButton)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.ChargeVerzeichnisButton)
        Me.Controls.Add(Me.ExportpfadLabel)
        Me.Controls.Add(Me.NummerLabel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ZaehlzahlTextBox)
        Me.Controls.Add(Me.DateTimePicker)
        Me.Controls.Add(Me.AnlageComboBox)
        Me.Name = "FormMesswerte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Messwerte exportieren"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AnlageComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents DateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents ZaehlzahlTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents NummerLabel As System.Windows.Forms.Label
    Friend WithEvents ChargeVerzeichnisButton As System.Windows.Forms.Button
    Friend WithEvents ExportpfadLabel As System.Windows.Forms.Label
    Friend WithEvents BenutzerToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents EndeMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents EnterButton As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents KennzeichenComboBox As System.Windows.Forms.ComboBox
End Class
