Friend Module OtherMethods

    Private PF As PopupForm

    Public Sub OpenLobby()
        Dim webAddress As String = "http://" & AppContext.host
        Process.Start(webAddress)
    End Sub

    Public Sub ExitApplication()
        'Kill Lobby'
        Shell("taskkill /PID " & AppContext.lobbyServerPID & " /T /F")
        Application.Exit()
    End Sub

    Public Sub ShowDialog()
        If PF IsNot Nothing AndAlso Not PF.IsDisposed Then Exit Sub

        Dim CloseApp As Boolean = False

        PF = New PopupForm
        PF.ShowDialog()
        CloseApp = (PF.DialogResult = DialogResult.Abort)
        PF = Nothing

        If CloseApp Then Application.Exit()
    End Sub

End Module
