Imports WBA.Admin.wbadminDataSet

Public Class FormBenutzer
    Private _Benutzer_Id As Integer = 0
    Private _Anlage_Id As Integer = 0
    Private _Anlage As String = String.Empty
    Private _BenutzerGewaehlt As String = String.Empty
    Private _BenutzerAngemeldet As Benutzer = Nothing

    ' Das DataSet
    Private WbaDataSet As WBA.Admin.wbadminDataSet = Nothing

    ' Die TableAdapter
    Private BenutzerTableAdapter As WBA.Admin.wbadminDataSetTableAdapters.BenutzerTableAdapter = Nothing
    Private AnlageTableAdapter As WBA.Admin.wbadminDataSetTableAdapters.AnlageTableAdapter = Nothing
    Private RolleTableAdapter As WBA.Admin.wbadminDataSetTableAdapters.RolleTableAdapter = Nothing
    Private BenutzerRolleTableAdapter As WBA.Admin.wbadminDataSetTableAdapters.BenutzerRolleTableAdapter = Nothing
    Private BenutzerAnlageTableAdapter As WBA.Admin.wbadminDataSetTableAdapters.BenutzerAnlageTableAdapter = Nothing
    Private TableAdapterManager As WBA.Admin.wbadminDataSetTableAdapters.TableAdapterManager = Nothing
    Private QueriesTableAdapter As WBA.Admin.wbadminDataSetTableAdapters.QueriesTableAdapter = Nothing

    ' Die BindingSources
    Private BenutzerAnlageBindingSource As System.Windows.Forms.BindingSource = Nothing
    Private BenutzerRolleBindingSource As System.Windows.Forms.BindingSource = Nothing
    Private BenutzerBindingSource As System.Windows.Forms.BindingSource = Nothing

#Region "....Das Formular wird geladen"

    ''' <summary>
    ''' Das Formular wird geladen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FormBenutzer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Try
            Me.WbaDataSet = New WBA.Admin.wbadminDataSet()

            Me.BenutzerTableAdapter = New WBA.Admin.wbadminDataSetTableAdapters.BenutzerTableAdapter()
            Me.AnlageTableAdapter = New WBA.Admin.wbadminDataSetTableAdapters.AnlageTableAdapter()
            Me.RolleTableAdapter = New WBA.Admin.wbadminDataSetTableAdapters.RolleTableAdapter()
            Me.BenutzerRolleTableAdapter = New WBA.Admin.wbadminDataSetTableAdapters.BenutzerRolleTableAdapter()
            Me.BenutzerAnlageTableAdapter = New WBA.Admin.wbadminDataSetTableAdapters.BenutzerAnlageTableAdapter()
            Me.TableAdapterManager = New WBA.Admin.wbadminDataSetTableAdapters.TableAdapterManager()
            Me.QueriesTableAdapter = New WBA.Admin.wbadminDataSetTableAdapters.QueriesTableAdapter()

            Me.TableAdapterManager.AnlageTableAdapter = Me.AnlageTableAdapter
            Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
            Me.TableAdapterManager.BauteilTableAdapter = Nothing
            Me.TableAdapterManager.BauteilWarmbehandlungTableAdapter = Nothing
            Me.TableAdapterManager.BenutzerAnlageTableAdapter = Me.BenutzerAnlageTableAdapter
            Me.TableAdapterManager.BenutzerRolleTableAdapter = Me.BenutzerRolleTableAdapter
            Me.TableAdapterManager.BenutzerTableAdapter = Me.BenutzerTableAdapter
            Me.TableAdapterManager.ParameterTableAdapter = Nothing
            Me.TableAdapterManager.ProgrammTableAdapter = Nothing
            Me.TableAdapterManager.RolleTableAdapter = Me.RolleTableAdapter
            Me.TableAdapterManager.WarmbehandlungTableAdapter = Nothing

            Me.BenutzerBindingSource = New System.Windows.Forms.BindingSource(Me.WbaDataSet, "Benutzer")
            Me.BenutzerAnlageBindingSource = New System.Windows.Forms.BindingSource(Me.WbaDataSet, "BenutzerAnlage")
            Me.BenutzerRolleBindingSource = New System.Windows.Forms.BindingSource(Me.WbaDataSet, "BenutzerRolle")

            Me.WbaDataSet.EnforceConstraints = False

            Me.BenutzerTableAdapter.Fill(Me.WbaDataSet.Benutzer)
            Me.AnlageTableAdapter.Fill(Me.WbaDataSet.Anlage)
            Me.RolleTableAdapter.Fill(Me.WbaDataSet.Rolle)
            Me.BenutzerRolleTableAdapter.Fill(Me.WbaDataSet.BenutzerRolle)
            Me.BenutzerAnlageTableAdapter.Fill(Me.WbaDataSet.BenutzerAnlage)

            Me.BenutzerTreeView.ShowNodeToolTips = True
            CreateBenutzerBindingHandler(BenutzerBindingSource)

            Me.BenutzerCountToolStripStatusLabel.Text = Me.WbaDataSet.Benutzer.Count.ToString
            'Me.dgvAnlagen.Controls(1).Visible = True
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "....Überladene Version von ShowDialg"

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

