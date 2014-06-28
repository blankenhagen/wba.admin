Public Class FormBenutzerAnlagenRollen

#Region "....Das Formular wird geladen"

    ''' <summary>
    ''' Das Formular wird geladen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FormBenutzerAnlagenRollen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ' Die Spaltenbreiten setzen (Anlage = 2 Spalten, Rolle = 3 Spalten)
        ' In Abhängigkeit der Sichtbarkeit des vertikalen Scrollbars die Breite setzen (horizontaler Scrollbar = Controls(0))
        If Me.dgvAnlagenRollen.Columns.Count > 2 Then
            Me.dgvAnlagenRollen.Columns(0).Width = 25
            Me.dgvAnlagenRollen.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvAnlagenRollen.Columns(1).Width = 35
            Me.dgvAnlagenRollen.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvAnlagenRollen.Columns(2).Width = If(Me.dgvAnlagenRollen.Controls(1).Visible, 274, 300)
        Else
            Me.dgvAnlagenRollen.Columns(0).Width = 25
            Me.dgvAnlagenRollen.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.dgvAnlagenRollen.Columns(1).Width = If(Me.dgvAnlagenRollen.Controls(1).Visible, 309, 330)
        End If
    End Sub

#End Region

    ''' <summary>
    ''' Dem aktuellen Benutzer eine Anlage zuordnen
    ''' </summary>
    ''' <param name="uid">Der aktuell gewählte Benutzer</param>
    ''' <param name="ds">Referenz auf das Dataset</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AddAnlage(ByVal uid As Integer,
                              ByVal benutzer As String,
                              ByRef ds As wbadminDataSet) As Integer

        Using Me
            Me.Text = "Anlagenberechtigung hinzufügen"
            Me.NameLabel.Text = "für Benutzer: " & benutzer

            ' EquiJoin: Alle vergebenen Anlagen für übergebenen Benutzer
            Dim query = From ba In ds.BenutzerAnlage
                        Where ba.Benutzer_Id = uid
                        Join a In ds.Anlage
                        On a.Id Equals ba.Anlage_Id
                        Select New With {.Id = ba.Anlage_Id,
                                         .Bezeichnung = a.Bezeichnung}

            ' NonEquiJoin: Alle noch nicht vergebenen Anlagen
            Dim query1 = From a In ds.Anlage
                         Let Ids = (From q In query
                                    Select q.Id)
                         Where (Ids.Contains(a.Id) = False)
                         Select New With {.Id = a.Id,
                                          .Bezeichnung = a.Bezeichnung}

            Me.dgvAnlagenRollen.DataSource = query1.ToList()

            If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Return Me.dgvAnlagenRollen.CurrentRow.Cells(0).Value
            Else
                Return 0
            End If
        End Using
    End Function

    ''' <summary>
    ''' Der selektierten Anlage des aktuellen Benutzers eine Rolle zuordnen
    ''' </summary>
    ''' <param name="uid">Der aktuell gewählte Benutzer</param>
    ''' <param name="wbaid">Die aktuell gewählte Anlage</param>
    ''' <param name="ds">Referenz auf das Dataset</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AddRolle(ByVal uid As Integer,
                             ByVal wbaid As Integer,
                             ByVal benutzer As String,
                             ByVal anlage As String,
                             ByRef ds As wbadminDataSet) As Integer

        Using Me
            Me.Text = "Benutzerrolle hinzufügen"
            Me.NameLabel.Text = "für Benutzer: " & benutzer & ControlChars.CrLf & "für Anlage: " & anlage

            ' Alle vergebenen Rollen für übergebenen Benutzer und Anlage
            Dim query = From bbr In ds.BenutzerRolle
                        Where bbr.Benutzer_Id = uid
                        Join br In ds.Rolle
                        On br.Id Equals bbr.Rolle_Id
                        Where bbr.Anlage_Id = wbaid
                        Select New With {.Id = br.Id,
                                         .Bezeichnung = br.Bezeichnung}

            ' Alle noch nicht vergebenen Benutzerrollen
            Dim query1 = From br In ds.Rolle
                         Let Ids = (From q In query
                                    Select q.Id)
                         Where (Ids.Contains(br.Id) = False)
                         Select New With {.Id = br.Id,
                                          .Code = br.Code,
                                          .Bezeichnung = br.Bezeichnung}

            If query1.Count > 0 Then
                Me.dgvAnlagenRollen.DataSource = query1.ToList()

                If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Return Me.dgvAnlagenRollen.CurrentRow.Cells(0).Value
                Else
                    Return 0
                End If
            Else
                Return 0
            End If
        End Using
    End Function

End Class