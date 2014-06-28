<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormParameterDetailsBearbeiten
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
        Me.tbxAbschreckzeit = New System.Windows.Forms.MaskedTextBox()
        Me.tbxGluehzeit = New System.Windows.Forms.MaskedTextBox()
        Me.tbxSollwert = New System.Windows.Forms.MaskedTextBox()
        Me.tbxAufheizzeit = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
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
        Me.EingabePanel.Controls.Add(Me.tbxAbschreckzeit)
        Me.EingabePanel.Controls.Add(Me.tbxGluehzeit)
        Me.EingabePanel.Controls.Add(Me.tbxSollwert)
        Me.EingabePanel.Controls.Add(Me.tbxAufheizzeit)
        Me.EingabePanel.Controls.Add(Me.Label4)
        Me.EingabePanel.Controls.Add(Me.Label3)
        Me.EingabePanel.Controls.Add(Me.Label1)
        Me.EingabePanel.Controls.Add(Me.Label2)
        Me.EingabePanel.Location = New System.Drawing.Point(12, 12)
        Me.EingabePanel.Name = "EingabePanel"
        Me.EingabePanel.Size = New System.Drawing.Size(186, 238)
        Me.EingabePanel.TabIndex = 52
        '
        'tbxAbschreckzeit
        '
        Me.tbxAbschreckzeit.Location = New System.Drawing.Point(21, 142)
        Me.tbxAbschreckzeit.Mask = "#0.0"
        Me.tbxAbschreckzeit.Name = "tbxAbschreckzeit"
        Me.tbxAbschreckzeit.Size = New System.Drawing.Size(103, 20)
        Me.tbxAbschreckzeit.TabIndex = 2
        Me.tbxAbschreckzeit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbxGluehzeit
        '
        Me.tbxGluehzeit.Location = New System.Drawing.Point(21, 86)
        Me.tbxGluehzeit.Mask = "00:00"
        Me.tbxGluehzeit.Name = "tbxGluehzeit"
        Me.tbxGluehzeit.Size = New System.Drawing.Size(103, 20)
        Me.tbxGluehzeit.TabIndex = 1
        Me.tbxGluehzeit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbxSollwert
        '
        Me.tbxSollwert.Location = New System.Drawing.Point(21, 30)
        Me.tbxSollwert.Mask = "##0"
        Me.tbxSollwert.Name = "tbxSollwert"
        Me.tbxSollwert.Size = New System.Drawing.Size(103, 20)
        Me.tbxSollwert.TabIndex = 0
        Me.tbxSollwert.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbxAufheizzeit
        '
        Me.tbxAufheizzeit.Location = New System.Drawing.Point(21, 198)
        Me.tbxAufheizzeit.Mask = "00:00"
        Me.tbxAufheizzeit.Name = "tbxAufheizzeit"
        Me.tbxAufheizzeit.Size = New System.Drawing.Size(103, 20)
        Me.tbxAufheizzeit.TabIndex = 3
        Me.tbxAufheizzeit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tbxAufheizzeit.ValidatingType = GetType(Date)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 182)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 13)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Aufheizzeit [ hh:mm ]"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 13)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "Abschreckzeit [ ss,s ]"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Glühzeit [ mm:ss ]"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Sollwert [ °C ]"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.ImageIndex = 6
        Me.Cancel_Button.Location = New System.Drawing.Point(108, 256)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(90, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Abbrechen"
        Me.Cancel_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'OK_Button
        '
        Me.OK_Button.ImageIndex = 7
        Me.OK_Button.Location = New System.Drawing.Point(12, 256)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(90, 23)
        Me.OK_Button.TabIndex = 0
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
        Me.ClientSize = New System.Drawing.Size(209, 289)
        Me.ControlBox = False
        Me.Controls.Add(Me.EingabePanel)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormParameterBearbeiten"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FormParameterBearbeiten"
        Me.EingabePanel.ResumeLayout(False)
        Me.EingabePanel.PerformLayout()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EingabePanel As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    Friend WithEvents tbxAbschreckzeit As System.Windows.Forms.MaskedTextBox
    Friend WithEvents tbxGluehzeit As System.Windows.Forms.MaskedTextBox
    Friend WithEvents tbxSollwert As System.Windows.Forms.MaskedTextBox
    Friend WithEvents tbxAufheizzeit As System.Windows.Forms.MaskedTextBox
End Class