#Region "....Eventhandler für die Benutzer Bindingsource"

    ''' <summary>
    ''' Die Eventhandler für die Bindingsource installieren
    ''' </summary>
    ''' <param name="bs"> Die BindingSource, auf deren Änderungen reagiert werden soll.</param>
    ''' <remarks></remarks>
    Private Sub CreateBenutzerBindingHandler(bs As BindingSource)
        AddHandler bs.CurrentChanged, AddressOf RefreshBenutzerBinding
        'AddHandler bs.BindingComplete, AddressOf RefreshBenutzerBinding
        'AddHandler bs.ListChanged, AddressOf RefreshBenutzerBinding

        'Me.dgvAnlagen_CurrentCellChanged(dgvAnlagen, System.EventArgs.Empty)
        RefreshAnlagen()
        RefreshRollen()
        DoTreeView()
    End Sub

    ''' <summary>
    ''' Der Bindinghandler für die Anlagen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Sub RefreshBenutzerBinding(sender As System.Object, e As System.EventArgs)
        RefreshAnlagen()
        DoTreeView()
    End Sub
#End Region

#Region "....Die Anlagen aktualisieren"

    ''' <summary>
    ''' Den DataGridView für die WB-Anlagen aktualisieren
    ''' Die Benutzer-ID in Member speichern
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshAnlagen()

        If WbaDataSet.Benutzer.Count > 0 Then

            Dim drv As DataRowView = BenutzerBindingSource.Current
            Dim pRow As BenutzerRow = CType(drv.Row, BenutzerRow)

            ' Aktuell gewählter Benutzer
            _Benutzer_Id = pRow.Id
            _BenutzerGewaehlt = pRow.Vorname & " " & pRow.Name

            'If pRow.Gesperrt > 0 Then
            '    Me.BenutzerToolStripStatusLabel.Text = "Gewählter Benutzer: " & _Benutzer & " ( gesperrt )"
            'Else
            '    Me.BenutzerToolStripStatusLabel.Text = "Gewählter Benutzer: " & _Benutzer
            'End If

            ' EquiJoin: Alle vergebenen Anlagen für aktuell gewählten Benutzer
            Dim query = From ba In WbaDataSet.BenutzerAnlage
                        Where ba.Benutzer_Id = _Benutzer_Id
                        Join a In WbaDataSet.Anlage
                        On a.Id Equals ba.Anlage_Id
                        Select New With {.Id = ba.Anlage_Id,
                                         .Bezeichnung = a.Bezeichnung}

            Me.AnlagenDataGridView.DataSource = query.ToList()
            Me.AnlagenDataGridView.Columns(0).Width = 25
            Me.AnlagenDataGridView.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ' In Abhängigkeit der Sichtbarkeit des vertikalen Scrollbars die Breite setzen (horizontaler Scrollbar = Controls(0))
            Me.AnlagenDataGridView.Columns(1).Width = If(Me.AnlagenDataGridView.Controls(1).Visible, 287, 310)
            Me.AnlagenDataGridView.Columns(1).HeaderText = "Anlagenberechtigung"

            RefreshRollen()
        End If
    End Sub
