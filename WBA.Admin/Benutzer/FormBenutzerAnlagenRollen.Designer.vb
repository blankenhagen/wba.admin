<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBenutzerAnlagenRollen
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
        Me.dgvAnlagenRollen = New System.Windows.Forms.DataGridView()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.AbbrButton = New System.Windows.Forms.Button()
        Me.NameLabel = New System.Windows.Forms.Label()
        CType(Me.dgvAnlagenRollen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvAnlagenRollen
        '
        Me.dgvAnlagenRollen.AllowUserToAddRows = False
        Me.dgvAnlagenRollen.AllowUserToDeleteRows = False
        Me.dgvAnlagenRollen.AllowUserToOrderColumns = True
        Me.dgvAnlagenRollen.AllowUserToResizeColumns = False
        Me.dgvAnlagenRollen.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Tan
        Me.dgvAnlagenRollen.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAnlagenRollen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAnlagenRollen.Location = New System.Drawing.Point(12, 47)
        Me.dgvAnlagenRollen.MultiSelect = False
        Me.dgvAnlagenRollen.Name = "dgvAnlagenRollen"
        Me.dgvAnlagenRollen.ReadOnly = True
        Me.dgvAnlagenRollen.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvAnlagenRollen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAnlagenRollen.Size = New System.Drawing.Size(395, 178)
        Me.dgvAnlagenRollen.TabIndex = 8
        '
        'OkButton
        '
        Me.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OkButton.Location = New System.Drawing.Point(12, 231)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 23)
        Me.OkButton.TabIndex = 7
        Me.OkButton.Text = "Ok"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'AbbrButton
        '
        Me.AbbrButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.AbbrButton.Location = New System.Drawing.Point(93, 231)
        Me.AbbrButton.Name = "AbbrButton"
        Me.AbbrButton.Size = New System.Drawing.Size(75, 23)
        Me.AbbrButton.TabIndex = 6
        Me.AbbrButton.Text = "Cancel"
        Me.AbbrButton.UseVisualStyleBackColor = True
        '
        'NameLabel
        '
        Me.NameLabel.AutoEllipsis = True
        Me.NameLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NameLabel.Location = New System.Drawing.Point(12, 0)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(372, 44)
        Me.NameLabel.TabIndex = 9
        Me.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FormBenutzerAnlagenRollen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(419, 263)
        Me.Controls.Add(Me.NameLabel)
        Me.Controls.Add(Me.AbbrButton)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.dgvAnlagenRollen)
        Me.Name = "FormBenutzerAnlagenRollen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Form2"
        CType(Me.dgvAnlagenRollen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvAnlagenRollen As System.Windows.Forms.DataGridView
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents AbbrButton As System.Windows.Forms.Button
    Friend WithEvents NameLabel As System.Windows.Forms.Label
End Class
