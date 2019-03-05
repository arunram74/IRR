Imports System.ComponentModel
Imports LifeTestRig

Public Class frmDefault
    Dim WithEvents H1, H2, H3, H4, H5, H6, H7, H8 As HeadDisplay

    Dim WithEvents Tmr As New Timer

    Dim frmRun As frmRunSusp


    Dim myParent As frmMain

    Private Sub frmDefault_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myParent = MdiParent
        myParent.toolbtnNewProj.Enabled = False
        myParent.toolBtnOpenPrj.Enabled = False
        myParent.toolBtnModifyPrj.Enabled = False
        lblMC1.Text = My.Settings("MC1Size")
        lblMC2.Text = My.Settings("MC2Size")
        lblMC3.Text = My.Settings("MC3Size")
        lblMC4.Text = My.Settings("MC4Size")
        chkMC1.Checked = My.Settings("MC1Sel")
        chkMC2.Checked = My.Settings("MC2Sel")
        chkMC3.Checked = My.Settings("MC3Sel")
        chkMC4.Checked = My.Settings("MC4Sel")

        Tmr.Interval = 100

    End Sub


    Private Sub frmDefault_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        H1 = New HeadDisplay(ledRunH1, ledIdleH1, ledLoadH1, ledStopH1, lblStatusH1, lblPrjNameH1, lblCupH1, lblConeH1, lblCreateDtTimeH1, lblH1, TransPicH1, Panel1, Station.MC1.HeadA, 1)
        H2 = New HeadDisplay(ledRunH2, ledIdleH2, ledLoadH2, ledStopH2, lblStatusH2, lblPrjNameH2, lblCupH2, lblConeH2, lblCreateDtTimeH2, lblH2, TransPicH2, Panel2, Station.MC1.HeadB, 1)
        H3 = New HeadDisplay(ledRunH3, ledIdleH3, ledLoadH3, ledStopH3, lblStatusH3, lblPrjNameH3, lblCupH3, lblConeH3, lblCreateDtTimeH3, lblH3, TransPicH3, Panel3, Station.MC2.HeadA, 2)
        H4 = New HeadDisplay(ledRunH4, ledIdleH4, ledLoadH4, ledStopH4, lblStatusH4, lblPrjNameH4, lblCupH4, lblConeH4, lblCreateDtTimeH4, lblH4, TransPicH4, Panel4, Station.MC2.HeadB, 2)
        H5 = New HeadDisplay(ledRunH5, ledIdleH5, ledLoadH5, ledStopH5, lblStatusH5, lblPrjNameH5, lblCupH5, lblConeH5, lblCreateDtTimeH5, lblH5, TransPicH5, Panel5, Station.MC3.HeadA, 3)
        H6 = New HeadDisplay(ledRunH6, ledIdleH6, ledLoadH6, ledStopH6, lblStatusH6, lblPrjNameH6, lblCupH6, lblConeH6, lblCreateDtTimeH6, lblH6, TransPicH6, Panel6, Station.MC3.HeadB, 3)
        H7 = New HeadDisplay(ledRunH7, ledIdleH7, ledLoadH7, ledStopH7, lblStatusH7, lblPrjNameH7, lblCupH7, lblConeH7, lblCreateDtTimeH7, lblH7, TransPicH7, Panel7, Station.MC4.HeadA, 4)
        H8 = New HeadDisplay(ledRunH8, ledIdleH8, ledLoadH8, ledStopH8, lblStatusH8, lblPrjNameH8, lblCupH8, lblConeH8, lblCreateDtTimeH8, lblH8, TransPicH8, Panel8, Station.MC4.HeadB, 4)
    End Sub

    Private Sub frmDefault_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        myParent.toolbtnNewProj.Enabled = False
        myParent.toolBtnOpenPrj.Enabled = False
        myParent.toolBtnModifyPrj.Enabled = False
        myParent.toolBtnComplete.Enabled = False
        My.Settings("MC1Sel") = chkMC1.Checked
        My.Settings("MC2Sel") = chkMC2.Checked
        My.Settings("MC3Sel") = chkMC3.Checked
        My.Settings("MC4Sel") = chkMC4.Checked
        My.Settings.Save()
    End Sub

    Private Sub chkMC1_Click(sender As Object, e As EventArgs) Handles chkMC1.Click
        If (Station.MC1.HeadA.myProj.MyStatus = ProjectCls.ProjectStatus.Run Or Station.MC1.HeadA.myProj.MyStatus = ProjectCls.ProjectStatus.Load) Or (Station.MC1.HeadB.myProj.MyStatus = ProjectCls.ProjectStatus.Run Or Station.MC1.HeadB.myProj.MyStatus = ProjectCls.ProjectStatus.Load) Then
            Exit Sub
        Else
            chkMC1.Checked = Not chkMC1.Checked
            If Not chkMC1.Checked Then
                H1.Selected = False
                H2.Selected = False

            Else
                If Station.MC1.HeadA.myProj.ProjectID = 0 Or Station.MC1.HeadB.myProj.ProjectID = 0 Then
                    MessageBox.Show("Projects should be assigned to both heads", "Select both heads", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    chkMC1.Checked = False
                    Exit Sub
                End If
                H1.Selected = True
                H2.Selected = True
                myParent.toolbtnNewProj.Enabled = False
                myParent.toolBtnOpenPrj.Enabled = False
                ''             myParent.toolBtnModifyPrj.Enabled = False
                myParent.toolBtnComplete.Enabled = False
            End If
        End If

    End Sub

    Private Sub chkMC2_Click(sender As Object, e As EventArgs) Handles chkMC2.Click
        If (Station.MC2.HeadA.myProj.MyStatus = ProjectCls.ProjectStatus.Run Or Station.MC2.HeadA.myProj.MyStatus = ProjectCls.ProjectStatus.Load) Or (Station.MC2.HeadB.myProj.MyStatus = ProjectCls.ProjectStatus.Run Or Station.MC2.HeadB.myProj.MyStatus = ProjectCls.ProjectStatus.Load) Then
            Exit Sub
        Else
            chkMC2.Checked = Not chkMC2.Checked
            If Not chkMC2.Checked Then
                H3.Selected = False
                H4.Selected = False
            Else
                If Station.MC2.HeadA.myProj.ProjectID = 0 Or Station.MC2.HeadB.myProj.ProjectID = 0 Then
                    MessageBox.Show("Projects should be assigned to both heads", "Select both heads", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    chkMC2.Checked = False
                    Exit Sub
                End If
                H3.Selected = True
                H4.Selected = True
                myParent.toolbtnNewProj.Enabled = False
                myParent.toolBtnOpenPrj.Enabled = False
                ''              myParent.toolBtnModifyPrj.Enabled = False
                myParent.toolBtnComplete.Enabled = False

            End If
        End If

    End Sub

    Private Sub chkMC3_Click(sender As Object, e As EventArgs) Handles chkMC3.Click
        If (Station.MC3.HeadA.myProj.MyStatus = ProjectCls.ProjectStatus.Run Or Station.MC3.HeadA.myProj.MyStatus = ProjectCls.ProjectStatus.Load) Or (Station.MC3.HeadB.myProj.MyStatus = ProjectCls.ProjectStatus.Run Or Station.MC3.HeadB.myProj.MyStatus = ProjectCls.ProjectStatus.Load) Then
            Exit Sub
        Else
            chkMC3.Checked = Not chkMC3.Checked
            If Not chkMC3.Checked Then
                H5.Selected = False
                H6.Selected = False

            Else
                If Station.MC3.HeadA.myProj.ProjectID = 0 Or Station.MC3.HeadB.myProj.ProjectID = 0 Then
                    MessageBox.Show("Projects should be assigned to both heads", "Select both heads", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    chkMC3.Checked = False
                    Exit Sub
                End If
                H5.Selected = True
                H6.Selected = True
                myParent.toolbtnNewProj.Enabled = False
                myParent.toolBtnOpenPrj.Enabled = False
                ''            myParent.toolBtnModifyPrj.Enabled = False
                myParent.toolBtnComplete.Enabled = False
            End If
        End If

    End Sub

    Private Sub chkMC4_Click(sender As Object, e As EventArgs) Handles chkMC4.Click
        If (Station.MC4.HeadA.myProj.MyStatus = ProjectCls.ProjectStatus.Run Or Station.MC4.HeadA.myProj.MyStatus = ProjectCls.ProjectStatus.Load) Or (Station.MC4.HeadB.myProj.MyStatus = ProjectCls.ProjectStatus.Run Or Station.MC4.HeadB.myProj.MyStatus = ProjectCls.ProjectStatus.Load) Then
            Exit Sub
        Else
            chkMC4.Checked = Not chkMC4.Checked
            If Not chkMC4.Checked Then
                H7.Selected = False
                H8.Selected = False

            Else
                If Station.MC4.HeadA.myProj.ProjectID = 0 Or Station.MC4.HeadB.myProj.ProjectID = 0 Then
                    MessageBox.Show("Projects should be assigned to both heads", "Select both heads", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    chkMC4.Checked = False
                    Exit Sub
                End If
                H7.Selected = True
                H8.Selected = True
                myParent.toolbtnNewProj.Enabled = False
                myParent.toolBtnOpenPrj.Enabled = False
                ''              myParent.toolBtnModifyPrj.Enabled = False
                myParent.toolBtnComplete.Enabled = False
            End If
        End If

    End Sub

    Private Sub H1_Click(sender As HeadDisplay, e As MouseEventArgs) Handles H1.Click

        UnselectAll()

        If chkMC1.Checked Then
            CurrentHead = H1.HeadObj
            PairHead = H2.HeadObj
            H1.Selected = True
            '' H2.Selected = True
        Else
            CurrentHead = H1.HeadObj ' make current selected head as current head which we are dealing with
            H1.Selected = True
        End If

        EnableDisable(CurrentHead.myProj, H2.HeadObj.myProj.MyStatus, chkMC1.Checked, Panel31.Location + Panel1.Location, e)
        Dim e1 As MouseEventArgs = New MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 0, 0, 0, 0)
        If e.Button = MouseButtons.Right Then H1_Click(H1, e1)

    End Sub

    Private Sub H2_Click(sender As HeadDisplay, e As MouseEventArgs) Handles H2.Click

        UnselectAll()

        If chkMC1.Checked Then
            CurrentHead = H2.HeadObj
            PairHead = H1.HeadObj
            ''  H1.Selected = True
            H2.Selected = True
        Else
            CurrentHead = H2.HeadObj ' make current selected head as current head which we are dealing with
            H2.Selected = True
        End If

        EnableDisable(CurrentHead.myProj, H1.HeadObj.myProj.MyStatus, chkMC1.Checked, Panel31.Location + Panel2.Location, e)
        Dim e1 As MouseEventArgs = New MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 0, 0, 0, 0)
        If e.Button = MouseButtons.Right Then H2_Click(H2, e1)

    End Sub

    Private Sub H3_Click(sender As HeadDisplay, e As MouseEventArgs) Handles H3.Click

        UnselectAll()

        If chkMC2.Checked Then
            CurrentHead = H3.HeadObj
            PairHead = H4.HeadObj
            H3.Selected = True
            ''   H4.Selected = True
        Else
            CurrentHead = H3.HeadObj ' make current selected head as current head which we are dealing with
            H3.Selected = True
        End If

        EnableDisable(CurrentHead.myProj, H4.HeadObj.myProj.MyStatus, chkMC2.Checked, Panel41.Location + Panel3.Location, e)
        Dim e1 As MouseEventArgs = New MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 0, 0, 0, 0)
        If e.Button = MouseButtons.Right Then H3_Click(H3, e1)

    End Sub

    Private Sub H4_Click(sender As HeadDisplay, e As MouseEventArgs) Handles H4.Click

        UnselectAll()

        If chkMC2.Checked Then
            CurrentHead = H4.HeadObj
            PairHead = H3.HeadObj
            ''  H3.Selected = True
            H4.Selected = True
        Else
            CurrentHead = H4.HeadObj ' make current selected head as current head which we are dealing with
            H4.Selected = True
        End If

        EnableDisable(CurrentHead.myProj, H3.HeadObj.myProj.MyStatus, chkMC2.Checked, Panel41.Location + Panel4.Location, e)
        Dim e1 As MouseEventArgs = New MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 0, 0, 0, 0)
        If e.Button = MouseButtons.Right Then H4_Click(H4, e1)

    End Sub

    Private Sub H5_Click(sender As HeadDisplay, e As MouseEventArgs) Handles H5.Click

        UnselectAll()

        If chkMC3.Checked Then
            CurrentHead = H5.HeadObj
            PairHead = H6.HeadObj
            H5.Selected = True
            ''   H6.Selected = True
        Else
            CurrentHead = H5.HeadObj ' make current selected head as current head which we are dealing with
            H5.Selected = True
        End If

        EnableDisable(CurrentHead.myProj, H6.HeadObj.myProj.MyStatus, chkMC3.Checked, Panel51.Location + Panel5.Location, e)
        Dim e1 As MouseEventArgs = New MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 0, 0, 0, 0)
        If e.Button = MouseButtons.Right Then H5_Click(H5, e1)

    End Sub

    Private Sub H6_Click(sender As HeadDisplay, e As MouseEventArgs) Handles H6.Click

        UnselectAll()

        If chkMC3.Checked Then
            CurrentHead = H6.HeadObj
            PairHead = H5.HeadObj
            ''   H5.Selected = True
            H6.Selected = True
        Else
            CurrentHead = H6.HeadObj ' make current selected head as current head which we are dealing with
            H6.Selected = True
        End If

        EnableDisable(CurrentHead.myProj, H5.HeadObj.myProj.MyStatus, chkMC3.Checked, Panel51.Location + Panel6.Location, e)
        Dim e1 As MouseEventArgs = New MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 0, 0, 0, 0)
        If e.Button = MouseButtons.Right Then H6_Click(H6, e1)

    End Sub

    Private Sub H7_Click(sender As HeadDisplay, e As MouseEventArgs) Handles H7.Click

        UnselectAll()

        If chkMC4.Checked Then
            CurrentHead = H7.HeadObj
            PairHead = H8.HeadObj
            H7.Selected = True
            ''     H8.Selected = True
        Else
            CurrentHead = H7.HeadObj ' make current selected head as current head which we are dealing with
            H7.Selected = True
        End If

        EnableDisable(CurrentHead.myProj, H8.HeadObj.myProj.MyStatus, chkMC4.Checked, Panel61.Location + Panel7.Location, e)
        Dim e1 As MouseEventArgs = New MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 0, 0, 0, 0)
        If e.Button = MouseButtons.Right Then H7_Click(H7, e1)

    End Sub

    Private Sub H8_Click(sender As HeadDisplay, e As MouseEventArgs) Handles H8.Click

        UnselectAll()

        If chkMC4.Checked Then
            CurrentHead = H8.HeadObj
            PairHead = H7.HeadObj
            ''   H7.Selected = True
            H8.Selected = True
        Else
            CurrentHead = H8.HeadObj ' make current selected head as current head which we are dealing with
            H8.Selected = True
        End If

        EnableDisable(CurrentHead.myProj, H7.HeadObj.myProj.MyStatus, chkMC4.Checked, Panel61.Location + Panel8.Location, e)
        Dim e1 As MouseEventArgs = New MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 0, 0, 0, 0)
        If e.Button = MouseButtons.Right Then H8_Click(H8, e1)

    End Sub

    Sub UnselectAll()
        H1.Selected = False
        H2.Selected = False
        H3.Selected = False
        H4.Selected = False
        H5.Selected = False
        H6.Selected = False
        H7.Selected = False
        H8.Selected = False
    End Sub

    Sub EnableDisable(ProjectObj As ProjectCls, OtherHeadStatus As ProjectCls.ProjectStatus, IsCommonChecked As Boolean, StartPoint As Point, e As MouseEventArgs)

        If (ProjectObj.MyStatus = ProjectCls.ProjectStatus.Suspended Or ProjectObj.MyStatus = ProjectCls.ProjectStatus.Idle) And ProjectObj.ProjectID <> 0 And Not IsCommonChecked Then
            myParent.toolBtnComplete.Enabled = True
        Else
            myParent.toolBtnComplete.Enabled = False
        End If

        If ProjectObj.ProjectID <> 0 Then myParent.toolBtnModifyPrj.Enabled = True Else myParent.toolBtnModifyPrj.Enabled = False

        If ProjectObj.ProjectID = 0 And Not IsCommonChecked Then
            myParent.toolBtnOpenPrj.Enabled = True
            myParent.toolbtnNewProj.Enabled = True
        Else
            myParent.toolBtnOpenPrj.Enabled = False
            myParent.toolbtnNewProj.Enabled = False
        End If

        If e.Button = MouseButtons.Right Then

            If (Not (OtherHeadStatus = ProjectCls.ProjectStatus.Run Or OtherHeadStatus = ProjectCls.ProjectStatus.Load) And Not IsCommonChecked And ProjectObj.ProjectID <> 0) Or IsCommonChecked Then
                frmRunSusp.Location = e.Location + StartPoint
                frmRunSusp.HeadPairBonded = IsCommonChecked
                frmRunSusp.ShowDialog()

            End If
        End If

    End Sub

    Public Sub SendClick()
        Dim e As MouseEventArgs = New MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 0, 0, 0, 0)
        If H1.Selected Then H1_Click(H1, e)
        If H2.Selected Then H2_Click(H2, e)
        If H3.Selected Then H3_Click(H3, e)
        If H4.Selected Then H4_Click(H4, e)
        If H5.Selected Then H5_Click(H5, e)
        If H6.Selected Then H6_Click(H6, e)
        If H7.Selected Then H7_Click(H7, e)
        If H8.Selected Then H8_Click(H8, e)
    End Sub




