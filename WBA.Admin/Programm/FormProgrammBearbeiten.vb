Imports System.Windows.Forms
Imports WBA.Admin.wbadminDataSet

Public Class FormProgrammBearbeiten
    ' Hier steht das Ergebnis der Funktion "DatenBearbeiten"
    Private _DataRow As WarmbehandlungRow
    Private _DataSet As wbadminDataSet
    Private _Namen() As String
    Private _Benutzer As Benutzer = Nothing
    Friend _FormProgramm As FormProgramm = Nothing

#Region "....Den Bearbeitungs Dialog aufrufen"

    ''' <summary>
    ''' Den Bearbeitungs-Dialog aufrufen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="row"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DatenBearbeiten(sender As Object, row As WarmbehandlungRow) As WarmbehandlungRow
        Using Me
            _FormProgramm = DirectCast(sender, FormProgramm)
            _DataSet = _FormProgramm.WbaDataSet
            _Benutzer = _FormProgramm.BenutzerAngemeldet

            Me.ReleaseAndLock.Anlage = _DataSet.Anlage

            Me.ReleaseAndLock.CanRelease = (_Benutzer.Code.Contains(41) OrElse _
                                            _Benutzer.Administrator)

            Me.ReleaseAndLock.CanLock = (_Benutzer.Code.Contains(40) OrElse _
                                         _Benutzer.Code.Contains(41) OrElse _
                                         _Benutzer.Administrator)

            ' Bei neuem Programm die Bearbeitung der Abschnitte unterbinden
            Me.AbschnitteButton.Enabled = Not (row.RowState = DataRowState.Detached)

            ' Die Daten aus der DataRow in die Maske übernehmen
            DatenInMaske(row)

            ' Den Dialog anzeigen
            Me.ShowDialog()

            ' Die DataRow zurückgeben
            Return _DataRow
        End Using
    End Function

#End Region

#Region "....Das Formular soll geschlossen werden"

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

#End Region

#Region "....Die Daten aus der Maske lesen"

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
        If String.IsNullOrEmpty(NameTextBox.Text) Then
            ErrProv.SetError(NameTextBox, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        Else
            If NameTextBox.Text.Length <= 10 Then
                For Each prgName As String In _Namen

                    If prgName.ToUpper = NameTextBox.Text.ToUpper Then
                        ErrProv.SetError(NameTextBox, "Name ist schon vergeben!")
                        locFehler = locFehler Or True
                        Exit For
                    End If
                Next
            Else
                ErrProv.SetError(NameTextBox, "Name darf max. 10 Zeichen lang sein!")
                locFehler = locFehler Or True
            End If
        End If

        ' Fehler war vorhanden - Nothing zurückliefern
        If locFehler Then Return Nothing

        ' Alles war OK, es gibt eine neue DataRow.
        Try
            _DataRow = _DataSet.Warmbehandlung.NewWarmbehandlungRow
            _DataRow.Verfahren = Me.VerfahrenComboBox.SelectedIndex + 1
            _DataRow.Freigabe = Me.ReleaseAndLock.Release
            _DataRow.Gesperrt = Me.ReleaseAndLock.Lock
            _DataRow.Name = Me.NameTextBox.Text.Trim() ' Keine führenden oder nachgestellten Leerzeichen!
            _DataRow.Bemerkung = Me.BemerkungTextBox.Text

            ' Die übrigen Spalten werden an anderer Stelle editiert
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.Message)
        End Try

        Return _DataRow
    End Function

#End Region

