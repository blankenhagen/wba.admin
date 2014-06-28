<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAuftragBearbeiten
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
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RUECK_TextBox = New System.Windows.Forms.TextBox()
        Me.WERKS_Label = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.AUFNR_TextBox = New System.Windows.Forms.TextBox()
        Me.BENENNUNG_TextBox = New System.Windows.Forms.TextBox()
        Me.BI_TextBox = New System.Windows.Forms.TextBox()
        Me.HTZ_TextBox = New System.Windows.Forms.TextBox()
        Me.IDNR_TextBox = New System.Windows.Forms.TextBox()
        Me.AUFLAGE_TextBox = New System.Windows.Forms.TextBox()
        Me.ERGAENZUNG_TextBox = New System.Windows.Forms.TextBox()
        Me.PL_TextBox = New System.Windows.Forms.TextBox()
        Me.GAMNG_TextBox = New System.Windows.Forms.TextBox()
        Me.PRUEFLOS_TextBox = New System.Windows.Forms.TextBox()
        Me.VORNR_TextBox = New System.Windows.Forms.TextBox()
        Me.ST_TextBox = New System.Windows.Forms.TextBox()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Cancel_Button
        '
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.ImageIndex = 6
        Me.Cancel_Button.Location = New System.Drawing.Point(115, 397)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(90, 23)
        Me.Cancel_Button.TabIndex = 14
        Me.Cancel_Button.Text = "Abbrechen"
        Me.Cancel_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'OK_Button
        '
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK_Button.ImageIndex = 7
        Me.OK_Button.Location = New System.Drawing.Point(12, 397)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(90, 23)
        Me.OK_Button.TabIndex = 13
        Me.OK_Button.Text = "OK"
        Me.OK_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(12, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Rückmeldenummer (RUECK, 10)"
        '
        'RUECK_TextBox
        '
        Me.RUECK_TextBox.Location = New System.Drawing.Point(177, 35)
        Me.RUECK_TextBox.MaxLength = 10
        Me.RUECK_TextBox.Name = "RUECK_TextBox"
        Me.RUECK_TextBox.Size = New System.Drawing.Size(90, 20)
        Me.RUECK_TextBox.TabIndex = 0
        Me.RUECK_TextBox.Tag = "0"
        Me.RUECK_TextBox.Text = "9999999999"
        '
        'WERKS_Label
        '
        Me.WERKS_Label.Location = New System.Drawing.Point(177, 10)
        Me.WERKS_Label.Name = "WERKS_Label"
        Me.WERKS_Label.Size = New System.Drawing.Size(38, 20)
        Me.WERKS_Label.TabIndex = 50
        Me.WERKS_Label.Text = "9999"
        Me.WERKS_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.Location = New System.Drawing.Point(12, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(141, 13)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Werkskennung (WERKS, 4)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label3.Location = New System.Drawing.Point(12, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(147, 13)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Auftragsnummer (AUFNR, 12)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label4.Location = New System.Drawing.Point(12, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(158, 13)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "Benennung (BENENNUNG, 21)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label5.Location = New System.Drawing.Point(12, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 13)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "Bauteilindex (BI, 2)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label6.Location = New System.Drawing.Point(12, 142)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "HTZ (HTZ, 18)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label7.Location = New System.Drawing.Point(12, 168)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 13)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "Identnummer (IDNR, 8)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label8.Location = New System.Drawing.Point(12, 194)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(113, 13)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "Auflage (AUFLAGE, 3)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label9.Location = New System.Drawing.Point(12, 220)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(155, 13)
        Me.Label9.TabIndex = 58
        Me.Label9.Text = "Ergänzung (ERGAENZUNG, 2)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label10.Location = New System.Drawing.Point(12, 248)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 13)
        Me.Label10.TabIndex = 59
        Me.Label10.Text = "Planvariante (PL, 2)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label11.Location = New System.Drawing.Point(12, 274)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(152, 13)
        Me.Label11.TabIndex = 60
        Me.Label11.Text = "Geplante Anzahl (GAMNG, 11)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label12.Location = New System.Drawing.Point(12, 300)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(160, 13)
        Me.Label12.TabIndex = 61
        Me.Label12.Text = "Prüflosnummer (PRUEFLOS, 12)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label13.Location = New System.Drawing.Point(12, 326)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(145, 13)
        Me.Label13.TabIndex = 62
        Me.Label13.Text = "Auftragsvorgang (VORNR, 4)"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label14.Location = New System.Drawing.Point(12, 352)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 13)
        Me.Label14.TabIndex = 63
        Me.Label14.Text = "Status (ST, 2)"
        '
        'AUFNR_TextBox
        '
        Me.AUFNR_TextBox.Location = New System.Drawing.Point(177, 61)
        Me.AUFNR_TextBox.MaxLength = 12
        Me.AUFNR_TextBox.Name = "AUFNR_TextBox"
        Me.AUFNR_TextBox.Size = New System.Drawing.Size(90, 20)
        Me.AUFNR_TextBox.TabIndex = 1
        Me.AUFNR_TextBox.Tag = "1"
        Me.AUFNR_TextBox.Text = "999999999999"
        '
        'BENENNUNG_TextBox
        '
        Me.BENENNUNG_TextBox.Location = New System.Drawing.Point(177, 87)
        Me.BENENNUNG_TextBox.MaxLength = 21
        Me.BENENNUNG_TextBox.Name = "BENENNUNG_TextBox"
        Me.BENENNUNG_TextBox.Size = New System.Drawing.Size(177, 20)
        Me.BENENNUNG_TextBox.TabIndex = 2
        Me.BENENNUNG_TextBox.Tag = "2"
        Me.BENENNUNG_TextBox.Text = "AAAAAAAAAAAAAAAAAAAAA"
        '
        'BI_TextBox
        '
        Me.BI_TextBox.Location = New System.Drawing.Point(177, 113)
        Me.BI_TextBox.MaxLength = 2
        Me.BI_TextBox.Name = "BI_TextBox"
        Me.BI_TextBox.Size = New System.Drawing.Size(38, 20)
        Me.BI_TextBox.TabIndex = 3
        Me.BI_TextBox.Tag = "3"
        Me.BI_TextBox.Text = "AA"
        '
        'HTZ_TextBox
        '
        Me.HTZ_TextBox.Location = New System.Drawing.Point(177, 139)
        Me.HTZ_TextBox.MaxLength = 18
        Me.HTZ_TextBox.Name = "HTZ_TextBox"
        Me.HTZ_TextBox.Size = New System.Drawing.Size(177, 20)
        Me.HTZ_TextBox.TabIndex = 4
        Me.HTZ_TextBox.Tag = "4"
        Me.HTZ_TextBox.Text = "AAAAAAAAAAAAAAAAAA"
        '
        'IDNR_TextBox
        '
        Me.IDNR_TextBox.Location = New System.Drawing.Point(177, 165)
        Me.IDNR_TextBox.MaxLength = 8
        Me.IDNR_TextBox.Name = "IDNR_TextBox"
        Me.IDNR_TextBox.Size = New System.Drawing.Size(90, 20)
        Me.IDNR_TextBox.TabIndex = 5
        Me.IDNR_TextBox.Tag = "5"
        Me.IDNR_TextBox.Text = "99999999"
        '
        'AUFLAGE_TextBox
        '
        Me.AUFLAGE_TextBox.Location = New System.Drawing.Point(177, 191)
        Me.AUFLAGE_TextBox.MaxLength = 3
        Me.AUFLAGE_TextBox.Name = "AUFLAGE_TextBox"
        Me.AUFLAGE_TextBox.Size = New System.Drawing.Size(38, 20)
        Me.AUFLAGE_TextBox.TabIndex = 6
        Me.AUFLAGE_TextBox.Tag = "6"
        Me.AUFLAGE_TextBox.Text = "999"
        '
        'ERGAENZUNG_TextBox
        '
        Me.ERGAENZUNG_TextBox.Location = New System.Drawing.Point(177, 217)
        Me.ERGAENZUNG_TextBox.MaxLength = 2
        Me.ERGAENZUNG_TextBox.Name = "ERGAENZUNG_TextBox"
        Me.ERGAENZUNG_TextBox.Size = New System.Drawing.Size(38, 20)
        Me.ERGAENZUNG_TextBox.TabIndex = 7
        Me.ERGAENZUNG_TextBox.Tag = "7"
        Me.ERGAENZUNG_TextBox.Text = "99"
        '
        'PL_TextBox
        '
        Me.PL_TextBox.Location = New System.Drawing.Point(177, 245)
        Me.PL_TextBox.MaxLength = 2
        Me.PL_TextBox.Name = "PL_TextBox"
        Me.PL_TextBox.Size = New System.Drawing.Size(38, 20)
        Me.PL_TextBox.TabIndex = 8
        Me.PL_TextBox.Tag = "8"
        Me.PL_TextBox.Text = "99"
        '
        'GAMNG_TextBox
        '
        Me.GAMNG_TextBox.Location = New System.Drawing.Point(177, 271)
        Me.GAMNG_TextBox.MaxLength = 11
        Me.GAMNG_TextBox.Name = "GAMNG_TextBox"
        Me.GAMNG_TextBox.Size = New System.Drawing.Size(90, 20)
        Me.GAMNG_TextBox.TabIndex = 9
        Me.GAMNG_TextBox.Tag = "9"
        Me.GAMNG_TextBox.Text = "99999999999"
        '
        'PRUEFLOS_TextBox
        '
        Me.PRUEFLOS_TextBox.Location = New System.Drawing.Point(177, 297)
        Me.PRUEFLOS_TextBox.MaxLength = 12
        Me.PRUEFLOS_TextBox.Name = "PRUEFLOS_TextBox"
        Me.PRUEFLOS_TextBox.Size = New System.Drawing.Size(90, 20)
        Me.PRUEFLOS_TextBox.TabIndex = 10
        Me.PRUEFLOS_TextBox.Tag = "10"
        Me.PRUEFLOS_TextBox.Text = "999999999999"
        '
        'VORNR_TextBox
        '
        Me.VORNR_TextBox.Location = New System.Drawing.Point(177, 323)
        Me.VORNR_TextBox.MaxLength = 4
        Me.VORNR_TextBox.Name = "VORNR_TextBox"
        Me.VORNR_TextBox.Size = New System.Drawing.Size(38, 20)
        Me.VORNR_TextBox.TabIndex = 11
        Me.VORNR_TextBox.Tag = "11"
        Me.VORNR_TextBox.Text = "9999"
        '
        'ST_TextBox
        '
        Me.ST_TextBox.Location = New System.Drawing.Point(177, 349)
        Me.ST_TextBox.MaxLength = 2
        Me.ST_TextBox.Name = "ST_TextBox"
        Me.ST_TextBox.Size = New System.Drawing.Size(38, 20)
        Me.ST_TextBox.TabIndex = 12
        Me.ST_TextBox.Tag = "12"
        Me.ST_TextBox.Text = "99"
        '
        'FormAuftragBearbeiten
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 434)
        Me.ControlBox = False
        Me.Controls.Add(Me.ST_TextBox)
        Me.Controls.Add(Me.VORNR_TextBox)
        Me.Controls.Add(Me.PRUEFLOS_TextBox)
        Me.Controls.Add(Me.GAMNG_TextBox)
        Me.Controls.Add(Me.PL_TextBox)
        Me.Controls.Add(Me.ERGAENZUNG_TextBox)
        Me.Controls.Add(Me.AUFLAGE_TextBox)
        Me.Controls.Add(Me.IDNR_TextBox)
        Me.Controls.Add(Me.HTZ_TextBox)
        Me.Controls.Add(Me.BI_TextBox)
        Me.Controls.Add(Me.BENENNUNG_TextBox)
        Me.Controls.Add(Me.AUFNR_TextBox)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.WERKS_Label)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RUECK_TextBox)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormAuftragBearbeiten"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FormAuftragBearbeiten"
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RUECK_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents ST_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents VORNR_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents PRUEFLOS_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents GAMNG_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents PL_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents ERGAENZUNG_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents AUFLAGE_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents IDNR_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents HTZ_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents BI_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents BENENNUNG_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents AUFNR_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents WERKS_Label As System.Windows.Forms.Label
End Class
