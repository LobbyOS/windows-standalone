
Public Class AppContext
    Inherits ApplicationContext

#Region " Storage "

    Private WithEvents Tray As NotifyIcon
    Private WithEvents MainMenu As ContextMenuStrip
    Private WithEvents mnuDisplayForm As ToolStripMenuItem
    Private WithEvents mnuOpenLobby As ToolStripMenuItem
    Private WithEvents mnuSep1 As ToolStripSeparator
    Private WithEvents mnuExit As ToolStripMenuItem
    Public Shared host As String
    Public Shared lobbyServerPID As String

#End Region

#Region " Constructor "

    '
    ' Capture the results of a command line execution and
    ' return them to the caller.
    '
    Function getCommandOutput(theCommand)

        Dim objShell, objCmdExec
        objShell = CreateObject("WScript.Shell")
        objCmdExec = objshell.exec(thecommand)
        getCommandOutput = objCmdExec.StdOut.ReadAll

    End Function

    Public Sub New()
        'Initialize the menus
        mnuDisplayForm = New ToolStripMenuItem("Lobby")
        mnuSep1 = New ToolStripSeparator()
        mnuOpenLobby = New ToolStripMenuItem("Open Lobby")
        mnuExit = New ToolStripMenuItem("Exit")
        MainMenu = New ContextMenuStrip
        MainMenu.Items.AddRange(New ToolStripItem() {mnuDisplayForm, mnuOpenLobby, mnuSep1, mnuExit})

        Dim workingDir As String = My.Application.Info.DirectoryPath

        Dim IniRead As Object = New IniRead(workingDir & "\lobby.ini")
        AppContext.host = IniRead.getValue("serverHost")

        Dim oShell

        'Start Lobby'
        Me.lobbyServerPID = Shell(workingDir & "\lobby.bat " & AppContext.host, AppWinStyle.Hide)

        'Shell("wscript.exe """ & CurDir() & "/invisible.vbs"" """ & CurDir() & "/lobby.bat""")

        'Initialize the tray
        Tray = New NotifyIcon
        Tray.Icon = My.Resources.TrayIcon
        Tray.ContextMenuStrip = MainMenu
        Tray.Text = "Lobby"

        'Display
        Tray.Visible = True

        OpenLobby()
    End Sub

#End Region

#Region " Event handlers "

    Private Sub AppContext_ThreadExit(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles Me.ThreadExit
        'Guarantees that the icon will not linger.
        Tray.Visible = False
    End Sub

    Private Sub mnuDisplayForm_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles mnuDisplayForm.Click
        ShowDialog()
    End Sub

    Private Sub mnuOpenLobby_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles mnuOpenLobby.Click
        OpenLobby()
    End Sub

    Private Sub mnuExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles mnuExit.Click
        ExitApplication()
    End Sub

    Private Sub Tray_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles Tray.DoubleClick
        ShowDialog()
    End Sub

#End Region

End Class
