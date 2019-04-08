
Imports LifeTestRig.Bulb

Public Class frmPLC
    'Dim WithEvents Tmr As New Timer
    Dim GreenColorSet As Color() = {Color.FromArgb(191, 255, 191), Color.FromArgb(128, 255, 128), Color.Lime, Color.FromArgb(0, 0, 0)}
    Dim RedColorSet As Color() = {Color.FromArgb(255, 191, 191), Color.FromArgb(255, 128, 128), Color.Red, Color.FromArgb(0, 0, 0)}



    Private Sub LedBulb1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub rdbMC1B_CheckedChanged(sender As Object, e As EventArgs) Handles rdbMC1A.CheckedChanged, rdbMC2A.CheckedChanged, rdbMC3A.CheckedChanged, rdbMC4A.CheckedChanged
        HandleChecks()
        UpDatePLCStatus()
    End Sub
    Sub HandleChecks()
        If rdbMC1A.Checked Then
            CurrentHead = Station.MC1.HeadA

        ElseIf rdbMC2A.Checked Then
            CurrentHead = Station.MC2.HeadA

        ElseIf rdbMC3A.Checked Then
            CurrentHead = Station.MC3.HeadA

        ElseIf rdbMC4A.Checked Then
            CurrentHead = Station.MC4.HeadA

        End If

    End Sub

    Private Sub frmPLC_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        rdbMC1A.Text = My.Settings("MC1Size")
        rdbMC2A.Text = My.Settings("MC2Size")
        rdbMC3A.Text = My.Settings("MC3Size")
        rdbMC4A.Text = My.Settings("MC4Size")

        'Tmr.Interval = 5000
        'Tmr.Enabled = True
        rdbMC1A.Checked = True

    End Sub

    Sub UpDatePLCStatus()
        SetLED(ledPnu, CurrentHead.PLC.GetTagVal("PnuematicPressure"))
        SetLED(ledLubLevel, CurrentHead.PLC.GetTagVal("LubeLevel"))
        SetLED(ledLubPres, CurrentHead.PLC.GetTagVal("LubePressure"))
        SetLED(ledLubPS, CurrentHead.PLC.GetTagVal("LubeOilSwitch"))
        SetLED(ledEmr, CurrentHead.PLC.GetTagVal("Emergency"))
        SetLED(ledMotTemp, CurrentHead.PLC.GetTagVal("MotorTemp"))
        SetLED(ledDriveStat, CurrentHead.PLC.GetTagVal("DriveStatus"))
        SetLED(ledHtTherm, CurrentHead.PLC.GetTagVal("HeaterThermister"))
        SetLED(ledMediaLvl, CurrentHead.PLC.GetTagVal("MediaLevel"))
        SetLED(ledMCBStat, CurrentHead.PLC.GetTagVal("MCBStatus"))
        SetLED(ledBoost, CurrentHead.PLC.GetTagVal("BoosterEndofStroke"))
        ''  SetLED(ledByp, CurrentHead.PLC.GetTagVal("BypassON"))



        lblVibA.Text = String.Format("{0:n2}", CurrentHead.PLC.GetTagVal("VibrationA_actVal"))
        lblVibB.Text = String.Format("{0:n2}", CurrentHead.PLC.GetTagVal("VibrationB_actVal"))

        lblSpd.Text = String.Format("{0:n0}", CurrentHead.PLC.GetTagVal("Speed_actVal"))
        lblLdA.Text = String.Format("{0:n0}", CurrentHead.PLC.GetTagVal("LoadA_actVal"))
        lblLDB.Text = String.Format("{0:n0}", CurrentHead.PLC.GetTagVal("LoadB_actVal"))

        lblB1A.Text = String.Format("{0:n2}", CurrentHead.PLC.GetTagVal("B1TempA_actVal"))
        lblB2A.Text = String.Format("{0:n2}", CurrentHead.PLC.GetTagVal("B2TempA_actVal"))
        lblB3A.Text = String.Format("{0:n2}", CurrentHead.PLC.GetTagVal("B3TempA_actVal"))
        lblB4A.Text = String.Format("{0:n2}", CurrentHead.PLC.GetTagVal("B4TempA_actVal"))

        lblB1B.Text = String.Format("{0:n2}", CurrentHead.PLC.GetTagVal("B1TempB_actVal"))
        lblB2B.Text = String.Format("{0:n2}", CurrentHead.PLC.GetTagVal("B2TempB_actVal"))
        lblB3B.Text = String.Format("{0:n2}", CurrentHead.PLC.GetTagVal("B3TempB_actVal"))
        lblB4B.Text = String.Format("{0:n2}", CurrentHead.PLC.GetTagVal("B4TempB_actVal"))

        lblLub.Text = String.Format("{0:n2}", CurrentHead.PLC.GetTagVal("InTankTemp_actVal"))
        lblOT.Text = String.Format("{0:n2}", CurrentHead.PLC.GetTagVal("OutTankTemp_actVal"))


        Stn1.On = PLCStations(1).IsStnAvailable
        Stn2.On = PLCStations(2).IsStnAvailable
        Stn3.On = PLCStations(3).IsStnAvailable
        Stn4.On = PLCStations(4).IsStnAvailable
        Stn5.On = PLCStations(5).IsStnAvailable
        Stn6.On = PLCStations(6).IsStnAvailable
        Stn7.On = PLCStations(7).IsStnAvailable
        Stn8.On = PLCStations(8).IsStnAvailable
        Stn9.On = PLCStations(9).IsStnAvailable
        Stn10.On = PLCStations(10).IsStnAvailable
        Stn11.On = PLCStations(11).IsStnAvailable
        Stn12.On = PLCStations(12).IsStnAvailable

        Dim PLCStnStr As String = My.Settings.Item("PLCStations")
        Dim strArr() As String = PLCStnStr.Split(","c)

        btnChkStn1.Enabled = (Not PLCStations(1).IsStnAvailable) And strArr(0) <> 0
        btnChkStn2.Enabled = (Not PLCStations(2).IsStnAvailable) And strArr(1) <> 0
        btnChkStn3.Enabled = (Not PLCStations(3).IsStnAvailable) And strArr(2) <> 0
        btnChkStn4.Enabled = (Not PLCStations(4).IsStnAvailable) And strArr(3) <> 0
        btnChkStn5.Enabled = (Not PLCStations(5).IsStnAvailable) And strArr(4) <> 0
        btnChkStn6.Enabled = (Not PLCStations(6).IsStnAvailable) And strArr(5) <> 0
        btnChkStn7.Enabled = (Not PLCStations(7).IsStnAvailable) And strArr(6) <> 0
        btnChkStn8.Enabled = (Not PLCStations(8).IsStnAvailable) And strArr(7) <> 0
        btnChkStn9.Enabled = (Not PLCStations(9).IsStnAvailable) And strArr(8) <> 0
        btnChkStn10.Enabled = (Not PLCStations(10).IsStnAvailable) And strArr(9) <> 0
        btnChkStn11.Enabled = (Not PLCStations(11).IsStnAvailable) And strArr(10) <> 0
        btnChkStn12.Enabled = (Not PLCStations(12).IsStnAvailable) And strArr(11) <> 0


    End Sub

    Sub SetLED(LED As LedBulb, GreenOrRed As Boolean) 'Greed=false REd=True
        If Not GreenOrRed Then
            LED.LightLightColor = GreenColorSet(0)
            LED.Color = GreenColorSet(1)
            LED.DarkColor = GreenColorSet(2)
            LED.DarkDarkColor = GreenColorSet(3)
        Else
            LED.LightLightColor = RedColorSet(0)
            LED.Color = RedColorSet(1)
            LED.DarkColor = RedColorSet(2)
            LED.DarkDarkColor = RedColorSet(3)
        End If
    End Sub



    Private Sub btnChkStn_Click(sender As Object, e As EventArgs) Handles btnChkStn1.Click, btnChkStn2.Click, btnChkStn3.Click, btnChkStn4.Click, btnChkStn5.Click, btnChkStn6.Click, btnChkStn7.Click, btnChkStn8.Click, btnChkStn9.Click, btnChkStn10.Click, btnChkStn11.Click, btnChkStn12.Click
        Dim btn As Button = sender
        PLCStations(btn.Tag).CheckComms = True
    End Sub

    Private Sub frmPLC_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        UpDatePLCStatus()
    End Sub

    Private Sub Tmr_Tick(sender As Object, e As EventArgs) Handles Tmr.Tick
        UpDatePLCStatus()
    End Sub
End Class
