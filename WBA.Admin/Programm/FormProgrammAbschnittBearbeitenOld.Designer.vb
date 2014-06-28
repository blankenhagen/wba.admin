<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProgrammAbschnittBearbeitenOld
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProgrammAbschnittBearbeitenOld))
        Me.tbxSollwert = New System.Windows.Forms.MaskedTextBox()
        Me.tbxDauer = New System.Windows.Forms.MaskedTextBox()
        Me.btnRowDown = New System.Windows.Forms.Button()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnRowUp = New System.Windows.Forms.Button()
        Me.btnEnter = New System.Windows.Forms.Button()
        Me.btnEnde = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbxSollwert
        '
        Me.tbxSollwert.Location = New System.Drawing.Point(37, 22)
        Me.tbxSollwert.Mask = "##0"
        Me.tbxSollwert.Name = "tbxSollwert"
        Me.tbxSollwert.Size = New System.Drawing.Size(34, 20)
        Me.tbxSollwert.TabIndex = 1
        Me.tbxSollwert.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbxDauer
        '
        Me.tbxDauer.Location = New System.Drawing.Point(77, 22)
        Me.tbxDauer.Mask = "00:00"
        Me.tbxDauer.Name = "tbxDauer"
        Me.tbxDauer.Size = New System.Drawing.Size(38, 20)
        Me.tbxDauer.TabIndex = 2
        Me.tbxDauer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tbxDauer.ValidatingType = GetType(Date)
        '
        'btnRowDown
        '
        Me.btnRowDown.ImageIndex = 1
        Me.btnRowDown.ImageList = Me.ImageList
        Me.btnRowDown.Location = New System.Drawing.Point(120, 1)
        Me.btnRowDown.Name = "btnRowDown"
        Me.btnRowDown.Size = New System.Drawing.Size(29, 39)
        Me.btnRowDown.TabIndex = 6
        Me.btnRowDown.UseVisualStyleBackColor = True
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Fuchsia
        Me.ImageList.Images.SetKeyName(0, "BuilderDialog_moveup.bmp")
        Me.ImageList.Images.SetKeyName(1, "BuilderDialog_movedown.bmp")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Temp."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(77, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "hh:mm"
        '
        'btnRowUp
        '
        Me.btnRowUp.ImageIndex = 0
        Me.btnRowUp.ImageList = Me.ImageList
        Me.btnRowUp.Location = New System.Drawing.Point(1, 1)
        Me.btnRowUp.Name = "btnRowUp"
        Me.btnRowUp.Size = New System.Drawing.Size(29, 37)
        Me.btnRowUp.TabIndex = 5
        Me.btnRowUp.UseVisualStyleBackColor = True
        '
        'btnEnter
        '
        Me.btnEnter.Location = New System.Drawing.Point(1, 46)
        Me.btnEnter.Name = "btnEnter"
        Me.btnEnter.Size = New System.Drawing.Size(69, 23)
        Me.btnEnter.TabIndex = 3
        Me.btnEnter.Text = "Enter"
        Me.btnEnter.UseVisualStyleBackColor = True
        '
        'btnEnde
        '
        Me.btnEnde.Location = New System.Drawing.Point(77, 46)
        Me.btnEnde.Name = "btnEnde"
        Me.btnEnde.Size = New System.Drawing.Size(72, 23)
        Me.btnEnde.TabIndex = 4
        Me.btnEnde.Text = "Ende"
        Me.btnEnde.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnRowUp)
        Me.Panel1.Controls.Add(Me.btnEnde)
        Me.Panel1.Controls.Add(Me.tbxSollwert)
        Me.Panel1.Controls.Add(Me.btnEnter)
        Me.Panel1.Controls.Add(Me.tbxDauer)
        Me.Panel1.Controls.Add(Me.btnRowDown)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(152, 73)
        Me.Panel1.TabIndex = 9
        '
        'FormProgrammAbschnittBearbeiten
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(152, 73)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormProgrammAbschnittBearbeiten"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Abschnitt: 99"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbxSollwert As System.Windows.Forms.MaskedTextBox
    Friend WithEvents tbxDauer As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnRowDown As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnRowUp As System.Windows.Forms.Button
    Friend WithEvents btnEnter As System.Windows.Forms.Button
    Friend WithEvents btnEnde As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
End Class
