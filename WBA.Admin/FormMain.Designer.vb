<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnHilfe = New System.Windows.Forms.Button()
        Me.btnBenutzer = New System.Windows.Forms.Button()
        Me.btnBauteil = New System.Windows.Forms.Button()
        Me.btnParameter = New System.Windows.Forms.Button()
        Me.btnProgramm = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.btnHilfe)
        Me.Panel1.Controls.Add(Me.btnBenutzer)
        Me.Panel1.Controls.Add(Me.btnBauteil)
        Me.Panel1.Controls.Add(Me.btnParameter)
        Me.Panel1.Controls.Add(Me.btnProgramm)
        Me.Panel1.Location = New System.Drawing.Point(0, 241)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(428, 42)
        Me.Panel1.TabIndex = 6
        '
        'btnHilfe
        '
        Me.btnHilfe.Location = New System.Drawing.Point(336, 10)
        Me.btnHilfe.Name = "btnHilfe"
        Me.btnHilfe.Size = New System.Drawing.Size(75, 23)
        Me.btnHilfe.TabIndex = 9
        Me.btnHilfe.Text = "Hilfe"
        Me.btnHilfe.UseVisualStyleBackColor = True
        '
        'btnBenutzer
        '
        Me.btnBenutzer.Location = New System.Drawing.Point(255, 10)
        Me.btnBenutzer.Name = "btnBenutzer"
        Me.btnBenutzer.Size = New System.Drawing.Size(75, 23)
        Me.btnBenutzer.TabIndex = 8
        Me.btnBenutzer.Text = "Benutzer"
        Me.btnBenutzer.UseVisualStyleBackColor = True
        '
        'btnBauteil
        '
        Me.btnBauteil.Location = New System.Drawing.Point(174, 10)
        Me.btnBauteil.Name = "btnBauteil"
        Me.btnBauteil.Size = New System.Drawing.Size(75, 23)
        Me.btnBauteil.TabIndex = 7
        Me.btnBauteil.Text = "Bauteil"
        Me.btnBauteil.UseVisualStyleBackColor = True
        '
        'btnParameter
        '
        Me.btnParameter.Location = New System.Drawing.Point(93, 10)
        Me.btnParameter.Name = "btnParameter"
        Me.btnParameter.Size = New System.Drawing.Size(75, 23)
        Me.btnParameter.TabIndex = 6
        Me.btnParameter.Text = "Parameter"
        Me.btnParameter.UseVisualStyleBackColor = True
        '
        'btnProgramm
        '
        Me.btnProgramm.Location = New System.Drawing.Point(12, 10)
        Me.btnProgramm.Name = "btnProgramm"
        Me.btnProgramm.Size = New System.Drawing.Size(75, 23)
        Me.btnProgramm.TabIndex = 5
        Me.btnProgramm.Text = "Programm"
        Me.btnProgramm.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.WBA.Admin.My.Resources.Resources.wbadmin
        Me.PictureBox1.Location = New System.Drawing.Point(0, 58)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(428, 225)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(428, 57)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 8
        Me.PictureBox2.TabStop = False
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 284)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FormMain"
        Me.Text = "Datenverwaltung für Warmbehandlungs-Anlagen"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnBenutzer As System.Windows.Forms.Button
    Friend WithEvents btnBauteil As System.Windows.Forms.Button
    Friend WithEvents btnParameter As System.Windows.Forms.Button
    Friend WithEvents btnProgramm As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnHilfe As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox

End Class
