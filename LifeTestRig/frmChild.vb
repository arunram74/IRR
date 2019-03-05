Public Class frmChild



    Public Sub frmChild_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        Me.Width = 1435
        Me.Height = 644


    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub frmChild_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim frmHeight As Integer = frmMain.pnlBtm.Top - frmMain.toolStrp.Height
        'Dim frmWidth As Integer = frmMain.Width
        'Me.Width = frmWidth - 20
        'Me.Height = frmHeight - 4

        Me.Left = 0
        Me.Top = 0
        Me.Width = 1435
        Me.Height = 644


        'btnCancel.Left = Me.Width - btnCancel.Width - 30
        'btnOK.Left = btnCancel.Left - btnOK.Width - 20

        'btnCancel.Top = Me.Height - btnCancel.Height - 45
        'btnOK.Top = btnCancel.Top

    End Sub
End Class