Imports System.ComponentModel

Public Class frmBearing

    Public ValuesChanged As Boolean = False

    Private Sub Bordergray(sender As Object, e As PaintEventArgs) Handles Label7.Paint, Label4.Paint, Label9.Paint, Label8.Paint, Label10.Paint, Label11.Paint, Label17.Paint, Label19.Paint, lblMachine.Paint, lblPrjID.Paint, lblPV.Paint, lblCup.Paint, lblCone.Paint, lblTestType.Paint, lblBearingType.Paint, lblB1.Paint, lblB2.Paint, lblB3.Paint, lblB4.Paint, PictureBox7.Paint
        ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.LightGray, ButtonBorderStyle.Solid)
    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        Me.Close()
    End Sub

    Private Sub frmBearing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ValuesChanged = False
        lblMcHead.Text = TempProjectObj.MachineName & "H" & TempProjectObj.HeadName
        LoadProjectInfo()
        LoadLimits()
        AllowOnlyNumbers(Me)
        For Each txtBox In Me.Controls.OfType(Of TextBox)()
            txtBox.Modified = False
        Next
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
        txtB1WH.Text = TempProjectObj.B1.WH
        txtB1WL.Text = TempProjectObj.B1.WL
        txtB1SH.Text = TempProjectObj.B1.SH
        txtB1SL.Text = TempProjectObj.B1.SL
        chkB1Byp.Checked = TempProjectObj.B1.Bypass

        txtB2WH.Text = TempProjectObj.B2.WH
        txtB2WL.Text = TempProjectObj.B2.WL
        txtB2SH.Text = TempProjectObj.B2.SH
        txtB2SL.Text = TempProjectObj.B2.SL
        chkB2Byp.Checked = TempProjectObj.B2.Bypass

        txtB3WH.Text = TempProjectObj.B3.WH
        txtB3WL.Text = TempProjectObj.B3.WL
        txtB3SH.Text = TempProjectObj.B3.SH
        txtB3SL.Text = TempProjectObj.B3.SL
        chkB3Byp.Checked = TempProjectObj.B3.Bypass

        txtB4WH.Text = TempProjectObj.B4.WH
        txtB4WL.Text = TempProjectObj.B4.WL
        txtB4SH.Text = TempProjectObj.B4.SH
        txtB4SL.Text = TempProjectObj.B4.SL
        chkB4Byp.Checked = TempProjectObj.B4.Bypass

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
                    MessageBox.Show("B1 Limits are not OK", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            End If

            If Convert.ToSingle(txtB1SL.Text) < Convert.ToSingle(txtB1WL.Text) And Convert.ToSingle(txtB1WL.Text) < Convert.ToSingle(txtB1WH.Text) And Convert.ToSingle(txtB1WH.Text) < Convert.ToSingle(txtB1SH.Text) Then
                TempProjectObj.B1.WH = txtB1WH.Text
                TempProjectObj.B1.WL = txtB1WL.Text
                TempProjectObj.B1.SH = txtB1SH.Text
                TempProjectObj.B1.SL = txtB1SL.Text
                TempProjectObj.B1.Bypass = chkB1Byp.Checked
            Else
                MessageBox.Show("B1 Limits are not OK", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            If Convert.ToSingle(txtB2SL.Text) < Convert.ToSingle(txtB1WL.Text) And Convert.ToSingle(txtB1WL.Text) < Convert.ToSingle(txtB1WH.Text) And Convert.ToSingle(txtB1WH.Text) < Convert.ToSingle(txtB1SH.Text) Then

                TempProjectObj.B2.WH = txtB2WH.Text
                TempProjectObj.B2.WL = txtB2WL.Text
                TempProjectObj.B2.SH = txtB2SH.Text
                TempProjectObj.B2.SL = txtB2SL.Text
                TempProjectObj.B2.Bypass = chkB2Byp.Checked
            Else
                MessageBox.Show("B2 Limits are not OK", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            If Convert.ToSingle(txtB3SL.Text) < Convert.ToSingle(txtB3WL.Text) And Convert.ToSingle(txtB3WL.Text) < Convert.ToSingle(txtB3WH.Text) And Convert.ToSingle(txtB3WH.Text) < Convert.ToSingle(txtB3SH.Text) Then

                TempProjectObj.B3.WH = txtB3WH.Text
                TempProjectObj.B3.WL = txtB3WL.Text
                TempProjectObj.B3.SH = txtB3SH.Text
                TempProjectObj.B3.SL = txtB3SL.Text
                TempProjectObj.B3.Bypass = chkB3Byp.Checked
            Else
                MessageBox.Show("B3 Limits are not OK", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            If Convert.ToSingle(txtB4SL.Text) < Convert.ToSingle(txtB4WL.Text) And Convert.ToSingle(txtB4WL.Text) < Convert.ToSingle(txtB4WH.Text) And Convert.ToSingle(txtB4WH.Text) < Convert.ToSingle(txtB4SH.Text) Then

                TempProjectObj.B4.WH = txtB4WH.Text
                TempProjectObj.B4.WL = txtB4WL.Text
                TempProjectObj.B4.SH = txtB4SH.Text
                TempProjectObj.B4.SL = txtB4SL.Text
                TempProjectObj.B4.Bypass = chkB4Byp.Checked
            Else
                MessageBox.Show("B4 Limits are not OK", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
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

        If TempProjectObj.B1.Bypass <> chkB1Byp.Checked Then ValModified = True
        If TempProjectObj.B2.Bypass <> chkB2Byp.Checked Then ValModified = True
        If TempProjectObj.B3.Bypass <> chkB3Byp.Checked Then ValModified = True
        If TempProjectObj.B4.Bypass <> chkB4Byp.Checked Then ValModified = True



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

    Private Sub cmbNoOfBearings_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNoOfBearings.SelectedIndexChanged
        BearingSelection()
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
        End If
    End Sub
End Class
