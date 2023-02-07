Imports System.Net
Imports System.Net.Sockets

Module ModPublic
    Public TargetIP As IPAddress = IPAddress.Broadcast
    Public TargetPort As Integer = 4578
    Public udpClient As New UdpClient(4579)

    Public preset1, preset2, preset3, preset4, preset5, preset6, preset7, preset8, preset9, preset10 As String

End Module