End Class
'Private Sub H1_MyStatusChanged(sender As HeadDisplay) Handles H1.MyStatusChanged
'    If sender.Selected Then
'        If (sender.HeadObj.myProj.MyStatus = ProjectCls.ProjectStatus.Suspended Or sender.HeadObj.myProj.MyStatus = ProjectCls.ProjectStatus.Idle) And sender.HeadObj.myProj.ProjectID <> 0 Then
'            myParent.toolBtnComplete.Enabled = True
'        Else
'            myParent.toolBtnComplete.Enabled = False
'        End If
'    End If
'End Sub

'Private Sub TransPic1_Click(sender As HeadDisplay, e As MouseEventArgs) Handles H1.Click, H2.Click, H3.Click, H4.Click, H5.Click, H6.Click, H7.Click, H8.Click

'    Dim myStatus As Boolean
'    Dim ISCommonChecked As Boolean = False


'    myParent.toolbtnNewProj.Enabled = False
'    myParent.toolBtnOpenPrj.Enabled = False
'    'myParent.toolBtnModifyPrj.Enabled = False
'    myParent.toolBtnComplete.Enabled = False

'    myStatus = sender.Selected

'    CurrentHead = Nothing ' make nothing else is selected
'    H1.Selected = False
'    H2.Selected = False
'    H3.Selected = False
'    H4.Selected = False
'    H5.Selected = False
'    H6.Selected = False
'    H7.Selected = False
'    H8.Selected = False

