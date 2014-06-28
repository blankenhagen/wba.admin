Imports WBA.Admin.wbadminDataSet

Public Class FormParameterBearbeiten
    ' Hier steht das Ergebnis der Funktion "DatenBearbeiten"
    Private _DataRow As WarmbehandlungRow
    Private _DataSet As wbadminDataSet
    Private _Namen() As String
    Private _Benutzer As Benutzer = Nothing

    ''' <summary>
    ''' Den Bearbeitungs-Dialog aufrufen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="row"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DatenBearbeiten(sender As Object, row As WarmbehandlungRow) As WarmbehandlungRow
        Using Me
            _DataSet = DirectCast(sender, FormParameter).WbaDataSet
            _Benutzer = DirectCast(sender, FormParameter)._BenutzerAngemeldet

            ' Die Daten aus der DataRow in die Maske übernehmen
            DatenInMaske(row)

            ' Den Dialog anzeigen
            Me.ShowDialog()

            ' Die DataRow zurückgeben
            Return _DataRow
        End Using
    End Function

    ''' <summary>
    ''' Das Formular soll geschlossen werden
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
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
    Private Function DatenAusMaske() As WarmbehandlungRow

        Dim locFehler As Boolean

        ' Alle möglichen Vorherigen Fehler zurücksetzen
        Me.ErrProv.Clear()

        ' Wenn keine Eingabe im Feld gemacht wurde,
        If String.IsNullOrEmpty(tbxName.Text) Then
            ErrProv.SetError(tbxName, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        Else
            For Each prgName As String In _Namen

                If prgName.ToUpper = tbxName.Text.ToUpper Then
                    ErrProv.SetError(tbxName, "Name ist schon vergeben!")
                    locFehler = locFehler Or True
                    Exit For
                End If
            Next
        End If

        ' Fehler war vorhanden - Nothing zurückliefern
        If locFehler Then Return Nothing

        ' Alles war OK, es gibt eine neue DataRow.
        Try
            _DataRow = _DataSet.Warmbehandlung.NewWarmbehandlungRow
            _DataRow.Verfahren = 0
            _DataRow.Freigabe = If(Me.cbxFreigabe.Checked, True, False)
            _DataRow.Gesperrt = If(Me.cbxGesperrt.Checked, True, False)
            _DataRow.Name = Me.tbxName.Text.Trim() ' Keine führenden oder nachgestellten Leerzeichen!
            _DataRow.Bemerkung = Me.tbxBemerkung.Text

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
    Private Sub DatenInMaske(ByVal row As WarmbehandlungRow)
        If row.RowState = DataRowState.Detached Then
            Me.Text = "Neuen Parameter Datensatz anlegen"

            Me.cbxFreigabe.Checked = False
            Me.cbxGesperrt.Checked = False
            Me.tbxName.Text = String.Empty
            Me.tbxBemerkung.Text = String.Empty

            ' Alle Parameternamen in ein String-Array
            _Namen = (From wb In _DataSet.Warmbehandlung
                      Select wb.Name).ToArray
        Else
            Me.Text = "Parameter Datensatz bearbeiten"

            Try
                Me.cbxFreigabe.Checked = If(row.IsFreigabeNull, False, row.Freigabe)
                Me.cbxGesperrt.Checked = If(row.IsGesperrtNull, False, row.Gesperrt)
                Me.tbxName.Text = If(row.IsNameNull, String.Empty, row.Name)
                Me.tbxBemerkung.Text = If(row.IsBemerkungNull, String.Empty, row.Bemerkung)

                ' Alle Parameternamen in ein String-Array (ausser dem zu bearbeitenden)
                _Namen = (From wb In _DataSet.Warmbehandlung
                          Where wb.Id <> row.Id
                          Select wb.Name).ToArray
            Catch ex As Exception
                Logging.WriteEntry(ex.Message, TraceEventType.Error)
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Das Formular wird geladen
    ''' Die Checkbox für Freigabe entsprechend aktivieren/deaktivieren
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FormParameterBearbeiten_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.cbxFreigabe.Enabled = (Me._Benutzer.Code.Contains(41) OrElse Me._Benutzer.Administrator)
    End Sub

    ''' <summary>
    ''' Das Formular erhält den Fokus
    ''' Das erste Feld hat den Fokus und der gesamte Inhalt ist markiert
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FormParameterBearbeiten_Activated(sender As System.Object, e As System.EventArgs) Handles MyBase.Activated
        Me.tbxName.Focus()
        Me.tbxName.SelectAll()
    End Sub
End Class