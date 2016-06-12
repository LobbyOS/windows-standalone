
'Use only ONE of these Main methods.
Public Module LaunchApp

    Public Function isProcessRunning(strComputer, processName)
        Dim objWMIService, objProcess, colProcess, instances

        instances = 0

        objWMIService = GetObject("winmgmts:" & "{impersonationLevel=impersonate}!\\" & strComputer & "\root\cimv2")

        colProcess = objWMIService.ExecQuery("Select * from Win32_Process")

        For Each objProcess In colProcess
            If objProcess.Name = processName Then instances = instances + 1
        Next
        'This program will be counted'
        If (instances = 1 Or instances = 0) Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub Main()
        If (isProcessRunning(".", "Lobby.exe") = True) Then
            MsgBox("Lobby is already running! Please close it before starting again.")
            Exit Sub
        Else
            'Turn visual styles back on
            Application.EnableVisualStyles()

            'Run the application using AppContext
            Application.Run(New AppContext)

            ''You can also run the application using a main form
            'Application.Run(New MainForm)

            ''Or in a default context with no user interface at all
            'Application.Run()
        End If
    End Sub

    'Public Sub Main(ByVal cmdArgs() As String)
    '    Application.EnableVisualStyles()

    '    Dim UseTray As Boolean = False

    '    For Each Cmd As String In cmdArgs
    '        If Cmd.ToLower = "-tray" Then
    '            UseTray = True
    '            Exit For
    '        End If
    '    Next

    '    If UseTray Then
    '        Application.Run(New AppContext)
    '    Else
    '        Application.Run(New MainForm)
    '    End If
    'End Sub

    'Public Function Main() As Integer
    'End Function

    'Public Function Main(ByVal cmdArgs() As String) As Integer
    'End Function

End Module
