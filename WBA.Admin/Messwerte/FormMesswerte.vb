Imports WBA.Admin.wbadminDataSet

Public Class FormMesswerte

    Private _Zone(2) As Integer
    Private _Info(2) As Integer

    Private _DataSet As WBA.Admin.wbadminDataSet = Nothing
    Private _AnlageTableAdapter As WBA.Admin.wbadminDataSetTableAdapters.AnlageTableAdapter = Nothing
    Private _ChargeTableAdapter As WBA.Admin.wbadminDataSetTableAdapters.ChargeTableAdapter = Nothing
    Private _HaltezeitTableAdapter As WBA.Admin.wbadminDataSetTableAdapters.HaltezeitTableAdapter = Nothing
    Private _ReglerMesswertTableAdapter As WBA.Admin.wbadminDataSetTableAdapters.ReglerMesswertTableAdapter = Nothing
    Private _InfoMesswertTableAdapter As WBA.Admin.wbadminDataSetTableAdapters.InfoMesswertTableAdapter = Nothing
    Private _MinimumMesswertTableAdapter As WBA.Admin.wbadminDataSetTableAdapters.MinimumMesswertTableAdapter = Nothing
    Private _MaximumMesswertTableAdapter As WBA.Admin.wbadminDataSetTableAdapters.MaximumMesswertTableAdapter = Nothing
    Private _WasserMesswertTableAdapter As WBA.Admin.wbadminDataSetTableAdapters.WasserMesswertTableAdapter = Nothing

    Private _AnlageBindingSource As System.Windows.Forms.BindingSource = Nothing

