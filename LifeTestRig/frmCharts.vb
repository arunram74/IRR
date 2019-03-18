Imports System.ComponentModel
Imports System.Data.Common
Imports System.Windows.Forms.DataVisualization.Charting
Imports MySql.Data.MySqlClient

Public Class frmCharts
    Dim tempval As Integer
    Dim SelectedGraphHd As Integer = 0

    Dim con As MySqlConnection = New MySqlConnection(serv)
    Dim da As MySqlDataAdapter
    Dim dt As DataTable
    Dim ds As DataSet

    Dim bsvb As BindingSource = New BindingSource
    Dim bsspd As BindingSource = New BindingSource
    Dim bsLd As BindingSource = New BindingSource
    Dim bsbtmp As BindingSource = New BindingSource
    Dim bsotmp As BindingSource = New BindingSource

    Dim daGrph As DataAdapter
    Dim dtGrphVib, dtGrphSpeed, dtGrphLoadDisp, dtGrphBearing, dtGrphOilTemp As DataView
    Dim counter As Integer = 0

    Private Sub frmCharts_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        rdbMC1A.Text = My.Settings("MC1Size") & "A"
        rdbMC1B.Text = My.Settings("MC1Size") & "B"

        rdbMC2A.Text = My.Settings("MC2Size") & "A"
        rdbMC2B.Text = My.Settings("MC2Size") & "B"

        rdbMC3A.Text = My.Settings("MC3Size") & "A"
        rdbMC3B.Text = My.Settings("MC3Size") & "B"

        rdbMC4A.Text = My.Settings("MC4Size") & "A"
        rdbMC4B.Text = My.Settings("MC4Size") & "B"

        Dim SetVal As Integer = My.Settings("ChartHeadSel")
        If setval = 1 Then rdbMC1A.Checked = True
        If SetVal = 2 Then rdbMC1B.Checked = True
        If SetVal = 3 Then rdbMC2A.Checked = True
        If SetVal = 4 Then rdbMC2B.Checked = True
        If SetVal = 5 Then rdbMC3A.Checked = True
        If SetVal = 6 Then rdbMC3B.Checked = True
        If SetVal = 7 Then rdbMC4A.Checked = True
        If SetVal = 8 Then rdbMC4B.Checked = True

        HandleChecks()

        CreateGraphs(chrtVib, bsvb, CurrentHead.myProj.dtVibration)
        CreateGraphs(chrtSpd, bsspd, CurrentHead.myProj.dtSpeed)
        CreateGraphs(chrtLd, bsLd, CurrentHead.myProj.dtLoadDisp)
        CreateGraphs(chrtBT, bsbtmp, CurrentHead.myProj.dtBearing)
        CreateGraphs(chrtOT, bsotmp, CurrentHead.myProj.dtOilTemp)
        UpdateGraphs()
        TmrCharUpdate.Enabled = True
        counter = 0

    End Sub

    Private Sub TmrCharUpdate_Tick(sender As Object, e As EventArgs) Handles TmrCharUpdate.Tick

        TmrCharUpdate.Enabled = False

        If Not (CurrentHead.myProj.MyStatus = ProjectCls.ProjectStatus.Load Or CurrentHead.myProj.MyStatus = ProjectCls.ProjectStatus.Run) Then counter += 1 Else counter = 0

        If (CurrentHead.myProj.MyStatus = ProjectCls.ProjectStatus.Load Or CurrentHead.myProj.MyStatus = ProjectCls.ProjectStatus.Run) Or counter < 1 Then
            CalculateAverages()
            UpdateGraphValues()
            UpdateGraphs()
            TmrCharUpdate.Interval = CurrentHead.myProj.DispUpdateRate.TotalMilliseconds
            'counter = 0
        Else
            UpdateStatus()
        End If


        TmrCharUpdate.Enabled = True

    End Sub

    Sub CreateGraphs(grph As Chart, bs As BindingSource, grphdt As DataTable)
        Try
            Dim ColorSet() = {Color.Red, Color.Blue, Color.Green, Color.Brown, Color.Gray, Color.Purple}
            'bs.DataSource = grphdt
            'grph.DataSource = grphdt
            'grph.DataBind()
            For i = 0 To grphdt.Columns.Count - 1
                If grph.Series.Count < (i + 1) Then grph.Series.Add(i.ToString)
                grph.Series(i).ChartType = SeriesChartType.Line
                grph.Series(i).Color = ColorSet(i)
                grph.Series(i).Name = grphdt.Columns(i).ColumnName
                grph.Series(i).YValueMembers = grphdt.Columns(i).ColumnName
            Next

            grph.ChartAreas(0).AxisX.LabelStyle.Enabled = False
            grph.ChartAreas(0).AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet
            grph.ChartAreas(0).AxisY.MajorGrid.LineDashStyle = ChartDashStyle.NotSet
            grph.ChartAreas(0).AxisY.IsStartedFromZero = False
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub UpdateGraphs()

        Try
            'chrtVib.DataSource = ""
            'For Each Srs In chrtVib.Series
            '    Srs.Points.Clear()
            'Next
            'chrtSpd.DataSource = CurrentHead.myProj.dtVibration
            dtGrphVib = New DataView(CurrentHead.myProj.dtVibration)
            chrtVib.DataSource = dtGrphVib


            'chrtSpd.DataSource = ""
            'For Each Srs In chrtSpd.Series
            '    Srs.Points.Clear()
            'Next
            'chrtSpd.DataSource = CurrentHead.myProj.dtSpeed
            dtGrphSpeed = New DataView(CurrentHead.myProj.dtSpeed)
            chrtSpd.DataSource = dtGrphSpeed

            'chrtLd.DataSource = ""
            'For Each Srs In chrtLd.Series
            '    Srs.Points.Clear()
            'Next
            'chrtLd.DataSource = CurrentHead.myProj.dtLoadDisp
            dtGrphLoadDisp = New DataView(CurrentHead.myProj.dtLoadDisp)
            chrtLd.DataSource = dtGrphLoadDisp

            'chrtBT.DataSource = ""
            'For Each Srs In chrtBT.Series
            '    Srs.Points.Clear()
            'Next
            'chrtBT.DataSource = CurrentHead.myProj.dtBearing
            dtGrphBearing = New DataView(CurrentHead.myProj.dtBearing)
            chrtBT.DataSource = dtGrphBearing

            'chrtOT.DataSource = ""
            'For Each Srs In chrtOT.Series
            '    Srs.Points.Clear()
            'Next
            'chrtOT.DataSource = CurrentHead.myProj.dtOilTemp
            dtGrphOilTemp = New DataView(CurrentHead.myProj.dtOilTemp)
            chrtOT.DataSource = dtGrphOilTemp

            'bsvb.ResetBindings(False)
            'bsspd.ResetBindings(False)
            'bsLd.ResetBindings(False)
            'bsbtmp.ResetBindings(False)
            'bsotmp.ResetBindings(False)

            CurrentHead.myProj.DataUpdateLock.EnterReadLock()
            chrtVib.DataBind()
            chrtSpd.DataBind()
            chrtLd.DataBind()
            chrtBT.DataBind()
            chrtOT.DataBind()
            CurrentHead.myProj.DataUpdateLock.ExitReadLock()



        Catch ex As Exception
            '' MessageBox.Show(ex.Message.ToString, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '' ignore for now! Do nothing
        End Try
    End Sub

    Private Sub rdbMC1B_CheckedChanged(sender As Object, e As EventArgs) Handles rdbMC1B.CheckedChanged, rdbMC1A.CheckedChanged, rdbMC2B.CheckedChanged, rdbMC2A.CheckedChanged, rdbMC3B.CheckedChanged, rdbMC3A.CheckedChanged, rdbMC4B.CheckedChanged, rdbMC4A.CheckedChanged

        HandleChecks()
    End Sub

    Sub HandleChecks()
        If rdbMC1A.Checked Then
            CurrentHead = Station.MC1.HeadA
        ElseIf rdbMC1B.Checked Then
            CurrentHead = Station.MC1.HeadB
        ElseIf rdbMC2A.Checked Then
            CurrentHead = Station.MC2.HeadA
        ElseIf rdbMC2B.Checked Then
            CurrentHead = Station.MC2.HeadB
        ElseIf rdbMC3A.Checked Then
            CurrentHead = Station.MC3.HeadA
        ElseIf rdbMC3B.Checked Then
            CurrentHead = Station.MC3.HeadB
        ElseIf rdbMC4A.Checked Then
            CurrentHead = Station.MC4.HeadA
        ElseIf rdbMC4B.Checked Then
            CurrentHead = Station.MC4.HeadB
        End If

        'chrtVib.DataSource = CurrentHead.myProj.dtVibration
        'chrtSpd.DataSource = CurrentHead.myProj.dtSpeed
        'chrtLd.DataSource = CurrentHead.myProj.dtLoadDisp
        'chrtBT.DataSource = CurrentHead.myProj.dtBearing
        'chrtOT.DataSource = CurrentHead.myProj.dtOilTemp

        UpdateGraphValues()
        UpdateGraphs()
        If CurrentHead.myProj.ProjectID <> 0 Then
            CalculateAverages()
        Else
            lblB1Avg.Text = ""
            lblB2Avg.Text = ""
            lblB3Avg.Text = ""
            lblB4Avg.Text = ""
            lblLoadAvg.Text = ""
            lblSpeedAvg.Text = ""
            lblInTankAvg.Text = ""
            lblOutOilAvg.Text = ""
        End If

        counter = 0
    End Sub

    Sub UpdateGraphValues()
        'Update values
        lblVibSH.Text = CurrentHead.myProj.Vibration.SH
        lblVibSL.Text = CurrentHead.myProj.Vibration.SL
        lblVibWH.Text = CurrentHead.myProj.Vibration.WH
        lblVibWL.Text = CurrentHead.myProj.Vibration.WL
        lblVib.Text = String.Format("{0:n2}", CurrentHead.myProj.Vibration.Value)
        If CurrentHead.myProj.Vibration.Value <= CurrentHead.myProj.Vibration.SL Or CurrentHead.myProj.Vibration.Value >= CurrentHead.myProj.Vibration.SH Then
            lblVib.BackColor = Color.Red
        ElseIf CurrentHead.myProj.Vibration.Value <= CurrentHead.myProj.Vibration.WL Or CurrentHead.myProj.Vibration.Value >= CurrentHead.myProj.Vibration.WH Then
            lblVib.BackColor = Color.Yellow
        ElseIf CurrentHead.myProj.Vibration.Value < CurrentHead.myProj.Vibration.WH And CurrentHead.myProj.Vibration.Value > CurrentHead.myProj.Vibration.WL Then
            lblVib.BackColor = Color.Green
        Else
            lblVib.BackColor = Color.WhiteSmoke
        End If
        If CurrentHead.myProj.Vibration.Bypass Then lblVib.BackColor = Color.WhiteSmoke

        'Update values
        lblSpdSH.Text = CurrentHead.myProj.Speed.SH
        lblSpdSL.Text = CurrentHead.myProj.Speed.SL
        lblSpdWH.Text = CurrentHead.myProj.Speed.WH
        lblSpdWL.Text = CurrentHead.myProj.Speed.WL
        lblSpd.Text = String.Format("{0:n2}", CurrentHead.myProj.Speed.Value)
        If CurrentHead.myProj.Speed.Value <= CurrentHead.myProj.Speed.SL Or CurrentHead.myProj.Speed.Value >= CurrentHead.myProj.Speed.SH Then
            lblSpd.BackColor = Color.Red
        ElseIf CurrentHead.myProj.Speed.Value <= CurrentHead.myProj.Speed.WL Or CurrentHead.myProj.Speed.Value >= CurrentHead.myProj.Speed.WH Then
            lblSpd.BackColor = Color.Yellow
        ElseIf CurrentHead.myProj.Speed.Value < CurrentHead.myProj.Speed.WH And CurrentHead.myProj.Speed.Value > CurrentHead.myProj.Speed.WL Then
            lblSpd.BackColor = Color.Green
        Else
            lblSpd.BackColor = Color.WhiteSmoke
        End If
        If CurrentHead.myProj.Speed.Bypass Then lblSpd.BackColor = Color.WhiteSmoke

        'Update values
        Dim LoadLimitNotActive As Boolean = CurrentHead.PLC.GetTagVal("LoadLimNtAct" & CurrentHead.myProj.HeadName)
        lblLdSH.Text = CurrentHead.myProj.Load.SH
        lblLdSL.Text = CurrentHead.myProj.Load.SL
        lblLdWH.Text = CurrentHead.myProj.Load.WH
        lblLdWL.Text = CurrentHead.myProj.Load.WL
        lblLd.Text = String.Format("{0:n0}", CurrentHead.myProj.Load.Value)
        lblLdSet.Text = String.Format("{0:n2}", CurrentHead.myProj.CurrentLoad)
        If ((CurrentHead.myProj.Load.Value <= CurrentHead.myProj.Load.SL) And Not LoadLimitNotActive) Or CurrentHead.myProj.Load.Value >= CurrentHead.myProj.Load.SH Then
            lblLd.BackColor = Color.Red
        ElseIf ((CurrentHead.myProj.Load.Value <= CurrentHead.myProj.Load.WL) And Not LoadLimitNotActive) Or CurrentHead.myProj.Load.Value >= CurrentHead.myProj.Load.WH Then
            lblLd.BackColor = Color.Yellow
        ElseIf CurrentHead.myProj.Load.Value < CurrentHead.myProj.Load.WH And CurrentHead.myProj.Load.Value > CurrentHead.myProj.Load.WL Then
            lblLd.BackColor = Color.Green
        Else
            lblLd.BackColor = Color.WhiteSmoke
        End If
        If CurrentHead.myProj.Load.Bypass Then lblLd.BackColor = Color.WhiteSmoke


        'Update values
        lblB1SH.Text = CurrentHead.myProj.B1.SH
        lblB1SL.Text = CurrentHead.myProj.B1.SL
        lblB1WH.Text = CurrentHead.myProj.B1.WH
        lblB1WL.Text = CurrentHead.myProj.B1.WL
        lblB1.Text = String.Format("{0:0}", CurrentHead.myProj.B1.Value)
        If CurrentHead.myProj.B1.Value <= CurrentHead.myProj.B1.SL Or CurrentHead.myProj.B1.Value >= CurrentHead.myProj.B1.SH Then
            lblB1.BackColor = Color.Red
        ElseIf CurrentHead.myProj.B1.Value <= CurrentHead.myProj.B1.WL Or CurrentHead.myProj.B1.Value >= CurrentHead.myProj.B1.WH Then
            lblB1.BackColor = Color.Yellow
        ElseIf CurrentHead.myProj.B1.Value < CurrentHead.myProj.B1.WH And CurrentHead.myProj.B1.Value > CurrentHead.myProj.B1.WL Then
            lblB1.BackColor = Color.Green
        Else
            lblB1.BackColor = Color.WhiteSmoke
        End If
        If CurrentHead.myProj.B1.Bypass Then lblB1.BackColor = Color.WhiteSmoke



        'Update values
        lblB2SH.Text = CurrentHead.myProj.B2.SH
        lblB2SL.Text = CurrentHead.myProj.B2.SL
        lblB2WH.Text = CurrentHead.myProj.B2.WH
        lblB2WL.Text = CurrentHead.myProj.B2.WL
        lblB2.Text = String.Format("{0:0}", CurrentHead.myProj.B2.Value)
        If CurrentHead.myProj.B2.Value <= CurrentHead.myProj.B2.SL Or CurrentHead.myProj.B2.Value >= CurrentHead.myProj.B2.SH Then
            lblB2.BackColor = Color.Red
        ElseIf CurrentHead.myProj.B2.Value <= CurrentHead.myProj.B2.WL Or CurrentHead.myProj.B2.Value >= CurrentHead.myProj.B2.WH Then
            lblB2.BackColor = Color.Yellow
        ElseIf CurrentHead.myProj.B2.Value < CurrentHead.myProj.B2.WH And CurrentHead.myProj.B2.Value > CurrentHead.myProj.B2.WL Then
            lblB2.BackColor = Color.Green
        Else
            lblB2.BackColor = Color.WhiteSmoke
        End If
        If CurrentHead.myProj.B2.Bypass Then lblB2.BackColor = Color.WhiteSmoke

        'Update values
        lblB3SH.Text = CurrentHead.myProj.B3.SH
        lblB3SL.Text = CurrentHead.myProj.B3.SL
        lblB3WH.Text = CurrentHead.myProj.B3.WH
        lblB3WL.Text = CurrentHead.myProj.B3.WL
        lblB3.Text = String.Format("{0:0}", CurrentHead.myProj.B3.Value)
        If CurrentHead.myProj.B3.Value <= CurrentHead.myProj.B3.SL Or CurrentHead.myProj.B3.Value >= CurrentHead.myProj.B3.SH Then
            lblB3.BackColor = Color.Red
        ElseIf CurrentHead.myProj.B3.Value <= CurrentHead.myProj.B3.WL Or CurrentHead.myProj.B3.Value >= CurrentHead.myProj.B3.WH Then
            lblB3.BackColor = Color.Yellow
        ElseIf CurrentHead.myProj.B3.Value < CurrentHead.myProj.B3.WH And CurrentHead.myProj.B3.Value > CurrentHead.myProj.B3.WL Then
            lblB3.BackColor = Color.Green
        Else
            lblB3.BackColor = Color.WhiteSmoke
        End If
        If CurrentHead.myProj.B3.Bypass Then lblB3.BackColor = Color.WhiteSmoke

        'Update values
        lblB4SH.Text = CurrentHead.myProj.B4.SH
        lblB4SL.Text = CurrentHead.myProj.B4.SL
        lblB4WH.Text = CurrentHead.myProj.B4.WH
        lblB4WL.Text = CurrentHead.myProj.B4.WL
        lblB4.Text = String.Format("{0:0}", CurrentHead.myProj.B4.Value)
        If CurrentHead.myProj.B4.Value <= CurrentHead.myProj.B4.SL Or CurrentHead.myProj.B4.Value >= CurrentHead.myProj.B4.SH Then
            lblB4.BackColor = Color.Red
        ElseIf CurrentHead.myProj.B4.Value <= CurrentHead.myProj.B4.WL Or CurrentHead.myProj.B4.Value >= CurrentHead.myProj.B4.WH Then
            lblB4.BackColor = Color.Yellow
        ElseIf CurrentHead.myProj.B4.Value < CurrentHead.myProj.B4.WH And CurrentHead.myProj.B4.Value > CurrentHead.myProj.B4.WL Then
            lblB4.BackColor = Color.Green
        Else
            lblB4.BackColor = Color.WhiteSmoke
        End If
        If CurrentHead.myProj.B4.Bypass Then lblB4.BackColor = Color.WhiteSmoke

        'Update values
        Dim LimitNotActive As Boolean = CurrentHead.PLC.GetTagVal("TmpLimNtAct")
        lblLubSH.Text = CurrentHead.myProj.InTankTemp.SH
        lblLubSL.Text = CurrentHead.myProj.InTankTemp.SL
        lblLubWH.Text = CurrentHead.myProj.InTankTemp.WH
        lblLubWL.Text = CurrentHead.myProj.InTankTemp.WL
        lblLub.Text = String.Format("{0:0}", CurrentHead.myProj.InTankTemp.Value)
        If ((CurrentHead.myProj.InTankTemp.Value <= CurrentHead.myProj.InTankTemp.SL) And Not LimitNotActive) Or CurrentHead.myProj.InTankTemp.Value >= CurrentHead.myProj.InTankTemp.SH Then
            lblLub.BackColor = Color.Red
        ElseIf ((CurrentHead.myProj.InTankTemp.Value <= CurrentHead.myProj.InTankTemp.WL) And Not LimitNotActive) Or CurrentHead.myProj.InTankTemp.Value >= CurrentHead.myProj.InTankTemp.WH Then
            lblLub.BackColor = Color.Yellow
        ElseIf CurrentHead.myProj.InTankTemp.Value < CurrentHead.myProj.InTankTemp.WH And CurrentHead.myProj.InTankTemp.Value > CurrentHead.myProj.InTankTemp.WL Then
            lblLub.BackColor = Color.Green
        Else
            lblLub.BackColor = Color.WhiteSmoke
        End If
        If CurrentHead.myProj.InTankTemp.Bypass Then lblLub.BackColor = Color.WhiteSmoke

        'Update values
        lblOTSH.Text = CurrentHead.myProj.OutTankTemp.SH
        lblOTSL.Text = CurrentHead.myProj.OutTankTemp.SL
        lblOTWH.Text = CurrentHead.myProj.OutTankTemp.WH
        lblOTWL.Text = CurrentHead.myProj.OutTankTemp.WL
        lblOT.Text = String.Format("{0:0}", CurrentHead.myProj.OutTankTemp.Value)
        If CurrentHead.myProj.OutTankTemp.Value <= CurrentHead.myProj.OutTankTemp.SL Or CurrentHead.myProj.OutTankTemp.Value >= CurrentHead.myProj.OutTankTemp.SH Then
            lblOT.BackColor = Color.Red
        ElseIf CurrentHead.myProj.OutTankTemp.Value <= CurrentHead.myProj.OutTankTemp.WL Or CurrentHead.myProj.OutTankTemp.Value >= CurrentHead.myProj.OutTankTemp.WH Then
            lblOT.BackColor = Color.Yellow
        ElseIf CurrentHead.myProj.OutTankTemp.Value < CurrentHead.myProj.OutTankTemp.WH And CurrentHead.myProj.OutTankTemp.Value > CurrentHead.myProj.OutTankTemp.WL Then
            lblOT.BackColor = Color.Green
        Else
            lblOT.BackColor = Color.WhiteSmoke
        End If
        If CurrentHead.myProj.OutTankTemp.Bypass Then lblOT.BackColor = Color.WhiteSmoke


        If Not CurrentHead.myProj.ProjectID = 0 Then
            lblPrjIDTxt.Text = CurrentHead.myProj.ProjectIDTxt & "_" & CurrentHead.myProj.B1Name & "_" & CurrentHead.myProj.B2Name & "_" & CurrentHead.myProj.B3Name & "_" & CurrentHead.myProj.B4Name
        Else
            lblPrjIDTxt.Text = ""
        End If

        lblBearingType.Text = CurrentHead.myProj.BearingType
        lblBearingNo.Text = CurrentHead.myProj.B1Name & "_" & CurrentHead.myProj.B2Name & "_" & CurrentHead.myProj.B3Name & "_" & CurrentHead.myProj.B4Name
        lblStartTime.Text = CurrentHead.myProj.CreatedDate
        lblCurTime.Text = CurrentHead.myProj.TerminatedDate
        lblLife.Text = String.Format("{0:n2}", CurrentHead.myProj.CurrentLife)
        lblRev.Text = String.Format("{0:n4}", CurrentHead.myProj.CurrRev)
        UpdateStatus()
        txtITTSP.Text = CurrentHead.myProj.InTankTemp.Setpoint


    End Sub

    Sub UpdateStatus()
        Select Case CurrentHead.myProj.MyStatus
            Case ProjectCls.ProjectStatus.Run
                ledRun.On = True
                lblStatus.Text = "Run"
                lblStatus.BackColor = Color.GreenYellow
                ledIdle.On = False
                ledLoad.On = False
                ledStop.On = False
            Case ProjectCls.ProjectStatus.Idle
                ledRun.On = False
                lblStatus.Text = "Idle"
                lblStatus.BackColor = Color.OrangeRed
                ledIdle.On = True
                ledLoad.On = False
                ledStop.On = False
            Case ProjectCls.ProjectStatus.Load
                ledRun.On = False
                lblStatus.Text = "Load"
                lblStatus.BackColor = Color.Cyan
                ledIdle.On = False
                ledLoad.On = True
                ledStop.On = False
            Case ProjectCls.ProjectStatus.Suspended
                ledRun.On = False
                lblStatus.Text = "Suspended"
                lblStatus.BackColor = Color.Orange
                ledIdle.On = False
                ledLoad.On = False
                ledStop.On = True
            Case ProjectCls.ProjectStatus.Indeterminate
                ledRun.On = False
                lblStatus.Text = "Indeterminate"
                lblStatus.BackColor = SystemColors.Control
                ledIdle.On = False
                ledLoad.On = False
                ledStop.On = False
            Case Else
                ledRun.On = False
                lblStatus.Text = "Indeterminate"
                ledIdle.On = False
                ledLoad.On = False
                ledStop.On = False
        End Select
    End Sub

    Sub CalculateAverages()
        If CurrentHead.myProj.ProjectID <> 0 Then
            Dim constr As String = "SELECT Avg(BearingTemp1), Avg(BearingTemp2), Avg(BearingTemp3), Avg(BearingTemp4), Avg(LubOilTemp), Avg(TankOilTemp), Avg(Vibration), Avg(Speed), Avg(Load1)  FROM datalogs  where  ProjectID=" & CurrentHead.myProj.ProjectID & " and status='RUN ' order by idDataLogs"
            If GetDataMySQL(con, da, ds, dt, False, constr) Then
                If dt.Rows.Count > 0 Then
                    lblB1Avg.Text = String.Format("{0:n2}", If(IsDBNull(dt.Rows(0).Item("Avg(BearingTemp1)")), 0, dt.Rows(0).Item("Avg(BearingTemp1)")))
                    lblB2Avg.Text = String.Format("{0:n2}", If(IsDBNull(dt.Rows(0).Item("Avg(BearingTemp2)")), 0, dt.Rows(0).Item("Avg(BearingTemp2)")))
                    lblB3Avg.Text = String.Format("{0:n2}", If(IsDBNull(dt.Rows(0).Item("Avg(BearingTemp3)")), 0, dt.Rows(0).Item("Avg(BearingTemp3)")))
                    lblB4Avg.Text = String.Format("{0:n2}", If(IsDBNull(dt.Rows(0).Item("Avg(BearingTemp4)")), 0, dt.Rows(0).Item("Avg(BearingTemp4)")))
                    lblLoadAvg.Text = String.Format("{0:n2}", If(IsDBNull(dt.Rows(0).Item("Avg(Load1)")), 0, dt.Rows(0).Item("Avg(Load1)")))
                    lblSpeedAvg.Text = String.Format("{0:n2}", If(IsDBNull(dt.Rows(0).Item("Avg(Speed)")), 0, dt.Rows(0).Item("Avg(Speed)")))
                    lblInTankAvg.Text = String.Format("{0:n2}", If(IsDBNull(dt.Rows(0).Item("Avg(LubOilTemp)")), 0, dt.Rows(0).Item("Avg(LubOilTemp)")))
                    lblOutOilAvg.Text = String.Format("{0:n2}", If(IsDBNull(dt.Rows(0).Item("Avg(TankOilTemp)")), 0, dt.Rows(0).Item("Avg(TankOilTemp)")))
                End If
            End If
        End If
    End Sub

    Private Sub frmCharts_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd

    End Sub

    Private Sub frmCharts_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim SetVal As Integer = 0
        If rdbMC1A.Checked Then SetVal = 1
        If rdbMC1B.Checked Then SetVal = 2
        If rdbMC2A.Checked Then SetVal = 3
        If rdbMC2B.Checked Then SetVal = 4
        If rdbMC3A.Checked Then SetVal = 5
        If rdbMC3B.Checked Then SetVal = 6
        If rdbMC4A.Checked Then SetVal = 7
        If rdbMC4B.Checked Then SetVal = 8

        My.Settings("ChartHeadSel") = SetVal
        My.Settings.Save()

    End Sub
End Class
