Imports WBA.Admin.wbadminDataSet

Public Class FormAnmeldung

    ''' <summary>
    ''' Der OK-Button wurde angeklickt
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

    ''' <summary>
    ''' Der Cancel-Button wurde angeklickt
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cancel_Button_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    End Sub

    ''' <summary>
    ''' Anmeldedialog anzeigen und den Benutzer über die Ausweisnummer ermitteln
    ''' </summary>
    ''' <returns> Ein Benutzerobjekt oder Nothing </returns>
    ''' <remarks></remarks>
    Public Function GetBenutzer() As Benutzer
        Using Me
            If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ' Den Benutzer über die Ausweisnummer ermitteln
                Dim query1 = From b In Me.WbData.Benutzer
                             Where b.Ausweis = tbxAusweis.Text
                             Select b

                If query1.Count > 0 Then ' Benutzer gefunden
                    Dim bRow As BenutzerRow = query1.Single

                    ' Alle Rollen-Codes für die dem Benutzer zugeordneten Anlagen holen
                    Dim query2 = From br In WbData.BenutzerRolle
                                 Where br.Benutzer_Id = bRow.Id
                                 Join r In WbData.Rolle
                                 On r.Id Equals br.Rolle_Id
                                 Let Ids = (From ba In _WbData.BenutzerAnlage
                                            Where ba.Benutzer_Id = bRow.Id
                                            Select ba.Anlage_Id)
                                 Where Ids.Contains(br.Anlage_Id)
                                 Select New With {.Code = r.Code}

                    ' Benutzer-Objekt erzeugen und die Benutzerdaten hinzufügen
                    Dim result As New Benutzer(query2.Count) With {.Id = bRow.Id, .Name = bRow.Vorname & " " & bRow.Name, .Gesperrt = bRow.Gesperrt}
                    Dim i As Integer = 0

                    ' Alle Rollen-Codes dem Benutzer-Objekt hinzufügen...
                    For Each c In query2
                        result.Code(i) = c.Code
                        Select Case c.Code
                            Case 10
                                result.Administrator = True
                            Case 2

                        End Select
                        i += 1
                    Next

                    ' ...und das Objekt als Ergebnis zurückliefern
                    Return result
                Else ' Benutzer nicht gefunden
                    MsgBox("Ausweisnummer " & tbxAusweis.Text & " nicht gefunden!")
                    Return Nothing
                End If
            Else ' Cancel
                Return Nothing
            End If
        End Using
    End Function

    ''' <summary>
    ''' Das Formular wird geladen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FormAnmeldung_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            ' Die entsprechenden Tabelle im Dataset füllen
            Me.WbData.EnforceConstraints = False
            Me.taBenutzer.Fill(Me.WbData.Benutzer)
            Me.taBenutzerRolle.Fill(Me.WbData.BenutzerRolle)
            Me.taBenutzerAnlage.Fill(Me.WbData.BenutzerAnlage)
            Me.taRolle.Fill(Me.WbData.Rolle)
            Me.taAnlage.Fill(Me.WbData.Anlage)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' Das Formular wurde aktiviert
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FormAnmeldung_Activated(sender As System.Object, e As System.EventArgs) Handles MyBase.Activated
        ' Das Eingabefeld für die Ausweisnummer ist fokussiert
        Me.tbxAusweis.Focus()
    End Sub

    ''' <summary>
    ''' Tastendrücke bearbeiten, während die TextBox den Fokus hat
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tbxAusweis_PreviewKeyDown(sender As System.Object, e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles tbxAusweis.PreviewKeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Me.btnOk.PerformClick()

            Case Keys.Escape
                Me.btnCancel.PerformClick()
        End Select
    End Sub
End Class