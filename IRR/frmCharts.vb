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
        rdbHA.Checked = True


        HandleChecks()

        CreateGraphs(chrtVib, bsvb, Station.MC.myProj.dtVibration, 3)
        CreateGraphs(chrtSpd, bsspd, Station.MC.myProj.dtSpeed, 3)
        CreateGraphs(chrtLd, bsLd, Station.MC.myProj.dtLoadDisp, 3)
        CreateGraphs(chrtBT, bsbtmp, Station.MC.myProj.dtBearing, 4)
        CreateGraphs(chrtOT, bsotmp, Station.MC.myProj.dtOilTemp, 4)
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

    Sub CreateGraphs(grph As Chart, bs As BindingSource, grphdt As DataTable, ColumnCount As Integer)
        Try
            Dim ColorSet() = {Color.Red, Color.Blue, Color.Green, Color.Brown, Color.Gray, Color.Purple}
            'bs.DataSource = grphdt
            'grph.DataSource = grphdt
            'grph.DataBind()
            For i = 0 To ColumnCount - 1
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

            dtGrphSpeed = Station.MC.myProj.dtSpeed.Copy
            chrtSpd.DataSource = dtGrphSpeed

            dtGrphLoadDisp = Station.MC.myProj.dtLoadDisp.Copy
            chrtLd.DataSource = dtGrphLoadDisp

            dtGrphBearing = Station.MC.myProj.dtBearing.Copy
            dtGrphOilTemp = Station.MC.myProj.dtOilTemp.Copy
            dtGrphVib = Station.MC.myProj.dtVibration.Copy

            dtGrphBearing = Station.MC.myProj.dtBearing.Copy
            dtGrphOilTemp = Station.MC.myProj.dtOilTemp.Copy
            dtGrphVib = Station.MC.myProj.dtVibration.Copy


            If rdbHA.Checked Then

                chrtBT.DataSource = dtGrphBearing.DefaultView.ToTable(True, "MinVal", "MaxVal", "BA", "SBA")
                chrtOT.DataSource = dtGrphOilTemp.DefaultView.ToTable(True, "MinVal", "MaxVal", "InletOilA", "TankOil")
                chrtVib.DataSource = dtGrphVib.DefaultView.ToTable(True, "MinVal", "MaxVal", "VibrationA")
            ElseIf rdbHB.Checked Then
                chrtBT.DataSource = dtGrphBearing.DefaultView.ToTable(True, "MinVal", "MaxVal", "BB", "SBB")
                chrtOT.DataSource = dtGrphOilTemp.DefaultView.ToTable(True, "MinVal", "MaxVal", "InletOilB", "TankOil")
                chrtVib.DataSource = dtGrphVib.DefaultView.ToTable(True, "MinVal", "MaxVal", "VibrationB")
            ElseIf rdbHC.Checked Then
                chrtBT.DataSource = dtGrphBearing.DefaultView.ToTable(True, "MinVal", "MaxVal", "BC", "SBC")
                chrtOT.DataSource = dtGrphOilTemp.DefaultView.ToTable(True, "MinVal", "MaxVal", "InletOilC", "TankOil")
                chrtVib.DataSource = dtGrphVib.DefaultView.ToTable(True, "MinVal", "MaxVal", "VibrationC")
            ElseIf rdbHD.Checked Then
                chrtBT.DataSource = dtGrphBearing.DefaultView.ToTable(True, "MinVal", "MaxVal", "BD", "SBD")
                chrtOT.DataSource = dtGrphOilTemp.DefaultView.ToTable(True, "MinVal", "MaxVal", "InletOilD", "TankOil")
                chrtVib.DataSource = dtGrphVib.DefaultView.ToTable(True, "MinVal", "MaxVal", "VibrationD")
            End If

            For i = 0 To 3
                chrtBT.Series(i).Name = chrtBT.DataSource.Columns(i).ColumnName
                chrtOT.Series(i).Name = chrtOT.DataSource.Columns(i).ColumnName
                If i < 3 Then chrtVib.Series(i).Name = chrtVib.DataSource.Columns(i).ColumnName
            Next i


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
