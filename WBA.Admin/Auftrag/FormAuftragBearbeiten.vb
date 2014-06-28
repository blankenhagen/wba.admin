Imports System.Windows.Forms
Imports WBA.Admin.wbadminDataSet

Public Class FormAuftragBearbeiten

    Private _DataSet As wbadminDataSet = Nothing
    Private _AuftragRow As AuftragRow
    Private _Benutzer As Benutzer = Nothing

#Region "....Das Formular soll geschlossen werden"

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

            _AuftragRow = DatenAusMaske()

            If _AuftragRow Is Nothing Then
                e.Cancel = True
            End If
        Else
            _AuftragRow = Nothing
        End If
    End Sub

#End Region

#Region "....Auftrag Neu oder bearbeiten"

    ''' <summary>
    ''' Auftrag Neu oder bearbeiten
    ''' </summary>
    ''' <param name="dataset">das DataSet des aufrufenden Formulars</param>
    ''' <param name="user">der angemeldete Bnutzer </param>
    ''' <param name="row">eine neue oder zu bearbeitende Row des aufrufenden Formulars</param>
    ''' <returns>eine neue Auftrag Row oder Nothing</returns>
    ''' <remarks></remarks>
    Public Function AuftragBearbeiten(dataset As wbadminDataSet, user As Benutzer, row As AuftragRow) As AuftragRow
        Using Me
            _DataSet = dataset
            _Benutzer = user

            ' Die Daten aus der DataRow in die Maske übernehmen
            DatenInMaske(row)

            ' Den Dialog anzeigen
            Me.ShowDialog()

            ' Die DataRow zurückgeben
            Return _AuftragRow
        End Using
    End Function

#End Region

