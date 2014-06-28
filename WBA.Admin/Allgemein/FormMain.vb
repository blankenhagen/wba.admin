Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Data.OleDb
Imports TBB.Utils

Public Class FormMain

    Private WithEvents ConnectionWorker As New BackgroundWorker

    Private ServerIsOnline As Boolean = False
    Private WorkerHasCompleted As Boolean = False
    Private ServerVersion As String = String.Empty
    Private DataSource As String = String.Empty
    Private Database As String = String.Empty

    ' Das DataSet
    Friend WbaDataSet As wbadminDataSet = Nothing

    ' Die TableAdapter
    Friend BenutzerTableAdapter As wbadminDataSetTableAdapters.BenutzerTableAdapter = Nothing
    Friend RolleTableAdapter As wbadminDataSetTableAdapters.RolleTableAdapter = Nothing
    Friend BenutzerRolleTableAdapter As wbadminDataSetTableAdapters.BenutzerRolleTableAdapter = Nothing
    Friend BenutzerAnlageTableAdapter As wbadminDataSetTableAdapters.BenutzerAnlageTableAdapter = Nothing
    Friend AnlageTableAdapter As wbadminDataSetTableAdapters.AnlageTableAdapter = Nothing

    ''' <summary>
    ''' Prüft, ob der SQL-Server erreichbar ist
    ''' Die eigentliche Prüfung läuft im Hintergrund-Thread
    ''' </summary>
    ''' <param name="settingName">Der Name der Variablen in den Settings</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SQLServerIsOnline(settingName As String) As Boolean

        Try
            Me.ConnectionPanel.Visible = True
            Me.ConnectionTimer.Enabled = True

            ' Der ConnectionString wird als Argument übergeben
            Me.ConnectionWorker.RunWorkerAsync(My.Settings.Item(settingName))

            ' Warten bis der Thread fertig ist
            While Not Me.WorkerHasCompleted
                Application.DoEvents()
            End While
        Catch ex As Exception

        Finally
            Me.WorkerHasCompleted = False
            Me.ConnectionPanel.Visible = False
            Me.ConnectionTimer.Enabled = False
            Me.ConnectionProgressBar.Value = 0
        End Try

        Return Me.ServerIsOnline
    End Function

    ''' <summary>
    ''' Das Formular wird sichtbar
    ''' Die Verbindung zur Datenbank testen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FormMain_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

        Dim remoteConnection As TBB.Utils.UDL = New TBB.Utils.UDL("mssql.udl")
        Dim remoteConnectionString = remoteConnection.GetSQLConnectionString

        Me.ConnectionStatusLabel.Text = String.Empty

        My.Settings.SetUserOverride("wbadminConnectionString", remoteConnectionString)

        ' Warten bis der Thread fertig ist
        If Not Me.SQLServerIsOnline("wbadminConnectionString") Then
            MsgBox("Keine Verbindung zur Datenbank!" & vbCrLf & vbCrLf & _
                   "Bitte wenden Sie sich an den System Administrator!")
            Me.ConnectionStatusLabel.Text = "Keine Verbindung zur Datenbank!"
        Else
            Me.ConnectionStatusLabel.Text = String.Format("Datenbank: {0}(Ver.{1})/{2}", Me.DataSource, Me.ServerVersion, Me.Database)
        End If
    End Sub

    ''' <summary>
    ''' Ein Button wurde angeklickt
    ''' Nach Anmeldung den enstsprechenden Dialog aufrufen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button_Click(sender As System.Object, e As System.EventArgs) Handles BenutzerButton.Click, BauteilButton.Click, AuftragButton.Click

        ' Es muss eine Verbindung zur Datenbank bestehen
        If Me.DataSource <> String.Empty Then
            Dim result As Benutzer

            With New FormAnmeldung
                result = .GetBenutzer()
            End With

            If result IsNot Nothing Then
                With result
                    Select Case True
                        Case sender Is BauteilButton
                            If .CodeCheck(30, 31) Then
                                Using dialog As New FormBauteil
                                    dialog.ShowDialog(result)
                                End Using
                            End If

                        Case sender Is BenutzerButton
                            If .CodeCheck(70, 71) Then
                                Using dialog As New FormBenutzer
                                    dialog.ShowDialog(result)
                                End Using
                            End If

                        Case sender Is AuftragButton
                            If .CodeCheck(90) Then
                                Using dialog As New FormAuftrag
                                    dialog.Tag = result ' Den Benutzer mitgeben
                                    dialog.ShowDialog()
                                End Using
                            End If
                    End Select
                End With
            End If
        Else
            MsgBox("Keine Verbindung zur Datenbank!" & vbCrLf & vbCrLf & _
                   "Bitte wenden Sie sich an den System Administrator!")
        End If
    End Sub

    Private Sub ParameterButton_Click(sender As System.Object, e As System.EventArgs) Handles ParameterButton.Click

        ' Es muss eine Verbindung zur Datenbank bestehen
        If Me.DataSource <> String.Empty Then
            Dim button As Button = DirectCast(sender, Button)
            Dim point As System.Drawing.Point
            point = button.Parent.PointToScreen(button.Location)
            point.Y -= Me.ParameterMenu.Height
            Me.ParameterMenu.Show(point)
        Else
            MsgBox("Keine Verbindung zur Datenbank!" & vbCrLf & vbCrLf & _
                   "Bitte wenden Sie sich an den System Administrator!")
        End If
    End Sub

    ''' <summary>
    ''' Die Hilfe aufrufen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub HilfeButton_Click(sender As System.Object, e As System.EventArgs) Handles HilfeButton.Click

        Using help As Process = New Process
            Try
                help.StartInfo.FileName = My.Application.Info.DirectoryPath & "\WBA.Admin.chm"
                help.Start()
            Catch ex As Exception
                MsgBox("Hilfe kann nicht geöffnet werden!")
            End Try
        End Using
    End Sub

    ''' <summary>
    ''' Die Messwerte einer Charge nach CSV exportieren
    ''' Berechtigung: Administrator und Qualitätssicherung
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MesswerteButton_Click(sender As System.Object, e As System.EventArgs) Handles MesswerteButton.Click

        Dim result As Benutzer

        With New FormAnmeldung
            result = .GetBenutzer()
        End With

        If result IsNot Nothing Then
            With result
                If .CodeCheck(10, 50) Then
                    Using dialog As New FormMesswerte
                        dialog.Tag = result ' Den Benutzer mitgeben
                        dialog.ShowDialog()
                    End Using
                End If
            End With
        End If
    End Sub

    ''' <summary>
    ''' Die Anwendung beenden
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EndeButton_Click(sender As System.Object, e As System.EventArgs) Handles EndeButton.Click

        Me.Close()
    End Sub

    ''' <summary>
    ''' Das Programm MenuItem wurde angeklickt
    ''' Den Programm Dialog aufrufen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ProgrammMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ProgrammMenuItem.Click

        Dim result As Benutzer

        With New FormAnmeldung
            result = .GetBenutzer()
        End With

        If result IsNot Nothing Then
            With result
                If .CodeCheck(40, 41) Then
                    Using dialog As New FormProgramm
                        dialog.ShowDialog(result)
                    End Using
                End If
            End With
        End If
    End Sub

    ''' <summary>
    ''' Das Lösungsglühen MenuItem wurde angeklickt
    ''' Den Parameter Dialog aufrufen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LoesungsgluehenMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LoesungsgluehenMenuItem.Click

        MsgBox("Funktion nicht implementiert!")

        'Dim result As Benutzer

        'With New FormAnmeldung
        '    result = .GetBenutzer()
        'End With

        'If result IsNot Nothing Then
        '    With result
        '        If .CodeCheck(40, 41) Then
        '            Using dialog As New FormParameter
        '                dialog.ShowDialog(result)
        '            End Using
        '        End If
        '    End With
        'End If
    End Sub

    ''' <summary>
    ''' Die Timerroutine für die Überprüfung der Datenbankverbindung
    ''' Der Fortschrittsbalken wird aktualisiert
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ConnectionTimer_Tick(sender As System.Object, e As System.EventArgs) Handles ConnectionTimer.Tick

        If Me.ConnectionProgressBar.Value < Me.ConnectionProgressBar.Maximum Then
            Me.ConnectionProgressBar.Value += 1
        End If
    End Sub

    ''' <summary>
    ''' Die Testverbindung zur Datenbank läuft im Hintergrund-Thread
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ConnectionWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles ConnectionWorker.DoWork

        Dim result As Boolean = False

        Try
            Using server As New SqlConnection(DirectCast(e.Argument, String))
                server.Open()

                result = (server.State = ConnectionState.Open)
                If result Then
                    Me.ServerVersion = server.ServerVersion
                    Me.DataSource = server.DataSource
                    Me.Database = server.Database

                    server.Close()
                End If
            End Using
        Catch ex As SqlException

        Finally
            e.Result = result
        End Try
    End Sub

    ''' <summary>
    ''' Ist der Hintergrund-Thread fertig, dann den Status zurückliefern
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ConnectionWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConnectionWorker.RunWorkerCompleted

        Me.ServerIsOnline = DirectCast(e.Result, Boolean)
        Me.WorkerHasCompleted = True
    End Sub

    'TODO: das Löschen von Programm, Parameter und Benutzer disablen

End Class

' Erweiterung von My.Settings, um App Settings überschreiben zu können
Namespace My
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        Public Sub SetUserOverride(ByVal [property] As String, ByVal value As String)
            Me([property]) = value
        End Sub
    End Class
End Namespace
