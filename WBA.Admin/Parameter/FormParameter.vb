Imports WBA.Admin.wbadminDataSet

Public Class FormParameter

    Public _BenutzerAngemeldet As Benutzer = Nothing
    Private _Warmbehandlung_Id As Integer

    ' Das DataSet
    Friend WithEvents WbaDataSet As WBA.Admin.wbadminDataSet = Nothing

    ' Die TableAdapter
    Friend WarmbehandlungTableAdapter As wbadminDataSetTableAdapters.WarmbehandlungTableAdapter = Nothing
    Friend ParameterTableAdapter As wbadminDataSetTableAdapters.ParameterTableAdapter = Nothing
    Friend TableAdapterManager As wbadminDataSetTableAdapters.TableAdapterManager = Nothing
    Friend QueriesTableAdapter As wbadminDataSetTableAdapters.QueriesTableAdapter = Nothing

    ' Die BindingSources
    Friend WithEvents WarmbehandlungBindingSource As BindingSource = Nothing
    Friend WithEvents ParameterBindingSource As BindingSource = Nothing

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

#Region ".....Das Formular wird geladen"

    ''' <summary>
    ''' Das Formular wird geladen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FormParameter_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.WbaDataSet = New WBA.Admin.wbadminDataSet()

            Me.WarmbehandlungTableAdapter = New WBA.Admin.wbadminDataSetTableAdapters.WarmbehandlungTableAdapter()
            Me.ParameterTableAdapter = New WBA.Admin.wbadminDataSetTableAdapters.ParameterTableAdapter()
            Me.TableAdapterManager = New WBA.Admin.wbadminDataSetTableAdapters.TableAdapterManager()
            Me.QueriesTableAdapter = New WBA.Admin.wbadminDataSetTableAdapters.QueriesTableAdapter()

            Me.TableAdapterManager.AnlageTableAdapter = Nothing
            Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
            Me.TableAdapterManager.BauteilTableAdapter = Nothing
            Me.TableAdapterManager.BauteilWarmbehandlungTableAdapter = Nothing
            Me.TableAdapterManager.BenutzerAnlageTableAdapter = Nothing
            Me.TableAdapterManager.BenutzerRolleTableAdapter = Nothing
            Me.TableAdapterManager.BenutzerTableAdapter = Nothing
            Me.TableAdapterManager.ParameterTableAdapter = Me.ParameterTableAdapter
            Me.TableAdapterManager.ProgrammTableAdapter = Nothing
            Me.TableAdapterManager.RolleTableAdapter = Nothing
            Me.TableAdapterManager.WarmbehandlungTableAdapter = Me.WarmbehandlungTableAdapter

            Me.WarmbehandlungBindingSource = New System.Windows.Forms.BindingSource(Me.WbaDataSet, "Warmbehandlung")
            Me.ParameterBindingSource = New System.Windows.Forms.BindingSource(Me.WarmbehandlungBindingSource, "FK_Parameter_Warmbehandlung")

            Me.WbaDataSet.EnforceConstraints = False
            Me.WarmbehandlungTableAdapter.Fill(Me.WbaDataSet.Warmbehandlung)
            Me.ParameterTableAdapter.Fill(Me.WbaDataSet.Parameter)

            ' Nach Lösungsglühen filtern
            Me.WarmbehandlungBindingSource.Filter = "Verfahren = 0"
            Me.WarmbehandlungBindingSource.Position = 0
            Me.ParameterToolStripStatusLabel.Text = Me.WarmbehandlungBindingSource.Count.ToString
            Me.DoTreeView()
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.Message)
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
            MsgBox(ex.Message)
            Return 0
        End Try
    End Function
#End Region

