Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class frmSuspFail

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub rndBtnSuspend_Click(sender As Object, e As EventArgs) Handles rndBtnSuspend.Click
        Station.MC.myProj.Init()
        Me.Close()
    End Sub

    Private Sub rndBtnFailed_Click(sender As Object, e As EventArgs) Handles rndBtnFailed.Click
        Dim str As String = InputBox("Please Enter the reason for failure")
        If str <> "" Then
            Station.MC.myProj.FailTest(str)
            Station.MC.myProj.Init()
            Me.Close()
        End If
    End Sub
End Class
