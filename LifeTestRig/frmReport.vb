Imports System.Globalization
Imports System.IO
Imports MySql.Data.MySqlClient


Public Class frmReport

    Dim con As MySqlConnection = New MySqlConnection(serv)
    Dim adp As MySqlDataAdapter
    Dim ds As DataSet
    Dim dt1, dt2, dt3 As DataTable
    Dim StartDate, EndDate As String
    Dim PrjIdFilter As String
    Dim McFilter As String
    Dim PrjStatusFilter As String

    Sub UpdateFilters()

        StartDate = dtFromDate.Value.ToString("yyyy-MM-dd")
        StartDate = StartDate & " " & dtFromTime.Value.ToString("HH:mm:ss") '' & "Z"
        'StartDate.AddMinutes(dtFromTime.Value.Minute)
        'StartDate.AddSeconds(dtFromTime.Value.Second)

        EndDate = dtToDate.Value.ToString("yyyy-MM-dd")
        EndDate = EndDate & " " & dtToTime.Value.ToString("HH:mm:ss") '' & "Z"
        'EndDate = dtToDate.Value
        'EndDate.AddHours(dtToTime.Value.Hour)
        'EndDate.AddMinutes(dtToTime.Value.Minute)
        'EndDate.AddSeconds(dtToTime.Value.Second)

        If chkDate.Checked Then
            StartDate = "1900-01-01 12:00:52" 'Z"
            EndDate = "2050-01-01 12:00:52" 'Z"
        End If

        If cmbPrjt.SelectedValue = 0 Then PrjIdFilter = "ProjectID" Else PrjIdFilter = cmbPrjt.SelectedValue
        If cmbPrjStatus.SelectedValue = 0 Then PrjStatusFilter = "Status" Else PrjStatusFilter = cmbPrjStatus.SelectedValue
        If cmbMachine.Text = "ALL" Then McFilter = "MachineName" Else McFilter = "'" & cmbMachine.Text & "'"

    End Sub

    Private Sub btnDataLogs_Click(sender As Object, e As EventArgs) Handles btnDataLogs.Click

        UpdateFilters()


        If PrjIdFilter = "ProjectID" Then
            MessageBox.Show("Please select a Project", "Run Report", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim constr As String = "SELECT LogTime,Status,  BearingTemp1, BearingTemp2, BearingTemp3, BearingTemp4, LubOilTemp, TankOilTemp, Vibration, Speed, Load1, Revolutions, NoOfHours, HeadName, MachineName, Reasondb.Reasontxt as Reason FROM datalogs inner join  reasondb on datalogs.StopReason=reasondb.ReasonID where ( Logtime Between '" & StartDate & "' and '" & EndDate & "') and ProjectID=" & PrjIdFilter & " and Status=" & PrjStatusFilter & " and MachineName=" & McFilter & " order by idDataLogs"
        If GetDataMySQL(con, adp, ds, dt1, False, constr) Then
            WriteDataTable(dt1, Templatepath & "test.csv", True)
            Viewer.CsvFilePath = Templatepath & "test.csv"
            Viewer.SaveAsFileName = "Datalogs_" & cmbPrjt.Text
            Viewer.Text = "Data Logs"
            If Viewer.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ' MsgBox(frmOpenExistingPrj.PrjName)
                Viewer.Close()
            End If
        End If

    End Sub

    Private Sub frmReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbMachine.Items.Clear()
        cmbMachine.Items.Add("ALL")
        cmbMachine.Items.Add(My.Settings("MC1Size"))
        cmbMachine.Items.Add(My.Settings("MC2Size"))
        cmbMachine.Items.Add(My.Settings("MC3Size"))
        cmbMachine.Items.Add(My.Settings("MC4Size"))

        UpdateTemplateList()
    End Sub

    Private Sub btnUtility_Click(sender As Object, e As EventArgs) Handles btnUtility.Click

        UpdateFilters()

        If McFilter = "MachineName" Then
            MessageBox.Show("Please select a Machine", "Utility", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim StartTime, EndTime As DateTime
        Dim RunTime, StopTime, TotalTime As TimeSpan
        Dim PrevOperation As String = "STRT"
        Dim provider As CultureInfo = CultureInfo.InvariantCulture
        Dim constr As String = "SELECT  DateandTime, Machine, Head, Concat(ProjectIDTxt,'_',B1Name,'_',B2Name,'_',B3Name,'_',B4Name) as Project, Operation, reasondb.reasontxt as Reason From utility inner join  reasondb on utility.ReasonID=reasondb.reasonID  where ( DateandTime Between '" & StartDate & "' and '" & EndDate & "') and Machine=" & McFilter & " Order by DateandTime"
        If GetDataMySQL(con, adp, ds, dt1, False, constr) Then
            If dt1.Rows.Count > 0 Then
                If dt1.Rows(0).Item("Operation") <> "STRT" Then StartTime = DateTime.ParseExact(StartDate, "yyyy-MM-dd HH:mm:ss", provider) 'if the mahine was already running at the start date specified
                Dim PrevStartTime As Date = #1/1/0001 12:00:00 AM#
                For i = 0 To dt1.Rows.Count - 1
                    If dt1.Rows(i).Item("Operation") = "STRT" Then StartTime = dt1.Rows(i).Item("DateandTime")
                    If dt1.Rows(i).Item("Operation") <> "STRT" And PrevOperation = "STRT" Then 'to skip A and B Station starting together
                        If StartTime > #1/1/0001 12:00:00 AM# Then
                            EndTime = dt1.Rows(i).Item("DateandTime")
                            If StartTime <> PrevStartTime Then
                                RunTime += (EndTime - StartTime)
                                PrevStartTime = StartTime
                            End If
                        End If
                    End If
                    PrevOperation = dt1.Rows(i).Item("Operation")
                Next

                If dt1.Rows(dt1.Rows.Count - 1).Item("Operation") = "STRT" Then 'LAst record is start but there is no suspend
                    EndTime = DateTime.Parse(EndDate)
                    If StartTime <> PrevStartTime Then
                        RunTime += (EndTime - StartTime)
                    End If
                End If

                StartTime = DateTime.Parse(StartDate) ' dt1.Rows(0).Item("DateandTime")
                EndTime = DateTime.Parse(EndDate) 'dt1.Rows(dt1.Rows.Count - 1).Item("DateandTime")
                TotalTime = EndTime - StartTime
                StopTime = TotalTime - RunTime
                WriteDataTable(dt1, Templatepath & "test.csv", True)
                Viewer.CsvFilePath = Templatepath & "test.csv"
                File.AppendAllText(Templatepath & "test.csv", " , " & vbCrLf & " , " & vbCrLf)
                File.AppendAllText(Templatepath & "test.csv", "Time,Hours,Minutes,Seconds " & vbCrLf)
                File.AppendAllText(Templatepath & "test.csv", "Total Run Time ," & RunTime.Hours + RunTime.Days * 24 & "," & RunTime.Minutes & "," & RunTime.Seconds & " " & vbCrLf)
                File.AppendAllText(Templatepath & "test.csv", "Total Stop Time ," & StopTime.Hours + StopTime.Days * 24 & "," & StopTime.Minutes & "," & StopTime.Seconds & " " & vbCrLf)
                File.AppendAllText(Templatepath & "test.csv", "Total Time ," & TotalTime.Hours + TotalTime.Days * 24 & "," & TotalTime.Minutes & "," & TotalTime.Seconds & " " & vbCrLf)
                Viewer.SaveAsFileName = "Utilities_" & cmbMachine.Text
                Viewer.Text = "Machine Utilities"
                If Viewer.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    ' MsgBox(frmOpenExistingPrj.PrjName)
                    Viewer.Close()
                End If
            Else
                MessageBox.Show("No Records Found", "Utility", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub btnRunReport_Click(sender As Object, e As EventArgs) Handles btnRunReport.Click

        UpdateFilters()

        If PrjIdFilter = "ProjectID" Then
            MessageBox.Show("Please select a Project", "Run Report", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim Filepath As String = Templatepath & "test.csv"
        File.Delete(Filepath)

        File.AppendAllText(Filepath, " ,  ,  ,  ,  ,  ,  ,  ,  ,   " & vbCrLf)

        Dim constr As String = "Select * from Project where ProjectID=" & PrjIdFilter
        If GetDataMySQL(con, adp, ds, dt1, False, constr) Then
            If dt1.Rows.Count > 0 Then
                File.AppendAllText(Filepath, "ProjectID-," & dt1.Rows(0).Item("ProjectIDTxt") & "_" & dt1.Rows(0).Item("B1Name") & "_" & dt1.Rows(0).Item("B2Name") & "_" & dt1.Rows(0).Item("B3Name") & "_" & dt1.Rows(0).Item("B4Name") & vbCrLf)
                File.AppendAllText(Filepath, "Owner-," & dt1.Rows(0).Item("Owner") & vbCrLf)
                File.AppendAllText(Filepath, "Bearing Count-," & dt1.Rows(0).Item("BearingCount") & vbCrLf)
                File.AppendAllText(Filepath, "Project Name-," & dt1.Rows(0).Item("ProjectName") & vbCrLf)
                File.AppendAllText(Filepath, "Cup-," & dt1.Rows(0).Item("CupNo") & vbCrLf)
                File.AppendAllText(Filepath, "Cone-," & dt1.Rows(0).Item("ConeNo") & vbCrLf)
                File.AppendAllText(Filepath, "Test Type-," & dt1.Rows(0).Item("TestType") & vbCrLf)
                File.AppendAllText(Filepath, "Bearing Type-," & dt1.Rows(0).Item("BearingType") & vbCrLf)
                File.AppendAllText(Filepath, "Machine Size-," & dt1.Rows(0).Item("MachineSize") & vbCrLf)
                File.AppendAllText(Filepath, "PV No-," & dt1.Rows(0).Item("PVNo") & vbCrLf)
                File.AppendAllText(Filepath, "," & vbCrLf)
                File.AppendAllText(Filepath, "," & vbCrLf)
            End If
        End If


        File.AppendAllText(Filepath, "Parameters, BearingTemp1, BearingTemp2, BearingTemp3, BearingTemp4, LubOilTemp, TankOilTemp, Vibration, Speed, Load1 " & vbCrLf)

        'Max Value for Load
        constr = "SELECT  Max(BearingTemp1) , Max(BearingTemp2) , Max(BearingTemp3) , Max(BearingTemp4) , Max(LubOilTemp) , Max(TankOilTemp), Max(Vibration) , Max(Speed), Max(Load1) FROM datalogs where Status='LOAD'and ProjectID=" & PrjIdFilter
        WritetoFile(Filepath, "Max Values(Loading)", constr)

        'Average Value for Load
        constr = "SELECT  Avg(BearingTemp1) , Avg(BearingTemp2) , Avg(BearingTemp3) , Avg(BearingTemp4) , Avg(LubOilTemp) , Avg(TankOilTemp), Avg(Vibration) , Avg(Speed), Avg(Load1) FROM datalogs where Status='LOAD' and ProjectID=" & PrjIdFilter
        WritetoFile(Filepath, "Average Values", constr)
        File.AppendAllText(Filepath, "," & vbCrLf)

        'Max Value for Run
        constr = "SELECT  Max(BearingTemp1) , Max(BearingTemp2) , Max(BearingTemp3) , Max(BearingTemp4) , Max(LubOilTemp) , Max(TankOilTemp), Max(Vibration) , Max(Speed), Max(Load1) FROM datalogs where Status='RUN ' and ProjectID=" & PrjIdFilter
        WritetoFile(Filepath, "Max Values(Running)", constr)

        'Average Value for Run
        constr = "SELECT  Avg(BearingTemp1) , Avg(BearingTemp2) , Avg(BearingTemp3) , Avg(BearingTemp4) , Avg(LubOilTemp) , Avg(TankOilTemp), Avg(Vibration) , Avg(Speed), Avg(Load1) FROM datalogs where Status='RUN ' and ProjectID=" & PrjIdFilter
        WritetoFile(Filepath, "Average Values", constr)
        File.AppendAllText(Filepath, "," & vbCrLf)

        'Max Value for Total
        constr = "SELECT  Max(BearingTemp1) , Max(BearingTemp2) , Max(BearingTemp3) , Max(BearingTemp4) , Max(LubOilTemp) , Max(TankOilTemp), Max(Vibration) , Max(Speed), Max(Load1) FROM datalogs Where (Status='RUN ' or Status='LOAD') and ProjectID=" & PrjIdFilter
        WritetoFile(Filepath, "Max Values(Total)", constr)

        'Average Value for Total
        constr = "SELECT  Avg(BearingTemp1) , Avg(BearingTemp2) , Avg(BearingTemp3) , Avg(BearingTemp4) , Avg(LubOilTemp) , Avg(TankOilTemp), Avg(Vibration) , Avg(Speed), Avg(Load1) FROM datalogs Where (Status='RUN ' or Status='LOAD') and ProjectID=" & PrjIdFilter
        WritetoFile(Filepath, "Average Values", constr)

        Viewer.SaveAsFileName = "RunReport_" & cmbPrjt.Text
        Viewer.CsvFilePath = Templatepath & "test.csv"
        Viewer.Text = "Run Report"
        If Viewer.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' MsgBox(frmOpenExistingPrj.PrjName)
            Viewer.Close()
        End If

    End Sub

    Private Sub cmbMachine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMachine.SelectedIndexChanged

    End Sub

    Private Sub btnLubOilTemp_Click(sender As Object, e As EventArgs) Handles btnLubOilTemp.Click
        UpdateFilters()
        Dim constr As String = "SELECT LogDate, LubOilMC1, LubOilMC2, LubOilMC3, LubOilMC4 from luboil where  LogDate Between '" & StartDate & "' and '" & EndDate & "'"
        If GetDataMySQL(con, adp, ds, dt1, False, constr) Then
            WriteDataTable(dt1, Templatepath & "test.csv", True)
            Viewer.CsvFilePath = Templatepath & "test.csv"
            Viewer.SaveAsFileName = "LubOilReport"
            Viewer.Text = "Lube Oil Temperature"
            If Viewer.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ' MsgBox(frmOpenExistingPrj.PrjName)
                Viewer.Close()
            End If
        End If
    End Sub

    Sub WritetoFile(FileName As String, Title As String, ConnectionStr As String)
        If GetDataMySQL(con, adp, ds, dt1, False, ConnectionStr) Then
            File.AppendAllText(FileName, Title)
            If dt1.Rows.Count > 0 Then
                For i = 0 To dt1.Columns.Count - 1
                    File.AppendAllText(FileName, "," & dt1.Rows(0).Item(i))
                Next
                File.AppendAllText(FileName, vbCrLf)
            End If
        End If
    End Sub

    Private Sub btStopReason_Click(sender As Object, e As EventArgs) Handles btStopReason.Click

        UpdateFilters()

        If PrjIdFilter = "ProjectID" Then
            MessageBox.Show("Please select a Project", "Stop Reason", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim strarr() = cmbPrjt.Text.Split("_"c)

        Dim constr As String = "SELECT DateandTime, reasondb.reasontxt as Status, Machine, Head, ProjectIDTxt, Operation From utility inner join  reasondb on utility.reasonID=reasondb.reasonid  where ProjectIDtxt='" & strarr(0) & "' and Operation<> 'STRT' Order by DateandTime"
        If GetDataMySQL(con, adp, ds, dt1, False, constr) Then
            WriteDataTable(dt1, Templatepath & "test.csv", True)
            Viewer.CsvFilePath = Templatepath & "test.csv"

            Viewer.SaveAsFileName = "StopReason_" & cmbPrjt.Text
            Viewer.Text = "Stop Reason"

            If Viewer.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ' MsgBox(frmOpenExistingPrj.PrjName)
                Viewer.Close()
            End If
        End If
    End Sub

    Sub UpdateTemplateList()


        Dim constr As String = "SELECT Concat(ProjectIDTxt,'_',B1Name,'_',B2Name,'_',B3Name,'_',B4Name) as ProjectIDTxt, ProjectID from Project  Order by ProjectID"
        If GetDataMySQL(con, adp, ds, dt2, False, constr) Then
            Dim dr As DataRow = dt2.NewRow
            dr("ProjectIDTxt") = "ALL"
            dr("ProjectID") = 0
            dt2.Rows.InsertAt(dr, 0)
            cmbPrjt.DataSource = dt2
            cmbPrjt.DisplayMember = "ProjectIDTxt"
            cmbPrjt.ValueMember = "ProjectID"
            cmbPrjt.MaxDropDownItems = 20
            cmbPrjt.Refresh()

        End If


        dt3 = New DataTable
        dt3.Columns.Add("Text", GetType(String))
        dt3.Columns.Add("Value", GetType(Integer))
        dt3.Rows.Add("ALL", 0)
        dt3.Rows.Add("LOAD", ProjectCls.ProjectStatus.Load)
        dt3.Rows.Add("RUN", ProjectCls.ProjectStatus.Run)
        dt3.Rows.Add("SUSPENDED", ProjectCls.ProjectStatus.Suspended)


        cmbPrjStatus.DataSource = dt3
        cmbPrjStatus.DisplayMember = "Text"
        cmbPrjStatus.ValueMember = "Value"

        cmbPrjStatus.Refresh()

        cmbMachine.SelectedIndex = 0
    End Sub

End Class
