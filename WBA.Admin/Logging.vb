Module Logging
    Private MyTraceSource As TraceSource = Nothing

    Sub New()
        System.Diagnostics.Trace.AutoFlush = True

        MyTraceSource = New TraceSource("WBA.Admin")
        MyTraceSource.Listeners.Remove("Default")

        MyTraceSource.Switch = New SourceSwitch("SourceSwitch", "Verbose")

        Dim exeAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim assemblyPath As String = System.IO.Path.GetDirectoryName(exeAssembly.Location)
        Dim logPath As String = assemblyPath & "\Logging"

        If Not System.IO.Directory.Exists(logPath) Then
            System.IO.Directory.CreateDirectory(logPath)
        End If

        Dim xmlListener As New System.Diagnostics.XmlWriterTraceListener(logPath & "\" & exeAssembly.GetName.Name.ToString & ".svclog")
        'xmlListener.Filter = New EventTypeFilter(SourceLevels.Error)
        xmlListener.TraceOutputOptions = xmlListener.TraceOutputOptions Or TraceOptions.Callstack Or TraceOptions.LogicalOperationStack
        xmlListener.Name = "xml"

        MyTraceSource.Listeners.Add(xmlListener)
    End Sub

    ''' <summary>
    ''' Einen Eintrag in das XML-Log schreiben
    ''' </summary>
    ''' <param name="Entry">Die Nachricht</param>
    ''' <param name="EventType">Der TraceEventType</param>
    ''' <param name="Id">Die Id</param>
    ''' <remarks></remarks>
    Sub WriteEntry(ByVal Entry As String, Optional ByVal EventType As TraceEventType = TraceEventType.Information, Optional ByVal Id As Integer = 1)
        MyTraceSource.TraceEvent(EventType, Id, Entry)
        MyTraceSource.Close()
    End Sub
End Module
