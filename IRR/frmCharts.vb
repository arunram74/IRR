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
    Dim dtGrphVib, dtGrphSpeed, dtGrphLoadDisp, dtGrphBearing, dtGrphOilTemp As DataTable
    Dim counter As Integer = 0

    Private Sub frmCharts_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        HandleChecks()

        CreateGraphs(chrtVib, bsvb, Station.MC.myProj.dtVibration)
        CreateGraphs(chrtSpd, bsspd, Station.MC.myProj.dtSpeed)
        CreateGraphs(chrtLd, bsLd, Station.MC.myProj.dtLoadDisp)
        CreateGraphs(chrtBT, bsbtmp, Station.MC.myProj.dtBearing)
        CreateGraphs(chrtOT, bsotmp, Station.MC.myProj.dtOilTemp)
        UpdateGraphs()
        TmrCharUpdate.Enabled = True
        counter = 0

    End Sub

    Private Sub TmrCharUpdate_Tick(sender As Object, e As EventArgs) Handles TmrCharUpdate.Tick

        TmrCharUpdate.Enabled = False

        If Not (Station.MC.myProj.MyStatus = ProjectCls.ProjectStatus.Load Or Station.MC.myProj.MyStatus = ProjectCls.ProjectStatus.Run) Then counter += 1 Else counter = 0

        If (Station.MC.myProj.MyStatus = ProjectCls.ProjectStatus.Load Or Station.MC.myProj.MyStatus = ProjectCls.ProjectStatus.Run) Or counter < 2 Then

            'If (Station.MC.myProj.MyStatus = ProjectCls.ProjectStatus.Load Or Station.MC.myProj.MyStatus = ProjectCls.ProjectStatus.Run) Then
            CalculateAverages()
            UpdateGraphValues()
            UpdateGraphs()
            If Station.MC.myProj.DispUpdateRate.TotalMilliseconds <> 0 Then TmrCharUpdate.Interval = Station.MC.myProj.DispUpdateRate.TotalMilliseconds
            counter = 0
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
            'chrtSpd.DataSource = Station.MC.myProj.dtVibration
            'dtGrphVib = New DataView(Station.MC.myProj.dtVibration)
            dtGrphVib = Station.MC.myProj.dtVibration.Copy
            chrtVib.DataSource = dtGrphVib


            'chrtSpd.DataSource = ""
            'For Each Srs In chrtSpd.Series
            '    Srs.Points.Clear()
            'Next
            'chrtSpd.DataSource = Station.MC.myProj.dtSpeed
            'dtGrphSpeed = New DataView(Station.MC.myProj.dtSpeed)
            dtGrphSpeed = Station.MC.myProj.dtSpeed.Copy
            chrtSpd.DataSource = dtGrphSpeed

            'chrtLd.DataSource = ""
            'For Each Srs In chrtLd.Series
            '    Srs.Points.Clear()
            'Next
            'chrtLd.DataSource = Station.MC.myProj.dtLoadDisp
            dtGrphLoadDisp = Station.MC.myProj.dtLoadDisp.Copy
            chrtLd.DataSource = dtGrphLoadDisp

            'chrtBT.DataSource = ""
            'For Each Srs In chrtBT.Series
            '    Srs.Points.Clear()
            'Next
            'chrtBT.DataSource = Station.MC.myProj.dtBearing
            dtGrphBearing = Station.MC.myProj.dtBearing.Copy
            chrtBT.DataSource = dtGrphBearing

            'chrtOT.DataSource = ""
            'For Each Srs In chrtOT.Series
            '    Srs.Points.Clear()
            'Next
            'chrtOT.DataSource = Station.MC.myProj.dtOilTemp
            dtGrphOilTemp = Station.MC.myProj.dtOilTemp.Copy
            chrtOT.DataSource = dtGrphOilTemp

            'bsvb.ResetBindings(False)
            'bsspd.ResetBindings(False)
            'bsLd.ResetBindings(False)
            'bsbtmp.ResetBindings(False)
            'bsotmp.ResetBindings(False)

            'Station.MC.myProj.DataUpdateLock.EnterReadLock()
            chrtVib.DataBind()
            chrtSpd.DataBind()
            chrtLd.DataBind()
            chrtBT.DataBind()
            chrtOT.DataBind()
            'Station.MC.myProj.DataUpdateLock.ExitReadLock()



        Catch ex As Exception
            ''MessageBox.Show(ex.Message.ToString, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '' ignore for now! Do nothing
        End Try
    End Sub

    Private Sub rdbMC1B_CheckedChanged(sender As Object, e As EventArgs)

        HandleChecks()
    End Sub

    Sub HandleChecks()

        'chrtVib.DataSource = Station.MC.myProj.dtVibration
        'chrtSpd.DataSource = Station.MC.myProj.dtSpeed
        'chrtLd.DataSource = Station.MC.myProj.dtLoadDisp
        'chrtBT.DataSource = Station.MC.myProj.dtBearing
        'chrtOT.DataSource = Station.MC.myProj.dtOilTemp

        UpdateGraphValues()
        UpdateGraphs()
        If Station.MC.myProj.ProjectID <> 0 Then
            CalculateAverages()
        Else

            lblLoadAvg.Text = ""
            lblSpeedAvg.Text = ""
            lblInTankAvg.Text = ""
            lblOutOilAvg.Text = ""
        End If

        counter = 0
    End Sub

    Sub UpdateGraphValues()
        'Update values
        lblVibASH.Text = Station.MC.myProj.VibrationA.SH
        lblVibASL.Text = Station.MC.myProj.VibrationA.SL
        lblVibAWH.Text = Station.MC.myProj.VibrationA.WH
        lblVibAWL.Text = Station.MC.myProj.VibrationA.WL

        lblVibA.Text = String.Format("{0:n2}", Station.MC.myProj.VibrationA.Value)
        If Station.MC.myProj.VibrationA.Value <= Station.MC.myProj.VibrationA.SL Or Station.MC.myProj.VibrationA.Value >= Station.MC.myProj.VibrationA.SH Then
            lblVibA.BackColor = Color.Red
        ElseIf Station.MC.myProj.VibrationA.Value <= Station.MC.myProj.VibrationA.WL Or Station.MC.myProj.VibrationA.Value >= Station.MC.myProj.VibrationA.WH Then
            lblVibA.BackColor = Color.Yellow
        ElseIf Station.MC.myProj.VibrationA.Value < Station.MC.myProj.VibrationA.WH And Station.MC.myProj.VibrationA.Value > Station.MC.myProj.VibrationA.WL Then
            lblVibA.BackColor = Color.Green
        Else
            lblVibA.BackColor = Color.WhiteSmoke
        End If
        If Station.MC.myProj.VibrationA.Bypass Then lblVibA.BackColor = Color.WhiteSmoke

        'Update values
        lblVibBSH.Text = Station.MC.myProj.VibrationB.SH
        lblVibBSL.Text = Station.MC.myProj.VibrationB.SL
        lblVibBWH.Text = Station.MC.myProj.VibrationB.WH
        lblVibBWL.Text = Station.MC.myProj.VibrationB.WL

        lblVibB.Text = String.Format("{0:n2}", Station.MC.myProj.VibrationB.Value)
        If Station.MC.myProj.VibrationB.Value <= Station.MC.myProj.VibrationB.SL Or Station.MC.myProj.VibrationB.Value >= Station.MC.myProj.VibrationB.SH Then
            lblVibB.BackColor = Color.Red
        ElseIf Station.MC.myProj.VibrationB.Value <= Station.MC.myProj.VibrationB.WL Or Station.MC.myProj.VibrationB.Value >= Station.MC.myProj.VibrationB.WH Then
            lblVibB.BackColor = Color.Yellow
        ElseIf Station.MC.myProj.VibrationB.Value < Station.MC.myProj.VibrationB.WH And Station.MC.myProj.VibrationB.Value > Station.MC.myProj.VibrationB.WL Then
            lblVibB.BackColor = Color.Green
        Else
            lblVibB.BackColor = Color.WhiteSmoke
        End If
        If Station.MC.myProj.VibrationB.Bypass Then lblVibB.BackColor = Color.WhiteSmoke

        'Update values
        lblVibCSH.Text = Station.MC.myProj.VibrationC.SH
        lblVibCSL.Text = Station.MC.myProj.VibrationC.SL
        lblVibCWH.Text = Station.MC.myProj.VibrationC.WH
        lblVibCWL.Text = Station.MC.myProj.VibrationC.WL

        lblVibC.Text = String.Format("{0:n2}", Station.MC.myProj.VibrationC.Value)
        If Station.MC.myProj.VibrationC.Value <= Station.MC.myProj.VibrationC.SL Or Station.MC.myProj.VibrationC.Value >= Station.MC.myProj.VibrationC.SH Then
            lblVibC.BackColor = Color.Red
        ElseIf Station.MC.myProj.VibrationC.Value <= Station.MC.myProj.VibrationC.WL Or Station.MC.myProj.VibrationC.Value >= Station.MC.myProj.VibrationC.WH Then
            lblVibC.BackColor = Color.Yellow
        ElseIf Station.MC.myProj.VibrationC.Value < Station.MC.myProj.VibrationC.WH And Station.MC.myProj.VibrationC.Value > Station.MC.myProj.VibrationC.WL Then
            lblVibC.BackColor = Color.Green
        Else
            lblVibC.BackColor = Color.WhiteSmoke
        End If
        If Station.MC.myProj.VibrationC.Bypass Then lblVibC.BackColor = Color.WhiteSmoke

        'Update values
        lblVibDSH.Text = Station.MC.myProj.VibrationD.SH
        lblVibDSL.Text = Station.MC.myProj.VibrationD.SL
        lblVibDWH.Text = Station.MC.myProj.VibrationD.WH
        lblVibDWL.Text = Station.MC.myProj.VibrationD.WL

        lblVibD.Text = String.Format("{0:n2}", Station.MC.myProj.VibrationD.Value)
        If Station.MC.myProj.VibrationD.Value <= Station.MC.myProj.VibrationD.SL Or Station.MC.myProj.VibrationD.Value >= Station.MC.myProj.VibrationD.SH Then
            lblVibD.BackColor = Color.Red
        ElseIf Station.MC.myProj.VibrationD.Value <= Station.MC.myProj.VibrationD.WL Or Station.MC.myProj.VibrationD.Value >= Station.MC.myProj.VibrationD.WH Then
            lblVibD.BackColor = Color.Yellow
        ElseIf Station.MC.myProj.VibrationD.Value < Station.MC.myProj.VibrationD.WH And Station.MC.myProj.VibrationD.Value > Station.MC.myProj.VibrationD.WL Then
            lblVibD.BackColor = Color.Green
        Else
            lblVibD.BackColor = Color.WhiteSmoke
        End If
        If Station.MC.myProj.VibrationD.Bypass Then lblVibD.BackColor = Color.WhiteSmoke

        'Update values
        lblSpdSH.Text = Station.MC.myProj.Speed.SH
        lblSpdSL.Text = Station.MC.myProj.Speed.SL
        lblSpdWH.Text = Station.MC.myProj.Speed.WH
        lblSpdWL.Text = Station.MC.myProj.Speed.WL
        lblSpd.Text = String.Format("{0:n2}", Station.MC.myProj.Speed.Value)
        lblSpdSet.Text = String.Format("{0:n2}", Station.MC.myProj.Speed.Setpoint)
        If Station.MC.myProj.Speed.Value <= Station.MC.myProj.Speed.SL Or Station.MC.myProj.Speed.Value >= Station.MC.myProj.Speed.SH Then
            lblSpd.BackColor = Color.Red
        ElseIf Station.MC.myProj.Speed.Value <= Station.MC.myProj.Speed.WL Or Station.MC.myProj.Speed.Value >= Station.MC.myProj.Speed.WH Then
            lblSpd.BackColor = Color.Yellow
        ElseIf Station.MC.myProj.Speed.Value < Station.MC.myProj.Speed.WH And Station.MC.myProj.Speed.Value > Station.MC.myProj.Speed.WL Then
            lblSpd.BackColor = Color.Green
        Else
            lblSpd.BackColor = Color.WhiteSmoke
        End If
        If Station.MC.myProj.Speed.Bypass Then lblSpd.BackColor = Color.WhiteSmoke

        'Update values
        Dim LoadLimitNotActive As Boolean = Station.MC.PLC.GetTagVal("LoadLimNtAct")
        lblLdSH.Text = Station.MC.myProj.Load.SH
        lblLdSL.Text = Station.MC.myProj.Load.SL
        lblLdWH.Text = Station.MC.myProj.Load.WH
        lblLdWL.Text = Station.MC.myProj.Load.WL
        lblLd.Text = String.Format("{0:n0}", Station.MC.myProj.Load.Value)
        lblLdSet.Text = String.Format("{0:n2}", Station.MC.myProj.CurrentLoad)
        If ((Station.MC.myProj.Load.Value <= Station.MC.myProj.Load.SL) And Not LoadLimitNotActive) Or Station.MC.myProj.Load.Value >= Station.MC.myProj.Load.SH Then
            lblLd.BackColor = Color.Red
        ElseIf ((Station.MC.myProj.Load.Value <= Station.MC.myProj.Load.WL) And Not LoadLimitNotActive) Or Station.MC.myProj.Load.Value >= Station.MC.myProj.Load.WH Then
            lblLd.BackColor = Color.Yellow
        ElseIf Station.MC.myProj.Load.Value < Station.MC.myProj.Load.WH And Station.MC.myProj.Load.Value > Station.MC.myProj.Load.WL Then
            lblLd.BackColor = Color.Green
        Else
            lblLd.BackColor = Color.WhiteSmoke
        End If
        If Station.MC.myProj.Load.Bypass Then lblLd.BackColor = Color.WhiteSmoke


        'Update values
        lblB1SH.Text = Station.MC.myProj.BA.SH
        lblB1SL.Text = Station.MC.myProj.BA.SL
        lblB1WH.Text = Station.MC.myProj.BA.WH
        lblB1WL.Text = Station.MC.myProj.BA.WL
        lblB1.Text = String.Format("{0:0}", Station.MC.myProj.BA.Value)
        If Station.MC.myProj.BA.Value <= Station.MC.myProj.BA.SL Or Station.MC.myProj.BA.Value >= Station.MC.myProj.BA.SH Then
            lblB1.BackColor = Color.Red
        ElseIf Station.MC.myProj.BA.Value <= Station.MC.myProj.BA.WL Or Station.MC.myProj.BA.Value >= Station.MC.myProj.BA.WH Then
            lblB1.BackColor = Color.Yellow
        ElseIf Station.MC.myProj.BA.Value < Station.MC.myProj.BA.WH And Station.MC.myProj.BA.Value > Station.MC.myProj.BA.WL Then
            lblB1.BackColor = Color.Green
        Else
            lblB1.BackColor = Color.WhiteSmoke
        End If
        If Station.MC.myProj.BA.Bypass Then lblB1.BackColor = Color.WhiteSmoke



        'Update values
        lblB2SH.Text = Station.MC.myProj.BB.SH
        lblB2SL.Text = Station.MC.myProj.BB.SL
        lblB2WH.Text = Station.MC.myProj.BB.WH
        lblB2WL.Text = Station.MC.myProj.BB.WL
        lblB2.Text = String.Format("{0:0}", Station.MC.myProj.BB.Value)
        If Station.MC.myProj.BB.Value <= Station.MC.myProj.BB.SL Or Station.MC.myProj.BB.Value >= Station.MC.myProj.BB.SH Then
            lblB2.BackColor = Color.Red
        ElseIf Station.MC.myProj.BB.Value <= Station.MC.myProj.BB.WL Or Station.MC.myProj.BB.Value >= Station.MC.myProj.BB.WH Then
            lblB2.BackColor = Color.Yellow
        ElseIf Station.MC.myProj.BB.Value < Station.MC.myProj.BB.WH And Station.MC.myProj.BB.Value > Station.MC.myProj.BB.WL Then
            lblB2.BackColor = Color.Green
        Else
            lblB2.BackColor = Color.WhiteSmoke
        End If
        If Station.MC.myProj.BB.Bypass Then lblB2.BackColor = Color.WhiteSmoke

        'Update values
        lblB3SH.Text = Station.MC.myProj.BC.SH
        lblB3SL.Text = Station.MC.myProj.BC.SL
        lblB3WH.Text = Station.MC.myProj.BC.WH
        lblB3WL.Text = Station.MC.myProj.BC.WL
        lblB3.Text = String.Format("{0:0}", Station.MC.myProj.BC.Value)
        If Station.MC.myProj.BC.Value <= Station.MC.myProj.BC.SL Or Station.MC.myProj.BC.Value >= Station.MC.myProj.BC.SH Then
            lblB3.BackColor = Color.Red
        ElseIf Station.MC.myProj.BC.Value <= Station.MC.myProj.BC.WL Or Station.MC.myProj.BC.Value >= Station.MC.myProj.BC.WH Then
            lblB3.BackColor = Color.Yellow
        ElseIf Station.MC.myProj.BC.Value < Station.MC.myProj.BC.WH And Station.MC.myProj.BC.Value > Station.MC.myProj.BC.WL Then
            lblB3.BackColor = Color.Green
        Else
            lblB3.BackColor = Color.WhiteSmoke
        End If
        If Station.MC.myProj.BC.Bypass Then lblB3.BackColor = Color.WhiteSmoke

        'Update values
        lblB4SH.Text = Station.MC.myProj.BD.SH
        lblB4SL.Text = Station.MC.myProj.BD.SL
        lblB4WH.Text = Station.MC.myProj.BD.WH
        lblB4WL.Text = Station.MC.myProj.BD.WL
        lblB4.Text = String.Format("{0:0}", Station.MC.myProj.BD.Value)
        If Station.MC.myProj.BD.Value <= Station.MC.myProj.BD.SL Or Station.MC.myProj.BD.Value >= Station.MC.myProj.BD.SH Then
            lblB4.BackColor = Color.Red
        ElseIf Station.MC.myProj.BD.Value <= Station.MC.myProj.BD.WL Or Station.MC.myProj.BD.Value >= Station.MC.myProj.BD.WH Then
            lblB4.BackColor = Color.Yellow
        ElseIf Station.MC.myProj.BD.Value < Station.MC.myProj.BD.WH And Station.MC.myProj.BD.Value > Station.MC.myProj.BD.WL Then
            lblB4.BackColor = Color.Green
        Else
            lblB4.BackColor = Color.WhiteSmoke
        End If
        If Station.MC.myProj.BD.Bypass Then lblB4.BackColor = Color.WhiteSmoke

        'Update values
        Dim LimitNotActive As Boolean = Station.MC.PLC.GetTagVal("TmpLimNtAct")
        lblLubSH.Text = Station.MC.myProj.Inlet_TempA.SH
        lblLubSL.Text = Station.MC.myProj.Inlet_TempA.SL
        lblLubWH.Text = Station.MC.myProj.Inlet_TempA.WH
        lblLubWL.Text = Station.MC.myProj.Inlet_TempA.WL
        lblLub.Text = String.Format("{0:0}", Station.MC.myProj.Inlet_TempA.Value)
        If ((Station.MC.myProj.Inlet_TempA.Value <= Station.MC.myProj.Inlet_TempA.SL) And Not LimitNotActive) Or Station.MC.myProj.Inlet_TempA.Value >= Station.MC.myProj.Inlet_TempA.SH Then
            lblLub.BackColor = Color.Red
        ElseIf ((Station.MC.myProj.Inlet_TempA.Value <= Station.MC.myProj.Inlet_TempA.WL) And Not LimitNotActive) Or Station.MC.myProj.Inlet_TempA.Value >= Station.MC.myProj.Inlet_TempA.WH Then
            lblLub.BackColor = Color.Yellow
        ElseIf Station.MC.myProj.Inlet_TempA.Value < Station.MC.myProj.Inlet_TempA.WH And Station.MC.myProj.Inlet_TempA.Value > Station.MC.myProj.Inlet_TempA.WL Then
            lblLub.BackColor = Color.Green
        Else
            lblLub.BackColor = Color.WhiteSmoke
        End If
        If Station.MC.myProj.Inlet_TempA.Bypass Then lblLub.BackColor = Color.WhiteSmoke

        'Update values
        lblOTSH.Text = Station.MC.myProj.TankTemp.SH
        lblOTSL.Text = Station.MC.myProj.TankTemp.SL
        lblOTWH.Text = Station.MC.myProj.TankTemp.WH
        lblOTWL.Text = Station.MC.myProj.TankTemp.WL
        lblOT.Text = String.Format("{0:0}", Station.MC.myProj.TankTemp.Value)
        If Station.MC.myProj.TankTemp.Value <= Station.MC.myProj.TankTemp.SL Or Station.MC.myProj.TankTemp.Value >= Station.MC.myProj.TankTemp.SH Then
            lblOT.BackColor = Color.Red
        ElseIf Station.MC.myProj.TankTemp.Value <= Station.MC.myProj.TankTemp.WL Or Station.MC.myProj.TankTemp.Value >= Station.MC.myProj.TankTemp.WH Then
            lblOT.BackColor = Color.Yellow
        ElseIf Station.MC.myProj.TankTemp.Value < Station.MC.myProj.TankTemp.WH And Station.MC.myProj.TankTemp.Value > Station.MC.myProj.TankTemp.WL Then
            lblOT.BackColor = Color.Green
        Else
            lblOT.BackColor = Color.WhiteSmoke
        End If
        If Station.MC.myProj.TankTemp.Bypass Then lblOT.BackColor = Color.WhiteSmoke


        If Not Station.MC.myProj.ProjectID = 0 Then
            lblPrjIDTxt.Text = Station.MC.myProj.ProjectIDTxt & "_" & Station.MC.myProj.HeadA & "_" & Station.MC.myProj.HeadB & "_" & Station.MC.myProj.HeadC & "_" & Station.MC.myProj.HeadD
        Else
            lblPrjIDTxt.Text = ""
        End If

        lblMake.Text = Station.MC.myProj.Make
        lblPartNo.Text = Station.MC.myProj.PartNo
        lblStartTime.Text = Station.MC.myProj.CreatedDate
        lblCurTime.Text = Station.MC.myProj.TerminatedDate
        lblLife.Text = String.Format("{0:n2}", Station.MC.myProj.CurrentLife)
        lblRev.Text = String.Format("{0:n4}", Station.MC.myProj.CurrRev)
        UpdateStatus()
        txtITTSP.Text = Station.MC.myProj.Inlet_TempA.Setpoint


    End Sub


    Sub UpdateStatus()
        Select Case Station.MC.myProj.MyStatus
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
        If Station.MC.myProj.ProjectID <> 0 Then
            Dim constr As String = "SELECT Avg(BearingTemp1), Avg(BearingTemp2), Avg(BearingTemp3), Avg(BearingTemp4), Avg(LubOilTemp), Avg(TankOilTemp), Avg(Vibration), Avg(Speed), Avg(Load1)  FROM datalogs  where  ProjectID=" & Station.MC.myProj.ProjectID & " and status='RUN ' order by idDataLogs"
            If GetDataMySQL(con, da, ds, dt, False, constr) Then
                If dt.Rows.Count > 0 Then
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


    End Sub
End Class
