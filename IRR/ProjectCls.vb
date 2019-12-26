Imports MySql.Data.MySqlClient
Imports System.Threading
Imports System.Timers
Public Class ProjectCls

    Dim con As MySqlConnection = New MySqlConnection(serv)
    Dim da, daPrj, daParam, daLoad, daGrph, daGrph1 As MySqlDataAdapter

    Dim ds As DataSet

    Public dsGraphs As DataSet
    Public dtVibration, dtSpeed, dtLoadDisp, dtBearing, dtSupBearing, dtOilTemp, dtTankOilTemp As DataTable

    Public DataUpdateLock As ReaderWriterLockSlim = New ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion)

    Public IsPairBonded As Boolean = False



    Dim dt1, dt2, dt3, dtData, dtLoad, dtchkLoad, dtreason As DataTable
    Dim cb As MySqlCommandBuilder
    Dim StartLoad, EndLoad As Single
    Dim IncrementLoadPerSec As Double = 0
    Dim StartRuntime As Date
    'Dim WithEvents Tmr As New System.Windows.Forms.Timer
    'Dim WithEvents LoadTmr As New System.Windows.Forms.Timer
    'Dim WithEvents RunTmr As New System.Windows.Forms.Timer
    'Dim WithEvents DispUpTmr As New System.Windows.Forms.Timer
    'Dim WithEvents LoadStopTimer As New System.Windows.Forms.Timer
    'Dim WithEvents StopTestTmr As New System.Windows.Forms.Timer

    Dim WithEvents Tmr As New System.Timers.Timer
    Dim WithEvents LoadTmr As New System.Timers.Timer
    Dim WithEvents RunTmr As New System.Timers.Timer
    Dim WithEvents DispUpTmr As New System.Timers.Timer
    Dim WithEvents LoadStopTimer As New System.Timers.Timer
    Dim WithEvents StopTestTmr As New System.Timers.Timer


    Public Event StatusChanged()

    Dim MyPLC As PLCCls

    Public Enum ProjectStatus
        Indeterminate
        Idle
        Run
        Load
        Stopped 'for machine utility
        Started 'for machine utility
        Suspended
        Failure
        Disabled
    End Enum

    Dim mLocked As Boolean = True
    Dim PleaseStop As Boolean = False

    Public ProjectID As String
    Public ProjectIDTxt As String
    Public ProjectOwner As String
    Public TestID As String
    Public Make As String
    Public Lubrication As String
    Public PartNo As String
    Public HeadA As Integer
    Public HeadB As Integer
    Public HeadC As Integer
    Public HeadD As Integer

    Public HeadA_Enable As Boolean
    Public HeadB_Enable As Boolean
    Public HeadC_Enable As Boolean
    Public HeadD_Enable As Boolean

    Friend TankTemp As SingleLimits


    Friend Load As SingleLimits
    Friend Speed As SingleLimits
    Public MaxRev As Double
    Public MaxRevActive As Boolean



    Public RunLogRate As TimeSpan
    Public LoadLogRate As TimeSpan
    Public DispUpdateRate As TimeSpan

    Friend Bearings(40) As BearingData
    Friend BA, SBA, Inlet_TempA, VibrationA As SingleLimits
    Friend BB, SBB, Inlet_TempB, VibrationB As SingleLimits
    Friend BC, SBC, Inlet_TempC, VibrationC As SingleLimits
    Friend BD, SBD, Inlet_TempD, VibrationD As SingleLimits

    Public isPrjDataAvailable As Boolean = False
    Public isParamDataAvailable As Boolean = False
    Public isBearingDataAvailable As Boolean = False   'complete filling 1st page, then goto next

    Public LoadDuration As TimeSpan 'Update these values
    Public RunDuration As TimeSpan
    Public CurrStepNo As Integer
    Public CurrentLoad As Single
    Public CurrRev As Double

    Public CreatedDate As Date
    Public TerminatedDate As Date

    Public Event ProjectChanged(ProjectName As String)

    Dim Life As Double = 0
    Public CurrentLife As Double = 0
    Dim LifeStrart As Date
    Dim PrevLife As Double = 0

    Dim Rev As Double


    Dim LoadSecRem, RunSecRem As Double

    Public MyStatus As ProjectStatus
    Dim MyPrevStatus As ProjectStatus = ProjectStatus.Idle

    Dim CurrMonActive As Boolean = False
    Dim PrevMonActive As Boolean = False

    Dim LoadAuto As Boolean = False
    Dim PrevLoadAuto As Boolean = False

    Public StopReason As String = ""
    Dim AlarmNo As Integer = 0
    Dim OtherHeadAlarmVal As Single = 0

    Public isNew As Boolean = False 'Whether this is a new project or not

    'For Alarm logging
    Dim oldArrSL1(16) As Boolean
    Dim newArrSL1(16) As Boolean

    Dim oldArrSH1(16) As Boolean
    Dim newArrSH1(16) As Boolean

    Dim oldArrWL1(16) As Boolean
    Dim newArrWL1(16) As Boolean

    Dim oldArrWH1(16) As Boolean
    Dim newArrWH1(16) As Boolean

    Dim oldArrSL2(16) As Boolean
    Dim newArrSL2(16) As Boolean

    Dim oldArrSH2(16) As Boolean
    Dim newArrSH2(16) As Boolean

    Dim oldArrWL2(16) As Boolean
    Dim newArrWL2(16) As Boolean

    Dim oldArrWH2(16) As Boolean
    Dim newArrWH2(16) As Boolean

    Dim oldArrMisc(16) As Boolean
    Dim newArrMisc(16) As Boolean

    Dim ErrSL, ErrSH, ErrMisc As UInt16

    Public Sub New(PLC As PLCCls)

        MyPLC = PLC
        Init()
    End Sub

    Public Sub Init()
        'Clear all values

        IsPairBonded = False

        ProjectID = 0
        ProjectIDTxt = ""
        ProjectOwner = ""
        TestID = ""
        Make = ""
        Lubrication = ""
        PartNo = ""
        HeadA = 0
        HeadB = 0
        HeadC = 0
        HeadD = 0
        HeadA_Enable = False
        HeadB_Enable = False
        HeadC_Enable = False
        HeadD_Enable = False



        VibrationA.Init("VibA")
        VibrationB.Init("VibB")
        VibrationC.Init("VibC")
        VibrationD.Init("VibD")


        TankTemp.Init("OutTankTemp")


        Load.Init("Load")

        Speed.Init("Speed")

        MaxRev = 0
        MaxRevActive = False


        RunLogRate = TimeSpan.Parse("00:00:00")
        LoadLogRate = TimeSpan.Parse("00:00:00")
        DispUpdateRate = TimeSpan.Parse("00:00:00")

        CreatedDate = #1/1/0001 12:00:00 AM#
        TerminatedDate = #1/1/0001 12:00:00 AM#

        BA.Init("BTempA")
        BB.Init("BTempB")
        BC.Init("BTempC")
        BD.Init("BTempD")

        SBA.Init("SBTempA")
        SBB.Init("SBTempB")
        SBC.Init("SBTempC")
        SBD.Init("SBTempD")

        Inlet_TempA.Init("Inlet_TempA")
        Inlet_TempA.Init("Inlet_TempB")
        Inlet_TempA.Init("Inlet_TempC")
        Inlet_TempA.Init("Inlet_TempD")


        LoadTmr.AutoReset = True
        RunTmr.AutoReset = True
        Tmr.AutoReset = True

        Life = 0
        Rev = 0

        'Empty Temporary Load Table
        Dim SQLConnection As New MySqlConnection(serv)
        Dim sqlCommand As New MySqlCommand()

        sqlCommand.CommandText = "Delete from LoadStepsTemp"
        sqlCommand.CommandType = CommandType.Text
        sqlCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()
            sqlCommand.ExecuteNonQuery()
            sqlCommand.Parameters.Clear()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message.ToString, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLConnection.Close()
        End Try

        MyStatus = ProjectStatus.Idle


        CreateGraphDataTables()

        'Init PLC Vars
        MyPLC.SetTagVal("MonitorLimits", 0)
        MyPLC.SetTagVal("MonitorLoad", 0)
        MyPLC.SetTagVal("Load", 0)

        CurrentLoad = 0

        RaiseEvent ProjectChanged(0)
    End Sub

    Public Function StartTest() As Boolean

        If Not MyPLC.GetTagVal("StationReady") Then
            Return False
            Exit Function
        End If
        MyStatus = ProjectStatus.Started
        ''     If MyStatus = ProjectStatus.Started Then
        If Not StartTestProcedure() Then
            Return False
            Exit Function  'Start the test
        End If

        ''   End If
        Tmr.AutoReset = True
        Tmr.Interval = 1000 '250 ms timer
        Tmr.Start()
        Return True

    End Function

    Function StartTestProcedure() As Boolean
        '    If MyPLC.GetTagVal("ControlActive") Then
        Dim retval As Boolean = True

        'Dim CanStart As Boolean = MyPLC.GetTagVal("StationReady")

        Dim constr As String = "SELECT * from  LoadSteps  where ProjectID=" & ProjectID & " Order by idLoadSteps"

        If GetDataMySQL(con, daLoad, ds, dtLoad, False, constr) Then

            If dtLoad.Rows.Count <> 0 Then

                'If CanStart Then

                If CreatedDate = #1/1/0001 12:00:00 AM# Then
                    CreatedDate = Now()
                End If

                StartRuntime = Now
                CurrStepNo = -1 'Start from the beginning of steps
                LoadSecRem = 0
                RunSecRem = 0

                CurrMonActive = False
                PrevMonActive = False

                CurrentLife = 0
                GetLastlifeandRevolutions()
                PrevLife = Life 'For calculating revolutions


                Update_Timers_PLCWithParam() 'Update PLC Values
                LifeStrart = Now 'To measure life

                MyPrevStatus = ProjectStatus.Idle
                ''MyStatus = ProjectStatus.Started
                StopReason = ""
                AlarmNo = 0
                OtherHeadAlarmVal = 0


                'PleaseStop = False

                LoadTmr.AutoReset = True
                RunTmr.AutoReset = True
                DispUpTmr.AutoReset = True
                LoadStopTimer.AutoReset = False
                LoadStopTimer.Stop()


                LogUtilities(MyStatus, 0)
                LogData(0)


                DispUpTmr.Interval = DispUpdateRate.TotalMilliseconds
                LoadTmr.Interval = LoadLogRate.TotalMilliseconds
                RunTmr.Interval = RunLogRate.TotalMilliseconds

                ''  DispUpTmr.Enabled = True

                Array.Clear(oldArrSL1, 0, oldArrSL1.Length)
                Array.Clear(newArrSL1, 0, newArrSL1.Length)

                Array.Clear(oldArrSH1, 0, oldArrSH1.Length)
                Array.Clear(newArrSH1, 0, newArrSH1.Length)

                Array.Clear(oldArrWL1, 0, oldArrWL1.Length)
                Array.Clear(newArrWL1, 0, newArrWL1.Length)

                Array.Clear(oldArrWH1, 0, oldArrWH1.Length)
                Array.Clear(newArrWH1, 0, newArrWH1.Length)


                Array.Clear(oldArrSL2, 0, oldArrSL2.Length)
                Array.Clear(newArrSL2, 0, newArrSL2.Length)

                Array.Clear(oldArrSH2, 0, oldArrSH2.Length)
                Array.Clear(newArrSH2, 0, newArrSH2.Length)

                Array.Clear(oldArrWL2, 0, oldArrWL2.Length)
                Array.Clear(newArrWL2, 0, newArrWL2.Length)

                Array.Clear(oldArrWH2, 0, oldArrWH2.Length)
                Array.Clear(newArrWH2, 0, newArrWH2.Length)

                Array.Clear(oldArrMisc, 0, oldArrMisc.Length)
                Array.Clear(newArrMisc, 0, newArrMisc.Length)

                'Else
                '    MessageBox.Show("Station Not Ready", "Start Station", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Tmr.Stop()
                '    retval = False
                '    MyStatus = ProjectStatus.Suspended
                'End If

            Else
                MessageBox.Show("No loadsteps :ProjectCls", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Tmr.Stop()
                retval = False
                MyStatus = ProjectStatus.Suspended
            End If

        Else
            MessageBox.Show("Error getting load values: ProjectClass", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Tmr.Stop()
            retval = False
            MyStatus = ProjectStatus.Suspended
        End If

        MonitorAfter = My.Settings("MonitorAfter")
        MyPLC.SetTagVal("MonitorLimits", 0)

        '' UpdateProject()
        Return retval
        Debug.Print("Starting - Head ")

    End Function

    Sub StopTest(ReasonStr As String, AlarmNo As Integer)

        Tmr.AutoReset = False
        LoadTmr.AutoReset = False
        RunTmr.AutoReset = False
        DispUpTmr.AutoReset = False


        Tmr.Stop()
        LoadTmr.Stop()
        RunTmr.Stop()
        DispUpTmr.Stop()


        '' Threading.Thread.Sleep(1100) 'wait till the process is over. This is very important

        UpdateGraphData()
        TerminatedDate = Now
        UpdateProject()

        Dim ReasonID As Integer

        If AlarmNo = 0 Then
            ReasonID = AddReason(ReasonStr)
            LogUtilities(MyStatus, ReasonID)
            LogData(ReasonID)
        ElseIf AlarmNo = 80 And OtherHeadAlarmVal <> 0 Then
            ReasonID = AddReason(GetReason(OtherHeadAlarmVal)) '& If(HeadName = "A", " in Head B", " in Head A"))
            LogUtilities(MyStatus, ReasonID)
            LogData(ReasonID)
        Else
            LogUtilities(MyStatus, AlarmNo)
            LogData(AlarmNo)
        End If

        MyPLC.SetTagVal("DriveOff", 1)
        System.Threading.Thread.Sleep(100)
        MyPLC.SetTagVal("LubeOff", 1)
        System.Threading.Thread.Sleep(200)
        MyPLC.SetTagVal("ControlOff", 1)

        MyPLC.SetTagVal("MonitorLimits", 0)
        MyPLC.SetTagVal("MonitorLoad", 0)
        Debug.Print("Stopped Now" & ReasonID & " " & AlarmNo) ' & " HEadName - " & HeadName)
        'PleaseStop = True
    End Sub

    Public Sub FailTest(ReasonStr As String)
        Tmr.AutoReset = False
        LoadTmr.AutoReset = False
        RunTmr.AutoReset = False
        DispUpTmr.AutoReset = False

        Tmr.Stop()
        LoadTmr.Stop()
        RunTmr.Stop()
        DispUpTmr.Stop()

        ''Threading.Thread.Sleep(2000) 'wait till the process is over. This is very important

        MyStatus = ProjectStatus.Failure
        TerminatedDate = Now
        UpdateProject()

        Dim ReasonID As Integer = AddReason(ReasonStr)
        LogUtilities(ProjectStatus.Failure, ReasonID)
        LogData(ReasonID)

        MyPLC.SetTagVal("DriveOff", 1)
        System.Threading.Thread.Sleep(100)
        MyPLC.SetTagVal("LubeOff", 1)


        MyPLC.SetTagVal("MonitorLimits", 0)
        MyPLC.SetTagVal("MonitorLoad", 0)

        'PleaseStop = True
    End Sub


#Region "DatabaseFunctions"

    Public Sub Save()

        If Not isNew Then
            UpdateProject()
            UpdateParameters()
            UpdateBearings()
            If MyStatus = ProjectStatus.Run Or MyStatus = ProjectStatus.Load Then Update_Timers_PLCWithParam() 'If the projet is running then update limits

        Else

            If NewProject() Then
                LoadProject() 'Load them again!
                NewParameters()
                NewLoadSet()
                NewBearings()
                isNew = False
            End If

        End If

        'Do this in last
        RaiseEvent ProjectChanged(ProjectID)



    End Sub

    Public Sub LoadExisting(PrjID As String)
        'Do not load HEadName and MAchineName

        ProjectID = PrjID
        LoadProject()
        LoadParameters()
        LoadBearings()


        'Do not raise event when application loads
        RaiseEvent ProjectChanged(ProjectID)
    End Sub

#Region "ProjectDatabase"
    'Function GetProjectStatus(ProjectID As String) As ProjectStatus

    Function GetProjectStatus() As ProjectStatus
        'Dim constr As String = "SELECT * from Project where ProjectID=" & ProjectID
        'If GetDataMySQL(con, da, ds, dt3, False, constr) Then
        '    If IsDBNull(dt3.Rows(0).Item("ProjectStatus")) Then
        '        Return ProjectStatus.Indeterminate
        '    Else
        '        Debug.Print("Project Status" & dt3.Rows(0).Item("ProjectStatus"))
        '        Return dt3.Rows(0).Item("ProjectStatus")
        '    End If
        'End If
        'Return ProjectStatus.Indeterminate
        Return MyStatus
    End Function

    Sub LoadProject()
        Dim constr As String = "SELECT * from Project where ProjectID=" & ProjectID
        If GetDataMySQL(con, daPrj, ds, dt1, False, constr) Then

            ProjectIDTxt = dt1.Rows(0).Item("ProjectIDTxt")
            ProjectOwner = dt1.Rows(0).Item("Owner")
            TestID = dt1.Rows(0).Item("ProjectName")
            PartNo = dt1.Rows(0).Item("PartNo")
            Make = dt1.Rows(0).Item("Make")
            Lubrication = dt1.Rows(0).Item("Lubrication")


            HeadA = dt1.Rows(0).Item("HeadABearing")
            HeadB = dt1.Rows(0).Item("HeadBBearing")
            HeadC = dt1.Rows(0).Item("HeadCBearing")
            HeadD = dt1.Rows(0).Item("HeadDBearing")

            HeadA_Enable = dt1.Rows(0).Item("HeadA_Enable")
            HeadB_Enable = dt1.Rows(0).Item("HeadB_Enable")
            HeadC_Enable = dt1.Rows(0).Item("HeadC_Enable")
            HeadD_Enable = dt1.Rows(0).Item("HeadD_Enable")


            MaxRev = dt1.Rows(0).Item("MaxRev")
            MaxRevActive = dt1.Rows(0).Item("MaxRevActive")

            RunLogRate = dt1.Rows(0).Item("RunLogRate")
            LoadLogRate = dt1.Rows(0).Item("LoadLogRate")
            DispUpdateRate = dt1.Rows(0).Item("DispUpdateRate")

            'MyStatus = dt1.Rows(0).Item("ProjectStatus")
            If MyStatus = ProjectStatus.Idle Then MyStatus = ProjectStatus.Suspended
            '   LoadDurationRemaining = dt1.Rows(0).Item("LoadDurationRemaining")
            '  RunDurationRemaining = dt1.Rows(0).Item("RunDurationRemaining")
            ' CurrStepNo = dt1.Rows(0).Item("CurrentStep")
            ' CurrentLoad = dt1.Rows(0).Item("CurrLoad")
            '  CurrRev = dt1.Rows(0).Item("CurrRev")

            CreatedDate = dt1.Rows(0).Item("CreatedDate")
            TerminatedDate = dt1.Rows(0).Item("TerminatedDate")




            isPrjDataAvailable = True ' The Data is available in the DB

        End If
    End Sub

    Public Function CheckforExistingPrj(ProjectTxt As String) As Boolean
        Dim retval As Boolean = False
        Dim constr As String = "SELECT * from Project where ProjectIDtxt='" & ProjectTxt & "'"

        If GetDataMySQL(con, daPrj, ds, dt1, False, constr) Then
            If dt1.Rows.Count > 0 Then
                retval = True
            End If
        End If
        Return retval
    End Function

    Function NewProject() As Boolean
        Dim retval As Boolean = False
        'If Not CheckProject() Then
        '    MessageBox.Show("Improper project values", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return retval
        'End If
        CurrentLoad = 0
        CurrRev = 0

        'create a new record
        Using SQLConnection As New MySqlConnection(serv)
            Using sqlCommand As New MySqlCommand()
                With sqlCommand
                    .CommandText = "INSERT INTO Project (`ProjectIDTxt`, `Owner`, `ProjectName`, `PartNo`, `Make`, `Lubrication`, `HeadABearing`, `HeadBBearing`, `HeadCBearing`, `HeadDBearing`, `HeadA_Enable`, `HeadB_Enable`, `HeadC_Enable`, `HeadD_Enable`,`MaxRev`, `MaxRevActive`, `RunLogRate`,`LoadLogRate`, `DispUpdateRate`,`LoadDurationRemaining`, `RunDurationRemaining`, `CurrentStep`, `CurrLoad`,  `CurrRev`,  `CreatedDate`, `TerminatedDate`, `ProjectStatus` ) values (@pid,@owner,@prjname,@pn,@mk,@lub,@ha, @hb,@hc,@hd,@ha_en,@hb_en,@hc_en,@hd_en,@maxr,@maxract,@runlrt,@loadlrt,@duprt,@ldrm,@rdrm,@curstp,@curld,@crrev,@crdt,@trmDt,@prjsts);" &
                        " Select LAST_INSERT_ID()"
                    .Connection = SQLConnection
                    .CommandType = CommandType.Text

                    .Parameters.AddWithValue("@pid", ProjectIDTxt)
                    .Parameters.AddWithValue("@owner", ProjectOwner)
                    .Parameters.AddWithValue("@prjname", TestID)
                    .Parameters.AddWithValue("@pn", PartNo)
                    .Parameters.AddWithValue("@mk", Make)
                    .Parameters.AddWithValue("@lub", Lubrication)

                    .Parameters.AddWithValue("@ha", HeadA)
                    .Parameters.AddWithValue("@hb", HeadB)
                    .Parameters.AddWithValue("@hc", HeadC)
                    .Parameters.AddWithValue("@hd", HeadD)

                    .Parameters.AddWithValue("@ha_en", HeadA_Enable)
                    .Parameters.AddWithValue("@hb_en", HeadB_Enable)
                    .Parameters.AddWithValue("@hc_en", HeadC_Enable)
                    .Parameters.AddWithValue("@hd_en", HeadD_Enable)



                    .Parameters.AddWithValue("@maxr", MaxRev)
                    .Parameters.AddWithValue("@maxract", MaxRevActive)
                    .Parameters.AddWithValue("@runlrt", RunLogRate)
                    .Parameters.AddWithValue("@loadlrt", LoadLogRate)
                    .Parameters.AddWithValue("@duprt", DispUpdateRate)
                    .Parameters.AddWithValue("@ldrm", 0)
                    .Parameters.AddWithValue("@rdrm", 0)
                    .Parameters.AddWithValue("@curstp", -1) 'Fresh Start
                    .Parameters.AddWithValue("@curld", CurrentLoad)
                    .Parameters.AddWithValue("@crrev", CurrRev)
                    .Parameters.AddWithValue("@crdt", Now())
                    .Parameters.AddWithValue("@trmDt", TerminatedDate)
                    .Parameters.AddWithValue("@prjsts", ProjectStatus.Idle)


                End With
                Try
                    SQLConnection.Open()
                    'sqlCommand.ExecuteNonQuery()
                    ProjectID = sqlCommand.ExecuteScalar
                    retval = True
                Catch ex As MySqlException
                    MessageBox.Show(ex.Message.ToString, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    SQLConnection.Close()
                End Try
            End Using
        End Using

        ''Get the project ID
        'Dim constr As String = "SELECT * from Project where CreatedDate>='" & String.Format("{0:u}", CreatedDateTime.AddSeconds(-1)) & "' and ProjectIDTxt='" & ProjectIDTxt & "'"
        'If GetDataMySQL(con, daPrj, ds, dt1, False, constr) Then
        '    ProjectID = dt1.Rows(0).Item("ProjectID")
        'End If

        Return retval
    End Function

    Sub UpdateProject()
        'Dim ts As TimeSpan
        'Dim primaryKey(1) As DataColumn

        Dim constr As String = "SELECT * from Project where ProjectID=" & ProjectID
        If GetDataMySQL(con, daPrj, ds, dt1, False, constr) Then
            '    primaryKey(1) = dt1.Columns("idProject")
            '    dt1.PrimaryKey = primaryKey

            Try
                dt1.Rows(0).Item("ProjectID") = ProjectID
                dt1.Rows(0).Item("Owner") = ProjectOwner
                dt1.Rows(0).Item("ProjectName") = TestID
                dt1.Rows(0).Item("PartNo") = PartNo
                dt1.Rows(0).Item("Make") = Make
                dt1.Rows(0).Item("Lubrication") = Lubrication

                dt1.Rows(0).Item("HeadABearing") = HeadA
                dt1.Rows(0).Item("HeadBBearing") = HeadB
                dt1.Rows(0).Item("HeadCBearing") = HeadC
                dt1.Rows(0).Item("HeadDBearing") = HeadD

                dt1.Rows(0).Item("HeadA_Enable") = HeadA_Enable
                dt1.Rows(0).Item("HeadB_Enable") = HeadB_Enable
                dt1.Rows(0).Item("HeadC_Enable") = HeadC_Enable
                dt1.Rows(0).Item("HeadD_Enable") = HeadD_Enable

                dt1.Rows(0).Item("MaxRev") = MaxRev
                dt1.Rows(0).Item("MaxRevActive") = MaxRevActive

                dt1.Rows(0).Item("RunLogRate") = RunLogRate
                dt1.Rows(0).Item("LoadLogRate") = LoadLogRate
                dt1.Rows(0).Item("DispUpdateRate") = DispUpdateRate

                dt1.Rows(0).Item("ProjectStatus") = MyStatus

                '   dt1.Rows(0).Item("LoadDurationRemaining") = LoadDurationRemaining
                'dt1.Rows(0).Item("RunDurationRemaining") = RunDurationRemaining
                ' dt1.Rows(0).Item("CurrentStep") = CurrStepNo
                'dt1.Rows(0).Item("CurrLoad") = CurrentLoad
                dt1.Rows(0).Item("CurrRev") = CurrRev

                If CreatedDate = #1/1/0001 12:00:00 AM# Then dt1.Rows(0).Item("CreatedDate") = CreatedDate 'Update only once when the test runs
                dt1.Rows(0).Item("TerminatedDate") = TerminatedDate


                Dim str As String = "Current Step" & CurrStepNo & ",LdRem:" & LoadSecRem.ToString & ",RnRem:" & RunSecRem.ToString & ", Curld:" & CurrentLoad
                Debug.Print(str)
                cb = New MySqlCommandBuilder(daPrj) 'to make the ds updatable
                cb.ConflictOption = ConflictOption.OverwriteChanges

                daPrj.Update(dt1)

                daPrj.Fill(dt1)

            Catch ex As MySqlException
                MessageBox.Show("Error -Update Project ", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If
        'MsgBox("Profile Updated!", vbInformation)

        LoadProject() 'load them again!
    End Sub

#End Region 'Project Database region end

#Region "ParameterDatabase"

    Sub LoadParameters()

        Dim vals(18) As SingleLimits
        Dim i As Integer
        Dim constr As String = "SELECT * from parameters where ProjectID=" & ProjectID & " Order by ParameterID"
        If GetDataMySQL(con, daParam, ds, dt2, False, constr) Then

            If dt2.Rows.Count = 19 Then
                For i = 0 To 18
                    vals(i).Value = dt2.Rows(i).Item("Value")
                    vals(i).WH = dt2.Rows(i).Item("WH")
                    vals(i).WL = dt2.Rows(i).Item("WL")
                    vals(i).SH = dt2.Rows(i).Item("SH")
                    vals(i).SL = dt2.Rows(i).Item("SL")
                    vals(i).Setpoint = dt2.Rows(i).Item("Setpoint")
                    vals(i).Bypass = dt2.Rows(i).Item("Bypass")

                Next i
                isParamDataAvailable = True ' The Data is available in the DB
            End If


            BA = vals(0)
            SBA = vals(1)
            Inlet_TempA = vals(2)
            VibrationA = vals(3)

            BB = vals(4)
            SBB = vals(5)
            Inlet_TempB = vals(6)
            VibrationB = vals(7)

            BC = vals(8)
            SBC = vals(9)
            Inlet_TempC = vals(10)
            VibrationC = vals(11)

            BD = vals(12)
            SBD = vals(13)
            Inlet_TempD = vals(14)
            VibrationD = vals(15)

            TankTemp = vals(16)
            Load = vals(17)
            Speed = vals(18)



            BA.TagName = "BTempA"
            SBA.TagName = "SBTempA"
            Inlet_TempA.TagName = "Inlet_TempA"
            VibrationA.TagName = "VibA"
            BB.TagName = "BTempB"
            SBB.TagName = "SBTempB"
            Inlet_TempB.TagName = "Inlet_TempB"
            VibrationB.TagName = "VibB"
            BC.TagName = "BTempC"
            SBC.TagName = "SBTempC"
            Inlet_TempC.TagName = "Inlet_TempC"
            VibrationC.TagName = "VibC"
            BD.TagName = "BTempD"
            SBD.TagName = "SBTempD"
            Inlet_TempD.TagName = "Inlet_TempD"
            VibrationD.TagName = "VibD"
            TankTemp.TagName = "OutTankTemp"
            Load.TagName = "Load"
            Speed.TagName = "Speed"

        End If
    End Sub

    Sub NewParameters()
        'create a new records
        Dim i As Integer
        Dim vals(19) As SingleLimits
        vals(0) = BA
        vals(1) = SBA
        vals(2) = Inlet_TempA
        vals(3) = VibrationA

        vals(4) = BB
        vals(5) = SBA
        vals(5).Bypass = SBB.Bypass
        vals(6) = Inlet_TempB
        vals(7) = VibrationB

        vals(8) = BC
        vals(9) = SBA
        vals(9).Bypass = SBC.Bypass
        vals(10) = Inlet_TempC
        vals(11) = VibrationC

        vals(12) = BD
        vals(13) = SBA
        vals(13).Bypass = SBD.Bypass
        vals(14) = Inlet_TempD
        vals(15) = VibrationD

        vals(16) = TankTemp
        vals(17) = Load
        vals(18) = Speed




        Dim SQLConnection As New MySqlConnection(serv)
        Dim sqlCommand As New MySqlCommand()

        sqlCommand.CommandText = "INSERT INTO Parameters (`ProjectID`, `ParameterID`, `WH`, `WL`, `SH`, `SL`, `Value`, `Setpoint`, `Bypass` ) values (@pid,@paramID,@wh,@wl,@sh,@sl,@val, @sp,@byp)"
        sqlCommand.CommandType = CommandType.Text
        sqlCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()
            For i = 0 To 18
                sqlCommand.Parameters.AddWithValue("@pid", ProjectID)
                sqlCommand.Parameters.AddWithValue("@paramid", i + 1)
                sqlCommand.Parameters.AddWithValue("@wh", vals(i).WH)
                sqlCommand.Parameters.AddWithValue("@wl", vals(i).WL)
                sqlCommand.Parameters.AddWithValue("@sh", vals(i).SH)
                sqlCommand.Parameters.AddWithValue("@sl", vals(i).SL)
                sqlCommand.Parameters.AddWithValue("@val", vals(i).Value)
                sqlCommand.Parameters.AddWithValue("@sp", vals(i).Setpoint)
                sqlCommand.Parameters.AddWithValue("@byp", vals(i).Bypass)

                sqlCommand.ExecuteNonQuery()

                sqlCommand.Parameters.Clear()

            Next i

        Catch ex As MySqlException
            MessageBox.Show("Error Creating Parameters", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLConnection.Close()
        End Try

        LoadParameters() 'load them again!
    End Sub

    'Create for new Project, Load parameters in a temporary table. Then copy it to regular table when that project is saved
    Sub NewLoadSet()

        ''The project ID should not exist in Parameters DB ( we can also check in Project DB itself)
        'Dim constr As String = "SELECT * from Parameters where ProjectID=" & ProjectID
        'GetDataMySQL(con, da, ds, dt3, False, constr)
        'If dt3.Rows.Count > 0 Then
        '    MsgBox("Choose a different Project ID in Project Values")
        '    Exit Sub
        'End If

        Dim SQLConnection As New MySqlConnection(serv)
        Dim sqlCommand As New MySqlCommand()



        sqlCommand.CommandText = "insert into LoadSteps (ProjectID,  StartLoad, EndLoad, LoadDuration, RunDuration, StepNo) select " & ProjectID & " as ProjectID,  StartLoad, EndLoad, LoadDuration, RunDuration, StepNo from LoadStepsTemp"
        sqlCommand.CommandType = CommandType.Text
        sqlCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()
            sqlCommand.ExecuteNonQuery()

            sqlCommand.CommandText = "Delete from LoadStepsTemp" 'Empty Temporary Table
            sqlCommand.ExecuteNonQuery()

        Catch ex As MySqlException
            MsgBox(ex.Message.ToString)
        Finally
            SQLConnection.Close()
        End Try
    End Sub

    Sub UpdateParameters()
        Dim i As Integer
        Dim vals(19) As SingleLimits
        Dim MyRow As DataRow

        vals(0) = BA
        vals(1) = SBA
        vals(2) = Inlet_TempA
        vals(3) = VibrationA

        vals(4) = BB
        vals(5) = SBB
        vals(6) = Inlet_TempB
        vals(7) = VibrationB

        vals(8) = BC
        vals(9) = SBC
        vals(10) = Inlet_TempC
        vals(11) = VibrationC

        vals(12) = BD
        vals(13) = SBD
        vals(14) = Inlet_TempD
        vals(15) = VibrationD

        vals(16) = TankTemp
        vals(17) = Load
        vals(18) = Speed

        Dim constr As String = "SELECT * from parameters where ProjectID=" & ProjectID & " Order by ParameterID"
        If GetDataMySQL(con, daParam, ds, dt2, False, constr) Then
            Try
                Dim RowCount = dt2.Rows.Count
                For i = 0 To 17
                    If RowCount = 0 Then MyRow = dt2.NewRow Else MyRow = dt2.Rows(i)
                    MyRow.Item("Value") = vals(i).Value
                    MyRow.Item("WH") = vals(i).WH
                    MyRow.Item("WL") = vals(i).WL
                    MyRow.Item("SH") = vals(i).SH
                    MyRow.Item("SL") = vals(i).SL
                    MyRow.Item("Setpoint") = vals(i).Setpoint
                    MyRow.Item("Bypass") = vals(i).Bypass
                    MyRow.Item("ProjectID") = ProjectID
                    MyRow.Item("ParameterID") = i
                    If RowCount = 0 Then dt2.Rows.Add(MyRow)
                Next i


                cb = New MySqlCommandBuilder(daParam) 'to make the ds updatable
                cb.ConflictOption = ConflictOption.OverwriteChanges
                daParam.Update(dt2)
            Catch ex As Exception
                MessageBox.Show("Database:error is:" & ex.Message)
                Exit Sub
            End Try
        End If
        'MsgBox("Profile Updated!", vbInformation)

        LoadParameters() 'load them again!
    End Sub

    Public Function CheckLoadSteps() As Integer
        Dim TableName As String
        Dim NoOfSteps As Integer = 0
        If isNew Then TableName = "LoadStepsTemp" Else TableName = "LoadSteps"
        Dim constr As String = "SELECT * from " & TableName & " where ProjectID=" & ProjectID
        If GetDataMySQL(con, daParam, ds, dtchkLoad, False, constr) Then
            NoOfSteps = dtchkLoad.Rows.Count
        End If
        Return NoOfSteps
    End Function

#End Region ' Parameter Database Region End

#Region "BearingDatabase"
    Sub LoadBearings()


        Dim i As Integer
        Dim constr As String = "SELECT * from Bearings where ProjectID=" & ProjectID & " Order by BearingNo"
        If GetDataMySQL(con, daParam, ds, dt2, False, constr) Then

            If dt2.Rows.Count = 40 Then
                For i = 0 To 39
                    Bearings(i).ProjectID = ProjectID
                    Bearings(i).BearingNo = i + 1
                    Bearings(i).Active = dt2.Rows(i).Item("Active")
                    Bearings(i).Failed = dt2.Rows(i).Item("Failed")
                    If Not IsDBNull(dt2.Rows(i).Item("AddedTime")) Then Bearings(i).AddedTime = dt2.Rows(i).Item("AddedTime")
                    If Not IsDBNull(dt2.Rows(i).Item("FailedTime")) Then Bearings(i).FailedTime = dt2.Rows(i).Item("FailedTime")

                Next i
                isParamDataAvailable = True ' The Data is available in the DB
            End If

        End If
    End Sub

    Sub NewBearings()
        'create a new records
        Dim CurrTime As Date = Now
        Dim SQLConnection As New MySqlConnection(serv)
        Dim sqlCommand As New MySqlCommand()

        sqlCommand.CommandText = "INSERT INTO Bearings (`ProjectID`, `BearingNo`, `Active`, `Failed`, `AddedTime`) values (@pid,@bno,@act,@fl,@at)"
        sqlCommand.CommandType = CommandType.Text
        sqlCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()
            For i = 0 To 39
                sqlCommand.Parameters.AddWithValue("@pid", ProjectID)
                sqlCommand.Parameters.AddWithValue("@bno", i + 1)
                sqlCommand.Parameters.AddWithValue("@act", True)
                sqlCommand.Parameters.AddWithValue("@fl", False)
                sqlCommand.Parameters.AddWithValue("@at", CurrTime)
                sqlCommand.ExecuteNonQuery()

                sqlCommand.Parameters.Clear()

            Next i

        Catch ex As MySqlException
            MessageBox.Show("Error Creating Bearings", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLConnection.Close()
        End Try

        LoadBearings() 'load them again!
    End Sub

    Public Sub UpdateBearings()
        Dim i As Integer
        Dim MyRow As DataRow


        Dim constr As String = "SELECT * from Bearings where ProjectID=" & ProjectID & " Order by BearingNo"
        If GetDataMySQL(con, daParam, ds, dt2, False, constr) Then
            Try
                Dim RowCount = dt2.Rows.Count
                For i = 0 To 39
                    If RowCount = 0 Then MyRow = dt2.NewRow Else MyRow = dt2.Rows(i)
                    MyRow.Item("ProjectID") = ProjectID
                    MyRow.Item("BearingNo") = i + 1
                    MyRow.Item("Active") = Bearings(i).Active
                    MyRow.Item("Failed") = Bearings(i).Failed
                    MyRow.Item("AddedTime") = Bearings(i).AddedTime
                    MyRow.Item("FailedTime") = Bearings(i).FailedTime
                    If RowCount = 0 Then dt2.Rows.Add(MyRow)
                Next i


                cb = New MySqlCommandBuilder(daParam) 'to make the ds updatable
                cb.ConflictOption = ConflictOption.OverwriteChanges
                daParam.Update(dt2)
            Catch ex As Exception
                MessageBox.Show("Database:error is:" & ex.Message)
                Exit Sub
            End Try
        End If
        'MsgBox("Profile Updated!", vbInformation)

        LoadBearings() 'load them again!
    End Sub

    Public Sub DisableStn(HeadStr As String)
        If Not ProjectID = 0 Then
            Select Case HeadStr
                Case "A"
                    Bearings(Station.MC.myProj.HeadA - 1).Active = False
                    Station.MC.myProj.HeadA = 0
                    Station.MC.myProj.HeadA_Enable = False
                Case "B"
                    Bearings(Station.MC.myProj.HeadB - 1).Active = False
                    Station.MC.myProj.HeadB = 0
                    Station.MC.myProj.HeadB_Enable = False
                Case "C"
                    Bearings(Station.MC.myProj.HeadC - 1).Active = False
                    Station.MC.myProj.HeadC = 0
                    Station.MC.myProj.HeadC_Enable = False
                Case "D"
                    Bearings(Station.MC.myProj.HeadD - 1).Active = False
                    Station.MC.myProj.HeadD = 0
                    Station.MC.myProj.HeadD_Enable = False
            End Select
            UpdateBearings()
            UpdateProject()
        End If
    End Sub

    Public Function CheckforBearings(BearNo As Integer) As Boolean
        Dim retval As Boolean = False
        Dim constr As String = "SELECT * from Bearings where ProjectID=" & ProjectID & " and BearingNo=" & BearNo & " and Failed=True "

        If GetDataMySQL(con, daPrj, ds, dt1, False, constr) Then
            If dt1.Rows.Count > 0 Then
                retval = True 'Bearing already exists
            End If
        End If
        Return retval
    End Function
#End Region

#End Region 'end of database functions

    Private Sub Tmr_Elapsed(sender As Object, e As EventArgs) Handles Tmr.Elapsed
        'Tmr.Enabled = False
        CheckForLoadRunCompletion()
        'Tmr.Enabled = True
    End Sub

    Private Sub CheckForLoadRunCompletion()

        Dim sw As Stopwatch = New Stopwatch

        Tmr.Enabled = False


        Dim ElapsedTime As Double = 0
        Dim CurTime As Date
        Dim TotalLoadDur As TimeSpan
        sw.Restart()



        ProcessWarnings()

        AlarmNo = ProcessAlarms()
        If (MyStatus = ProjectStatus.Run Or MyStatus = ProjectStatus.Load) And (Not MyPLC.GetTagVal("StationReady") Or AlarmNo <> 0) Then

            Tmr.Enabled = False

            If AlarmNo = 0 Then 'Get the reason. If the Station has tripped due to other head then get the other head trip reason
                AlarmNo = 80 'Station Not Ready
                System.Threading.Thread.Sleep(4000) 'sleep for 2 Sec
                'If HeadName = "A" Then OtherHeadAlarmVal = MyPLC.GetTagVal("AlarmNoB") Else OtherHeadAlarmVal = MyPLC.GetTagVal("AlarmNoA")
            End If

            Debug.Print("Stopping Due to Alarm" & AlarmNo)
            MyStatus = ProjectStatus.Suspended
            StopReason = ""
            ''            StopTest("", AlarmNo) 'end of test
            '  RaiseEvent StatusChange(MyStatus)
            'Exit Sub
        End If




        If MyStatus = ProjectStatus.Suspended Then
            LoadStopTimer.Interval = 100000 '100s
            LoadStopTimer.Start()
            StopTest(StopReason, AlarmNo) 'end of test
            Exit Sub
        End If

        'Calculate Life
        Dim runtime As TimeSpan = Now.Subtract(LifeStrart)
        Dim TotalHrs As Double = runtime.TotalHours
        CurrentLife = Life + TotalHrs

        If runtime.TotalSeconds > MonitorAfter Then CurrMonActive = True

        If CurrMonActive <> PrevMonActive Then ''rising edge
            MyPLC.SetTagVal("MonitorLimits", 1)
            DispUpTmr.Enabled = True
            PrevMonActive = CurrMonActive
        End If

        'Dim constr As String = "SELECT * from  LoadSteps  where ProjectID=" & ProjectID & " Order by idLoadSteps"

        'If Not IsPairBonded Or (IsPairBonded And HeadName = "A") Then
        'If GetDataMySQL(con, daLoad, ds, dtLoad, False, constr) Then

        'If dtLoad.Rows.Count > 0 Then


        'When both Load and Run are completed and continue executing the last step till the bearing fails
        If LoadSecRem = 0 And RunSecRem = 0 And CurrStepNo < (dtLoad.Rows.Count - 1) Then
                        CurrStepNo = CurrStepNo + 1
                        LoadDuration = dtLoad.Rows(CurrStepNo).Item("LoadDuration")
                        RunDuration = dtLoad.Rows(CurrStepNo).Item("RunDuration")

                        LoadSecRem = LoadDuration.TotalSeconds
                        RunSecRem = RunDuration.TotalSeconds
                        StartRuntime = Now()
                    End If

                    'Calculate the load slope
                    StartLoad = dtLoad.Rows(CurrStepNo).Item("StartLoad")
                    EndLoad = dtLoad.Rows(CurrStepNo).Item("EndLoad")
                    TotalLoadDur = dtLoad.Rows(CurrStepNo).Item("LoadDuration")



                    IncrementLoadPerSec = (EndLoad - StartLoad) / TotalLoadDur.TotalSeconds

                    CurTime = Now()
                    ElapsedTime = DateDiff(DateInterval.Second, StartRuntime, CurTime)


                    'Check if Load is completed or not
                    If LoadSecRem > 0 Then

                        LoadSecRem = LoadDuration.TotalSeconds - ElapsedTime
                        If LoadSecRem < 0 Then LoadSecRem = 0
                        'End If
                    End If

                    'When only Load is completed
                    If RunSecRem > 0 And LoadSecRem = 0 Then

                        RunSecRem = RunDuration.TotalSeconds + LoadDuration.TotalSeconds - ElapsedTime
                        If RunSecRem < 0 Then RunSecRem = 0
                        'End If
                    End If

                    ' CurrentLoad = CurrentLoad + IncrementLoadPerSec
                    CurrentLoad = EndLoad - (IncrementLoadPerSec * LoadSecRem)

                    MyPLC.SetTagVal("Load", CurrentLoad)


                    If CurrentLoad > EndLoad Then CurrentLoad = EndLoad 'Limit Current Load

                    'If CurrentLoad < EndLoad Then MyPLC.SetTagVal("MonitorLoad" & HeadName, 0) Else MyPLC.SetTagVal("MonitorLoad" & HeadName, 1) ' Do not monitor Load in Load phase

                    If CurrentLoad < EndLoad And MyStatus <> ProjectStatus.Suspended Then
                        MyStatus = ProjectStatus.Load
                    End If

                    If CurrentLoad = EndLoad And MyStatus <> ProjectStatus.Suspended Then
                        MyStatus = ProjectStatus.Run
                    End If

            '' UpdateProject() 'Update All values

            'Else
            '    MessageBox.Show("No loadsteps :ProjectCls", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If

            'Else
            '    MessageBox.Show("Error getting load values: ProjectClass", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If
            '    Else
            '    CurrentLoad = MyPLC.GetTagVal("Load")
            'End If

            MyPLC.SetTagVal("HeadStatus", MyStatus) '/*** Important change the tag name in the file


        If MyStatus = ProjectStatus.Load Then
            LoadTmr.Start()
            RunTmr.Stop()
        End If

        If MyStatus = ProjectStatus.Load Then MyPLC.SetTagVal("MonitorLoad", 1) Else MyPLC.SetTagVal("MonitorLoad", 0)

        If MyStatus = ProjectStatus.Run Then
            LoadTmr.Stop()
            RunTmr.Start()
        End If

        If MyStatus <> MyPrevStatus Then  'raising edge
            If Not (MyStatus = ProjectStatus.Started Or MyStatus = ProjectStatus.Suspended) Then LogData(0) 'Start and susp log taken care somewhere else
            MyPrevStatus = MyStatus
            UpdateProject()
            'RaiseEvent StatusChanged()
        End If

        LoadAuto = MyPLC.GetTagVal("LoadAuto")

        'If LoadAuto <> PrevLoadAuto Then 'If Someone Puts from Load setup to Load Auto - As required by Timken
        If Not LoadAuto Then 'restart loading phase
            LoadSecRem = 0
            RunSecRem = 0
            CurrStepNo = -1
        End If
        '    PrevLoadAuto = LoadAuto
        'End If


        'if maxRevolutions achieved
        If MaxRevActive Then
            If MaxRev < CurrRev Then
                MyStatus = ProjectStatus.Suspended
                Tmr.Enabled = False
                StopTest("Auto Stop MaxRev", 0)
                Tmr.Enabled = False
                Exit Sub
            End If
        End If

        sw.Stop()
        'Debug.Print("Processing Time is - " & sw.ElapsedMilliseconds & "HEadName - " & HeadName)

        'Application.DoEvents()
        TerminatedDate = Now
        CurrRev = Rev

        'Debug.Print("Load Value is  " & CurrentLoad)
        Tmr.Enabled = True

        ''If Not IsPairBonded Or (IsPairBonded And HeadName <> "A") Then
    End Sub

    Private Sub LoadTmr_Elapsed(sender As Object, e As EventArgs) Handles LoadTmr.Elapsed
        LogData(0)
        '    Debug.Print("Load Time Elapsed -" & Now)
    End Sub

    Private Sub RunTmr_Elapsed(sender As Object, e As EventArgs) Handles RunTmr.Elapsed
        LogData(0)
        '   Debug.Print("Run Time Elapsed -" & Now)
    End Sub

    Sub LogData(StopReasonID As Integer)

        If PleaseStop Then Exit Sub
        'Update Tag Data
        UpdateTagData()

        Rev = Rev + (((CurrentLife - PrevLife) * 60) * Speed.Value / 1000000) 'Calculate Revolutions
        Debug.Print("Rev, Current Life, PrevLife -" & Rev & "," & CurrentLife & ", " & PrevLife)
        PrevLife = CurrentLife


        'Debug.Print("Rev, Current Life, PrevLife -" & Rev & "," & CurrentLife & ", " & PrevLife)
        ''  Debug.Print("Loggin Data")
        Dim SQLConnection As New MySqlConnection(serv)
        Dim sqlCommand As New MySqlCommand()

        sqlCommand.CommandText = "INSERT INTO datalogs (`Status`,`StopReason`, `TankOilTemp`, `Speed`, `Load1`, `Revolutions`, `NoOfHours`, `ProjectID`  ) values (@sta,@stpRsn,@tnkOil,@spd,@ld,@rev,@nohr,@pid)"
        sqlCommand.CommandType = CommandType.Text
        sqlCommand.Connection = SQLConnection
        Dim StatusTxt As String
        Select Case MyStatus
            Case ProjectStatus.Load
                StatusTxt = "LOAD"
            Case ProjectStatus.Run
                StatusTxt = "RUN "
            Case ProjectStatus.Suspended
                StatusTxt = "SUSP"
            Case ProjectStatus.Failure
                StatusTxt = "FAIL"
            Case ProjectStatus.Started
                StatusTxt = "STRT"
            Case ProjectStatus.Stopped
                StatusTxt = "STOP"
            Case Else
                StatusTxt = "INDT" 'indeterminate
        End Select

        Try
            SQLConnection.Open()

            sqlCommand.Parameters.AddWithValue("@sta", StatusTxt)
            sqlCommand.Parameters.AddWithValue("@stpRsn", StopReasonID)
            sqlCommand.Parameters.AddWithValue("@tnkOil", TankTemp.Value)
            sqlCommand.Parameters.AddWithValue("@spd", Speed.Value)
            sqlCommand.Parameters.AddWithValue("@ld", Load.Value)
            sqlCommand.Parameters.AddWithValue("@rev", Rev)
            sqlCommand.Parameters.AddWithValue("@nohr", CurrentLife)
            sqlCommand.Parameters.AddWithValue("@pid", ProjectID)

            sqlCommand.ExecuteNonQuery()

            ''     sqlCommand.Parameters.Clear()
            'Debug.Print("CurrRev in logs " & Rev)


        Catch ex As MySqlException
            MessageBox.Show(ex.Message.ToString, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLConnection.Close()
        End Try

        If HeadA_Enable Then LogBearings("A", HeadA, StopReasonID, StatusTxt, BA.Value, SBA.Value, Inlet_TempA.Value, VibrationA.Value)
        If HeadB_Enable Then LogBearings("B", HeadB, StopReasonID, StatusTxt, BB.Value, SBB.Value, Inlet_TempB.Value, VibrationB.Value)
        If HeadC_Enable Then LogBearings("C", HeadC, StopReasonID, StatusTxt, BC.Value, SBC.Value, Inlet_TempC.Value, VibrationC.Value)
        If HeadD_Enable Then LogBearings("D", HeadD, StopReasonID, StatusTxt, BD.Value, SBD.Value, Inlet_TempD.Value, VibrationD.Value)

    End Sub

    Sub LogBearings(HeadStr As String, BearingNo As Integer, StopReasonIDPar As Integer, StatusTxtPar As String, bVal As Single, sbVal As Single, ItVal As Single, Vibration As Single)
        Dim SQLConnection As New MySqlConnection(serv)
        Dim sqlCommand As New MySqlCommand()

        sqlCommand.CommandText = "INSERT INTO datalogs_" & HeadStr & "(`Status`,`StopReason`, `B`, `SB`, `Inlet_Temp`, `Vib`, `ProjectID`,`BearingNo`, `LogTime`  ) values (@sta,@stpRsn,@b,@sb,@it,@vib,@pid,@bno,@lgdt)"
        sqlCommand.CommandType = CommandType.Text
        sqlCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()

            sqlCommand.Parameters.AddWithValue("@sta", StatusTxtPar)
            sqlCommand.Parameters.AddWithValue("@stpRsn", StopReasonIDPar)
            sqlCommand.Parameters.AddWithValue("@b", bVal)
            sqlCommand.Parameters.AddWithValue("@sb", sbVal)
            sqlCommand.Parameters.AddWithValue("@it", ItVal)
            sqlCommand.Parameters.AddWithValue("@vib", Vibration)
            sqlCommand.Parameters.AddWithValue("@pid", ProjectID)
            sqlCommand.Parameters.AddWithValue("@bno", BearingNo)
            sqlCommand.Parameters.AddWithValue("@lgdt", Now)

            sqlCommand.ExecuteNonQuery()



        Catch ex As MySqlException
            MessageBox.Show(ex.Message.ToString, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLConnection.Close()
        End Try

    End Sub

    Public Sub LogUtilities(Status As ProjectStatus, ReasonID As Integer)
        Dim SQLConnection As New MySqlConnection(serv)
        Dim sqlCommand As New MySqlCommand()

        sqlCommand.CommandText = "INSERT INTO utility ( `ProjectIDTxt`, `Operation`, `ReasonID`,`BA`,`BB`,`BC`,`BD` ) values (@pid,@oper,@reasn,@b1,@b2,@b3,@b4)"
        sqlCommand.CommandType = CommandType.Text
        sqlCommand.Connection = SQLConnection

        Dim StatusTxt As String
        Select Case Status
            Case ProjectStatus.Load
                StatusTxt = "LOAD"
            Case ProjectStatus.Run
                StatusTxt = "RUN "
            Case ProjectStatus.Suspended
                StatusTxt = "SUSP"
            Case ProjectStatus.Failure
                StatusTxt = "FAIL"
            Case ProjectStatus.Started
                StatusTxt = "STRT"
            Case ProjectStatus.Stopped
                StatusTxt = "STOP"
            Case Else
                StatusTxt = "INDT" 'indeterminate
        End Select

        Try
            SQLConnection.Open()

            sqlCommand.Parameters.AddWithValue("@pid", ProjectIDTxt)
            sqlCommand.Parameters.AddWithValue("@oper", StatusTxt)
            sqlCommand.Parameters.AddWithValue("@reasn", ReasonID)
            sqlCommand.Parameters.AddWithValue("@b1", HeadA)
            sqlCommand.Parameters.AddWithValue("@b2", HeadB)
            sqlCommand.Parameters.AddWithValue("@b3", HeadC)
            sqlCommand.Parameters.AddWithValue("@b4", HeadD)

            sqlCommand.ExecuteNonQuery()

            sqlCommand.Parameters.Clear()



        Catch ex As MySqlException
            MessageBox.Show(ex.Message.ToString, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLConnection.Close()
        End Try
    End Sub

    Sub CreateGraphDataTables()
        'dsGraphs = New DataSet()

        'Dim constr As String = "SELECT * from chrt_vib"
        'GetDataMySQL(con, daGrph, ds, dtVibration, False, constr)

        'constr = "SELECT * from chrt_speed"
        'GetDataMySQL(con, daGrph, ds, dtSpeed, False, constr)

        'constr = "SELECT * from chrt_load"
        'GetDataMySQL(con, daGrph, ds, dtLoadDisp, False, constr)

        'constr = "SELECT * from chrt_bearings"
        'GetDataMySQL(con, daGrph, ds, dtBearing, False, constr)

        'constr = "SELECT * from chrt_oiltemp"
        'GetDataMySQL(con, daGrph, ds, dtOilTemp, False, constr)


    End Sub

    Sub UpdateGraphData()

        'If MyPLC.GetTagVal("MonitorLimits" & HeadName) = 0 Then Exit Sub
        Dim MyRow As DataRow

        UpdateTagData()

        'DataUpdateLock.EnterWriteLock()

        Try
            Dim constr As String = "SELECT * from chrt_vib"
            GetDataMySQL(con, daGrph, ds, dtVibration, False, constr)
            If dtVibration.Rows.Count > NoOfGraphEntries Then dtVibration.Rows(0).Delete()
            MyRow = dtVibration.NewRow
            MyRow.Item("MinVal") = VibrationA.SL
            MyRow.Item("MaxVal") = VibrationA.SH
            MyRow.Item("VibrationA") = VibrationA.Value
            MyRow.Item("VibrationB") = VibrationB.Value
            MyRow.Item("VibrationC") = VibrationC.Value
            MyRow.Item("VibrationD") = VibrationD.Value
            dtVibration.Rows.Add(MyRow)
            cb = New MySqlCommandBuilder(daGrph) 'to make the ds updatable
            cb.ConflictOption = ConflictOption.OverwriteChanges
            daGrph.Update(dtVibration)

            constr = "SELECT * from chrt_bearings"
            GetDataMySQL(con, daGrph, ds, dtBearing, False, constr)
            If dtBearing.Rows.Count > NoOfGraphEntries Then dtBearing.Rows(0).Delete()
            MyRow = dtBearing.NewRow
            MyRow.Item("MinVal") = BA.SL
            MyRow.Item("MaxVal") = BA.SH
            MyRow.Item("BA") = BA.Value
            MyRow.Item("BB") = BB.Value
            MyRow.Item("BC") = BC.Value
            MyRow.Item("BD") = BD.Value
            MyRow.Item("SBA") = SBA.Value
            MyRow.Item("SBB") = SBB.Value
            MyRow.Item("SBC") = SBC.Value
            MyRow.Item("SBD") = SBD.Value
            dtBearing.Rows.Add(MyRow)
            cb = New MySqlCommandBuilder(daGrph) 'to make the ds updatable
            cb.ConflictOption = ConflictOption.OverwriteChanges
            daGrph.Update(dtBearing)

            constr = "SELECT * from chrt_oiltemp"
            GetDataMySQL(con, daGrph, ds, dtOilTemp, False, constr)
            If dtOilTemp.Rows.Count > NoOfGraphEntries Then dtOilTemp.Rows(0).Delete()
            MyRow = dtOilTemp.NewRow
            MyRow.Item("MinVal") = Inlet_TempA.SL
            MyRow.Item("MaxVal") = Inlet_TempA.SH
            MyRow.Item("InletOilA") = Inlet_TempA.Value
            MyRow.Item("InletOilB") = Inlet_TempB.Value
            MyRow.Item("InletOilC") = Inlet_TempC.Value
            MyRow.Item("InletOilD") = Inlet_TempD.Value
            MyRow.Item("TankOil") = TankTemp.Value
            dtOilTemp.Rows.Add(MyRow)
            cb = New MySqlCommandBuilder(daGrph) 'to make the ds updatable
            cb.ConflictOption = ConflictOption.OverwriteChanges
            daGrph.Update(dtOilTemp)


            constr = "SELECT * from chrt_speed"
            GetDataMySQL(con, daGrph, ds, dtSpeed, False, constr)
            If dtSpeed.Rows.Count > NoOfGraphEntries Then dtSpeed.Rows(0).Delete()
            MyRow = dtSpeed.NewRow
            MyRow.Item("MinVal") = Speed.SL
            MyRow.Item("MaxVal") = Speed.SH
            MyRow.Item("Speed") = Speed.Value
            dtSpeed.Rows.Add(MyRow)
            cb = New MySqlCommandBuilder(daGrph) 'to make the ds updatable
            cb.ConflictOption = ConflictOption.OverwriteChanges
            daGrph.Update(dtSpeed)

            constr = "SELECT * from chrt_load"
            GetDataMySQL(con, daGrph, ds, dtLoadDisp, False, constr)
            If dtLoadDisp.Rows.Count > NoOfGraphEntries Then dtLoadDisp.Rows(0).Delete()
            MyRow = dtLoadDisp.NewRow
            MyRow.Item("MinVal") = Load.SL
            MyRow.Item("MaxVal") = Load.SH
            MyRow.Item("Load") = Load.Value
            dtLoadDisp.Rows.Add(MyRow)
            cb = New MySqlCommandBuilder(daGrph) 'to make the ds updatable
            cb.ConflictOption = ConflictOption.OverwriteChanges
            daGrph.Update(dtLoadDisp)

        Catch ex As Exception
            MessageBox.Show("Database:error is:" & ex.Message)
            Exit Sub
        End Try


        'DataUpdateLock.ExitWriteLock()

    End Sub

    Sub UpdateTagData()
        'Update Tag Data
        BA.Value = MyPLC.GetTagVal("BTempA_actVal")
        BB.Value = MyPLC.GetTagVal("BTempB_actVal")
        BC.Value = MyPLC.GetTagVal("BTempC_actVal")
        BD.Value = MyPLC.GetTagVal("BTempD_actVal")

        SBA.Value = MyPLC.GetTagVal("SBTempA_actVal")
        SBB.Value = MyPLC.GetTagVal("SBTempB_actVal")
        SBC.Value = MyPLC.GetTagVal("SBTempC_actVal")
        SBD.Value = MyPLC.GetTagVal("SBTempD_actVal")

        Inlet_TempA.Value = MyPLC.GetTagVal("Inlet_TempA_ActVal")
        Inlet_TempB.Value = MyPLC.GetTagVal("Inlet_TempB_ActVal")
        Inlet_TempC.Value = MyPLC.GetTagVal("Inlet_TempC_ActVal")
        Inlet_TempD.Value = MyPLC.GetTagVal("Inlet_TempD_ActVal")

        VibrationA.Value = MyPLC.GetTagVal("VibrationA_ActVal")
        VibrationB.Value = MyPLC.GetTagVal("VibrationB_ActVal")
        VibrationC.Value = MyPLC.GetTagVal("VibrationC_ActVal")
        VibrationD.Value = MyPLC.GetTagVal("VibrationD_ActVal")

        TankTemp.Value = MyPLC.GetTagVal("TankTemp_ActVal")
        Speed.Value = MyPLC.GetTagVal("Speed_ActVal")
        Load.Value = MyPLC.GetTagVal("Load_ActVal")


        'CurrRev = Rev + (MyPLC.GetTagVal("RevolutionsA") / 1000000) 'iN mILLIONS
        'Debug.Print("Currev in get tagdata " & MyPLC.GetTagVal("RevolutionsA"))
    End Sub

    Sub GetLastlifeandRevolutions()

        Dim constr As String = "SELECT * from datalogs where ProjectID=" & ProjectID & " Order by idDataLogs DESC Limit 1"
        GetDataMySQL(con, da, ds, dt3, False, constr)
        If dt3.Rows.Count > 0 Then
            Life = dt3.Rows(0).Item("NoOfHours")
            Rev = dt3.Rows(0).Item("Revolutions")
        Else
            Life = 0
            Rev = 0
        End If
    End Sub

    Sub Update_Timers_PLCWithParam()
        Dim i As Integer
        Dim vals(18) As SingleLimits
        vals(0) = BA
        vals(1) = BB
        vals(2) = BC
        vals(3) = BD

        vals(4) = SBA
        vals(5) = SBB
        vals(6) = SBC
        vals(7) = SBD

        vals(8) = Inlet_TempA
        vals(9) = Inlet_TempB
        vals(10) = Inlet_TempC
        vals(11) = Inlet_TempD

        vals(12) = VibrationA
        vals(13) = VibrationB
        vals(14) = VibrationC
        vals(15) = VibrationD

        vals(16) = Speed

        vals(17) = Load
        vals(18) = TankTemp



        Try
            For i = 0 To 18
                '  MyPLC.SetTagVal(vals(i).TagName & "_Actval", vals(i).Value)
                MyPLC.SetTagVal(vals(i).TagName & "_WH", vals(i).WH)
                MyPLC.SetTagVal(vals(i).TagName & "_WL", vals(i).WL)
                MyPLC.SetTagVal(vals(i).TagName & "_SH", vals(i).SH)
                MyPLC.SetTagVal(vals(i).TagName & "_SL", vals(i).SL)
                MyPLC.SetTagVal(vals(i).TagName & "_Byp", vals(i).Bypass)

            Next i

            'If (Not IsPairBonded) Or (IsPairBonded And HeadName = "A") Then
            '    MyPLC.SetTagVal("SpeedSP", Speed.Setpoint)
            '    MyPLC.SetTagVal("LubOilTempSP", InTankTemp.Setpoint)
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        DispUpTmr.Interval = DispUpdateRate.TotalMilliseconds
        LoadTmr.Interval = LoadLogRate.TotalMilliseconds
        RunTmr.Interval = RunLogRate.TotalMilliseconds

        'MsgBox("Profile Updated!", vbInformation)
    End Sub

    Sub ProcessWarnings()
        Try
            Dim value As UInt16 = MyPLC.GetTagValUint16("WarnLow1")
            Dim b As BitArray = New BitArray(BitConverter.GetBytes(value))
            b.CopyTo(newArrWL1, 0)

            value = MyPLC.GetTagValUint16("WarnHigh1")
            b = New BitArray(BitConverter.GetBytes(value))
            b.CopyTo(newArrWH1, 0)

            value = MyPLC.GetTagValUint16("WarnLow1")
            b = New BitArray(BitConverter.GetBytes(value))
            b.CopyTo(newArrWL2, 0)

            value = MyPLC.GetTagValUint16("WarnHigh1")
            b = New BitArray(BitConverter.GetBytes(value))
            b.CopyTo(newArrWH2, 0)


            Dim J As Integer = 1
            For i = 0 To 15
                If oldArrWL1(i) <> newArrWL1(i) And newArrWL1(i) Then
                    LogAlarm(i + J)
                    Debug.Print("Change in Warning Low value with index-" & i + J)
                End If
                'oldArrWL(i) = newArrWL(i)
                If newArrWL1(i) Then oldArrWL1(i) = True
                'Application.DoEvents()
            Next

            J = 17
            For i = 0 To 15
                If oldArrWL2(i) <> newArrWL2(i) And newArrWL2(i) Then
                    LogAlarm(i + J)
                    Debug.Print("Change in Warning Low value with index-" & i + J)
                End If
                If newArrWL2(i) Then oldArrWL2(i) = True
            Next

            J = 33
            For i = 0 To 15
                If oldArrWH1(i) <> newArrWH1(i) And newArrWH1(i) Then
                    LogAlarm(i + J)
                    Debug.Print("Change in Warning Low value with index-" & i + J)
                End If
                If newArrWH1(i) Then oldArrWH1(i) = True
            Next

            J = 49
            For i = 0 To 15
                If oldArrWH2(i) <> newArrWH2(i) And newArrWH2(i) Then
                    LogAlarm(i + J)
                    Debug.Print("Change in Warning High value with index-" & i + i)
                End If
                If newArrWH2(i) Then oldArrWH2(i) = True
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function ProcessAlarms() As Integer

        Dim Retval As Integer = 0
        Try

            ErrSL = MyPLC.GetTagValUint16("SuspLow1")
            Dim b As BitArray = New BitArray(BitConverter.GetBytes(ErrSL))
            b.CopyTo(newArrSL1, 0)

            ErrSL = MyPLC.GetTagValUint16("SuspLow2")
            b = New BitArray(BitConverter.GetBytes(ErrSL))
            b.CopyTo(newArrSL2, 0)

            ErrSH = MyPLC.GetTagValUint16("SuspHigh1")
            b = New BitArray(BitConverter.GetBytes(ErrSH))
            b.CopyTo(newArrSH1, 0)

            ErrSH = MyPLC.GetTagValUint16("SuspHigh2")
            b = New BitArray(BitConverter.GetBytes(ErrSH))
            b.CopyTo(newArrSH2, 0)

            newArrMisc(0) = MyPLC.GetTagVal("PnuematicPressure")
            newArrMisc(1) = MyPLC.GetTagVal("LubeLevel")
            newArrMisc(2) = MyPLC.GetTagVal("LubePressure")
            newArrMisc(3) = MyPLC.GetTagVal("LubeOilSwitch")
            newArrMisc(4) = MyPLC.GetTagVal("LubeOilTemp")
            newArrMisc(5) = MyPLC.GetTagVal("MotorTemp")
            newArrMisc(6) = MyPLC.GetTagVal("DriveStatus")
            newArrMisc(7) = MyPLC.GetTagVal("HeaterThermister")
            newArrMisc(8) = MyPLC.GetTagVal("MediaLevel")
            newArrMisc(9) = MyPLC.GetTagVal("MCBStatus")
            newArrMisc(10) = MyPLC.GetTagVal("BoosterEndofStroke")
            newArrMisc(11) = MyPLC.GetTagVal("BypassON")

            'Dim testBA As BitArray = New BitArray(newArrMisc)
            'Dim t(1) As UInt16
            'testBA.CopyTo(t, 0)
            'ErrMisc = t(0)


            Dim J As Integer
            J = 65
            For i = 0 To 15
                If oldArrSL1(i) <> newArrSL1(i) And newArrSL1(i) Then
                    LogAlarm(i + J)
                    Retval = i + J
                End If
                oldArrSL1(i) = newArrSL1(i)
                '' Application.DoEvents()
            Next

            J = 81
            For i = 0 To 15
                If oldArrSL2(i) <> newArrSL2(i) And newArrSL2(i) Then
                    LogAlarm(i + J)
                    Retval = i + J
                End If
                oldArrSL2(i) = newArrSL2(i)
                '' Application.DoEvents()
            Next

            J = 97
            For i = 0 To 15
                If oldArrSH1(i) <> newArrSH1(i) And newArrSH1(i) Then
                    LogAlarm(i + J)
                    Retval = i + J
                End If
                oldArrSH1(i) = newArrSH1(i)
                '' Application.DoEvents()
            Next

            J = 113
            For i = 0 To 15
                If oldArrSH2(i) <> newArrSH2(i) And newArrSH2(i) Then
                    LogAlarm(i + J)
                    Retval = i + J
                End If
                oldArrSH2(i) = newArrSH2(i)
                '' Application.DoEvents()
            Next

            J = 129
            For i = 0 To 15
                If oldArrMisc(i) <> newArrMisc(i) And newArrMisc(i) Then
                    LogAlarm(i + J)
                    Retval = i + J
                End If
                oldArrMisc(i) = newArrMisc(i)
                '' Application.DoEvents()
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If Retval <> 0 Then MyPLC.SetTagVal("AlarmNo", Retval)

        Return Retval
    End Function

    Sub LogAlarm(AlarmVal As Integer)
        Dim SQLConnection As New MySqlConnection(serv)
        Dim sqlCommand As New MySqlCommand()


        sqlCommand.CommandText = "INSERT INTO alarmlog (`AlarmID`, `LogTime`,  `ProjectIDTxt` ) values (@alid,@logtm,@prjt)"
        sqlCommand.CommandType = CommandType.Text
        sqlCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()

            sqlCommand.Parameters.AddWithValue("@alid", AlarmVal)
            sqlCommand.Parameters.AddWithValue("@logtm", Now)
            sqlCommand.Parameters.AddWithValue("@prjt", ProjectIDTxt)

            sqlCommand.ExecuteNonQuery()

            sqlCommand.Parameters.Clear()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message.ToString, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLConnection.Close()
        End Try
    End Sub

    Public Function AddReason(ReasonStr As String) As Integer
        Dim RetVal As Integer = 0

        Dim SQLConnection As New MySqlConnection(serv)
        Dim sqlCommand As New MySqlCommand()

        sqlCommand.CommandText = "INSERT INTO ReasonDB (`ReasonTxt`) values (@rsntxt); Select LAST_INSERT_ID() "
        sqlCommand.CommandType = CommandType.Text
        sqlCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()

            sqlCommand.Parameters.AddWithValue("@rsntxt", ReasonStr)

            RetVal = sqlCommand.ExecuteScalar

        Catch ex As MySqlException
            MessageBox.Show(ex.Message.ToString, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLConnection.Close()
        End Try

        Return RetVal

    End Function

    Function GetReason(ReasonID As Integer) As String
        Dim Retval As String = ""
        Dim constr As String = "SELECT * from reasondb where reasonid=" & ReasonID
        If GetDataMySQL(con, da, ds, dtreason, False, constr) Then
            If IsDBNull(dtreason.Rows(0).Item("ReasonTxt")) Then
                Retval = ""
            Else
                'Debug.Print("Project Status" & dt3.Rows(0).Item("ProjectStatus"))
                Retval = dtreason.Rows(0).Item("ReasonTxt")
            End If
        End If
        Return Retval
    End Function

    Protected Overrides Sub Finalize()
        If MyStatus = ProjectStatus.Run Or MyStatus = ProjectStatus.Load Then
            StopTest("Application Closed", 0)
        End If
        MyBase.Finalize()
    End Sub

    Private Sub DispUpTmr_Elapsed(sender As Object, e As EventArgs) Handles DispUpTmr.Elapsed
        DispUpTmr.Enabled = False
        UpdateGraphData()
        DispUpTmr.Enabled = True
    End Sub

    Private Sub LoadStopTimer_Elapsed(sender As Object, e As EventArgs) Handles LoadStopTimer.Elapsed
        LoadStopTimer.Enabled = False
        MyPLC.SetTagVal("Load", 0)
    End Sub


End Class


