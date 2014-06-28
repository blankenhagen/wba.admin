Imports WBA.Admin.wbadminDataSet
Imports System.Data.SqlClient

Public Class FormHistory

    ''' <summary>
    ''' Die History für Benutzer, Bauteil, Warmbehandlung anzeigen
    ''' </summary>
    ''' <param name="bs">Die entsprechende BindingSource</param>
    ''' <remarks></remarks>
    Public Sub ShowHistory(ByRef bs As BindingSource)
        Using Me
            Dim drv As DataRowView = CType(bs.Current, DataRowView)

            Try
                Select Case drv.Row.Table.TableName
                    Case "Benutzer"
                        Me.Text = "Historie für Benutzer: " & drv.Row.Item("Vorname") & " " & drv.Row.Item("Name")

                    Case "Bauteil"
                        Me.Text = "Historie für Bauteil: HTZ: " & drv.Row.Item("HTZ") & ", IDNR:  " & drv.Row.Item("IDNR")

                    Case "Warmbehandlung"
                        Me.Text = "Historie für Warmbehandlung: " & drv.Row.Item("Name")
                End Select


                Me.tbxHistory.Clear()
                Dim queryString As String = String.Format("SELECT History FROM dbo.{0} WHERE Id = {1};", _
                                                           drv.Row.Table.TableName, drv.Row.Item("Id"))

                Using connection As New SqlConnection(My.Settings.wbadminConnectionString)
                    Dim command As New SqlCommand(queryString, connection)
                    connection.Open()
                    Dim reader As SqlDataReader = command.ExecuteReader()

                    Try
                        While reader.Read()
                            Me.tbxHistory.Text = reader(0).ToString
                        End While
                    Catch ex As Exception
                        Logging.WriteEntry(ex.Message, TraceEventType.Error)
                        MsgBox(ex.ToString)
                    Finally
                        reader.Close()
                    End Try
                End Using
            Catch ex As Exception
                Logging.WriteEntry(ex.Message, TraceEventType.Error)
                MsgBox(ex.ToString)
            End Try

            Me.ShowDialog()
        End Using
    End Sub

    ''' <summary>
    ''' Die History für BauteilWarmbehandlung (EMP) anzeigen
    ''' </summary>
    ''' <param name="Bauteil_Id">Die Id des aktuell gewählten Bauteils</param>
    ''' <param name="Warmbehandlung_Id">Die Id der aktuell gewählten Warmbehandlung</param>
    ''' <param name="bs">Die entsprechende BindingSource</param>
    ''' <param name="ds">Das Dataset</param>
    ''' <remarks></remarks>
    Public Sub ShowHistory(ByVal Bauteil_Id As Integer, ByVal Warmbehandlung_Id As Integer, ByRef bs As BindingSource, ByRef ds As wbadminDataSet)
        Using Me
            bs.Filter = String.Format("Bauteil_Id = {0} AND Warmbehandlung_Id = {1}", Bauteil_Id, Warmbehandlung_Id)

            If bs.Count > 0 Then
                'Dim drv As DataRowView = CType(bs.Current, DataRowView)
                'Dim currRow As BauteilWarmbehandlungRow = CType(drv.Row, BauteilWarmbehandlungRow)
                'Dim btRow As BauteilRow = currRow.GetParentRow(FormBauteil.WbData.Relations("FK_BauteilWarmbehandlung_Bauteil"))

                Try
                    Dim dataset As wbadminDataSet = ds
                    Dim query = (From b In dataset.Bauteil
                                 Where b.Id = Bauteil_Id
                                 From w In dataset.Warmbehandlung
                                 Where w.Id = Warmbehandlung_Id
                                 Select b.HTZ, b.IDNR, w.Name).Single

                    Me.Text = "Historie für Bauteil: HTZ: " & query.HTZ & ", IDNR:  " & query.IDNR & ", WB: " & query.Name
                    Me.tbxHistory.Clear()
                    Dim queryString As String = String.Format("SELECT History FROM dbo.BauteilWarmbehandlung WHERE Bauteil_Id = {0} AND Warmbehandlung_Id = {1};", _
                                                              Bauteil_Id, Warmbehandlung_Id)

                    Using connection As New SqlConnection(My.Settings.wbadminConnectionString)
                        Dim command As New SqlCommand(queryString, connection)
                        connection.Open()
                        Dim reader As SqlDataReader = command.ExecuteReader()

                        Try
                            While reader.Read()
                                Me.tbxHistory.Text = reader(0).ToString
                            End While
                        Catch ex As Exception
                            Logging.WriteEntry(ex.Message, TraceEventType.Error)
                            MsgBox(ex.Message)
                        Finally
                            reader.Close()
                        End Try
                    End Using
                Catch ex As Exception
                    Logging.WriteEntry(ex.Message, TraceEventType.Error)
                    MsgBox(ex.Message)
                Finally
                    bs.RemoveFilter()
                End Try
            End If

            Me.ShowDialog()
        End Using
    End Sub

    ''' <summary>
    ''' Der OK-Button wurde angeklickt
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub
End Class