'    sender.Selected = myStatus

'    If Not sender.Selected Then sender.Selected = True


'    If sender.Selected Then

'        Select Case sender.MaChineSet
'            Case 1
'                If chkMC1.Checked Then
'                    ISCommonChecked = True
'                    CurrentHead = Station.MC1.HeadA
'                    PairHead = Station.MC1.HeadB
'                    H1.Selected = True
'                    H2.Selected = True
'                Else
'                    CurrentHead = sender.HeadObj ' make current selected head as current head which we are dealing with
'                End If
'            Case 2
'                If chkMC2.Checked Then
'                    ISCommonChecked = True
'                    CurrentHead = Station.MC2.HeadA
'                    PairHead = Station.MC2.HeadB
'                    H3.Selected = True
'                    H4.Selected = True
'                Else
'                    CurrentHead = sender.HeadObj ' make current selected head as current head which we are dealing with
'                End If
'            Case 3
'                If chkMC3.Checked Then
'                    ISCommonChecked = True
'                    CurrentHead = Station.MC3.HeadA
'                    PairHead = Station.MC3.HeadB
'                    H5.Selected = True
'                    H6.Selected = True
'                Else
'                    CurrentHead = sender.HeadObj
'                End If
'            Case 4
'                If chkMC4.Checked Then
'                    ISCommonChecked = True
'                    CurrentHead = Station.MC4.HeadA
'                    PairHead = Station.MC4.HeadB
'                    H7.Selected = True
'                    H8.Selected = True
'                Else
'                    CurrentHead = sender.HeadObj
'                End If
'        End Select



