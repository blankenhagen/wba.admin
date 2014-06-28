<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAnmeldung
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.tbxAusweis = New System.Windows.Forms.TextBox()
        Me.WbData = New wbadminDataSet()
        Me.taBenutzer = New wbadminDataSetTableAdapters.BenutzerTableAdapter()
        Me.taRolle = New wbadminDataSetTableAdapters.RolleTableAdapter()
        Me.taBenutzerRolle = New wbadminDataSetTableAdapters.BenutzerRolleTableAdapter()
        Me.taBenutzerAnlage = New wbadminDataSetTableAdapters.BenutzerAnlageTableAdapter()
        Me.taAnlage = New wbadminDataSetTableAdapters.AnlageTableAdapter()
        CType(Me.WbData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ImageIndex = 6
        Me.btnCancel.Location = New System.Drawing.Point(108, 38)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Abbrechen"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'btnOk
        '
        Me.btnOk.ImageIndex = 7
        Me.btnOk.Location = New System.Drawing.Point(12, 38)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(90, 23)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "OK"
        Me.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'tbxAusweis
        '
        Me.tbxAusweis.Location = New System.Drawing.Point(12, 12)
        Me.tbxAusweis.Name = "tbxAusweis"
        Me.tbxAusweis.Size = New System.Drawing.Size(186, 20)
        Me.tbxAusweis.TabIndex = 2
        '
        'WbData
        '
        Me.WbData.DataSetName = "wbadminDataSet"
        Me.WbData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'taBenutzer
        '
        Me.taBenutzer.ClearBeforeFill = True
        '
        'taRolle
        '
        Me.taRolle.ClearBeforeFill = True
        '
        'taBenutzerRolle
        '
        Me.taBenutzerRolle.ClearBeforeFill = True
        '
        'taBenutzerAnlage
        '
        Me.taBenutzerAnlage.ClearBeforeFill = True
        '
        'taAnlage
        '
        Me.taAnlage.ClearBeforeFill = True
        '
        'FormAnmeldung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(212, 69)
        Me.ControlBox = False
        Me.Controls.Add(Me.tbxAusweis)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormAnmeldung"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ausweisnummer eingeben"
        CType(Me.WbData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents tbxAusweis As System.Windows.Forms.TextBox
    Friend WithEvents WbData As wbadminDataSet
    Friend WithEvents taBenutzer As wbadminDataSetTableAdapters.BenutzerTableAdapter
    Friend WithEvents taRolle As wbadminDataSetTableAdapters.RolleTableAdapter
    Friend WithEvents taBenutzerRolle As wbadminDataSetTableAdapters.BenutzerRolleTableAdapter
    Friend WithEvents taBenutzerAnlage As wbadminDataSetTableAdapters.BenutzerAnlageTableAdapter
    Friend WithEvents taAnlage As wbadminDataSetTableAdapters.AnlageTableAdapter
End Class