#Region ".....Neue Parameter anlegen"

    ''' <summary>
    ''' Neuen Parameter Datensatz anlegen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub NeuerParameter()
        Try
            ' Ein neues Formular
            Dim newParam As New FormParameterBearbeiten

            ' Eine neue DataRow
            Dim newRow = Me.WbaDataSet.Warmbehandlung.NewWarmbehandlungRow

            ' Der Bearbeitendialog gibt eine entsprechende DataRow zurück
            Dim result As WarmbehandlungRow = newParam.DatenBearbeiten(Me, newRow)

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
                    Dim entry As String = String.Format("{0} {1} hat WB-Parameter '{2}' hinzugefügt{3}", _
                                                        DateTime.Now, _BenutzerAngemeldet.Name, result.Name, ControlChars.CrLf)
                    Me.QueriesTableAdapter.spWarmbehandlungAppendHistory(newRow.Id, entry)
                End If

                ' Die Parameter für den neuen Datensatz erzeugen
                Me.MacheParameter(newRow.Name)

                ' Die Datasource auf den neuen Datensatz positionieren
                Me.ParameterBindingSource.Position = Me.ParameterBindingSource.Find("Name", result.Name)

                DoTreeView() ' TreeView entsprechend aktualisieren
            End If
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region ".....Vorhandene Parameter bearbeiten"

    ''' <summary>
    ''' Gewählten Parameter Datensatz bearbeiten
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ParameterBearbeiten()
        Try
            Dim editParam As New FormParameterBearbeiten

            ' Die DataRow mit dem aktuellen Benutzer
            Dim drv As DataRowView = CType(Me.WarmbehandlungBindingSource.Current, DataRowView)
            Dim currRow As WarmbehandlungRow = CType(drv.Row, WarmbehandlungRow)

            ' Der Bearbeitendialog gibt eine entsprechende DataRow zurück
            Dim result As WarmbehandlungRow = editParam.DatenBearbeiten(Me, currRow)

            ' Gibt es eine DataRow, dann...
            If result IsNot Nothing Then
                ' ...die Daten aktualisieren
                If currRow.Verfahren <> result.Verfahren Then
                    Me.QueriesTableAdapter.spWarmbehandlungAppendHistory(currRow.Id, Me.GetHistoryEntry(_BenutzerAngemeldet.Name, "Verfahren", currRow.Verfahren, result.Verfahren))
                    currRow.Verfahren = result.Verfahren
                End If

                If currRow.Freigabe <> result.Freigabe Then
                    Me.QueriesTableAdapter.spWarmbehandlungAppendHistory(currRow.Id, Me.GetHistoryEntry(_BenutzerAngemeldet.Name, "Freigabe", currRow.Freigabe.ToString, result.Freigabe.ToString))
                    currRow.Freigabe = result.Freigabe
                End If

                If currRow.Gesperrt <> result.Gesperrt Then
                    Me.QueriesTableAdapter.spWarmbehandlungAppendHistory(currRow.Id, Me.GetHistoryEntry(_BenutzerAngemeldet.Name, "Gesperrt", currRow.Gesperrt.ToString, result.Gesperrt.ToString))
                    currRow.Gesperrt = result.Gesperrt
                End If

                If currRow.Name <> result.Name Then
                    Me.QueriesTableAdapter.spWarmbehandlungAppendHistory(currRow.Id, Me.GetHistoryEntry(_BenutzerAngemeldet.Name, "Name", currRow.Name, result.Name))
                    currRow.Name = result.Name
                End If

                currRow.Bemerkung = result.Bemerkung

                If Me.SaveData(WarmbehandlungBindingSource) > 0 Then
                    'MessageBox.Show(String.Format("Daten von Benutzer {0} {1} wurden geändert!", aktRow.U_VORNAME, aktRow.U_NAME))
                End If

                DoTreeView() ' TreeView entsprechend aktualisieren
            End If
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region ".....Parameter details bearbeiten"

    ''' <summary>
    ''' Parameter des gewählten Datensatzes bearbeiten
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ParameterDetailsBearbeiten()
        Try
            Dim editParam As New FormParameterDetailsBearbeiten

            ' Die DataRow mit dem aktuellen Benutzer
            Dim drv As DataRowView = CType(Me.ParameterBindingSource.Current, DataRowView)
            Dim currRow As ParameterRow = CType(drv.Row, ParameterRow)

            ' Der Bearbeitendialog gibt eine entsprechende DataRow zurück
            Dim result As ParameterRow = editParam.DatenBearbeiten(Me.WbaDataSet, currRow)

            ' Gibt es eine DataRow, dann...
            If result IsNot Nothing Then
                ' ...die Daten aktualisieren
                currRow.Sollwert = result.Sollwert
                currRow.Gluehzeit = result.Gluehzeit
                currRow.Abschreckzeit = result.Abschreckzeit
                currRow.Aufheizzeit = result.Aufheizzeit

                If Me.SaveData(WarmbehandlungBindingSource) > 0 Then
                    'MessageBox.Show(String.Format("Daten von Benutzer {0} {1} wurden geändert!", aktRow.U_VORNAME, aktRow.U_NAME))
                End If
            End If
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region ".....Detail Datensatz für Parameter anlegen"

    ''' <summary>
    ''' Für den gerade angelegten Parameter Datensatz den Eintrag in der Detailtabelle erzeugen
    ''' </summary>
    ''' <param name="prgName"></param>
    ''' <remarks></remarks>
    Private Sub MacheParameter(ByVal prgName As String)
        Try
            ' Den zuletzt eingefügten Datensatz über den Namen finden, damit seine Id verfügbar ist
            Dim drv As DataRowView = CType(Me.WarmbehandlungBindingSource(Me.WarmbehandlungBindingSource.Find("Name", prgName)), DataRowView)
            Dim row = Me.WbaDataSet.Parameter.NewParameterRow

            With row
                .Sollwert = 0
                .Gluehzeit = 0
                .Abschreckzeit = 0
                .Aufheizzeit = 0
                .Warmbehandlung_Id = CType(drv.Row, WarmbehandlungRow).Id ' Der Fremdschlüssel!
            End With

            Me.WbaDataSet.Parameter.AddParameterRow(row)
            Me.SaveData(ParameterBindingSource)
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.Message)
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

#Region ".....Warmbehandlung kopieren"

    ''' <summary>
    ''' Eine Warmbehandlungsvorschrift unter neuem Namen kopieren
    ''' </summary>
    ''' <param name="name">der neue Name</param>
    ''' <remarks></remarks>
    Private Sub KopiereWarmbehandlung(name As String)
        Try
            Dim rowOldWarmbehandlung As WarmbehandlungRow = Nothing
            Dim rowOldParameter As DataRow = Nothing

            rowOldWarmbehandlung = Me.WbaDataSet.Warmbehandlung.FindById(Me._Warmbehandlung_Id)

            Dim query = (From prg In Me.WbaDataSet.Parameter _
                         Where prg.Warmbehandlung_Id = Me._Warmbehandlung_Id _
                         Select prg).Single

            rowOldParameter = query

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
                Dim entry As String = String.Format("{0} {1} hat WB-Parameter '{2}' nach {3} kopiert{4}", _
                                                    DateTime.Now, _BenutzerAngemeldet.Name, rowOldWarmbehandlung.Name, name, ControlChars.CrLf)
                Me.QueriesTableAdapter.spWarmbehandlungAppendHistory(newRow.Id, entry)
                Me.WbaDataSet.Warmbehandlung.AcceptChanges()
            End If

            ' Den Parameter-Datensatz hinzufügen
            Dim row = Me.WbaDataSet.Parameter.NewParameterRow

            With row
                .Sollwert = rowOldParameter.Item("Sollwert")
                .Gluehzeit = rowOldParameter.Item("Gluehzeit")
                .Aufheizzeit = rowOldParameter.Item("Aufheizzeit")
                .Abschreckzeit = rowOldParameter.Item("Abschreckzeit")
                .Warmbehandlung_Id = newRow.Id ' Der Fremdschlüssel!
            End With

            Me.WbaDataSet.Parameter.AddParameterRow(row)

            ' Die Abschnitte speichern
            Me.SaveData(ParameterBindingSource)

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