#End Region

#Region "....Die Rollen aktualisieren"

    ''' <summary>
    ''' Den DataGridView für die Benutzerrollen aktualisieren
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshRollen()

        If WbaDataSet.Benutzer.Count > 0 Then
            ' EquiJoin: Alle vergebenen Rollen für aktuell gewählten Benutzer und Anlage
            Dim query = From bbr In WbaDataSet.BenutzerRolle
                        Where bbr.Benutzer_Id = _Benutzer_Id
                        Join br In WbaDataSet.Rolle
                        On br.Id Equals bbr.Rolle_Id
                        Where bbr.Anlage_Id = _Anlage_Id
                        Select New With {.Id = br.Id,
                                         .Code = br.Code,
                                         .Bezeichnung = br.Bezeichnung}

            Me.RollenDataGridView.DataSource = query.ToList()
            Me.RollenDataGridView.Columns(0).Width = 25
            Me.RollenDataGridView.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.RollenDataGridView.Columns(1).Width = 35
            Me.RollenDataGridView.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ' In Abhängigkeit der Sichtbarkeit des vertikalen Scrollbars die Breite setzen (horizontaler Scrollbar = Controls(0))
            Me.RollenDataGridView.Columns(2).Width = If(Me.RollenDataGridView.Controls(1).Visible, 252, 300)
            Me.RollenDataGridView.Columns(2).HeaderText = "Benutzerrolle"
        End If
    End Sub
#End Region

