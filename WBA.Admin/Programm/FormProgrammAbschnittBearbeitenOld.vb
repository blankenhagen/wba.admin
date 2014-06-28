Imports WBA.Admin.wbadminDataSet

Public Class FormProgrammAbschnittBearbeitenOld

    Private _DataSource As BindingSource
    Private _DataSet As wbadminDataSet

    Private Function GetTotalMinutes(ByVal valStr As String) As Integer
        Return Convert.ToInt32(Strings.Left(valStr, 2)) * 60 + Convert.ToInt32(Strings.Right(valStr, 2))
    End Function

    Private Sub btnEnde_Click(sender As System.Object, e As System.EventArgs) Handles btnEnde.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnEnter_Click(sender As System.Object, e As System.EventArgs) Handles btnEnter.Click

        Dim drv As DataRowView = CType(_DataSource.Current, DataRowView)
        Dim currRow As ProgrammRow = CType(drv.Row, ProgrammRow)
        Dim intValue As Integer

        If currRow.Sollwert <> Integer.Parse(Me.tbxSollwert.Text) Then
            currRow.Sollwert = Integer.Parse(Me.tbxSollwert.Text)
        End If

        If Me.tbxDauer.MaskFull Then
            intValue = Me.GetTotalMinutes(Me.tbxDauer.Text)

            If currRow.Dauer <> TimeSpan.Parse(Me.tbxDauer.Text).TotalMinutes Then
                currRow.Dauer = TimeSpan.Parse(Me.tbxDauer.Text).TotalMinutes
            End If
        Else
            MsgBox("Eingabefehler!")
            Me.tbxDauer.Focus()
            Me.tbxDauer.SelectAll()
            Exit Sub
        End If

        Me.btnRowDown.PerformClick()
        '_DataSource.EndEdit()
        'FormProgramm.ChartAction(currRow.Warmbehandlung_Id)

        Me.tbxSollwert.Focus()
        Me.tbxSollwert.SelectAll()
    End Sub

    Private Sub GetCurrentValues()
        Dim drv As DataRowView = CType(_DataSource.Current, DataRowView)
        Dim currRow As ProgrammRow = CType(drv.Row, ProgrammRow)

        Me.tbxSollwert.Text = currRow.Sollwert.ToString
        Me.tbxDauer.Text = DateTime.MinValue.AddMinutes(currRow.Dauer).ToString("HH:mm")

        Me.tbxSollwert.Focus()
        Me.tbxSollwert.SelectAll()
    End Sub

    Private Sub RowUpRowDown_Click(sender As System.Object, e As System.EventArgs) Handles btnRowUp.Click, btnRowDown.Click
        Try
            Select Case DirectCast(sender, Button).Name
                Case "btnRowUp"
                    If _DataSource.Position > 0 Then
                        _DataSource.MovePrevious()
                    Else
                        _DataSource.MoveLast()
                    End If

                    Me.GetCurrentValues()

                Case "btnRowDown"
                    If _DataSource.Position < 15 Then
                        _DataSource.MoveNext()
                    Else
                        _DataSource.MoveFirst()
                    End If

                    Me.GetCurrentValues()
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBoxes_PreviewKeyDown(sender As System.Object, e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles tbxSollwert.PreviewKeyDown, tbxDauer.PreviewKeyDown
        Select Case e.KeyCode
            Case Keys.PageUp
                Me.btnRowUp.PerformClick()

            Case Keys.PageDown
                Me.btnRowDown.PerformClick()
        End Select
    End Sub

    Public Overloads Function ShowDialog(ByRef ds As wbadminDataSet, ByRef bs As BindingSource) As Windows.Forms.DialogResult
        _DataSet = ds
        _DataSource = bs
        _DataSource.MoveFirst()

        ' Vorgängermethode aufrufen
        Return MyBase.ShowDialog()
    End Function

    Private Sub tbxSollwert_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbxSollwert.TextChanged
        If DirectCast(sender, MaskedTextBox).Text.Length >= 3 Then
            Me.tbxDauer.Focus()
            Me.tbxDauer.SelectAll()
        End If
    End Sub


    Private Sub tbxDauer_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbxDauer.TextChanged
        If DirectCast(sender, MaskedTextBox).Text.Length >= 5 Then
            Me.btnEnter.Focus()
        End If
    End Sub

    Private Sub FormProgrammAbschnittBearbeiten_Activated(sender As System.Object, e As System.EventArgs) Handles MyBase.Activated
        Me.GetCurrentValues()
    End Sub
End Class