#Region "....Daten aus den TextBoxen lesen"

    ''' <summary>
    ''' Überprüft die Eingaben im Formular
    ''' </summary>
    ''' <returns>eine neue Auftrag Row oder Nothing</returns>
    ''' <remarks></remarks>
    Private Function DatenAusMaske() As AuftragRow

        Dim row As AuftragRow = Nothing
        Dim wert As Long = 0
        Dim locFehler As Boolean

        ' Alle möglichen Vorherigen Fehler zurücksetzen
        Me.ErrProv.Clear()

        If String.IsNullOrEmpty(Me.RUECK_TextBox.Text) Then
            ErrProv.SetError(Me.RUECK_TextBox, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        ElseIf Not OnlyNumbers(Me.RUECK_TextBox.Text) Then
            ErrProv.SetError(Me.RUECK_TextBox, "Nur Ziffern erlaubt!")
            locFehler = locFehler Or True
        End If

        If String.IsNullOrEmpty(Me.AUFNR_TextBox.Text) Then
            ErrProv.SetError(Me.AUFNR_TextBox, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        ElseIf Not OnlyNumbers(Me.AUFNR_TextBox.Text) Then
            ErrProv.SetError(Me.AUFNR_TextBox, "Nur Ziffern erlaubt!")
            locFehler = locFehler Or True
        ElseIf Long.TryParse(Me.AUFNR_TextBox.Text, wert) Then
            If wert <= 10000000 Then
                ErrProv.SetError(Me.AUFNR_TextBox, "Eingabe muss > 10.000.000 sein!")
                locFehler = locFehler Or True
            End If
        End If

        If String.IsNullOrEmpty(Me.IDNR_TextBox.Text) Then
            ErrProv.SetError(Me.IDNR_TextBox, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        ElseIf Not OnlyNumbers(Me.IDNR_TextBox.Text) Then
            ErrProv.SetError(Me.IDNR_TextBox, "Nur Ziffern erlaubt!")
            locFehler = locFehler Or True
        ElseIf Long.TryParse(Me.IDNR_TextBox.Text, wert) Then
            If wert <= 10000000 Then
                ErrProv.SetError(Me.IDNR_TextBox, "Eingabe muss > 10.000.000 sein!")
                locFehler = locFehler Or True
            End If
        End If

        If String.IsNullOrEmpty(Me.AUFLAGE_TextBox.Text) Then
            ErrProv.SetError(Me.AUFLAGE_TextBox, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        ElseIf Not OnlyNumbers(Me.AUFLAGE_TextBox.Text) Then
            ErrProv.SetError(Me.AUFLAGE_TextBox, "Nur Ziffern erlaubt!")
            locFehler = locFehler Or True
        End If

        If String.IsNullOrEmpty(Me.ERGAENZUNG_TextBox.Text) Then
            ErrProv.SetError(Me.ERGAENZUNG_TextBox, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        ElseIf Not OnlyNumbers(Me.ERGAENZUNG_TextBox.Text) Then
            ErrProv.SetError(Me.ERGAENZUNG_TextBox, "Nur Ziffern erlaubt!")
            locFehler = locFehler Or True
        End If

        If String.IsNullOrEmpty(Me.PL_TextBox.Text) Then
            ErrProv.SetError(Me.PL_TextBox, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        ElseIf Not OnlyNumbers(Me.PL_TextBox.Text) Then
            ErrProv.SetError(Me.PL_TextBox, "Nur Ziffern erlaubt!")
            locFehler = locFehler Or True
        End If

        If String.IsNullOrEmpty(Me.GAMNG_TextBox.Text) Then
            ErrProv.SetError(Me.GAMNG_TextBox, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        ElseIf Not OnlyNumbers(Me.GAMNG_TextBox.Text) Then
            ErrProv.SetError(Me.GAMNG_TextBox, "Nur Ziffern erlaubt!")
            locFehler = locFehler Or True
        ElseIf Long.TryParse(Me.GAMNG_TextBox.Text, wert) Then
            If wert <= 0 Then
                ErrProv.SetError(Me.GAMNG_TextBox, "Eingabe muss >= 0 sein!")
                locFehler = locFehler Or True
            End If
        End If

        If String.IsNullOrEmpty(Me.PRUEFLOS_TextBox.Text) Then
            ErrProv.SetError(Me.PRUEFLOS_TextBox, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        ElseIf Not Long.TryParse(Me.PRUEFLOS_TextBox.Text, wert) Then
            ErrProv.SetError(Me.PRUEFLOS_TextBox, "Nur Ziffern erlaubt!")
            locFehler = locFehler Or True
        End If

        If String.IsNullOrEmpty(Me.VORNR_TextBox.Text) Then
            ErrProv.SetError(Me.VORNR_TextBox, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        ElseIf Not OnlyNumbers(Me.VORNR_TextBox.Text) Then
            ErrProv.SetError(Me.VORNR_TextBox, "Nur Ziffern erlaubt!")
            locFehler = locFehler Or True
        End If

        If String.IsNullOrEmpty(Me.ST_TextBox.Text) Then
            ErrProv.SetError(Me.ST_TextBox, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        ElseIf Not OnlyNumbers(Me.ST_TextBox.Text) Then
            ErrProv.SetError(Me.ST_TextBox, "Nur Ziffern erlaubt!")
            locFehler = locFehler Or True
        End If

        ' Fehler war vorhanden - Nothing zurückliefern
        If locFehler Then Return Nothing

        ' Alles war OK, es gibt eine neue DataRow.
        Try
            row = _DataSet.Auftrag.NewAuftragRow

            With row
                .WERKS = Me.WERKS_Label.Text.PadRight(4, " "c)
                .RUECK = Me.RUECK_TextBox.Text.PadLeft(10, "0"c)
                .AUFNR = Me.AUFNR_TextBox.Text.PadLeft(12, "0"c)
                .BENENNUNG = Me.BENENNUNG_TextBox.Text.PadRight(21, " "c)
                .BI = Me.BI_TextBox.Text.PadRight(2, " "c)
                .HTZ = Me.HTZ_TextBox.Text.PadRight(18, " "c)
                .IDNR = Me.IDNR_TextBox.Text.PadLeft(8, "0"c)
                .AUFLAGE = Me.AUFLAGE_TextBox.Text.PadLeft(3, "0"c)
                .ERGAENZUNG = Me.ERGAENZUNG_TextBox.Text.PadLeft(2, "0"c)
                .PL = Me.PL_TextBox.Text.PadLeft(2, "0"c)
                .GAMNG = Me.GAMNG_TextBox.Text.PadLeft(11, "0"c)
                .PRUEFLOS = Me.PRUEFLOS_TextBox.Text.PadLeft(12, "0"c)
                .VORNR = Me.VORNR_TextBox.Text.PadLeft(4, "0"c)
                .ST = Me.ST_TextBox.Text.PadLeft(2, "0"c)
            End With
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.Message)
        End Try

        Return row
    End Function

#End Region

#Region "....TextBoxen mit Daten füllen"

    ''' <summary>
    ''' Lädt die Daten aus der DataRow in die Maske
    ''' Bei neuem Benutzer werden die Felder mit Leerstrings vorbesetzt
    ''' </summary>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Private Sub DatenInMaske(ByVal row As AuftragRow)
        If row.RowState = DataRowState.Detached Then
            Me.Text = "Neuen Auftrag anlegen"

            Me.WERKS_Label.Text = "72"
            Me.RUECK_TextBox.Text = "0000000000"
            Me.AUFNR_TextBox.Text = "000000000000"
            Me.BENENNUNG_TextBox.Text = String.Empty
            Me.BI_TextBox.Text = String.Empty
            Me.HTZ_TextBox.Text = String.Empty
            Me.IDNR_TextBox.Text = "00000000"
            Me.AUFLAGE_TextBox.Text = "000"
            Me.ERGAENZUNG_TextBox.Text = "00"
            Me.PL_TextBox.Text = "00"
            Me.GAMNG_TextBox.Text = "00000000001"
            Me.PRUEFLOS_TextBox.Text = "000000000000"
            Me.VORNR_TextBox.Text = "0000"
            Me.ST_TextBox.Text = "00"
        Else
            Me.Text = "Auftrag bearbeiten"

            '    Try
            '        Me.tbxName.Text = If(row.IsNameNull, String.Empty, row.Name)
            '        Me.tbxVorname.Text = If(row.IsVornameNull, String.Empty, row.Vorname)
            '        Me.tbxAusweisnummer.Text = If(row.IsAusweisNull, String.Empty, row.Ausweis)
            '        Me.tbxENR.Text = If(row.IsENRNull, String.Empty, row.ENR)
            '        Me.tbxSAP.Text = If(row.IsSAPNull, String.Empty, row.SAP)
            '        Me.cbxGesperrt.Checked = If(row.IsGesperrtNull, False, (row.Gesperrt = True))
            '    Catch ex As Exception
            '        Logging.WriteEntry(ex.Message, TraceEventType.Error)
            '        MsgBox(ex.Message)
            '    End Try
        End If

        ' Das erste Feld hat den Fokus und der gesamte Inhalt ist markiert
        Me.RUECK_TextBox.Focus()
        Me.RUECK_TextBox.SelectAll()
    End Sub

#End Region

#Region "....Die TextBox Ereignisse"

    ''' <summary>
    ''' Mit 'Enter' zum nächsten Eingabefeld schalten
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TextBox_PreviewKeyDown(sender As System.Object, e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles VORNR_TextBox.PreviewKeyDown, _
                                                                                                                           ST_TextBox.PreviewKeyDown, _
                                                                                                                           RUECK_TextBox.PreviewKeyDown, _
                                                                                                                           PRUEFLOS_TextBox.PreviewKeyDown, _
                                                                                                                           PL_TextBox.PreviewKeyDown, _
                                                                                                                           IDNR_TextBox.PreviewKeyDown, _
                                                                                                                           HTZ_TextBox.PreviewKeyDown, _
                                                                                                                           GAMNG_TextBox.PreviewKeyDown, _
                                                                                                                           ERGAENZUNG_TextBox.PreviewKeyDown, _
                                                                                                                           BI_TextBox.PreviewKeyDown, _
                                                                                                                           BENENNUNG_TextBox.PreviewKeyDown, _
                                                                                                                           AUFNR_TextBox.PreviewKeyDown, _
                                                                                                                           AUFLAGE_TextBox.PreviewKeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Select Case DirectCast(sender, TextBox).Tag
                    Case "0"
                        Me.AUFNR_TextBox.Focus()
                        Me.AUFNR_TextBox.SelectAll()

                    Case "1"
                        Me.BENENNUNG_TextBox.Focus()
                        Me.BENENNUNG_TextBox.SelectAll()

                    Case "2"
                        Me.BI_TextBox.Focus()
                        Me.BI_TextBox.SelectAll()

                    Case "3"
                        Me.HTZ_TextBox.Focus()
                        Me.HTZ_TextBox.SelectAll()

                    Case "4"
                        Me.IDNR_TextBox.Focus()
                        Me.IDNR_TextBox.SelectAll()

                    Case "5"
                        Me.AUFLAGE_TextBox.Focus()
                        Me.AUFLAGE_TextBox.SelectAll()

                    Case "6"
                        Me.ERGAENZUNG_TextBox.Focus()
                        Me.ERGAENZUNG_TextBox.SelectAll()

                    Case "7"
                        Me.PL_TextBox.Focus()
                        Me.PL_TextBox.SelectAll()

                    Case "8"
                        Me.GAMNG_TextBox.Focus()
                        Me.GAMNG_TextBox.SelectAll()

                    Case "9"
                        Me.PRUEFLOS_TextBox.Focus()
                        Me.PRUEFLOS_TextBox.SelectAll()

                    Case "10"
                        Me.VORNR_TextBox.Focus()
                        Me.VORNR_TextBox.SelectAll()

                    Case "11"
                        Me.ST_TextBox.Focus()
                        Me.ST_TextBox.SelectAll()

                    Case "12"
                        Me.RUECK_TextBox.Focus()
                        Me.RUECK_TextBox.SelectAll()
                End Select
        End Select
    End Sub

#End Region

    ''' <summary>
    ''' Prüft den angegebenen Text, ob dieser nur aus Zahlen besteht
    ''' </summary>
    ''' <param name="Text">String, der gerprüft werden soll.</param>
    ''' <returns>True, wenn der String nur aus Zahlen besteht, andernfalls False.</returns>
    Private Function OnlyNumbers(ByVal Text As String) As Boolean
        If Text.Length = 0 Then Return False
        If Not IsNumeric(Text) Then Return False

        For i As Integer = 0 To Text.Length - 1
            If Not "0123456789".Contains(Text.Chars(i)) Then
                Return False
            End If
        Next

        Return True
    End Function

End Class