#Region "....Die Daten in die Maske schreiben"

    ''' <summary>
    ''' Lädt die Daten aus der DataRow in die Maske
    ''' Bei neuem Programm werden die Felder mit Leerstrings vorbesetzt
    ''' </summary>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Private Sub DatenInMaske(ByVal row As WarmbehandlungRow)
        If row.RowState = DataRowState.Detached Then
            Me.Text = "Neues Programm anlegen"

            'Me.VerfahrenComboBox.Enabled = True
            Me.VerfahrenComboBox.Text = Me.VerfahrenComboBox.Items(0)
            Me.NameTextBox.Text = String.Empty
            Me.BemerkungTextBox.Text = String.Empty

            row.Gesperrt = 0
            row.Freigabe = 0

            ' Programm für alle Anlagen sperren
            For i As Integer = 0 To Me.ReleaseAndLock.MaxOfen - 1
                Tools.SetBit(row.Gesperrt, DirectCast(Me.ReleaseAndLock.Sperre(i).Tag, AnlageObjekt).Bit)
                Me.ReleaseAndLock.Sperre(i).Enabled = False
                Me.ReleaseAndLock.Freigabe(i).Enabled = False
            Next

            Me.ReleaseAndLock.Release = row.Freigabe
            Me.ReleaseAndLock.Lock = row.Gesperrt

            'Me.ReleaseAndLock.Visible = False

            ' Alle Programmnamen in ein String-Array
            _Namen = (From wb In _DataSet.Warmbehandlung
                      Select wb.Name).ToArray
        Else
            Me.Text = "Programm bearbeiten"

            Try
                Me.VerfahrenComboBox.Text = Me.VerfahrenComboBox.Items(row.Verfahren - 1)
                Me.VerfahrenComboBox.Visible = False
                Me.VerfahrenLabel.Size = Me.VerfahrenComboBox.Size
                Me.VerfahrenLabel.Location = Me.VerfahrenComboBox.Location
                Me.VerfahrenLabel.Text = Me.VerfahrenComboBox.Text
                Me.VerfahrenLabel.Visible = True

                Me.NameTextBox.Text = If(row.IsNameNull, String.Empty, row.Name)
                Me.BemerkungTextBox.Text = If(row.IsBemerkungNull, String.Empty, row.Bemerkung)
                Me.ReleaseAndLock.Release = If(row.IsFreigabeNull, 0, row.Freigabe)
                Me.ReleaseAndLock.Lock = If(row.IsGesperrtNull, 0, row.Gesperrt)
                Me.ReleaseAndLock.Verfahren = If(row.IsVerfahrenNull, 0, row.Verfahren)

                Me.NameTextBox.Enabled = (row.Freigabe = 0)

                ' Alle Programmnamen in ein String-Array (ausser dem zu bearbeitenden)
                _Namen = (From wb In _DataSet.Warmbehandlung
                          Where wb.Id <> row.Id
                          Select wb.Name).ToArray
            Catch ex As Exception
                Logging.WriteEntry(ex.Message, TraceEventType.Error)
                MsgBox(ex.Message)
            End Try
        End If

        ' Das erste Feld hat den Fokus und der gesamte Inhalt ist markiert
        Me.NameTextBox.Focus()
        Me.NameTextBox.SelectAll()
    End Sub

#End Region

