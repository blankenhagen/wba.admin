Imports System.Windows.Forms
Imports WBA.Admin.wbadminDataSet

Public Class FormBauteilBearbeiten
    Private BauteilDataRow As BauteilRow
    Private WbData As wbadminDataSet

    ''' <summary>
    ''' Den Bearbeitungs-Dialog aufrufen
    ''' </summary>
    ''' <param name="dataSet"></param>
    ''' <param name="row"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DatenBearbeiten(ByVal dataSet As wbadminDataSet, ByVal row As BauteilRow) As BauteilRow
        Using Me
            Me.WbData = dataSet

            ' Die Daten aus der DataRow in die Maske übernehmen
            Me.DatenInMaske(row)

            ' Den Dialog anzeigen
            Me.ShowDialog()

            ' Die DataRow zurückgeben
            Return Me.BauteilDataRow
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
            Me.BauteilDataRow = Me.DatenAusMaske()

            ' Wenn _BenutzerRow also Nothing und damit NICHT in Ordnung war, ...
            If Me.BauteilDataRow Is Nothing Then

                ' ... bleibt der Dialog, der ja eigentlich geschlossen werden soll,
                ' offen - und das erreichen wir durch Setzen von
                e.Cancel = True
            End If
        Else
            ' Diese Zeile kann nur erreicht werden, wenn Abbrechen
            ' ausgelöst wurde. Dann wird auf jeden Fall Nothing als
            ' Funktionsergebnis zurückgegeben.
            Me.BauteilDataRow = Nothing
        End If
    End Sub

    ''' <summary>
    ''' Überprüft die Eingaben im Formular, und liefert im Erfolgsfall
    ''' ein fix-und-fertiges DataRow-Objekt aus den Eingabefeldern zurück.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function DatenAusMaske() As BauteilRow

        Dim locFehler As Boolean

        ' Alle möglichen Vorherigen Fehler zurücksetzen
        Me.ErrProv.Clear()

        ' Wenn keine Eingabe im Feld gemacht wurde,
        If String.IsNullOrEmpty(Me.tbxHTZ.Text) Then
            Me.ErrProv.SetError(Me.tbxHTZ, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        ElseIf Me.tbxHTZ.Text.Length > 18 Then
            Me.ErrProv.SetError(Me.tbxHTZ, "Es sind nur 18 Stellen erlaubt!")
            locFehler = locFehler Or True
        End If

        If String.IsNullOrEmpty(Me.tbxIDNR.Text) Then
            Me.ErrProv.SetError(Me.tbxIDNR, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        ElseIf Me.tbxIDNR.Text.Length > 8 Then
            Me.ErrProv.SetError(Me.tbxIDNR, "Es sind nur 8 Stellen erlaubt!")
            locFehler = locFehler Or True
        End If

        If String.IsNullOrEmpty(Me.tbxPL.Text) Then
            Me.ErrProv.SetError(Me.tbxPL, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        ElseIf Me.tbxPL.Text.Length > 2 Then
            Me.ErrProv.SetError(Me.tbxPL, "Es sind nur 2 Stellen erlaubt!")
            locFehler = locFehler Or True
        End If

        ' Fehler war vorhanden - Nothing zurückliefern
        If locFehler Then Return Nothing

        ' Alles war OK, es gibt eine neue DataRow
        Try
            Me.BauteilDataRow = Me.WbData.Bauteil.NewBauteilRow
            Me.BauteilDataRow.HTZ = Me.tbxHTZ.Text
            Me.BauteilDataRow.IDNR = Me.tbxIDNR.Text
            Me.BauteilDataRow.PL = Me.tbxPL.Text

            ' Die übrigen Spalten werden an anderer Stelle editiert
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return Me.BauteilDataRow
    End Function

    ''' <summary>
    ''' Lädt die Daten aus der DataRow in die Maske
    ''' Bei neuem Bauteil werden die Felder mit Leerstrings vorbesetzt
    ''' </summary>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Private Sub DatenInMaske(ByVal row As BauteilRow)
        If row.RowState = DataRowState.Detached Then
            Me.Text = "Neues Bauteil anlegen"

            Me.tbxHTZ.Text = String.Empty
            Me.tbxIDNR.Text = String.Empty
            Me.tbxPL.Text = String.Empty
        Else
            Me.Text = "Bauteil bearbeiten"

            Try
                Me.tbxHTZ.Text = If(row.IsHTZNull, String.Empty, row.HTZ)
                Me.tbxIDNR.Text = If(row.IsIDNRNull, String.Empty, row.IDNR)
                Me.tbxPL.Text = If(row.IsPLNull, String.Empty, row.PL)
            Catch ex As Exception
                Logging.WriteEntry(ex.Message, TraceEventType.Error)
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub FormBauteilBearbeiten_Activated(sender As System.Object, e As System.EventArgs) Handles MyBase.Activated
        ' Das erste Feld hat den Fokus. Der gesamte Inhalt wird in "OnEnter" markiert
        Me.tbxHTZ.Focus()
    End Sub

    Private Sub TextBox_Enter(sender As System.Object, e As System.EventArgs) Handles tbxPL.Enter, tbxIDNR.Enter, tbxHTZ.Enter
        ' Der Delegat wird asynchron aufgerufen und diese Methode unmittelbar danach beendet
        BeginInvoke(DirectCast(Sub() DirectCast(sender, TextBox).SelectAll(), Action))
    End Sub
End Class