Imports System.ComponentModel
Imports MySql.Data.MySqlClient
Public Class frmAlarms
    Dim con As MySqlConnection = New MySqlConnection(serv)
    Dim dt As DataTable
    Dim ds As DataSet
    Dim adp As MySqlDataAdapter
    Dim RowNo As Integer = 0
    WithEvents dgr As DataGridViewRowCollection
    Private Sub frmAlarms_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbMC1.Text = Station.MC1.mMachineName
        rbMC2.Text = Station.MC2.mMachineName
        rbMC3.Text = Station.MC3.mMachineName
        rbMC4.Text = Station.MC4.mMachineName
        rbMC1.Checked = True


    End Sub

    Private Sub dgvAlarm_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgvAlarm.RowPrePaint
        If dgvAlarm.Rows.Count > 0 Then
            If Not IsDBNull(dgvAlarm.Rows(e.RowIndex).Cells("alarmid").Value) Then
                If dgvAlarm.Rows(e.RowIndex).Cells("alarmid").Value > 32 Then
                    dgvAlarm.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
                ElseIf dgvAlarm.Rows(e.RowIndex).Cells("alarmid").Value > 0 And dgvAlarm.Rows(e.RowIndex).Cells("alarmid").Value < 33 Then
                    dgvAlarm.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
                End If
            End If
        End If
    End Sub


    Private Sub rbMC2_CheckedChanged(sender As Object, e As EventArgs) Handles rbMC1.CheckedChanged, rbMC1.CheckedChanged, rbMC3.CheckedChanged, rbMC4.CheckedChanged

        Dim StnName As String = ""
        If rbMC1.Checked Then
            StnName = Station.MC1.mMachineName
        ElseIf rbMC2.Checked Then
            StnName = Station.MC2.mMachineName
        ElseIf rbMC3.Checked Then
            StnName = Station.MC3.mMachineName
        ElseIf rbMC4.Checked Then
            StnName = Station.MC4.mMachineName
        End If

        Dim constr As String
        constr = "SELECT alarmlog.AlarmNo, alarmlog.alarmid, reasondb.reasontxt, alarmlog.Logtime, Alarmlog.ProjectIDtxt, Alarmlog.HeadName, AlarmLog.MachineName from AlarmLog inner join reasondb on Alarmlog.AlarmId = reasondb.reasonid where AlarmLog.MachineName ='" & StnName & "' Order by AlarmNo Desc Limit 100;"
        If GetDataMySQL(con, adp, ds, dt, False, constr) Then dgvAlarm.DataSource = dt
    End Sub

End Class