'        '' If CurrentHead.myProj.MyStatus <> ProjectCls.ProjectStatus.Run And CurrentHead.myProj.MyStatus <> ProjectCls.ProjectStatus.Load And Not ISCommonChecked Then
'        If CurrentHead.myProj.ProjectID = 0 And Not ISCommonChecked Then
'            myParent.toolbtnNewProj.Enabled = True
'            ''     If CurrentHead.myProj.ProjectID <> 0 Then myParent.toolBtnModifyPrj.Enabled = True
'        Else
'            myParent.toolbtnNewProj.Enabled = False
'            ''    myParent.toolBtnModifyPrj.Enabled = False
'        End If

'        If CurrentHead.myProj.ProjectID <> 0 And Not ISCommonChecked Then myParent.toolBtnModifyPrj.Enabled = True

'        If (CurrentHead.myProj.MyStatus = ProjectCls.ProjectStatus.Suspended Or CurrentHead.myProj.MyStatus = ProjectCls.ProjectStatus.Idle) And CurrentHead.myProj.ProjectID <> 0 And Not ISCommonChecked Then
'            myParent.toolBtnComplete.Enabled = True
'        Else
'            myParent.toolBtnComplete.Enabled = False
'        End If

'        If CurrentHead.myProj.MyStatus = ProjectCls.ProjectStatus.Idle And CurrentHead.myProj.ProjectID = 0 And Not ISCommonChecked Then
'            myParent.toolBtnOpenPrj.Enabled = True
'        Else
'            myParent.toolBtnOpenPrj.Enabled = False
'        End If



