Imports WBA.Admin.wbadminDataSet

Public Class FormBauteil
    ' Enthält die Id des aktuell selektierten Bauteils
    Private _Bauteil_Id As Integer = 0
    ' Enthält die Id der aktuell selektierten WB-Vorschrift des aktuell selektierten Bauteils
    Private _Warmbehandlung_Id As Integer = 0
    ' Enthält den entsprechenden Datensatz aus der Verknüpfungstabelle
    Private _CurrentBauteilWarmbehandlungRow As BauteilWarmbehandlungRow = Nothing
    ' Enthält den angemeldeten Benutzer
    Private _BenutzerAngemeldet As Benutzer = Nothing

    ' Das DataSet
    Friend WbaDataSet As WBA.Admin.wbadminDataSet = Nothing

    ' Die TableAdapter
    Private BauteilTableAdapter As WBA.Admin.wbadminDataSetTableAdapters.BauteilTableAdapter = Nothing
    Private BauteilWarmbehandlungTableAdapter As WBA.Admin.wbadminDataSetTableAdapters.BauteilWarmbehandlungTableAdapter = Nothing
    Private WarmbehandlungTableAdapter As WBA.Admin.wbadminDataSetTableAdapters.WarmbehandlungTableAdapter = Nothing
    Private BenutzerTableAdapter As WBA.Admin.wbadminDataSetTableAdapters.BenutzerTableAdapter = Nothing
    Private TableAdapterManager As WBA.Admin.wbadminDataSetTableAdapters.TableAdapterManager = Nothing
    Private QueriesTableAdapter As WBA.Admin.wbadminDataSetTableAdapters.QueriesTableAdapter = Nothing

    ' Die BindingSources
    Private BauteilBindingSource As System.Windows.Forms.BindingSource = Nothing
    Private BauteilWarmbehandlungBindingSource As System.Windows.Forms.BindingSource = Nothing
    Private QueriesBindingSource As System.Windows.Forms.BindingSource = Nothing

#Region ".....Das Formular wird geladen"

    ''' <summary>
    ''' Das Formular wird geladen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FormBauteil_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.WbaDataSet = New WBA.Admin.wbadminDataSet()

            Me.BauteilTableAdapter = New WBA.Admin.wbadminDataSetTableAdapters.BauteilTableAdapter()
            Me.BauteilWarmbehandlungTableAdapter = New WBA.Admin.wbadminDataSetTableAdapters.BauteilWarmbehandlungTableAdapter()
            Me.WarmbehandlungTableAdapter = New WBA.Admin.wbadminDataSetTableAdapters.WarmbehandlungTableAdapter()
            Me.BenutzerTableAdapter = New WBA.Admin.wbadminDataSetTableAdapters.BenutzerTableAdapter()
            Me.TableAdapterManager = New WBA.Admin.wbadminDataSetTableAdapters.TableAdapterManager()
            Me.QueriesTableAdapter = New WBA.Admin.wbadminDataSetTableAdapters.QueriesTableAdapter()

            Me.TableAdapterManager.AnlageTableAdapter = Nothing
            Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
            Me.TableAdapterManager.BauteilTableAdapter = Me.BauteilTableAdapter
            Me.TableAdapterManager.BauteilWarmbehandlungTableAdapter = Me.BauteilWarmbehandlungTableAdapter
            Me.TableAdapterManager.BenutzerAnlageTableAdapter = Nothing
            Me.TableAdapterManager.BenutzerRolleTableAdapter = Nothing
            Me.TableAdapterManager.BenutzerTableAdapter = Me.BenutzerTableAdapter
            Me.TableAdapterManager.ParameterTableAdapter = Nothing
            Me.TableAdapterManager.ProgrammTableAdapter = Nothing
            Me.TableAdapterManager.RolleTableAdapter = Nothing
            Me.TableAdapterManager.WarmbehandlungTableAdapter = Me.WarmbehandlungTableAdapter

            Me.BauteilBindingSource = New System.Windows.Forms.BindingSource(Me.WbaDataSet, "Bauteil")
            Me.BauteilWarmbehandlungBindingSource = New System.Windows.Forms.BindingSource(BauteilBindingSource, "FK_BauteilWarmbehandlung_Bauteil")
            Me.QueriesBindingSource = New System.Windows.Forms.BindingSource(Me.components)

            Me.WbaDataSet.EnforceConstraints = False
            Me.BauteilTableAdapter.Fill(Me.WbaDataSet.Bauteil)
            Me.BauteilWarmbehandlungTableAdapter.Fill(Me.WbaDataSet.BauteilWarmbehandlung)
            Me.WarmbehandlungTableAdapter.Fill(Me.WbaDataSet.Warmbehandlung)
            Me.BenutzerTableAdapter.Fill(Me.WbaDataSet.Benutzer)

            Me.CreateBindingHandler(BauteilBindingSource)
            Me.RefreshWarmbehandlung()

            Me.FilterComboBox.Text = Me.FilterComboBox.Items(1) ' Filter "IDNR" ist vorgewählt

            Me.BauteileToolStripStatusLabel.Text = Me.WbaDataSet.Bauteil.Count.ToString

            With Me.BauteilDataGridView
                .DataSource = Me.BauteilBindingSource
                .Columns(0).Visible = False
                .Columns(1).Width = 120
                .Columns(2).Width = 60
                .Columns(3).Width = 30
            End With
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.ToString)
        End Try
    End Sub
