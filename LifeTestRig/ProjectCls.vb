Imports MySql.Data.MySqlClient
Imports System.Threading
Imports System.Timers
Public Class ProjectCls

    Dim con As MySqlConnection = New MySqlConnection(serv)
    Dim da, daPrj, daParam, daLoad As MySqlDataAdapter

    Dim ds As DataSet

    Public dsGraphs As DataSet
    Public dtVibration, dtSpeed, dtLoadDisp, dtBearing, dtOilTemp As DataTable

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
    End Enum

    Dim mLocked As Boolean = True
    Dim PleaseStop As Boolean = False

    Public MachineName As String
    Public HeadName As String

    Public ProjectID As String
    Public ProjectIDTxt As String
    Public ProjectOwner As String
    Public ProjectName As String
    Public BearingCount As Integer
    Public BearingType As String
    Public MachineSize As Integer
    Public CupNo As String
    Public ConeNo As String
    Public PVNo As String
    Public TestType As String
    Public B1Name As Integer
    Public B2Name As Integer
    Public B3Name As Integer
    Public B4Name As Integer


    Friend Vibration As SingleLimits
    Friend OutTankTemp As SingleLimits
    Friend InTankTemp As SingleLimits
    Friend Load As SingleLimits
    Friend Speed As SingleLimits
    Public MaxRev As Double
    Public MaxRevActive As Boolean



    Public RunLogRate As TimeSpan
    Public LoadLogRate As TimeSpan
    Public DispUpdateRate As TimeSpan


    Friend B1, B2, B3, B4 As SingleLimits

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
    Dim oldArrSL(16) As Boolean
    Dim newArrSL(16) As Boolean

    Dim oldArrSH(16) As Boolean
    Dim newArrSH(16) As Boolean

    Dim oldArrWL(16) As Boolean
    Dim newArrWL(16) As Boolean

    Dim oldArrWH(16) As Boolean
    Dim newArrWH(16) As Boolean

    Dim oldArrMisc(16) As Boolean
    Dim newArrMisc(16) As Boolean

    Dim ErrSL, ErrSH, ErrMisc As UInt16

    Public Sub New(MacName As String, Head As String, PLC As PLCCls)
        MachineName = MacName
        HeadName = Head
        MyPLC = PLC
        Init()
    End Sub

    Public Sub Init()
        'Clear all values

        IsPairBonded = False

        ProjectID = 0
        ProjectIDTxt = ""
        ProjectOwner = ""
        ProjectName = ""
        BearingCount = 0
        BearingType = ""
        MachineSize = CInt(Left(MachineName, 1))
        CupNo = ""
        ConeNo = ""
        PVNo = ""
        TestType = ""
        B1Name = 0
        B2Name = 0
        B3Name = 0
        B4Name = 0


        Vibration.Value = 0
        Vibration.SL = 0
        Vibration.SH = 0
        Vibration.WH = 0
        Vibration.WL = 0
        Vibration.Bypass = False
        Vibration.TagName = "Vibration" & HeadName

        OutTankTemp.Value = 0
        OutTankTemp.SL = 0
        OutTankTemp.SH = 0
        OutTankTemp.WL = 0
        OutTankTemp.WH = 0
        OutTankTemp.Bypass = False
        OutTankTemp.TagName = "OutTankTemp"


        InTankTemp.Value = 0
        InTankTemp.SL = 0
        InTankTemp.SH = 0
        InTankTemp.WL = 0
        InTankTemp.WH = 0
        InTankTemp.Bypass = False
        InTankTemp.TagName = "InTankTemp"

        Load.Value = 0
        Load.WH = 0
        Load.WL = 0
        Load.SH = 0
        Load.SL = 0
        Load.Bypass = False
        Load.TagName = "Load" & HeadName

        Speed.Value = 0
        Speed.WH = 0
        Speed.WL = 0
        Speed.SH = 0
        Speed.SL = 0
        Speed.Bypass = False
        Speed.TagName = "Speed"

        MaxRev = 0
        MaxRevActive = False


        RunLogRate = TimeSpan.Parse("00:00:00")
        LoadLogRate = TimeSpan.Parse("00:00:00")
        DispUpdateRate = TimeSpan.Parse("00:00:00")

        CreatedDate = #1/1/0001 12:00:00 AM#
        TerminatedDate = #1/1/0001 12:00:00 AM#

        B1.Value = 0
        B1.WH = 0
        B1.WL = 0
        B1.SL = 0
        B1.SH = 0
        B1.Bypass = False
        B1.TagName = "B1Temp" & HeadName

        B2.Value = 0
        B2.WH = 0
        B2.WL = 0
        B2.SL = 0
        B2.SH = 0
        B2.Bypass = False
        B2.TagName = "B2Temp" & HeadName

        B3.Value = 0
        B3.WH = 0
        B3.WL = 0
        B3.SL = 0
        B3.SH = 0
        B3.Bypass = False
        B3.TagName = "B3Temp" & HeadName

        B4.Value = 0
        B4.WH = 0
        B4.WL = 0
        B4.SL = 0
        B4.SH = 0
        B4.Bypass = False
        B4.TagName = "B4Temp" & HeadName

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
        MyPLC.SetTagVal("MonitorLimits" & HeadName, 0)
        MyPLC.SetTagVal("MonitorLoad" & HeadName, 0)
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

        Dim CanStart As Boolean = MyPLC.GetTagVal("StationReady")

        Dim constr As String = "SELECT * from  LoadSteps  where ProjectID=" & ProjectID & " Order by idLoadSteps"

        If GetDataMySQL(con, daLoad, ds, dtLoad, False, constr) Then

            If dtLoad.Rows.Count = 0 Then

                If CanStart Then

                    If CreatedDate = #1/1/0001 12:00:00 AM# Then
                        CreatedDate = Now()
                    End If

                    StartRuntime = Now
                    CurrStepNo = -1 'Start from the beginning of steps
                    LoadSecRem = 0
                    RunSecRem = 0

                    CurrMonActive = False
                    PrevMonActive = False


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

                    Array.Clear(oldArrSL, 0, oldArrSL.Length)
                    Array.Clear(newArrSL, 0, newArrSL.Length)

                    Array.Clear(oldArrSH, 0, oldArrSH.Length)
                    Array.Clear(newArrSH, 0, newArrSH.Length)

                    Array.Clear(oldArrWL, 0, oldArrWL.Length)
                    Array.Clear(newArrWL, 0, newArrWL.Length)

                    Array.Clear(oldArrWH, 0, oldArrWH.Length)
                    Array.Clear(newArrWH, 0, newArrWH.Length)

                    Array.Clear(oldArrMisc, 0, oldArrMisc.Length)
                    Array.Clear(newArrMisc, 0, newArrMisc.Length)

                Else
                    MessageBox.Show("Station Not Ready", "Start Station", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Tmr.Stop()
                    retval = False
                    MyStatus = ProjectStatus.Suspended
                End If

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
        MyPLC.SetTagVal("MonitorLimits" & HeadName, 0)

        '' UpdateProject()
        Return retval
        Debug.Print("Starting - Head " & HeadName)

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
            ReasonID = AddReason(GetReason(OtherHeadAlarmVal) & If(HeadName = "A", " in Head B", " in Head A"))
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

        MyPLC.SetTagVal("MonitorLimits" & HeadName, 0)
        MyPLC.SetTagVal("MonitorLoad" & HeadName, 0)
        Debug.Print("Stopped Now" & ReasonID & " " & AlarmNo & " HEadName - " & HeadName)
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


        MyPLC.SetTagVal("MonitorLimits" & HeadName, 0)
        MyPLC.SetTagVal("MonitorLoad" & HeadName, 0)

        'PleaseStop = True
    End Sub

#Region "DatabaseFunctions"

    Public Sub Save()

        If Not isNew Then
            UpdateProject()
            UpdateParameters()
            If MyStatus = ProjectStatus.Run Or MyStatus = ProjectStatus.Load Then Update_Timers_PLCWithParam() 'If the projet is running then update limits

        Else

            If NewProject() Then
                LoadProject() 'Load them again!
                NewParameters()
                NewLoadSet()
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
            ProjectName = dt1.Rows(0).Item("ProjectName")
            BearingCount = dt1.Rows(0).Item("BearingCount")
            BearingType = dt1.Rows(0).Item("BearingType")
            MachineSize = dt1.Rows(0).Item("MachineSize")
            CupNo = dt1.Rows(0).Item("CupNo")
            ConeNo = dt1.Rows(0).Item("ConeNo")
            PVNo = dt1.Rows(0).Item("PVNo")
            TestType = dt1.Rows(0).Item("TestType")

            B1Name = dt1.Rows(0).Item("B1Name")
            B2Name = dt1.Rows(0).Item("B2Name")
            B3Name = dt1.Rows(0).Item("B3Name")
            B4Name = dt1.Rows(0).Item("B4Name")

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

    Public Function CheckforExistingPrj(ProjectTxt As String, B1No As String, B2No As String, B3No As String, B4No As String) As Boolean
        Dim retval As Boolean = False
        Dim constr As String = "SELECT * from Project where ProjectIDtxt='" & ProjectTxt & "' and (( B1Name='" & B1No & "' or B2Name='" & B1No & "' or B3Name='" & B1No & "' or B4Name='" & B1No & "' )" &
            " or ( B1Name='" & B2No & "' or B2Name='" & B2No & "' or B3Name='" & B2No & "' or B4Name='" & B2No & "' )" &
            " or ( B1Name='" & B3No & "' or B2Name='" & B3No & "' or B3Name='" & B3No & "' or B4Name='" & B3No & "' )" &
            " or ( B1Name='" & B4No & "' or B2Name='" & B4No & "' or B3Name='" & B4No & "' or B4Name='" & B4No & "' ))"

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


        'create a new record
        Using SQLConnection As New MySqlConnection(serv)
            Using sqlCommand As New MySqlCommand()
                With sqlCommand
                    .CommandText = "INSERT INTO Project (`ProjectIDTxt`, `Owner`, `ProjectName`, `BearingCount`, `BearingType`, `MachineSize`, `CupNo`, `ConeNo`, `PVNo`, `TestType`, `B1Name`, `B2Name`, `B3Name`, `B4Name`,`MaxRev`, `MaxRevActive`, `RunLogRate`,`LoadLogRate`, `DispUpdateRate`,`NoOFBearings`,`LoadDurationRemaining`, `RunDurationRemaining`, `CurrentStep`, `CurrLoad`,  `CurrRev`,  `CreatedDate`, `TerminatedDate`, `ProjectStatus`,  `MachineName`, `HeadName` ) values (@pid,@owner,@prjname,@bc,@bt,@ms,@cup, @cone,@pv,@tt,@b1n,@b2n,@b3n,@b4n,@maxr,@maxract,@runlrt,@loadlrt,@duprt,@nobr,@ldrm,@rdrm,@curstp,@curld,@crrev,@crdt,@trmDt,@prjsts,@mcnm,@hdnm);" &
                        " Select LAST_INSERT_ID()"
                    .Connection = SQLConnection
                    .CommandType = CommandType.Text

                    .Parameters.AddWithValue("@pid", ProjectIDTxt)
                    .Parameters.AddWithValue("@owner", ProjectOwner)
                    .Parameters.AddWithValue("@prjname", ProjectName)
                    .Parameters.AddWithValue("@bc", BearingCount)
                    .Parameters.AddWithValue("@bt", BearingType)
                    .Parameters.AddWithValue("@ms", MachineSize)
                    .Parameters.AddWithValue("@cup", CupNo)
                    .Parameters.AddWithValue("@cone", ConeNo)
                    .Parameters.AddWithValue("@pv", PVNo)
                    .Parameters.AddWithValue("@tt", TestType)
                    .Parameters.AddWithValue("@b1n", B1Name)
                    .Parameters.AddWithValue("@b2n", B2Name)
                    .Parameters.AddWithValue("@b3n", B3Name)
                    .Parameters.AddWithValue("@b4n", B4Name)
                    .Parameters.AddWithValue("@maxr", MaxRev)
                    .Parameters.AddWithValue("@maxract", MaxRevActive)
                    .Parameters.AddWithValue("@runlrt", RunLogRate)
                    .Parameters.AddWithValue("@loadlrt", LoadLogRate)
                    .Parameters.AddWithValue("@duprt", DispUpdateRate)
                    .Parameters.AddWithValue("@nobr", 0)
                    .Parameters.AddWithValue("@ldrm", 0)
                    .Parameters.AddWithValue("@rdrm", 0)
                    .Parameters.AddWithValue("@curstp", -1) 'Fresh Start
                    .Parameters.AddWithValue("@curld", CurrentLoad)
                    .Parameters.AddWithValue("@crrev", CurrRev)
                    .Parameters.AddWithValue("@crdt", Now())
                    .Parameters.AddWithValue("@trmDt", TerminatedDate)
                    .Parameters.AddWithValue("@prjsts", ProjectStatus.Idle)
                    .Parameters.AddWithValue("@mcnm", MachineName)
                    .Parameters.AddWithValue("@hdnm", HeadName)

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
                dt1.Rows(0).Item("ProjectName") = ProjectName
                dt1.Rows(0).Item("BearingCount") = BearingCount
                dt1.Rows(0).Item("BearingType") = BearingType
                dt1.Rows(0).Item("MachineSize") = MachineSize
                dt1.Rows(0).Item("CupNo") = CupNo
                dt1.Rows(0).Item("ConeNo") = ConeNo
                dt1.Rows(0).Item("PVNo") = PVNo
                dt1.Rows(0).Item("TestType") = TestType

                dt1.Rows(0).Item("B1Name") = B1Name
                dt1.Rows(0).Item("B2Name") = B2Name
                dt1.Rows(0).Item("B3Name") = B3Name
                dt1.Rows(0).Item("B4Name") = B4Name

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

                dt1.Rows(0).Item("MachineName") = MachineName
                dt1.Rows(0).Item("HeadName") = HeadName

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

        Dim vals(9) As SingleLimits
        Dim i As Integer
        Dim constr As String = "SELECT * from parameters where ProjectID=" & ProjectID & " Order by ParameterID"
        If GetDataMySQL(con, daParam, ds, dt2, False, constr) Then

            If dt2.Rows.Count = 9 Then
                For i = 0 To 8
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


            Vibration = vals(0)
            OutTankTemp = vals(1)
            InTankTemp = vals(2)
            Load = vals(3)
            Speed = vals(4)

            B1 = vals(5)
            B2 = vals(6)
            B3 = vals(7)
            B4 = vals(8)

            Vibration.TagName = "Vibration" & HeadName
            OutTankTemp.TagName = "OutTankTemp"
            InTankTemp.TagName = "InTankTemp"
            Load.TagName = "Load" & HeadName
            Speed.TagName = "Speed"
            B1.TagName = "B1Temp" & HeadName
            B2.TagName = "B2Temp" & HeadName
            B3.TagName = "B3Temp" & HeadName
            B4.TagName = "B4Temp" & HeadName

        End If
    End Sub

    Sub NewParameters()
        'create a new records
        Dim i As Integer
        Dim vals(9) As SingleLimits
        vals(0) = Vibration
        vals(1) = OutTankTemp
        vals(2) = InTankTemp
        vals(3) = Load
        vals(4) = Speed

        vals(5) = B1
        vals(6) = B2
        vals(7) = B3
        vals(8) = B4


        Dim SQLConnection As New MySqlConnection(serv)
        Dim sqlCommand As New MySqlCommand()

        sqlCommand.CommandText = "INSERT INTO Parameters (`ProjectID`, `ParameterID`, `WH`, `WL`, `SH`, `SL`, `Value`, `Setpoint`, `Bypass` ) values (@pid,@paramID,@wh,@wl,@sh,@sl,@val, @sp,@byp)"
        sqlCommand.CommandType = CommandType.Text
        sqlCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()
            For i = 0 To 8
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
        Dim vals(9) As SingleLimits
        Dim MyRow As DataRow
        vals(0) = Vibration
        vals(1) = OutTankTemp
        vals(2) = InTankTemp
        vals(3) = Load
        vals(4) = Speed

        vals(5) = B1
        vals(6) = B2
        vals(7) = B3
        vals(8) = B4

        Dim constr As String = "SELECT * from parameters where ProjectID=" & ProjectID & " Order by ParameterID"
        If GetDataMySQL(con, daParam, ds, dt2, False, constr) Then
            Try
                Dim RowCount = dt2.Rows.Count
                For i = 0 To 8
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

#End Region 'end of database functions

    Private Sub CheckForLoadRunCompletion()

        Dim sw As Stopwatch = New Stopwatch

        Tmr.Enabled = False



        Dim str As String = MachineName

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
                If HeadName = "A" Then OtherHeadAlarmVal = MyPLC.GetTagVal("AlarmNoB") Else OtherHeadAlarmVal = MyPLC.GetTagVal("AlarmNoA")
            End If

            Debug.Print("Stopping Due to Alarm" & MachineName & "" & HeadName & "" & AlarmNo)
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
            MyPLC.SetTagVal("MonitorLimits" & HeadName, 1)
            DispUpTmr.Enabled = True
            PrevMonActive = CurrMonActive
        End If

        'Dim constr As String = "SELECT * from  LoadSteps  where ProjectID=" & ProjectID & " Order by idLoadSteps"

        If Not IsPairBonded Or (IsPairBonded And HeadName = "A") Then
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
            Else
            CurrentLoad = MyPLC.GetTagVal("Load")
        End If

        If HeadName = "A" Then MyPLC.SetTagVal("Head1Status", MyStatus)
        If IsPairBonded And HeadName = "B" Then MyStatus = MyPLC.GetTagValUint16("Head1Status")

        If MyStatus = ProjectStatus.Load Then
            LoadTmr.Start()
            RunTmr.Stop()
        End If

        If MyStatus = ProjectStatus.Load Then MyPLC.SetTagVal("MonitorLoad" & HeadName, 1) Else MyPLC.SetTagVal("MonitorLoad" & HeadName, 0)

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

    Private Sub Tmr_Elapsed(sender As Object, e As EventArgs) Handles Tmr.Elapsed
        CheckForLoadRunCompletion()
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

        sqlCommand.CommandText = "INSERT INTO datalogs (`Status`,`StopReason`, `BearingTemp1`, `BearingTemp2`, `BearingTemp3`, `BearingTemp4`, `LubOilTemp`, `TankOilTemp`, `Vibration`, `Speed`, `Load1`, `Revolutions`, `NoOfHours`, `ProjectID`, `HeadName`, `MachineName` ) values (@sta,@stpRsn,@b1,@b2,@b3,@b4,@luboil,@tnkOil,@vib,@spd,@ld,@rev,@nohr,@pid,@hn,@mcnm)"
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
            sqlCommand.Parameters.AddWithValue("@b1", B1.Value)
            sqlCommand.Parameters.AddWithValue("@b2", B2.Value)
            sqlCommand.Parameters.AddWithValue("@b3", B3.Value)
            sqlCommand.Parameters.AddWithValue("@b4", B4.Value)
            sqlCommand.Parameters.AddWithValue("@luboil", InTankTemp.Value)
            sqlCommand.Parameters.AddWithValue("@tnkOil", OutTankTemp.Value)
            sqlCommand.Parameters.AddWithValue("@vib", Vibration.Value)
            sqlCommand.Parameters.AddWithValue("@spd", Speed.Value)
            sqlCommand.Parameters.AddWithValue("@ld", Load.Value)
            sqlCommand.Parameters.AddWithValue("@rev", Rev)
            sqlCommand.Parameters.AddWithValue("@nohr", CurrentLife)
            sqlCommand.Parameters.AddWithValue("@pid", ProjectID)
            sqlCommand.Parameters.AddWithValue("@hn", HeadName)
            sqlCommand.Parameters.AddWithValue("@mcnm", MachineName)

            sqlCommand.ExecuteNonQuery()

            ''     sqlCommand.Parameters.Clear()
            'Debug.Print("CurrRev in logs " & Rev)


        Catch ex As MySqlException
            MessageBox.Show(ex.Message.ToString, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLConnection.Close()
        End Try
    End Sub

    Public Sub LogUtilities(Status As ProjectStatus, ReasonID As Integer)
        Dim SQLConnection As New MySqlConnection(serv)
        Dim sqlCommand As New MySqlCommand()

        sqlCommand.CommandText = "INSERT INTO utility (`Machine`, `Head`, `ProjectIDTxt`, `Operation`, `ReasonID`,`B1Name`,`B2Name`,`B3Name`,`B4Name` ) values (@mc,@hd,@pid,@oper,@reasn,@b1,@b2,@b3,@b4)"
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

            sqlCommand.Parameters.AddWithValue("@mc", MachineName)
            sqlCommand.Parameters.AddWithValue("@hd", HeadName)
            sqlCommand.Parameters.AddWithValue("@pid", ProjectIDTxt)
            sqlCommand.Parameters.AddWithValue("@oper", StatusTxt)
            sqlCommand.Parameters.AddWithValue("@reasn", ReasonID)
            sqlCommand.Parameters.AddWithValue("@b1", B1Name)
            sqlCommand.Parameters.AddWithValue("@b2", B2Name)
            sqlCommand.Parameters.AddWithValue("@b3", B3Name)
            sqlCommand.Parameters.AddWithValue("@b4", B4Name)

            sqlCommand.ExecuteNonQuery()

            sqlCommand.Parameters.Clear()



        Catch ex As MySqlException
            MessageBox.Show(ex.Message.ToString, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLConnection.Close()
        End Try
    End Sub

    Sub CreateGraphDataTables()
        dsGraphs = New DataSet()

        dtVibration = dsGraphs.Tables.Add("Vibration")
        dtVibration.Columns.Add("MinVal", GetType(Single))
        dtVibration.Columns.Add("MaxVal", GetType(Single))
        dtVibration.Columns.Add("Vibration", GetType(Single))

        dtSpeed = dsGraphs.Tables.Add("Speed")
        dtSpeed.Columns.Add("MinVal", GetType(Single))
        dtSpeed.Columns.Add("MaxVal", GetType(Single))
        dtSpeed.Columns.Add("Speed", GetType(Single))

        dtLoadDisp = dsGraphs.Tables.Add("Load")
        dtLoadDisp.Columns.Add("MinVal", GetType(Single))
        dtLoadDisp.Columns.Add("MaxVal", GetType(Single))
        dtLoadDisp.Columns.Add("Load", GetType(Single))

        dtBearing = dsGraphs.Tables.Add("Bearings")
        dtBearing.Columns.Add("MinVal", GetType(Single))
        dtBearing.Columns.Add("MaxVal", GetType(Single))
        dtBearing.Columns.Add("B1", GetType(Single))
        dtBearing.Columns.Add("B2", GetType(Single))
        dtBearing.Columns.Add("B3", GetType(Single))
        dtBearing.Columns.Add("B4", GetType(Single))

        dtOilTemp = dsGraphs.Tables.Add("OilTemp")
        dtOilTemp.Columns.Add("MinVal", GetType(Single))
        dtOilTemp.Columns.Add("MaxVal", GetType(Single))
        dtOilTemp.Columns.Add("LubOil", GetType(Single))
        dtOilTemp.Columns.Add("TankOil", GetType(Single))

    End Sub

    Sub UpdateGraphData()

        'If MyPLC.GetTagVal("MonitorLimits" & HeadName) = 0 Then Exit Sub

        UpdateTagData()

        DataUpdateLock.EnterWriteLock()

        If dtVibration.Rows.Count > NoOfGraphEntries Then dtVibration.Rows(0).Delete()
        dtVibration.Rows.Add(Vibration.SL, Vibration.SH, Vibration.Value)

        If dtSpeed.Rows.Count > NoOfGraphEntries Then dtSpeed.Rows(0).Delete()
        dtSpeed.Rows.Add(Speed.SL, Speed.SH, Speed.Value)

        If dtLoadDisp.Rows.Count > NoOfGraphEntries Then dtLoadDisp.Rows(0).Delete()
        dtLoadDisp.Rows.Add(Load.SL, Load.SH, Load.Value)

        If dtBearing.Rows.Count > NoOfGraphEntries Then dtBearing.Rows(0).Delete()
        dtBearing.Rows.Add(B1.SL, B1.SH, B1.Value, B2.Value, B3.Value, B4.Value)

        If dtOilTemp.Rows.Count > NoOfGraphEntries Then dtOilTemp.Rows(0).Delete()
        dtOilTemp.Rows.Add(OutTankTemp.SL, OutTankTemp.SH, InTankTemp.Value, OutTankTemp.Value)

        DataUpdateLock.ExitWriteLock()

    End Sub

    Sub UpdateTagData()
        'Update Tag Data
        B1.Value = MyPLC.GetTagVal("B1Temp" & HeadName & "_ActVal")
        B2.Value = MyPLC.GetTagVal("B2Temp" & HeadName & "_ActVal")
        B3.Value = MyPLC.GetTagVal("B3Temp" & HeadName & "_ActVal")
        B4.Value = MyPLC.GetTagVal("B4Temp" & HeadName & "_ActVal")
        B1.Value = MyPLC.GetTagVal("B1Temp" & HeadName & "_ActVal")
        Vibration.Value = MyPLC.GetTagVal("Vibration" & HeadName & "_ActVal")
        InTankTemp.Value = MyPLC.GetTagVal("InTankTemp_ActVal")
        OutTankTemp.Value = MyPLC.GetTagVal("OutTankTemp_ActVal")
        Speed.Value = MyPLC.GetTagVal("Speed_ActVal")
        Load.Value = MyPLC.GetTagVal("Load" & HeadName & "_ActVal")
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
        Dim vals(9) As SingleLimits
        vals(0) = Vibration
        vals(1) = OutTankTemp
        vals(2) = InTankTemp
        vals(3) = Load
        vals(4) = Speed

        vals(5) = B1
        vals(6) = B2
        vals(7) = B3
        vals(8) = B4


        Try
            For i = 0 To 8
                '  MyPLC.SetTagVal(vals(i).TagName & "_Actval", vals(i).Value)
                MyPLC.SetTagVal(vals(i).TagName & "_WH", vals(i).WH)
                MyPLC.SetTagVal(vals(i).TagName & "_WL", vals(i).WL)
                MyPLC.SetTagVal(vals(i).TagName & "_SH", vals(i).SH)
                MyPLC.SetTagVal(vals(i).TagName & "_SL", vals(i).SL)
                MyPLC.SetTagVal(vals(i).TagName & "_Byp", vals(i).Bypass)

            Next i

            If (Not IsPairBonded) Or (IsPairBonded And HeadName = "A") Then
                MyPLC.SetTagVal("SpeedSP", Speed.Setpoint)
                MyPLC.SetTagVal("LubOilTempSP", InTankTemp.Setpoint)
            End If

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
            Dim value As UInt16 = MyPLC.GetTagValUint16("WarnLow" & HeadName)
            Dim b As BitArray = New BitArray(BitConverter.GetBytes(value))
            b.CopyTo(newArrWL, 0)

            value = MyPLC.GetTagValUint16("WarnHigh" & HeadName)
            b = New BitArray(BitConverter.GetBytes(value))
            b.CopyTo(newArrWH, 0)

            Dim J As Integer = 1
            For i = 0 To 15
                If Not oldArrWL(i) And newArrWL(i) Then
                    LogAlarm(i + J)
                End If
                oldArrWL(i) = newArrWL(i)
                Application.DoEvents()
            Next

            J = 17
            For i = 0 To 15
                If Not oldArrWH(i) And newArrWH(i) Then
                    LogAlarm(i + J)
                End If
                oldArrWH(i) = newArrWH(i)
                Application.DoEvents()
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function ProcessAlarms() As Integer

        Dim Retval As Integer = 0
        Try

            ErrSL = MyPLC.GetTagValUint16("SuspLow" & HeadName)
            Dim b As BitArray = New BitArray(BitConverter.GetBytes(ErrSL))
            b.CopyTo(newArrSL, 0)

            ErrSH = MyPLC.GetTagValUint16("SuspHigh" & HeadName)
            b = New BitArray(BitConverter.GetBytes(ErrSH))
            b.CopyTo(newArrSH, 0)

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
            J = 33
            For i = 0 To 15
                If Not oldArrSL(i) And newArrSL(i) Then
                    LogAlarm(i + J)
                    Retval = i + J
                End If
                oldArrSL(i) = newArrSL(i)
                '' Application.DoEvents()
            Next

            J = 49
            For i = 0 To 15
                If Not oldArrSH(i) And newArrSH(i) Then
                    LogAlarm(i + J)
                    Retval = i + J
                End If
                oldArrSH(i) = newArrSH(i)
                '' Application.DoEvents()
            Next

            J = 65
            For i = 0 To 15
                If Not oldArrMisc(i) And newArrMisc(i) Then
                    LogAlarm(i + J)
                    Retval = i + J
                End If
                oldArrMisc(i) = newArrMisc(i)
                '' Application.DoEvents()
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If Retval <> 0 Then MyPLC.SetTagVal("AlarmNo" & HeadName, Retval)

        Return Retval
    End Function

    Sub LogAlarm(AlarmVal As Integer)
        Dim SQLConnection As New MySqlConnection(serv)
        Dim sqlCommand As New MySqlCommand()


        sqlCommand.CommandText = "INSERT INTO alarmlog (`AlarmID`, `LogTime`, `HeadName`, `MachineName`, `ProjectIDTxt` ) values (@alid,@logtm,@hn,@mn,@prjt)"
        sqlCommand.CommandType = CommandType.Text
        sqlCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()

            sqlCommand.Parameters.AddWithValue("@alid", AlarmVal)
            sqlCommand.Parameters.AddWithValue("@logtm", Now)
            sqlCommand.Parameters.AddWithValue("@hn", HeadName)
            sqlCommand.Parameters.AddWithValue("@mn", MachineName)
            sqlCommand.Parameters.AddWithValue("@prjt", ProjectIDTxt & "_" & B1Name & "_" & B2Name & "_" & B3Name & "_" & B4Name)

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
        MyPLC.SetTagVal("Load", 0)
    End Sub


End Class


