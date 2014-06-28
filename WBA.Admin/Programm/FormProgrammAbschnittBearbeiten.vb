Imports WBA.Admin.wbadminDataSet

Public Class FormProgrammAbschnittBearbeiten

    Private AbschnittListe As List(Of Abschnitt)
    Private AbschnittListeKopie As List(Of Abschnitt)
    Private CurrentRowIndex As Integer = 0
    Private ProgrammBindingSource As BindingSource
    Private WbData As wbadminDataSet

    ''' <summary>
    ''' Überladene Version von "ShowDialog"
    ''' </summary>
    ''' <param name="ds">das Dataset</param>
    ''' <param name="bs">die Programm BindingSource</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function ShowDialog(ds As wbadminDataSet, bs As BindingSource) As Windows.Forms.DialogResult
        WbData = ds
        ProgrammBindingSource = bs
        ProgrammBindingSource.MoveFirst()

        ' Vorgängermethode aufrufen
        Return MyBase.ShowDialog()
    End Function

    ''' <summary>
    ''' Das Formular wird geladen
    ''' Abschnittslisten erzeugen
    ''' DataGridView formatieren
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FormMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.AbschnittListe = New List(Of Abschnitt)

        Try
            If Me.ProgrammBindingSource.Count > 0 Then
                For Each ab As Object In Me.ProgrammBindingSource.List
                    Me.AbschnittListe.Add(New Abschnitt(ab("Abschnitt"), ab("Sollwert"), ab("Dauer") \ 60, ab("Dauer") Mod 60))
                Next
            End If
        Catch ex As Exception
            Logging.WriteEntry(ex.Message, TraceEventType.Error)
            MsgBox(ex.Message)
        End Try

        Me.AbschnittListeKopie = New List(Of Abschnitt)

        For i As Integer = 0 To Me.AbschnittListe.Count - 1
            Me.AbschnittListeKopie.Add(New Abschnitt(i + 1))
            Me.AbschnittListeKopie(i).Sollwert = Me.AbschnittListe(i).Sollwert
            Me.AbschnittListeKopie(i).Stunden = Me.AbschnittListe(i).Stunden
            Me.AbschnittListeKopie(i).Minuten = Me.AbschnittListe(i).Minuten
        Next

        Me.AbschnittDataGridView.DataSource = Me.AbschnittListe
        Me.AbschnittDataGridView.Columns(0).HeaderText = "#"
        Me.AbschnittDataGridView.Columns(0).Width = 30
        Me.AbschnittDataGridView.Columns(1).HeaderText = "Temp"
        Me.AbschnittDataGridView.Columns(1).Width = 40
        Me.AbschnittDataGridView.Columns(2).HeaderText = "Std."
        Me.AbschnittDataGridView.Columns(2).Width = 40
        Me.AbschnittDataGridView.Columns(3).HeaderText = "Min."
        Me.AbschnittDataGridView.Columns(3).Width = 40
    End Sub

    ''' <summary>
    ''' Die Auswahl im DataGridView hat sich geändert
    ''' Den Zeilenindex merken
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AbschnittDataGridView_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles AbschnittDataGridView.SelectionChanged
        Me.CurrentRowIndex = DirectCast(sender, DataGridView).CurrentRow.Index
    End Sub

    ''' <summary>
    ''' Eine Zeile in der Abschnittsliste löschen
    ''' Die Liste wird auf MaxAbschnitte erweitert
    ''' und die Abschnitte werden neu durchnummeriert
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DeleteButton_Click(sender As System.Object, e As System.EventArgs) Handles DeleteButton.Click

        Me.AbschnittListe.RemoveAt(Me.CurrentRowIndex)
        Me.AbschnittListe.Add(New Abschnitt())

        Me.EnumerateAndRefresh()
    End Sub

    ''' <summary>
    ''' Eine neue Zeile in die Abschnittsliste einfügen
    ''' und zwar vor der selektierten Zeile
    ''' Die Liste wird auf MaxAbschnitte verkürzt
    ''' und die Abschnitte werden neu durchnummeriert
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub InsertButton_Click(sender As System.Object, e As System.EventArgs) Handles InsertButton.Click

        Me.AbschnittListe.Insert(Me.CurrentRowIndex, New Abschnitt())
        Me.AbschnittListe.RemoveAt(Me.AbschnittListe.Count - 1)

        Me.EnumerateAndRefresh()
    End Sub

    ''' <summary>
    ''' Durchnummerieren der Abschnittsliste
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EnumerateAndRefresh()
        Dim i As Integer = 0

        For Each a In Me.AbschnittListe
            i += 1
            a.Nummer = i
        Next

        Me.AbschnittDataGridView.Refresh()
    End Sub

    ''' <summary>
    ''' Das Zellen Validating-Ereignis des DataGridView
    ''' Auf Eingabegrenzen überprüfen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AbschnittDataGridView_CellValidating(sender As System.Object, e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles AbschnittDataGridView.CellValidating
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)

        Select Case e.ColumnIndex
            Case 1 ' Sollwert
                If e.FormattedValue > 600 Then
                    dgv.Rows(e.RowIndex).ErrorText = "Sollwert nur bis 600 erlaubt"
                    e.Cancel = True
                End If

            Case 2 ' Stunden
                If e.FormattedValue > 99 Then
                    dgv.Rows(e.RowIndex).ErrorText = "Stunden nur bis 99 erlaubt"
                    e.Cancel = True
                End If

            Case 3 ' Minuten
                If e.FormattedValue > 59 Then
                    dgv.Rows(e.RowIndex).ErrorText = "Minuten nur bis 59 erlaubt"
                    e.Cancel = True
                End If
        End Select
    End Sub

    ''' <summary>
    ''' Das Zellen EndEdit des DataGridView
    ''' Den Fehlertext löschen, wenn ESC gedrückt wurde
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AbschnittDataGridView_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AbschnittDataGridView.CellEndEdit
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)

        dgv.Rows(e.RowIndex).ErrorText = String.Empty
    End Sub

    ''' <summary>
    ''' Der Dialog soll geschlossen werden
    ''' Die geänderten Zeilen feststellen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FormAbschnitteBearbeiten_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            Try
                Me.ProgrammBindingSource.MoveFirst()

                For i As Integer = 0 To Me.AbschnittListe.Count - 1
                    Dim drv As DataRowView = CType(Me.ProgrammBindingSource.Current, DataRowView)
                    Dim pRow As ProgrammRow = CType(drv.Row, ProgrammRow)

                    If (Me.AbschnittListe(i).Sollwert <> Me.AbschnittListeKopie(i).Sollwert) OrElse _
                       (Me.AbschnittListe(i).Stunden <> Me.AbschnittListeKopie(i).Stunden) OrElse _
                       (Me.AbschnittListe(i).Minuten <> Me.AbschnittListeKopie(i).Minuten) Then

                        pRow.Sollwert = Me.AbschnittListe(i).Sollwert
                        pRow.Dauer = Me.AbschnittListe(i).Stunden * 60 + Me.AbschnittListe(i).Minuten
                    End If

                    Me.ProgrammBindingSource.MoveNext()
                Next

                Me.ProgrammBindingSource.EndEdit()
                Me.ProgrammBindingSource.MoveFirst()
            Catch ex As Exception
                Logging.WriteEntry(ex.Message, TraceEventType.Error)
                MsgBox(ex.Message)
            End Try
        Else
            For i As Integer = 0 To Me.AbschnittListe.Count - 1

                If (Me.AbschnittListe(i).Sollwert <> Me.AbschnittListeKopie(i).Sollwert) OrElse _
                   (Me.AbschnittListe(i).Stunden <> Me.AbschnittListeKopie(i).Stunden) OrElse _
                   (Me.AbschnittListe(i).Minuten <> Me.AbschnittListeKopie(i).Minuten) Then

                    MsgBox("Alle Änderungen werden verworfen!")
                    Exit For
                End If
            Next
        End If
    End Sub

End Class