#End Region

#Region ".....Überladene Version von ShowDialog"

    ''' <summary>
    ''' Überladen für die Parameterübergabe
    ''' </summary>
    ''' <param name="user">Angemeldeter Benutzer</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function ShowDialog(ByVal user As Benutzer) As System.Windows.Forms.DialogResult
        _BenutzerAngemeldet = user
        Me.BenutzerToolStripStatusLabel.Text = _BenutzerAngemeldet.Name
        Return (MyBase.ShowDialog())
    End Function
#End Region

#Region ".....Die Menü Click Ereignisse"

    ''' <summary>
    ''' Den Bauteil-Dialog schliessen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Ende_Click(sender As System.Object, e As System.EventArgs) Handles EndeMenuItem.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Neues Bauteil anlegen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BauteilNew_Click(sender As System.Object, e As System.EventArgs) Handles BauteilNew.Click
        Me.NeuesBauteil()
        Me.BauteileToolStripStatusLabel.Text = Me.WbaDataSet.Bauteil.Count.ToString
    End Sub

    ''' <summary>
    ''' Selektiertes Bauteil bearbeiten
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BauteilEdit_Click(sender As System.Object, e As System.EventArgs) Handles BauteilEdit.Click
        If Me.WbaDataSet.Bauteil.Count > 0 Then
            Me.BauteilBearbeiten()
        End If
    End Sub

    ''' <summary>
    ''' Selektiertes Bauteil löschen
    ''' Löschen nur möglich, wenn das Bauteil keine Verknüpfungen mit Vorschriften hat
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BauteilDelete_Click(sender As System.Object, e As System.EventArgs) Handles BauteilDelete.Click
        If Me.WbaDataSet.Bauteil.Count > 0 Then
            Dim drv As DataRowView = DirectCast(Me.BauteilBindingSource.Current, DataRowView)
            Dim row As BauteilRow = DirectCast(drv.Row, BauteilRow)

            If (MessageBox.Show(Me, String.Format("Bauteil mit IDNR = {0} wirklich löschen?!", row.IDNR), _
                                Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                Try
                    Dim query = From bw In Me.WbaDataSet.BauteilWarmbehandlung _
                                Where bw.Bauteil_Id = row.Id _
                                Select bw

                    ' Nur löschen, wenn das Bauteil keine Verknüpfungen mit Vorschriften hat
                    If query.Count = 0 Then
                        Me.BauteilBindingSource.RemoveCurrent()
                        Me.SaveData(Me.BauteilBindingSource)
                        Me.BauteileToolStripStatusLabel.Text = Me.WbaDataSet.Bauteil.Count.ToString
                    Else
                        MsgBox(String.Format("Zuerst die Zuordnungen von dem Bauteil mit IDNR = {0} entfernen!", row.IDNR))
                    End If
                Catch ex As Exception
                    Logging.WriteEntry(ex.Message, TraceEventType.Error)
                    MsgBox(ex.Message)
                End Try
            End If
        End If
    End Sub

    ''' <summary>
    ''' Die Historie für das Bauteil anzeigen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub HistoryBauteil_Click(sender As System.Object, e As System.EventArgs) Handles HistoryBauteil.Click
        With New FormHistory
            .ShowHistory(BauteilBindingSource)
        End With
    End Sub

    ''' <summary>
    ''' Die Historie für die Erstmuster anzeigen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub HistoryEMP_Click(sender As System.Object, e As System.EventArgs) Handles HistoryEMP.Click
        With New FormHistory
            .ShowHistory(_Bauteil_Id, _Warmbehandlung_Id, BauteilWarmbehandlungBindingSource, Me.WbaDataSet)
        End With
    End Sub
#End Region

#Region ".....Eventhandler für die Bauteil Bindingsource"

    ''' <summary>
    ''' Die Eventhandler für die Bauteil Bindingsource installieren
    ''' </summary>
    ''' <param name="bs"> Die BindingSource, auf deren Änderungen reagiert werden soll.</param>
    ''' <remarks></remarks>
    Private Sub CreateBindingHandler(bs As BindingSource)
        AddHandler bs.CurrentChanged, AddressOf RefreshBauteilBinding
        AddHandler bs.BindingComplete, AddressOf RefreshBauteilBinding
        AddHandler bs.ListChanged, AddressOf RefreshBauteilBinding
    End Sub

    ''' <summary>
    ''' Der Bindinghandler für die Warmbehandlungs-Vorschriften
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Sub RefreshBauteilBinding(sender As System.Object, e As System.EventArgs)
        RefreshWarmbehandlung()
    End Sub
