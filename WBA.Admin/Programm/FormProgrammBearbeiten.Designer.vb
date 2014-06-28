<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProgrammBearbeiten
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
        Me.NameTextBox = New System.Windows.Forms.TextBox()
        Me.VerfahrenComboBox = New System.Windows.Forms.ComboBox()
        Me.BemerkungTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.VerfahrenLabel = New System.Windows.Forms.Label()
        Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.NameLabel = New System.Windows.Forms.Label()
        Me.ReleaseAndLock = New WBA.Admin.ReleaseAndLock()
        Me.AbschnitteButton = New System.Windows.Forms.Button()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NameTextBox
        '
        Me.NameTextBox.Location = New System.Drawing.Point(12, 75)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(135, 20)
        Me.NameTextBox.TabIndex = 1
        '
        'VerfahrenComboBox
        '
        Me.VerfahrenComboBox.FormattingEnabled = True
        Me.VerfahrenComboBox.Items.AddRange(New Object() {"Weichglühen", "Warmauslagern"})
        Me.VerfahrenComboBox.Location = New System.Drawing.Point(12, 25)
        Me.VerfahrenComboBox.Name = "VerfahrenComboBox"
        Me.VerfahrenComboBox.Size = New System.Drawing.Size(135, 21)
        Me.VerfahrenComboBox.TabIndex = 42
        '
        'BemerkungTextBox
        '
        Me.BemerkungTextBox.Location = New System.Drawing.Point(12, 125)
        Me.BemerkungTextBox.Multiline = True
        Me.BemerkungTextBox.Name = "BemerkungTextBox"
        Me.BemerkungTextBox.Size = New System.Drawing.Size(450, 49)
        Me.BemerkungTextBox.TabIndex = 43
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Verfahren"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.Location = New System.Drawing.Point(12, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label3.Location = New System.Drawing.Point(12, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Bemerkung"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.ImageIndex = 6
        Me.Cancel_Button.Location = New System.Drawing.Point(93, 180)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(75, 23)
        Me.Cancel_Button.TabIndex = 48
        Me.Cancel_Button.Text = "Abbrechen"
        Me.Cancel_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'OK_Button
        '
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK_Button.ImageIndex = 7
        Me.OK_Button.Location = New System.Drawing.Point(12, 180)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(75, 23)
        Me.OK_Button.TabIndex = 47
        Me.OK_Button.Text = "OK"
        Me.OK_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'VerfahrenLabel
        '
        Me.VerfahrenLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.VerfahrenLabel.Location = New System.Drawing.Point(17, 36)
        Me.VerfahrenLabel.Name = "VerfahrenLabel"
        Me.VerfahrenLabel.Size = New System.Drawing.Size(56, 23)
        Me.VerfahrenLabel.TabIndex = 48
        Me.VerfahrenLabel.Text = "Verfahren"
        Me.VerfahrenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.VerfahrenLabel.Visible = False
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'NameLabel
        '
        Me.NameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NameLabel.Location = New System.Drawing.Point(17, 85)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(56, 23)
        Me.NameLabel.TabIndex = 49
        Me.NameLabel.Text = "Name"
        Me.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NameLabel.Visible = False
        '
        'ReleaseAndLock
        '
        Me.ReleaseAndLock.Anlage = Nothing
        Me.ReleaseAndLock.CanLock = False
        Me.ReleaseAndLock.CanRelease = False
        Me.ReleaseAndLock.Location = New System.Drawing.Point(153, 9)
        Me.ReleaseAndLock.Lock = 0
        Me.ReleaseAndLock.Name = "ReleaseAndLock"
        Me.ReleaseAndLock.Release = 0
        Me.ReleaseAndLock.Size = New System.Drawing.Size(309, 109)
        Me.ReleaseAndLock.TabIndex = 47
        Me.ReleaseAndLock.Verfahren = 0
        '
        'AbschnitteButton
        '
        Me.AbschnitteButton.Location = New System.Drawing.Point(387, 180)
        Me.AbschnitteButton.Name = "AbschnitteButton"
        Me.AbschnitteButton.Size = New System.Drawing.Size(75, 23)
        Me.AbschnitteButton.TabIndex = 50
        Me.AbschnitteButton.Text = "Abschnitte"
        Me.AbschnitteButton.UseVisualStyleBackColor = True
        '
        'FormProgrammBearbeiten
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 213)
        Me.ControlBox = False
        Me.Controls.Add(Me.AbschnitteButton)
        Me.Controls.Add(Me.NameLabel)
        Me.Controls.Add(Me.VerfahrenLabel)
        Me.Controls.Add(Me.BemerkungTextBox)
        Me.Controls.Add(Me.ReleaseAndLock)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.NameTextBox)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.VerfahrenComboBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormProgrammBearbeiten"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FormProgrammBearbeiten"
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents VerfahrenComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents BemerkungTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    Friend WithEvents ReleaseAndLock As WBA.Admin.ReleaseAndLock
    Friend WithEvents VerfahrenLabel As System.Windows.Forms.Label
    Friend WithEvents NameLabel As System.Windows.Forms.Label
    Friend WithEvents AbschnitteButton As System.Windows.Forms.Button
End Class
