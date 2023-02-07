Imports System.DirectoryServices.ActiveDirectory

Public Class FrmNetwork
    Private Sub FrmNetwork_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size
        Me.Top = FrmMain.Top + ((FrmMain.Height - Me.Height) / 2)
        Me.Left = FrmMain.Left + ((FrmMain.Width - Me.Width) / 2)
        Me.Icon = FrmMain.Icon


        TxtBroadcastIP.Text = TargetIP.ToString
        TxtBroadcastPort.Text = TargetPort
        Me.Visible = True
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim strIP As String = TxtBroadcastIP.Text
            If strIP.Trim.Length > 0 Then
                TargetIP = System.Net.IPAddress.Parse(strIP)

                SaveSetting("HexaleafController", "Settings", "TargetIP", strIP)
            Else
                MsgBox("No String specified")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If TargetPort > 0 And TargetPort < 65535 Then
            TargetPort = TxtBroadcastPort.Text
            SaveSetting("HexaleafController", "Settings", "TargetPort", TargetPort)
        End If


        Me.Close()
    End Sub




End Class