#Region "....Das Formular wird geladen"

    ''' <summary>
    ''' Das Formular wird geladen
    ''' Die Checkboxen für Freigabe und Gesperrt entsprechend aktivieren/deaktivieren
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FormProgrammBearbeiten_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'Me.ReleaseAndLock.Anlage = _DataSet.Anlage

        'Me.ReleaseAndLock.CanRelease = (Me._Benutzer.Code.Contains(41) OrElse _
        '                                Me._Benutzer.Administrator)

        'Me.ReleaseAndLock.CanLock = (Me._Benutzer.Code.Contains(40) OrElse _
        '                             Me._Benutzer.Code.Contains(41) OrElse _
        '                             Me._Benutzer.Administrator)


    End Sub

#End Region

#Region "....Den Bearbeitungs Dialog für die Abschnitte aufrufen"


    ''' <summary>
    ''' Die Abschnitte des aktuell gewählten Programms bearbeiten
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AbschnitteButton_Click(sender As System.Object, e As System.EventArgs) Handles AbschnitteButton.Click
        Using ab As New FormProgrammAbschnittBearbeiten

            ' Die aktuellen Werte des Programms zwischenspeichern
            'Dim dtOld As DataTable = Me.WbData.Programm.CopyToDataTable
            Dim ta As wbadminDataSetTableAdapters.ProgrammTableAdapter = New wbadminDataSetTableAdapters.ProgrammTableAdapter
            Dim dtOld As ProgrammDataTable = ta.GetDataByWarmbehandlung(_FormProgramm.Warmbehandlung_Id)

            ' Den Dialog positionieren
            ab.Location = New Point With {.X = Me.Left + Me.Width + 5, .Y = Me.Top - 5}

            ' Der Dialog wurde über "Ende" verlassen
            If ab.ShowDialog(FormProgramm.WbaDataSet, _FormProgramm.ProgrammBindingSource) = System.Windows.Forms.DialogResult.OK Then
                Dim drv As DataRowView = CType(_FormProgramm.WarmbehandlungBindingSource.Current, DataRowView)
                Dim wbRow As WarmbehandlungRow = CType(drv.Row, WarmbehandlungRow)
                Dim dtNeu As DataTable = Nothing

                ' Die geänderten Zeilen holen
                dtNeu = _DataSet.Programm.GetChanges(DataRowState.Modified)

                ' Die Gesamtlaufzeit aller Abschnitte bestimmen
                Dim prgQuery = From prg In _DataSet.Programm
                               Where prg.Warmbehandlung_Id = wbRow.Id
                               Select prg

                Dim laufzeit = Aggregate p In prgQuery
                               Into Summe = Sum(p.Dauer)

                ' Hat sich diese geändert, dann in Warmbehandlung aktualisieren
                If wbRow.Laufzeit <> laufzeit Then
                    wbRow.BeginEdit()
                    wbRow.Laufzeit = laufzeit
                    wbRow.EndEdit()
                    _FormProgramm.UpdateAction(wbRow.Id, True)
                End If

                ' Wurden Zeilen geändert, dann...
                If dtNeu IsNot Nothing Then
                    ' ...diese speichern
                    _FormProgramm.ProgrammBindingSource.EndEdit()
                    If _FormProgramm.SaveData(_FormProgramm.ProgrammBindingSource) > 0 Then
                        ' Nur ausführen, wenn die Laufzeit > 0 ist
                        ' verhindert die Prüfung auf Änderung bei neuem Programm
                        If wbRow.Laufzeit > 0 Then
                            Try
                                ' Über alle geänderten Zeilen iterieren
                                For Each row As DataRow In dtNeu.Rows
                                    Dim neu As ProgrammRow = DirectCast(row, ProgrammRow)
                                    Dim query As DataRow = (From old In dtOld.Rows _
                                                            Where old(0) = neu.Id _
                                                            Select old).Single

                                    ' Wurde der Sollwert geändert, dann die Historie schreiben
                                    If query(2) <> neu.Sollwert Then
                                        Dim entry As String = String.Format("{0} {1} hat ""Sollwert"" für Abschnitt {2:D} von '{3:D}' nach '{4:D}' geändert{5}",
                                                                            Now.ToString,
                                                                            _Benutzer.Name,
                                                                            neu.Abschnitt,
                                                                            query(2),
                                                                            neu.Sollwert,
                                                                            ControlChars.CrLf)
                                        _FormProgramm.QueriesTableAdapter.spWarmbehandlungAppendHistory(neu.Warmbehandlung_Id, entry)
                                    End If

                                    ' Wurde die Dauer geändert, dann die Historie schreiben
                                    If query(3) <> neu.Dauer Then
                                        Dim newDauer As String = String.Format("{0}.{1:D2}:{2:D2}", neu.Dauer \ 1440, _
                                                                                                    (neu.Dauer Mod 1440) \ 60, _
                                                                                                    ((neu.Dauer Mod 1440) Mod 60) Mod 60)
                                        Dim oldDauer As String = String.Format("{0}.{1:D2}:{2:D2}", query(3) \ 1440, _
                                                                                                    (query(3) Mod 1440) \ 60, _
                                                                                                    ((query(3) Mod 1440) Mod 60) Mod 60)

                                        Dim entry As String = String.Format("{0} {1} hat ""Dauer"" für Abschnitt {2:D} von '{3}' nach '{4}' geändert{5}", _
                                                                            Now.ToString, _
                                                                            _Benutzer.Name, _
                                                                            neu.Abschnitt, _
                                                                            oldDauer, _
                                                                            newDauer, _
                                                                            ControlChars.CrLf)
                                        _FormProgramm.QueriesTableAdapter.spWarmbehandlungAppendHistory(neu.Warmbehandlung_Id, entry)
                                    End If
                                Next
                            Catch ex As Exception
                                Logging.WriteEntry(ex.Message, TraceEventType.Error)
                                MsgBox(ex.Message)
                            End Try
                        End If
                    End If
                End If
            End If
        End Using
    End Sub

#End Region

End Class

