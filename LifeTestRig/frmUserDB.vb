Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Public Class frmUserDB

    Dim con As MySqlConnection = New MySqlConnection(serv)
    Dim adp As MySqlDataAdapter
    Dim ds As DataTable
    Dim cb As MySqlCommandBuilder

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            'save changes
            DataGridView1.EndEdit()
            adp.Update(ds)
        Catch ex As Exception
            MessageBox.Show("Database:error is:" & ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmUserDB_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        Label1.Text = "User Level - " & vbCrLf & "1 - Admin" & vbCrLf & "2 - User"
        DataGridView1.Columns.Clear()

        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            adp = New MySqlDataAdapter("SELECT idUserDB,UserName,Password, UserLevel FROM  userDB", con) 'idUserDB should be available for updating the modifed records
            ds = New DataTable
            adp.Fill(ds)

            cb = New MySqlCommandBuilder(adp) 'to make the ds updatable

            DataGridView1.DataSource = ds
            DataGridView1.Columns(0).Visible = False
            con.Close()
            con.Dispose()

        Catch ex As Exception
            MessageBox.Show("Database:error is:" & ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try


    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs) Handles DataGridView1.ColumnAdded
        Dim i = 1
    End Sub
End Class
