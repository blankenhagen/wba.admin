<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormParameterBearbeiten
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
        Me.EingabePanel = New System.Windows.Forms.Panel()
        Me.cbxGesperrt = New System.Windows.Forms.CheckBox()
        Me.cbxFreigabe = New System.Windows.Forms.CheckBox()
        Me.tbxName = New System.Windows.Forms.TextBox()
        Me.tbxBemerkung = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.EingabePanel.SuspendLayout()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EingabePanel
        '
        Me.EingabePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EingabePanel.Controls.Add(Me.cbxGesperrt)
        Me.EingabePanel.Controls.Add(Me.cbxFreigabe)
        Me.EingabePanel.Controls.Add(Me.tbxName)
        Me.EingabePanel.Controls.Add(Me.tbxBemerkung)
        Me.EingabePanel.Controls.Add(Me.Label2)
        Me.EingabePanel.Controls.Add(Me.Label3)
        Me.EingabePanel.Location = New System.Drawing.Point(12, 12)
        Me.EingabePanel.Name = "EingabePanel"
        Me.EingabePanel.Size = New System.Drawing.Size(294, 192)
        Me.EingabePanel.TabIndex = 52
        '
        'cbxGesperrt
        '
        Me.cbxGesperrt.AutoSize = True
        Me.cbxGesperrt.Location = New System.Drawing.Point(209, 57)
        Me.cbxGesperrt.Name = "cbxGesperrt"
        Me.cbxGesperrt.Size = New System.Drawing.Size(66, 17)
        Me.cbxGesperrt.TabIndex = 47
        Me.cbxGesperrt.Text = "Gesperrt"
        Me.cbxGesperrt.UseVisualStyleBackColor = True
        '
        'cbxFreigabe
        '
        Me.cbxFreigabe.AutoSize = True
        Me.cbxFreigabe.Location = New System.Drawing.Point(208, 34)
        Me.cbxFreigabe.Name = "cbxFreigabe"
        Me.cbxFreigabe.Size = New System.Drawing.Size(67, 17)
        Me.cbxFreigabe.TabIndex = 0
        Me.cbxFreigabe.Text = "Freigabe"
        Me.cbxFreigabe.UseVisualStyleBackColor = True
        '
        'tbxName
        '
        Me.tbxName.Location = New System.Drawing.Point(16, 31)
        Me.tbxName.Name = "tbxName"
        Me.tbxName.Size = New System.Drawing.Size(135, 20)
        Me.tbxName.TabIndex = 1
        '
        'tbxBemerkung
        '
        Me.tbxBemerkung.Location = New System.Drawing.Point(16, 100)
        Me.tbxBemerkung.Multiline = True
        Me.tbxBemerkung.Name = "tbxBemerkung"
        Me.tbxBemerkung.Size = New System.Drawing.Size(260, 77)
        Me.tbxBemerkung.TabIndex = 43
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Bemerkung"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.ImageIndex = 6
        Me.Cancel_Button.Location = New System.Drawing.Point(161, 210)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(90, 23)
        Me.Cancel_Button.TabIndex = 51
        Me.Cancel_Button.Text = "Abbrechen"
        Me.Cancel_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'OK_Button
        '
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK_Button.ImageIndex = 7
        Me.OK_Button.Location = New System.Drawing.Point(65, 210)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(90, 23)
        Me.OK_Button.TabIndex = 50
        Me.OK_Button.Text = "OK"
        Me.OK_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'FormParameterBearbeiten
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(320, 243)
        Me.ControlBox = False
        Me.Controls.Add(Me.EingabePanel)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.Name = "FormParameterBearbeiten"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FormParameterBearbeiten"
        Me.EingabePanel.ResumeLayout(False)
        Me.EingabePanel.PerformLayout()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EingabePanel As System.Windows.Forms.Panel
    Friend WithEvents cbxGesperrt As System.Windows.Forms.CheckBox
    Friend WithEvents cbxFreigabe As System.Windows.Forms.CheckBox
    Friend WithEvents tbxName As System.Windows.Forms.TextBox
    Friend WithEvents tbxBemerkung As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
End Class
