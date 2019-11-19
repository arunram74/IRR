Public Class frmTest
    Private Sub frmTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub RoundButton1_Click(sender As Object, e As EventArgs) Handles RoundButton1.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If LedBulb3.On Then
            LedBulb3.On = False
            LedBulb3.Refresh()
        Else
            LedBulb3.On = True
        End If
    End Sub

    Private Sub RoundButton2_Click(sender As Object, e As EventArgs) Handles RoundButton2.Click

    End Sub
End Class
