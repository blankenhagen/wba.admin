Public Class Tools

    Public Shared Sub ClrBit(ByRef value As UInt16, ByVal bit As UInt16)
        value = CUShort(value And Not (1 << bit))
    End Sub

    Public Shared Sub SetBit(ByRef value As UInt16, ByVal bit As UInt16)
        value = CUShort(value Or (1 << bit))
    End Sub

    Public Shared Function BitSet(ByVal value As UInt16, ByVal bit As UInt16) As Boolean
        Return (value And (1 << bit)) = (1 << bit)
    End Function

    Public Shared Function Transform(ByVal y As Double, ByVal ye0 As Double, ByVal ye1 As Double, ByVal ya0 As Double, ByVal ya1 As Double) As Double
        If y < ye0 Then y = ye0
        If y > ye1 Then y = ye1
        Return (y - ye0) / (ye1 - ye0) * (ya1 - ya0) + ya0
    End Function

    Public Shared Function UnicodeStringToBytes(ByVal str As String) As Byte()
        Return System.Text.Encoding.Unicode.GetBytes(str)
    End Function

    '------------------Daten(Bytearray) in String und zurück-------------------
    Public Shared Function StringToByteArray(ByRef str As String) As Byte()
        Return Convert.FromBase64String(str)
    End Function

    Public Shared Function ByteArrayToString(ByRef Barr() As Byte) As String
        Return Convert.ToBase64String(Barr)
    End Function

    '------------------Text in Bytearray und zurück-------------------
    Public Shared Function TextStringToByteArray(ByRef str As String) As Byte()
        Dim enc As System.Text.Encoding = System.Text.Encoding.Default
        Return enc.GetBytes(str)
    End Function

    Public Shared Function ByteArrayToTextString(ByRef Barr() As Byte) As String
        Dim enc As System.Text.Encoding = System.Text.Encoding.Default
        Return enc.GetString(Barr)
    End Function

End Class
