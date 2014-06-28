Imports System.Windows.Forms
Imports WBA.Admin.wbadminDataSet

Public Class FormBenutzerBearbeiten

    Private _DataSet As wbadminDataSet = Nothing
    Private _DataRow As BenutzerRow = Nothing
    Private _Benutzer As Benutzer = Nothing

    ''' <summary>
    ''' Benutzer Neu oder bearbeiten
    ''' </summary>
    ''' <param name="row"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DatenBearbeiten(dataset As wbadminDataSet, user As Benutzer, row As BenutzerRow) As BenutzerRow
        Using Me
            _DataSet = dataset
            _Benutzer = user

            ' Die Daten aus der DataRow in die Maske übernehmen
            DatenInMaske(row)

            ' Den Dialog anzeigen
            Me.ShowDialog()

            ' Die DataRow zurückgeben
            Return _DataRow
        End Using
    End Function

    ''' <summary>
    ''' Das Formular wird geladen
    ''' Benutzer sperren/entsperren nur mit der entsprechenden Berechtigung
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FormBenutzerBearbeiten_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.cbxGesperrt.Enabled = (Me._Benutzer.Code.Contains(71) OrElse Me._Benutzer.Administrator)
    End Sub

    ''' <summary>
    ''' Überschriebene Methode "OnClosing"
    ''' Wird aufgerufen, wenn das Formular geschlossen werden soll.
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
    Private Function DatenAusMaske() As BenutzerRow

        Dim locFehler As Boolean

        ' Alle möglichen Vorherigen Fehler zurücksetzen
        Me.ErrProv.Clear()

        ' Wenn keine Eingabe im Feld gemacht wurde,
        If String.IsNullOrEmpty(tbxName.Text) Then
            ErrProv.SetError(tbxName, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        End If

        If String.IsNullOrEmpty(tbxVorname.Text) Then
            ErrProv.SetError(tbxVorname, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        End If

        If String.IsNullOrEmpty(tbxAusweisnummer.Text) Then
            ErrProv.SetError(tbxAusweisnummer, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        End If

        If String.IsNullOrEmpty(tbxENR.Text) Then
            ErrProv.SetError(tbxENR, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        End If

        If String.IsNullOrEmpty(tbxSAP.Text) Then
            ErrProv.SetError(tbxSAP, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        End If

        ' Fehler war vorhanden - Nothing zurückliefern
        If locFehler Then Return Nothing

        ' Alles war OK, es gibt eine neue DataRow.
        Try
            _DataRow = _DataSet.Benutzer.NewBenutzerRow
            _DataRow.Name = Me.tbxName.Text
            _DataRow.Vorname = Me.tbxVorname.Text
            _DataRow.Ausweis = Me.tbxAusweisnummer.Text
            _DataRow.ENR = Me.tbxENR.Text
            _DataRow.SAP = Me.tbxSAP.Text
            _DataRow.Gesperrt = If(Me.cbxGesperrt.Checked, True, False)
            ' Die übrigen Spalten werden an anderer Stelle editiert
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.Message)
        End Try

        Return _DataRow
    End Function

    ''' <summary>
    ''' Lädt die Daten aus der DataRow in die Maske
    ''' Bei neuem Benutzer werden die Felder mit Leerstrings vorbesetzt
    ''' </summary>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Private Sub DatenInMaske(ByVal row As BenutzerRow)
        If row.RowState = DataRowState.Detached Then
            Me.Text = "Neuen Benutzer hinzufügen"

            Me.tbxName.Text = String.Empty
            Me.tbxVorname.Text = String.Empty
            Me.tbxAusweisnummer.Text = String.Empty
            Me.tbxENR.Text = String.Empty
            Me.tbxSAP.Text = String.Empty
            Me.cbxGesperrt.Checked = False
        Else
            Me.Text = "Benutzer bearbeiten"

            Try
                Me.tbxName.Text = If(row.IsNameNull, String.Empty, row.Name)
                Me.tbxVorname.Text = If(row.IsVornameNull, String.Empty, row.Vorname)
                Me.tbxAusweisnummer.Text = If(row.IsAusweisNull, String.Empty, row.Ausweis)
                Me.tbxENR.Text = If(row.IsENRNull, String.Empty, row.ENR)
                Me.tbxSAP.Text = If(row.IsSAPNull, String.Empty, row.SAP)
                Me.cbxGesperrt.Checked = If(row.IsGesperrtNull, False, (row.Gesperrt = True))
            Catch ex As Exception
                Logging.WriteEntry(ex.Message, TraceEventType.Error)
                MsgBox(ex.Message)
            End Try
        End If

        ' Das erste Feld hat den Fokus und der gesamte Inhalt ist markiert
        Me.tbxName.Focus()
        Me.tbxName.SelectAll()
    End Sub

End Class