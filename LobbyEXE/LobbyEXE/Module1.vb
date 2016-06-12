Imports System.Runtime.InteropServices
Imports System.Text

Public Class IniRead
    Private Declare Auto Function GetPrivateProfileString Lib "kernel32" (ByVal lpAppName As String, _
            ByVal lpKeyName As String, _
            ByVal lpDefault As String, _
            ByVal lpReturnedString As StringBuilder, _
            ByVal nSize As Integer, _
            ByVal lpFileName As String) As Integer

    Private iniFile = ""

    Public Sub New(iniFile)
        Me.iniFile = iniFile
    End Sub

    Public Function getValue(keyName)
        Dim res As Integer
        Dim sb As StringBuilder

        sb = New StringBuilder(500)
        res = GetPrivateProfileString("LobbyConfig", keyName, "", sb, sb.Capacity, Me.iniFile)
        Return sb.ToString()
    End Function

End Class