Imports WBA.Admin.wbadminDataSet

Public Class FormBauteilWarmbehandlung

    ' Diese Member werden in "AddWarmbehandlung" gesetzt
    Private WbaDataSet As wbadminDataSet = Nothing
    Private Bauteil_Id As Integer = 0

    ''' <summary>
    ''' Dem aktuell gewählten Bauteil eine WB-Vorschrift hinzufügen
    ''' </summary>
    ''' <param name="bid"> Das aktuell gewählte Bauteil </param>
    ''' <param name="ds"> Das DataSet </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AddWarmbehandlung(ByVal bid As Integer,
                                      ByRef ds As wbadminDataSet) As Integer
        Using Me
            Bauteil_Id = bid
            WbaDataSet = ds

            Me.Text = "WB-Vorschrift hinzufügen"

            If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Return Me.dgvWarmbehandlung.CurrentRow.Cells(0).Value
            Else
                Return 0
            End If
        End Using
    End Function

    ''' <summary>
    ''' Die Anzeige im DataGridView filtern
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbxFilter_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbxFilter.SelectedIndexChanged

        Select Case DirectCast(sender, ComboBox).SelectedIndex
            Case 0 ' Alle (Lösungsglühen + Weichglühen + Warmauslagern)
                Me.GetWarmbehandlung(-1)

            Case 1 ' Lösungsglühen
                Me.GetWarmbehandlung(0)

            Case 2 ' Weichglühen
                Me.GetWarmbehandlung(1)

            Case 3 ' Warmauslagern
                Me.GetWarmbehandlung(2)
        End Select
    End Sub

    ''' <summary>
    ''' Die nicht zugeordneten WB-Vorschriften holen
    ''' </summary>
    ''' <param name="Filter"> -1 = Alle, 0 = Lösungsglühen, 1 = Weichglühen, 2 = Warmauslagern</param>
    ''' <remarks></remarks>
    Private Sub GetWarmbehandlung(ByVal Filter As Integer)

        Dim query = From wb In WbaDataSet.Warmbehandlung
                    Let Ids = (From btwb In WbaDataSet.BauteilWarmbehandlung
                               Where btwb.Bauteil_Id = Bauteil_Id
                               Select btwb.Warmbehandlung_Id)
                    Where (Ids.Contains(wb.Id) = False) And (wb.Verfahren = Filter Or Filter = -1)
                    Select New With {.Id = wb.Id,
                                     .Warmbehandlung = wb.Name}

        Me.dgvWarmbehandlung.DataSource = query.ToList()

        Me.dgvWarmbehandlung.Columns(0).Visible = False ' "Id" ist unsichtbar!
        Me.dgvWarmbehandlung.Columns(1).Width = 250
    End Sub

    ''' <summary>
    ''' Das Formular wird geladen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FormBauteilWarmbehandlung_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.cbxFilter.Text = Me.cbxFilter.Items(0)
    End Sub
End Class