#End Region

#Region ".....Warmbehandlung aktualisieren"

    ''' <summary>
    ''' Den DataGridView für die WB-Vorschriften aktualisieren
    ''' Die Benutzer-ID in Member speichern
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshWarmbehandlung()

        If Me.BauteilBindingSource.Count > 0 Then
            Dim drv As DataRowView = Me.BauteilBindingSource.Current

            If drv IsNot Nothing Then
                Dim pRow As BauteilRow = DirectCast(drv.Row, BauteilRow)

                ' Aktuell gewähltes Bauteil
                Me._Bauteil_Id = pRow.Id

                ' EquiJoin: Alle vergebenen WB-Vorschriften für aktuell gewähltes Bauteil
                Dim query = From btwb In Me.WbaDataSet.BauteilWarmbehandlung
                            Where btwb.Bauteil_Id = Me._Bauteil_Id
                            Join wb In Me.WbaDataSet.Warmbehandlung
                            On wb.Id Equals btwb.Warmbehandlung_Id
                            Select New With {.Id = wb.Id,
                                             .Warmbehandlung = wb.Name}

                Me.WarmbehandlungDataGridView.DataSource = query.ToList()
                Me.WarmbehandlungDataGridView.Columns(0).Visible = False ' "Id" ist unsichtbar!
                Me.WarmbehandlungDataGridView.Columns(1).Width = 250
                Me.WarmbehandlungDataGridView.Select()
            End If
        End If
    End Sub
#End Region

#Region ".....Warmbehandlung DataGridView SelectionChanged Ereignis"

    ''' <summary>
    ''' Die Auswahl im DataGridView der WB-Vorschriften hat sich geändert
    ''' Die Anzeigefelder für die Erstmusterprüfung entsprechend aktualisieren
    ''' Die aktuelle Warmbehandlungs-Id und die entsprechende Zeile aus der Tabelle "BauteilWarmbehandlung"
    ''' wird in Membervariablen gespeichert
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub WarmbehandlungDataGridView_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles WarmbehandlungDataGridView.SelectionChanged
        Try
            If Me.WarmbehandlungDataGridView.CurrentRow IsNot Nothing Then

                ' Die erste Spalte des DataGridView enthält die Id
                _Warmbehandlung_Id = Me.WarmbehandlungDataGridView.CurrentRow.Cells(0).Value

                ' Den entsprechenden Datensatz abfragen...
                Dim query = From btwb In WbaDataSet.BauteilWarmbehandlung
                            Where (btwb.Bauteil_Id = _Bauteil_Id And btwb.Warmbehandlung_Id = _Warmbehandlung_Id)
                            Select btwb

                ' ...und der Membervariablen zuweisen
                If query.Count > 0 Then
                    _CurrentBauteilWarmbehandlungRow = query.Single
                    'Me.Label1.Text = _CurrentBauteilWarmbehandlungRow.Bauteil_Id.ToString & "/" & _CurrentBauteilWarmbehandlungRow.Warmbehandlung_Id.ToString
                Else
                    _CurrentBauteilWarmbehandlungRow = Nothing
                    'Me.Label1.Text = "Nothing"
                End If

                ' Die Anzeigefelder für die Erstmusterprüfung aktualisieren
                If _CurrentBauteilWarmbehandlungRow IsNot Nothing Then
                    ' Die EMP-Felder dürfen nicht NULL sein!
                    If Not _CurrentBauteilWarmbehandlungRow.IsEMP_DatumNull AndAlso _
                       Not _CurrentBauteilWarmbehandlungRow.IsBenutzer_IdNull Then

                        ' Vorname + Name des Benutzers abfragen
                        Dim query1 = (From b In WbaDataSet.Benutzer
                                      Where b.Id = _CurrentBauteilWarmbehandlungRow.Benutzer_Id
                                      Select New With {.Vorname = b.Vorname,
                                                       .Name = b.Name}).Single

                        Me.ZeitstempelLabel.Text = _CurrentBauteilWarmbehandlungRow.EMP_Datum.ToString
                        Me.BenutzerLabel.Text = query1.Vorname & " " & query1.Name
                        Me.EMP_Button.Text = "Entfernen"
                        Me.EMP_Button.Enabled = True
                    Else
                        Me.ZeitstempelLabel.Text = "nicht erteilt"
                        Me.BenutzerLabel.Text = String.Empty
                        Me.EMP_Button.Text = "Erteilen"
                        Me.EMP_Button.Enabled = True
                    End If
                Else
                    Me.ZeitstempelLabel.Text = String.Empty
                    Me.BenutzerLabel.Text = String.Empty
                    Me.EMP_Button.Text = "Keine Zuordnung"
                    Me.EMP_Button.Enabled = False
                End If
            Else
                _CurrentBauteilWarmbehandlungRow = Nothing
                _Warmbehandlung_Id = 0
                Me.ZeitstempelLabel.Text = String.Empty
                Me.BenutzerLabel.Text = String.Empty
                Me.EMP_Button.Text = "Keine Zuordnung"
                Me.EMP_Button.Enabled = False
            End If
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.ToString)
        End Try
    End Sub
