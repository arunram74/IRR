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

        CreateGraphs(chrtVib, 3)
        CreateGraphs(chrtSpd, 3)
        CreateGraphs(chrtLd, 3)
        CreateGraphs(chrtBT, 4)
        CreateGraphs(chrtOT, 4)

        rdbHA.Checked = True

        HandleChecks()

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

    Sub CreateGraphs(grph As Chart, ColumnCount As Integer)
        Try
            Dim ColorSet() = {Color.Red, Color.Blue, Color.Green, Color.Brown, Color.Gray, Color.Purple}
            'bs.DataSource = grphdt
            'grph.DataSource = grphdt
            'grph.DataBind()
            For i = 0 To ColumnCount - 1
                If grph.Series.Count < (i + 1) Then grph.Series.Add(i.ToString)
                grph.Series(i).ChartType = SeriesChartType.Line
                grph.Series(i).Color = ColorSet(i)
                grph.Series(i).Name = i 'grphdt.Columns(i).ColumnName
                grph.Series(i).YValueMembers = i 'grphdt.Columns(i).ColumnName
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
            Dim constrbt, constrot, constrvib As String

            Dim constr As String = "SELECT * from chrt_speed"
            GetDataMySQL(con, daGrph, ds, dtGrphSpeed, False, constr)

            constr = "SELECT * from chrt_load"
            GetDataMySQL(con, daGrph, ds, dtGrphLoadDisp, False, constr)

            If rdbHA.Checked Then
                constrbt = "SELECT MinVal, MaxVal, BA, SBA from chrt_bearings"
                constrot = "SELECT MinVal, MaxVal, InletOilA, TankOil from chrt_oiltemp"
                constrvib = "SELECT MinVal, MaxVal, VibrationA from chrt_vib"
            ElseIf rdbHB.Checked Then
                constrbt = "SELECT MinVal, MaxVal, BB, SBB from chrt_bearings"
                constrot = "SELECT MinVal, MaxVal, InletOilB, TankOil from chrt_oiltemp"
                constrvib = "SELECT MinVal, MaxVal, VibrationB from chrt_vib"
            ElseIf rdbHC.Checked Then
                constrbt = "SELECT MinVal, MaxVal, BC, SBC from chrt_bearings"
                constrot = "SELECT MinVal, MaxVal, InletOilC, TankOil from chrt_oiltemp"
                constrvib = "SELECT MinVal, MaxVal, VibrationC from chrt_vib"
            ElseIf rdbHD.Checked Then
                constrbt = "SELECT MinVal, MaxVal, BD, SBD from chrt_bearings"
                constrot = "SELECT MinVal, MaxVal, InletOilD, TankOil from chrt_oiltemp"
                constrvib = "SELECT MinVal, MaxVal, VibrationD from chrt_vib"
            End If

            GetDataMySQL(con, daGrph, ds, dtGrphBearing, False, constrbt)
            GetDataMySQL(con, daGrph, ds, dtGrphOilTemp, False, constrot)
            GetDataMySQL(con, daGrph, ds, dtGrphVib, False, constrvib)



            For i = 0 To dtGrphBearing.Columns.Count - 1
                chrtBT.Series(i).Name = dtGrphBearing.Columns(i).ColumnName
            Next i

            For i = 0 To dtGrphOilTemp.Columns.Count - 1
                chrtOT.Series(i).Name = dtGrphOilTemp.Columns(i).ColumnName
            Next i

            For i = 0 To dtGrphVib.Columns.Count - 1
                chrtVib.Series(i).Name = dtGrphVib.Columns(i).ColumnName
            Next i



            'Station.MC.myProj.DataUpdateLock.EnterReadLock()
            chrtVib.DataBind()
            chrtSpd.DataBind()
            chrtLd.DataBind()
            chrtBT.DataBind()
            chrtOT.DataBind()
            'Station.MC.myProj.DataUpdateLock.ExitReadLock()




        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '' ignore for now! Do nothing
        End Try
    End Sub

    Private Sub rdbMC1B_CheckedChanged(sender As Object, e As EventArgs)

        HandleChecks()
    End Sub

    Sub HandleChecks()



        chrtVib.DataSource = dtGrphVib
        chrtSpd.DataSource = dtGrphSpeed
        chrtLd.DataSource = dtGrphLoadDisp
        chrtBT.DataSource = dtGrphBearing
        chrtOT.DataSource = dtGrphOilTemp

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

    Private Sub rdb_CheckedChanged(sender As Object, e As EventArgs)
        HandleChecks()
    End Sub

    Sub UpdateGraphValues()
        'Update values

        If rdbHA.Checked Then
            UpdateRows(Station.MC.myProj.VibrationA, lblVib, lblVibSH, lblVibSL, lblVibWH, lblVibWL)
            UpdateRows(Station.MC.myProj.BA, lblBT, lblBSH, lblBSL, lblBWH, lblBWL)
            UpdateRows(Station.MC.myProj.SBA, lblSBT, lblSBSH, lblSBSL, lblSBWH, lblSBWL)
            UpdateRows(Station.MC.myProj.Inlet_TempA, lblLub, lblLubSH, lblLubSL, lblLubWH, lblLubWL)
        ElseIf rdbHB.Checked Then
            UpdateRows(Station.MC.myProj.VibrationB, lblVib, lblVibSH, lblVibSL, lblVibWH, lblVibWL)
            UpdateRows(Station.MC.myProj.BB, lblBT, lblBSH, lblBSL, lblBWH, lblBWL)
            UpdateRows(Station.MC.myProj.SBB, lblSBT, lblSBSH, lblSBSL, lblSBWH, lblSBWL)
            UpdateRows(Station.MC.myProj.Inlet_TempB, lblLub, lblLubSH, lblLubSL, lblLubWH, lblLubWL)
        ElseIf rdbHC.Checked Then
            UpdateRows(Station.MC.myProj.VibrationC, lblVib, lblVibSH, lblVibSL, lblVibWH, lblVibWL)
            UpdateRows(Station.MC.myProj.BC, lblBT, lblBSH, lblBSL, lblBWH, lblBWL)
            UpdateRows(Station.MC.myProj.SBC, lblSBT, lblSBSH, lblSBSL, lblSBWH, lblSBWL)
            UpdateRows(Station.MC.myProj.Inlet_TempC, lblLub, lblLubSH, lblLubSL, lblLubWH, lblLubWL)
        ElseIf rdbHD.Checked Then
            UpdateRows(Station.MC.myProj.VibrationD, lblVib, lblVibSH, lblVibSL, lblVibWH, lblVibWL)
            UpdateRows(Station.MC.myProj.BD, lblBT, lblBSH, lblBSL, lblBWH, lblBWL)
            UpdateRows(Station.MC.myProj.SBD, lblSBT, lblSBSH, lblSBSL, lblSBWH, lblSBWL)
            UpdateRows(Station.MC.myProj.Inlet_TempD, lblLub, lblLubSH, lblLubSL, lblLubWH, lblLubWL)
        End If


        UpdateRows(Station.MC.myProj.Speed, lblSpd, lblSpdSH, lblSpdSL, lblSpdWH, lblSpdWL)
        UpdateRows(Station.MC.myProj.Load, lblLd, lblLdSH, lblLdSL, lblLdWH, lblLdWL)






        'Update values
        'Dim LimitNotActive As Boolean = Station.MC.PLC.GetTagVal("TmpLimNtAct")
        'lblLubSH.Text = Station.MC.myProj.Inlet_TempA.SH
        'lblLubSL.Text = Station.MC.myProj.Inlet_TempA.SL
        'lblLubWH.Text = Station.MC.myProj.Inlet_TempA.WH
        'lblLubWL.Text = Station.MC.myProj.Inlet_TempA.WL
        'lblLub.Text = String.Format("{0:0}", Station.MC.myProj.Inlet_TempA.Value)
        'If ((Station.MC.myProj.Inlet_TempA.Value <= Station.MC.myProj.Inlet_TempA.SL) And Not LimitNotActive) Or Station.MC.myProj.Inlet_TempA.Value >= Station.MC.myProj.Inlet_TempA.SH Then
        '    lblLub.BackColor = Color.Red
        'ElseIf ((Station.MC.myProj.Inlet_TempA.Value <= Station.MC.myProj.Inlet_TempA.WL) And Not LimitNotActive) Or Station.MC.myProj.Inlet_TempA.Value >= Station.MC.myProj.Inlet_TempA.WH Then
        '    lblLub.BackColor = Color.Yellow
        'ElseIf Station.MC.myProj.Inlet_TempA.Value < Station.MC.myProj.Inlet_TempA.WH And Station.MC.myProj.Inlet_TempA.Value > Station.MC.myProj.Inlet_TempA.WL Then
        '    lblLub.BackColor = Color.Green
        'Else
        '    lblLub.BackColor = Color.WhiteSmoke
        'End If
        'If Station.MC.myProj.Inlet_TempA.Bypass Then lblLub.BackColor = Color.WhiteSmoke


        UpdateRows(Station.MC.myProj.TankTemp, lblOT, lblOTSH, lblOTSL, lblOTWH, lblOTWL)



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

    Private Sub UpdateRows(val As SingleLimits, lblVal As Label, lblSH As Label, lblSL As Label, lblWH As Label, lblWL As Label)
        'Update values
        lblSH.Text = val.SH
        lblSL.Text = val.SL
        lblWH.Text = val.WH
        lblWL.Text = val.WL

        lblVal.Text = String.Format("{0:n2}", val.Value)
        If val.Value <= val.SL Or val.Value >= val.SH Then
            lblVal.BackColor = Color.Red
        ElseIf val.Value <= val.WL Or val.Value >= val.WH Then
            lblVal.BackColor = Color.Yellow
        ElseIf val.Value < val.WH And val.Value > val.WL Then
            lblVal.BackColor = Color.Green
        Else
            lblVal.BackColor = Color.WhiteSmoke
        End If
        If val.Bypass Then lblVal.BackColor = Color.WhiteSmoke
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
            Dim constr As String = "SELECT Avg(Load1), Avg(Speed),  Avg(TankOilTemp)  FROM datalogs  where  ProjectID=" & Station.MC.myProj.ProjectID & " and status='RUN ' order by idDataLogs"
            If GetDataMySQL(con, da, ds, dt, False, constr) Then
                If dt.Rows.Count > 0 Then
                    lblLoadAvg.Text = String.Format("{0:n2}", If(IsDBNull(dt.Rows(0).Item("Avg(Load1)")), 0, dt.Rows(0).Item("Avg(Load1)")))
                    lblSpeedAvg.Text = String.Format("{0:n2}", If(IsDBNull(dt.Rows(0).Item("Avg(Speed)")), 0, dt.Rows(0).Item("Avg(Speed)")))
                    ' lblInTankAvg.Text = String.Format("{0:n2}", If(IsDBNull(dt.Rows(0).Item("Avg(LubOilTemp)")), 0, dt.Rows(0).Item("Avg(LubOilTemp)")))
                    lblOutOilAvg.Text = String.Format("{0:n2}", If(IsDBNull(dt.Rows(0).Item("Avg(TankOilTemp)")), 0, dt.Rows(0).Item("Avg(TankOilTemp)")))
                End If
            End If
        End If
    End Sub


End Class
