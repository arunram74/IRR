Imports System.ComponentModel
Imports IRR
Imports MySql.Data.MySqlClient
Public Class frmMain

    Dim WithEvents frmDispChild As Form 'All forms are diplayed using this variable

    Dim con As MySqlConnection = New MySqlConnection(serv)
    Dim dt As DataTable
    Dim ds As DataSet
    Dim adp As MySqlDataAdapter
    Dim RowNo As Integer = 0
    Dim myWrapper As CommunicationCls


    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        serv = "server = localhost; user id =root; password =Actemium#123; database =" & My.Settings("DBName")
        Station = New StnCls


        Dim constr As String
        constr = "SELECT alarmlog.AlarmNo, alarmlog.alarmid, reasondb.reasontxt, alarmlog.Logtime, Alarmlog.ProjectIDtxt, Alarmlog.HeadName, AlarmLog.MachineName from AlarmLog inner join reasondb on Alarmlog.AlarmId = reasondb.reasonid Order by AlarmNo Desc Limit 100;"
        If GetDataMySQL(con, adp, ds, dt, False, constr) Then dgvAlarmMain.DataSource = dt

        ' pnlRIG1.BringToFront()
        '        Me.BackColor = Color.FromArgb(255, 0, 127, 127)
        Init()

        No_Sleep() 'prevents PC going to sleep
        bkgrndWrkr1.RunWorkerAsync(PLCStations)



    End Sub

    Private Sub dgvAlarmMain_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgvAlarmMain.RowPrePaint
        If dgvAlarmMain.Rows(e.RowIndex).Cells("alarmid").Value > 32 Then
            dgvAlarmMain.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
        ElseIf dgvAlarmMain.Rows(e.RowIndex).Cells("alarmid").Value > 0 And dgvAlarmMain.Rows(e.RowIndex).Cells("alarmid").Value < 33 Then
            dgvAlarmMain.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
        End If
    End Sub

    '***********************************************************************************************************
    '*Handles - Until a station is selected this should be the status
    '*
    '***********************************************************************************************************
    Private Sub Init()
        toolbtnNewProj.Enabled = False
        toolBtnOpenPrj.Enabled = False
        toolBtnModifyPrj.Enabled = False
        toolBtnComplete.Enabled = False
        MonitorAfter = My.Settings("MonitorAfter")
    End Sub


    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles pnlBtm.Paint
        lblAlarmCaption.Width = pnlBtm.Width
        dgvAlarmMain.Height = pnlBtm.Height - lblAlarmCaption.Height
    End Sub