#End Region

#Region ".....Daten speichern"

    ''' <summary>
    ''' Änderungen in der Datenbank aktualisieren
    ''' </summary>
    ''' <param name="bs">Übergabe der entsprechenden BindingSource</param>
    ''' <returns>Anzahl der betroffenen Datensätze</returns>
    ''' <remarks></remarks>
    Private Function SaveData(bs As BindingSource) As Integer
        Try
            Me.Validate()
            bs.EndEdit()
            Return Me.TableAdapterManager.UpdateAll(Me.WbaDataSet)
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.ToString)
            Return 0
        End Try
    End Function
#End Region

#Region ".....Neues Bauteil anlegen"

    ''' <summary>
    ''' Es wird ein neues Bauteil angelegt
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub NeuesBauteil()
        Try
            ' Ein neues Formular
            Dim bauteil As New FormBauteilBearbeiten

            ' Eine neue DataRow
            Dim newRow = Me.WbaDataSet.Bauteil.NewBauteilRow

            ' Der Bearbeitendialog gibt eine entsprechende DataRow zurück
            Dim result As BauteilRow = bauteil.DatenBearbeiten(Me.WbaDataSet, newRow)

            ' Gibt es eine DataRow, dann...
            If result IsNot Nothing Then
                ' ...die Daten aktualisieren
                newRow.HTZ = result.HTZ
                newRow.IDNR = result.IDNR
                newRow.PL = result.PL

                ' Die neue DataRow zur Liste hinzufügen
                Me.WbaDataSet.Bauteil.AddBauteilRow(newRow)

                If Me.SaveData(BauteilBindingSource) > 0 Then
                    'MessageBox.Show(String.Format("Daten von Benutzer {0} {1} wurden geändert!", aktRow.U_VORNAME, aktRow.U_NAME))
                    Dim entry As String = String.Format("{0} {1} hat Bauteil ""IDNR"": '{2}' hinzugefügt{3}", _
                                                        DateTime.Now, _BenutzerAngemeldet.Name, result.IDNR, ControlChars.CrLf)
                    Me.QueriesTableAdapter.spBauteilAppendHistory(newRow.Id, entry)
                End If

                ' Die Datasource auf den neuen Datensatz positionieren
                Me.BauteilBindingSource.Position = Me.BauteilBindingSource.Find("IDNR", result.IDNR)
            End If
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.ToString)
        End Try
    End Sub
