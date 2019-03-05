'***********************************************************************************************************
'*Handles - PLC Communication, status, variables, IP address etc, May be derived Class from mxworks or modbus
'*
'***********************************************************************************************************
Imports System.IO
Imports System.Threading
Imports System.Timers
Imports System.ComponentModel.BackgroundWorker
Imports System.ComponentModel

Public Class PLCCls


    Public mMachineName As String
    Dim mHeadName As String
    Dim mMachineNo As Integer

    Dim LifeBit As Boolean = True

    Private Structure PLCTag
        Public WriteValue As Single
        Public ReadValue As Single
        Public Address As String
        Public StationNo As String
        Public Type As Integer
    End Structure



    Dim PLCVariables As Hashtable = New Hashtable()
    ' Dim PLCVariablesW As Hashtable = New Hashtable()

    'Dim PLCVariables250msR As Hashtable = New Hashtable()
    'Dim PLCVariables250msW As Hashtable = New Hashtable()
    'Dim PLCVariables500msR As Hashtable = New Hashtable()
    'Dim PLCVariables500msW As Hashtable = New Hashtable()
    'Dim PLCVariables1sR As Hashtable = New Hashtable()
    'Dim PLCVariables1sW As Hashtable = New Hashtable()
    'Dim PLCVariables10sR As Hashtable = New Hashtable()
    'Dim PLCVariables10sW As Hashtable = New Hashtable()
    'Dim temphashTable As Hashtable = New Hashtable 'to check duplicate entries


    Dim WithEvents TagExTmr As New System.Timers.Timer
    Dim WithEvents TagsReadTmr As New System.Timers.Timer

    Dim WithEvents bg As New System.ComponentModel.BackgroundWorker

    Public RunLogRatemSec As Integer = 20000 '20 sec
    Public DispLogRatemSec As Integer = 2000 '2 sec
    Public LoadLogRatemSec As Integer = 10000 '10 sec
    Public MonitorRatemSec As Integer = 500 '500 mS

    Dim SetTagLock As ReaderWriterLockSlim = New ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion)
    Dim GetTagLock As ReaderWriterLockSlim = New ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion)



    Public Sub New(MachineName As String, MachineNo As Integer)
        mMachineName = MachineName
        mMachineNo = MachineNo
        PLCInit()

    End Sub


    Sub PLCInit()





        Dim strArray As String()
        Try
            Dim SR As StreamReader = New StreamReader(Templatepath & "PLC\MC" & mMachineName & ".txt")
            Dim line As String

            line = SR.ReadLine 'read header
            line = SR.ReadLine 'read the content
            Do
                If Not line = String.Empty Then

                    strArray = line.Split(","c)

                    'Check for duplicate entries 
                    ' temphashTable.Add(strArray(0).ToUpper.Trim, 0)

                    AddVariable(strArray(0).ToUpper.Trim, strArray(1).Trim, strArray(2).Trim, strArray(3).Trim.ToUpper.Trim, strArray(4).ToUpper.Trim)
                    line = SR.ReadLine 'read the content
                Else
                    Exit Do
                End If
            Loop


        Catch ex As Exception
            If IsNothing(strArray) Then ReDim strArray(1)
            MessageBox.Show(ex.Message.ToString & strArray(0), System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        ' temphashTable.Clear() ' there is no need for this object any more

        'UT.ActLogicalStationNumber = 1
        'UT.ActPassword = ""
        ' UT.Open()

        TagExTmr.Interval = 2000
        ''    If mMachineName = "3.1" Then 
        TagExTmr.Enabled = True

        'TagsReadTmr.Interval = 2000
        'TagsReadTmr.Enabled = True

    End Sub

    'Private Sub MonitorLimits() 'This will be done in plc itself
    '    ' RaiseEvent LimitsExceeded()
    'End Sub

    'Public Sub ProcessPLCValues()
    '    MonitorLimits()
    'End Sub


    Sub AddVariable(VarName As String, Address As String, StationNo As String, Type As Integer, Value As Single)
        'Dim NoOfVar As Integer = PLCVariables.Count
        'ReDim PLCVariables(NoOfVar + 1)
        'PLCVariables(NoOfVar).Name = VarName
        'PLCVariables(NoOfVar).Address = Address
        'PLCVariables(NoOfVar).Value = Value
        'PLCVariables(NoOfVar).StationNo = StationNo

        Dim NewPLCTag As PLCTag
        NewPLCTag.Address = Address
        NewPLCTag.StationNo = StationNo
        NewPLCTag.Type = Type
        NewPLCTag.WriteValue = Value

        'Select Case ScanTime
        '    Case "250MS"
        '        If RW = "R" Or RW = "RW" Then PLCVariables250msR.Add(VarName, NewPLCTag)
        '        If RW = "W" Or RW = "RW" Then PLCVariables250msW.Add(VarName, NewPLCTag)

        '    Case "500MS"
        '        If RW = "R" Or RW = "RW" Then PLCVariables500msR.Add(VarName, NewPLCTag)
        '        If RW = "W" Or RW = "RW" Then PLCVariables500msW.Add(VarName, NewPLCTag)

        '    Case "1S"
        '        If RW = "R" Or RW = "RW" Then PLCVariables1sR.Add(VarName, NewPLCTag)
        '        If RW = "W" Or RW = "RW" Then PLCVariables1sW.Add(VarName, NewPLCTag)

        '    Case "10S"
        '        If RW = "R" Or RW = "RW" Then PLCVariables10sR.Add(VarName, NewPLCTag)
        '        If RW = "W" Or RW = "RW" Then PLCVariables10sW.Add(VarName, NewPLCTag)

        'End Select
        'If RW = "R" Or RW = "RW" Then PLCVariablesR.Add(VarName, NewPLCTag)
        'If RW = "W" Or RW = "RW" Then PLCVariablesW.Add(VarName, NewPLCTag)
        PLCVariables.Add(VarName, NewPLCTag)
        Try

        Catch ae As ArgumentException
            MessageBox.Show("Duplicate Key", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function GetTagValUint16(VarName As String) As UInt16

        Dim TagVal As UInt16
        Dim data() As Integer = {0, 0, 0, 0, 0, 0, 0, 0}
        Dim Stn As ActUtlTypeLib.ActUtlType

        'GetTagLock.EnterWriteLock()

        Dim MyPLCTag As PLCTag
        Dim retval As Single = 0.0

        Try
            If PLCVariables.ContainsKey(VarName.ToUpper) Then
                MyPLCTag = PLCVariables(VarName.ToUpper)
                Stn = PLCStations(MyPLCTag.StationNo).Stn
                'If PLCStations(MyPLCTag.StationNo).IsStnAvailable Then
                '    Stn.ReadDeviceBlock(MyPLCTag.Address, 1, data(0))
                'End If
                'TagVal = ToUInt(data)
                'MyPLCTag.ReadValue = TagVal
                'PLCVariables(VarName.ToUpper) = MyPLCTag
                If PLCStations(MyPLCTag.StationNo).IsStnAvailable Then
                    PLCStations(MyPLCTag.StationNo).TagLock.EnterReadLock()
                    If Left(MyPLCTag.Address, 1) = "D" Then
                        data(0) = PLCStations(MyPLCTag.StationNo).DataWord(Right(MyPLCTag.Address, MyPLCTag.Address.Length - 1))
                        data(1) = PLCStations(MyPLCTag.StationNo).DataWord(Right(MyPLCTag.Address, MyPLCTag.Address.Length - 1) + 1)
                    End If
                    PLCStations(MyPLCTag.StationNo).TagLock.ExitReadLock()
                End If
                TagVal = ToUInt(data)
                MyPLCTag.ReadValue = TagVal
                PLCVariables(VarName.ToUpper) = MyPLCTag
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString & " GeTagValueUint16-" & MyPLCTag.Address, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'GetTagLock.ExitWriteLock()
        Return TagVal





    End Function

    Public Function GetTagVal(VarName As String) As Single


        'GetTagLock.EnterWriteLock()

        Dim MyPLCTag As PLCTag
        Dim retval As Single = 0.0


        If PLCVariables.ContainsKey(VarName.ToUpper) Then
            MyPLCTag = PLCVariables(VarName.ToUpper)
            GetDatafromAddress(MyPLCTag)
            PLCVariables(VarName.ToUpper) = MyPLCTag
        End If


        'GetTagLock.ExitWriteLock()

        Return MyPLCTag.ReadValue





    End Function

    Public Sub SetTagVal(VarName As String, value As Single)


        'GetTagLock.EnterReadLock()

        Dim MyPLCTag As PLCTag


        If PLCVariables.ContainsKey(VarName.ToUpper) Then
            MyPLCTag = PLCVariables(VarName.ToUpper)
            MyPLCTag.WriteValue = value
            PLCVariables(VarName.ToUpper) = MyPLCTag
            WriteDatatoAddress(MyPLCTag)
        End If

        'GetTagLock.ExitReadLock()


    End Sub

    'Public Sub UpdatetoPLC_AllTags()
    '    Dim MyKeys As ICollection
    '    Dim Key As Object
    '    Dim myTag As PLCTag

    '    If PLCVariablesW.Count > 0 Then
    '        MyKeys = PLCVariablesW.Keys()
    '        For Each Key In MyKeys
    '            myTag = PLCVariablesW(Key.ToString)
    '            WriteDatatoAddress(myTag)
    '        Next
    '    End If
    'End Sub

    Private Sub GetDatafromAddress(ByRef MyTag As PLCTag)

        Dim TagVal As Single
        Dim data() As Integer = {0, 0, 0, 0, 0, 0, 0, 0}
        Dim Stn As ActUtlTypeLib.ActUtlType

        Try
            Stn = PLCStations(MyTag.StationNo).Stn

            If PLCStations(MyTag.StationNo).IsStnAvailable Then

                PLCStations(MyTag.StationNo).TagLock.EnterReadLock()
                Select Case Left(MyTag.Address, 1)
                    Case "D"
                        data(0) = PLCStations(MyTag.StationNo).DataWord(Right(MyTag.Address, MyTag.Address.Length - 1))
                        data(1) = PLCStations(MyTag.StationNo).DataWord(Right(MyTag.Address, MyTag.Address.Length - 1) + 1)

                    Case "M"

                        Dim Remainder As Integer = CInt(Right(MyTag.Address, MyTag.Address.Length - 1)) Mod 16
                        Dim Quotient As Integer = CInt(Right(MyTag.Address, MyTag.Address.Length - 1)) \ 16 'integer division ""\"" not "/
                        data(0) = If((PLCStations(MyTag.StationNo).MWord(Quotient) And 1 << Remainder) > 0, 1, 0)
                        End Select
                        PLCStations(MyTag.StationNo).TagLock.ExitReadLock()

                        Select Case MyTag.Type
                            Case 1
                                TagVal = Convert.ToBoolean(data(0))
                            Case 2
                                TagVal = ToInt(data)
                            Case 3
                                TagVal = ToReal(data)
                            Case 4
                                TagVal = ToUInt(data)
                        End Select

                    Else

                        TagVal = 0

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString & " GetDatafromAddress-" & MyTag.Address, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        MyTag.ReadValue = TagVal

    End Sub

    Private Sub WriteDatatoAddress(ByRef MyTag As PLCTag)

        Dim data() As Integer = {0, 0, 0, 0, 0, 0, 0, 0}
        Dim Byte1() As Byte

        Try

            Dim Stn As ActUtlTypeLib.ActUtlType = PLCStations(MyTag.StationNo).Stn

            If PLCStations(MyTag.StationNo).IsStnAvailable Then
                Select Case MyTag.Type
                    Case 1
                        Byte1 = BitConverter.GetBytes(Convert.ToBoolean(MyTag.WriteValue))
                        data(0) = BitConverter.ToBoolean(Byte1, 0)
                        Stn.WriteDeviceRandom(MyTag.Address, 1, data(0))
                    Case 2
                        Byte1 = BitConverter.GetBytes(Convert.ToInt16(MyTag.WriteValue))
                        data(0) = BitConverter.ToInt16(Byte1, 0)
                        Stn.WriteDeviceRandom(MyTag.Address, 1, data(0))
                    Case 3
                        Byte1 = BitConverter.GetBytes(MyTag.WriteValue)
                        data(0) = BitConverter.ToUInt16(Byte1, 0)
                        data(1) = BitConverter.ToUInt16(Byte1, 2)
                        Stn.WriteDeviceBlock(MyTag.Address, 2, data(0))
                    Case 4
                        Byte1 = BitConverter.GetBytes(Convert.ToUInt16(MyTag.WriteValue))
                        data(0) = BitConverter.ToUInt16(Byte1, 0)
                        Stn.WriteDeviceRandom(MyTag.Address, 1, data(0))

                End Select
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString & "WriteDAtafromAddress-" & MyTag.Address, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Function ToReal(dataArr() As Integer) As Single
        Dim Byte1() As Byte = BitConverter.GetBytes(dataArr(0))
        Dim Byte2() As Byte = BitConverter.GetBytes(dataArr(1))
        Dim Byte3(4) As Byte
        Array.Copy(Byte1, 0, Byte3, 0, 2)
        Array.Copy(Byte2, 0, Byte3, 2, 2)
        Return BitConverter.ToSingle(Byte3, 0)
    End Function

    Function ToInt(dataArr() As Integer) As Integer
        Dim Byte1() As Byte = BitConverter.GetBytes(dataArr(0))
        Dim IntVal As Short = BitConverter.ToInt16(Byte1, 0)
        Return Convert.ToInt32(IntVal)
    End Function

    Function ToUInt(dataArr() As Integer) As Integer
        Dim Byte1() As Byte = BitConverter.GetBytes(dataArr(0))
        Dim IntVal As UInt16 = BitConverter.ToUInt16(Byte1, 0)
        Return Convert.ToUInt32(IntVal)
    End Function

    Private Sub TagExTmr_Elapsed(sender As Object, e As ElapsedEventArgs) Handles TagExTmr.Elapsed
        TagExTmr.Enabled = False
        Dim FromTag As String = My.Settings("TagFrom")
        Dim ToTag As String = My.Settings("TagTo")

        If FromTag <> "NOSTRING" Or ToTag <> "NOSTRING" Then
            Dim strarr() As String = ToTag.Split(","c)
            Dim FromUINTVAL As UInt16 = GetTagValUint16(FromTag)
            For Each strVar In strarr
                SetTagVal(strVar, FromUINTVAL)
            Next
        End If

        SetTagVal("LifeBit", LifeBit)
        If LifeBit Then LifeBit = False Else LifeBit = True 'Toggle

        TagExTmr.Enabled = True
    End Sub

    'Private Sub TagsReadTmr_Elapsed(sender As Object, e As ElapsedEventArgs) Handles TagsReadTmr.Elapsed
    '    TagsReadTmr.Enabled = False
    '    For i = 0 To 2
    '        If MySTations(i) <> 0 Then
    '            PLCStations(MySTations(i)).Stn.ReadDeviceBlock("D0", 700, PLCDataWord(MySTations(i), 0))
    '            PLCStations(MySTations(i)).Stn.ReadDeviceBlock("M0", 200, PLCMWord(MySTations(i), 0))
    '            Application.DoEvents()
    '        End If
    '    Next
    '    TagsReadTmr.Enabled = True
    'End Sub

End Class

'Public Sub Scan250ms()





'    Dim MyKeys As ICollection
'    Dim Key As Object
'    Dim myTag As PLCTag



'    'Writing
'    'SetTagLock.EnterReadLock()
'    If PLCVariables250msW.Count > 0 Then
'        MyKeys = PLCVariables250msW.Keys()
'        For Each Key In MyKeys
'            myTag = PLCVariables250msW(Key.ToString)
'            WriteDatatoAddress(myTag)
'        Next
'    End If
'    'SetTagLock.ExitReadLock()

'    'Reading
'    'GetTagLock.EnterWriteLock()
'    If PLCVariables250msR.Count > 0 Then
'        MyKeys = PLCVariables250msR.Keys()
'        For Each Key In MyKeys
'            myTag = PLCVariables250msR(Key.ToString)
'            GetDatafromAddress(myTag)
'        Next
'    End If
'    'GetTagLock.ExitWriteLock()

'    '   Debug.Print(mMachineName & " Scan250ms")


'End Sub


'Public Sub Scan500ms()




'    Dim MyKeys As ICollection
'    Dim Key As Object
'    Dim myTag As PLCTag

'    'Writing
'    ' SetTagLock.EnterReadLock()
'    If PLCVariables500msW.Count > 0 Then
'        MyKeys = PLCVariables500msW.Keys()
'        For Each Key In MyKeys
'            myTag = PLCVariables500msW(Key.ToString)
'            WriteDatatoAddress(myTag)
'        Next
'    End If
'    'SetTagLock.ExitReadLock()

'    'Reading
'    'GetTagLock.EnterWriteLock()
'    If PLCVariables500msR.Count > 0 Then
'        MyKeys = PLCVariables500msR.Keys()
'        For Each Key In MyKeys
'            myTag = PLCVariables500msR(Key.ToString)
'            GetDatafromAddress(myTag)
'        Next
'    End If
'    'GetTagLock.ExitWriteLock()


'    ' Debug.Print(mMachineName & "        Scan500ms")
'End Sub

'Public Sub Scan1s()




'    Dim MyKeys As ICollection
'    Dim Key As Object
'    Dim myTag As PLCTag

'    'Writing
'    'SetTagLock.EnterReadLock()
'    If PLCVariables1sW.Count > 0 Then
'        MyKeys = PLCVariables1sW.Keys()
'        For Each Key In MyKeys
'            myTag = PLCVariables1sW(Key.ToString)
'            WriteDatatoAddress(myTag)
'        Next
'    End If
'    'SetTagLock.ExitReadLock()


'    'Reading
'    'GetTagLock.EnterWriteLock()
'    If PLCVariables1sR.Count > 0 Then
'        MyKeys = PLCVariables1sR.Keys()
'        For Each Key In MyKeys
'            myTag = PLCVariables1sR(Key.ToString)
'            GetDatafromAddress(myTag)
'        Next
'    End If
'    ' GetTagLock.ExitWriteLock()


'    '     Debug.Print(mMachineName & "                Scan1s")
'End Sub

'Public Sub Scan10s()




'    Dim MyKeys As ICollection
'    Dim Key As Object
'    Dim myTag As PLCTag

'    'Writing
'    'SetTagLock.EnterReadLock()
'    If PLCVariables10sW.Count > 0 Then
'        MyKeys = PLCVariables10sW.Keys()
'        For Each Key In MyKeys
'            myTag = PLCVariables10sW(Key.ToString)
'            WriteDatatoAddress(myTag)
'        Next
'    End If
'    'SetTagLock.ExitReadLock()

'    'Reading
'    'GetTagLock.EnterWriteLock()
'    If PLCVariables10sR.Count > 0 Then
'        MyKeys = PLCVariables10sR.Keys()
'        For Each Key In MyKeys
'            myTag = PLCVariables10sR(Key.ToString)
'            GetDatafromAddress(myTag)
'        Next
'    End If
'    'GetTagLock.ExitWriteLock()


'    '    Debug.Print(mMachineName & "                     Scan10s")

'End Sub