Imports WBA.Admin.wbadminDataSet
Imports WBA.Admin.Tools

Public Class ReleaseAndLock

    Private Const MaxBits As Integer = 8
    Public Property MaxOfen As Integer = 4

    Private Bezeichnung(MaxOfen - 1) As Label
    Public Freigabe(MaxOfen - 1) As CheckBox
    Public Sperre(MaxOfen - 1) As CheckBox
    Public Property Verfahren As Integer = 0

    Private _Anlage As AnlageDataTable
    ''' <summary>
    ''' Die Anlagentabelle
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Anlage() As AnlageDataTable
        Get
            Return _Anlage
        End Get
        Set(ByVal value As AnlageDataTable)
            _Anlage = value

            If _Anlage IsNot Nothing Then
                Dim i As Integer = 0

                For Each a As AnlageRow In _Anlage

                    Dim strVerfahren() As String = Split(a.AssignedVerfahren, ";")

                    If a.Code <> 4 Then ' Lienemann-Ofen nicht berücksichtigen!
                        If (strVerfahren.Contains("1") OrElse strVerfahren.Contains("2")) Then
                            Dim objAnlage As AnlageObjekt = New AnlageObjekt

                            For Each v In strVerfahren
                                Select Case v
                                    Case "1"
                                        objAnlage.Weichgluehen = 1
                                    Case "2"
                                        objAnlage.Warmauslagern = 2
                                End Select
                            Next

                            objAnlage.Bit = a.Code - 1
                            objAnlage.BitValue = Math.Pow(2, objAnlage.Bit)
                            objAnlage.Kuerzel = a.Kuerzel

                            Freigabe(i).Tag = objAnlage
                            Sperre(i).Tag = objAnlage

                            Bezeichnung(i).Text = a.Bezeichnung

                            i += 1
                        End If
                    End If
                Next
            End If
        End Set
    End Property

    Private _Release As Integer
    ''' <summary>
    ''' Die Freigabe
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Release() As Integer
        Get
            Return _Release
        End Get
        Set(ByVal value As Integer)
            If _Release <> value Then
                _Release = value

                For i As Integer = 0 To MaxBits - 1
                    If BitSet(_Release, i) Then
                        For Each R In Freigabe
                            If R IsNot Nothing Then
                                If DirectCast(R.Tag, AnlageObjekt).Bit = i Then
                                    R.Checked = True
                                End If
                            End If
                        Next
                    End If
                Next
            End If

            For i As Integer = 0 To MaxOfen - 1
                RemoveHandler Freigabe(i).CheckedChanged, AddressOf FreigabeCheckBox_CheckedChanged
                AddHandler Freigabe(i).CheckedChanged, AddressOf FreigabeCheckBox_CheckedChanged
            Next
        End Set
    End Property

    Private _Lock As Integer
    ''' <summary>
    ''' Die Sperre
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Lock() As Integer
        Get
            Return _Lock
        End Get
        Set(ByVal value As Integer)

            If _Lock <> value Then
                _Lock = value

                For i As Integer = 0 To MaxBits - 1
                    If BitSet(_Lock, i) Then
                        For Each S In Sperre
                            If S IsNot Nothing Then
                                If DirectCast(S.Tag, AnlageObjekt).Bit = i Then
                                    S.Checked = True
                                End If
                            End If
                        Next
                    End If
                Next
            End If

            For i As Integer = 0 To MaxOfen - 1
                RemoveHandler Sperre(i).CheckedChanged, AddressOf SperreCheckBox_CheckedChanged
                AddHandler Sperre(i).CheckedChanged, AddressOf SperreCheckBox_CheckedChanged
            Next
        End Set
    End Property

    Private _CanRelease As Boolean
    ''' <summary>
    ''' Freigabe-Checkbox aktivieren/deaktivieren
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CanRelease() As Boolean
        Get
            Return _CanRelease
        End Get
        Set(ByVal value As Boolean)
            _CanRelease = value

            For Each F In Freigabe
                If F IsNot Nothing Then
                    F.Enabled = _CanRelease
                End If
            Next
        End Set
    End Property

    Private _CanLock As Boolean
    ''' <summary>
    ''' Sperre-Checkbox aktivieren/deaktivieren
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CanLock() As Boolean
        Get
            Return _CanLock
        End Get
        Set(ByVal value As Boolean)
            _CanLock = value

            For Each S In Sperre
                If S IsNot Nothing Then
                    S.Enabled = _CanLock
                End If
            Next
        End Set
    End Property


    ''' <summary>
    ''' Der Konstruktor
    ''' Die Controls in Array's einlesen
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        Dim myControl() As Control

        For i As Integer = 0 To MaxOfen - 1
            myControl = Me.Controls.Find(String.Format("FreigabeCheckBox_{0}", i + 1), True)
            Freigabe(i) = myControl(0)

            myControl = Me.Controls.Find(String.Format("SperreCheckBox_{0}", i + 1), True)
            Sperre(i) = myControl(0)

            myControl = Me.Controls.Find(String.Format("AnlageLabel_{0}", i + 1), True)
            Bezeichnung(i) = myControl(0)
        Next
    End Sub

    ''' <summary>
    ''' Der Zustand der Freigabe-Checkbox hat sich geändert
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FreigabeCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Dim CB As CheckBox = DirectCast(sender, CheckBox)
        Dim tag As AnlageObjekt = DirectCast(CB.Tag, AnlageObjekt)

        If CB.Checked Then
            If (tag.Weichgluehen = Me.Verfahren) OrElse _
               (tag.Warmauslagern = Me.Verfahren) Then

                SetBit(_Release, tag.Bit)
            Else
                CB.CheckState = CheckState.Unchecked
                MsgBox("Anlage ist für dieses Verfahren nicht ausgelegt!")
            End If
        Else
            ClrBit(_Release, tag.Bit)
        End If
    End Sub

    ''' <summary>
    ''' Der Zustand der Sperre-Checkbox hat sich geändert
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SperreCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Dim CB As CheckBox = DirectCast(sender, CheckBox)
        Dim tag As AnlageObjekt = DirectCast(CB.Tag, AnlageObjekt)

        If CB.Checked Then
            SetBit(_Lock, tag.Bit)

            'If BitSet(_Release, tag.Bit) Then
            '    SetBit(_Lock, tag.Bit)
            'Else
            '    CB.CheckState = CheckState.Unchecked
            '    MsgBox("Nur freigegebene Programme können gesperrt werden!")
            'End If
        Else
            ClrBit(_Lock, tag.Bit)
        End If
    End Sub

    ''' <summary>
    ''' Das OnPaint-Ereignis
    ''' 3D-Linie unter den Überschriften zeichnen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ReleaseAndLock_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim r As System.Drawing.RectangleF = e.Graphics.VisibleClipBounds

        Dim pen As New Pen(Color.LightGray)
        e.Graphics.DrawLine(pen, r.Left + 5, r.Top + 15, r.Right, r.Top + 15)

        pen.Color = Color.White
        e.Graphics.DrawLine(pen, r.Left + 5, r.Top + 16, r.Right, r.Top + 16)
    End Sub

    Public Function GetKuerzelByFreigabe(value As Integer) As String
        Dim result As String = String.Empty

        For Each CB As CheckBox In Freigabe
            Dim anl As AnlageObjekt = DirectCast(CB.Tag, AnlageObjekt)

            If value = anl.BitValue Then
                result = anl.Kuerzel

                Exit For
            End If
        Next

        Return result
    End Function

End Class

Public Class AnlageObjekt

    Public Property Kuerzel As String = String.Empty
    Public Property Bit As Integer = 0
    Public Property BitValue As Integer = 0
    Public Property Warmauslagern As Integer = 0
    Public Property Weichgluehen As Integer = 0

    'Public Sub New()
    '    MyBase.New()

    'End Sub
End Class