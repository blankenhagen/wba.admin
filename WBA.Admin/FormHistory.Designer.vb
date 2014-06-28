<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormHistory
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
        Me.tbxHistory = New System.Windows.Forms.RichTextBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'tbxHistory
        '
        Me.tbxHistory.BackColor = System.Drawing.SystemColors.Window
        Me.tbxHistory.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxHistory.Location = New System.Drawing.Point(12, 12)
        Me.tbxHistory.Name = "tbxHistory"
        Me.tbxHistory.ReadOnly = True
        Me.tbxHistory.Size = New System.Drawing.Size(673, 302)
        Me.tbxHistory.TabIndex = 0
        Me.tbxHistory.Text = ""
        Me.tbxHistory.WordWrap = False
        '
        'btnOk
        '
        Me.btnOk.ImageIndex = 7
        Me.btnOk.Location = New System.Drawing.Point(12, 320)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(90, 23)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "OK"
        Me.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'FormHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(697, 353)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.tbxHistory)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbxHistory As System.Windows.Forms.RichTextBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
End Class
