Imports System.ComponentModel

Public Class frmBearing

    Public ValuesChanged As Boolean = False

    Private Sub Bordergray(sender As Object, e As PaintEventArgs) ' Handles Label7.Paint, Label4.Paint, Label9.Paint, Label8.Paint, Label10.Paint, Label11.Paint, Label17.Paint, Label19.Paint, PictureBox7.Paint
        ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.LightGray, ButtonBorderStyle.Solid)
    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        Me.Close()
    End Sub

    Private Sub frmBearing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ValuesChanged = False

        LoadProjectInfo()
        LoadLimits()
        AllowOnlyNumbers(Me)
        For Each txtBox In Me.Controls.OfType(Of TextBox)()
            txtBox.Modified = False
        Next
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
        txtB1WH.Text = TempProjectObj.BA.WH
        txtB1WL.Text = TempProjectObj.BA.WL
        txtB1SH.Text = TempProjectObj.BA.SH
        txtB1SL.Text = TempProjectObj.BA.SL
        chkB1Byp.Checked = TempProjectObj.BA.Bypass

        txtB2WH.Text = TempProjectObj.BB.WH
        txtB2WL.Text = TempProjectObj.BB.WL
        txtB2SH.Text = TempProjectObj.BB.SH
        txtB2SL.Text = TempProjectObj.BB.SL
        chkB2Byp.Checked = TempProjectObj.BB.Bypass

        txtB3WH.Text = TempProjectObj.BC.WH
        txtB3WL.Text = TempProjectObj.BC.WL
        txtB3SH.Text = TempProjectObj.BC.SH
        txtB3SL.Text = TempProjectObj.BC.SL
        chkB3Byp.Checked = TempProjectObj.BC.Bypass

        txtB4WH.Text = TempProjectObj.BD.WH
        txtB4WL.Text = TempProjectObj.BD.WL
        txtB4SH.Text = TempProjectObj.BD.SH
        txtB4SL.Text = TempProjectObj.BD.SL
        chkB4Byp.Checked = TempProjectObj.BD.Bypass

        txtVibAWH.Text = TempProjectObj.VibrationA.WH
        txtVibAWL.Text = TempProjectObj.VibrationA.WL
        txtVibASH.Text = TempProjectObj.VibrationA.SH
        txtVibASL.Text = TempProjectObj.VibrationA.SL
        chkVibAByp.Checked = TempProjectObj.VibrationA.Bypass

        txtVibBWH.Text = TempProjectObj.VibrationB.WH
        txtVibBWL.Text = TempProjectObj.VibrationB.WL
        txtVibBSH.Text = TempProjectObj.VibrationB.SH
        txtVibBSL.Text = TempProjectObj.VibrationB.SL
        chkVibBByp.Checked = TempProjectObj.VibrationB.Bypass

        txtVibCWH.Text = TempProjectObj.VibrationC.WH
        txtVibCWL.Text = TempProjectObj.VibrationC.WL
        txtVibCSH.Text = TempProjectObj.VibrationC.SH
        txtVibCSL.Text = TempProjectObj.VibrationC.SL
        chkVibCByp.Checked = TempProjectObj.VibrationC.Bypass

        txtVibDWH.Text = TempProjectObj.VibrationD.WH
        txtVibDWL.Text = TempProjectObj.VibrationD.WL
        txtVibDSH.Text = TempProjectObj.VibrationD.SH
        txtVibDSL.Text = TempProjectObj.VibrationD.SL
        chkVibDByp.Checked = TempProjectObj.VibrationD.Bypass

        cmbNoOfBearings.SelectedIndex = 1

    End Sub

    Function UpdateBearingCls() As Boolean

        Try
            If cmbNoOfBearings.SelectedIndex = 0 Then 'Use only one to update all other bearing characteristics
                If Convert.ToSingle(txtB1SL.Text) < Convert.ToSingle(txtB1WL.Text) And Convert.ToSingle(txtB1WL.Text) < Convert.ToSingle(txtB1WH.Text) And Convert.ToSingle(txtB1WH.Text) < Convert.ToSingle(txtB1SH.Text) Then

                    txtB2WH.Text = If(String.IsNullOrEmpty(txtB1WH.Text), 0, txtB1WH.Text)
                    txtB2WL.Text = If(String.IsNullOrEmpty(txtB1WL.Text), 0, txtB1WL.Text)
                    txtB2SH.Text = If(String.IsNullOrEmpty(txtB1SH.Text), 0, txtB1SH.Text)
                    txtB2SL.Text = If(String.IsNullOrEmpty(txtB1SL.Text), 0, txtB1SL.Text)
                    chkB2Byp.Checked = chkB1Byp.Checked

                    txtB3WH.Text = If(String.IsNullOrEmpty(txtB1WH.Text), 0, txtB1WH.Text)
                    txtB3WL.Text = If(String.IsNullOrEmpty(txtB1WL.Text), 0, txtB1WL.Text)
                    txtB3SH.Text = If(String.IsNullOrEmpty(txtB1SH.Text), 0, txtB1SH.Text)
                    txtB3SL.Text = If(String.IsNullOrEmpty(txtB1SL.Text), 0, txtB1SL.Text)
                    chkB3Byp.Checked = chkB1Byp.Checked

                    txtB4WH.Text = If(String.IsNullOrEmpty(txtB1WH.Text), 0, txtB1WH.Text)
                    txtB4WL.Text = If(String.IsNullOrEmpty(txtB1WL.Text), 0, txtB1WL.Text)
                    txtB4SH.Text = If(String.IsNullOrEmpty(txtB1SH.Text), 0, txtB1SH.Text)
                    txtB4SL.Text = If(String.IsNullOrEmpty(txtB1SL.Text), 0, txtB1SL.Text)
                    chkB4Byp.Checked = chkB1Byp.Checked
                Else
                    MessageBox.Show("Head A Bearing Limits are not OK", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

                If Convert.ToSingle(txtVibASL.Text) < Convert.ToSingle(txtVibAWL.Text) And Convert.ToSingle(txtVibAWL.Text) < Convert.ToSingle(txtVibAWH.Text) And Convert.ToSingle(txtVibAWH.Text) < Convert.ToSingle(txtVibASH.Text) Then

                    txtVibBWH.Text = If(String.IsNullOrEmpty(txtB1WH.Text), 0, txtVibAWH.Text)
                    txtVibBWL.Text = If(String.IsNullOrEmpty(txtB1WL.Text), 0, txtVibAWL.Text)
                    txtVibBSH.Text = If(String.IsNullOrEmpty(txtB1SH.Text), 0, txtVibASH.Text)
                    txtVibBSL.Text = If(String.IsNullOrEmpty(txtB1SL.Text), 0, txtVibASL.Text)
                    chkVibBByp.Checked = chkVibAByp.Checked

                    txtVibCWH.Text = If(String.IsNullOrEmpty(txtB1WH.Text), 0, txtVibAWH.Text)
                    txtVibCWL.Text = If(String.IsNullOrEmpty(txtB1WL.Text), 0, txtVibAWL.Text)
                    txtVibCSH.Text = If(String.IsNullOrEmpty(txtB1SH.Text), 0, txtVibASH.Text)
                    txtVibCSL.Text = If(String.IsNullOrEmpty(txtB1SL.Text), 0, txtVibASL.Text)
                    chkVibCByp.Checked = chkVibAByp.Checked

                    txtVibDWH.Text = If(String.IsNullOrEmpty(txtB1WH.Text), 0, txtVibAWH.Text)
                    txtVibDWL.Text = If(String.IsNullOrEmpty(txtB1WL.Text), 0, txtVibAWL.Text)
                    txtVibDSH.Text = If(String.IsNullOrEmpty(txtB1SH.Text), 0, txtVibASH.Text)
                    txtVibDSL.Text = If(String.IsNullOrEmpty(txtB1SL.Text), 0, txtVibASL.Text)
                    chkVibDByp.Checked = chkVibAByp.Checked
                Else
                    MessageBox.Show("Head A Vibration Limits are not OK", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            End If

            If Convert.ToSingle(txtB1SL.Text) < Convert.ToSingle(txtB1WL.Text) And Convert.ToSingle(txtB1WL.Text) < Convert.ToSingle(txtB1WH.Text) And Convert.ToSingle(txtB1WH.Text) < Convert.ToSingle(txtB1SH.Text) Then
                TempProjectObj.BA.WH = txtB1WH.Text
                TempProjectObj.BA.WL = txtB1WL.Text
                TempProjectObj.BA.SH = txtB1SH.Text
                TempProjectObj.BA.SL = txtB1SL.Text
                TempProjectObj.BA.Bypass = chkB1Byp.Checked
            Else
                MessageBox.Show("Head A Bearing Limits are not OK", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            If Convert.ToSingle(txtB2SL.Text) < Convert.ToSingle(txtB1WL.Text) And Convert.ToSingle(txtB1WL.Text) < Convert.ToSingle(txtB1WH.Text) And Convert.ToSingle(txtB1WH.Text) < Convert.ToSingle(txtB1SH.Text) Then

                TempProjectObj.BB.WH = txtB2WH.Text
                TempProjectObj.BB.WL = txtB2WL.Text
                TempProjectObj.BB.SH = txtB2SH.Text
                TempProjectObj.BB.SL = txtB2SL.Text
                TempProjectObj.BB.Bypass = chkB2Byp.Checked
            Else
                MessageBox.Show("Head B Bearing  Limits are not OK", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            If Convert.ToSingle(txtB3SL.Text) < Convert.ToSingle(txtB3WL.Text) And Convert.ToSingle(txtB3WL.Text) < Convert.ToSingle(txtB3WH.Text) And Convert.ToSingle(txtB3WH.Text) < Convert.ToSingle(txtB3SH.Text) Then

                TempProjectObj.BC.WH = txtB3WH.Text
                TempProjectObj.BC.WL = txtB3WL.Text
                TempProjectObj.BC.SH = txtB3SH.Text
                TempProjectObj.BC.SL = txtB3SL.Text
                TempProjectObj.BC.Bypass = chkB3Byp.Checked
            Else
                MessageBox.Show("Head C Bearing  Limits are not OK", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            If Convert.ToSingle(txtB4SL.Text) < Convert.ToSingle(txtB4WL.Text) And Convert.ToSingle(txtB4WL.Text) < Convert.ToSingle(txtB4WH.Text) And Convert.ToSingle(txtB4WH.Text) < Convert.ToSingle(txtB4SH.Text) Then

                TempProjectObj.BD.WH = txtB4WH.Text
                TempProjectObj.BD.WL = txtB4WL.Text
                TempProjectObj.BD.SH = txtB4SH.Text
                TempProjectObj.BD.SL = txtB4SL.Text
                TempProjectObj.BD.Bypass = chkB4Byp.Checked
            Else
                MessageBox.Show("Head D Bearing  Limits are not OK", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            If Convert.ToSingle(txtVibASL.Text) < Convert.ToSingle(txtVibAWL.Text) And Convert.ToSingle(txtVibAWL.Text) < Convert.ToSingle(txtVibAWH.Text) And Convert.ToSingle(txtVibAWH.Text) < Convert.ToSingle(txtVibASH.Text) Then
                TempProjectObj.VibrationA.WH = txtVibAWH.Text
                TempProjectObj.VibrationA.WL = txtVibAWL.Text
                TempProjectObj.VibrationA.SH = txtVibASH.Text
                TempProjectObj.VibrationA.SL = txtVibASL.Text
                TempProjectObj.VibrationA.Bypass = chkVibAByp.Checked
            Else
                MessageBox.Show("Head A Vibration Limits are not OK", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            If Convert.ToSingle(txtVibBSL.Text) < Convert.ToSingle(txtVibBWL.Text) And Convert.ToSingle(txtVibBWL.Text) < Convert.ToSingle(txtVibBWH.Text) And Convert.ToSingle(txtVibBWH.Text) < Convert.ToSingle(txtVibBSH.Text) Then

                TempProjectObj.VibrationB.WH = txtVibBWH.Text
                TempProjectObj.VibrationB.WL = txtVibBWL.Text
                TempProjectObj.VibrationB.SH = txtVibBSH.Text
                TempProjectObj.VibrationB.SL = txtVibBSL.Text
                TempProjectObj.VibrationB.Bypass = chkVibBByp.Checked
            Else
                MessageBox.Show("Head B Vibration Limits are not OK", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            If Convert.ToSingle(txtVibCSL.Text) < Convert.ToSingle(txtVibCWL.Text) And Convert.ToSingle(txtVibCWL.Text) < Convert.ToSingle(txtVibCWH.Text) And Convert.ToSingle(txtVibCWH.Text) < Convert.ToSingle(txtVibCSH.Text) Then

                TempProjectObj.VibrationC.WH = txtVibCWH.Text
                TempProjectObj.VibrationC.WL = txtVibCWL.Text
                TempProjectObj.VibrationC.SH = txtVibCSH.Text
                TempProjectObj.VibrationC.SL = txtVibCSL.Text
                TempProjectObj.VibrationC.Bypass = chkVibCByp.Checked
            Else
                MessageBox.Show("Head C Vibration Limits are not OK", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            If Convert.ToSingle(txtVibDSL.Text) < Convert.ToSingle(txtVibDWL.Text) And Convert.ToSingle(txtVibDWL.Text) < Convert.ToSingle(txtVibDWH.Text) And Convert.ToSingle(txtVibDWH.Text) < Convert.ToSingle(txtVibDSH.Text) Then

                TempProjectObj.VibrationD.WH = txtVibDWH.Text
                TempProjectObj.VibrationD.WL = txtVibDWL.Text
                TempProjectObj.VibrationD.SH = txtVibDSH.Text
                TempProjectObj.VibrationD.SL = txtVibDSL.Text
                TempProjectObj.VibrationD.Bypass = chkVibDByp.Checked
            Else
                MessageBox.Show("Head D Vibration  Limits are not OK", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Empty or null values in inputs. Please enter a valid number", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try


        'TempProjectObj.NoofBearings = cmbNoOfBearings.Text
        Return True
    End Function

    Private Sub frmBearing_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.DialogResult = DialogResult.No

        Dim ValModified As Boolean = False

        If TempProjectObj.BA.Bypass <> chkB1Byp.Checked Then ValModified = True
        If TempProjectObj.BB.Bypass <> chkB2Byp.Checked Then ValModified = True
        If TempProjectObj.BC.Bypass <> chkB3Byp.Checked Then ValModified = True
        If TempProjectObj.BD.Bypass <> chkB4Byp.Checked Then ValModified = True

        If TempProjectObj.VibrationA.Bypass <> chkVibAByp.Checked Then ValModified = True
        If TempProjectObj.VibrationB.Bypass <> chkVibBByp.Checked Then ValModified = True
        If TempProjectObj.VibrationC.Bypass <> chkVibCByp.Checked Then ValModified = True
        If TempProjectObj.VibrationD.Bypass <> chkVibDByp.Checked Then ValModified = True


        For Each txtBox In Me.Controls.OfType(Of TextBox)()
            If txtBox.Modified Then
                ValModified = True
                txtBox.Modified = False
            End If
        Next

        If ValModified Then
            Me.DialogResult = DialogResult.Yes
            If MessageBox.Show("Do you want to update project with these values?", "Limits", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If Not UpdateBearingCls() Then e.Cancel = True
                Exit Sub
            End If
        End If
    End Sub

    Sub BearingSelection()
        If cmbNoOfBearings.SelectedIndex = 0 Then
            txtB2WH.Visible = False
            txtB2WL.Visible = False
            txtB2SH.Visible = False
            txtB2SL.Visible = False
            chkB2Byp.Visible = False

            txtB3WH.Visible = False
            txtB3WL.Visible = False
            txtB3SH.Visible = False
            txtB3SL.Visible = False
            chkB3Byp.Visible = False

            txtB4WH.Visible = False
            txtB4WL.Visible = False
            txtB4SH.Visible = False
            txtB4SL.Visible = False
            chkB4Byp.Visible = False

            Label13.Visible = False
            Label14.Visible = False
            Label15.Visible = False

            txtVibBWH.Visible = False
            txtVibBWL.Visible = False
            txtVibBSH.Visible = False
            txtVibBSL.Visible = False
            chkVibBByp.Visible = False

            txtVibCWH.Visible = False
            txtVibCWL.Visible = False
            txtVibCSH.Visible = False
            txtVibCSL.Visible = False
            chkVibCByp.Visible = False

            txtVibDWH.Visible = False
            txtVibDWL.Visible = False
            txtVibDSH.Visible = False
            txtVibDSL.Visible = False
            chkVibDByp.Visible = False

            Label25.Visible = False
            Label22.Visible = False
            Label24.Visible = False

        Else
            txtB2WH.Visible = True
            txtB2WL.Visible = True
            txtB2SH.Visible = True
            txtB2SL.Visible = True
            chkB2Byp.Visible = True

            txtB3WH.Visible = True
            txtB3WL.Visible = True
            txtB3SH.Visible = True
            txtB3SL.Visible = True
            chkB3Byp.Visible = True

            txtB4WH.Visible = True
            txtB4WL.Visible = True
            txtB4SH.Visible = True
            txtB4SL.Visible = True
            chkB4Byp.Visible = True

            Label13.Visible = True
            Label14.Visible = True
            Label15.Visible = True

            txtVibBWH.Visible = True
            txtVibBWL.Visible = True
            txtVibBSH.Visible = True
            txtVibBSL.Visible = True
            chkVibBByp.Visible = True

            txtVibCWH.Visible = True
            txtVibCWL.Visible = True
            txtVibCSH.Visible = True
            txtVibCSL.Visible = True
            chkVibCByp.Visible = True

            txtVibDWH.Visible = True
            txtVibDWL.Visible = True
            txtVibDSH.Visible = True
            txtVibDSL.Visible = True
            chkVibDByp.Visible = True

            Label25.Visible = True
            Label22.Visible = True
            Label24.Visible = True
        End If
    End Sub

    Private Sub cmbNoOfBearings_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbNoOfBearings.SelectedIndexChanged
        BearingSelection()
    End Sub
End Class