#Region "....Anlagen DataGridView CurrentCellChanged Ereignis"

    ''' <summary>
    ''' Die Aktuelle Zeile im DataGridView der Anlagen hat sich geändert
    ''' Die Anlagen-ID in Member speichern
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AnlagenDataGridView_CurrentCellChanged(sender As System.Object, e As System.EventArgs) Handles AnlagenDataGridView.CurrentCellChanged

        Dim dgvr As System.Windows.Forms.DataGridViewRow = DirectCast(sender, DataGridView).CurrentRow

        If dgvr IsNot Nothing Then
            ' Aktuell gewählte Anlage
            _Anlage_Id = dgvr.Cells(0).Value
            _Anlage = dgvr.Cells(1).Value
            'Me.AddAnlage.Enabled = True
            'Me.RemoveAnlage.Enabled = True
            RefreshRollen()
        Else
            ' Keine Anlage zugewiesen
            _Anlage_Id = 0
            _Anlage = String.Empty
            'Me.AddAnlage.Enabled = False
            'Me.RemoveAnlage.Enabled = False
        End If
    End Sub
#End Region

#Region "....Den TreeView aktualisieren"

    ''' <summary>
    ''' Die Baumdarstellung der Benutzer aktualisieren
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DoTreeView()
        Try
            ' Alle Knoten im TreeView löschen
            Me.BenutzerTreeView.Nodes.Clear()

            ' Nur ausführen, wenn es auch Benutzer gibt
            If Me.BenutzerBindingSource.Count > 0 Then
                Dim i As Integer ' Index des jeweiligen Hauptknotens

                Me.BenutzerTreeView.BeginUpdate()

                ' Für jeden Benutzer einen Knoten aufbauen
                For Each pRow As DataRowView In Me.BenutzerBindingSource

                    ' Der Elternknoten enthält den Namen und den Vornamen des Benutzers
                    i = Me.BenutzerTreeView.Nodes.Add(New TreeNode(pRow("Name") & ", " & pRow("Vorname")))
                    Me.BenutzerTreeView.Nodes(i).Name = pRow("Id").ToString  ' Der Name des Knotens ist die Id
                    Me.BenutzerTreeView.Nodes(i).ImageIndex = 15
                    Me.BenutzerTreeView.Nodes(i).SelectedImageIndex = Me.BenutzerTreeView.Nodes(i).ImageIndex

                    If pRow("Gesperrt") Then ' Wenn Benutzer gesperrt, dann Name in rot
                        Me.BenutzerTreeView.Nodes(i).ForeColor = Color.Red
                    End If

                    ' Der 1. Kindknoten enthält die Ausweisnummer
                    Me.BenutzerTreeView.Nodes(i).Nodes.Add(New TreeNode(pRow("Ausweis")))
                    Me.BenutzerTreeView.Nodes(i).Nodes(0).ToolTipText = "Die Ausweisnummer"
                    Me.BenutzerTreeView.Nodes(i).Nodes(0).ImageIndex = 10
                    Me.BenutzerTreeView.Nodes(i).Nodes(0).SelectedImageIndex = Me.BenutzerTreeView.Nodes(i).Nodes(0).ImageIndex

                    ' Der 2. Kindknoten enthält die ENR
                    Me.BenutzerTreeView.Nodes(i).Nodes.Add(New TreeNode(pRow("ENR")))
                    Me.BenutzerTreeView.Nodes(i).Nodes(1).ToolTipText = "Die Prüfernummer"
                    Me.BenutzerTreeView.Nodes(i).Nodes(1).ImageIndex = 12
                    Me.BenutzerTreeView.Nodes(i).Nodes(1).SelectedImageIndex = Me.BenutzerTreeView.Nodes(i).Nodes(1).ImageIndex

                    ' Der 3. Kindknoten enthält den SAP User
                    Me.BenutzerTreeView.Nodes(i).Nodes.Add(New TreeNode(pRow("SAP")))
                    Me.BenutzerTreeView.Nodes(i).Nodes(2).ToolTipText = "Der SAP-Benutzername"
                    Me.BenutzerTreeView.Nodes(i).Nodes(2).ImageIndex = 9
                    Me.BenutzerTreeView.Nodes(i).Nodes(2).SelectedImageIndex = Me.BenutzerTreeView.Nodes(i).Nodes(2).ImageIndex

                    ' Der 4. Kindknoten enthält die Sperre
                    If pRow("Gesperrt") Then
                        Me.BenutzerTreeView.Nodes(i).Nodes.Add(New TreeNode("gesperrt"))
                        Me.BenutzerTreeView.Nodes(i).Nodes(3).ForeColor = Color.Red
                        Me.BenutzerTreeView.Nodes(i).Nodes(3).ImageIndex = 7
                    Else
                        Me.BenutzerTreeView.Nodes(i).Nodes.Add(New TreeNode("nicht gesperrt"))
                        Me.BenutzerTreeView.Nodes(i).Nodes(3).ImageIndex = 8
                    End If

                    Me.BenutzerTreeView.Nodes(i).Nodes(3).ToolTipText = "Benutzer gesperrt/nicht gesperrt"
                    Me.BenutzerTreeView.Nodes(i).Nodes(3).SelectedImageIndex = Me.BenutzerTreeView.Nodes(i).Nodes(3).ImageIndex
                Next

                Me.BenutzerTreeView.EndUpdate()

                ' Den aktuellen Knoten selektieren
                Me.BenutzerTreeView.SelectedNode = Me.BenutzerTreeView.Nodes(Me.BenutzerBindingSource.Position)
                Me.BenutzerTreeView.SelectedNode.EnsureVisible()
                Me.BenutzerTreeView.Select()
            End If
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "....Das TreeView AfterSelect Ereignis"

    ''' <summary>
    ''' Die Position in der BindingSourde mit der Position im TreeView synchronisieren
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub trvBenutzer_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles BenutzerTreeView.AfterSelect
        ' Die Position der BindingSource entsprechend des selektierten Knotens setzen
        ' Name = Id, Unterknoten sind leer
        If e.Action <> TreeViewAction.Unknown Then
            If e.Node.Name <> String.Empty Then
                Me.BenutzerBindingSource.Position = e.Node.Index
            End If
        End If
    End Sub
#End Region

#Region "....Die Daten speichern"

    ''' <summary>
    ''' Änderungen in der Datenbank aktualisieren
    ''' </summary>
    ''' <remarks></remarks>
    Private Function SaveData(bs As BindingSource) As Integer
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

#Region "....Neuen Benutzer anlegen"

    ''' <summary>
    ''' Neuen Benutzer anlegen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub NeuerBenutzer()
        Dim eb As New FormBenutzerBearbeiten

        ' Eine neue DataRow
        Dim newRow = Me.WbaDataSet.Benutzer.NewBenutzerRow

        ' Der Bearbeitendialog gibt eine entsprechende DataRow zurück
        Dim result As BenutzerRow = eb.DatenBearbeiten(Me.WbaDataSet, _BenutzerAngemeldet, newRow)

        ' Gibt es eine DataRow, dann...
        If result IsNot Nothing Then
            Try
                ' ...die Daten aktualisieren
                newRow.Name = result.Name
                newRow.Vorname = result.Vorname
                newRow.Ausweis = result.Ausweis
                newRow.ENR = result.ENR
                newRow.SAP = result.SAP
                newRow.Gesperrt = result.Gesperrt
                newRow.PWD = String.Empty

                ' Die neue DataRow zur Liste hinzufügen
                Me.WbaDataSet.Benutzer.AddBenutzerRow(newRow)

                If Me.SaveData(BenutzerBindingSource) > 0 Then
                    Dim entry As String = String.Format("{0} {1} hat Benutzer '{2}' hinzugefügt{3}", _
                                                        DateTime.Now, _BenutzerAngemeldet.Name, result.Vorname & " " & result.Name, ControlChars.CrLf)
                    Me.QueriesTableAdapter.spBenutzerAppendHistory(newRow.Id, entry)

                    ' Die Datasource auf den neuen Datensatz positionieren
                    Me.BenutzerBindingSource.Position = Me.BenutzerBindingSource.Find("Name", result.Name)

                    DoTreeView()
                End If
            Catch ex As Exception
                Logging.WriteEntry(ex.Message, TraceEventType.Error)
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
#End Region

#Region "....Vorhandenen Benutzer bearbeiten"

    ''' <summary>
    ''' Aktuellen Benutzer bearbeiten
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BenutzerBearbeiten()
        Dim eb As New FormBenutzerBearbeiten

        ' Die DataRow mit dem aktuellen Benutzer
        Dim drv As DataRowView = CType(Me.BenutzerBindingSource.Current, DataRowView)
        Dim currRow As BenutzerRow = CType(drv.Row, BenutzerRow)

        ' Der Bearbeitendialog gibt eine entsprechende DataRow zurück
        Dim result As BenutzerRow = eb.DatenBearbeiten(Me.WbaDataSet, _BenutzerAngemeldet, currRow)

        ' Gibt es eine DataRow, dann...
        If result IsNot Nothing Then
            ' ...die Daten aktualisieren
            Try
                If currRow.Name <> result.Name Then
                    Me.QueriesTableAdapter.spBenutzerAppendHistory(currRow.Id, Me.GetHistoryEntry(_BenutzerAngemeldet.Name, "Name", currRow.Name, result.Name))
                    currRow.Name = result.Name
                End If

                If currRow.Vorname <> result.Vorname Then
                    Me.QueriesTableAdapter.spBenutzerAppendHistory(currRow.Id, Me.GetHistoryEntry(_BenutzerAngemeldet.Name, "Vorname", currRow.Vorname, result.Vorname))
                    currRow.Vorname = result.Vorname
                End If

                If currRow.Ausweis <> result.Ausweis Then
                    Me.QueriesTableAdapter.spBenutzerAppendHistory(currRow.Id, Me.GetHistoryEntry(_BenutzerAngemeldet.Name, "Ausweis", currRow.Ausweis, result.Ausweis))
                    currRow.Ausweis = result.Ausweis
                End If

                If currRow.ENR <> result.ENR Then
                    Me.QueriesTableAdapter.spBenutzerAppendHistory(currRow.Id, Me.GetHistoryEntry(_BenutzerAngemeldet.Name, "ENR", currRow.ENR, result.ENR))
                    currRow.ENR = result.ENR
                End If

                If currRow.SAP <> result.SAP Then
                    Me.QueriesTableAdapter.spBenutzerAppendHistory(currRow.Id, Me.GetHistoryEntry(_BenutzerAngemeldet.Name, "SAP", currRow.SAP, result.SAP))
                    currRow.SAP = result.SAP
                End If

                If currRow.Gesperrt <> result.Gesperrt Then
                    Me.QueriesTableAdapter.spBenutzerAppendHistory(currRow.Id, Me.GetHistoryEntry(_BenutzerAngemeldet.Name, "Gesperrt", currRow.Gesperrt.ToString, result.Gesperrt.ToString))
                    currRow.Gesperrt = result.Gesperrt
                End If
            Catch ex As Exception
                Logging.WriteEntry(ex.Message, TraceEventType.Error)
                MsgBox(ex.Message)
            End Try

            If Me.SaveData(BenutzerBindingSource) > 0 Then
                'MessageBox.Show(String.Format("Daten von Benutzer {0} {1} wurden geändert!", aktRow.U_VORNAME, aktRow.U_NAME))
                DoTreeView()
            End If
        End If
    End Sub
#End Region

#Region "....History String bilden"

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

#Region "....Die Menü Click Ereignisse"

    ''' <summary>
    ''' Den Dialo schliessen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EndeMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EndeMenuItem.Click

        Me.Close()
    End Sub

    ''' <summary>
    ''' Neuen Benutzer anlegen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BenutzerNew_Click(sender As System.Object, e As System.EventArgs) Handles BenutzerNew.Click

        Me.NeuerBenutzer()
        Me.BenutzerCountToolStripStatusLabel.Text = Me.WbaDataSet.Benutzer.Count.ToString
    End Sub

    ''' <summary>
    ''' Aktuellen Benutzer löschen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BenutzerDelete_Click(sender As System.Object, e As System.EventArgs) Handles BenutzerDelete.Click

        If (MessageBox.Show(Me, "Benutzer wirlich löschen?", Me.Text, _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then

            Me.BenutzerBindingSource.RemoveCurrent()
            Dim result As Integer = Me.SaveData(Me.BenutzerBindingSource)
            Me.BenutzerCountToolStripStatusLabel.Text = Me.WbaDataSet.Benutzer.Count.ToString
        End If
    End Sub

    ''' <summary>
    ''' Aktuellen Benutzer bearbeiten
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BenutzerEdit_Click(sender As System.Object, e As System.EventArgs) Handles BenutzerEdit.Click

        If Me.WbaDataSet.Benutzer.Count > 0 Then
            Me.BenutzerBearbeiten()
        End If
    End Sub

    ''' <summary>
    ''' Dem aktuellen Benutzer eine neue Anlage zuordnen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AnlageAdd_Click(sender As System.Object, e As System.EventArgs) Handles AnlageAdd.Click

        Dim ar As New FormBenutzerAnlagenRollen
        Dim wbaId As Integer = ar.AddAnlage(_Benutzer_Id, _BenutzerGewaehlt, WbaDataSet)

        If wbaId > 0 Then
            ' Die Anlage hinzufügen
            Dim newRow = Me.WbaDataSet.BenutzerAnlage.NewBenutzerAnlageRow

            newRow.Benutzer_Id = _Benutzer_Id
            newRow.Anlage_Id = wbaId
            Me.WbaDataSet.BenutzerAnlage.Rows.Add(newRow)
            Me.SaveData(Me.BenutzerAnlageBindingSource)

            Try
                Dim query As AnlageRow = (From a In Me.WbaDataSet.Anlage
                                          Where a.Id = wbaId
                                          Select a).Single

                Dim entry As String = String.Format("{0} {1} hat die Anlage '{2}' hinzugefügt{3}", _
                                                    DateTime.Now, _BenutzerAngemeldet.Name, query.Bezeichnung, ControlChars.CrLf)
                Me.QueriesTableAdapter.spBenutzerAppendHistory(_Benutzer_Id, entry)
            Catch ex As Exception
                Logging.WriteEntry(ex.Message, TraceEventType.Error)
                MsgBox(ex.Message)
            End Try

            Me.RefreshAnlagen()
        End If
    End Sub

    ''' <summary>
    ''' Beim aktuellen Benutzer die selektierte Anlage entfernen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AnlageRemove_Click(sender As System.Object, e As System.EventArgs) Handles AnlageRemove.Click

        'Dim count As Integer = Me.dgvAnlagen.RowCount

        ' Nur ausführen, wenn überhaupt Anlagen für den gewählten Benutzer vergeben sind
        If Me.AnlagenDataGridView.RowCount > 0 Then
            Dim can_remove As Boolean = True

            ' Sind Rollen für die Anlage vergeben, dann Sicherheitsabfrage
            If Me.RollenDataGridView.RowCount > 0 Then
                Dim msgstring As String = String.Format("für die Anlage '{0}' sind{1}{2} Benutzerrollen vergeben.{3}Soll die Anlage trotzdem entfernt werden ?", _
                                                        Strings.Trim(Me.AnlagenDataGridView.CurrentRow.Cells(1).Value), ControlChars.CrLf, Me.RollenDataGridView.RowCount, ControlChars.CrLf)

                If MessageBox.Show(Me, msgstring, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                    can_remove = False
                End If
            End If

            ' Anlage entfernen, wenn True
            If can_remove Then
                Try
                    Me.BenutzerRolleBindingSource.Filter = String.Format("Benutzer_Id = {0} AND Anlage_Id = {1}", _Benutzer_Id, _Anlage_Id)

                    For Each br In Me.BenutzerRolleBindingSource
                        Me.BenutzerRolleBindingSource.RemoveCurrent()
                    Next

                    Me.BenutzerRolleBindingSource.EndEdit()

                    Me.BenutzerAnlageBindingSource.Filter = String.Format("Benutzer_Id = {0} AND Anlage_Id = {1}", _Benutzer_Id, _Anlage_Id)

                    If Me.BenutzerAnlageBindingSource.Count = 1 Then
                        Me.BenutzerAnlageBindingSource.RemoveCurrent()
                    End If

                    Me.SaveData(Me.BenutzerAnlageBindingSource)

                    Try
                        Dim query As AnlageRow = (From a In Me.WbaDataSet.Anlage
                                                  Where a.Id = _Anlage_Id
                                                  Select a).Single

                        Dim entry As String = String.Format("{0} {1} hat die Anlage '{2}' entfernt{3}", _
                                                            DateTime.Now, _BenutzerAngemeldet.Name, query.Bezeichnung, ControlChars.CrLf)
                        Me.QueriesTableAdapter.spBenutzerAppendHistory(_Benutzer_Id, entry)
                    Catch ex As Exception
                        Logging.WriteEntry(ex.Message, TraceEventType.Error)
                        MsgBox(ex.Message)
                    End Try

                    Me.RefreshAnlagen()
                Catch ex As Exception
                    Logging.WriteEntry(ex.Message, TraceEventType.Error)
                    MsgBox(ex.Message)
                Finally
                    Me.BenutzerRolleBindingSource.Filter = String.Empty
                    Me.BenutzerAnlageBindingSource.Filter = String.Empty
                End Try
            End If
        Else
            MessageBox.Show("Keine Anlagenberechtigung für" & ControlChars.CrLf & "den gewählten Benutzer vergeben!")
        End If
    End Sub

    ''' <summary>
    ''' Der selektierten Anlage des aktuellen Benutzers eine neue Rolle zuordnen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RolleAdd_Click(sender As System.Object, e As System.EventArgs) Handles RolleAdd.Click

        ' Nur ausführen, wenn überhaupt Anlagen für den gewählten Benutzer vergeben sind
        If _Anlage_Id > 0 Then
            Dim ar As New FormBenutzerAnlagenRollen
            Dim brId As Integer = ar.AddRolle(_Benutzer_Id, _Anlage_Id, _BenutzerGewaehlt, _Anlage, WbaDataSet)

            If brId > 0 Then
                ' Die Benutzerrolle für Anlage hinzufügen
                Dim newRow = Me.WbaDataSet.BenutzerRolle.NewBenutzerRolleRow

                newRow.Benutzer_Id = _Benutzer_Id
                newRow.Anlage_Id = _Anlage_Id
                newRow.Rolle_Id = brId
                Me.WbaDataSet.BenutzerRolle.Rows.Add(newRow)
                Me.SaveData(Me.BenutzerRolleBindingSource)

                Try
                    Dim query1 As AnlageRow = (From a In Me.WbaDataSet.Anlage
                                               Where a.Id = _Anlage_Id
                                               Select a).Single

                    Dim query2 As RolleRow = (From a In Me.WbaDataSet.Rolle
                                              Where a.Id = brId
                                              Select a).Single

                    Dim entry As String = String.Format("{0} {1} hat die Rolle '{2}' der Anlage '{3}' hinzugefügt{4}", _
                                                        DateTime.Now, _BenutzerAngemeldet.Name, query2.Bezeichnung, query1.Bezeichnung, ControlChars.CrLf)
                    Me.QueriesTableAdapter.spBenutzerAppendHistory(_Benutzer_Id, entry)
                Catch ex As Exception
                    Logging.WriteEntry(ex.Message, TraceEventType.Error)
                    MsgBox(ex.Message)
                End Try

                Me.RefreshRollen()
            End If
        Else
            MessageBox.Show("Keine Anlagenberechtigung für" & ControlChars.CrLf & "den gewählten Benutzer vergeben!")
        End If
    End Sub

    ''' <summary>
    ''' Der selektierten Anlage des aktuellen Benutzers die selektierte Rolle entfernen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RolleRemove_Click(sender As System.Object, e As System.EventArgs) Handles RolleRemove.Click

        ' Nur ausführen, wenn überhaupt Benutzerrollen für die gewählte Anlage vergeben sind
        If Me.RollenDataGridView.RowCount > 0 Then
            Try
                Dim brId As Integer = Me.RollenDataGridView.CurrentRow.Cells(0).Value
                Me.BenutzerRolleBindingSource.Filter = String.Format("Benutzer_Id = {0} AND Anlage_Id = {1} AND Rolle_Id = {2}", _Benutzer_Id, _Anlage_Id, brId)

                If Me.BenutzerRolleBindingSource.Count = 1 Then
                    Me.BenutzerRolleBindingSource.RemoveCurrent()
                    Me.SaveData(Me.BenutzerRolleBindingSource)

                    Try
                        Dim query1 As AnlageRow = (From a In Me.WbaDataSet.Anlage
                                                   Where a.Id = _Anlage_Id
                                                   Select a).Single

                        Dim query2 As RolleRow = (From a In Me.WbaDataSet.Rolle
                                                  Where a.Id = brId
                                                  Select a).Single

                        Dim entry As String = String.Format("{0} {1} hat die Rolle '{2}' der Anlage '{3}' entfernt{4}", _
                                                            DateTime.Now, _BenutzerAngemeldet.Name, query2.Bezeichnung, query1.Bezeichnung, ControlChars.CrLf)
                        Me.QueriesTableAdapter.spBenutzerAppendHistory(_Benutzer_Id, entry)
                    Catch ex As Exception
                        Logging.WriteEntry(ex.Message, TraceEventType.Error)
                        MsgBox(ex.Message)
                    End Try

                    Me.RefreshRollen()
                End If
            Catch ex As Exception
                Logging.WriteEntry(ex.Message, TraceEventType.Error)
                MsgBox(ex.Message)
            Finally
                Me.BenutzerRolleBindingSource.Filter = String.Empty
            End Try
        Else
            MessageBox.Show("Keine Benutzerrollen für" & ControlChars.CrLf & "die gewählte Anlage vergeben!")
        End If
    End Sub

    ''' <summary>
    ''' Die Historie des aktuellen Benutzers anzeigen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub HistoryMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HistoryMenuItem.Click

        With New FormHistory
            .ShowHistory(BenutzerBindingSource)
        End With
    End Sub

#End Region

End Class
