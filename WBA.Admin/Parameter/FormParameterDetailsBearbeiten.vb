Imports WBA.Admin.wbadminDataSet

Public Class FormParameterDetailsBearbeiten
    ' Hier steht das Ergebnis der Funktion "DatenBearbeiten"
    Private _DataRow As ParameterRow
    Private _DataSet As wbadminDataSet

    Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Cancel_Button_Click(sender As System.Object, e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    End Sub

    Public Function DatenBearbeiten(ByVal dataSet As wbadminDataSet, ByVal row As ParameterRow) As ParameterRow
        Using Me
            _DataSet = dataSet ' Die Referenz auf das Dataset übernehmen
            DatenInMaske(row) ' Die Daten aus der DataRow in die Maske übernehmen
            Me.ShowDialog() ' Den Dialog anzeigen
            Return _DataRow ' Die DataRow zurückgeben
        End Using
    End Function

    Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)

        ' Überprüfung des Formulars nur, wenn OK geklickt wurde:
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then

            ' Daten aus Maske gibt ein DataRow-Objekt nur dann zurück,
            ' wenn die Daten in Ordnung waren.
            _DataRow = DatenAusMaske()

            ' Wenn _BenutzerRow also Nothing und damit NICHT in Ordnung war, ...
            If _DataRow Is Nothing Then

                ' ... bleibt der Dialog, der ja eigentlich geschlossen werden soll,
                ' offen - und das erreichen wir durch Setzen von
                e.Cancel = True
            End If
        Else
            ' Diese Zeile kann nur erreicht werden, wenn Abbrechen
            ' ausgelöst wurde. Dann wird auf jeden Fall Nothing als
            ' Funktionsergebnis zurückgegeben.
            _DataRow = Nothing
        End If
    End Sub

    ''' <summary>
    ''' Überprüft die Eingaben im Formular, und liefert im Erfolgsfall
    ''' ein fix-und-fertiges DataRow-Objekt aus den Eingabefeldern zurück.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function DatenAusMaske() As ParameterRow

        Dim locFehler As Boolean

        ' Alle vorherigen Fehler zurücksetzen
        Me.ErrProv.Clear()

        ' Eingabefelder überprüfen
        If String.IsNullOrEmpty(tbxSollwert.Text) Then
            ErrProv.SetError(tbxSollwert, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        End If

        If String.IsNullOrEmpty(tbxGluehzeit.Text) Then
            ErrProv.SetError(tbxGluehzeit, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        End If

        If String.IsNullOrEmpty(tbxAbschreckzeit.Text) Then
            ErrProv.SetError(tbxAbschreckzeit, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        End If

        If String.IsNullOrEmpty(tbxAufheizzeit.Text) Then
            ErrProv.SetError(tbxAufheizzeit, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        End If

        ' Fehler war vorhanden - Nothing zurückliefern
        If locFehler Then Return Nothing

        ' Alles war OK, es wird eine neue DataRow erzeugt
        Try
            _DataRow = _DataSet.Parameter.NewParameterRow
            _DataRow.Sollwert = Integer.Parse(Me.tbxSollwert.Text)
            _DataRow.Gluehzeit = TimeSpan.Parse("00:" & Me.tbxGluehzeit.Text).TotalSeconds()
            _DataRow.Abschreckzeit = Single.Parse(Me.tbxAbschreckzeit.Text)
            _DataRow.Aufheizzeit = TimeSpan.Parse(Me.tbxAufheizzeit.Text).TotalMinutes()

            'If Me.tbxAufheizzeit.MaskFull Then
            '    intValue = Me.GetTotalMinutes(Me.tbxAufheizzeit.Text)

            '    If drv("Dauer") <> TimeSpan.Parse(Me.tbxDauer.Text).TotalMinutes Then
            '        drv("Dauer") = TimeSpan.Parse(Me.tbxDauer.Text).TotalMinutes
            '    End If
            'Else
            '    MsgBox("Eingabefehler!")
            '    Me.tbxDauer.Focus()
            '    Me.tbxDauer.SelectAll()
            '    Exit Function
            'End If

            ' Die übrigen Spalten werden an anderer Stelle editiert
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.Message)
        End Try

        Return _DataRow
    End Function

    ''' <summary>
    ''' Lädt die Daten aus der DataRow in die Maske
    ''' Bei neuem Parameter Datensatz werden die Felder mit Leerstrings vorbesetzt
    ''' </summary>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Private Sub DatenInMaske(ByVal row As ParameterRow)
        Me.Text = "Parameter bearbeiten"

        Try
            Me.tbxSollwert.Text = row.Sollwert.ToString
            Me.tbxGluehzeit.Text = DateTime.MinValue.AddSeconds(row.Gluehzeit).ToString("mm:ss")
            Me.tbxAbschreckzeit.Text = row.Abschreckzeit.ToString("00.0")
            Me.tbxAufheizzeit.Text = DateTime.MinValue.AddMinutes(row.Aufheizzeit).ToString("HH:mm")
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormParameterBearbeiten_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub FormParameterBearbeiten_Activated(sender As System.Object, e As System.EventArgs) Handles MyBase.Activated
        ' Das erste Feld hat den Fokus. Der gesamte Inhalt wird in "OnEnter" markiert
        Me.tbxSollwert.Focus()
    End Sub

    Private Sub tbxSollwert_Enter(sender As System.Object, e As System.EventArgs) Handles tbxSollwert.Enter, tbxGluehzeit.Enter, tbxAufheizzeit.Enter, tbxAbschreckzeit.Enter
        ' Der Delegat wird asynchron aufgerufen und diese Methode unmittelbar danach beendet
        BeginInvoke(DirectCast(Sub() DirectCast(sender, MaskedTextBox).SelectAll(), Action))
    End Sub
End Class