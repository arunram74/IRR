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
        UpdateTemplateList()
        LoadProjectDetails()
        If TempProjectObj.ProjectID <> 0 Then
            ''btnReturn.Enabled = false
            txtPrjId.Enabled = False
            txtOwner.Enabled = False
            txtTestID.Enabled = False
            txtMake.Enabled = False
            txtLub.Enabled = False
            txtPN.Enabled = False

            Panel1.Enabled = False
            btnCopyFromTemplate.Enabled = False
        Else
            '' btnReturn.Enabled = True
            txtPrjId.Enabled = True

            txtOwner.Enabled = True
            txtTestID.Enabled = True
            txtMake.Enabled = True
            txtLub.Enabled = True
            txtPN.Enabled = True

            Panel1.Enabled = True
            btnCopyFromTemplate.Enabled = True
        End If

        If Station.MC.myProj.MyStatus = ProjectCls.ProjectStatus.Run Or Station.MC.myProj.MyStatus = ProjectCls.ProjectStatus.Load Then
            Panel1.Enabled = False
        Else
            Panel1.Enabled = True
        End If

        For Each txtBox In Me.Controls.OfType(Of TextBox)()
            txtBox.Modified = False
        Next

    End Sub

    Sub CopytoTemp()

        TempProjectObj.ProjectIDTxt = Station.MC.myProj.ProjectIDTxt
        TempProjectObj.ProjectOwner = Station.MC.myProj.ProjectOwner
        TempProjectObj.TestID = Station.MC.myProj.TestID
        TempProjectObj.Make = Station.MC.myProj.Make
        TempProjectObj.Lubrication = Station.MC.myProj.Lubrication
        TempProjectObj.PartNo = Station.MC.myProj.PartNo
        TempProjectObj.HeadA = Station.MC.myProj.HeadA
        TempProjectObj.HeadB = Station.MC.myProj.HeadB
        TempProjectObj.HeadC = Station.MC.myProj.HeadC
        TempProjectObj.HeadD = Station.MC.myProj.HeadD
        TempProjectObj.HeadA_Enable = Station.MC.myProj.HeadA_Enable
        TempProjectObj.HeadB_Enable = Station.MC.myProj.HeadB_Enable
        TempProjectObj.HeadC_Enable = Station.MC.myProj.HeadC_Enable
        TempProjectObj.HeadD_Enable = Station.MC.myProj.HeadD_Enable

        TempProjectObj.ProjectID = Station.MC.myProj.ProjectID

        TempProjectObj.BA = Station.MC.myProj.BA
        TempProjectObj.SBA = Station.MC.myProj.SBA
        TempProjectObj.Inlet_TempA = Station.MC.myProj.Inlet_TempA
        TempProjectObj.VibrationA = Station.MC.myProj.VibrationA

        TempProjectObj.BB = Station.MC.myProj.BB
        TempProjectObj.SBB = Station.MC.myProj.SBB
        TempProjectObj.Inlet_TempB = Station.MC.myProj.Inlet_TempB
        TempProjectObj.VibrationB = Station.MC.myProj.VibrationB

        TempProjectObj.BC = Station.MC.myProj.BC
        TempProjectObj.SBC = Station.MC.myProj.SBC
        TempProjectObj.Inlet_TempC = Station.MC.myProj.Inlet_TempC
        TempProjectObj.VibrationC = Station.MC.myProj.VibrationC

        TempProjectObj.BD = Station.MC.myProj.BD
        TempProjectObj.SBD = Station.MC.myProj.SBD
        TempProjectObj.Inlet_TempD = Station.MC.myProj.Inlet_TempD
        TempProjectObj.VibrationD = Station.MC.myProj.VibrationD

        TempProjectObj.TankTemp = Station.MC.myProj.TankTemp

        TempProjectObj.Load = Station.MC.myProj.Load

        TempProjectObj.Speed = Station.MC.myProj.Speed


        TempProjectObj.MaxRev = Station.MC.myProj.MaxRev
        TempProjectObj.MaxRevActive = Station.MC.myProj.MaxRevActive

        TempProjectObj.LoadLogRate = Station.MC.myProj.LoadLogRate


        TempProjectObj.RunLogRate = Station.MC.myProj.RunLogRate


        TempProjectObj.DispUpdateRate = Station.MC.myProj.DispUpdateRate



    End Sub

    Sub CopyFromTemp()

        Station.MC.myProj.ProjectIDTxt = TempProjectObj.ProjectIDTxt
        Station.MC.myProj.ProjectOwner = TempProjectObj.ProjectOwner
        Station.MC.myProj.TestID = TempProjectObj.TestID
        Station.MC.myProj.Make = TempProjectObj.Make
        Station.MC.myProj.Lubrication = TempProjectObj.Lubrication
        Station.MC.myProj.PartNo = TempProjectObj.PartNo
        Station.MC.myProj.HeadA = TempProjectObj.HeadA
        Station.MC.myProj.HeadB = TempProjectObj.HeadB
        Station.MC.myProj.HeadC = TempProjectObj.HeadC
        Station.MC.myProj.HeadD = TempProjectObj.HeadD
        Station.MC.myProj.HeadA_Enable = TempProjectObj.HeadA_Enable
        Station.MC.myProj.HeadB_Enable = TempProjectObj.HeadB_Enable
        Station.MC.myProj.HeadC_Enable = TempProjectObj.HeadC_Enable
        Station.MC.myProj.HeadD_Enable = TempProjectObj.HeadD_Enable

        Station.MC.myProj.ProjectID = TempProjectObj.ProjectID

        Station.MC.myProj.BA = TempProjectObj.BA
        Station.MC.myProj.SBA = TempProjectObj.SBA
        Station.MC.myProj.Inlet_TempA = TempProjectObj.Inlet_TempA
        Station.MC.myProj.VibrationA = TempProjectObj.VibrationA

        Station.MC.myProj.BB = TempProjectObj.BB
        Station.MC.myProj.SBB = TempProjectObj.SBB
        Station.MC.myProj.Inlet_TempB = TempProjectObj.Inlet_TempB
        Station.MC.myProj.VibrationB = TempProjectObj.VibrationB

        Station.MC.myProj.BC = TempProjectObj.BC
        Station.MC.myProj.SBC = TempProjectObj.SBC
        Station.MC.myProj.Inlet_TempC = TempProjectObj.Inlet_TempC
        Station.MC.myProj.VibrationC = TempProjectObj.VibrationC

        Station.MC.myProj.BD = TempProjectObj.BD
        Station.MC.myProj.SBD = TempProjectObj.SBD
        Station.MC.myProj.Inlet_TempD = TempProjectObj.Inlet_TempD
        Station.MC.myProj.VibrationD = TempProjectObj.VibrationD

        Station.MC.myProj.TankTemp = TempProjectObj.TankTemp

        Station.MC.myProj.Load = TempProjectObj.Load

        Station.MC.myProj.Speed = TempProjectObj.Speed


        Station.MC.myProj.MaxRev = TempProjectObj.MaxRev
        Station.MC.myProj.MaxRevActive = TempProjectObj.MaxRevActive

        Station.MC.myProj.LoadLogRate = TempProjectObj.LoadLogRate


        Station.MC.myProj.RunLogRate = TempProjectObj.RunLogRate


        Station.MC.myProj.DispUpdateRate = TempProjectObj.DispUpdateRate


    End Sub

    Sub UpdateProjectCls()
        TempProjectObj.ProjectIDTxt = txtPrjId.Text
        TempProjectObj.ProjectOwner = txtOwner.Text
        TempProjectObj.TestID = txtTestID.Text

        TempProjectObj.Make = txtMake.Text
        TempProjectObj.Lubrication = txtLub.Text

        TempProjectObj.PartNo = If(String.IsNullOrEmpty(txtPN.Text), 0, txtPN.Text)
        TempProjectObj.HeadA = If(String.IsNullOrEmpty(cmbBA.Text), 0, cmbBA.Text)
        TempProjectObj.HeadB = If(String.IsNullOrEmpty(cmbBB.Text), 0, cmbBB.Text)
        TempProjectObj.HeadC = If(String.IsNullOrEmpty(cmbBC.Text), 0, cmbBC.Text)
        TempProjectObj.HeadD = If(String.IsNullOrEmpty(cmbBD.Text), 0, cmbBD.Text)

        TempProjectObj.HeadA_Enable = chkHeadA.Checked
        TempProjectObj.HeadB_Enable = chkHeadB.Checked
        TempProjectObj.HeadC_Enable = chkHeadC.Checked
        TempProjectObj.HeadD_Enable = chkHeadD.Checked
    End Sub

    Sub LoadProjectDetails()


        txtPrjId.Text = TempProjectObj.ProjectIDTxt
        txtOwner.Text = TempProjectObj.ProjectOwner
        txtTestID.Text = TempProjectObj.TestID

        txtMake.Text = TempProjectObj.Make
        txtLub.Text = TempProjectObj.Lubrication

        txtPN.Text = TempProjectObj.PartNo
        cmbBA.Text = TempProjectObj.HeadA
        cmbBB.Text = TempProjectObj.HeadB
        cmbBC.Text = TempProjectObj.HeadC
        cmbBD.Text = TempProjectObj.HeadD

        chkHeadA.Checked = TempProjectObj.HeadA_Enable
        chkHeadB.Checked = TempProjectObj.HeadB_Enable
        chkHeadC.Checked = TempProjectObj.HeadC_Enable
        chkHeadD.Checked = TempProjectObj.HeadD_Enable


    End Sub

    Private Sub btnSaveAs_Click(sender As Object, e As EventArgs)
        Process.Start(Templatepath & "Project\")
    End Sub

    Private Sub RoundButton1_Click(sender As Object, e As EventArgs) Handles btnLimits.Click
        UpdateProjectCls()
        If frmParameters.ShowDialog() = DialogResult.Yes Then ValuesChanged = True
    End Sub


    Private Sub btnPrjSave_Click(sender As Object, e As EventArgs) Handles btnPrjSave.Click
        ''  If Station.MC.myProj.isNew Then    MessageBox.Show("Do you want to Save Project", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons., MessageBoxIcon.yesno)

        If Not PrjSave() Then Exit Sub

        Me.Close()
    End Sub

    Function PrjSave() As Boolean
        UpdateProjectCls()

        If Not CheckProject() Then
            MessageBox.Show("There are certain blank values. Please check the parameters ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        If Station.MC.myProj.isNew Then
            If Station.MC.myProj.CheckforExistingPrj(TempProjectObj.ProjectIDTxt) Then
                MessageBox.Show("The bearing number(s) already exists in other datapoints", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End If

        CopyFromTemp()

        If Not Station.MC.myProj.CheckLoadSteps > 0 Then
            MessageBox.Show("Error in Load Steps. Please check", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        Station.MC.myProj.Save()
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
                If Station.MC.myProj.isNew Then
                    Station.MC.myProj.Init()
                End If
            End If
        End If

        If Not Station.MC.myProj.CheckLoadSteps > 0 And Station.MC.myProj.ProjectID <> 0 Then
            MessageBox.Show("Error in Load Steps. Please check", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Me.Close()
    End Sub

    Private Sub txtB1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Function CheckProject() As Boolean

        Dim RetVal As Boolean = True


        If TempProjectObj.ProjectIDTxt = "" Then RetVal = False
        If TempProjectObj.ProjectOwner = "" Then RetVal = False
        If TempProjectObj.TestID = "" Then RetVal = False


        If TempProjectObj.Make = "" Then RetVal = False
        If TempProjectObj.Lubrication = "" Then RetVal = False
        If TempProjectObj.PartNo = "" Then RetVal = False


        If TempProjectObj.HeadA = 0 Then RetVal = False
        If TempProjectObj.HeadB = 0 Then RetVal = False
        If TempProjectObj.HeadC = 0 Then RetVal = False
        If TempProjectObj.HeadD = 0 Then RetVal = False

        If CheckForZero(TempProjectObj.VibrationA) Then RetVal = False
        If CheckForZero(TempProjectObj.VibrationB) Then RetVal = False
        If CheckForZero(TempProjectObj.VibrationC) Then RetVal = False
        If CheckForZero(TempProjectObj.VibrationD) Then RetVal = False

        If CheckForZero(TempProjectObj.TankTemp) Then RetVal = False

        If CheckForZero(TempProjectObj.Inlet_TempA) Then RetVal = False
        If CheckForZero(TempProjectObj.Inlet_TempB) Then RetVal = False
        If CheckForZero(TempProjectObj.Inlet_TempC) Then RetVal = False
        If CheckForZero(TempProjectObj.Inlet_TempD) Then RetVal = False


        If CheckForZero(TempProjectObj.Load) Then RetVal = False
        If CheckForZero(TempProjectObj.Speed) Then RetVal = False



        'If MaxRev = 0 And MaxRevActive Then RetVal = False


        If TempProjectObj.RunLogRate.TotalSeconds = 0 Then RetVal = False
        If TempProjectObj.LoadLogRate.TotalSeconds = 0 Then RetVal = False
        If TempProjectObj.DispUpdateRate.TotalSeconds = 0 Then RetVal = False

        If CheckForZero(TempProjectObj.BA) Then RetVal = False
        If CheckForZero(TempProjectObj.BB) Then RetVal = False
        If CheckForZero(TempProjectObj.BC) Then RetVal = False
        If CheckForZero(TempProjectObj.BD) Then RetVal = False

        If CheckForZero(TempProjectObj.SBA) Then RetVal = False
        If CheckForZero(TempProjectObj.SBB) Then RetVal = False
        If CheckForZero(TempProjectObj.SBC) Then RetVal = False
        If CheckForZero(TempProjectObj.SBD) Then RetVal = False



        Return RetVal
    End Function

    Private Function CheckForZero(val As SingleLimits) As Boolean
        Dim RetVal As Boolean = True
        If val.WH = 0 Then RetVal = False
        If val.WL = 0 Then RetVal = False
        If val.SH = 0 Then RetVal = False
        If val.SL = 0 Then RetVal = False
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

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub



    Sub CopyFromTemplate(Filename As String)

        Dim constr As String = "SELECT * from Project where ProjectID=" & cmbProject.SelectedValue
        If GetDataMySQL(con, daPrj, ds, dt1, False, constr) Then
            If dt1.Rows.Count > 0 Then
                'TempProjectObj.ProjectID = dt1.Rows(0).Item("ProjectID")
                TempProjectObj.ProjectIDTxt = dt1.Rows(0).Item("ProjectIDTxt")
                TempProjectObj.ProjectOwner = dt1.Rows(0).Item("Owner")
                TempProjectObj.TestID = dt1.Rows(0).Item("ProjectName")
                TempProjectObj.Make = dt1.Rows(0).Item("Make")
                TempProjectObj.Lubrication = dt1.Rows(0).Item("Lubrication")
                TempProjectObj.PartNo = dt1.Rows(0).Item("PVNo")
                TempProjectObj.HeadA = dt1.Rows(0).Item("HeadABearing")
                TempProjectObj.HeadB = dt1.Rows(0).Item("HeadBBearing")
                TempProjectObj.HeadC = dt1.Rows(0).Item("HeadCBearing")
                TempProjectObj.HeadD = dt1.Rows(0).Item("HeadDBearing")

                TempProjectObj.HeadA_Enable = dt1.Rows(0).Item("HeadA_Enable")
                TempProjectObj.HeadB_Enable = dt1.Rows(0).Item("HeadB_Enable")
                TempProjectObj.HeadC_Enable = dt1.Rows(0).Item("HeadC_Enable")
                TempProjectObj.HeadD_Enable = dt1.Rows(0).Item("HeadD_Enable")

                TempProjectObj.LoadLogRate = dt1.Rows(0).Item("LoadLogRate")
                TempProjectObj.RunLogRate = dt1.Rows(0).Item("RunLogRate")
                TempProjectObj.DispUpdateRate = dt1.Rows(0).Item("DispUpdateRate")
                TempProjectObj.MaxRev = dt1.Rows(0).Item("MaxRev")
                TempProjectObj.MaxRevActive = dt1.Rows(0).Item("MAxRevActive")
            End If

        End If

    End Sub

    'Private Sub txtB1_Leave(sender As Object, e As EventArgs)
    '    If txtBearingCount.Text > (txtB1.Text + 4) Then
    '        txtB2.Text = txtB1.Text + 1
    '        txtB3.Text = txtB1.Text + 2
    '        txtB4.Text = txtB1.Text + 3
    '    End If
    'End Sub

    Private Sub txtB1_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

#End Region 'Templates
End Class


Public Class NewCheckBox
    Inherits CheckBox

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)

        'Make the box you check 3/4 the height
        Dim boxsize As Integer = Me.Height * 0.75
        Dim rect As New Rectangle(
            New Point(0, Me.Height / 2 - boxsize / 2),
            New Size(boxsize, boxsize)
        )

        ControlPaint.DrawCheckBox(e.Graphics, rect, If(Me.Checked, ButtonState.Checked, ButtonState.Normal))
    End Sub
End Class