'        If CurrentHead.myProj.ProjectID <> 0 Then

'            Dim StartPoint As Point
'            If e.Button = MouseButtons.Right Then
'                Select Case sender.MyBasePanel.Name
'                    Case "Panel1"
'                        StartPoint = Panel31.Location + Panel1.Location
'                    Case "Panel2"
'                        StartPoint = Panel31.Location + Panel2.Location
'                    Case "Panel3"
'                        StartPoint = Panel41.Location + Panel3.Location
'                    Case "Panel4"
'                        StartPoint = Panel41.Location + Panel4.Location
'                    Case "Panel5"
'                        StartPoint = Panel51.Location + Panel5.Location
'                    Case "Panel6"
'                        StartPoint = Panel51.Location + Panel6.Location
'                    Case "Panel7"
'                        StartPoint = Panel61.Location + Panel7.Location
'                    Case "Panel8"
'                        StartPoint = Panel61.Location + Panel8.Location
'                End Select
'                Dim RunPossble As Boolean = False
'                Dim OtherHeadStatus As ProjectCls.ProjectStatus = ProjectCls.ProjectStatus.Idle

'                Select Case sender.MaChineSet
'                    Case 1
'                        If CurrentHead.myProj.HeadName = "A" Then OtherHeadStatus = Station.MC1.HeadB.myProj.MyStatus Else OtherHeadStatus = Station.MC1.HeadA.myProj.MyStatus
'                    Case 2
'                        If CurrentHead.myProj.HeadName = "A" Then OtherHeadStatus = Station.MC2.HeadB.myProj.MyStatus Else OtherHeadStatus = Station.MC2.HeadA.myProj.MyStatus
'                    Case 3
'                        If CurrentHead.myProj.HeadName = "A" Then OtherHeadStatus = Station.MC3.HeadB.myProj.MyStatus Else OtherHeadStatus = Station.MC3.HeadA.myProj.MyStatus
'                    Case 4
'                        If CurrentHead.myProj.HeadName = "A" Then OtherHeadStatus = Station.MC3.HeadB.myProj.MyStatus Else OtherHeadStatus = Station.MC3.HeadA.myProj.MyStatus
'                End Select

