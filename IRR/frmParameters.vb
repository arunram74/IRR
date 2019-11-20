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



    Public ValuesChanged As Boolean = False

    Private Sub frmLimits_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ValuesChanged = False

        'If Station.MC.myProj.MyStatus = ProjectCls.ProjectStatus.Run Or Station.MC.myProj.MyStatus = ProjectCls.ProjectStatus.Load Then
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





    Private Sub frmLimits_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        '  cmbLimits.SelectedIndex = 0
        '   UpdateUpDownControls()
        formshown = True
    End Sub

    Private Sub P1_Click(sender As Object, e As EventArgs) Handles P1.Click

    End Sub

    Private Sub Bordergray(sender As Object, e As PaintEventArgs) Handles Label7.Paint, Label4.Paint, Label9.Paint, Label8.Paint, Label10.Paint, Label11.Paint, Label17.Paint, Label19.Paint, lblTestID.Paint, lblPartNo.Paint, lblLub.Paint, lblMake.Paint, lblB1.Paint, lblB2.Paint, lblB3.Paint, lblB4.Paint, P1.Paint, Label21.Paint, Label12.Paint
        ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.LightGray, ButtonBorderStyle.Solid)
    End Sub

    Sub LoadProjectInfo()

        lblTestID.Text = TempProjectObj.ProjectIDTxt

        lblLub.Text = TempProjectObj.Lubrication
        lblMake.Text = TempProjectObj.Make


        lblB1.Text = TempProjectObj.HeadA
        lblB2.Text = TempProjectObj.HeadB
        lblB3.Text = TempProjectObj.HeadC
        lblB4.Text = TempProjectObj.HeadD
    End Sub

    Sub LoadLimits()
        txtSupBTWH.Text = TempProjectObj.SBA.WH
        txtSupBTWL.Text = TempProjectObj.SBA.WL
        txtSupBTSH.Text = TempProjectObj.SBA.SH
        txtSupBTSL.Text = TempProjectObj.SBA.SL
        chkSupBTAByp.Checked = TempProjectObj.SBA.Bypass
        chkSupBTBByp.Checked = TempProjectObj.SBD.Bypass
        chkSupBTCByp.Checked = TempProjectObj.SBC.Bypass
        chkSupBTDByp.Checked = TempProjectObj.SBD.Bypass


        txtInletTWH.Text = TempProjectObj.Inlet_TempA.WH
        txtInletTWL.Text = TempProjectObj.Inlet_TempA.WL
        txtInletTSH.Text = TempProjectObj.Inlet_TempA.SH
        txtInletTSL.Text = TempProjectObj.Inlet_TempA.SL
        chkInletTByp.Checked = TempProjectObj.Inlet_TempA.Bypass

        txtTankTWH.Text = TempProjectObj.TankTemp.WH
        txtTankTWL.Text = TempProjectObj.TankTemp.WL
        txtTankTSH.Text = TempProjectObj.TankTemp.SH
        txtTankTSL.Text = TempProjectObj.TankTemp.SL
        txtLubOilTempSP.Text = TempProjectObj.TankTemp.Setpoint
        chkTankTByp.Checked = TempProjectObj.TankTemp.Bypass

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
            If Convert.ToSingle(txtSupBTSL.Text) < Convert.ToSingle(txtSupBTWL.Text) And Convert.ToSingle(txtSupBTWL.Text) < Convert.ToSingle(txtSupBTWH.Text) And Convert.ToSingle(txtSupBTWH.Text) < Convert.ToSingle(txtSupBTSH.Text) Then
                TempProjectObj.SBA.WH = txtSupBTWH.Text
                TempProjectObj.SBA.WL = txtSupBTWL.Text
                TempProjectObj.SBA.SH = txtSupBTSH.Text
                TempProjectObj.SBA.SL = txtSupBTSL.Text
                TempProjectObj.SBB = TempProjectObj.SBA
                TempProjectObj.SBC = TempProjectObj.SBA
                TempProjectObj.SBD = TempProjectObj.SBA

                TempProjectObj.SBA.Bypass = chkSupBTAByp.Checked
                TempProjectObj.SBB.Bypass = chkSupBTBByp.Checked
                TempProjectObj.SBC.Bypass = chkSupBTCByp.Checked
                TempProjectObj.SBD.Bypass = chkSupBTDByp.Checked

            Else
                MessageBox.Show("Vibration Limits are not OK", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            If Convert.ToSingle(txtInletTSL.Text) < Convert.ToSingle(txtInletTWL.Text) And Convert.ToSingle(txtInletTWL.Text) < Convert.ToSingle(txtInletTWH.Text) And Convert.ToSingle(txtInletTWH.Text) < Convert.ToSingle(txtInletTSH.Text) Then
                TempProjectObj.Inlet_TempA.WH = txtInletTWH.Text
                TempProjectObj.Inlet_TempA.WL = txtInletTWL.Text
                TempProjectObj.Inlet_TempA.SH = txtInletTSH.Text
                TempProjectObj.Inlet_TempA.SL = txtInletTSL.Text
                TempProjectObj.Inlet_TempA.Bypass = chkInletTByp.Checked

                TempProjectObj.Inlet_TempB = TempProjectObj.Inlet_TempA
                TempProjectObj.Inlet_TempC = TempProjectObj.Inlet_TempA
                TempProjectObj.Inlet_TempD = TempProjectObj.Inlet_TempA

            Else
                MessageBox.Show("OuterTank Limits are not OK", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            If Convert.ToSingle(txtTankTSL.Text) < Convert.ToSingle(txtTankTWL.Text) And Convert.ToSingle(txtTankTWL.Text) < Convert.ToSingle(txtTankTWH.Text) And Convert.ToSingle(txtTankTWH.Text) < Convert.ToSingle(txtTankTSH.Text) Then
                TempProjectObj.TankTemp.WH = txtTankTWH.Text
                TempProjectObj.TankTemp.WL = txtTankTWL.Text
                TempProjectObj.TankTemp.SH = txtTankTSH.Text
                TempProjectObj.TankTemp.SL = txtTankTSL.Text
                TempProjectObj.TankTemp.Setpoint = txtLubOilTempSP.Text
                TempProjectObj.TankTemp.Bypass = chkTankTByp.Checked
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

        If TempProjectObj.LoadLogRate <> Station.MC.myProj.LoadLogRate Then ValModified = True
        If TempProjectObj.RunLogRate <> Station.MC.myProj.RunLogRate Then ValModified = True
        If TempProjectObj.DispUpdateRate <> Station.MC.myProj.DispUpdateRate Then ValModified = True


        If TempProjectObj.SBA.Bypass <> chkSupBTAByp.Checked Then ValModified = True
        If TempProjectObj.SBB.Bypass <> chkSupBTBByp.Checked Then ValModified = True
        If TempProjectObj.SBD.Bypass <> chkSupBTCByp.Checked Then ValModified = True
        If TempProjectObj.SBD.Bypass <> chkSupBTDByp.Checked Then ValModified = True

        If TempProjectObj.Speed.Bypass <> chkSpeedByp.Checked Then ValModified = True
        If TempProjectObj.Load.Bypass <> chkLoadByp.Checked Then ValModified = True
        If TempProjectObj.TankTemp.Bypass <> chkTankTByp.Checked Then ValModified = True
        If TempProjectObj.Inlet_TempA.Bypass <> chkInletTByp.Checked Then ValModified = True
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
                        Case "VIBA"
                            TempProjectObj.VibrationA = val
                        Case "VIBB"
                            TempProjectObj.VibrationB = val
                        Case "VIBC"
                            TempProjectObj.VibrationC = val
                        Case "VIBD"
                            TempProjectObj.VibrationD = val
                        Case "TANKTEMP"
                            TempProjectObj.TankTemp = val
                        Case "INLETTEMP"
                            TempProjectObj.Inlet_TempA = val
                        Case "LOAD"
                            TempProjectObj.Load = val
                        Case "SPEED"
                            TempProjectObj.Speed = val
                        Case "BA"
                            TempProjectObj.BA = val
                        Case "BB"
                            TempProjectObj.BB = val
                        Case "BC"
                            TempProjectObj.BC = val
                        Case "BD"
                            TempProjectObj.BD = val
                        Case "SB"
                            TempProjectObj.SBA = val

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
