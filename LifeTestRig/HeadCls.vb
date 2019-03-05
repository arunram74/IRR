'***********************************************************************************************************
'*Handles - Handles PLC class per machine to be passed to background worker
'*
'***********************************************************************************************************
Imports LifeTestRig
Imports System.Timers

Public Class CommunicationCls
    Public PLC1 As PLCCls
    Public PLC2 As PLCCls
    Public PLC3 As PLCCls
    Public PLC4 As PLCCls

    Dim WithEvents CheckCommsTmr As New Timer

    Sub New(Mc1Name As String, Mc2Name As String, Mc3Name As String, Mc4Name As String)
        Templatepath = My.Settings("TemplateLoc")
        ' PLCStnTable = New Hashtable()
        For i = 0 To 12
            PLCStations.Add(New PLCStn)
        Next i


        CheckCommsTmr.Interval = 20000
        CheckCommsTmr.Enabled = True


        PLC1 = New PLCCls(Mc1Name, 0)
        PLC2 = New PLCCls(Mc2Name, 1)
        PLC3 = New PLCCls(Mc3Name, 2)
        PLC4 = New PLCCls(Mc4Name, 3)
    End Sub



End Class
'***********************************************************************************************************
'*Handles - Just Represent Machines. This class to be passed to background worker
'*
'***********************************************************************************************************


Public Class StnCls
    Public MachineType As String
    Dim McName1 As String = My.Settings.Item("MC1Size")
    Dim McName2 As String = My.Settings.Item("MC2Size")
    Dim McName3 As String = My.Settings.Item("MC3Size")
    Dim McName4 As String = My.Settings.Item("MC4Size")

    Public Comms As New CommunicationCls(McName1, McName2, McName3, McName4)
    Public MC1 As New MachineCls(McName1, 1, Comms.PLC1)
    Public MC2 As New MachineCls(McName2, 2, Comms.PLC2)
    Public MC3 As New MachineCls(McName3, 3, Comms.PLC3)
    Public MC4 As New MachineCls(McName4, 4, Comms.PLC4)

End Class

'***********************************************************************************************************
'*Handles - Just Represent Machines
'*
'***********************************************************************************************************
Public Class MachineCls
    Public MachineType As String
    Public HeadA As HeadCls
    Public HeadB As HeadCls
    Public PLCAddress As String 'ip address
    Public WithEvents PLC As PLCCls

    Public mMachineName As String
    Dim mMachineID As String


    Public Sub New(MachineName As String, MachineID As String, PLC As PLCCls)
        mMachineName = MachineName
        mMachineID = MachineID

        '' PLC = New PLCCls(MachineName)
        HeadA = New HeadCls("A", mMachineName, mMachineID, PLC)
        HeadB = New HeadCls("B", mMachineName, mMachineID, PLC)
        GetIPAddress()
    End Sub



    Private Sub GetIPAddress()

    End Sub

End Class

'***********************************************************************************************************
'*Handles - Head functions
'*
'***********************************************************************************************************
Public Class HeadCls
    Public WithEvents myProj As ProjectCls
    Public PLC As PLCCls
    Dim mHeadName As String
    Dim mProjName As String = ""
    Dim mProjectID As Integer = 0
    Dim mMachineName As String
    Dim mMachineID As String

    Public Event HeadStatusChanged()

    Public Sub New(HeadName As String, MachineName As String, MachineID As String, PLCofMachine As PLCCls)
        mHeadName = HeadName
        mMachineName = MachineName
        mMachineID = MachineID

        myProj = New ProjectCls(mMachineName, mHeadName, PLCofMachine)
        PLC = PLCofMachine

        myProj.HeadName = mHeadName
        myProj.MachineName = mMachineName
        GetPreviousPrjID()
        If mProjectID <> 0 Then
            myProj.LoadExisting(mProjectID)
            Debug.Print("Loading projectID = " & mProjectID & "HeadName=" & mHeadName)
        Else
            myProj.isNew = True
        End If


    End Sub

    Private Sub GetPreviousPrjID()
        Dim strKey As String
        If mHeadName = "A" Then strKey = "M" & mMachineID & "HAPrjID" Else strKey = "M" & mMachineID & "HBPrjID"
        mProjectID = My.Settings.Item(strKey)
    End Sub

    Private Sub myProj_ProjectChanged(ProjectID As String) Handles myProj.ProjectChanged
        mProjectID = ProjectID
        Dim strKey As String
        If mHeadName = "A" Then strKey = "M" & mMachineID & "HAPrjID" Else strKey = "M" & mMachineID & "HBPrjID"
        My.Settings.Item(strKey) = mProjectID
        My.Settings.Save()
        RaiseEvent HeadStatusChanged()
    End Sub

    Protected Overrides Sub Finalize()
        'Dim strKey As String
        'If mHeadName = "A" Then strKey = "M" & mMachineID & "HAPrjID" Else strKey = "M" & mMachineID & "HBPrjID"
        'My.Settings.Item(strKey) = mProjectID
        'My.Settings.Save()
        MyBase.Finalize()
    End Sub

    'Private Sub myProj_StatusChange() Handles myProj.StatusChanged
    '    RaiseEvent HeadStatusChanged()
    'End Sub
End Class
