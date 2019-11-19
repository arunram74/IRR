Imports System.Windows.Forms

Public Class frmRunSusp
    Public TestResult As Integer = 0 '1 if completed or suspended. 2 if fail
    Public HeadPairBonded As Boolean = False


    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmTestComplete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Station.MC.myProj.MyStatus = ProjectCls.ProjectStatus.Run Or Station.MC.myProj.MyStatus = ProjectCls.ProjectStatus.Load Then rndBtnRun.Enabled = False Else rndBtnRun.Enabled = True
        If Station.MC.myProj.MyStatus <> ProjectCls.ProjectStatus.Run And Station.MC.myProj.MyStatus <> ProjectCls.ProjectStatus.Load Then
            rndBtnSuspend.Enabled = False
        Else
            rndBtnSuspend.Enabled = True
        End If


        Me.DoubleBuffered = True
        Me.FormBorderStyle = FormBorderStyle.None
        Dim p As New Drawing2D.GraphicsPath()
        p.StartFigure()
        p.AddArc(New Rectangle(0, 0, 40, 40), 180, 90)
        p.AddLine(40, 0, Me.Width - 40, 0)
        p.AddArc(New Rectangle(Me.Width - 40, 0, 40, 40), -90, 90)
        p.AddLine(Me.Width, 40, Me.Width, Me.Height - 40)
        p.AddArc(New Rectangle(Me.Width - 40, Me.Height - 40, 40, 40), 0, 90)
        p.AddLine(Me.Width - 40, Me.Height, 40, Me.Height)
        p.AddArc(New Rectangle(0, Me.Height - 40, 40, 40), 90, 90)
        p.CloseFigure()
        Me.Region = New Region(p)
        Me.Hide()

    End Sub



    Private Sub rndBtnFailed_Click(sender As Object, e As EventArgs)
        If Station.MC.myProj.ProjectID <> 0 Then
            Dim str As String = InputBox("Please Enter the reason for Failure")
            If str <> "" Then
                Station.MC.myProj.FailTest(str)
            End If
            Me.Close()
        End If
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
        Station.MC.myProj.IsPairBonded = HeadPairBonded


        If Station.MC.myProj.StartTest() Then

        Else
            MessageBox.Show("Station Not Ready", "Start Station", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Me.Close()
    End Sub



    Private Sub Label3_Paint(sender As Object, e As PaintEventArgs) Handles Label3.Paint
        Dim p As New Pen(Color.Black)
        e.Graphics.DrawRectangle(p, 0, 0, Label3.Width - 5, Label3.Height - 5, 10)
    End Sub
End Class
