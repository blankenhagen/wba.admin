Imports WBA.Admin.wbadminDataSet
Imports System.Windows.Forms.DataVisualization.Charting
Imports WBA.Admin.Tools

Public Class FormProgramm
    'Delegate Sub ChartDelegate(ByVal wbId As Integer)
    Delegate Sub UpdateChangesDelegate(id As Integer, tree As Boolean)

    'Public ChartAction As New ChartDelegate(AddressOf Me.DoChart)
    Public UpdateAction As New UpdateChangesDelegate(AddressOf Me.UpdateChanges)

    Friend Property BenutzerAngemeldet As Benutzer = Nothing
    Friend Property Warmbehandlung_Id As Integer ' = 0
    Private _XArray(15) As Integer

    ' Das Chart
    Private WithEvents ChartProgramm As System.Windows.Forms.DataVisualization.Charting.Chart = Nothing
    Private ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = Nothing
    Private Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = Nothing
    Private Series1 As System.Windows.Forms.DataVisualization.Charting.Series = Nothing

    ' Das DataSet
    Friend WithEvents WbaDataSet As WBA.Admin.wbadminDataSet = Nothing

    ' Die TableAdapter
    Friend AnlageTableAdapter As wbadminDataSetTableAdapters.AnlageTableAdapter = Nothing
    Friend WarmbehandlungTableAdapter As wbadminDataSetTableAdapters.WarmbehandlungTableAdapter = Nothing
    Friend ProgrammTableAdapter As wbadminDataSetTableAdapters.ProgrammTableAdapter = Nothing
    Friend TableAdapterManager As wbadminDataSetTableAdapters.TableAdapterManager = Nothing
    Friend QueriesTableAdapter As wbadminDataSetTableAdapters.QueriesTableAdapter = Nothing

    ' Die BindingSources
    Friend WithEvents WarmbehandlungBindingSource As BindingSource = Nothing
    Friend WithEvents ProgrammBindingSource As BindingSource = Nothing

    ' Wird für das Schreiben der History für Freigabe und Gesperrt gebraucht
    Private Enum Anlagenkuerzel
        SBH201 = 0
        SBH107 = 1
        RHO171 = 2
        LMO42 = 3
        HWO206 = 4
        HWO171 = 5
        UKO107 = 6
        NONE = 7
    End Enum

#Region "....Überladene Version von ShowDialog"

    ''' <summary>
    ''' Überladen für die Parameterübergabe
    ''' </summary>
    ''' <param name="user">Angemeldeter Benutzer</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function ShowDialog(user As Benutzer) As System.Windows.Forms.DialogResult
        BenutzerAngemeldet = user
        Me.BenutzerToolStripStatusLabel.Text = BenutzerAngemeldet.Name

        Return (MyBase.ShowDialog())
    End Function
#End Region

