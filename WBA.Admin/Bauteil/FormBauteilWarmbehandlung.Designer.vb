<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBauteilWarmbehandlung
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
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.dgvWarmbehandlung = New System.Windows.Forms.DataGridView()
        Me.cbxFilter = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgvWarmbehandlung, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Cancel_Button
        '
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.ImageIndex = 6
        Me.Cancel_Button.Location = New System.Drawing.Point(107, 193)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(90, 23)
        Me.Cancel_Button.TabIndex = 3
        Me.Cancel_Button.Text = "Abbrechen"
        Me.Cancel_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'OK_Button
        '
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK_Button.ImageIndex = 7
        Me.OK_Button.Location = New System.Drawing.Point(11, 193)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(90, 23)
        Me.OK_Button.TabIndex = 2
        Me.OK_Button.Text = "OK"
        Me.OK_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'dgvWarmbehandlung
        '
        Me.dgvWarmbehandlung.AllowUserToAddRows = False
        Me.dgvWarmbehandlung.AllowUserToDeleteRows = False
        Me.dgvWarmbehandlung.AllowUserToResizeColumns = False
        Me.dgvWarmbehandlung.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Tan
        Me.dgvWarmbehandlung.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvWarmbehandlung.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvWarmbehandlung.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvWarmbehandlung.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvWarmbehandlung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWarmbehandlung.Location = New System.Drawing.Point(11, 52)
        Me.dgvWarmbehandlung.MultiSelect = False
        Me.dgvWarmbehandlung.Name = "dgvWarmbehandlung"
        Me.dgvWarmbehandlung.ReadOnly = True
        Me.dgvWarmbehandlung.RowHeadersVisible = False
        Me.dgvWarmbehandlung.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvWarmbehandlung.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvWarmbehandlung.Size = New System.Drawing.Size(186, 135)
        Me.dgvWarmbehandlung.TabIndex = 46
        '
        'cbxFilter
        '
        Me.cbxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxFilter.FormattingEnabled = True
        Me.cbxFilter.Items.AddRange(New Object() {"Alle", "Lösungsglühen", "Weichglühen", "Warmauslagern"})
        Me.cbxFilter.Location = New System.Drawing.Point(12, 25)
        Me.cbxFilter.Name = "cbxFilter"
        Me.cbxFilter.Size = New System.Drawing.Size(185, 21)
        Me.cbxFilter.TabIndex = 47
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Filter"
        '
        'FormBauteilWarmbehandlung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(208, 225)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbxFilter)
        Me.Controls.Add(Me.dgvWarmbehandlung)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormBauteilWarmbehandlung"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FormBauteilWarmbehandlung"
        CType(Me.dgvWarmbehandlung, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents dgvWarmbehandlung As System.Windows.Forms.DataGridView
    Friend WithEvents cbxFilter As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
