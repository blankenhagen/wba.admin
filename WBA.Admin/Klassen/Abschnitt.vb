Public Class Abschnitt
    Public Property Nummer As Integer = 0
    Public Property Sollwert As Integer = 0
    Public Property Stunden As Integer = 0
    Public Property Minuten As Integer = 0

    Public Sub New()
        MyBase.New()

        Me.Nummer = 0
        Me.Sollwert = 0
        Me.Stunden = 0
        Me.Minuten = 0
    End Sub

    Public Sub New(nr As Integer, soll As Integer, std As Integer, min As Integer)
        Me.Nummer = nr
        Me.Sollwert = soll
        Me.Stunden = std
        Me.Minuten = min
    End Sub

    Public Sub New(nr As Integer)
        Me.Nummer = nr
        Me.Sollwert = 0
        Me.Stunden = 0
        Me.Minuten = 0
    End Sub
End Class