'                If (Not (OtherHeadStatus = ProjectCls.ProjectStatus.Run Or OtherHeadStatus = ProjectCls.ProjectStatus.Load) And Not ISCommonChecked) Or ISCommonChecked Then
'                    frmRunSusp.Location = e.Location + StartPoint
'                    frmRunSusp.HeadPairBonded = ISCommonChecked
'                    frmRunSusp.ShowDialog()

'                    If (CurrentHead.myProj.MyStatus = ProjectCls.ProjectStatus.Suspended Or CurrentHead.myProj.MyStatus = ProjectCls.ProjectStatus.Idle) And CurrentHead.myProj.ProjectID <> 0 And Not ISCommonChecked Then
'                        myParent.toolBtnComplete.Enabled = True
'                    Else
'                        myParent.toolBtnComplete.Enabled = False
'                    End If

'                End If

'            End If
'        Else
'            myParent.toolBtnModifyPrj.Enabled = False

'        End If
'    Else
'        myParent.toolbtnNewProj.Enabled = False
'        myParent.toolBtnOpenPrj.Enabled = False
'    End If




'    'remvoe these later
'    'myParent.toolBtnModifyPrj.Enabled = True
'    'myParent.toolBtnParam.Enabled = True
'    'myParent.toolBtnLoad.Enabled = True
'    'myParent.toolBtnBearing.Enabled = True
'End Sub

