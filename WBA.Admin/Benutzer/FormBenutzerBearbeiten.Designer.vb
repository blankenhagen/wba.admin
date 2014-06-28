<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBenutzerBearbeiten
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
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.cbxGesperrt = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbxSAP = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbxENR = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbxAusweisnummer = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbxVorname = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbxName = New System.Windows.Forms.TextBox()
        Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK_Button.ImageIndex = 7
        Me.OK_Button.Location = New System.Drawing.Point(8, 222)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(90, 23)
        Me.OK_Button.TabIndex = 6
        Me.OK_Button.Text = "OK"
        Me.OK_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'Cancel_Button
        '
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.ImageIndex = 6
        Me.Cancel_Button.Location = New System.Drawing.Point(104, 222)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(90, 23)
        Me.Cancel_Button.TabIndex = 7
        Me.Cancel_Button.Text = "Abbrechen"
        Me.Cancel_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'cbxGesperrt
        '
        Me.cbxGesperrt.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.cbxGesperrt.Location = New System.Drawing.Point(13, 178)
        Me.cbxGesperrt.Name = "cbxGesperrt"
        Me.cbxGesperrt.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbxGesperrt.Size = New System.Drawing.Size(103, 17)
        Me.cbxGesperrt.TabIndex = 5
        Me.cbxGesperrt.Text = "Gesperrt"
        Me.cbxGesperrt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbxGesperrt.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label5.Location = New System.Drawing.Point(14, 148)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "SAP"
        '
        'tbxSAP
        '
        Me.tbxSAP.Location = New System.Drawing.Point(101, 145)
        Me.tbxSAP.Name = "tbxSAP"
        Me.tbxSAP.Size = New System.Drawing.Size(193, 20)
        Me.tbxSAP.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label4.Location = New System.Drawing.Point(12, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "ENR"
        '
        'tbxENR
        '
        Me.tbxENR.Location = New System.Drawing.Point(101, 112)
        Me.tbxENR.Name = "tbxENR"
        Me.tbxENR.Size = New System.Drawing.Size(193, 20)
        Me.tbxENR.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label3.Location = New System.Drawing.Point(12, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Ausweisnummer"
        '
        'tbxAusweisnummer
        '
        Me.tbxAusweisnummer.Location = New System.Drawing.Point(101, 79)
        Me.tbxAusweisnummer.Name = "tbxAusweisnummer"
        Me.tbxAusweisnummer.Size = New System.Drawing.Size(193, 20)
        Me.tbxAusweisnummer.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.Location = New System.Drawing.Point(12, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Vorname"
        '
        'tbxVorname
        '
        Me.tbxVorname.Location = New System.Drawing.Point(101, 45)
        Me.tbxVorname.Name = "tbxVorname"
        Me.tbxVorname.Size = New System.Drawing.Size(193, 20)
        Me.tbxVorname.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name"
        '
        'tbxName
        '
        Me.tbxName.Location = New System.Drawing.Point(101, 9)
        Me.tbxName.Name = "tbxName"
        Me.tbxName.Size = New System.Drawing.Size(193, 20)
        Me.tbxName.TabIndex = 0
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'FormBenutzerBearbeiten
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(308, 257)
        Me.Controls.Add(Me.cbxGesperrt)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.tbxSAP)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbxENR)
        Me.Controls.Add(Me.tbxName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbxVorname)
        Me.Controls.Add(Me.tbxAusweisnummer)
        Me.Controls.Add(Me.Label2)
        Me.Name = "FormBenutzerBearbeiten"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FormEditBenutzer"
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents cbxGesperrt As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbxSAP As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbxENR As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbxAusweisnummer As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbxVorname As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbxName As System.Windows.Forms.TextBox
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
End Class