#Region "ClickEvents"

    '***********************************************************************************************************
    '*Handles - Showing of the child screens
    '*
    '***********************************************************************************************************



    Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        frmDefault.MdiParent = Me
        frmDefault.Show()
    End Sub

    Private Sub ProToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles toolbtnNewProj.Click
        Station.MC.myProj.isNew = True
        Station.MC.myProj.Init()
        toolBtnOpenPrj.Enabled = False
        toolBtnModifyPrj.Enabled = False
        frmPrjt.ShowDialog()
        ''  frmDefault.SendClick()
        ' ShowChildForm(ChildForms.project)
    End Sub


    Private Sub frmMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'bkgrndWrkr1.CancelAsync()
        'bkgrndWrkr2.CancelAsync()
        'bkgrndWrkr3.CancelAsync()
        'bkgrndWrkr4.CancelAsync()
        If MessageBox.Show("Do you want to quit the application?", "Quit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then e.Cancel = True
    End Sub


    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles toolBtnOpenPrj.Click
        If frmOpenExistingPrj.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' MsgBox(frmOpenExistingPrj.PrjName)
            If Station.MC.myProj.MyStatus = ProjectCls.ProjectStatus.Run Or Station.MC.myProj.MyStatus = ProjectCls.ProjectStatus.Load Then
                MessageBox.Show("Cannot load this project", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If



            Station.MC.myProj.LoadExisting(frmOpenExistingPrj.PrjID)
            Station.MC.myProj.isNew = False
            frmOpenExistingPrj.Close()
            frmPrjt.ShowDialog()
        End If
        frmDefault.SendClick()
    End Sub


    Private Sub toolBtnCharts_Click(sender As Object, e As EventArgs) Handles toolBtnCharts.Click
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next
        frmCharts.MdiParent = Me
        frmCharts.Show()
    End Sub

    Private Sub toolbtnDefault_Click(sender As Object, e As EventArgs) Handles toolbtnDefault.Click
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next
        frmDefault.MdiParent = Me
        frmDefault.Show()
    End Sub

    Private Sub ToolStripButton1_Click_2(sender As Object, e As EventArgs) Handles toolBtnPLC.Click
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next
        frmPLC.MdiParent = Me
        frmPLC.Show()
    End Sub

    Private Sub toolstrpMnuAlarm_Click(sender As Object, e As EventArgs) Handles toolStrpAlarm.Click
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next
        frmAlarms.MdiParent = Me
        frmAlarms.Show()
    End Sub

    Private Sub ScalingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles toolbtnScale.Click
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next
        frmScaling.MdiParent = Me
        frmScaling.Show()
    End Sub

    Private Sub toolBtnReports_Click(sender As Object, e As EventArgs) Handles toolBtnReports.Click
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next
        frmReport.MdiParent = Me
        frmReport.Show()
    End Sub

    Private Sub toolBtnModifyPrj_Click(sender As Object, e As EventArgs) Handles toolBtnModifyPrj.Click
        If Station.MC.myProj.ProjectID <> 0 Then
            frmPrjt.ShowDialog()
            frmDefault.SendClick()
        End If
    End Sub

    Private Sub toolBtnRun_Click(sender As Object, e As EventArgs)
        Station.MC.myProj.StartTest()

    End Sub


    Private Sub toolbtnCommSettings_Click(sender As Object, e As EventArgs) Handles toolbtnCommSettings.Click
        If frmSettings.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' MsgBox(frmOpenExistingPrj.PrjName)
            frmSettings.Close()
        End If
    End Sub



    Sub LogLubOilData()
        Dim SQLConnection As New MySqlConnection(serv)
        Dim sqlCommand As New MySqlCommand()


        sqlCommand.CommandText = "INSERT INTO luboil (`LubOilMC1`, `LubOilMC2`, `LubOilMC3`, `LubOilMC4`, `LogDate` ) values (@lbmc1,@lbmc2,@lbmc3,@lbmc4,@lgdate)"
        sqlCommand.CommandType = CommandType.Text
        sqlCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()

            sqlCommand.Parameters.AddWithValue("@lbmc1", Station.Comms.PLC1.GetTagVal("InTankTemp_actVal"))
            sqlCommand.Parameters.AddWithValue("@lbmc2", 0)
            sqlCommand.Parameters.AddWithValue("@lbmc3", 0)
            sqlCommand.Parameters.AddWithValue("@lbmc4", 0)
            sqlCommand.Parameters.AddWithValue("@lgdate", Now)

            sqlCommand.ExecuteNonQuery()

            sqlCommand.Parameters.Clear()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message.ToString, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLConnection.Close()
        End Try
    End Sub

    Private Sub TmrAlarm_Tick(sender As Object, e As EventArgs) Handles TmrAlarm.Tick
        Dim constr As String
        constr = "SELECT alarmlog.AlarmNo, alarmlog.alarmid, reasondb.reasontxt, alarmlog.Logtime, Alarmlog.ProjectIDtxt, Alarmlog.HeadName, AlarmLog.MachineName from AlarmLog inner join reasondb on Alarmlog.AlarmId = reasondb.reasonid Order by AlarmNo Desc Limit 100;"
        If GetDataMySQL(con, adp, ds, dt, False, constr) Then dgvAlarmMain.DataSource = dt
    End Sub

    Private Sub toolBtnComplete_Click_1(sender As Object, e As EventArgs) Handles toolBtnComplete.Click
        frmSuspFail.ShowDialog()
        frmDefault.SendClick()
    End Sub

    Private Sub toolBtnPID_Click(sender As Object, e As EventArgs) Handles toolBtnPID.Click
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next
        frmPID.MdiParent = Me
        frmPID.Show()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        frmAboutBox.ShowDialog()
    End Sub

#End Region

    Private Sub bkgrndWrkr_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bkgrndWrkr1.DoWork

        Dim MyComms As List(Of PLCStn) = e.Argument
        Dim PLCStnStr As String = My.Settings.Item("PLCStations")

        Dim strArr() As String = PLCStnStr.Split(","c)
        Dim j As Integer = 0

        While True

            Try
                For i = 1 To 3
                    If MyComms(i).CheckComms And strArr(i - 1) <> 0 Then
                        MyComms(i).Stn.ActLogicalStationNumber = CInt(strArr(i - 1))
                        MyComms(i).Stn.ActPassword = ""

                        If MyComms(i).Stn.Open() <> 0 Then
                            MyComms(i).IsStnAvailable = False
                        Else
                            MyComms(i).IsStnAvailable = True
                        End If
                        MyComms(i).CheckComms = False
                    End If

                    If MyComms(i).IsStnAvailable Then
                        Dim data() As Integer = {0, 0}
                        MyComms(i).Stn.ReadDeviceRandom("M1", 1, data(0)) 'always on Tag
                        If data(0) = 0 Then
                            MyComms(i).IsStnAvailable = False
                            MyComms(i).Stn.Close()
                        Else
                            MyComms(i).TagLock.EnterWriteLock()
                            MyComms(i).Stn.ReadDeviceBlock("D0", MyComms(i).DataWord.Count, MyComms(i).DataWord(0))
                            MyComms(i).Stn.ReadDeviceBlock("M0", MyComms(i).MWord.Count, MyComms(i).MWord(0))
                            MyComms(i).TagLock.ExitWriteLock()
                        End If
                    End If
                    System.Threading.Thread.Sleep(500)
                Next


            Catch ex As Exception
                ' MessageBox.Show(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            '' check at regular intervals for CancellationPending
            If bkgrndWrkr1.CancellationPending Then Exit While

            Application.DoEvents()
        End While

        '' set the e.Cancel to True to indicate to the RunWorkerCompleted that you cancelled out
        If bkgrndWrkr1.CancellationPending Then e.Cancel = True
        '    bkgrndWrkr.ReportProgress(100, "Cancelled.")

    End Sub

    Private Sub bkgrndWrkr1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bkgrndWrkr1.RunWorkerCompleted
        For i = 1 To 3
            PLCStations(i).Stn.Close()
        Next i
    End Sub

    Private Sub TmrLubOil_Tick(sender As Object, e As EventArgs) Handles TmrLubOil.Tick
        Dim myTimeSpan1 As TimeSpan = New TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        Dim MyTimeSpan2 As TimeSpan = New TimeSpan(23, 59, 59)
        Dim myTimeSpan3 As TimeSpan = New TimeSpan(16, 0, 0)

        Dim TsObj As TimeSpan = New TimeSpan()

        If myTimeSpan1 < myTimeSpan3 Then
            TsObj = myTimeSpan3.Subtract(myTimeSpan1)
        Else
            TsObj = myTimeSpan3.Add(MyTimeSpan2.Subtract(myTimeSpan1))
        End If
        Dim milsec As Integer = Convert.ToInt32(TsObj.TotalMilliseconds)
        TmrLubOil.Interval = milsec

        If (Now.Hour = 15 And Now.Minute > 50) Or (Now.Hour = 16 And Now.Minute < 10) Then
            LogLubOilData() 'Log at 4:00 PM. +/- 10 min
        End If
    End Sub


End Class
