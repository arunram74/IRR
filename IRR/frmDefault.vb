Imports System.ComponentModel
Imports IRR

Public Class frmDefault
    Dim WithEvents H1, H2, H3, H4 As HeadDisplay

    Dim WithEvents Tmr As New Timer

    Dim frmRun As frmRunSusp


    Dim myParent As frmMain

    Private Sub frmDefault_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myParent = MdiParent
        myParent.toolbtnNewProj.Enabled = False
        myParent.toolBtnOpenPrj.Enabled = False
        myParent.toolBtnModifyPrj.Enabled = False
        Tmr.Interval = 100



        'Me.ToolTip1.SetToolTip(Me.TransPicH1, "WARNING!  This will permanently delete the" & Environment.NewLine & "current record being displayed.")

    End Sub


    Private Sub frmDefault_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        H1 = New HeadDisplay(ledRunH1, ledIdleH1, ledLoadH1, ledStopH1, lblStatusH1, lblBearingNoHA, chkHeadA, TransPicH1, Panel1, Panel6, "A")
        H2 = New HeadDisplay(ledRunH2, ledIdleH2, ledLoadH2, ledStopH2, lblStatusH2, lblBearingNoHB, chkHeadB, TransPicH2, Panel2, Panel7, "B")
        H3 = New HeadDisplay(ledRunH3, ledIdleH3, ledLoadH3, ledStopH3, lblStatusH3, lblBearingNoHC, chkHeadC, TransPicH3, Panel3, Panel8, "C")
        H4 = New HeadDisplay(ledRunH4, ledIdleH4, ledLoadH4, ledStopH4, lblStatusH4, lblBearingNoHD, chkHeadD, TransPicH4, Panel4, Panel9, "D")

    End Sub

    Private Sub frmDefault_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        myParent.toolbtnNewProj.Enabled = False
        myParent.toolBtnOpenPrj.Enabled = False
        myParent.toolBtnModifyPrj.Enabled = False
        myParent.toolBtnComplete.Enabled = False

        My.Settings.Save()
    End Sub



    Private Sub H1_Click(sender As HeadDisplay, e As MouseEventArgs) Handles H1.Click

        UnselectAll()


        H1.Selected = True


        EnableDisable(Station.MC.myProj, Station.MC.myProj.MyStatus, Panel1.Location, e)
        Dim e1 As MouseEventArgs = New MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 0, 0, 0, 0)
        If e.Button = MouseButtons.Right Then H1_Click(H1, e1)

    End Sub

    Private Sub H2_Click(sender As HeadDisplay, e As MouseEventArgs) Handles H2.Click

        UnselectAll()


        H2.Selected = True


        EnableDisable(Station.MC.myProj, Station.MC.myProj.MyStatus, Panel2.Location, e)
        Dim e1 As MouseEventArgs = New MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 0, 0, 0, 0)
        If e.Button = MouseButtons.Right Then H2_Click(H2, e1)

    End Sub

    Private Sub H3_Click(sender As HeadDisplay, e As MouseEventArgs) Handles H3.Click

        UnselectAll()


        H3.Selected = True


        EnableDisable(Station.MC.myProj, Station.MC.myProj.MyStatus, Panel3.Location, e)
        Dim e1 As MouseEventArgs = New MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 0, 0, 0, 0)
        If e.Button = MouseButtons.Right Then H3_Click(H3, e1)

    End Sub

    Private Sub H4_Click(sender As HeadDisplay, e As MouseEventArgs) Handles H4.Click

        UnselectAll()


        H4.Selected = True


        EnableDisable(Station.MC.myProj, Station.MC.myProj.MyStatus, Panel4.Location, e)
        Dim e1 As MouseEventArgs = New MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 0, 0, 0, 0)
        If e.Button = MouseButtons.Right Then H4_Click(H4, e1)

    End Sub





    Sub UnselectAll()
        H1.Selected = False
        H2.Selected = False
        H3.Selected = False
        H4.Selected = False

    End Sub

    Sub EnableDisable(ProjectObj As ProjectCls, OtherHeadStatus As ProjectCls.ProjectStatus, StartPoint As Point, e As MouseEventArgs)

        If (ProjectObj.MyStatus = ProjectCls.ProjectStatus.Suspended Or ProjectObj.MyStatus = ProjectCls.ProjectStatus.Idle) And ProjectObj.ProjectID <> 0 Then
            myParent.toolBtnComplete.Enabled = True
        Else
            myParent.toolBtnComplete.Enabled = False
        End If

        If ProjectObj.ProjectID <> 0 Then myParent.toolBtnModifyPrj.Enabled = True Else myParent.toolBtnModifyPrj.Enabled = False

        If ProjectObj.ProjectID = 0 Then
            myParent.toolBtnOpenPrj.Enabled = True
            myParent.toolbtnNewProj.Enabled = True
        Else
            myParent.toolBtnOpenPrj.Enabled = False
            myParent.toolbtnNewProj.Enabled = False
        End If

        If e.Button = MouseButtons.Right And ProjectObj.ProjectID <> 0 Then

            frmRunSusp.Location = e.Location + StartPoint
            frmRunSusp.ShowDialog()

        End If

    End Sub

    Private Sub TmrRefresh_Tick(sender As Object, e As EventArgs) Handles TmrRefresh.Tick
        lblTestID.Text = Station.MC.myProj.TestID
        lblMakeHA.Text = Station.MC.myProj.Make
        lblPartNoHA.Text = Station.MC.myProj.PartNo
    End Sub

    Public Sub SendClick()
        Dim e As MouseEventArgs = New MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 0, 0, 0, 0)
        If H1.Selected Then H1_Click(H1, e)
        If H2.Selected Then H2_Click(H2, e)
        If H3.Selected Then H3_Click(H3, e)
        If H4.Selected Then H4_Click(H4, e)

    End Sub

    Private Sub rndBtnSuspend_Click(sender As Object, e As EventArgs) Handles rndBtnSuspend.Click
        If Station.MC.myProj.MyStatus = ProjectCls.ProjectStatus.Run Or Station.MC.myProj.MyStatus = ProjectCls.ProjectStatus.Load Then
            Dim str As String = InputBox("Please Enter the reason for suspension")
            If str <> "" Then
                Station.MC.myProj.StopReason = str
                Station.MC.myProj.MyStatus = ProjectCls.ProjectStatus.Suspended

            End If
            Me.Close()
        End If
    End Sub

    Private Sub rndBtnRun_Click(sender As Object, e As EventArgs) Handles rndBtnRun.Click
        frmMain.toolbtnNewProj.Enabled = False
        frmMain.toolBtnOpenPrj.Enabled = False
        frmMain.toolBtnModifyPrj.Enabled = False

        If Station.MC.myProj.StartTest() Then

        Else
            MessageBox.Show("Station Not Ready", "Start Station", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


    End Sub

End Class
