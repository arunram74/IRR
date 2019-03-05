'Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.IO

Public Class frmParameters

    'Dim con As MySqlConnection = New MySqlConnection(serv)
    'Dim daLim, daLimName As MySqlDataAdapter
    'Dim ds As DataSet
    'Dim dt1, dt2, dt3 As DataTable
    'Dim cb As MySqlCommandBuilder
    Dim formshown As Boolean = False
    'Dim numupDownArrNames() As String = {"Vib", "BT", "SPD", "LD", "TT", "SBT", "IOT"}

    Friend Event NextScreen(sender As Form, nxtScr As ChildForms)

    'Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
    '    Dim rs As DataRow
    '    Dim i As Integer
    '    Dim ctrl1, ctrl2, ctrl3, ctrl4 As NumericUpDown
    '    Dim chkctrl As CheckBox
    '    cmbLimits.SelectedIndex = dt1.Rows(0).Item("LimitID") - 1
    '    For Each rs In dt1.Rows
    '        i = rs.Item("ParamID")
    '        ctrl1 = Me.Controls("nup" & numupDownArrNames(i - 1) & "WH")
    '        ctrl2 = Me.Controls("nup" & numupDownArrNames(i - 1) & "WL")
    '        ctrl3 = Me.Controls("nup" & numupDownArrNames(i - 1) & "AH")
    '        ctrl4 = Me.Controls("nup" & numupDownArrNames(i - 1) & "AL")
    '        chkctrl = Me.Controls("chk" & numupDownArrNames(i - 1) & "Byp")

    '        rs.Item("WarningLimitH") = ctrl1.Value
    '        rs.Item("WarningLimitL") = ctrl2.Value
    '        rs.Item("AlarmLimitH") = ctrl3.Value
    '        rs.Item("AlarmLimitL") = ctrl4.Value
    '        rs.Item("Bypass") = chkctrl.Checked
    '    Next
    '    cb = New MySqlCommandBuilder(daLim) 'to make the ds updatable
    '    daLim.Update(dt1)
    'End Sub

    Public ValuesChanged As Boolean = False

    Private Sub frmLimits_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ValuesChanged = False
        lblMcHead.Text = TempProjectObj.MachineName & "H" & TempProjectObj.HeadName
        'If CurrentHead.myProj.MyStatus = ProjectCls.ProjectStatus.Run Or CurrentHead.myProj.MyStatus = ProjectCls.ProjectStatus.Load Then
        '    Panel1.Enabled = False
        'Else
        '    Panel1.Enabled = True
        'End If

        If TempProjectObj.ProjectID <> 0 Then Panel2.Enabled = False Else Panel2.Enabled = True
        LoadLimits()
        LoadProjectInfo()
        UpdateTemplateList()
        AllowOnlyNumbers(Me)
        For Each txtBox In Me.Controls.OfType(Of TextBox)()
            txtBox.Modified = False
        Next
    End Sub




    'Sub UpdateUpDownControls()
    '    Dim constr As String = "SELECT * from Limitsdb  where LimitID=" & cmbLimits.SelectedValue.ToString & " ORDER by ParamID ASC"
    '    Dim rs As DataRow
    '    Dim i As Integer
    '    Dim ctrl1, ctrl2, ctrl3, ctrl4 As NumericUpDown
    '    Dim chkctrl As CheckBox


    '    GetDataMySQL(con, daLim, ds, dt1, False, constr)
    '    For Each rs In dt1.Rows
    '        i = rs.Item("ParamID")
    '        ctrl1 = Me.Controls("nup" & numupDownArrNames(i - 1) & "WH")
    '        ctrl2 = Me.Controls("nup" & numupDownArrNames(i - 1) & "WL")
    '        ctrl3 = Me.Controls("nup" & numupDownArrNames(i - 1) & "AH")
    '        ctrl4 = Me.Controls("nup" & numupDownArrNames(i - 1) & "AL")
    '        chkctrl = Me.Controls("chk" & numupDownArrNames(i - 1) & "Byp")

    '        ctrl1.Value = rs.Item("WarningLimitH")
    '        ctrl2.Value = rs.Item("WarningLimitL")
    '        ctrl3.Value = rs.Item("AlarmLimitH")
    '        ctrl4.Value = rs.Item("AlarmLimitL")
    '        chkctrl.Checked = rs.Item("Bypass")
    '    Next

    'End Sub

    Private Sub btnLoad_Click_1(sender As Object, e As EventArgs) Handles btnLoad.Click
        If frmLoad.ShowDialog() = DialogResult.Yes Then ValuesChanged = True
    End Sub

    Private Sub btnBearing_Click(sender As Object, e As EventArgs) Handles btnBearing.Click
        If frmBearing.ShowDialog() = DialogResult.Yes Then ValuesChanged = True

    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click

        If ValuesChanged Then Me.DialogResult = DialogResult.Yes Else Me.DialogResult = DialogResult.No
        Me.Close()
    End Sub

    Sub LoadLimitSets()

        '    Dim constr As String = "SELECT idlimitname, LimitSetName from Limitname"
        '    If GetDataMySQL(con, daLimName, ds, dt2, False, constr) Then
        '        cmbLimits.DataSource = dt2
        '        cmbLimits.DisplayMember = "LimitSetName"
        '        cmbLimits.ValueMember = "idlimitname"
        '    End If

    End Sub



    Private Sub frmLimits_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        '  cmbLimits.SelectedIndex = 0
        '   UpdateUpDownControls()
        formshown = True
    End Sub

    Private Sub P1_Click(sender As Object, e As EventArgs) Handles P1.Click

    End Sub

    Private Sub Bordergray(sender As Object, e As PaintEventArgs) Handles Label7.Paint, Label4.Paint, Label9.Paint, Label8.Paint, Label10.Paint, Label11.Paint, Label17.Paint, Label19.Paint, lblMachine.Paint, lblPrjID.Paint, lblPV.Paint, lblCup.Paint, lblCone.Paint, lblTestType.Paint, lblBearingType.Paint, lblB1.Paint, lblB2.Paint, lblB3.Paint, lblB4.Paint, P1.Paint, Label21.Paint, Label12.Paint
        ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.LightGray, ButtonBorderStyle.Solid)
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

    Sub LoadLimits()
        txtVibWH.Text = TempProjectObj.Vibration.WH
        txtVibWL.Text = TempProjectObj.Vibration.WL
        txtVibSH.Text = TempProjectObj.Vibration.SH
        txtVibSL.Text = TempProjectObj.Vibration.SL
        chkVibByp.Checked = TempProjectObj.Vibration.Bypass

        txtOTTWH.Text = TempProjectObj.OutTankTemp.WH
        txtOTTWL.Text = TempProjectObj.OutTankTemp.WL
        txtOTTSH.Text = TempProjectObj.OutTankTemp.SH
        txtOTTSL.Text = TempProjectObj.OutTankTemp.SL
        chkOTTByp.Checked = TempProjectObj.OutTankTemp.Bypass

        txtITTWH.Text = TempProjectObj.InTankTemp.WH
        txtITTWL.Text = TempProjectObj.InTankTemp.WL
        txtITTSH.Text = TempProjectObj.InTankTemp.SH
        txtITTSL.Text = TempProjectObj.InTankTemp.SL
        txtLubOilTempSP.Text = TempProjectObj.InTankTemp.Setpoint
        chkITTByp.Checked = TempProjectObj.InTankTemp.Bypass

        txtLoadWH.Text = TempProjectObj.Load.WH
        txtLoadWL.Text = TempProjectObj.Load.WL
        txtLoadSH.Text = TempProjectObj.Load.SH
        txtLoadSL.Text = TempProjectObj.Load.SL
        chkLoadByp.Checked = TempProjectObj.Load.Bypass

        txtSpeedWH.Text = TempProjectObj.Speed.WH
        txtSpeedWL.Text = TempProjectObj.Speed.WL
        txtSpeedSH.Text = TempProjectObj.Speed.SH
        txtSpeedSL.Text = TempProjectObj.Speed.SL
        txtSpeedSP.Text = TempProjectObj.Speed.Setpoint
        chkSpeedByp.Checked = TempProjectObj.Speed.Bypass

        txtMaxRev.Text = TempProjectObj.MaxRev
        chkMaxRevByp.Checked = Not TempProjectObj.MaxRevActive

        nupLoadHr.Value = TempProjectObj.LoadLogRate.Hours
        nupLoadMin.Value = TempProjectObj.LoadLogRate.Minutes
        nupLoadSec.Value = TempProjectObj.LoadLogRate.Seconds

        nupRunHr.Value = TempProjectObj.RunLogRate.Hours
        nupRunMin.Value = TempProjectObj.RunLogRate.Minutes
        nupRunSec.Value = TempProjectObj.RunLogRate.Seconds

        nupDUPHr.Value = TempProjectObj.DispUpdateRate.Hours
        nupDUPMin.Value = TempProjectObj.DispUpdateRate.Minutes
        nupDUPSec.Value = TempProjectObj.DispUpdateRate.Seconds

    End Sub

    Function UpdateLimitCls() As Boolean
        Try
            If Convert.ToSingle(txtVibSL.Text) < Convert.ToSingle(txtVibWL.Text) And Convert.ToSingle(txtVibWL.Text) < Convert.ToSingle(txtVibWH.Text) And Convert.ToSingle(txtVibWH.Text) < Convert.ToSingle(txtVibSH.Text) Then
                TempProjectObj.Vibration.WH = txtVibWH.Text
                TempProjectObj.Vibration.WL = txtVibWL.Text
                TempProjectObj.Vibration.SH = txtVibSH.Text
                TempProjectObj.Vibration.SL = txtVibSL.Text
                TempProjectObj.Vibration.Bypass = chkVibByp.Checked
            Else
                MessageBox.Show("Vibration Limits are not OK", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            If Convert.ToSingle(txtOTTSL.Text) < Convert.ToSingle(txtOTTWL.Text) And Convert.ToSingle(txtOTTWL.Text) < Convert.ToSingle(txtOTTWH.Text) And Convert.ToSingle(txtOTTWH.Text) < Convert.ToSingle(txtOTTSH.Text) Then
                TempProjectObj.OutTankTemp.WH = txtOTTWH.Text
                TempProjectObj.OutTankTemp.WL = txtOTTWL.Text
                TempProjectObj.OutTankTemp.SH = txtOTTSH.Text
                TempProjectObj.OutTankTemp.SL = txtOTTSL.Text
                TempProjectObj.OutTankTemp.Bypass = chkOTTByp.Checked
            Else
                MessageBox.Show("OuterTank Limits are not OK", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            If Convert.ToSingle(txtITTSL.Text) < Convert.ToSingle(txtITTWL.Text) And Convert.ToSingle(txtITTWL.Text) < Convert.ToSingle(txtITTWH.Text) And Convert.ToSingle(txtITTWH.Text) < Convert.ToSingle(txtITTSH.Text) Then
                TempProjectObj.InTankTemp.WH = txtITTWH.Text
                TempProjectObj.InTankTemp.WL = txtITTWL.Text
                TempProjectObj.InTankTemp.SH = txtITTSH.Text
                TempProjectObj.InTankTemp.SL = txtITTSL.Text
                TempProjectObj.InTankTemp.Setpoint = txtLubOilTempSP.Text
                TempProjectObj.InTankTemp.Bypass = chkITTByp.Checked
            Else
                MessageBox.Show("Inner Tank Limits are not OK", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            If Convert.ToSingle(txtLoadSL.Text) < Convert.ToSingle(txtLoadWL.Text) And Convert.ToSingle(txtLoadWL.Text) < Convert.ToSingle(txtLoadWH.Text) And Convert.ToSingle(txtLoadWH.Text) < Convert.ToSingle(txtLoadSH.Text) Then
                TempProjectObj.Load.WH = txtLoadWH.Text
                TempProjectObj.Load.WL = txtLoadWL.Text
                TempProjectObj.Load.SH = txtLoadSH.Text
                TempProjectObj.Load.SL = txtLoadSL.Text
                TempProjectObj.Load.Bypass = chkLoadByp.Checked
            Else
                MessageBox.Show("Load limits are not OK", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If


            If Convert.ToSingle(txtSpeedSL.Text) < Convert.ToSingle(txtSpeedWL.Text) And Convert.ToSingle(txtSpeedWL.Text) < Convert.ToSingle(txtSpeedWH.Text) And Convert.ToSingle(txtSpeedWH.Text) < Convert.ToSingle(txtSpeedSH.Text) Then
                TempProjectObj.Speed.WH = txtSpeedWH.Text
                TempProjectObj.Speed.WL = txtSpeedWL.Text
                TempProjectObj.Speed.SH = txtSpeedSH.Text
                TempProjectObj.Speed.SL = txtSpeedSL.Text
                TempProjectObj.Speed.Setpoint = txtSpeedSP.Text
                TempProjectObj.Speed.Bypass = chkSpeedByp.Checked
            Else
                MessageBox.Show("Speed Limits are not OK", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            TempProjectObj.MaxRev = txtMaxRev.Text
            TempProjectObj.MaxRevActive = Not chkMaxRevByp.Checked

            TempProjectObj.LoadLogRate = TimeSpan.Parse(nupLoadHr.Value & ":" & nupLoadMin.Value & ":" & nupLoadSec.Value)
            TempProjectObj.RunLogRate = TimeSpan.Parse(nupRunHr.Value & ":" & nupRunMin.Value & ":" & nupRunSec.Value)
            TempProjectObj.DispUpdateRate = TimeSpan.Parse(nupDUPHr.Value & ":" & nupDUPMin.Value & ":" & nupDUPSec.Value)
        Catch ex As Exception
            MessageBox.Show("Empty or null values in inputs. Please enter a valid number", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try


        Return True

    End Function

    Private Sub frmParameters_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        TempProjectObj.LoadLogRate = TimeSpan.Parse(nupLoadHr.Value & ":" & nupLoadMin.Value & ":" & nupLoadSec.Value)
        TempProjectObj.RunLogRate = TimeSpan.Parse(nupRunHr.Value & ":" & nupRunMin.Value & ":" & nupRunSec.Value)
        TempProjectObj.DispUpdateRate = TimeSpan.Parse(nupDUPHr.Value & ":" & nupDUPMin.Value & ":" & nupDUPSec.Value)



        Dim ValModified As Boolean = False

        If TempProjectObj.LoadLogRate <> CurrentHead.myProj.LoadLogRate Then ValModified = True
        If TempProjectObj.RunLogRate <> CurrentHead.myProj.RunLogRate Then ValModified = True
        If TempProjectObj.DispUpdateRate <> CurrentHead.myProj.DispUpdateRate Then ValModified = True


        If TempProjectObj.Vibration.Bypass <> chkVibByp.Checked Then ValModified = True
        If TempProjectObj.Speed.Bypass <> chkSpeedByp.Checked Then ValModified = True
        If TempProjectObj.Load.Bypass <> chkLoadByp.Checked Then ValModified = True
        If TempProjectObj.InTankTemp.Bypass <> chkITTByp.Checked Then ValModified = True
        If TempProjectObj.OutTankTemp.Bypass <> chkOTTByp.Checked Then ValModified = True
        If TempProjectObj.MaxRevActive = chkMaxRevByp.Checked Then ValModified = True

        For Each txtBox In Me.Controls.OfType(Of TextBox)()
            If txtBox.Modified Then
                ValModified = True
                txtBox.Modified = False
            End If
        Next

        If ValModified Then
            If MessageBox.Show("Do you want to update project with these values?", "Limits", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If Not UpdateLimitCls() Then e.Cancel = True
                ValuesChanged = True
                Me.DialogResult = DialogResult.Yes
                Exit Sub
            End If
        End If

    End Sub

#Region "Templates"




    Sub UpdateTemplateList()
        ' Dim filters As String() = {"*.mp3", "*.docx", "*.bmp", "*.txt"}
        Dim filters As String() = {"*.txt", "*.csv"}


        Dim foundFiles As List(Of IO.FileInfo) = SearchAndAddToListWithFilter(Templatepath & "Limits\", filters, True)
        cmbLmtTemp.Items.Clear()
        For Each itm In foundFiles
            cmbLmtTemp.Items.Add(itm.Name.Substring(0, itm.Name.Length - 4))
        Next
        If cmbLmtTemp.Items.Count > 0 Then cmbLmtTemp.SelectedIndex = 0
    End Sub


    Sub CopyFromTemplate(Filename As String)
        Try
            Dim SR As StreamReader = New StreamReader(Templatepath & "Limits\" & Filename)
            Dim line As String
            Dim strArray As String()
            Dim val As SingleLimits

            line = SR.ReadLine 'read header
            line = SR.ReadLine 'read the content
            Do
                If Not line = String.Empty Then

                    strArray = line.Split(","c)

                    Select Case strArray(0).ToUpper
                        Case "LOADLOGRATE"
                            TempProjectObj.LoadLogRate = TimeSpan.Parse(strArray(1).Trim)
                            line = SR.ReadLine 'read the content
                            Continue Do
                        Case "RUNLOGRATE"
                            TempProjectObj.RunLogRate = TimeSpan.Parse(strArray(1).Trim)
                            line = SR.ReadLine 'read the content
                            Continue Do
                        Case "DISPUPDRATE"
                            TempProjectObj.DispUpdateRate = TimeSpan.Parse(strArray(1).Trim)
                            line = SR.ReadLine 'read the content
                            Continue Do
                    End Select

                    val.WH = strArray(1).Trim
                    val.WL = strArray(2).Trim
                    val.SH = strArray(3).Trim
                    val.SL = strArray(4).Trim
                    val.Bypass = strArray(5).Trim


                    Select Case strArray(0).ToUpper
                        Case "VIB"
                            TempProjectObj.Vibration = val
                        Case "OUTTANKTEMP"
                            TempProjectObj.OutTankTemp = val
                        Case "INTANKTEMP"
                            TempProjectObj.InTankTemp = val
                        Case "LOAD"
                            TempProjectObj.Load = val
                        Case "SPEED"
                            TempProjectObj.Speed = val
                        Case "B1"
                            TempProjectObj.B1 = val
                        Case "B2"
                            TempProjectObj.B2 = val
                        Case "B3"
                            TempProjectObj.B3 = val
                        Case "B4"
                            TempProjectObj.B4 = val
                        Case "MAXREV"
                            TempProjectObj.MaxRev = val.WH
                            TempProjectObj.MaxRevActive = val.Bypass
                    End Select

                    line = SR.ReadLine 'read the content
                Else
                    Exit Do
                End If
            Loop
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        LoadLimits()
    End Sub

    Private Sub btnopnTmpLoc_Click(sender As Object, e As EventArgs) Handles btnopnTmpLoc.Click
        Process.Start(Templatepath & "Limits\")
    End Sub

    Private Sub btnCopyFromTemplate_Click(sender As Object, e As EventArgs) Handles btnCopyFromTemplate.Click
        CopyFromTemplate(cmbLmtTemp.SelectedItem.ToString & ".txt")
    End Sub




#End Region 'Templates

End Class
