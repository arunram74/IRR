Imports System.ComponentModel
Imports System.IO
Imports MySql.Data.MySqlClient
Public Class frmPrjt

    Dim con As MySqlConnection = New MySqlConnection(serv)
    Dim daPrj, daProf As MySqlDataAdapter
    Dim ds As DataSet
    Dim dt1, dt2, dt3 As DataTable
    Dim cb As MySqlCommandBuilder
    Dim formshown As Boolean = False
    Dim profileID As Integer
    Dim ValuesChanged As Boolean = False
    Friend Event NextScreen(sender As Form, nxtScr As ChildForms)

    Private Sub frmPrjt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ValuesChanged = False
        CopytoTemp()
        lblMcHead.Text = TempProjectObj.MachineName & "H" & TempProjectObj.HeadName
        UpdateTemplateList()
        LoadProjectDetails()
        If TempProjectObj.ProjectID <> 0 Then
            ''btnReturn.Enabled = false
            txtPrjId.Enabled = False
            txtOwner.Enabled = False
            txtPrjName.Enabled = False
            txtBearingCount.Enabled = False
            txtCup.Enabled = False
            txtCone.Enabled = False
            cmbBearingType.Enabled = False
            cmbMachineType.Enabled = False
            cmbTestType.Enabled = False
            txtPV.Enabled = False

            txtB1.Enabled = False
            txtB2.Enabled = False
            txtB3.Enabled = False
            txtB4.Enabled = False
            Panel1.Enabled = False
            btnCopyFromTemplate.Enabled = False
        Else
            '' btnReturn.Enabled = True
            txtPrjId.Enabled = True

            txtOwner.Enabled = True
            txtPrjName.Enabled = True
            txtBearingCount.Enabled = True
            txtCup.Enabled = True
            txtCone.Enabled = True
            cmbBearingType.Enabled = True
            cmbMachineType.Enabled = True
            cmbTestType.Enabled = True
            txtPV.Enabled = True

            txtB1.Enabled = True
            txtB2.Enabled = True
            txtB3.Enabled = True
            txtB4.Enabled = True
            Panel1.Enabled = True
            btnCopyFromTemplate.Enabled = True
        End If

        If CurrentHead.myProj.MyStatus = ProjectCls.ProjectStatus.Run Or CurrentHead.myProj.MyStatus = ProjectCls.ProjectStatus.Load Then
            Panel1.Enabled = False
        Else
            Panel1.Enabled = True
        End If

        For Each txtBox In Me.Controls.OfType(Of TextBox)()
            txtBox.Modified = False
        Next

    End Sub

    Sub CopytoTemp()

        TempProjectObj.ProjectIDTxt = CurrentHead.myProj.ProjectIDTxt
        TempProjectObj.ProjectOwner = CurrentHead.myProj.ProjectOwner
        TempProjectObj.ProjectName = CurrentHead.myProj.ProjectName
        TempProjectObj.BearingCount = CurrentHead.myProj.BearingCount
        TempProjectObj.CupNo = CurrentHead.myProj.CupNo
        TempProjectObj.ConeNo = CurrentHead.myProj.ConeNo
        TempProjectObj.TestType = CurrentHead.myProj.TestType
        TempProjectObj.MachineSize = CurrentHead.myProj.MachineSize
        TempProjectObj.BearingType = CurrentHead.myProj.BearingType
        TempProjectObj.PVNo = CurrentHead.myProj.PVNo
        TempProjectObj.B1Name = CurrentHead.myProj.B1Name
        TempProjectObj.B2Name = CurrentHead.myProj.B2Name
        TempProjectObj.B3Name = CurrentHead.myProj.B3Name
        TempProjectObj.B4Name = CurrentHead.myProj.B4Name
        TempProjectObj.MachineName = CurrentHead.myProj.MachineName
        TempProjectObj.HeadName = CurrentHead.myProj.HeadName
        TempProjectObj.ProjectID = CurrentHead.myProj.ProjectID

        TempProjectObj.B1.WH = CurrentHead.myProj.B1.WH
        TempProjectObj.B1.WL = CurrentHead.myProj.B1.WL
        TempProjectObj.B1.SH = CurrentHead.myProj.B1.SH
        TempProjectObj.B1.SL = CurrentHead.myProj.B1.SL
        TempProjectObj.B1.Bypass = CurrentHead.myProj.B1.Bypass

        TempProjectObj.B2.WH = CurrentHead.myProj.B2.WH
        TempProjectObj.B2.WL = CurrentHead.myProj.B2.WL
        TempProjectObj.B2.SH = CurrentHead.myProj.B2.SH
        TempProjectObj.B2.SL = CurrentHead.myProj.B2.SL
        TempProjectObj.B2.Bypass = CurrentHead.myProj.B2.Bypass

        TempProjectObj.B3.WH = CurrentHead.myProj.B3.WH
        TempProjectObj.B3.WL = CurrentHead.myProj.B3.WL
        TempProjectObj.B3.SH = CurrentHead.myProj.B3.SH
        TempProjectObj.B3.SL = CurrentHead.myProj.B3.SL
        TempProjectObj.B3.Bypass = CurrentHead.myProj.B3.Bypass

        TempProjectObj.B4.WH = CurrentHead.myProj.B4.WH
        TempProjectObj.B4.WL = CurrentHead.myProj.B4.WL
        TempProjectObj.B4.SH = CurrentHead.myProj.B4.SH
        TempProjectObj.B4.SL = CurrentHead.myProj.B4.SL
        TempProjectObj.B4.Bypass = CurrentHead.myProj.B4.Bypass

        TempProjectObj.Vibration.WH = CurrentHead.myProj.Vibration.WH
        TempProjectObj.Vibration.WL = CurrentHead.myProj.Vibration.WL
        TempProjectObj.Vibration.SH = CurrentHead.myProj.Vibration.SH
        TempProjectObj.Vibration.SL = CurrentHead.myProj.Vibration.SL
        TempProjectObj.Vibration.Bypass = CurrentHead.myProj.Vibration.Bypass

        TempProjectObj.OutTankTemp.WH = CurrentHead.myProj.OutTankTemp.WH
        TempProjectObj.OutTankTemp.WL = CurrentHead.myProj.OutTankTemp.WL
        TempProjectObj.OutTankTemp.SH = CurrentHead.myProj.OutTankTemp.SH
        TempProjectObj.OutTankTemp.SL = CurrentHead.myProj.OutTankTemp.SL
        TempProjectObj.OutTankTemp.Bypass = CurrentHead.myProj.OutTankTemp.Bypass

        TempProjectObj.InTankTemp.WH = CurrentHead.myProj.InTankTemp.WH
        TempProjectObj.InTankTemp.WL = CurrentHead.myProj.InTankTemp.WL
        TempProjectObj.InTankTemp.SH = CurrentHead.myProj.InTankTemp.SH
        TempProjectObj.InTankTemp.SL = CurrentHead.myProj.InTankTemp.SL
        TempProjectObj.InTankTemp.Setpoint = CurrentHead.myProj.InTankTemp.Setpoint
        TempProjectObj.InTankTemp.Bypass = CurrentHead.myProj.InTankTemp.Bypass

        TempProjectObj.Load.WH = CurrentHead.myProj.Load.WH
        TempProjectObj.Load.WL = CurrentHead.myProj.Load.WL
        TempProjectObj.Load.SH = CurrentHead.myProj.Load.SH
        TempProjectObj.Load.SL = CurrentHead.myProj.Load.SL
        TempProjectObj.Load.Bypass = CurrentHead.myProj.Load.Bypass

        TempProjectObj.Speed.WH = CurrentHead.myProj.Speed.WH
        TempProjectObj.Speed.WL = CurrentHead.myProj.Speed.WL
        TempProjectObj.Speed.SH = CurrentHead.myProj.Speed.SH
        TempProjectObj.Speed.SL = CurrentHead.myProj.Speed.SL
        TempProjectObj.Speed.Setpoint = CurrentHead.myProj.Speed.Setpoint
        TempProjectObj.Speed.Bypass = CurrentHead.myProj.Speed.Bypass

        TempProjectObj.MaxRev = CurrentHead.myProj.MaxRev
        TempProjectObj.MaxRevActive = CurrentHead.myProj.MaxRevActive

        TempProjectObj.LoadLogRate = CurrentHead.myProj.LoadLogRate


        TempProjectObj.RunLogRate = CurrentHead.myProj.RunLogRate


        TempProjectObj.DispUpdateRate = CurrentHead.myProj.DispUpdateRate



    End Sub

    Sub CopyFromTemp()

        CurrentHead.myProj.ProjectIDTxt = TempProjectObj.ProjectIDTxt
        CurrentHead.myProj.ProjectOwner = TempProjectObj.ProjectOwner
        CurrentHead.myProj.ProjectName = TempProjectObj.ProjectName
        CurrentHead.myProj.BearingCount = TempProjectObj.BearingCount
        CurrentHead.myProj.CupNo = TempProjectObj.CupNo
        CurrentHead.myProj.ConeNo = TempProjectObj.ConeNo
        CurrentHead.myProj.TestType = TempProjectObj.TestType
        CurrentHead.myProj.MachineSize = TempProjectObj.MachineSize
        CurrentHead.myProj.BearingType = TempProjectObj.BearingType
        CurrentHead.myProj.PVNo = TempProjectObj.PVNo
        CurrentHead.myProj.B1Name = TempProjectObj.B1Name
        CurrentHead.myProj.B2Name = TempProjectObj.B2Name
        CurrentHead.myProj.B3Name = TempProjectObj.B3Name
        CurrentHead.myProj.B4Name = TempProjectObj.B4Name
        CurrentHead.myProj.MachineName = TempProjectObj.MachineName
        CurrentHead.myProj.HeadName = TempProjectObj.HeadName

        CurrentHead.myProj.B1.WH = TempProjectObj.B1.WH
        CurrentHead.myProj.B1.WL = TempProjectObj.B1.WL
        CurrentHead.myProj.B1.SH = TempProjectObj.B1.SH
        CurrentHead.myProj.B1.SL = TempProjectObj.B1.SL
        CurrentHead.myProj.B1.Bypass = TempProjectObj.B1.Bypass

        CurrentHead.myProj.B2.WH = TempProjectObj.B2.WH
        CurrentHead.myProj.B2.WL = TempProjectObj.B2.WL
        CurrentHead.myProj.B2.SH = TempProjectObj.B2.SH
        CurrentHead.myProj.B2.SL = TempProjectObj.B2.SL
        CurrentHead.myProj.B2.Bypass = TempProjectObj.B2.Bypass

        CurrentHead.myProj.B3.WH = TempProjectObj.B3.WH
        CurrentHead.myProj.B3.WL = TempProjectObj.B3.WL
        CurrentHead.myProj.B3.SH = TempProjectObj.B3.SH
        CurrentHead.myProj.B3.SL = TempProjectObj.B3.SL
        CurrentHead.myProj.B3.Bypass = TempProjectObj.B3.Bypass

        CurrentHead.myProj.B4.WH = TempProjectObj.B4.WH
        CurrentHead.myProj.B4.WL = TempProjectObj.B4.WL
        CurrentHead.myProj.B4.SH = TempProjectObj.B4.SH
        CurrentHead.myProj.B4.SL = TempProjectObj.B4.SL
        CurrentHead.myProj.B4.Bypass = TempProjectObj.B4.Bypass

        CurrentHead.myProj.Vibration.WH = TempProjectObj.Vibration.WH
        CurrentHead.myProj.Vibration.WL = TempProjectObj.Vibration.WL
        CurrentHead.myProj.Vibration.SH = TempProjectObj.Vibration.SH
        CurrentHead.myProj.Vibration.SL = TempProjectObj.Vibration.SL
        CurrentHead.myProj.Vibration.Bypass = TempProjectObj.Vibration.Bypass

        CurrentHead.myProj.OutTankTemp.WH = TempProjectObj.OutTankTemp.WH
        CurrentHead.myProj.OutTankTemp.WL = TempProjectObj.OutTankTemp.WL
        CurrentHead.myProj.OutTankTemp.SH = TempProjectObj.OutTankTemp.SH
        CurrentHead.myProj.OutTankTemp.SL = TempProjectObj.OutTankTemp.SL
        CurrentHead.myProj.OutTankTemp.Bypass = TempProjectObj.OutTankTemp.Bypass

        CurrentHead.myProj.InTankTemp.WH = TempProjectObj.InTankTemp.WH
        CurrentHead.myProj.InTankTemp.WL = TempProjectObj.InTankTemp.WL
        CurrentHead.myProj.InTankTemp.SH = TempProjectObj.InTankTemp.SH
        CurrentHead.myProj.InTankTemp.SL = TempProjectObj.InTankTemp.SL
        CurrentHead.myProj.InTankTemp.Setpoint = TempProjectObj.InTankTemp.Setpoint
        CurrentHead.myProj.InTankTemp.Bypass = TempProjectObj.InTankTemp.Bypass

        CurrentHead.myProj.Load.WH = TempProjectObj.Load.WH
        CurrentHead.myProj.Load.WL = TempProjectObj.Load.WL
        CurrentHead.myProj.Load.SH = TempProjectObj.Load.SH
        CurrentHead.myProj.Load.SL = TempProjectObj.Load.SL
        CurrentHead.myProj.Load.Bypass = TempProjectObj.Load.Bypass

        CurrentHead.myProj.Speed.WH = TempProjectObj.Speed.WH
        CurrentHead.myProj.Speed.WL = TempProjectObj.Speed.WL
        CurrentHead.myProj.Speed.SH = TempProjectObj.Speed.SH
        CurrentHead.myProj.Speed.SL = TempProjectObj.Speed.SL
        CurrentHead.myProj.Speed.Setpoint = TempProjectObj.Speed.Setpoint
        CurrentHead.myProj.Speed.Bypass = TempProjectObj.Speed.Bypass

        CurrentHead.myProj.MaxRev = TempProjectObj.MaxRev
        CurrentHead.myProj.MaxRevActive = TempProjectObj.MaxRevActive

        CurrentHead.myProj.LoadLogRate = TempProjectObj.LoadLogRate

        CurrentHead.myProj.RunLogRate = TempProjectObj.RunLogRate

        CurrentHead.myProj.DispUpdateRate = TempProjectObj.DispUpdateRate

    End Sub

    Sub UpdateProjectCls()
        TempProjectObj.ProjectIDTxt = txtPrjId.Text
        TempProjectObj.ProjectOwner = txtOwner.Text
        TempProjectObj.ProjectName = txtPrjName.Text
        TempProjectObj.BearingCount = If(String.IsNullOrEmpty(txtBearingCount.Text), 0, txtBearingCount.Text)
        TempProjectObj.CupNo = txtCup.Text
        TempProjectObj.ConeNo = txtCone.Text
        TempProjectObj.TestType = cmbTestType.Text
        TempProjectObj.MachineSize = cmbMachineType.Text
        TempProjectObj.BearingType = cmbBearingType.Text
        TempProjectObj.PVNo = txtPV.Text
        TempProjectObj.B1Name = If(String.IsNullOrEmpty(txtB1.Text), 0, txtB1.Text)
        TempProjectObj.B2Name = If(String.IsNullOrEmpty(txtB2.Text), 0, txtB2.Text)
        TempProjectObj.B3Name = If(String.IsNullOrEmpty(txtB3.Text), 0, txtB3.Text)
        TempProjectObj.B4Name = If(String.IsNullOrEmpty(txtB4.Text), 0, txtB4.Text)
    End Sub

    Sub LoadProjectDetails()


        txtPrjId.Text = TempProjectObj.ProjectIDTxt
        txtOwner.Text = TempProjectObj.ProjectOwner
        txtPrjName.Text = TempProjectObj.ProjectName
        txtBearingCount.Text = TempProjectObj.BearingCount
        txtCup.Text = TempProjectObj.CupNo
        txtCone.Text = TempProjectObj.ConeNo
        cmbTestType.Text = TempProjectObj.TestType
        cmbMachineType.Text = TempProjectObj.MachineSize
        cmbBearingType.Text = TempProjectObj.BearingType
        txtPV.Text = TempProjectObj.PVNo
        txtB1.Text = TempProjectObj.B1Name
        txtB2.Text = TempProjectObj.B2Name
        txtB3.Text = TempProjectObj.B3Name
        txtB4.Text = TempProjectObj.B4Name

    End Sub

    Private Sub btnSaveAs_Click(sender As Object, e As EventArgs)
        Process.Start(Templatepath & "Project\")
    End Sub

    Private Sub RoundButton1_Click(sender As Object, e As EventArgs) Handles btnLimits.Click
        UpdateProjectCls()
        If frmParameters.ShowDialog() = DialogResult.Yes Then ValuesChanged = True
    End Sub


    Private Sub btnPrjSave_Click(sender As Object, e As EventArgs) Handles btnPrjSave.Click
        ''  If CurrentHead.myProj.isNew Then    MessageBox.Show("Do you want to Save Project", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons., MessageBoxIcon.yesno)

        If Not PrjSave() Then Exit Sub

        Me.Close()
    End Sub

    Function PrjSave() As Boolean
        UpdateProjectCls()

        If Not CheckProject() Then
            MessageBox.Show("There are certain blank values. Please check the parameters ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        If CurrentHead.myProj.isNew Then
            If CurrentHead.myProj.CheckforExistingPrj(TempProjectObj.ProjectIDTxt, TempProjectObj.B1Name, TempProjectObj.B2Name, TempProjectObj.B3Name, TempProjectObj.B4Name) Then
                MessageBox.Show("The bearing number(s) already exists in other datapoints", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End If

        CopyFromTemp()

        If Not CurrentHead.myProj.CheckLoadSteps > 0 Then
            MessageBox.Show("Error in Load Steps. Please check", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        CurrentHead.myProj.Save()
        Return True
    End Function

    Private Sub frmPrjt_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        formshown = True
    End Sub


    Private Sub Bordergray(sender As Object, e As PaintEventArgs) Handles Panel3.Paint
        ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.LightGray, ButtonBorderStyle.Solid)
    End Sub



    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click

        For Each txtBox In Me.Controls.OfType(Of TextBox)()
            If txtBox.Modified Then
                ValuesChanged = True
                txtBox.Modified = False
            End If
        Next

        If ValuesChanged Then
            If MessageBox.Show("Values of the project are changed. Do you want to save? ", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If Not PrjSave() Then
                    Exit Sub
                End If
            Else
                If CurrentHead.myProj.isNew Then
                    CurrentHead.myProj.Init()
                End If
            End If
        End If

        If Not CurrentHead.myProj.CheckLoadSteps > 0 And CurrentHead.myProj.ProjectID <> 0 Then
            MessageBox.Show("Error in Load Steps. Please check", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Me.Close()
    End Sub

    Private Sub txtB1_TextChanged(sender As Object, e As EventArgs) Handles txtB1.TextChanged

    End Sub

    Function CheckProject() As Boolean

        Dim RetVal As Boolean = True


        If TempProjectObj.ProjectIDTxt = "" Then RetVal = False
        If TempProjectObj.ProjectOwner = "" Then RetVal = False
        If TempProjectObj.ProjectName = "" Then RetVal = False
        If TempProjectObj.BearingCount = 0 Then RetVal = False

        If TempProjectObj.BearingType = "" Then RetVal = False
        If TempProjectObj.CupNo = "" Then RetVal = False
        If TempProjectObj.ConeNo = "" Then RetVal = False
        If TempProjectObj.PVNo = "" Then RetVal = False
        If TempProjectObj.TestType = "" Then RetVal = False

        If TempProjectObj.B1Name = 0 Then RetVal = False
        If TempProjectObj.B2Name = 0 Then RetVal = False
        If TempProjectObj.B3Name = 0 Then RetVal = False
        If TempProjectObj.B4Name = 0 Then RetVal = False


        If TempProjectObj.Vibration.SL = 0 Then RetVal = False
        If TempProjectObj.Vibration.SH = 0 Then RetVal = False
        If TempProjectObj.Vibration.WH = 0 Then RetVal = False
        If TempProjectObj.Vibration.WL = 0 Then RetVal = False



        If TempProjectObj.OutTankTemp.SL = 0 Then RetVal = False
        If TempProjectObj.OutTankTemp.SH = 0 Then RetVal = False
        If TempProjectObj.OutTankTemp.WL = 0 Then RetVal = False
        If TempProjectObj.OutTankTemp.WH = 0 Then RetVal = False



        If TempProjectObj.InTankTemp.SL = 0 Then RetVal = False
        If TempProjectObj.InTankTemp.SH = 0 Then RetVal = False
        If TempProjectObj.InTankTemp.WL = 0 Then RetVal = False
        If TempProjectObj.InTankTemp.WH = 0 Then RetVal = False


        If TempProjectObj.Load.WH = 0 Then RetVal = False
        If TempProjectObj.Load.WL = 0 Then RetVal = False
        If TempProjectObj.Load.SH = 0 Then RetVal = False
        If TempProjectObj.Load.SL = 0 Then RetVal = False


        If TempProjectObj.Speed.WH = 0 Then RetVal = False
        If TempProjectObj.Speed.WL = 0 Then RetVal = False
        If TempProjectObj.Speed.SH = 0 Then RetVal = False
        If TempProjectObj.Speed.SL = 0 Then RetVal = False


        'If MaxRev = 0 And MaxRevActive Then RetVal = False


        If TempProjectObj.RunLogRate.TotalSeconds = 0 Then RetVal = False
        If TempProjectObj.LoadLogRate.TotalSeconds = 0 Then RetVal = False
        If TempProjectObj.DispUpdateRate.TotalSeconds = 0 Then RetVal = False


        If TempProjectObj.B1.WH = 0 Then RetVal = False
        If TempProjectObj.B1.WL = 0 Then RetVal = False
        If TempProjectObj.B1.SL = 0 Then RetVal = False
        If TempProjectObj.B1.SH = 0 Then RetVal = False


        If TempProjectObj.B2.WH = 0 Then RetVal = False
        If TempProjectObj.B2.WL = 0 Then RetVal = False
        If TempProjectObj.B2.SL = 0 Then RetVal = False
        If TempProjectObj.B2.SH = 0 Then RetVal = False


        If TempProjectObj.B3.WH = 0 Then RetVal = False
        If TempProjectObj.B3.WL = 0 Then RetVal = False
        If TempProjectObj.B3.SL = 0 Then RetVal = False
        If TempProjectObj.B3.SH = 0 Then RetVal = False


        If TempProjectObj.B4.WH = 0 Then RetVal = False
        If TempProjectObj.B4.WL = 0 Then RetVal = False
        If TempProjectObj.B4.SL = 0 Then RetVal = False
        If TempProjectObj.B4.SH = 0 Then RetVal = False

        Return RetVal
    End Function



    '***********************************************************************************************************
    '*Handles - Template Handling
    '*
    '***********************************************************************************************************
#Region "Templates"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCopyFromTemplate.Click
        CopyFromTemplate(cmbProject.SelectedItem.ToString & ".txt")
        LoadProjectDetails()
    End Sub

    Sub UpdateTemplateList()

        ' Dim constr As String = "SELECT Distinct ProjectIDTxt, ProjectID from Project where ProjectStatus <> " & ProjectCls.ProjectStatus.Failure & " Order by ProjectIDTxt"
      Dim constr As String = "  With cte As
                (   SELECT *, ROW_NUMBER() OVER (PARTITION BY ProjectIDTxt ORDER BY ProjectID DESC) AS rn
                         From Project
                )
                Select ProjectIDTxt, ProjectID 
                From cte
                Where rn = 1 and ProjectStatus <> " & ProjectCls.ProjectStatus.Failure & " Order by ProjectIDTxt"

        If GetDataMySQL(con, daPrj, ds, dt2, False, constr) Then
            cmbProject.DataSource = dt2
            cmbProject.DisplayMember = "ProjectIDTxt"
            cmbProject.ValueMember = "ProjectID"
            cmbProject.Refresh()

        End If
    End Sub


    Sub CopyFromTemplate(Filename As String)

        Dim constr As String = "SELECT * from Project where ProjectID=" & cmbProject.SelectedValue
        If GetDataMySQL(con, daPrj, ds, dt1, False, constr) Then
            If dt1.Rows.Count > 0 Then
                'TempProjectObj.ProjectID = dt1.Rows(0).Item("ProjectID")
                TempProjectObj.ProjectIDTxt = dt1.Rows(0).Item("ProjectIDTxt")
                TempProjectObj.ProjectOwner = dt1.Rows(0).Item("Owner")
                TempProjectObj.ProjectName = dt1.Rows(0).Item("ProjectName")
                TempProjectObj.BearingCount = dt1.Rows(0).Item("BearingCount")
                TempProjectObj.CupNo = dt1.Rows(0).Item("CupNo")
                TempProjectObj.ConeNo = dt1.Rows(0).Item("ConeNo")
                TempProjectObj.TestType = dt1.Rows(0).Item("TestType")
                TempProjectObj.MachineSize = dt1.Rows(0).Item("MachineSize")
                TempProjectObj.BearingType = dt1.Rows(0).Item("BearingType")
                TempProjectObj.PVNo = dt1.Rows(0).Item("PVNo")
                'TempProjectObj.B1Name = dt1.Rows(0).Item("B1Name")
                'TempProjectObj.B2Name = dt1.Rows(0).Item("B2Name")
                'TempProjectObj.B3Name = dt1.Rows(0).Item("B3Name")
                'TempProjectObj.B4Name = dt1.Rows(0).Item("B4Name")
                TempProjectObj.LoadLogRate = dt1.Rows(0).Item("LoadLogRate")
                TempProjectObj.RunLogRate = dt1.Rows(0).Item("RunLogRate")
                TempProjectObj.DispUpdateRate = dt1.Rows(0).Item("DispUpdateRate")
                TempProjectObj.MaxRev = dt1.Rows(0).Item("MaxRev")
                TempProjectObj.MaxRevActive = dt1.Rows(0).Item("MAxRevActive")
            End If

        End If

    End Sub

    Private Sub txtB1_Leave(sender As Object, e As EventArgs) Handles txtB1.Leave
        If txtBearingCount.Text > (txtB1.Text + 4) Then
            txtB2.Text = txtB1.Text + 1
            txtB3.Text = txtB1.Text + 2
            txtB4.Text = txtB1.Text + 3
        End If
    End Sub

    Private Sub txtB1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtB1.KeyPress, txtB2.KeyPress, txtB3.KeyPress, txtB4.KeyPress, txtBearingCount.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

#End Region 'Templates
End Class
