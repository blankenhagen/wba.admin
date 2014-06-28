<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVorschriftKopieren
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
        Me.OldNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NewNameTextBox = New System.Windows.Forms.TextBox()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OldNameTextBox
        '
        Me.OldNameTextBox.Location = New System.Drawing.Point(12, 28)
        Me.OldNameTextBox.Name = "OldNameTextBox"
        Me.OldNameTextBox.ReadOnly = True
        Me.OldNameTextBox.Size = New System.Drawing.Size(119, 20)
        Me.OldNameTextBox.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Aktueller Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(137, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Neuer Name"
        '
        'NewNameTextBox
        '
        Me.NewNameTextBox.Location = New System.Drawing.Point(137, 28)
        Me.NewNameTextBox.Name = "NewNameTextBox"
        Me.NewNameTextBox.Size = New System.Drawing.Size(119, 20)
        Me.NewNameTextBox.TabIndex = 2
        '
        'Cancel_Button
        '
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.ImageIndex = 6
        Me.Cancel_Button.Location = New System.Drawing.Point(137, 63)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(90, 23)
        Me.Cancel_Button.TabIndex = 50
        Me.Cancel_Button.Text = "Abbrechen"
        Me.Cancel_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'OK_Button
        '
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK_Button.ImageIndex = 7
        Me.OK_Button.Location = New System.Drawing.Point(41, 63)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(90, 23)
        Me.OK_Button.TabIndex = 49
        Me.OK_Button.Text = "OK"
        Me.OK_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'FormVorschriftKopieren
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(272, 98)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NewNameTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.OldNameTextBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormVorschriftKopieren"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Vorschrift kopieren"
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OldNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NewNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
End Class
