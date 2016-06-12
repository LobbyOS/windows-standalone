Public Class PopupForm

    Public Sub New()
        InitializeComponent()
        Icon = My.Resources.TrayIcon
    End Sub

    Private Sub OpenButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OpenLobby()
    End Sub

    Private Sub CloseAppButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles CloseAppButton.Click
        ExitApplication()
        Me.DialogResult = Windows.Forms.DialogResult.Abort
        Me.Close()
    End Sub

    Private Sub PopupForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Label1.Text = "Lobby Server is running on " & AppContext.host
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class