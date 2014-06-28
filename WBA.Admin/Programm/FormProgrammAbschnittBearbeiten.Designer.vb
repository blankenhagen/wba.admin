<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProgrammAbschnittBearbeiten
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.AbschnittDataGridView = New System.Windows.Forms.DataGridView()
        Me.DeleteButton = New System.Windows.Forms.Button()
        Me.InsertButton = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.AbbruchButton = New System.Windows.Forms.Button()
        Me.OkButton = New System.Windows.Forms.Button()
        CType(Me.AbschnittDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'AbschnittDataGridView
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.AbschnittDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.AbschnittDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AbschnittDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AbschnittDataGridView.Location = New System.Drawing.Point(3, 3)
        Me.AbschnittDataGridView.Name = "AbschnittDataGridView"
        Me.AbschnittDataGridView.Size = New System.Drawing.Size(191, 373)
        Me.AbschnittDataGridView.TabIndex = 0
        '
        'DeleteButton
        '
        Me.DeleteButton.Location = New System.Drawing.Point(102, 382)
        Me.DeleteButton.Name = "DeleteButton"
        Me.DeleteButton.Size = New System.Drawing.Size(75, 23)
        Me.DeleteButton.TabIndex = 2
        Me.DeleteButton.Text = "Löschen"
        Me.DeleteButton.UseVisualStyleBackColor = True
        '
        'InsertButton
        '
        Me.InsertButton.Location = New System.Drawing.Point(21, 382)
        Me.InsertButton.Name = "InsertButton"
        Me.InsertButton.Size = New System.Drawing.Size(75, 23)
        Me.InsertButton.TabIndex = 3
        Me.InsertButton.Text = "Einfügen"
        Me.InsertButton.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.AbbruchButton)
        Me.Panel1.Controls.Add(Me.OkButton)
        Me.Panel1.Controls.Add(Me.AbschnittDataGridView)
        Me.Panel1.Controls.Add(Me.InsertButton)
        Me.Panel1.Controls.Add(Me.DeleteButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 442)
        Me.Panel1.TabIndex = 4
        '
        'AbbruchButton
        '
        Me.AbbruchButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.AbbruchButton.Location = New System.Drawing.Point(119, 414)
        Me.AbbruchButton.Name = "AbbruchButton"
        Me.AbbruchButton.Size = New System.Drawing.Size(75, 23)
        Me.AbbruchButton.TabIndex = 5
        Me.AbbruchButton.Text = "Abbruch"
        Me.AbbruchButton.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OkButton.Location = New System.Drawing.Point(3, 414)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 23)
        Me.OkButton.TabIndex = 4
        Me.OkButton.Text = "Ok"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'FormProgrammAbschnittBearbeiten
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(200, 442)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormProgrammAbschnittBearbeiten"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Abschnitte bearbeiten"
        CType(Me.AbschnittDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AbschnittDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DeleteButton As System.Windows.Forms.Button
    Friend WithEvents InsertButton As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents AbbruchButton As System.Windows.Forms.Button

End Class