#Region ".....TreeView aktualisieren"

    ''' <summary>
    ''' Die Baumdarstellung der Parameter aktualisieren
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DoTreeView()
        Try
            ' Alle Knoten im TreeView löschen
            Me.trvWarmbehandlung.Nodes.Clear()

            ' Nur ausführen, wenn es auch Parameter gibt
            If Me.WarmbehandlungBindingSource.Count > 0 Then
                Dim i As Integer ' Index des jeweiligen Hauptknotens

                Me.trvWarmbehandlung.BeginUpdate()

                ' Für jeden Parameter Datensatz einen Knoten aufbauen (BindingSource wird duch ComboBox gefiltert)
                For Each pRow As DataRowView In Me.WarmbehandlungBindingSource
                    If pRow("Verfahren") = 0 Then
                        ' Der Elternknoten enthält den Namen des Parameter Datensatzes
                        i = Me.trvWarmbehandlung.Nodes.Add(New TreeNode(pRow("Name")))
                        Me.trvWarmbehandlung.Nodes(i).Name = pRow("Id").ToString  ' Der Name des Knotens ist die Id
                        'Me.trvWarmbehandlung.Nodes(i).ImageIndex = 6

                        If pRow("Gesperrt") Then ' Ist der Datensatz gesperrt, dann Name in rot
                            Me.trvWarmbehandlung.Nodes(i).ForeColor = Color.Red
                        End If

                        ' Ist der Datensatz nicht freigegeben, dann Name in blau, ausser er ist gesperrt
                        If Not pRow("Freigabe") AndAlso Not pRow("Gesperrt") Then
                            Me.trvWarmbehandlung.Nodes(i).ForeColor = Color.Blue
                        End If

                        ' Der 1. Kindknoten enthält die Freigabe
                        If pRow("Freigabe") Then
                            Me.trvWarmbehandlung.Nodes(i).Nodes.Add(New TreeNode("Freigabe"))
                            Me.trvWarmbehandlung.Nodes(i).Nodes(0).ForeColor = Color.Green
                            Me.trvWarmbehandlung.Nodes(i).Nodes(0).ImageIndex = 7
                        Else
                            Me.trvWarmbehandlung.Nodes(i).Nodes.Add(New TreeNode("keine Freigabe"))
                            Me.trvWarmbehandlung.Nodes(i).Nodes(0).ImageIndex = 8
                        End If

                        Me.trvWarmbehandlung.Nodes(i).Nodes(0).SelectedImageIndex = Me.trvWarmbehandlung.Nodes(i).Nodes(0).ImageIndex

                        ' Der 2. Kindknoten enthält die Sperre
                        If pRow("Gesperrt") Then
                            Me.trvWarmbehandlung.Nodes(i).Nodes.Add(New TreeNode("gesperrt"))
                            Me.trvWarmbehandlung.Nodes(i).Nodes(1).ForeColor = Color.Red
                            Me.trvWarmbehandlung.Nodes(i).Nodes(1).ImageIndex = 7
                        Else
                            Me.trvWarmbehandlung.Nodes(i).Nodes.Add(New TreeNode("nicht gesperrt"))
                            Me.trvWarmbehandlung.Nodes(i).Nodes(1).ImageIndex = 8
                        End If

                        Me.trvWarmbehandlung.Nodes(i).Nodes(1).SelectedImageIndex = Me.trvWarmbehandlung.Nodes(i).Nodes(1).ImageIndex
                    End If
                Next

                Me.trvWarmbehandlung.EndUpdate()

                ' Den aktuellen Knoten selektieren
                If Me.trvWarmbehandlung.Nodes.Count > 0 Then
                    Me.trvWarmbehandlung.SelectedNode = Me.trvWarmbehandlung.Nodes(Me.WarmbehandlungBindingSource.Position)
                    Me.trvWarmbehandlung.SelectedNode.EnsureVisible()
                    Me.trvWarmbehandlung.Select()
                End If
            End If
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region ".....Die Anzeige aktualisieren"

    ''' <summary>
    ''' Die Parameter in den Anzeigelabels formatieren
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshParameter()
        If Me.WarmbehandlungBindingSource.Count > 0 Then
            If Me._Warmbehandlung_Id > 0 Then
                Try
                    Dim query = (From params In Me.WbaDataSet.Parameter _
                                 Where params.Warmbehandlung_Id = Me._Warmbehandlung_Id _
                                 Select params).Single

                    Me.SollwertLabel.Text = query.Sollwert.ToString
                    Me.GluehzeitLabel.Text = String.Format("{0,2:D2}:{1,2:D2}", query.Gluehzeit \ 60, query.Gluehzeit Mod 60)
                    Me.AbschreckzeitLabel.Text = query.Abschreckzeit.ToString("00.0")
                    Me.AufheizzeitLabel.Text = String.Format("{0,2:D2}:{1,2:D2}", query.Aufheizzeit \ 60, query.Aufheizzeit Mod 60)
                Catch ex As Exception
                    Logging.WriteEntry(ex.Message, TraceEventType.Error)
                    MsgBox(ex.Message)
                End Try
            End If
        End If
    End Sub
