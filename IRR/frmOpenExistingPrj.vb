Imports System.Windows.Forms

Imports MySql.Data.MySqlClient
Public Class frmOpenExistingPrj

    Dim con As MySqlConnection = New MySqlConnection(serv)
    Dim adp As MySqlDataAdapter
    Dim ds As DataSet
    Dim dt1, dt2 As DataTable
    Dim cb As MySqlCommandBuilder
    Dim formshown As Boolean = False

    Public PrjID As String = ""


    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        PrjID = DataGridView1.CurrentRow.Cells(0).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmOpenExistingPrj_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadValues()
    End Sub

    Sub LoadValues()
        Dim i As Integer
        'Dim constr As String = "SELECT ProjectID, Concat(ProjectIDTxt,'_',B1Name,'_',B2Name,'_',B3Name,'_',B4Name) as  PRJECTID, MACHINENAME, PROJECTNAME, CUPNO, CONENO, CREATEDDATE, TERMINATEDDATE from Project where ProjectStatus <> " & ProjectCls.ProjectStatus.Failure &
        Dim constr As String = "SELECT ProjectID, ProjectIdTxt as TEST_ID, PROJECTNAME, MAKE, PARTNO, CREATEDDATE, TERMINATEDDATE from Project where ProjectStatus <> " & ProjectCls.ProjectStatus.Failure &
        " and ProjectID<>" & Station.MC.myProj.ProjectID &
                " Order by ProjectIDTxt"

        If GetDataMySQL(con, adp, ds, dt2, False, constr) Then
            bndSrcPrj.DataSource = dt2
            DataGridView1.DataSource = bndSrcPrj
            DataGridView1.Columns(0).Visible = False
            For i = 1 To DataGridView1.Columns.Count - 1 'disable sorting
                DataGridView1.Columns.Item(i).SortMode = DataGridViewColumnSortMode.Programmatic
            Next i
        End If

    End Sub
End Class