#End Region

#Region ".....Vorhandenes Bauteil bearbeiten"

    ''' <summary>
    ''' Gewähltes Bauteil bearbeiten
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BauteilBearbeiten()
        Try
            Dim bauteil As New FormBauteilBearbeiten

            ' Die DataRow mit dem aktuellen Benutzer
            Dim drv As DataRowView = CType(Me.BauteilBindingSource.Current, DataRowView)
            Dim currRow As BauteilRow = CType(drv.Row, BauteilRow)

            ' Der Bearbeitendialog gibt eine entsprechende DataRow zurück
            Dim result As BauteilRow = bauteil.DatenBearbeiten(Me.WbaDataSet, currRow)

            ' Gibt es eine DataRow, dann...
            If result IsNot Nothing Then
                ' ...die aktuelle Row zwischenspeichern...
                Dim row = Me.WbaDataSet.Bauteil.NewBauteilRow
                row.ItemArray = currRow.ItemArray

                ' ...und die Daten aktualisieren
                currRow.HTZ = result.HTZ
                currRow.IDNR = result.IDNR
                currRow.PL = result.PL

                ' War das Speichern erfolgreich,...
                If Me.SaveData(BauteilBindingSource) > 0 Then
                    ' ...dann die entsprechende History schreiben
                    If row.HTZ <> result.HTZ Then
                        Me.QueriesTableAdapter.spBauteilAppendHistory(row.Id, Me.GetHistoryEntry(_BenutzerAngemeldet.Name, "HTZ", row.HTZ, result.HTZ))
                    End If

                    If row.IDNR <> result.IDNR Then
                        Me.QueriesTableAdapter.spBauteilAppendHistory(row.Id, Me.GetHistoryEntry(_BenutzerAngemeldet.Name, "IDNR", row.IDNR, result.IDNR))
                    End If

                    If row.PL <> result.PL Then
                        Me.QueriesTableAdapter.spBauteilAppendHistory(row.Id, Me.GetHistoryEntry(_BenutzerAngemeldet.Name, "PL", row.PL, result.PL))
                    End If
                End If
            End If
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.ToString)
        End Try
    End Sub
#End Region

