Imports System.IO
Imports System.Text
Imports System.Threading
Imports MySql.Data.MySqlClient


Module commonfunc
    ' API call to prevent sleep (until the application exits)
    Private Declare Function SetThreadExecutionState Lib "kernel32" (ByVal esflags As EXECUTION_STATE) As EXECUTION_STATE

    Public Templatepath As String = "D:\Timken\project\LifeTestRig\Templates\"
    Public serv As String = "server = localhost; user id =root; password =Actemium#123; database =timken" 'global connection string variable
    Public CurrentRig As Integer = 1 'to identify current rig
    Public testno As Integer = 0
    Public Const BaseScanTime As Long = 250 '250ms

    Public Const NoOfGraphEntries As Integer = 1500

    Public Station As StnCls
    Public CurrentHead As HeadCls
    Public PairHead As HeadCls

    Public Class PLCStn
        Public Stn As ActUtlTypeLib.ActUtlType = New ActUtlTypeLib.ActUtlType
        Public IsStnAvailable As Boolean = False
        Public CheckComms As Boolean = True
        Public DataWord(700) As Integer
        Public MWord(50) As Integer
        Public TagLock As ReaderWriterLockSlim = New ReaderWriterLockSlim()
    End Class

    Public PLCStations As New List(Of PLCStn)
    'Public PLCStnTable As Hashtable
    'Public isPLCAvailable() As Boolean = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}

    Public MonitorAfter As Integer = 99

    Public TempProjectObj As New TempProject

    Public Enum ChildForms 'for identifying which form to diplay
        project
        profile
        limits
        scale
        PLC
        graph
        user
        alarm
        test
        bearing
        frmDefault
        report
    End Enum

    'Public Structure IntLimits
    '    Public Value As Integer
    '    Public WL As Integer
    '    Public WH As Integer
    '    Public SL As Integer
    '    Public SH As Integer
    '    Public LoadLimitRange As Integer 'in percentage + /- value during load
    '    Public Bypass As Boolean
    'End Structure

    Public Structure SingleLimits
        Public Value As Single
        Public WL As Single
        Public WH As Single
        Public SL As Single
        Public SH As Single
        Public Setpoint As Single 'in percentage + /- value during load
        Public Bypass As Boolean
        Public TagName As String
    End Structure

    Public TagExFrom As String
    Public TagExTo() As String

    Public SelectedHead As HeadCls ' Curernt head on which modifications will be done


    '***********************************************************************************************************
    '*Handles - Creates the Datatable or Dataset based on the parameter passed. Dataset consists of many tables
    '*
    '***********************************************************************************************************
    Public Function GetDataMySQL(ByRef con As MySqlConnection, ByRef adp As MySqlDataAdapter, ByRef ds As DataSet, ByRef dt As DataTable, isDataSet As Boolean, constr As String) As Boolean

        Dim iRet As Boolean
        Try
            If con.State = ConnectionState.Open Then con.Close()

            con.Open()

            adp = New MySqlDataAdapter(constr, con)
            If Not isDataSet Then
                dt = New DataTable
                adp.Fill(dt)
            Else
                ds = New DataSet
                adp.Fill(ds)
            End If

            con.Close()
            con.Dispose()
            iRet = True
        Catch ex As Exception
            MessageBox.Show("Database:error is:" & ex.Message, constr, MessageBoxButtons.OK, MessageBoxIcon.Error)
            iRet = False
        End Try
        GetDataMySQL = iRet
    End Function

    Public Function SearchAndAddToListWithFilter(ByVal path As String, ByVal filters As String(), ByVal searchSubFolders As Boolean) As List(Of IO.FileInfo)
        If Not IO.Directory.Exists(path) Then
            Throw New Exception("Path not found")
        End If

        Dim searchOptions As IO.SearchOption
        If searchSubFolders Then
            searchOptions = IO.SearchOption.AllDirectories
        Else
            searchOptions = IO.SearchOption.TopDirectoryOnly
        End If

        Return filters.SelectMany(Function(filter) New IO.DirectoryInfo(path).GetFiles(filter, searchOptions)).ToList
    End Function


    Public Sub BackgroundWorkerProcess(Comms As CommunicationCls, MachineNo As Integer, ByRef Scanticks As Integer)

        'Scanticks += 1
        ''250ms process starts here

        'If MachineNo = 1 Then Comms.PLC1.Scan250ms()
        'If MachineNo = 2 Then Comms.PLC2.Scan250ms()
        'If MachineNo = 3 Then Comms.PLC3.Scan250ms()
        'If MachineNo = 4 Then Comms.PLC4.Scan250ms()

        ''end of 250ms process

        'If Scanticks Mod 2 = 0 Then '500ms process
        '    If MachineNo = 1 Then Comms.PLC1.Scan500ms()
        '    If MachineNo = 2 Then Comms.PLC2.Scan500ms()
        '    If MachineNo = 3 Then Comms.PLC3.Scan500ms()
        '    If MachineNo = 4 Then Comms.PLC4.Scan500ms()
        'End If

        'If Scanticks Mod 4 = 0 Then '1s Process
        '    If MachineNo = 1 Then Comms.PLC1.Scan1s()
        '    If MachineNo = 2 Then Comms.PLC2.Scan1s()
        '    If MachineNo = 3 Then Comms.PLC3.Scan1s()
        '    If MachineNo = 4 Then Comms.PLC4.Scan1s()
        'End If

        'If Scanticks Mod 40 = 0 Then '10s process
        '    If MachineNo = 1 Then Comms.PLC1.Scan10s()
        '    If MachineNo = 2 Then Comms.PLC2.Scan10s()
        '    If MachineNo = 3 Then Comms.PLC3.Scan10s()
        '    If MachineNo = 4 Then Comms.PLC4.Scan10s()
        'End If

        'If Scanticks > 40 Then Scanticks = 0 'reset ticks

    End Sub

    Public Sub WriteDataTable(ByVal sourceTable As DataTable, filepath As String, ByVal includeHeaders As Boolean)
        Try
            Dim writer As New StreamWriter(filepath)
            If (includeHeaders) Then
                Dim headerValues As IEnumerable(Of String) = sourceTable.Columns.OfType(Of DataColumn).Select(Function(column) QuoteValue(column.ColumnName))
                ' Dim headerValues As IEnumerable(Of String) = sourceTable.Columns.OfType(Of DataColumn).Select(Function(column) column.ColumnName)

                writer.WriteLine(String.Join(",", headerValues))
            End If

            Dim items1 As IEnumerable(Of String) = Nothing
            For Each row As DataRow In sourceTable.Rows
                '               items1 = row.ItemArray.Select(Function(obj) QuoteValue(If(obj?.ToString(), String.Empty)))
                items1 = row.ItemArray.Select(Function(obj) (If(obj?.ToString(), String.Empty)))
                writer.WriteLine(String.Join(",", items1))
            Next

            writer.Flush()
            writer.Close()
            writer.Dispose()
        Catch ex As Exception
            MessageBox.Show("Report " & ex.ToString, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Function QuoteValue(ByVal value As String) As String
        Return String.Concat("""", value.Replace("""", """"""), """")
    End Function

    Public Sub LoadtoGrid(Grid As DataGridView, filepath As String, HeaderReqd As Boolean)
        Dim TextFieldParser1 As New Microsoft.VisualBasic.FileIO.TextFieldParser(filepath)

        TextFieldParser1.Delimiters = New String() {","}
        Grid.Rows.Clear()
        Grid.Columns.Clear()

        While Not TextFieldParser1.EndOfData
            Dim Row1 As String() = TextFieldParser1.ReadFields()


            If Grid.Columns.Count = 0 AndAlso Row1.Count > 0 Then
                Dim i As Integer

                For i = 0 To Row1.Count - 1
                    If HeaderReqd Then Grid.Columns.Add("Column" & i + 1, Row1(i)) Else Grid.Columns.Add("Column" & i + 1, "")
                Next
                If HeaderReqd Then Continue While
            End If

            Grid.Rows.Add(Row1)

        End While
        TextFieldParser1.Close()
        TextFieldParser1 = Nothing
    End Sub

    'Allow only Numbers 
    Public Sub event_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

    Public Sub AllowOnlyNumbers(frm As Form)
        Dim textboxes = GetAllControls(frm).OfType(Of TextBox)().ToList()
        For Each item As TextBox In textboxes
            AddHandler item.KeyPress, AddressOf event_KeyPress
        Next
    End Sub

    Public Function GetAllControls(control As Control) As IEnumerable(Of Control)
        Dim controls = control.Controls.Cast(Of Control)()
        Return controls.SelectMany(Function(ctrl) GetAllControls(ctrl)).Concat(controls)
    End Function


    ' Define the API execution states
    Public Enum EXECUTION_STATE
        ' Stay in working state by resetting display idle timer
        ES_SYSTEM_REQUIRED = &H1
        ' Force display on by resetting system idle timer
        ES_DISPLAY_REQUIRED = &H2
        ' Force this state until next ES_CONTINUOUS call
        ' and one of the other flags are cleared
        ES_CONTINUOUS = &H80000000
    End Enum


    ' Call API - force no sleep and no display turn off
    Public Function No_Sleep() As EXECUTION_STATE
        Return SetThreadExecutionState(EXECUTION_STATE.ES_SYSTEM_REQUIRED Or
               EXECUTION_STATE.ES_CONTINUOUS Or EXECUTION_STATE.ES_DISPLAY_REQUIRED)
    End Function


End Module
