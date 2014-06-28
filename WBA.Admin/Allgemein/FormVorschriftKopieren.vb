Public Class FormVorschriftKopieren

    Private OldName As String = String.Empty
    Private NewName As String = String.Empty
    Private Names() As String
    Private WbData As WBA.Admin.wbadminDataSet = Nothing

    ''' <summary>
    ''' Das Formular wird geladen
    ''' Textboxen setzen und 
    ''' alle Vorschrift-Namen in Array
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FormVorschriftKopieren_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.OldNameTextBox.Text = Me.OldName
        Me.NewNameTextBox.Text = Me.OldName

        Me.Names = (From wb In WbData.Warmbehandlung
                    Select wb.Name).ToArray
    End Sub

    ''' <summary>
    ''' Das Formular soll geschlossen werden
    ''' Den neuen Namen auf Gültigkeit prüfen
    ''' Der Dialog kann bei ungültigem Namen nicht geschlossen werden
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FormVorschriftKopieren_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        MyBase.OnClosing(e)

        If Me.DialogResult = Windows.Forms.DialogResult.OK Then

            If Me.CheckName = String.Empty Then
                e.Cancel = True
            End If
        Else
            Me.NewName = String.Empty ' ?????
        End If
    End Sub

    ''' <summary>
    ''' Die Namensüberprüfung durchführen
    ''' </summary>
    ''' <returns>den Namen</returns>
    ''' <remarks></remarks>
    Private Function CheckName() As String
        Dim locFehler As Boolean

        ' Alle möglichen vorherigen Fehler zurücksetzen
        Me.ErrProv.Clear()

        ' Wenn keine Eingabe im Feld gemacht wurde,
        If String.IsNullOrEmpty(Me.NewNameTextBox.Text) Then
            ErrProv.SetError(Me.NewNameTextBox, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        Else
            If Me.NewNameTextBox.Text.Length <= 10 Then
                For Each name As String In Me.Names

                    If name.ToUpper = Me.NewNameTextBox.Text.ToUpper Then
                        ErrProv.SetError(Me.NewNameTextBox, "Name ist schon vergeben!")
                        locFehler = locFehler Or True
                        Exit For
                    End If
                Next
            Else
                ErrProv.SetError(Me.NewNameTextBox, "Name darf max. 10 Zeichen lang sein!")
                locFehler = locFehler Or True
            End If
        End If

        ' Bei Fehler leeren String zurückliefern...
        If locFehler Then Return String.Empty

        ' ...sonst den neuen Namen
        Me.NewName = Me.NewNameTextBox.Text

        Return Me.NewName
    End Function

    ''' <summary>
    ''' Den neuen Namen über den Dialog abfragen
    ''' </summary>
    ''' <param name="sender">das Dataset</param>
    ''' <param name="name">der alte Name</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetName(sender As Object, name As String) As String
        Using Me
            Me.WbData = DirectCast(sender, WBA.Admin.wbadminDataSet)
            Me.OldName = name

            ' Den Dialog anzeigen...
            Me.ShowDialog()

            ' ...und den neuen Namen zurückliefern
            Return Me.NewName
        End Using
    End Function
End Class