#Region ".....History String bilden"

    ''' <summary>
    ''' Gibt einen formatierten String für die Historie zurück
    ''' </summary>
    ''' <param name="user">angemeldeter Benutzer</param>
    ''' <param name="col">der Spaltenname</param>
    ''' <param name="fromvalue">alter Wert</param>
    ''' <param name="tovalue">neuer Wert</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetHistoryEntry(ByVal user As String, ByVal col As String, ByVal fromvalue As String, ByVal tovalue As String) As String
        Return String.Format("{0} {1} hat ""{2}"" von '{3}' nach '{4}' geändert{5}", Now.ToString, user, col, fromvalue, tovalue, ControlChars.CrLf)
    End Function
#End Region

#Region ".....Die EMP Button Click Ereignisse"

    Private Sub EMP_Button_Click(sender As System.Object, e As System.EventArgs) Handles RemoveButton.Click, EMP_Button.Click, AddButton.Click

        Select Case DirectCast(sender, Button).Name
            Case "EMP_Button" ' EMP erteilen/entfernen
                Dim result As Benutzer

                With New FormAnmeldung
                    result = .GetBenutzer()
                End With

                If result IsNot Nothing Then
                    If result.CodeCheck(30, 31) Then
                        Select Case EMP_Button.Text
                            Case "Erteilen"
                                _CurrentBauteilWarmbehandlungRow.EMP_Datum = DateTime.Now
                                _CurrentBauteilWarmbehandlungRow.Benutzer_Id = result.Id
                                Me.SaveData(BauteilWarmbehandlungBindingSource)

                                Dim entry As String = String.Format("{0} {1} hat für {2} EMP erteilt{3}", _
                                                                    DateTime.Now, result.Name, Me.WarmbehandlungDataGridView.CurrentRow.Cells(1).Value, ControlChars.CrLf)

                                With _CurrentBauteilWarmbehandlungRow
                                    Me.QueriesTableAdapter.spBauteilWarmbehandlungAppendHistory(.Bauteil_Id, .Warmbehandlung_Id, entry)
                                End With

                                Me.WarmbehandlungDataGridView_SelectionChanged(WarmbehandlungDataGridView, EventArgs.Empty)

                            Case "Entfernen"
                                _CurrentBauteilWarmbehandlungRow.SetEMP_DatumNull()
                                _CurrentBauteilWarmbehandlungRow.SetBenutzer_IdNull()
                                Me.SaveData(BauteilWarmbehandlungBindingSource)

                                Dim entry As String = String.Format("{0} {1} hat für {2} EMP entfernt{3}", _
                                                                    DateTime.Now, result.Name, Me.WarmbehandlungDataGridView.CurrentRow.Cells(1).Value, ControlChars.CrLf)

                                With _CurrentBauteilWarmbehandlungRow
                                    Me.QueriesTableAdapter.spBauteilWarmbehandlungAppendHistory(.Bauteil_Id, .Warmbehandlung_Id, entry)
                                End With

                                Me.WarmbehandlungDataGridView_SelectionChanged(WarmbehandlungDataGridView, EventArgs.Empty)
                        End Select
                    End If
                End If
                'End If

            Case "AddButton" ' WB-Vorschrift hinzufügen
                Dim wbId As Integer

                With New FormBauteilWarmbehandlung
                    wbId = .AddWarmbehandlung(_Bauteil_Id, WbaDataSet)
                End With

                If wbId > 0 Then
                    ' Die WB-Vorschrift hinzufügen
                    Dim newRow = Me.WbaDataSet.BauteilWarmbehandlung.NewBauteilWarmbehandlungRow

                    newRow.Bauteil_Id = _Bauteil_Id
                    newRow.Warmbehandlung_Id = wbId

                    Me.WbaDataSet.BauteilWarmbehandlung.AddBauteilWarmbehandlungRow(newRow)
                    Me.SaveData(Me.BauteilWarmbehandlungBindingSource)

                    Try
                        Dim query As WarmbehandlungRow = (From a In Me.WbaDataSet.Warmbehandlung
                                                          Where a.Id = wbId
                                                          Select a).Single

                        Dim entry As String = String.Format("{0} {1} hat die WB-Vorschrift '{2}' hinzugefügt{3}", _
                                                            DateTime.Now, _BenutzerAngemeldet.Name, query.Name, ControlChars.CrLf)
                        Me.QueriesTableAdapter.spBauteilAppendHistory(_Bauteil_Id, entry)
                    Catch ex As Exception
                        Logging.WriteEntry(ex.Message, TraceEventType.Error)
                        MsgBox(ex.Message)
                    End Try

                    Me.RefreshWarmbehandlung()
                End If

            Case "RemoveButton" ' WB-Vorschrift entfernen
                ' Nur ausführen, wenn überhaupt WB-Vorschriften für das gewählte Bauteil vergeben sind
                If Me.WarmbehandlungDataGridView.RowCount > 0 Then
                    Try
                        Me.BauteilWarmbehandlungBindingSource.Filter = String.Format("Bauteil_Id = {0} AND Warmbehandlung_Id = {1}", _Bauteil_Id, _Warmbehandlung_Id)

                        Dim drv As DataRowView = CType(BauteilWarmbehandlungBindingSource.Current, DataRowView)
                        Dim currRow As BauteilWarmbehandlungRow = CType(drv.Row, BauteilWarmbehandlungRow)

                        If currRow.IsEMP_DatumNull Then
                            Dim msgString As String = String.Format("Soll die WB-Vorschrift {0}{1}wirklich entfernt werden ?", _
                                                                    Strings.Trim(Me.WarmbehandlungDataGridView.CurrentRow.Cells(1).Value), ControlChars.CrLf)

                            If MessageBox.Show(Me, msgString, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then

                                Me.BauteilWarmbehandlungBindingSource.Filter = String.Format("Bauteil_Id = {0} AND Warmbehandlung_Id = {1}", _Bauteil_Id, _Warmbehandlung_Id)

                                If Me.BauteilWarmbehandlungBindingSource.Count = 1 Then
                                    Me.BauteilWarmbehandlungBindingSource.RemoveCurrent()
                                End If

                                Me.BauteilWarmbehandlungBindingSource.EndEdit()
                                Me.SaveData(Me.BauteilWarmbehandlungBindingSource)

                                Try
                                    Dim query As WarmbehandlungRow = (From a In Me.WbaDataSet.Warmbehandlung
                                                                      Where a.Id = _Warmbehandlung_Id
                                                                      Select a).Single

                                    Dim entry As String = String.Format("{0} {1} hat die WB-Vorschrift '{2}' entfernt{3}", _
                                                                        DateTime.Now, _BenutzerAngemeldet.Name, query.Name, ControlChars.CrLf)
                                    Me.QueriesTableAdapter.spBauteilAppendHistory(_Bauteil_Id, entry)
                                Catch ex As Exception
                                    Logging.WriteEntry(ex.Message, TraceEventType.Error)
                                    MsgBox(ex.Message)
                                End Try

                                Me.RefreshWarmbehandlung()
                            End If
                        Else
                            Dim msgString As String = String.Format("Für WB-Vorschrift {0} liegt eine Erstmuster vor!{1}Entfernen Sie zuerst das Erstmuster !", _
                                                                    Strings.Trim(Me.WarmbehandlungDataGridView.CurrentRow.Cells(1).Value), ControlChars.CrLf)
                            MessageBox.Show(Me, msgString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Catch ex As Exception
                        Logging.WriteEntry(ex.Message, TraceEventType.Error)
                        MsgBox(ex.Message)
                    Finally
                        Me.BauteilWarmbehandlungBindingSource.RemoveFilter()
                    End Try
                Else
                    MessageBox.Show("Keine WB-Vorschriften für" & ControlChars.CrLf & "das gewählte Bauteil vergeben!")
                End If
        End Select
    End Sub
#End Region

#Region ".....Die Filter Button Click Ereignisse"

    ''' <summary>
    ''' Bauteile filtern
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FilterButton_Click(sender As System.Object, e As System.EventArgs) Handles FilterButton.Click, ClearButton.Click
        If Me.FilterTextBox.Text <> String.Empty Then
            Select Case DirectCast(sender, Button).Name
                Case "FilterButton"
                    Me.BauteilBindingSource.Filter = Me.FilterComboBox.Text & " LIKE '" & Me.FilterTextBox.Text & "%'"

                Case "ClearButton"
                    Me.BauteilBindingSource.RemoveFilter()
                    Me.FilterTextBox.Text = String.Empty
            End Select
        End If
    End Sub
#End Region

End Class