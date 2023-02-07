Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks.Sources

Public Class FrmMain
    Dim prohibitUpdate As Boolean = True
    Dim PreFix As String = "$,"
    Dim Data As String
    Dim listenerThread As Thread
    Dim stopListening As Boolean = False
    Dim serverRunning As Boolean = False

    '  Dim preset1, preset2, preset3, preset4, preset5, preset6, preset7, preset8, preset9, preset10 As String

    Dim button1ToolTipText, button2ToolTipText, button3ToolTipText, button4ToolTipText, button5ToolTipText, button6ToolTipText, button7ToolTipText, button8ToolTipText, button9ToolTipText, button10ToolTipText


    Private Sub ListenForMessages()


        While Not stopListening
            Try
                Dim remoteIpEndPoint As New IPEndPoint(IPAddress.Any, 0)
                Dim receiveBytes As Byte() = udpClient.Receive(remoteIpEndPoint)
                Dim receivedText As String = Encoding.ASCII.GetString(receiveBytes)

                ' Update the textbox on the UI thread
                Me.Invoke(Sub()
                              txtReceived.Text = receivedText

                          End Sub)
            Catch ex As Exception
                ' Handle exceptions as appropriate
            End Try
        End While
        udpClient.Close()
    End Sub

    Sub SaveSet()
        If Me.Top > 0 Then
            SaveSetting("HexaleafController", "Settings", "Top", Me.Top)
        End If
        If Me.Left > 0 Then
            SaveSetting("HexaleafController", "Settings", "Left", Me.Left)
        End If

        SaveSetting("HexaleafController", "Settings", "Trackbar1", TrackBar1.Value)
        SaveSetting("HexaleafController", "Settings", "Trackbar2", TrackBar2.Value)
        SaveSetting("HexaleafController", "Settings", "Trackbar3", TrackBar3.Value)
        SaveSetting("HexaleafController", "Settings", "Trackbar4", TrackBar4.Value)
        SaveSetting("HexaleafController", "Settings", "Trackbar5", TrackBar5.Value)
        SaveSetting("HexaleafController", "Settings", "Trackbar6", TrackBar6.Value)
        SaveSetting("HexaleafController", "Settings", "Combobox1", ComboBox1.SelectedIndex)

        SaveSetting("HexaleafController", "Settings", "NumericUpDown1", NumericUpDown1.Value)
        SaveSetting("HexaleafController", "Settings", "NumericUpDown2", NumericUpDown2.Value)
        SaveSetting("HexaleafController", "Settings", "NumericUpDown3", NumericUpDown3.Value)

        SaveSetting("HexaleafController", "Settings", "NumPreset", NumPreset.Value)

        SaveSetting("HexaleafController", "Settings", "Preset1", preset1)
        SaveSetting("HexaleafController", "Settings", "Preset2", preset2)
        SaveSetting("HexaleafController", "Settings", "Preset3", preset3)
        SaveSetting("HexaleafController", "Settings", "Preset4", preset4)
        SaveSetting("HexaleafController", "Settings", "Preset5", preset5)
        SaveSetting("HexaleafController", "Settings", "Preset6", preset6)
        SaveSetting("HexaleafController", "Settings", "Preset7", preset7)
        SaveSetting("HexaleafController", "Settings", "Preset8", preset8)
        SaveSetting("HexaleafController", "Settings", "Preset9", preset9)
        SaveSetting("HexaleafController", "Settings", "Preset10", preset10)


        SaveSetting("HexaleafController", "Settings", "ChkMaximumTime", ChkMaximumTime.Checked)
        SaveSetting("HexaleafController", "Settings", "ChkMinimumTime", ChkMinimumTime.Checked)
        SaveSetting("HexaleafController", "Settings", "ChkMode", ChkMode.Checked)
        SaveSetting("HexaleafController", "Settings", "ChkPrimaryColor", ChkPrimaryColor.Checked)
        SaveSetting("HexaleafController", "Settings", "ChkSecondaryColor", ChkSecondaryColor.Checked)
        SaveSetting("HexaleafController", "Settings", "ChkRandomizer", ChkRandomizer.Checked)

        SaveSetting("HexaleafController", "Settings", "ChkAutoSend", ChkAutoSend.Checked)



    End Sub

    Sub LoadSet()
        Me.Top = GetSetting("HexaleafController", "Settings", "Top", 100)
        Me.Left = GetSetting("HexaleafController", "Settings", "Left", 200)
        TrackBar1.Value = GetSetting("HexaleafController", "Settings", "Trackbar1", 20)
        TrackBar2.Value = GetSetting("HexaleafController", "Settings", "Trackbar2", 120)
        TrackBar3.Value = GetSetting("HexaleafController", "Settings", "Trackbar3", 80)
        TrackBar4.Value = GetSetting("HexaleafController", "Settings", "Trackbar4", 150)
        TrackBar5.Value = GetSetting("HexaleafController", "Settings", "Trackbar5", 0)
        TrackBar6.Value = GetSetting("HexaleafController", "Settings", "Trackbar6", 30)
        ComboBox1.SelectedIndex = GetSetting("HexaleafController", "Settings", "Combobox1", 0)

        NumericUpDown1.Value = GetSetting("HexaleafController", "Settings", "NumericUpDown1", 70)
        NumericUpDown2.Value = GetSetting("HexaleafController", "Settings", "NumericUpDown2", 5)
        NumericUpDown3.Value = GetSetting("HexaleafController", "Settings", "NumericUpDown3", 100)

        NumPreset.Value = GetSetting("HexaleafController", "Settings", "NumPreset", 1)

        preset1 = GetSetting("HexaleafController", "Settings", "Preset1", " ")
        preset2 = GetSetting("HexaleafController", "Settings", "Preset2", " ")
        preset3 = GetSetting("HexaleafController", "Settings", "Preset3", " ")
        preset4 = GetSetting("HexaleafController", "Settings", "Preset4", " ")
        preset5 = GetSetting("HexaleafController", "Settings", "Preset5", " ")
        preset6 = GetSetting("HexaleafController", "Settings", "Preset6", " ")
        preset7 = GetSetting("HexaleafController", "Settings", "Preset7", " ")
        preset8 = GetSetting("HexaleafController", "Settings", "Preset8", " ")
        preset9 = GetSetting("HexaleafController", "Settings", "Preset9", " ")
        preset10 = GetSetting("HexaleafController", "Settings", "Preset10", " ")

        button1ToolTipText = preset1
        button2ToolTipText = preset2
        button3ToolTipText = preset3
        button4ToolTipText = preset4
        button5ToolTipText = preset5
        button6ToolTipText = preset6
        button7ToolTipText = preset7
        button8ToolTipText = preset8
        button9ToolTipText = preset9
        button10ToolTipText = preset10

        ToolTip1.SetToolTip(Me.Button1, button1ToolTipText)
        ToolTip1.SetToolTip(Me.Button2, button2ToolTipText)
        ToolTip1.SetToolTip(Me.Button4, button3ToolTipText)
        ToolTip1.SetToolTip(Me.Button5, button4ToolTipText)
        ToolTip1.SetToolTip(Me.Button6, button5ToolTipText)
        ToolTip1.SetToolTip(Me.Button7, button6ToolTipText)
        ToolTip1.SetToolTip(Me.Button8, button7ToolTipText)
        ToolTip1.SetToolTip(Me.Button9, button8ToolTipText)
        ToolTip1.SetToolTip(Me.Button10, button9ToolTipText)
        ToolTip1.SetToolTip(Me.Button11, button10ToolTipText)


        ChkMaximumTime.Checked = GetSetting("HexaleafController", "Settings", "ChkMaximumTime", True)
        ChkMinimumTime.Checked = GetSetting("HexaleafController", "Settings", "ChkMinimumTime", True)
        ChkMode.Checked = GetSetting("HexaleafController", "Settings", "ChkMode", True)
        ChkPrimaryColor.Checked = GetSetting("HexaleafController", "Settings", "ChkPrimaryColor", True)
        ChkSecondaryColor.Checked = GetSetting("HexaleafController", "Settings", "ChkSecondaryColor", True)
        ChkRandomizer.Checked = GetSetting("HexaleafController", "Settings", "ChkRandomizer", True)


        ChkAutoSend.Checked = GetSetting("HexaleafController", "Settings", "ChkAutoSend", False)

        TargetPort = GetSetting("HexaleafController", "Settings", "TargetPort", 4578)

        Try
            Dim strIP As String = GetSetting("HexaleafController", "Settings", "TargetIP", "225.255.255.255")
            If strIP.Trim.Length > 0 Then
                TargetIP = System.Net.IPAddress.Parse(strIP)
                '
                '               SaveSetting("HexaleafController", "Settings", "TargetIP", strIP)
            Else
                '     MsgBox("No String specified")
            End If

        Catch ex As Exception
            '         MsgBox(ex.Message)
        End Try



    End Sub

    ' Alternative solution
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        prohibitUpdate = True

        Label1.Text = ""
        Label2.Text = ""


        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size

        LoadSet()
        prohibitUpdate = False

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SaveSet()
        If serverRunning Then
            stopListening = True
            listenerThread.Join(200)
            While listenerThread.IsAlive
                Application.DoEvents()
            End While
        End If

    End Sub

    Sub UDPSend(sData As String, sPort As Integer, sIP As IPAddress)
        Dim client As New UdpClient()
        Dim BytData As Byte() = Encoding.ASCII.GetBytes(sData)
        client.Send(BytData, BytData.Length, sIP.ToString(), sPort)
        client.Close()
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles stopServerButton.Click
        If Not serverRunning Then
            MessageBox.Show("Server is not running.")
            Exit Sub
        End If

        ' Signal the listener thread to stop listening
        stopListening = True
        listenerThread.Join(500)
        serverRunning = False
        lblindicator.BackColor = Color.Red
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles startServerButton.Click
        If serverRunning Then
            MessageBox.Show("Server is already running.")
            Exit Sub
        End If

        ' Start the listener thread
        listenerThread = New Thread(AddressOf ListenForMessages)
        listenerThread.IsBackground = True
        listenerThread.Start()
        serverRunning = True
        lblindicator.BackColor = Color.Green
    End Sub

    Sub LoadValuesToControls(valueToSplit As String)
        'Dim valueToSplit As String = "V1,V2,V3,V4,V5,V6"
        prohibitUpdate = True
        Dim prV1 As String = "*"
        Dim prV2 As String = "*"
        Dim prV3 As String = "*"
        Dim prV4 As String = "*"
        Dim prV5 As String = "*"
        Dim prV6 As String = "*"

        Dim values() As String = valueToSplit.Split(","c)
        For Each value As String In values
            If value.Contains("V1") Then
                prV1 = value.Replace("V1", "")
            ElseIf value.Contains("V2") Then
                prV2 = value.Replace("V2", "")
            ElseIf value.Contains("V3") Then
                prV3 = value.Replace("V3", "")
            ElseIf value.Contains("V4") Then
                prV4 = value.Replace("V4", "")
            ElseIf value.Contains("V5") Then
                prV5 = value.Replace("V5", "")
            ElseIf value.Contains("V6") Then
                prV6 = value.Replace("V6", "")
            End If
        Next

        If prV1 <> "*" Then
            ComboBox1.SelectedIndex = Convert.ToInt32(prV1) - 1

        End If
        If prV2 <> "*" Then
            ' convertColorHere
            If prV2.Length = 9 Then
                Dim firstPart As String = prV2.Substring(0, 3)
                Dim secondPart As String = prV2.Substring(3, 3)
                Dim thirdPart As String = prV2.Substring(6, 3)

                Dim redColor As Integer = Integer.Parse(firstPart)
                Dim greenColor As Integer = Integer.Parse(secondPart)
                Dim blueColor As Integer = Integer.Parse(thirdPart)
                TrackBar1.Value = redColor
                TrackBar2.Value = greenColor
                TrackBar3.Value = blueColor
            End If
        End If
        If prV3 <> "*" Then

            If prV3.Length = 9 Then
                Dim firstPart As String = prV3.Substring(0, 3)
                Dim secondPart As String = prV3.Substring(3, 3)
                Dim thirdPart As String = prV3.Substring(6, 3)

                Dim redColor As Integer = Integer.Parse(firstPart)
                Dim greenColor As Integer = Integer.Parse(secondPart)
                Dim blueColor As Integer = Integer.Parse(thirdPart)
                TrackBar4.Value = redColor
                TrackBar5.Value = greenColor
                TrackBar6.Value = blueColor
            End If
            ' convertColorHere
        End If

        If prV4 <> "*" Then
            NumericUpDown2.Value = Convert.ToInt32(prV4) / 100
        End If
        If prV5 <> "*" Then
            NumericUpDown3.Value = Convert.ToInt32(prV5) / 100
        End If
        If prV6 <> "*" Then
            NumericUpDown1.Value = Convert.ToInt32(prV6)
        End If
        prohibitUpdate = False


    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' UDPSend(PreFix & "V11,V2050050000", TargetPort, TargetIP)
        UDPSend(PreFix & preset1, TargetPort, TargetIP)
        tsLBL2.Text = PreFix & preset1
        tsLBL1.Text = " Preset 1"
        TmrClearlbls.Enabled = True
        LoadValuesToControls(preset1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' UDPSend(PreFix & "V13,V20002550000,V3000000150", TargetPort, TargetIP)
        UDPSend(PreFix & preset2, TargetPort, TargetIP)
        tsLBL2.Text = PreFix & preset2
        tsLBL1.Text = " Preset 2"
        TmrClearlbls.Enabled = True
        LoadValuesToControls(preset2)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' UDPSend(PreFix & "V13,V20100450000,V3060000000", TargetPort, TargetIP)
        UDPSend(PreFix & preset3, TargetPort, TargetIP)
        tsLBL2.Text = PreFix & preset3
        tsLBL1.Text = "Preset 3"

        TmrClearlbls.Enabled = True
        LoadValuesToControls(preset3)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'UDPSend(PreFix & "V12,V2110000000,V3000030050", TargetPort, TargetIP)
        UDPSend(PreFix & preset4, TargetPort, TargetIP)
        tsLBL2.Text = PreFix & preset4
        tsLBL1.Text = "Preset 4"
        TmrClearlbls.Enabled = True
        LoadValuesToControls(preset4)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        '  UDPSend(PreFix & "V13,V2020050000,V31200030000", TargetPort, TargetIP)
        UDPSend(PreFix & preset5, TargetPort, TargetIP)
        tsLBL2.Text = PreFix & preset5
        tsLBL1.Text = "Preset 5"
        TmrClearlbls.Enabled = True
        LoadValuesToControls(preset5)

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ' UDPSend(PreFix & "V11,V2020000010,V30000000000", TargetPort, TargetIP)
        UDPSend(PreFix & preset6, TargetPort, TargetIP)
        tsLBL2.Text = PreFix & preset6
        tsLBL1.Text = "Preset 6"
        TmrClearlbls.Enabled = True
        LoadValuesToControls(preset6)
    End Sub


    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        '  UDPSend(PreFix & "V11,V2020000010,V30120500030", TargetPort, TargetIP)
        UDPSend(PreFix & preset7, TargetPort, TargetIP)
        tsLBL2.Text = PreFix & preset7
        tsLBL1.Text = "Preset 7"
        TmrClearlbls.Enabled = True
        LoadValuesToControls(preset7)

    End Sub


    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        ' UDPSend(PreFix & "V12,V2000000000,V30000000000", TargetPort, TargetIP)
        UDPSend(PreFix & preset10, TargetPort, TargetIP)
        tsLBL2.Text = PreFix & preset10
        tsLBL1.Text = "Preset 10"
        TmrClearlbls.Enabled = True
        LoadValuesToControls(preset10)


    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        ' UDPSend(PreFix & "V12,V2020000010,V30330000100", TargetPort, TargetIP)
        UDPSend(PreFix & preset8, TargetPort, TargetIP)

        tsLBL2.Text = PreFix & preset8
        tsLBL1.Text = "Preset 8"
        TmrClearlbls.Enabled = True
        LoadValuesToControls(preset8)

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        '  UDPSend(PreFix & "V13,V2200110030,V3000100000", TargetPort, TargetIP)
        UDPSend(PreFix & preset9, TargetPort, TargetIP)

        tsLBL2.Text = PreFix & preset9
        tsLBL1.Text = "Preset 9"
        TmrClearlbls.Enabled = True
        LoadValuesToControls(preset9)

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub


    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.ShowDialog()
    End Sub
    Private Function GetPresetValue(ByVal presetVariable) As String
        ' Replace this code with code to retrieve the value of the preset variable
        Return presetVariable.ToString
    End Function
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim presetValue As String
        presetValue = GetPresetValue(preset1)
        INIWrite(Application.StartupPath & "\SavedValues.ini", "Presets", "preset1", presetValue)
        presetValue = GetPresetValue(preset2)
        INIWrite(Application.StartupPath & "\SavedValues.ini", "Presets", "preset2", presetValue)
        presetValue = GetPresetValue(preset3)
        INIWrite(Application.StartupPath & "\SavedValues.ini", "Presets", "preset3", presetValue)
        presetValue = GetPresetValue(preset4)
        INIWrite(Application.StartupPath & "\SavedValues.ini", "Presets", "preset4", presetValue)
        presetValue = GetPresetValue(preset5)
        INIWrite(Application.StartupPath & "\SavedValues.ini", "Presets", "preset5", presetValue)
        presetValue = GetPresetValue(preset6)
        INIWrite(Application.StartupPath & "\SavedValues.ini", "Presets", "preset6", presetValue)
        presetValue = GetPresetValue(preset7)
        INIWrite(Application.StartupPath & "\SavedValues.ini", "Presets", "preset7", presetValue)
        presetValue = GetPresetValue(preset8)
        INIWrite(Application.StartupPath & "\SavedValues.ini", "Presets", "preset8", presetValue)
        presetValue = GetPresetValue(preset9)
        INIWrite(Application.StartupPath & "\SavedValues.ini", "Presets", "preset9", presetValue)
        presetValue = GetPresetValue(preset10)
        INIWrite(Application.StartupPath & "\SavedValues.ini", "Presets", "preset10", presetValue)
    End Sub

    Private Sub btmSendAll_Click(sender As Object, e As EventArgs) Handles btnSendAll.Click
        If prohibitUpdate = False Then
            Dim constructLine As String = PreFix & "V1" & (ComboBox1.SelectedIndex + 1) & "," & Label1.Text & "," & Label2.Text & ",V4" & NumericUpDown2.Value * 100 & ",V5" & NumericUpDown3.Value * 100 & ",V6" & NumericUpDown1.Value
            'MsgBox(constructLine)
            UDPSend(constructLine, TargetPort, TargetIP)
            tsLBL2.Text = constructLine
            TmrClearlbls.Enabled = True
        End If
    End Sub

    Private Sub TmrClearlbls_Tick(sender As Object, e As EventArgs) Handles TmrClearlbls.Tick
        tsLBL2.Text = ""
        tsLBL1.Text = ""
        TmrClearlbls.Enabled = False
    End Sub

    Private Sub TrackBar1_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar1.Scroll, TrackBar1.ValueChanged
        UpdatePrimaryColorValues()
    End Sub
    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll, TrackBar2.ValueChanged
        UpdatePrimaryColorValues()
    End Sub

    Private Sub TrackBar3_Scroll(sender As Object, e As EventArgs) Handles TrackBar3.Scroll, TrackBar2.ValueChanged
        UpdatePrimaryColorValues()
    End Sub

    Sub UpdatePrimaryColorValues()
        Label1.Text = "V2" & TrackBar1.Value.ToString("000") & TrackBar2.Value.ToString("000") & TrackBar3.Value.ToString("000")
        Dim redValue As Integer = TrackBar1.Value
        Dim greenValue As Integer = TrackBar2.Value
        Dim blueValue As Integer = TrackBar3.Value
        LblPrimaryRed.Text = redValue
        LblPrimaryGreen.Text = greenValue
        LblPrimaryBlue.Text = blueValue
        Dim myColor As Color = Color.FromArgb(redValue, greenValue, blueValue)
        Label1.BackColor = myColor

        Dim myInvColor As Color = Color.FromArgb(255, 255 - myColor.R, 255 - myColor.G, 255 - myColor.B)
        Label1.ForeColor = myInvColor

        If ChkAutoSend.Checked = True Then
            Call btmSendAll_Click(Nothing, Nothing)
        Else

            If prohibitUpdate = False Then
                UDPSend(PreFix & Label1.Text, TargetPort, TargetIP)
                tsLBL2.Text = PreFix & Label1.Text
                TmrClearlbls.Enabled = True

            End If
        End If

    End Sub
    Sub UpdateSeecondaryColorValues()

        Label2.Text = "V3" & TrackBar4.Value.ToString("000") & TrackBar5.Value.ToString("000") & TrackBar6.Value.ToString("000")
        Dim redValue As Integer = TrackBar4.Value
        Dim greenValue As Integer = TrackBar5.Value
        Dim blueValue As Integer = TrackBar6.Value
        LblSecondaryRed.Text = redValue
        LblSecondaryGreen.Text = greenValue
        LblSecondaryBlue.Text = blueValue
        Dim myColor As Color = Color.FromArgb(redValue, greenValue, blueValue)
        Label2.BackColor = myColor
        Dim myInvColor As Color = Color.FromArgb(255, 255 - myColor.R, 255 - myColor.G, 255 - myColor.B)
        Label2.ForeColor = myInvColor


        If ChkAutoSend.Checked = True Then
            Call btmSendAll_Click(Nothing, Nothing)
        Else

            If prohibitUpdate = False Then
                UDPSend(PreFix & Label2.Text, TargetPort, TargetIP)
                tsLBL2.Text = PreFix & Label2.Text
                TmrClearlbls.Enabled = True
            End If

        End If
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        If NumPreset.Value = 1 Then
            preset1 = ""
            If ChkMode.Checked = True Then
                preset1 = preset1 + ",V1" & ComboBox1.SelectedIndex + 1
            End If

            If ChkPrimaryColor.Checked = True Then
                preset1 = preset1 + "," & Label1.Text
            End If

            If ChkSecondaryColor.Checked = True Then
                preset1 = preset1 + "," & Label2.Text
            End If

            If ChkMinimumTime.Checked = True Then
                preset1 = preset1 + ",V4" & NumericUpDown2.Value * 100
            End If

            If ChkMaximumTime.Checked = True Then
                preset1 = preset1 + ",V5" & NumericUpDown3.Value * 100
            End If
            If ChkRandomizer.Checked = True Then
                preset1 = preset1 + ",V6" & NumericUpDown1.Value
            End If
            preset1 = preset1.Replace(",,", ",")

        ElseIf NumPreset.Value = 2 Then
            preset2 = ""
            If ChkMode.Checked = True Then
                preset2 = preset2 + ",V1" & ComboBox1.SelectedIndex + 1
            End If

            If ChkPrimaryColor.Checked = True Then
                preset2 = preset2 + "," & Label1.Text
            End If

            If ChkSecondaryColor.Checked = True Then
                preset2 = preset2 + "," & Label2.Text
            End If

            If ChkMinimumTime.Checked = True Then
                preset2 = preset2 + ",V4" & NumericUpDown2.Value * 100
            End If

            If ChkMaximumTime.Checked = True Then
                preset2 = preset2 + ",V5" & NumericUpDown3.Value * 100
            End If
            If ChkRandomizer.Checked = True Then
                preset2 = preset2 + ",V6" & NumericUpDown1.Value
            End If
            preset2 = preset2.Replace(",,", ",")
        ElseIf NumPreset.Value = 3 Then
            preset3 = ""
            If ChkMode.Checked = True Then
                preset3 = preset3 + ",V1" & ComboBox1.SelectedIndex + 1
            End If

            If ChkPrimaryColor.Checked = True Then
                preset3 = preset3 + "," & Label1.Text
            End If

            If ChkSecondaryColor.Checked = True Then
                preset3 = preset3 + "," & Label2.Text
            End If

            If ChkMinimumTime.Checked = True Then
                preset3 = preset3 + ",V4" & NumericUpDown2.Value * 100
            End If

            If ChkMaximumTime.Checked = True Then
                preset3 = preset3 + ",V5" & NumericUpDown3.Value * 100
            End If
            If ChkRandomizer.Checked = True Then
                preset3 = preset3 + ",V6" & NumericUpDown1.Value
            End If
            preset3 = preset3.Replace(",,", ",")

        ElseIf NumPreset.Value = 4 Then
            preset4 = ""
            If ChkMode.Checked = True Then
                preset4 = preset4 + ",V1" & ComboBox1.SelectedIndex + 1
            End If

            If ChkPrimaryColor.Checked = True Then
                preset4 = preset4 + "," & Label1.Text
            End If

            If ChkSecondaryColor.Checked = True Then
                preset4 = preset4 + "," & Label2.Text
            End If

            If ChkMinimumTime.Checked = True Then
                preset4 = preset4 + ",V4" & NumericUpDown2.Value * 100
            End If

            If ChkMaximumTime.Checked = True Then
                preset4 = preset4 + ",V5" & NumericUpDown3.Value * 100
            End If
            If ChkRandomizer.Checked = True Then
                preset4 = preset4 + ",V6" & NumericUpDown1.Value
            End If
            preset4 = preset4.Replace(",,", ",")

        ElseIf NumPreset.Value = 5 Then
            preset5 = ""
            If ChkMode.Checked = True Then
                preset5 = preset5 + ",V1" & ComboBox1.SelectedIndex + 1
            End If

            If ChkPrimaryColor.Checked = True Then
                preset5 = preset5 + "," & Label1.Text
            End If

            If ChkSecondaryColor.Checked = True Then
                preset5 = preset5 + "," & Label2.Text
            End If

            If ChkMinimumTime.Checked = True Then
                preset5 = preset5 + ",V4" & NumericUpDown2.Value * 100
            End If

            If ChkMaximumTime.Checked = True Then
                preset5 = preset5 + ",V5" & NumericUpDown3.Value * 100
            End If
            If ChkRandomizer.Checked = True Then
                preset5 = preset5 + ",V6" & NumericUpDown1.Value
            End If
            preset5 = preset5.Replace(",,", ",")

        ElseIf NumPreset.Value = 6 Then
            preset6 = ""
            If ChkMode.Checked = True Then
                preset6 = preset6 + ",V1" & ComboBox1.SelectedIndex + 1
            End If

            If ChkPrimaryColor.Checked = True Then
                preset6 = preset6 + "," & Label1.Text
            End If

            If ChkSecondaryColor.Checked = True Then
                preset6 = preset6 + "," & Label2.Text
            End If

            If ChkMinimumTime.Checked = True Then
                preset6 = preset6 + ",V4" & NumericUpDown2.Value * 100
            End If

            If ChkMaximumTime.Checked = True Then
                preset6 = preset6 + ",V5" & NumericUpDown3.Value * 100
            End If
            If ChkRandomizer.Checked = True Then
                preset6 = preset6 + ",V6" & NumericUpDown1.Value
            End If
            preset6 = preset6.Replace(",,", ",")

        ElseIf NumPreset.Value = 7 Then
            preset7 = ""
            If ChkMode.Checked = True Then
                preset7 = preset7 + ",V1" & ComboBox1.SelectedIndex + 1
            End If

            If ChkPrimaryColor.Checked = True Then
                preset7 = preset7 + "," & Label1.Text
            End If

            If ChkSecondaryColor.Checked = True Then
                preset7 = preset7 + "," & Label2.Text
            End If

            If ChkMinimumTime.Checked = True Then
                preset7 = preset7 + ",V4" & NumericUpDown2.Value * 100
            End If

            If ChkMaximumTime.Checked = True Then
                preset7 = preset7 + ",V5" & NumericUpDown3.Value * 100
            End If
            If ChkRandomizer.Checked = True Then
                preset7 = preset7 + ",V6" & NumericUpDown1.Value
            End If
            preset7 = preset7.Replace(",,", ",")

        ElseIf NumPreset.Value = 8 Then
            preset8 = ""
            If ChkMode.Checked = True Then
                preset8 = preset8 + ",V1" & ComboBox1.SelectedIndex + 1
            End If

            If ChkPrimaryColor.Checked = True Then
                preset8 = preset8 + "," & Label1.Text
            End If

            If ChkSecondaryColor.Checked = True Then
                preset8 = preset8 + "," & Label2.Text
            End If

            If ChkMinimumTime.Checked = True Then
                preset8 = preset8 + ",V4" & NumericUpDown2.Value * 100
            End If

            If ChkMaximumTime.Checked = True Then
                preset8 = preset8 + ",V5" & NumericUpDown3.Value * 100
            End If
            If ChkRandomizer.Checked = True Then
                preset8 = preset8 + ",V6" & NumericUpDown1.Value
            End If
            preset8 = preset8.Replace(",,", ",")

        ElseIf NumPreset.Value = 9 Then
            preset9 = ""
            If ChkMode.Checked = True Then
                preset9 = preset9 + ",V1" & ComboBox1.SelectedIndex + 1
            End If

            If ChkPrimaryColor.Checked = True Then
                preset9 = preset9 + "," & Label1.Text
            End If

            If ChkSecondaryColor.Checked = True Then
                preset9 = preset9 + "," & Label2.Text
            End If

            If ChkMinimumTime.Checked = True Then
                preset9 = preset9 + ",V4" & NumericUpDown2.Value * 100
            End If

            If ChkMaximumTime.Checked = True Then
                preset9 = preset9 + ",V5" & NumericUpDown3.Value * 100
            End If
            If ChkRandomizer.Checked = True Then
                preset9 = preset9 + ",V6" & NumericUpDown1.Value
            End If
            preset9 = preset9.Replace(",,", ",")

        ElseIf NumPreset.Value = 10 Then
            preset10 = ""
            If ChkMode.Checked = True Then
                preset10 = preset10 + ",V1" & ComboBox1.SelectedIndex + 1
            End If

            If ChkPrimaryColor.Checked = True Then
                preset10 = preset10 + "," & Label1.Text
            End If

            If ChkSecondaryColor.Checked = True Then
                preset10 = preset10 + "," & Label2.Text
            End If

            If ChkMinimumTime.Checked = True Then
                preset10 = preset10 + ",V4" & NumericUpDown2.Value * 100
            End If

            If ChkMaximumTime.Checked = True Then
                preset10 = preset10 + ",V5" & NumericUpDown3.Value * 100
            End If
            If ChkRandomizer.Checked = True Then
                preset10 = preset10 + ",V6" & NumericUpDown1.Value
            End If
            preset10 = preset10.Replace(",,", ",")

        End If
        If preset1.StartsWith(",") Then
            preset1 = preset1.Remove(0, 1)
        End If

        If preset2.StartsWith(",") Then
            preset2 = preset2.Remove(0, 1)
        End If

        If preset3.StartsWith(",") Then
            preset3 = preset3.Remove(0, 1)
        End If

        If preset4.StartsWith(",") Then
            preset4 = preset4.Remove(0, 1)
        End If

        If preset5.StartsWith(",") Then
            preset5 = preset5.Remove(0, 1)
        End If

        If preset6.StartsWith(",") Then
            preset6 = preset6.Remove(0, 1)
        End If

        If preset7.StartsWith(",") Then
            preset7 = preset7.Remove(0, 1)
        End If

        If preset8.StartsWith(",") Then
            preset8 = preset8.Remove(0, 1)
        End If

        If preset9.StartsWith(",") Then
            preset9 = preset9.Remove(0, 1)
        End If

        If preset10.StartsWith(",") Then
            preset10 = preset10.Remove(0, 1)
        End If



        button1ToolTipText = preset1
        button2ToolTipText = preset2
        button3ToolTipText = preset3
        button4ToolTipText = preset4
        button5ToolTipText = preset5
        button6ToolTipText = preset6
        button7ToolTipText = preset7
        button8ToolTipText = preset8
        button9ToolTipText = preset9
        button10ToolTipText = preset10

        ToolTip1.SetToolTip(Me.Button1, button1ToolTipText)
        ToolTip1.SetToolTip(Me.Button2, button2ToolTipText)
        ToolTip1.SetToolTip(Me.Button4, button3ToolTipText)
        ToolTip1.SetToolTip(Me.Button5, button4ToolTipText)
        ToolTip1.SetToolTip(Me.Button6, button5ToolTipText)
        ToolTip1.SetToolTip(Me.Button7, button6ToolTipText)
        ToolTip1.SetToolTip(Me.Button8, button7ToolTipText)
        ToolTip1.SetToolTip(Me.Button9, button8ToolTipText)
        ToolTip1.SetToolTip(Me.Button10, button9ToolTipText)
        ToolTip1.SetToolTip(Me.Button11, button10ToolTipText)


    End Sub

    Private Sub TrackBar4_Scroll(sender As Object, e As EventArgs) Handles TrackBar4.Scroll, TrackBar4.ValueChanged
        UpdateSeecondaryColorValues()

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        preset1 = INIRead(Application.StartupPath & "\SavedValues.ini", "Presets", "preset1")
        preset2 = INIRead(Application.StartupPath & "\SavedValues.ini", "Presets", "preset2")
        preset3 = INIRead(Application.StartupPath & "\SavedValues.ini", "Presets", "preset3")
        preset4 = INIRead(Application.StartupPath & "\SavedValues.ini", "Presets", "preset4")
        preset5 = INIRead(Application.StartupPath & "\SavedValues.ini", "Presets", "preset5")
        preset6 = INIRead(Application.StartupPath & "\SavedValues.ini", "Presets", "preset6")
        preset7 = INIRead(Application.StartupPath & "\SavedValues.ini", "Presets", "preset7")
        preset8 = INIRead(Application.StartupPath & "\SavedValues.ini", "Presets", "preset8")
        preset9 = INIRead(Application.StartupPath & "\SavedValues.ini", "Presets", "preset9")
        preset10 = INIRead(Application.StartupPath & "\SavedValues.ini", "Presets", "preset10")
    End Sub

    Private Sub TrackBar5_Scroll(sender As Object, e As EventArgs) Handles TrackBar5.Scroll, TrackBar5.ValueChanged
        UpdateSeecondaryColorValues()
    End Sub

    Private Sub TrackBar6_Scroll(sender As Object, e As EventArgs) Handles TrackBar6.Scroll, TrackBar6.ValueChanged
        UpdateSeecondaryColorValues()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        If ChkAutoSend.Checked = True Then
            Call btmSendAll_Click(Nothing, Nothing)
        Else
            UDPSend(PreFix & Label2.Text, TargetPort, TargetIP)
            tsLBL2.Text = PreFix & Label2.Text
            TmrClearlbls.Enabled = True
        End If

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        If ChkAutoSend.Checked = True Then
            Call btmSendAll_Click(Nothing, Nothing)
        Else
            UDPSend(PreFix & Label1.Text, TargetPort, TargetIP)
            tsLBL2.Text = PreFix & Label1.Text
            TmrClearlbls.Enabled = True
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        If prohibitUpdate = False Then
            ' MsgBox(ComboBox1.SelectedItem)
            '  MsgBox(ComboBox1.SelectedIndex + 1)

            If ChkAutoSend.Checked = True Then
                Call btmSendAll_Click(Nothing, Nothing)
            Else

                UDPSend(PreFix & "V1" & ComboBox1.SelectedIndex + 1, TargetPort, TargetIP)

                tsLBL2.Text = PreFix & "V1" & ComboBox1.SelectedIndex + 1
                TmrClearlbls.Enabled = True
            End If


        End If

    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If prohibitUpdate = False Then

            If ChkAutoSend.Checked = True Then
                Call btmSendAll_Click(Nothing, Nothing)
            Else

                UDPSend(PreFix & "V6" & NumericUpDown1.Value, TargetPort, TargetIP)

                tsLBL2.Text = PreFix & "V6" & NumericUpDown1.Value
                TmrClearlbls.Enabled = True
            End If


        End If

    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        If prohibitUpdate = False Then
            If ChkAutoSend.Checked = True Then
                Call btmSendAll_Click(Nothing, Nothing)
            Else
                UDPSend(PreFix & "V4" & NumericUpDown2.Value * 100, TargetPort, TargetIP)
                tsLBL2.Text = PreFix & "V4" & NumericUpDown2.Value
                TmrClearlbls.Enabled = True

            End If

        End If
    End Sub

    Private Sub NumericUpDown3_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown3.ValueChanged
        If prohibitUpdate = False Then

            If ChkAutoSend.Checked = True Then
                Call btmSendAll_Click(Nothing, Nothing)
            Else

                UDPSend(PreFix & "V5" & NumericUpDown3.Value * 100, TargetPort, TargetIP)
                tsLBL2.Text = PreFix & "V5" & NumericUpDown3.Value
                TmrClearlbls.Enabled = True
            End If

        End If
    End Sub

    Private Sub NetworkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NetworkToolStripMenuItem.Click

        FrmNetwork.ShowDialog()
    End Sub
End Class
