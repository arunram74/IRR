Imports System.ComponentModel
Imports System.IO
Imports System.Windows.Forms.DataVisualization.Charting
Imports MySql.Data.MySqlClient
Public Class frmLoad

    Dim con As MySqlConnection = New MySqlConnection(serv)
    Dim adp, adp2 As MySqlDataAdapter
    Dim ds As DataSet
    Dim dt1, dt2, dt3, dtchart As DataTable
    Dim cb As MySqlCommandBuilder
    Dim formshown As Boolean = False
    Dim TableName As String = "LoadSteps"

    Public ValuesChanged As Boolean = False

    Friend Event NextScreen(sender As Form, nxtScr As ChildForms)

    Private Sub frmProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ValuesChanged = False

        lblMcHead.Text = CurrentHead.myProj.MachineName & "H" & TempProjectObj.HeadName
        If CurrentHead.myProj.MyStatus = ProjectCls.ProjectStatus.Run Or CurrentHead.myProj.MyStatus = ProjectCls.ProjectStatus.Load Then Panel1.Enabled = False Else Panel1.Enabled = True
        If CurrentHead.myProj.isNew Then
            TableName = "LoadStepsTemp"
            Panel2.Enabled = True
        Else
            TableName = "LoadSteps"
            Panel2.Enabled = False
        End If

        'If TempProjectObj.MachineSize = 5 Then
        nupEndLoad.Maximum = 32000
            'Else
            '    nupEndLoad.Maximum = 24000
            'End If

            UpdateTemplateList()
        LoadProjectInfo()
        AllowOnlyNumbers(Me)
    End Sub

    'Sub LoadProfileNames()

    '    Dim constr As String = "SELECT idProfile, ProfileName from Profile "
    '    If GetDataMySQL(con, adp, ds, dt1, False, constr) Then
    '        cmbProfile.DataSource = dt1
    '        cmbProfile.DisplayMember = "ProfileName"
    '        cmbProfile.ValueMember = "idProfile"
    '    End If

    'End Sub

    Sub LoadValues()
        Dim i As Integer
        Dim constr As String = "SELECT * from " & TableName & " where ProjectID=" & TempProjectObj.ProjectID & " Order by idLoadSteps"
        If GetDataMySQL(con, adp, ds, dt2, False, constr) Then
            bndSrcLoad.DataSource = dt2
            dgvLoad.DataSource = bndSrcLoad
            dgvLoad.Columns(0).Visible = False
            For i = 0 To dgvLoad.Columns.Count - 1 'disable sorting
                dgvLoad.Columns.Item(i).SortMode = DataGridViewColumnSortMode.Programmatic
            Next i

            If dt2.Rows.Count > 0 Then
                dgvLoad.Rows(0).Cells(1).Selected = True
                Dim e As DataGridViewCellEventArgs
                DataGridView1_CellClick(dgvLoad, e)
            End If

        End If

        UpdateGraph()

        ' Next
    End Sub

    Sub UpdateGraph()
        dtchart = New DataTable
        dtchart.Columns.Add("Load")
        dtchart.Columns.Add("Duration")

        If dt2.Rows.Count > 0 Then
            Dim StartDur As New TimeSpan
            StartDur = TimeSpan.Parse("00:00:00")
            dtchart.Rows.Add(dt2.Rows(0).Item("StartLoad"), StartDur)
            For i = 0 To dt2.Rows.Count - 1
                StartDur += dt2.Rows(i).Item("LoadDuration")
                dtchart.Rows.Add(dt2.Rows(i).Item("EndLoad"), StartDur)
                StartDur += dt2.Rows(i).Item("RunDuration")
                dtchart.Rows.Add(dt2.Rows(i).Item("EndLoad"), StartDur)
            Next i
        End If

        graphLoad.DataSource = dtchart
        graphLoad.ChartAreas(0).AxisX.Interval = 1
        graphLoad.Series.Clear()
        ' For i = 1 To dtchart.Columns.Count - 1
        Dim series As Series = New Series()
        series.XValueType = ChartValueType.Time
        series.XValueMember = dtchart.Columns(1).ColumnName
        series.YValueMembers = dtchart.Columns(0).ColumnName
        series.ChartType = SeriesChartType.Line
        series.IsVisibleInLegend = True
        series.IsValueShownAsLabel = True
        series.BorderWidth = 3
        series.LegendText = "Load"
        graphLoad.Series.Add(series)
    End Sub

    Private Sub cmbProfile_SelectedIndexChanged(sender As Object, e As EventArgs)
        If formshown Then
            LoadValues()
        End If
    End Sub

    Private Sub btnAddNewRow_Click(sender As Object, e As EventArgs) Handles btnAddNewRow.Click
        Dim NoofRows As Integer = 0
        Dim StartLoad As Single = 0
        Dim rundur, LoadDur As TimeSpan

        If MessageBox.Show("The Loadsteps will be changed. Do you want to Proceed?", "Load", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        'The project ID should not exist in LoadStep DB
        If CurrentHead.myProj.isNew Then
            Dim constr As String = "SELECT * from LoadSteps where ProjectID=" & TempProjectObj.ProjectID & " Order by idLoadSteps"
            GetDataMySQL(con, adp2, ds, dt3, False, constr)
            If dt3.Rows.Count > 0 Then
                MessageBox.Show("Choose a different Project ID In Project Values", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If

        NoofRows = dgvLoad.Rows.Count
        If NoofRows > 1 Then
            StartLoad = dgvLoad.Rows(NoofRows - 1).Cells(3).Value  'get the last end load
        End If

        LoadDur = TimeSpan.Parse(nupHr.Value & ":" & nupMin.Value & ":" & nupSec.Value)
        rundur = TimeSpan.Parse(nupRunHr.Value & ":" & nupRunMin.Value & ":" & nupRunSec.Value)

        'create a new record
        Using SQLConnection As New MySqlConnection(serv)
            Using sqlCommand As New MySqlCommand()
                With sqlCommand
                    .CommandText = "INSERT INTO " & TableName & " (`ProjectID`,  `StartLoad`, `EndLoad`, `LoadDuration`, `RunDuration`, `StepNo`) values (@pid,@strtLoad,@endld,@lddur,@rundur, @stpno )"
                    .Connection = SQLConnection
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@pid", TempProjectObj.ProjectID)
                    .Parameters.AddWithValue("@strtLoad", StartLoad)
                    .Parameters.AddWithValue("@endld", nupEndLoad.Value)
                    .Parameters.AddWithValue("@lddur", LoadDur)
                    .Parameters.AddWithValue("@rundur", rundur)
                    .Parameters.AddWithValue("@stpno", NoofRows + 1)
                End With
                Try
                    SQLConnection.Open()
                    sqlCommand.ExecuteNonQuery()
                Catch ex As MySqlException
                    MessageBox.Show(ex.Message.ToString, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    SQLConnection.Close()
                End Try
            End Using
        End Using

        ValuesChanged = True
        LoadValues()
    End Sub


    Private Sub frmProfile_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        LoadValues()
        formshown = True
    End Sub

    Private Sub btnClearRow_Click(sender As Object, e As EventArgs) Handles btnClearRow.Click
        'txtCurStp.Text = DataGridView1.CurrentRow.Cells(2).Value

        If MessageBox.Show("The selected load step will be cleared. Do you want to Proceed?", "Load", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
        nupEndLoad.Value = 0
        nupRunMin.Value = 0
        nupHr.Value = 0
        nupMin.Value = 0
        nupSec.Value = 0

        Dim t As TimeSpan
        Dim i As Integer
        i = dgvLoad.CurrentRow.Index
        If i = 0 Then
            dgvLoad.CurrentRow.Cells(2).Value = 0
        Else
            dgvLoad.CurrentRow.Cells(2).Value = dgvLoad.Rows(i - 1).Cells(3).Value
        End If

        dgvLoad.CurrentRow.Cells(3).Value = nupEndLoad.Value
        t = TimeSpan.Parse(nupRunHr.Value & ":" & nupRunMin.Value & ":" & nupRunSec.Value)
        dgvLoad.CurrentRow.Cells(5).Value = t

        t = TimeSpan.Parse(nupHr.Value & ":" & nupMin.Value & ":" & nupSec.Value)
        dgvLoad.CurrentRow.Cells(4).Value = t

        ValuesChanged = True
    End Sub

    Private Sub btnDeleteRow_Click(sender As Object, e As EventArgs) Handles btnDeleteRow.Click
        ' Dim i As Integer
        If MessageBox.Show("Do you want to delete last row ?", "Delete", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            dgvLoad.Rows.RemoveAt(dgvLoad.Rows.Count - 1)

            Try
                'save changes
                cb = New MySqlCommandBuilder(adp) 'to make the ds updatable
                'bndSrcLoad.EndEdit() ' Somehow this updates datatable
                adp.Update(dt2)
            Catch ex As Exception
                MessageBox.Show("Database:error is:" & ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
            UpdateGraph()

            If dt2.Rows.Count > 0 Then
                dgvLoad.Rows(dgvLoad.Rows.Count - 1).Cells(1).Selected = True
                Dim ev As DataGridViewCellEventArgs
                DataGridView1_CellClick(dgvLoad, ev)
            End If
        End If

        ValuesChanged = True
    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLoad.CellClick
        Dim t As TimeSpan
        dgvLoad.CurrentRow.Selected = True

        nupEndLoad.Value = dgvLoad.CurrentRow.Cells(3).Value
        t = dgvLoad.CurrentRow.Cells(5).Value
        nupRunHr.Value = t.Hours
        nupRunMin.Value = t.Minutes
        nupRunSec.Value = t.Seconds
        t = dgvLoad.CurrentRow.Cells(4).Value
        nupHr.Value = t.Hours
        nupMin.Value = t.Minutes
        nupSec.Value = t.Seconds
        txtCurStp.Text = dgvLoad.CurrentRow.Cells(6).Value

        If dgvLoad.CurrentRow.Index = (dgvLoad.Rows.Count - 1) Then
            nupRunHr.Enabled = False
            nupRunMin.Enabled = False
            nupRunSec.Enabled = False
        Else
            nupRunHr.Enabled = True
            nupRunMin.Enabled = True
            nupRunSec.Enabled = True
        End If
    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        Me.Close()
    End Sub

    Private Sub btnUpdateRow_Click(sender As Object, e As EventArgs) Handles btnUpdateRow.Click
        Dim t As TimeSpan

        If MessageBox.Show("The selected load step will be updated. Do you want to Proceed?", "Load", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        '        DataGridView1.CurrentRow.Cells(3).Value = 0
        dgvLoad.CurrentRow.Cells(3).Value = nupEndLoad.Value
        t = TimeSpan.Parse(nupRunHr.Value & ":" & nupRunMin.Value & ":" & nupRunSec.Value)
        dgvLoad.CurrentRow.Cells(5).Value = t

        t = TimeSpan.Parse(nupHr.Value & ":" & nupMin.Value & ":" & nupSec.Value)
        dgvLoad.CurrentRow.Cells(4).Value = t
        Try
            'save changes
            cb = New MySqlCommandBuilder(adp) 'to make the ds updatable
            bndSrcLoad.EndEdit() ' Somehow this updates datatable
            adp.Update(dt2)
        Catch ex As Exception
            MessageBox.Show("Database:error is:" & ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        LoadValues()
        ValuesChanged = True

    End Sub

    Sub LoadProjectInfo()
        lblMachine.Text = TempProjectObj.MachineName
        lblPrjID.Text = TempProjectObj.ProjectIDTxt

        lblCup.Text = TempProjectObj.CupNo
        lblCone.Text = TempProjectObj.ConeNo
        lblTestType.Text = TempProjectObj.TestType

        lblBearingType.Text = TempProjectObj.BearingType
        lblPV.Text = TempProjectObj.PVNo

        lblB1.Text = TempProjectObj.B1Name
        lblB2.Text = TempProjectObj.B2Name
        lblB3.Text = TempProjectObj.B3Name
        lblB4.Text = TempProjectObj.B4Name
    End Sub

    Private Sub Bordergray(sender As Object, e As PaintEventArgs) Handles lblMachine.Paint, lblPrjID.Paint, lblPV.Paint, lblCup.Paint, lblCone.Paint, lblTestType.Paint, lblBearingType.Paint, lblB1.Paint, lblB2.Paint, lblB3.Paint, lblB4.Paint, PictureBox7.Paint
        ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.LightGray, ButtonBorderStyle.Solid)
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCopyFromTemplate.Click
        CopyFromTemplate(cmbTemplates.SelectedItem.ToString & ".txt")
        ValuesChanged = True
    End Sub

    Sub UpdateTemplateList()
        ' Dim filters As String() = {"*.mp3", "*.docx", "*.bmp", "*.txt"}
        Dim filters As String() = {"*.txt", "*.csv"}


        Dim foundFiles As List(Of IO.FileInfo) = SearchAndAddToListWithFilter(Templatepath & "Load\", filters, True)
        cmbTemplates.Items.Clear()
        For Each itm In foundFiles
            cmbTemplates.Items.Add(itm.Name.Substring(0, itm.Name.Length - 4))
        Next
        If cmbTemplates.Items.Count > 0 Then cmbTemplates.SelectedIndex = 0
    End Sub

    Private Sub btnopnTmpLoc_Click(sender As Object, e As EventArgs) Handles btnopnTmpLoc.Click
        Process.Start(Templatepath & "load\")
    End Sub

    Sub CopyFromTemplate(Filename As String)

        Dim SQLConnection As New MySqlConnection(serv)
        Dim sqlCommand As New MySqlCommand()



        Try
            Dim SR As StreamReader = New StreamReader(Templatepath & "load\" & Filename)
            Dim line As String
            Dim strArray As String()
            Dim StartLoadVal As Single = 0

            line = SR.ReadLine 'read header
            line = SR.ReadLine 'read the content

            sqlCommand.CommandType = CommandType.Text
            sqlCommand.Connection = SQLConnection
            SQLConnection.Open()

            sqlCommand.CommandText = "Delete from LoadStepsTemp" 'Empty Temporary Table
            sqlCommand.ExecuteNonQuery()

            sqlCommand.CommandText = "INSERT INTO LoadStepsTemp (`ProjectID`,  `StartLoad`, `EndLoad`,  `LoadDuration`, `RunDuration`, `StepNo`) values (@pid,@strtLoad,@endld,@lddur,@rundur,@stpno )"

            Do
                If Not line = String.Empty Then
                    strArray = line.Split(","c)
                    sqlCommand.Parameters.AddWithValue("@pid", TempProjectObj.ProjectID)
                    sqlCommand.Parameters.AddWithValue("@strtLoad", StartLoadVal)
                    sqlCommand.Parameters.AddWithValue("@endld", strArray(1))
                    sqlCommand.Parameters.AddWithValue("@lddur", strArray(2))
                    sqlCommand.Parameters.AddWithValue("@rundur", strArray(3))
                    sqlCommand.Parameters.AddWithValue("@stpno", strArray(4))

                    StartLoadVal = strArray(1) 'Start load=End load of previous step

                    sqlCommand.ExecuteNonQuery()

                    sqlCommand.Parameters.Clear()
                    line = SR.ReadLine 'read the next line
                Else
                    Exit Do
                End If
            Loop


        Catch ex As MySqlException
            MessageBox.Show(ex.Message.ToString, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLConnection.Close()
        End Try

        LoadValues()
    End Sub

    Private Sub frmLoad_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If ValuesChanged Then Me.DialogResult = DialogResult.Yes Else Me.DialogResult = DialogResult.No
    End Sub
End Class