#End Region

#Region ".....Das TreeView AfterSelect Ereignis"

    ''' <summary>
    ''' Die Position in der BindingSourde mit der Position im TreeView synchronisieren
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub WarmbehandlungTreeView_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles trvWarmbehandlung.AfterSelect
        ' Die Position der BindingSource entsprechend des selektierten Knotens setzen
        ' Name = Id, Unterknoten sind leer
        'If e.Action <> TreeViewAction.Unknown Then
        If e.Node.Name <> String.Empty Then
            Me.WarmbehandlungBindingSource.Position = e.Node.Index
            Me.trvWarmbehandlung.Select()
            'Dim drv As DataRowView = CType(Me.bsWarmbehandlung.Current, DataRowView)
            'Dim currRow As WarmbehandlungRow = CType(drv.Row, WarmbehandlungRow)
            Me._Warmbehandlung_Id = Integer.Parse(e.Node.Name) 'currRow.Id
            RefreshParameter()
        End If
        'End If
    End Sub
#End Region

#Region ".....Die Menü Click Ereignisse"

    ''' <summary>
    ''' Der Dialog wird geschlossen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DialogSchliessen_Click(sender As System.Object, e As System.EventArgs) Handles DialogSchliessen.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Ein neuer Parameter Datensatz soll angelegt werden
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BearbeitenNeueParameter_Click(sender As System.Object, e As System.EventArgs) Handles BearbeitenNeuerParameter.Click
        Me.NeuerParameter()
        Me.ParameterToolStripStatusLabel.Text = Me.WarmbehandlungBindingSource.Count.ToString
    End Sub

    ''' <summary>
    ''' Der aktuell gewählte Parameter Datensatz soll bearbeitet werden
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BearbeitenAendernParameter_Click(sender As System.Object, e As System.EventArgs) Handles BearbeitenAendernParameter.Click
        Me.ParameterBearbeiten()
    End Sub

    ''' <summary>
    ''' Der aktuell gewählte Parameter Datensatz soll gelöscht werden
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BearbeitenLoeschenParameter_Click(sender As System.Object, e As System.EventArgs) Handles BearbeitenLoeschenParameter.Click
        If (MessageBox.Show(Me, "Parameter wirlich löschen?", _
                            Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            Try
                Me.WarmbehandlungBindingSource.RemoveCurrent()
                Me.SaveData(Me.WarmbehandlungBindingSource)
                Me.ParameterToolStripStatusLabel.Text = Me.WarmbehandlungBindingSource.Count.ToString
                DoTreeView() ' TreeView entsprechend aktualisieren
            Catch ex As Exception
                Logging.WriteEntry(ex.Message, TraceEventType.Error)
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Die selektierte Warmbehandlungsvorschrift unter neuem Namen kopieren
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BearbeitenKopierenParameter_Click(sender As System.Object, e As System.EventArgs) Handles BearbeitenKopierenParameter.Click
        ' Die DataRow mit der selektierten Vorschrift
        Dim drv As DataRowView = DirectCast(Me.WarmbehandlungBindingSource.Current, DataRowView)
        Dim row As WarmbehandlungRow = DirectCast(drv.Row, WarmbehandlungRow)


        If (MessageBox.Show(Me, String.Format("Soll die Vorschrift '{0}' unter neuem Namen kopiert werden?", row.Name), _
                            Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then

            Dim result As String = String.Empty

            With New FormVorschriftKopieren
                .Location = Me.PointToScreen(New Point(Me.pnlProgramm.Location.X, Me.pnlProgramm.Location.Y))
                result = .GetName(Me.WbaDataSet, row.Name)

                If result IsNot String.Empty Then
                    Me.KopiereWarmbehandlung(result)
                    Me.ParameterToolStripStatusLabel.Text = Me.WarmbehandlungBindingSource.Count.ToString
                End If
            End With
        End If
    End Sub

    ''' <summary>
    ''' Die Parameter des aktuell gewählten Datensatzes sollen bearbeitet werden
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BearbeitenParameterDetails_Click(sender As System.Object, e As System.EventArgs) Handles BearbeitenParameterDetails.Click
        Me.ParameterDetailsBearbeiten()
    End Sub

    ''' <summary>
    ''' Die History für die aktuelle WB-Vorschrift anzeigen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AnzeigenHistorie_Click(sender As System.Object, e As System.EventArgs) Handles AnzeigenHistorie.Click
        With New FormHistory
            .ShowHistory(WarmbehandlungBindingSource)
        End With
    End Sub
#End Region

End Class