Public Class Benutzer
    Public Id As Integer = 0
    Public Name As String = String.Empty
    Public Gesperrt As Boolean = False
    Public Administrator As Boolean = False
    Public Code(-1) As Integer

    Sub New(ByVal size As Integer)
        ReDim Code(size - 1)
    End Sub

    'Function CodeCheck(item As Integer) As Boolean
    '    Dim result As Boolean = False

    '    If Me.Code.Contains(item) OrElse Me.Administrator Then
    '        Return True
    '    ElseIf Me.Gesperrt Then
    '        MsgBox(Me.Name & " ist gesperrt!")
    '        Return False
    '    Else
    '        MsgBox(Me.Name & " verfügt nicht" & ControlChars.CrLf & "über die notwendige Berechtigung!")
    '        Return False
    '    End If
    'End Function

    ''' <summary>
    ''' Überprüft die als Parameter-Array übergebenen Codes
    ''' und gibt entsprechende Meldungen aus
    ''' </summary>
    ''' <param name="p"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function CodeCheck(ParamArray p As Integer()) As Boolean
        Dim result As Boolean = False

        If Me.Gesperrt Then
            MsgBox(Me.Name & " ist gesperrt!")
            Return False
        End If

        If Me.Administrator Then
            Return True
        End If

        For i As Integer = 0 To p.Count - 1
            If Me.Code.Contains(p(i)) Then
                result = True
                Exit For
            End If
        Next

        If Not result Then
            MsgBox(Me.Name & " verfügt nicht" & ControlChars.CrLf & "über die notwendige Berechtigung!")
        End If

        Return result
    End Function
End Class
