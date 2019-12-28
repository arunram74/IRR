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
        Dim constr As String
        constr = "SELECT alarmlog.AlarmNo, alarmlog.alarmid, reasondb.reasontxt, alarmlog.Logtime, Alarmlog.ProjectIDtxt, Alarmlog.HeadName, AlarmLog.MachineName from AlarmLog inner join reasondb on Alarmlog.AlarmId = reasondb.reasonid Order by AlarmNo Desc Limit 100;"
        If GetDataMySQL(con, adp, ds, dt, False, constr) Then dgvAlarm.DataSource = dt

    End Sub

    Private Sub dgvAlarm_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgvAlarm.RowPrePaint
        If dgvAlarm.Rows.Count > 0 Then
            If Not IsDBNull(dgvAlarm.Rows(e.RowIndex).Cells("alarmid").Value) Then
                If dgvAlarm.Rows(e.RowIndex).Cells("alarmid").Value > 64 Then
                    dgvAlarm.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
                ElseIf dgvAlarm.Rows(e.RowIndex).Cells("alarmid").Value > 0 And dgvAlarm.Rows(e.RowIndex).Cells("alarmid").Value < 64 Then
                    dgvAlarm.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
                End If
            End If
        End If
    End Sub



End Class