#Region "....Das Formular wird geladen"

    ''' <summary>
    ''' Das Formular wird geladen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FormCharge_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Try
            _DataSet = New WBA.Admin.wbadminDataSet
            _DataSet.EnforceConstraints = False

            _AnlageTableAdapter = New WBA.Admin.wbadminDataSetTableAdapters.AnlageTableAdapter
            _ChargeTableAdapter = New WBA.Admin.wbadminDataSetTableAdapters.ChargeTableAdapter
            _HaltezeitTableAdapter = New WBA.Admin.wbadminDataSetTableAdapters.HaltezeitTableAdapter
            _ReglerMesswertTableAdapter = New WBA.Admin.wbadminDataSetTableAdapters.ReglerMesswertTableAdapter
            _InfoMesswertTableAdapter = New WBA.Admin.wbadminDataSetTableAdapters.InfoMesswertTableAdapter
            _MinimumMesswertTableAdapter = New WBA.Admin.wbadminDataSetTableAdapters.MinimumMesswertTableAdapter
            _MaximumMesswertTableAdapter = New WBA.Admin.wbadminDataSetTableAdapters.MaximumMesswertTableAdapter
            _WasserMesswertTableAdapter = New WBA.Admin.wbadminDataSetTableAdapters.WasserMesswertTableAdapter

            ' Die Auswahlliste mit den Anlagen füllen
            _AnlageTableAdapter.Fill(_DataSet.Anlage)

            _AnlageBindingSource = New System.Windows.Forms.BindingSource
            _AnlageBindingSource.DataSource = _DataSet.Anlage

            Me.AnlageComboBox.DataSource = _AnlageBindingSource
            Me.AnlageComboBox.DisplayMember = "Kuerzel"
            Me.AnlageComboBox.ValueMember = "Id"

            ' Hier werden Kennung, Zonen und Info "verhackstückt"
            AddHandler Me.AnlageComboBox.TextChanged, AddressOf Me.AnlageComboBox_TextChanged

            ' Die Komponenten aus den Settings initialisieren
            Me.ExportpfadLabel.Text = My.Settings.Exportpfad
            Me.AnlageComboBox.SelectedValue = My.Settings.Anlage_Id
            Me.DateTimePicker.Value = My.Settings.Chargedatum
            Me.ZaehlzahlTextBox.Text = My.Settings.Zaehlzahl.ToString

            ' Dafür sorgen, dass auf jeden Fall das Änderungsereignis eintritt
            If Me.AnlageComboBox.SelectedValue = 1 Then
                Me.AnlageComboBox_TextChanged(Me.AnlageComboBox, System.EventArgs.Empty)
            End If

            Me.KennzeichenComboBox.SelectedIndex = My.Settings.Kennung
            Me.EnterButton.PerformClick() ' Die Chargennummer aktualisieren

            ' Der Benutzer sollte in Tag übergeben worden sein
            If Me.Tag IsNot Nothing Then
                Me.BenutzerToolStripStatusLabel.Text = DirectCast(Me.Tag, Benutzer).Name
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#Region "....Die Menü Click Ereignisse"

    ''' <summary>
    ''' Der Verzeichnis Button wurde angeklickt
    ''' Verzeichnis für den Export wählen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ChargeVerzeichnisButton_Click(sender As System.Object, e As System.EventArgs) Handles ChargeVerzeichnisButton.Click

        Using fbd As New Windows.Forms.FolderBrowserDialog
            If Me.ExportpfadLabel.Text <> String.Empty Then
                fbd.SelectedPath = Me.ExportpfadLabel.Text
            End If

            fbd.ShowDialog()
            Me.ExportpfadLabel.Text = fbd.SelectedPath
        End Using
    End Sub

    ''' <summary>
    ''' Das Ende MenuItem wurde angeklickt
    ''' Die Werte aus den Komponenten in den Settings speichern
    ''' und den Dialog schließen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EndeMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EndeMenuItem.Click

        Try
            With My.Settings
                .Exportpfad = Me.ExportpfadLabel.Text
                .Anlage_Id = Me.AnlageComboBox.SelectedValue
                .Chargedatum = Me.DateTimePicker.Value
                .Zaehlzahl = CInt(Me.ZaehlzahlTextBox.Text)
                .Kennung = Me.KennzeichenComboBox.SelectedIndex
                .Save()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Close()
        End Try
    End Sub

#End Region

#Region "....Die Button Click Ereignisse"

    ''' <summary>
    ''' Das Export MenuItem wurde angeklickt
    ''' Die Messwerte in CSV Dateien exportieren
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ExportMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExportMenuItem.Click

        Try
            _ChargeTableAdapter.FillByNummer(_DataSet.Charge, Me.NummerLabel.Text)

            If _DataSet.Charge.Count > 0 Then

                Dim pRow As ChargeRow = DirectCast(_DataSet.Charge.Rows(0), ChargeRow)

                _HaltezeitTableAdapter.FillByCharge(_DataSet.Haltezeit, pRow.Id)
                _ReglerMesswertTableAdapter.FillByCharge(_DataSet.ReglerMesswert, pRow.Id)
                _InfoMesswertTableAdapter.FillByCharge(_DataSet.InfoMesswert, pRow.Id)
                _MinimumMesswertTableAdapter.FillByCharge(_DataSet.MinimumMesswert, pRow.Id)
                _MaximumMesswertTableAdapter.FillByCharge(_DataSet.MaximumMesswert, pRow.Id)
                _WasserMesswertTableAdapter.FillByCharge(_DataSet.WasserMesswert, pRow.Id)

                Me.Write_CSV("Regler", Me.Messwerte_To_CSV(DirectCast(_DataSet.ReglerMesswert, DataTable), _Zone(Me.KennzeichenComboBox.SelectedIndex)))

                ' Nur wenn Info Messwerte vorliegen
                If _DataSet.InfoMesswert.Count > 0 Then
                    Me.Write_CSV("Info", Me.Messwerte_To_CSV(DirectCast(_DataSet.InfoMesswert, DataTable), _Info(Me.KennzeichenComboBox.SelectedIndex)))
                End If

                ' Nur wenn Minimumn- und Maximum Messwerte vorliegen
                If _DataSet.MinimumMesswert.Count > 0 AndAlso _DataSet.MaximumMesswert.Count > 0 Then
                    Me.Write_CSV("Minimum", Me.Messwerte_To_CSV(DirectCast(_DataSet.MinimumMesswert, DataTable), _Zone(Me.KennzeichenComboBox.SelectedIndex)))
                    Me.Write_CSV("Maximum", Me.Messwerte_To_CSV(DirectCast(_DataSet.MaximumMesswert, DataTable), _Zone(Me.KennzeichenComboBox.SelectedIndex)))
                End If

                ' Nur wenn Wasser Messwerte vorliegen
                If _DataSet.WasserMesswert.Count > 0 Then
                    Me.Write_CSV("Wasser", Me.Messwerte_To_CSV(DirectCast(_DataSet.WasserMesswert, DataTable), 2))
                End If

                If _DataSet.Haltezeit.Count > 0 Then
                    Me.Write_CSV("Haltezeit", Me.Haltezeit_To_CSV(DirectCast(_DataSet.Haltezeit, DataTable)))
                End If
            Else
                MsgBox("Keine Charge gefunden!")
            End If

            MsgBox("Messwerte wurden exportiert!")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Der Enter Button wurde angeklickt
    ''' Die Chargennummer bilden
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EnterButton_Click(sender As System.Object, e As System.EventArgs) Handles EnterButton.Click

        Try
            Dim result As Integer

            If Integer.TryParse(Me.ZaehlzahlTextBox.Text, result) Then
                Me.NummerLabel.Text = Me.AnlageComboBox.Text & "-" & _
                                      Me.KennzeichenComboBox.SelectedItem & _
                                      Me.DateTimePicker.Value.ToString("yyyyMMdd") & _
                                      String.Format("{0:D3}", CInt(Me.ZaehlzahlTextBox.Text))
            Else
                MsgBox("Unzulässige Eingabe bei der Zählzahl!")
                Me.ZaehlzahlTextBox.Text = String.Empty
                Me.ZaehlzahlTextBox.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#Region "....Die ComboBox Ereignisse"

    ''' <summary>
    ''' Die Auswahl in der Anlage ComboBox hat sich geändert
    ''' Die Kennzeichen ComboBox entsprechend füllen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AnlageComboBox_TextChanged(sender As System.Object, e As System.EventArgs)

        Try
            Dim CB As ComboBox = DirectCast(sender, ComboBox)
            Dim pRow As AnlageRow = DirectCast(DirectCast(CB.SelectedItem, DataRowView).Row, AnlageRow)

            Dim kennung() As String = Split(pRow.Kennzeichen, ";")
            Dim zone() As String = Split(pRow.Regelzonen, ";")
            Dim info() As String = Split(pRow.Infosensoren, ";")

            Me.KennzeichenComboBox.Items.Clear()

            For Each k In kennung
                Me.KennzeichenComboBox.Items.Add(k)
            Next

            Me.KennzeichenComboBox.SelectedIndex = 0

            Dim i As Integer = 0
            Dim j As Integer = 0

            If zone.Length > 0 AndAlso info.Length > 0 Then

                Array.Clear(_Zone, 0, 3)

                For Each z In zone
                    Integer.TryParse(z, _Zone(i))
                    i += 1
                Next

                Array.Clear(_Info, 0, 3)

                For Each inf In info
                    Integer.TryParse(inf, _Info(j))
                    j += 1
                Next
            End If

            Trace.WriteLine(pRow.Kuerzel)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#Region "....Die CSV Dateien"

    ''' <summary>
    ''' Die CSV-Datei schreiben
    ''' Es wird ein Verzeichnis unter dem Namen der Chargennummer angelegt
    ''' Darunter werden die einzelnen Messwertdateien abgelegt
    ''' </summary>
    ''' <param name="dateiname">Der Name der entsprechenden Messwertdatei</param>
    ''' <param name="content">Der Inhalt der Datei im CSV-Format</param>
    ''' <remarks></remarks>
    Private Sub Write_CSV(dateiname As String, content As String)

        Dim verzeichnis As String = String.Empty
        Dim datei As IO.StreamWriter = Nothing

        Try
            verzeichnis = Me.ExportpfadLabel.Text & "\" & Me.NummerLabel.Text

            If Not System.IO.Directory.Exists(verzeichnis) Then
                System.IO.Directory.CreateDirectory(verzeichnis)
            End If

            datei = New IO.StreamWriter(verzeichnis & "\" & dateiname & ".csv")

            datei.Write(content)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            datei.Close()
        End Try
    End Sub


    ''' <summary>
    ''' Die Messwerte in CSV wandeln
    ''' Als Separator wird ";" verwendet, Zeilenende = CR
    ''' </summary>
    ''' <param name="DT">Die DataTable</param>
    ''' <param name="count">Die Anzahl der Messwerte</param>
    ''' <returns>Den CSV-String</returns>
    ''' <remarks></remarks>
    Private Function Messwerte_To_CSV(DT As DataTable, count As Integer)

        Dim result As String = String.Empty
        Dim zeile As String = String.Empty
        Dim DR As DataRow
        Dim DC As DataColumn

        ' Spaltenüberschriften
        Dim i As Integer = 0
        For Each DC In DT.Columns
            ' Id, Minimum, Maximum und Charge_Id auslassen und nur die Werte der verwendeten Messtellen
            If i = 1 OrElse i = 2 OrElse (i >= 5 AndAlso (i <= (5 + (count - 1)))) Then
                zeile += If(zeile <> String.Empty, ";", String.Empty).ToString
                zeile += DC.ColumnName
            End If

            i += 1
        Next

        result += zeile & Chr(13)

        ' Ausgabe aller Zeilen
        For Each DR In DT.Rows
            zeile = String.Empty

            ' Schleife über alle Spalten
            i = 0
            For Each DC In DT.Columns
                ' Id, Minimum, Maximum und Charge_Id auslassen und nur die Werte der verwendeten Messtellen
                If i = 1 OrElse i = 2 OrElse (i >= 5 AndAlso (i <= (5 + (count - 1)))) Then
                    zeile += If(zeile <> String.Empty, ";", String.Empty).ToString
                    zeile += DR.Item(DC.ColumnName).ToString
                End If

                i += 1
            Next

            result += zeile & Chr(13)
        Next

        Return result
    End Function

    ''' <summary>
    ''' Die Haltezeiten in CSV wandeln
    ''' Als Separator wird ";" verwendet, Zeilenende = CR
    ''' </summary>
    ''' <param name="DT">Die DataTable</param>
    ''' <returns>Den CSV-String</returns>
    ''' <remarks></remarks>
    Private Function Haltezeit_To_CSV(DT As DataTable)

        Dim result As String = String.Empty
        Dim zeile As String = String.Empty
        Dim DR As DataRow
        Dim DC As DataColumn

        ' Spaltenüberschriften
        Dim i As Integer = 0
        For Each DC In DT.Columns
            ' Id und Charge_Id auslassen
            If i > 0 AndAlso i < 6 Then
                zeile += If(zeile <> String.Empty, ";", String.Empty).ToString
                zeile += DC.ColumnName
            End If

            i += 1
        Next

        result += zeile & Chr(13)

        ' Ausgabe aller Zeilen
        For Each DR In DT.Rows
            zeile = String.Empty

            ' Schleife über alle Spalten
            i = 0
            For Each DC In DT.Columns
                ' Id und Charge_Id auslassen
                If i > 0 AndAlso i < 6 Then
                    zeile += If(zeile <> String.Empty, ";", String.Empty).ToString
                    zeile += DR.Item(DC.ColumnName).ToString
                End If

                i += 1
            Next

            result += zeile & Chr(13)
        Next

        Return result
    End Function

#End Region

End Class