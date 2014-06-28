Imports WBA.Admin.wbadminDataSet

Public Class FormAuftrag

    Private _DataSet As wbadminDataSet = Nothing
    Private _AuftragTabelAdapter As wbadminDataSetTableAdapters.AuftragTableAdapter = Nothing
    Private _AuftragBindingSource As BindingSource = Nothing
    Private _Benutzer As Benutzer = Nothing

#Region "....Das Formular wird geladen"

    ''' <summary>
    ''' Das Formular wird geladen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FormAuftrag_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        _DataSet = New wbadminDataSet
        _AuftragTabelAdapter = New wbadminDataSetTableAdapters.AuftragTableAdapter
        _AuftragBindingSource = New BindingSource
        _AuftragBindingSource.DataSource = _DataSet.Auftrag

        AddHandler _AuftragBindingSource.ListChanged, AddressOf Me.RefreshAuftrag

        With Me.AuftragDataGridView
            .DataSource = _AuftragBindingSource
            .Columns(0).Width = 70
            .Columns(1).Width = 170
            .Columns(2).Width = 200
            .Columns(3).Width = 30
            .Columns(4).Width = 90
            .Columns(5).Width = 30
            .Columns(6).Width = 60
            .Columns(7).Width = 60
            .Columns(8).Width = 90
            .Columns(9).Width = 80
            .Columns(10).Width = 30
            .Columns(11).Width = 60
            .Columns(12).Width = 60
            .Columns(13).Width = 80
        End With

        _AuftragTabelAdapter.Fill(_DataSet.Auftrag)

        Me.FilterComboBox.SelectedIndex = -1
        Me.FilterButton.Enabled = False
        Me.ClearButton.Enabled = False
        Me.FilterTextBox.Text = String.Empty

        ' Der Benutzer sollte in Tag übergeben worden sein
        If Me.Tag IsNot Nothing Then
            Me.BenutzerToolStripStatusLabel.Text = DirectCast(Me.Tag, Benutzer).Name
        End If
    End Sub

#End Region

#Region "....Der Auftrag Binding Handler"

    ''' <summary>
    ''' Der Auftrag Binding Handler
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshAuftrag()
        Me.AuftraegeToolStripStatusLabel.Text = _AuftragBindingSource.Count
    End Sub

#End Region

#Region "....Die Menu Click Ereignisse"

    ''' <summary>
    ''' Ende wurde angeklickt
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EndeMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EndeMenuItem.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Auftrag/Neu wurde angeklickt
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AuftragNew_Click(sender As System.Object, e As System.EventArgs) Handles AuftragNew.Click
        Me.NeuerAuftrag()
    End Sub

#End Region

#Region "....Neuen Auftrag anlegen"

    Private Sub NeuerAuftrag()

        With New FormAuftragBearbeiten
            Dim newRow = _DataSet.Auftrag.NewAuftragRow
            Dim result As AuftragRow = .AuftragBearbeiten(_DataSet, _Benutzer, newRow)

            If result IsNot Nothing Then
                Try
                    _DataSet.Auftrag.AddAuftragRow(result)
                    _AuftragTabelAdapter.Update(result)
                Catch ex As Exception
                    Logging.WriteEntry(ex.Message, TraceEventType.Error)
                    MsgBox(ex.Message)
                End Try
            End If
        End With
    End Sub

#End Region

#Region "....Die Button Click Ereignisse"

    ''' <summary>
    ''' Bauteile filtern
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FilterButton_Click(sender As System.Object, e As System.EventArgs) Handles FilterButton.Click, ClearButton.Click

        Select Case DirectCast(sender, Button).Name

            Case "FilterButton"
                If Me.FilterTextBox.Text <> String.Empty Then
                    _AuftragBindingSource.Filter = Me.FilterComboBox.Text & " LIKE '" & Me.FilterTextBox.Text & "%'"
                End If

            Case "ClearButton"
                _AuftragBindingSource.RemoveFilter()
                'Me.FilterTextBox.Text = String.Empty
                Me.FilterComboBox.SelectedIndex = -1
        End Select
    End Sub
#End Region

#Region "....Die ComboBox Ereignisse"

    ''' <summary>
    ''' Dier Index der Filter ComboBox hat sich geändert
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FilterComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles FilterComboBox.SelectedIndexChanged

        Dim CB As ComboBox = DirectCast(sender, ComboBox)

        If CB.SelectedIndex >= 0 Then
            Me.FilterButton.Enabled = True
            Me.ClearButton.Enabled = True
        Else
            Me.FilterButton.Enabled = False
            Me.ClearButton.Enabled = False
            Me.FilterTextBox.Text = String.Empty
        End If

    End Sub

    ''' <summary>
    ''' Die DropDown Liste der ComboBox wurde geschlossen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FilterComboBox_DropDownClosed(sender As System.Object, e As System.EventArgs) Handles FilterComboBox.DropDownClosed

        Me.FilterTextBox.Text = String.Empty
        Me.FilterTextBox.Focus()
    End Sub

#End Region

End Class