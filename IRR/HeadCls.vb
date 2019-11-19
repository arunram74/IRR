'***********************************************************************************************************
'*Handles - Handles PLC class per machine to be passed to background worker
'*
'***********************************************************************************************************
Imports IRR
Imports System.Timers

Public Class CommunicationCls
    Public PLC1 As PLCCls
    Dim WithEvents CheckCommsTmr As New Timer

    Sub New()
        Templatepath = My.Settings("TemplateLoc")
        ' PLCStnTable = New Hashtable()
        For i = 0 To 12
            PLCStations.Add(New PLCStn)
        Next i

        CheckCommsTmr.Interval = 20000
        CheckCommsTmr.Enabled = True

        PLC1 = New PLCCls()

    End Sub



End Class
'***********************************************************************************************************
'*Handles - Just Represent Machines. This class to be passed to background worker
'*
'***********************************************************************************************************


Public Class StnCls
    Public Comms As New CommunicationCls()
    Public MC As New MachineCls(Comms.PLC1)
End Class


'***********************************************************************************************************
'*Handles - Head functions
'*
'***********************************************************************************************************
Public Class MachineCls
    Public WithEvents myProj As ProjectCls
    Public PLC As PLCCls

    Dim mProjName As String = ""
    Dim mProjectID As Integer = 0

    Public Event HeadStatusChanged()

    Public Sub New(PLCofMachine As PLCCls)


        myProj = New ProjectCls(PLCofMachine)
        PLC = PLCofMachine


        GetPreviousPrjID()
        If mProjectID <> 0 Then
            myProj.LoadExisting(mProjectID)
            Debug.Print("Loading projectID = " & mProjectID)
        Else
            myProj.isNew = True
        End If


    End Sub

    Private Sub GetPreviousPrjID()
        Dim strKey As String
        mProjectID = My.Settings.Item("PrjID")
    End Sub

    Private Sub myProj_ProjectChanged(ProjectID As String) Handles myProj.ProjectChanged
        mProjectID = ProjectID
        Dim strKey As String

        My.Settings.Item("PrjID") = mProjectID
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
