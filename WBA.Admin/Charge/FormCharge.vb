Public Class FormCharge

    ''' <summary>
    ''' Das Formular wird geladen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FormCharge_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.ChargeVerzeichnisLabel.Text = My.Settings.Exportpfad
        Me.NummerLabel.Text = String.Empty
    End Sub

    ''' <summary>
    ''' Verzeichnis auswählen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ChargeVerzeichnisButton_Click(sender As System.Object, e As System.EventArgs) Handles ChargeVerzeichnisButton.Click
        Using fbd As New Windows.Forms.FolderBrowserDialog
            If Me.ChargeVerzeichnisLabel.Text <> String.Empty Then
                fbd.SelectedPath = Me.ChargeVerzeichnisLabel.Text
            End If

            fbd.ShowDialog()
            Me.ChargeVerzeichnisLabel.Text = fbd.SelectedPath
            My.Settings.Exportpfad = fbd.SelectedPath
            My.Settings.Save()
        End Using
    End Sub

    Private Sub EndeMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EndeMenuItem.Click

        Me.Close()
    End Sub

    Private Sub ExportMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExportMenuItem.Click

    End Sub

    Private Sub EnterButton_Click(sender As System.Object, e As System.EventArgs) Handles EnterButton.Click

        Me.NummerLabel.Text = Me.AnlageComboBox.Text & " - " & _
                              Me.DateTimePicker.Value.ToString("yyyyMMdd") & _
                              Me.ZaehlzahlTextBox.Text
    End Sub
End Class