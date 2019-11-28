
Imports IRR.Bulb

Public Class frmPLC
    'Dim WithEvents Tmr As New Timer
    Dim GreenColorSet As Color() = {Color.FromArgb(191, 255, 191), Color.FromArgb(128, 255, 128), Color.Lime, Color.FromArgb(0, 0, 0)}
    Dim RedColorSet As Color() = {Color.FromArgb(255, 191, 191), Color.FromArgb(255, 128, 128), Color.Red, Color.FromArgb(0, 0, 0)}




    Private Sub rdbMC1B_CheckedChanged(sender As Object, e As EventArgs)

        UpDatePLCStatus()
    End Sub




    Sub UpDatePLCStatus()
        SetLED(ledPnu, Station.MC.PLC.GetTagVal("PnuematicPressure"))
        SetLED(ledLubLevel, Station.MC.PLC.GetTagVal("LubeLevel"))
        SetLED(ledLubPres, Station.MC.PLC.GetTagVal("LubePressure"))
        SetLED(ledLubPS, Station.MC.PLC.GetTagVal("LubeOilSwitch"))
        SetLED(ledEmr, Station.MC.PLC.GetTagVal("Emergency"))
        SetLED(ledMotTemp, Station.MC.PLC.GetTagVal("MotorTemp"))
        SetLED(ledDriveStat, Station.MC.PLC.GetTagVal("DriveStatus"))
        SetLED(ledHtTherm, Station.MC.PLC.GetTagVal("HeaterThermister"))
        SetLED(ledMediaLvl, Station.MC.PLC.GetTagVal("MediaLevel"))
        SetLED(ledMCBStat, Station.MC.PLC.GetTagVal("MCBStatus"))
        SetLED(ledBoost, Station.MC.PLC.GetTagVal("BoosterEndofStroke"))
        ''  SetLED(ledByp, Station.MC.PLC.GetTagVal("BypassON"))



        lblVibA.Text = String.Format("{0:n2}", Station.MC.PLC.GetTagVal("VibrationA_actVal"))
        lblVibB.Text = String.Format("{0:n2}", Station.MC.PLC.GetTagVal("VibrationB_actVal"))
        lblVibC.Text = String.Format("{0:n2}", Station.MC.PLC.GetTagVal("VibrationA_actVal"))
        lblVibD.Text = String.Format("{0:n2}", Station.MC.PLC.GetTagVal("VibrationB_actVal"))

        lblSpd.Text = String.Format("{0:n0}", Station.MC.PLC.GetTagVal("Speed_actVal"))
        lblLoad.Text = String.Format("{0:n0}", Station.MC.PLC.GetTagVal("Load_actVal"))

        lblBA.Text = String.Format("{0:n2}", Station.MC.PLC.GetTagVal("BTempA_actVal"))
        lblBB.Text = String.Format("{0:n2}", Station.MC.PLC.GetTagVal("BTempA_actVal"))
        lblBC.Text = String.Format("{0:n2}", Station.MC.PLC.GetTagVal("BTempA_actVal"))
        lblBD.Text = String.Format("{0:n2}", Station.MC.PLC.GetTagVal("BTempA_actVal"))

        lblSBA.Text = String.Format("{0:n2}", Station.MC.PLC.GetTagVal("SBTempA_actVal"))
        lblSBB.Text = String.Format("{0:n2}", Station.MC.PLC.GetTagVal("SBTempB_actVal"))
        lblSBC.Text = String.Format("{0:n2}", Station.MC.PLC.GetTagVal("SBTempC_actVal"))
        lblSBD.Text = String.Format("{0:n2}", Station.MC.PLC.GetTagVal("SBTempD_actVal"))

        lblInlet_TempA.Text = String.Format("{0:n2}", Station.MC.PLC.GetTagVal("Inlet_TempA_ActVal"))
        lblInlet_TempB.Text = String.Format("{0:n2}", Station.MC.PLC.GetTagVal("Inlet_TempB_ActVal"))
        lblInlet_TempC.Text = String.Format("{0:n2}", Station.MC.PLC.GetTagVal("Inlet_TempC_ActVal"))
        lblInlet_TempD.Text = String.Format("{0:n2}", Station.MC.PLC.GetTagVal("Inlet_TempD_ActVal"))


        lblOT.Text = String.Format("{0:n2}", Station.MC.PLC.GetTagVal("OutTankTemp_actVal"))


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
