Public Class FormMain

    Private Sub Button_Click(sender As System.Object, e As System.EventArgs) Handles btnProgramm.Click, btnParameter.Click, btnBenutzer.Click, btnBauteil.Click
        Dim result As Benutzer

        With New FormAnmeldung
            result = .GetBenutzer()
        End With

        If result IsNot Nothing Then
            Select Case True
                Case sender Is btnProgramm
                    Using dialog As New FormProgramm
                        dialog.ShowDialog(result)
                    End Using

                Case sender Is btnParameter
                    Using dialog As New FormParameter
                        dialog.ShowDialog(result)
                    End Using

                Case sender Is btnBauteil
                    Using dialog As New FormBauteil
                        dialog.ShowDialog(result)
                    End Using

                Case sender Is btnBenutzer
                    Using dialog As New FormBenutzer
                        If result.Administrator AndAlso Not result.Gesperrt Then
                            dialog.ShowDialog(result)
                        Else
                            If result.Gesperrt Then
                                MsgBox(result.Name & " ist gesperrt!")
                            Else
                                MsgBox(result.Name & " verfügt nicht über die notwendige Berechtigung!")
                            End If
                        End If
                    End Using
            End Select
        End If
    End Sub

    Private Sub btnHilfe_Click(sender As System.Object, e As System.EventArgs) Handles btnHilfe.Click
        MsgBox("Nicht implementiert!")
    End Sub
End Class
