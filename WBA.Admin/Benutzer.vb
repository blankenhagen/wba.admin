Public Class Benutzer
    Public Id As Integer = 0
    Public Name As String = String.Empty
    Public Gesperrt As Boolean = False
    Public Administrator As Boolean = False
    Public Code(-1) As Integer

    Sub New(ByVal size As Integer)
        ReDim Code(size - 1)
    End Sub
End Class
