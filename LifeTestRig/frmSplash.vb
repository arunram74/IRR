Public Class frmSplash
    Private Sub frmSplash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        tmrProgress.Enabled = True

    End Sub

    Private Sub tmrProgress_Tick(sender As Object, e As EventArgs) Handles tmrProgress.Tick
        prgressLoad.Visible = True
        prgressLoad.Value = prgressLoad.Value + 2
        lblProgress.Text = prgressLoad.Value & " % Loading please wait... "
        If (prgressLoad.Value = 10) Then
            lblMsg.Text = "Reading modules..."
        ElseIf (prgressLoad.Value = 20) Then
            lblMsg.Text = "Turning on modules."
        ElseIf (prgressLoad.Value = 40) Then
            lblMsg.Text = "Starting modules."
        ElseIf (prgressLoad.Value = 60) Then
            lblMsg.Text = "Loading modules."
        ElseIf (prgressLoad.Value = 80) Then
            lblMsg.Text = "Modules loading completed."
        ElseIf (prgressLoad.Value = 100) Then
            tmrProgress.Enabled = False
            lblProgress.Text = "Loading completed."
            Me.Hide()
            prgressLoad.Value = 0
        End If
    End Sub
End Class