#Region "....Das Formular wird geladen"

    ''' <summary>
    ''' Das Formular wird geladen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FormProgramm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.CreateChart()

        Try
            Me.WbaDataSet = New WBA.Admin.wbadminDataSet()

            Me.AnlageTableAdapter = New WBA.Admin.wbadminDataSetTableAdapters.AnlageTableAdapter()
            Me.WarmbehandlungTableAdapter = New WBA.Admin.wbadminDataSetTableAdapters.WarmbehandlungTableAdapter()
            Me.ProgrammTableAdapter = New WBA.Admin.wbadminDataSetTableAdapters.ProgrammTableAdapter()
            Me.TableAdapterManager = New WBA.Admin.wbadminDataSetTableAdapters.TableAdapterManager()
            Me.QueriesTableAdapter = New WBA.Admin.wbadminDataSetTableAdapters.QueriesTableAdapter()

            Me.TableAdapterManager.AnlageTableAdapter = Nothing
            Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
            Me.TableAdapterManager.BauteilTableAdapter = Nothing
            Me.TableAdapterManager.BauteilWarmbehandlungTableAdapter = Nothing
            Me.TableAdapterManager.BenutzerAnlageTableAdapter = Nothing
            Me.TableAdapterManager.BenutzerRolleTableAdapter = Nothing
            Me.TableAdapterManager.BenutzerTableAdapter = Nothing
            Me.TableAdapterManager.ParameterTableAdapter = Nothing
            Me.TableAdapterManager.ProgrammTableAdapter = Me.ProgrammTableAdapter
            Me.TableAdapterManager.RolleTableAdapter = Nothing
            Me.TableAdapterManager.WarmbehandlungTableAdapter = Me.WarmbehandlungTableAdapter

            Me.WarmbehandlungBindingSource = New System.Windows.Forms.BindingSource(Me.WbaDataSet, "Warmbehandlung")
            Me.ProgrammBindingSource = New System.Windows.Forms.BindingSource(Me.WarmbehandlungBindingSource, "FK_Programm_Warmbehandlung")

            Me.WbaDataSet.EnforceConstraints = False
            Me.AnlageTableAdapter.Fill(Me.WbaDataSet.Anlage)
            Me.WarmbehandlungTableAdapter.Fill(Me.WbaDataSet.Warmbehandlung)
            Me.ProgrammTableAdapter.Fill(Me.WbaDataSet.Programm)

            Me.FilterComboBox.Text = Me.FilterComboBox.Items(0)
            Me.ProgrammeToolStripStatusLabel.Text = Me.WarmbehandlungBindingSource.Count.ToString

            With Me.ProgrammListView
                .Items.Clear()
                .View = View.Details
                .AllowColumnReorder = False
                .HeaderStyle = ColumnHeaderStyle.Nonclickable
                .FullRowSelect = True
                .MultiSelect = False
                .HideSelection = False
                .GridLines = True
                .Columns.Add("#", 20, HorizontalAlignment.Center)
                .Columns.Add("°C", 45, HorizontalAlignment.Right)
                .Columns.Add("d.hh:mm", 63, HorizontalAlignment.Right)
                '.Width = 130
                .Dock = DockStyle.Fill
            End With
            Me.WarmbehandlungBindingSource_PositionChanged(Nothing, EventArgs.Empty)
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "....Die Menü Click Ereignisse"

    ''' <summary>
    ''' Der Dialog wird geschlossen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Ende_Click(sender As System.Object, e As System.EventArgs) Handles EndeMenuItem.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Ein neues Programm soll angelegt werden
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ProgrammNew_Click(sender As System.Object, e As System.EventArgs) Handles ProgrammNew.Click
        ' Filter muss ausgeschaltet sein!
        If Me.FilterComboBox.SelectedIndex = 0 Then
            Me.NeuesProgramm()
            Me.ProgrammeToolStripStatusLabel.Text = Me.WarmbehandlungBindingSource.Count.ToString
        Else
            MessageBox.Show(Me, "Es darf kein Filter gesetzt sein!" & ControlChars.CrLf & _
                                "In der Filterauswahl 'Alle' wählen!", _
                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    ''' <summary>
    ''' Das aktuell gewählte Programm soll bearbeitet werden
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ProgrammEdit_Click(sender As System.Object, e As System.EventArgs) Handles ProgrammEdit.Click
        Me.ProgrammBearbeiten()
    End Sub

    ''' <summary>
    ''' Das aktuell gewählte Programm soll gelöscht werden
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ProgrammDelete_Click(sender As System.Object, e As System.EventArgs) Handles ProgrammDelete.Click
        If (MessageBox.Show(Me, "Programm wirlich löschen?", _
                            Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then

            Me.WarmbehandlungBindingSource.RemoveCurrent()
            Dim result As Integer = Me.SaveData(Me.WarmbehandlungBindingSource)
            Me.ProgrammeToolStripStatusLabel.Text = Me.WarmbehandlungBindingSource.Count.ToString
            ' TreeView entsprechend aktualisieren
            DoTreeView()
        End If
    End Sub

    ''' <summary>
    ''' Die selektierte Warmbehandlungsvorschrift unter neuem Namen kopieren
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ProgrammCopy_Click(sender As System.Object, e As System.EventArgs) Handles ProgrammCopy.Click
        ' Die DataRow mit der selektierten Vorschrift
        Dim drv As DataRowView = DirectCast(Me.WarmbehandlungBindingSource.Current, DataRowView)
        Dim row As WarmbehandlungRow = DirectCast(drv.Row, WarmbehandlungRow)


        If (MessageBox.Show(Me, String.Format("Soll die Vorschrift '{0}' unter neuem Namen kopiert werden?", row.Name), _
                            Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then

            Dim result As String = String.Empty

            With New FormVorschriftKopieren
                .Location = Me.ProgrammPanel.PointToScreen(New Point(Me.ChartProgramm.Location.X, Me.ChartProgramm.Location.Y))
                result = .GetName(Me.WbaDataSet, row.Name)

                If result IsNot String.Empty Then
                    Me.KopiereWarmbehandlung(result)
                    Me.ProgrammeToolStripStatusLabel.Text = Me.WarmbehandlungBindingSource.Count.ToString
                End If
            End With
        End If
    End Sub

    ''' <summary>
    ''' Die History für die aktuelle WB-Vorschrift anzeigen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub History_Click(sender As System.Object, e As System.EventArgs) Handles HistoryMenuItem.Click
        With New FormHistory
            .ShowHistory(WarmbehandlungBindingSource)
        End With
    End Sub
#End Region

#Region "....Warmbehandlung kopieren"

    ''' <summary>
    ''' Eine Warmbehandlungsvorschrift unter neuem Namen kopieren
    ''' </summary>
    ''' <param name="name">der neue Name</param>
    ''' <remarks></remarks>
    Private Sub KopiereWarmbehandlung(name As String)
        Try
            Dim rowOldWarmbehandlung As WarmbehandlungRow = Nothing
            Dim dtOldProgramm As DataTable = Nothing

            rowOldWarmbehandlung = Me.WbaDataSet.Warmbehandlung.FindById(Me.Warmbehandlung_Id)

            Dim query = From prg In Me.WbaDataSet.Programm _
                        Where prg.Warmbehandlung_Id = Me.Warmbehandlung_Id _
                        Select prg

            dtOldProgramm = query.CopyToDataTable

            ' Eine neue Warmbehandlungs Row erzeugen...
            Dim newRow = Me.WbaDataSet.Warmbehandlung.NewWarmbehandlungRow

            ' ...die Felder mit den alten Daten aktualisieren...
            newRow.Verfahren = rowOldWarmbehandlung.Verfahren
            newRow.Freigabe = False
            newRow.Gesperrt = False
            newRow.Name = name
            If Not IsDBNull(rowOldWarmbehandlung.Bemerkung) Then newRow.Bemerkung = rowOldWarmbehandlung.Bemerkung
            newRow.Laufzeit = rowOldWarmbehandlung.Laufzeit

            ' ...und die neue DataRow zur Liste hinzufügen
            Me.WbaDataSet.Warmbehandlung.AddWarmbehandlungRow(newRow)

            ' Diesen Datensatz speichern, damit seine "Id" verfügbar ist
            If Me.SaveData(WarmbehandlungBindingSource) > 0 Then
                ' Die Historie schreiben
                Dim entry As String = String.Format("{0} {1} hat WB-Programm '{2}' nach {3} kopiert{4}", _
                                                    DateTime.Now, BenutzerAngemeldet.Name, rowOldWarmbehandlung.Name, name, ControlChars.CrLf)
                Me.QueriesTableAdapter.spWarmbehandlungAppendHistory(newRow.Id, entry)
                Me.WbaDataSet.Warmbehandlung.AcceptChanges()
            End If

            ' 16 Prgrammabschnitte hinzufügen
            For i As Integer = 1 To 16
                Dim row = Me.WbaDataSet.Programm.NewProgrammRow

                With row
                    .Abschnitt = i
                    .Sollwert = dtOldProgramm.Rows(i - 1).Item("Sollwert")
                    .Dauer = dtOldProgramm.Rows(i - 1).Item("Dauer")
                    .Warmbehandlung_Id = newRow.Id ' Der Fremdschlüssel!
                End With

                Me.WbaDataSet.Programm.AddProgrammRow(row)
            Next

            ' Die Abschnitte speichern
            Me.SaveData(ProgrammBindingSource)

            ' Die Datasource auf den neuen Datensatz positionieren
            Me.WarmbehandlungBindingSource.Position = Me.WarmbehandlungBindingSource.Find("Name", name)

            ' TreeView entsprechend aktualisieren
            DoTreeView()
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "....Daten speichern"

    ''' <summary>
    ''' Änderungen in der Datenbank aktualisieren
    ''' </summary>
    ''' <param name="bs">Übergabe der entsprechenden BindingSource</param>
    ''' <returns>Anzahl der betroffenen Datensätze</returns>
    ''' <remarks></remarks>
    Friend Function SaveData(bs As BindingSource) As Integer
        Try
            Me.Validate()
            bs.EndEdit()
            Return Me.TableAdapterManager.UpdateAll(Me.WbaDataSet)
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.Message)
            Return 0
        End Try
    End Function
#End Region

#Region "....Neues Programm anlegen"

    ''' <summary>
    ''' Es wird ein neues Programm angelegt und nach dem Speichern
    ''' werden für dieses Programm die Abschnitte angelegt
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub NeuesProgramm()
        Try
            ' Ein neues Formular
            Dim NewPrg As New FormProgrammBearbeiten

            ' Eine neue DataRow
            Dim newRow = Me.WbaDataSet.Warmbehandlung.NewWarmbehandlungRow

            ' Der Bearbeitendialog gibt eine entsprechende DataRow zurück
            Dim result As WarmbehandlungRow = NewPrg.DatenBearbeiten(Me, newRow)

            ' Gibt es eine DataRow, dann...
            If result IsNot Nothing Then
                ' ...die Daten aktualisieren
                newRow.Verfahren = result.Verfahren
                newRow.Freigabe = result.Freigabe
                newRow.Gesperrt = result.Gesperrt
                newRow.Name = result.Name
                newRow.Bemerkung = result.Bemerkung
                newRow.Laufzeit = 0

                ' Die neue DataRow zur Liste hinzufügen
                Me.WbaDataSet.Warmbehandlung.AddWarmbehandlungRow(newRow)

                If Me.SaveData(WarmbehandlungBindingSource) > 0 Then
                    Dim entry As String = String.Format("{0} {1} hat WB-Programm '{2}' hinzugefügt{3}", _
                                                        DateTime.Now, BenutzerAngemeldet.Name, result.Name, ControlChars.CrLf)
                    Me.QueriesTableAdapter.spWarmbehandlungAppendHistory(newRow.Id, entry)
                    Me.WbaDataSet.Warmbehandlung.AcceptChanges()
                End If

                ' Die Abschnitte für den Datensatz erzeugen
                Me.MacheAbschnitte(newRow.Name)

                ' Die Datasource auf den neuen Datensatz positionieren
                Me.WarmbehandlungBindingSource.Position = Me.WarmbehandlungBindingSource.Find("Name", result.Name)

                ' TreeView entsprechend aktualisieren
                DoTreeView()
            End If
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "....Vorhandenes Programm bearbeiten"

    ''' <summary>
    ''' Gewähltes Programm bearbeiten
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ProgrammBearbeiten()
        Try
            Dim EditPrg As New FormProgrammBearbeiten

            ' Die DataRow mit der aktuellen Warmbehandlung
            Dim drv As DataRowView = CType(Me.WarmbehandlungBindingSource.Current, DataRowView)
            Dim currRow As WarmbehandlungRow = CType(drv.Row, WarmbehandlungRow)

            ' Der Bearbeitendialog gibt eine entsprechende DataRow zurück
            Dim result As WarmbehandlungRow = EditPrg.DatenBearbeiten(Me, currRow)

            ' Gibt es eine DataRow, dann...
            If result IsNot Nothing Then
                ' ...die aktuelle Row zwischenspeichern...
                Dim row = Me.WbaDataSet.Warmbehandlung.NewWarmbehandlungRow
                row.ItemArray = currRow.ItemArray

                ' ...und die Daten aktualisieren
                currRow.Verfahren = result.Verfahren
                currRow.Freigabe = result.Freigabe
                currRow.Gesperrt = result.Gesperrt
                currRow.Name = result.Name
                currRow.Bemerkung = result.Bemerkung

                ' War das Speichern erfolgreich,...
                If Me.SaveData(WarmbehandlungBindingSource) > 0 Then

                    ' ...dann die entsprechende History schreiben
                    If row.Verfahren <> result.Verfahren Then
                        Dim history As String = String.Empty

                        history = String.Format("{0} {1} hat ""{2}"" von '{3}' nach '{4}' geändert{5}", Now.ToString, BenutzerAngemeldet.Name, "Verfahren", row.Verfahren, result.Verfahren, ControlChars.CrLf)
                        Me.QueriesTableAdapter.spWarmbehandlungAppendHistory(row.Id, history)
                    End If

                    If row.Name <> result.Name Then
                        Dim history As String = String.Empty

                        history = String.Format("{0} {1} hat ""{2}"" von '{3}' nach '{4}' geändert{5}", Now.ToString, BenutzerAngemeldet.Name, "Name", row.Verfahren, result.Verfahren, ControlChars.CrLf)
                        Me.QueriesTableAdapter.spWarmbehandlungAppendHistory(row.Id, history)
                    End If

                    If row.Freigabe <> result.Freigabe Then
                        Dim history As String = String.Empty

                        For i As Integer = 0 To 7
                            If Tools.BitSet(row.Freigabe, i) Xor Tools.BitSet(result.Freigabe, i) Then
                                If Tools.BitSet(result.Freigabe, i) Then ' Die Freigabe für diese Anlage wurde erteilt
                                    history = String.Format("{0} {1} hat Freigabe für {2} erteilt{3}", Now.ToString, BenutzerAngemeldet.Name, [Enum].GetName(GetType(Anlagenkuerzel), i), ControlChars.CrLf)
                                    Me.QueriesTableAdapter.spWarmbehandlungAppendHistory(row.Id, history)
                                Else ' Die Freigabe für diese Anlage wurde entfernt
                                    history = String.Format("{0} {1} hat Freigabe für {2} entfernt{3}", Now.ToString, BenutzerAngemeldet.Name, [Enum].GetName(GetType(Anlagenkuerzel), i), ControlChars.CrLf)
                                    Me.QueriesTableAdapter.spWarmbehandlungAppendHistory(row.Id, history)
                                End If
                            End If
                        Next
                    End If

                    If row.Gesperrt <> result.Gesperrt Then
                        Dim history As String = String.Empty

                        For i As Integer = 0 To 7
                            If Tools.BitSet(row.Gesperrt, i) Xor Tools.BitSet(result.Gesperrt, i) Then
                                If Tools.BitSet(result.Gesperrt, i) Then ' Die Sperre für diese Anlage wurde gesetzt
                                    history = String.Format("{0} {1} hat Sperre für {2} gesetzt{3}", Now.ToString, BenutzerAngemeldet.Name, [Enum].GetName(GetType(Anlagenkuerzel), i), ControlChars.CrLf)
                                    Me.QueriesTableAdapter.spWarmbehandlungAppendHistory(row.Id, history)
                                Else ' Die Sperre für diese Anlage wurde entfernt
                                    history = String.Format("{0} {1} hat Sperre für {2} entfernt{3}", Now.ToString, BenutzerAngemeldet.Name, [Enum].GetName(GetType(Anlagenkuerzel), i), ControlChars.CrLf)
                                    Me.QueriesTableAdapter.spWarmbehandlungAppendHistory(row.Id, history)
                                End If
                            End If
                        Next
                    End If
                End If

                ' TreeView entsprechend aktualisieren
                DoTreeView()
            End If
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "....Abschnitte für neues Programm erzeugen"

    ''' <summary>
    ''' Für das gerade angelegte Programm die Abschnitte erzeugen
    ''' </summary>
    ''' <param name="prgName"></param>
    ''' <remarks></remarks>
    Private Sub MacheAbschnitte(ByVal prgName As String)
        Try
            ' Den zuletzt eingefügten Datensatz über den Namen finden, damit seine Id verfügbar ist
            Dim drv As DataRowView = CType(Me.WarmbehandlungBindingSource(Me.WarmbehandlungBindingSource.Find("Name", prgName)), DataRowView)

            ' 16 Prgrammabschnitte hinzufügen
            For i As Integer = 1 To 16
                Dim row = Me.WbaDataSet.Programm.NewProgrammRow

                With row
                    .Abschnitt = i
                    .Sollwert = 0
                    .Dauer = 0
                    .Warmbehandlung_Id = CType(drv.Row, WarmbehandlungRow).Id ' Der Fremdschlüssel!
                End With

                Me.WbaDataSet.Programm.AddProgrammRow(row)
            Next

            Me.SaveData(ProgrammBindingSource)
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#Region "....Update Action Delegate"

    ''' <summary>
    ''' Update Action Delegate
    ''' </summary>
    ''' <param name="id"></param>
    ''' <remarks></remarks>
    Private Sub UpdateChanges(id As Integer, tree As Boolean)
        If tree Then
            Me.DoTreeView()
        End If

        Me.DoChart(id)
        Me.DoListView(id)
    End Sub

#End Region

#Region "....TreeView aktualisieren"

    ''' <summary>
    ''' Die Baumdarstellung der Programme aktualisieren
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DoTreeView()
        Try
            ' Alle Knoten im TreeView löschen
            Me.WarmbehandlungTreeView.Nodes.Clear()

            ' Nur ausführen, wenn es auch Programme gibt
            If Me.WarmbehandlungBindingSource.Count > 0 Then
                'Me.bsWarmbehandlung.Sort = "Name"
                Dim i As Integer ' Index des jeweiligen Hauptknotens

                Me.WarmbehandlungTreeView.BeginUpdate()

                ' Für jedes Programm einen Knoten aufbauen (BindingSource wird duch ComboBox gefiltert)
                For Each pRow As DataRowView In Me.WarmbehandlungBindingSource

                    ' Der Elternknoten enthält den Namen des Programms
                    i = Me.WarmbehandlungTreeView.Nodes.Add(New TreeNode(pRow("Name")))
                    Me.WarmbehandlungTreeView.Nodes(i).Name = pRow("Id").ToString  ' Der Name des Knotens ist die Id

                    'If pRow("Gesperrt") Then ' Ist das Programm gesperrt, dann Name in rot
                    '    Me.WarmbehandlungTreeView.Nodes(i).ForeColor = Color.Red
                    'End If

                    '' Ist das Programm nicht freigegeben, dann Name in blau, ausser es ist gesperrt
                    'If Not pRow("Freigabe") AndAlso Not pRow("Gesperrt") Then
                    '    Me.WarmbehandlungTreeView.Nodes(i).ForeColor = Color.Blue
                    'End If

                    ' Der 1. Kindknoten enthält den Typ (Weichglühen/Warmauslagern, Lösungsglühen = 0)
                    Select Case pRow("Verfahren")
                        Case 1 ' Weichglühen
                            Me.WarmbehandlungTreeView.Nodes(i).ImageIndex = 5
                            Me.WarmbehandlungTreeView.Nodes(i).Nodes.Add(New TreeNode("Weichglühen"))
                            Me.WarmbehandlungTreeView.Nodes(i).Nodes(0).ImageIndex = 3
                        Case 2 ' Warmauslagern
                            Me.WarmbehandlungTreeView.Nodes(i).ImageIndex = 4
                            Me.WarmbehandlungTreeView.Nodes(i).Nodes.Add(New TreeNode("Warmauslagern"))
                            Me.WarmbehandlungTreeView.Nodes(i).Nodes(0).ImageIndex = 2
                    End Select

                    Me.WarmbehandlungTreeView.Nodes(i).SelectedImageIndex = Me.WarmbehandlungTreeView.Nodes(i).ImageIndex
                    Me.WarmbehandlungTreeView.Nodes(i).Nodes(0).SelectedImageIndex = Me.WarmbehandlungTreeView.Nodes(i).Nodes(0).ImageIndex

                    ' Der 2. Kindknoten enthält die Laufzeit
                    Me.WarmbehandlungTreeView.Nodes(i).Nodes.Add(New TreeNode(String.Format("{0}.{1:D2}:{2:D2}", pRow("Laufzeit") \ 1440, _
                                                                                                           (pRow("Laufzeit") Mod 1440) \ 60, _
                                                                                                           ((pRow("Laufzeit") Mod 1440) Mod 60) Mod 60)))

                    Me.WarmbehandlungTreeView.Nodes(i).Nodes(1).ImageIndex = 0
                    Me.WarmbehandlungTreeView.Nodes(i).Nodes(1).SelectedImageIndex = Me.WarmbehandlungTreeView.Nodes(i).Nodes(1).ImageIndex

                    ' Der 3. Kindknoten enthält die Freigabe
                    Me.WarmbehandlungTreeView.Nodes(i).Nodes.Add(New TreeNode("Freigabe"))
                    Me.WarmbehandlungTreeView.Nodes(i).Nodes(2).ImageIndex = 8
                    Me.WarmbehandlungTreeView.Nodes(i).Nodes(2).SelectedImageIndex = Me.WarmbehandlungTreeView.Nodes(i).Nodes(2).ImageIndex

                    ' Die Anlagen, für die das Programm freigegeben ist
                    Dim k As Integer = 0

                    For bit As Integer = 0 To 7
                        If BitSet(pRow("Freigabe"), bit) Then
                            Dim j As Integer = bit + 1
                            Dim query = (From a In Me.WbaDataSet.Anlage _
                                         Where a.Code = (j)).Single

                            Me.WarmbehandlungTreeView.Nodes(i).Nodes(2).Nodes.Add(New TreeNode(query.Kuerzel))
                            Me.WarmbehandlungTreeView.Nodes(i).Nodes(2).Nodes(k).ImageIndex = 9
                            Me.WarmbehandlungTreeView.Nodes(i).Nodes(2).Nodes(k).SelectedImageIndex = Me.WarmbehandlungTreeView.Nodes(i).Nodes(2).Nodes(k).ImageIndex

                            k += 1
                        End If
                    Next

                    ' Der 4. Kindknoten enthält die Sperre
                    Me.WarmbehandlungTreeView.Nodes(i).Nodes.Add(New TreeNode("Sperre"))
                    Me.WarmbehandlungTreeView.Nodes(i).Nodes(3).ImageIndex = 7
                    Me.WarmbehandlungTreeView.Nodes(i).Nodes(3).SelectedImageIndex = Me.WarmbehandlungTreeView.Nodes(i).Nodes(3).ImageIndex

                    ' Die Anlagen, für die das Programm gesperrt ist
                    k = 0

                    For bit As Integer = 0 To 7
                        If BitSet(pRow("Gesperrt"), bit) Then
                            Dim j As Integer = bit + 1
                            Dim query = (From a In Me.WbaDataSet.Anlage _
                                         Where a.Code = (j)).Single

                            Me.WarmbehandlungTreeView.Nodes(i).Nodes(3).Nodes.Add(New TreeNode(query.Kuerzel))
                            Me.WarmbehandlungTreeView.Nodes(i).Nodes(3).Nodes(k).ImageIndex = 10
                            Me.WarmbehandlungTreeView.Nodes(i).Nodes(3).Nodes(k).SelectedImageIndex = Me.WarmbehandlungTreeView.Nodes(i).Nodes(3).Nodes(k).ImageIndex

                            k += 1
                        End If
                    Next
                Next

                Me.WarmbehandlungTreeView.EndUpdate()

                ' Den aktuellen Knoten selektieren
                If Me.WarmbehandlungTreeView.Nodes.Count > 0 Then
                    Me.WarmbehandlungTreeView.SelectedNode = Me.WarmbehandlungTreeView.Nodes(Me.WarmbehandlungBindingSource.Position)
                    Me.WarmbehandlungTreeView.SelectedNode.EnsureVisible()
                    Me.WarmbehandlungTreeView.Select()
                End If
            End If
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "....Das Chart erzeugen"

    ''' <summary>
    ''' Das Chart erzeugen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateChart()
        Me.ChartProgramm = New System.Windows.Forms.DataVisualization.Charting.Chart()

        Me.ChartArea1 = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Me.Legend1 = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Me.Series1 = New System.Windows.Forms.DataVisualization.Charting.Series()

        Me.ChartProgramm.BorderlineColor = System.Drawing.Color.DimGray
        Me.ChartProgramm.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        'Me.ChartProgramm.Location = New System.Drawing.Point(125, 69)
        Me.ChartProgramm.Location = New System.Drawing.Point(0, 0)
        Me.ChartProgramm.Dock = DockStyle.Fill
        Me.ChartProgramm.Name = "ChartProgramm"
        'Me.ChartProgramm.Size = New System.Drawing.Size(479, 374)
        Me.ChartProgramm.TabIndex = 43
        Me.ChartProgramm.Text = "Chart1"

        Me.ChartArea1.AxisX.Interval = 60.0R
        Me.ChartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount
        Me.ChartArea1.Name = "ChartArea1"
        Me.ChartProgramm.ChartAreas.Add(ChartArea1)

        Me.Legend1.Enabled = False
        Me.Legend1.Name = "Legend1"
        Me.ChartProgramm.Legends.Add(Legend1)

        Me.Series1.BorderWidth = 2
        Me.Series1.ChartArea = "ChartArea1"
        Me.Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Me.Series1.Legend = "Legend1"
        Me.Series1.MarkerSize = 9
        Me.Series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle
        Me.Series1.Name = "Series1"
        Me.Series1.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.Red
        Me.Series1.SmartLabelStyle.Enabled = False
        Me.ChartProgramm.Series.Add(Series1)

        AddHandler Me.ChartProgramm.Customize, AddressOf ChartProgramm_Customize
        AddHandler Me.ChartProgramm.GetToolTipText, AddressOf ChartProgramm_GetToolTipText
        AddHandler Me.ChartProgramm.MouseMove, AddressOf ChartProgramm_MouseMove

        'Me.ProgrammPanel.Controls.Add(Me.ChartProgramm)
        Me.ChartPanel.Controls.Add(Me.ChartProgramm)
    End Sub
#End Region

#Region "....Chart aktualisieren"

    ''' <summary>
    ''' Die grafische Darstellung des Programms aktualisieren
    ''' </summary>
    ''' <param name="wbId">Aktuell gewählte Warmbehandlung</param>
    ''' <remarks></remarks>
    Public Sub DoChart(ByVal wbId As Integer)
        Try
            Dim zeit As TimeSpan = TimeSpan.Zero ' Zeitvariable mit 0 als Wert

            ' LINQ-Abfrage der Abschnittedatensätze, die zum aktuellen Programm gehören
            Dim query = From prg In Me.WbaDataSet.Programm _
                        Where prg.Warmbehandlung_Id = wbId _
                        Select New With _
                        {.Sollwert = prg.Sollwert, _
                         .Dauer = prg.Dauer}

            ' Das Chart mit allen Datenpunkten versorgen
            With Me.ChartProgramm
                .ChartAreas("ChartArea1").AxisX.Minimum = 0 ' X-Achse fängt bei 0 an
                .Series("Series1").Points.Clear() ' Pointscollection löschen
                ' 1.Punkt: X = 0, Y = Startsollwert
                .Series("Series1").Points.AddXY(zeit.TotalMinutes, 0)
                Me._XArray(0) = 0

                Dim i As Integer = 0

                ' Über alle Datensätze in Abschnitte iterieren
                For Each dr In query
                    i += 1

                    ' Wenn Zeiten = 0, dann Programm zu Ende
                    If dr.Dauer = 0 OrElse i > 15 Then
                        Exit For
                    End If

                    ' Zeitwert aus Stunden, Minuten und Sekunden bilden
                    zeit = zeit.Add(New TimeSpan(0, dr.Dauer, 0))
                    Me._XArray(i) = dr.Dauer ' X-Werte für Datenpunkt-Tooltips (siehe "GetToolTipText" )

                    .Series("Series1").Points.AddXY(zeit.TotalMinutes, dr.Sollwert)
                    '.Series("Series1").Points(i).Label = String.Format("{0}{1}{2}", dr.Sollwert,
                    '                                                                ControlChars.CrLf,
                    '                                                                DateTime.MinValue.AddMinutes(dr.Dauer).ToString("HH:mm"))
                Next
            End With
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "....Die Chart Ereignisse"

    ''' <summary>
    ''' Die Labels der Zeitachse benutzerdefiniert formatieren
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ChartProgramm_Customize(sender As System.Object, e As System.EventArgs)
        Dim xAxisLabels As CustomLabelsCollection = DirectCast(sender, Chart).ChartAreas(0).AxisX.CustomLabels

        For i As Integer = 0 To xAxisLabels.Count - 1
            Dim ts As TimeSpan = TimeSpan.FromMinutes(Double.Parse(xAxisLabels(i).Text))
            xAxisLabels(i).Text = ts.Hours.ToString("00") & ":" & ts.Minutes.ToString("00")
        Next
    End Sub

    ''' <summary>
    ''' Text für Datenpunkt-Tooltips zuweisen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ChartProgramm_GetToolTipText(sender As System.Object, e As System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs)
        Dim myChart As Chart = DirectCast(sender, Chart)

        Select Case e.HitTestResult.ChartElementType
            Case ChartElementType.DataPoint
                If e.HitTestResult.PointIndex >= 0 Then
                    Dim ts As TimeSpan = TimeSpan.FromMinutes(Me._XArray(e.HitTestResult.PointIndex))
                    e.Text = myChart.Series(0).Points(e.HitTestResult.PointIndex).YValues(0).ToString & " °C" & ControlChars.CrLf & _
                             ts.Days.ToString("0") & "." & ts.Hours.ToString("00") & ":" & ts.Minutes.ToString("00")
                End If
        End Select
    End Sub

    ''' <summary>
    ''' Bei Mausbewegung das Erscheinungsbild des entsprechenden Datenpunktes ändern
    ''' Das entsprechende Segment wir in rot dargestellt
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ChartProgramm_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        Dim myChart As Chart = DirectCast(sender, Chart)
        Dim htrResult As HitTestResult = myChart.HitTest(e.X, e.Y)

        'Alle Datenpunkte zurück auf Default
        For Each dp As DataPoint In myChart.Series(0).Points
            dp.Color = Color.CornflowerBlue
        Next dp

        'Wird die Maus über einen Datenpunkt bewegt,
        'so wird die Farbe für diesen Punkt gewechselt
        If htrResult.PointIndex >= 0 Then
            If htrResult.ChartElementType = ChartElementType.DataPoint Then
                Dim dpSelected As DataPoint

                dpSelected = myChart.Series(0).Points(htrResult.PointIndex)
                dpSelected.Color = Color.Crimson
            End If
        End If
    End Sub
#End Region

#Region "....Das TreeView AfterSelect Ereignis"

    ''' <summary>
    ''' Die Position in der BindingSourde mit der Position im TreeView synchronisieren
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub WarmbehandlungTreeView_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles WarmbehandlungTreeView.AfterSelect

        ' Die Position der BindingSource entsprechend des selektierten Knotens setzen
        ' Name = Id, Unterknoten sind leer
        If e.Node.Name <> String.Empty Then
            Me.WarmbehandlungBindingSource.Position = e.Node.Index
            Me.WarmbehandlungTreeView.Select()
            Dim drv As DataRowView = CType(Me.WarmbehandlungBindingSource.Current, DataRowView)
            Dim currRow As WarmbehandlungRow = CType(drv.Row, WarmbehandlungRow)
            Warmbehandlung_Id = currRow.Id
            'Me.DoChart(_Warmbehandlung_Id)
            'Me.DoListView(_Warmbehandlung_Id)
        End If
    End Sub
#End Region

#Region "....Den ListView aktualisieren"

    ''' <summary>
    ''' Den ListView aktualisieren
    ''' Die Daten der einzelnen Programm Abschnitte anzeigen
    ''' </summary>
    ''' <param name="wbId"></param>
    ''' <remarks></remarks>
    Private Sub DoListView(wbId As Integer)
        Try
            Dim query = From prg In Me.WbaDataSet.Programm _
                        Where prg.Warmbehandlung_Id = wbId _
                        Select New With _
                        {.Id = prg.Id, _
                         .Abschnitt = prg.Abschnitt, _
                         .Sollwert = prg.Sollwert, _
                         .Dauer = prg.Dauer}

            Me.ProgrammListView.Items.Clear()


            Dim strDauer As String = String.Empty

            For Each row In query
                If row.Sollwert = 0 AndAlso row.Dauer = 0 Then
                    Exit For
                End If

                strDauer = String.Format("{0}.{1:D2}:{2:D2}", row.Dauer \ 1440, _
                                                             (row.Dauer Mod 1440) \ 60, _
                                                            ((row.Dauer Mod 1440) Mod 60) Mod 60)

                Dim lvItem As New ListViewItem(row.Abschnitt.ToString)
                lvItem.Tag = row.Id
                lvItem.SubItems.Add(row.Sollwert.ToString)
                lvItem.SubItems.Add(strDauer)

                Me.ProgrammListView.Items.Add(lvItem)
            Next

            If Me.ProgrammListView.Items.Count > 0 Then
                Me.ProgrammListView.Items.Item(0).Selected = True
                'Me.ProgrammListView.Items.Item(0).Focused = True
            End If
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "....Das ListView ColumnWidthChanging Ereignis"

    ''' <summary>
    ''' Verhindert das Verändern der Spaltenbreite
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ProgrammListView_ColumnWidthChanging(sender As System.Object, e As System.Windows.Forms.ColumnWidthChangingEventArgs) Handles ProgrammListView.ColumnWidthChanging
        e.NewWidth = Me.ProgrammListView.Columns(e.ColumnIndex).Width
        e.Cancel = True
    End Sub
#End Region

#Region "....Das ComboBox SelectIndexChanged Ereignis"

    ''' <summary>
    ''' Die Anzeige im TreeView filtern
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FilterComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles FilterComboBox.SelectedIndexChanged

        Select Case DirectCast(sender, ComboBox).SelectedIndex
            Case 0 ' Alle (Weichglühen + Warmauslagern)
                Me.WarmbehandlungBindingSource.Filter = "Verfahren = 1 or Verfahren = 2"
                Me.WarmbehandlungBindingSource.Position = 0

            Case 1 ' Weichglühen
                Me.WarmbehandlungBindingSource.Filter = "Verfahren = 1"
                Me.WarmbehandlungBindingSource.Position = 0

            Case 2 ' Warmauslagern
                Me.WarmbehandlungBindingSource.Filter = "Verfahren = 2"
                Me.WarmbehandlungBindingSource.Position = 0
        End Select

        ' TreeView entsprechend aktualisieren
        Me.DoTreeView()
    End Sub
#End Region

#Region "....PositionChanged Ereignisse der BindingSources"

    ''' <summary>
    ''' Die aktuelle Position in der BindingSource "Warmbehandlung" hat sich geändert
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub WarmbehandlungBindingSource_PositionChanged(sender As Object, e As System.EventArgs) Handles WarmbehandlungBindingSource.PositionChanged
        Dim drv As DataRowView = CType(Me.WarmbehandlungBindingSource.Current, DataRowView)
        Dim currRow As WarmbehandlungRow = CType(drv.Row, WarmbehandlungRow)

        Me.NameLabel.Text = currRow.Name
        Me.UpdateChanges(currRow.Id, False)
    End Sub

    ''' <summary>
    ''' Die aktuelle Position in der BindingSource "Programm" hat sich geändert
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ProgrammBindingSource_PositionChanged(sender As Object, e As System.EventArgs) Handles ProgrammBindingSource.PositionChanged
        Dim drv As DataRowView = CType(Me.ProgrammBindingSource.Current, DataRowView)

        If drv IsNot Nothing Then
            Dim currRow As ProgrammRow = CType(drv.Row, ProgrammRow)
            Dim totalTime As Integer = 0

            ' Die Zeiten der Abschnitte aufaddieren
            For i As Integer = 1 To currRow.Abschnitt
                Dim rowView As DataRowView = CType(Me.ProgrammBindingSource.Item(i - 1), DataRowView)
                Dim row As ProgrammRow = CType(rowView.Row, ProgrammRow)
                totalTime += row.Dauer
            Next
        End If
    End Sub
#End Region

#Region "....Split Container Collapse Button Click Ereignis"

    ''' <summary>
    ''' Abschnitte-Tabelle anzeigen/verbergen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CollapseButton_Click(sender As System.Object, e As System.EventArgs) Handles CollapseButton.Click
        Me.ProgrammSplitContainer.Panel1Collapsed = Not Me.ProgrammSplitContainer.Panel1Collapsed

        Me.CollapseButton.Image = If(Me.ProgrammSplitContainer.Panel1Collapsed, My.Resources.collapse_right, My.Resources.collapse_left)
    End Sub
#End Region


    Private Sub ProgrammListView_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ProgrammListView.SelectedIndexChanged
        Dim lv As ListView = DirectCast(sender, ListView)

        If lv.SelectedItems.Count > 0 Then
            Dim i As Integer = lv.SelectedItems(0).Index
            Dim j As Integer = lv.SelectedItems(0).Tag

            Me.ProgrammBindingSource.Position = i
            'Debug.WriteLine(i.ToString & ", " & j.ToString)
        End If
    End Sub
End Class