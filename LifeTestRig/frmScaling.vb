Imports MySql.Data.MySqlClient
Public Class frmScaling
    Dim con As MySqlConnection = New MySqlConnection(serv)
    Dim adp As MySqlDataAdapter
    Dim ds As DataSet
    Dim dt1, dt2 As DataTable
    Dim cb As MySqlCommandBuilder
    Dim formshown As Boolean = False
    Dim myPLC As PLCCls
    Dim StationNo As Integer = 1

    Private Sub Bordergray(sender As Object, e As PaintEventArgs) Handles Label4.Paint, Label9.Paint, Label17.Paint, Label19.Paint, Label3.Paint, Label7.Paint, Label8.Paint, Label10.Paint, Label34.Paint, Label36.Paint, Label37.Paint, Label38.Paint, Label24.Paint, Label22.Paint, Label28.Paint, Label30.Paint, Label47.Paint, Label48.Paint
        ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.LightGray, ButtonBorderStyle.Solid)
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        LoadValuesfromDB()
    End Sub

    Sub LoadValuesfromPLC()
        txtSAB1.Text = myPLC.GetTagVal("B1TempA_Scale")
        txtIAB1.Text = myPLC.GetTagVal("B1TempA_Intercept")

        txtSAB2.Text = myPLC.GetTagVal("B2TempA_Scale")
        txtIAB2.Text = myPLC.GetTagVal("B2TempA_Intercept")

        txtSAB3.Text = myPLC.GetTagVal("B3TempA_Scale")
        txtIAB3.Text = myPLC.GetTagVal("B3TempA_Intercept")

        txtSAB4.Text = myPLC.GetTagVal("B4TempA_Scale")
        txtIAB4.Text = myPLC.GetTagVal("B4TempA_Intercept")

        txtSVibA.Text = myPLC.GetTagVal("VibrationA_Scale")
        txtIVibA.Text = myPLC.GetTagVal("VibrationA_Intercept")

        txtSBB1.Text = myPLC.GetTagVal("B1TempB_Scale")
        txtIBB1.Text = myPLC.GetTagVal("B1TempB_Intercept")

        txtSBB2.Text = myPLC.GetTagVal("B2TempB_Scale")
        txtIBB2.Text = myPLC.GetTagVal("B2TempB_Intercept")

        txtSBB3.Text = myPLC.GetTagVal("B3TempB_Scale")
        txtIBB3.Text = myPLC.GetTagVal("B3TempB_Intercept")

        txtSBB4.Text = myPLC.GetTagVal("B4TempB_Scale")
        txtIBB4.Text = myPLC.GetTagVal("B4TempB_Intercept")


        txtSLOT.Text = myPLC.GetTagVal("InTankTemp_Scale")
        txtILOT.Text = myPLC.GetTagVal("InTankTemp_Intercept")

        txtSTOT.Text = myPLC.GetTagVal("OutTankTemp_Scale")
        txtITOT.Text = myPLC.GetTagVal("OutTankTemp_Intercept")

        txtSVibB.Text = myPLC.GetTagVal("VibrationB_Scale")
        txtIVibB.Text = myPLC.GetTagVal("VibrationB_Intercept")

        txtSSpeed.Text = myPLC.GetTagVal("Speed_Scale")
        txtISpeed.Text = myPLC.GetTagVal("Speed_Intercept")

        txtSLdA.Text = myPLC.GetTagVal("LoadA_Scale")
        txtILdA.Text = myPLC.GetTagVal("LoadA_Intercept")

        txtSLdB.Text = myPLC.GetTagVal("LoadB_Scale")
        txtILdB.Text = myPLC.GetTagVal("LoadB_Intercept")

        txtLoadMul.Text = myPLC.GetTagVal("LoadMul")
        txtloadprop.Text = myPLC.GetTagVal("LoadProp")
        txtLoadInt.Text = myPLC.GetTagVal("LoadInt")
        txtLoadDer.Text = myPLC.GetTagVal("LoadDer")



    End Sub

    Sub SaveValuestoPLC()

        Try
            myPLC.SetTagVal("B1TempA_Scale", Convert.ToSingle(txtSAB1.Text))
            myPLC.SetTagVal("B1TempA_Intercept", Convert.ToSingle(txtIAB1.Text))

            myPLC.SetTagVal("B2TempA_Scale", Convert.ToSingle(txtSAB2.Text))
            myPLC.SetTagVal("B2TempA_Intercept", Convert.ToSingle(txtIAB2.Text))

            myPLC.SetTagVal("B3TempA_Scale", Convert.ToSingle(txtSAB3.Text))
            myPLC.SetTagVal("B3TempA_Intercept", Convert.ToSingle(txtIAB3.Text))

            myPLC.SetTagVal("B4TempA_Scale", Convert.ToSingle(txtSAB4.Text))
            myPLC.SetTagVal("B4TempA_Intercept", Convert.ToSingle(txtIAB4.Text))

            myPLC.SetTagVal("VibrationA_Scale", Convert.ToSingle(txtSVibA.Text))
            myPLC.SetTagVal("VibrationA_Intercept", Convert.ToSingle(txtIVibA.Text))

            myPLC.SetTagVal("B1TempB_Scale", Convert.ToSingle(txtSBB1.Text))
            myPLC.SetTagVal("B1TempB_Intercept", Convert.ToSingle(txtIBB1.Text))

            myPLC.SetTagVal("B2TempB_Scale", Convert.ToSingle(txtSBB2.Text))
            myPLC.SetTagVal("B2TempB_Intercept", Convert.ToSingle(txtIBB2.Text))

            myPLC.SetTagVal("B3TempB_Scale", Convert.ToSingle(txtSBB3.Text))
            myPLC.SetTagVal("B3TempB_Intercept", Convert.ToSingle(txtIBB3.Text))

            myPLC.SetTagVal("B4TempB_Scale", Convert.ToSingle(txtSBB4.Text))
            myPLC.SetTagVal("B4TempB_Intercept", Convert.ToSingle(txtIBB4.Text))


            myPLC.SetTagVal("InTankTemp_Scale", Convert.ToSingle(txtSLOT.Text))
            myPLC.SetTagVal("InTankTemp_Intercept", Convert.ToSingle(txtILOT.Text))

            myPLC.SetTagVal("OutTankTemp_Scale", Convert.ToSingle(txtSTOT.Text))
            myPLC.SetTagVal("OutTankTemp_Intercept", Convert.ToSingle(txtITOT.Text))

            myPLC.SetTagVal("VibrationB_Scale", Convert.ToSingle(txtSVibB.Text))
            myPLC.SetTagVal("VibrationB_Intercept", Convert.ToSingle(txtIVibB.Text))

            myPLC.SetTagVal("Speed_Scale", Convert.ToSingle(txtSSpeed.Text))
            myPLC.SetTagVal("Speed_Intercept", Convert.ToSingle(txtISpeed.Text))

            myPLC.SetTagVal("LoadA_Scale", Convert.ToSingle(txtSLdA.Text))
            myPLC.SetTagVal("LoadA_Intercept", Convert.ToSingle(txtILdA.Text))

            myPLC.SetTagVal("LoadB_Scale", Convert.ToSingle(txtSLdB.Text))
            myPLC.SetTagVal("LoadB_Intercept", Convert.ToSingle(txtILdB.Text))

            myPLC.SetTagVal("LoadMul", Convert.ToSingle(txtLoadMul.Text))
            myPLC.SetTagVal("LoadProp", Convert.ToSingle(txtLoadProp.Text))
            myPLC.SetTagVal("LoadInt", Convert.ToSingle(txtLoadInt.Text))
            myPLC.SetTagVal("LoadDer", Convert.ToSingle(txtLoadDer.Text))


            txtLoadMul.Enabled = False
            txtLoadProp.Enabled = False
            txtLoadInt.Enabled = False
            txtLoadDer.Enabled = False
            chkLoadMul.Checked = False

        Catch ex As Exception
            MessageBox.Show("Empty or null values in inputs. Please enter a valid number", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Sub LoadValuesfromDB()
        Dim constr As String = "SELECT * from scaling where StationNo=" & StationNo & " Order by idScaling "
        If GetDataMySQL(con, adp, ds, dt1, False, constr) Then

            txtSAB1.Text = dt1.Rows(0).Item("Slope")
            txtIAB1.Text = dt1.Rows(0).Item("Intercept")

            txtSAB2.Text = dt1.Rows(1).Item("Slope")
            txtIAB2.Text = dt1.Rows(1).Item("Intercept")

            txtSAB3.Text = dt1.Rows(2).Item("Slope")
            txtIAB3.Text = dt1.Rows(2).Item("Intercept")

            txtSAB4.Text = dt1.Rows(3).Item("Slope")
            txtIAB4.Text = dt1.Rows(3).Item("Intercept")

            txtSVibA.Text = dt1.Rows(4).Item("Slope")
            txtIVibA.Text = dt1.Rows(4).Item("Intercept")


            txtSBB1.Text = dt1.Rows(5).Item("Slope")
            txtIBB1.Text = dt1.Rows(5).Item("Intercept")

            txtSBB2.Text = dt1.Rows(6).Item("Slope")
            txtIBB2.Text = dt1.Rows(6).Item("Intercept")

            txtSBB3.Text = dt1.Rows(7).Item("Slope")
            txtIBB3.Text = dt1.Rows(7).Item("Intercept")

            txtSBB4.Text = dt1.Rows(8).Item("Slope")
            txtIBB4.Text = dt1.Rows(8).Item("Intercept")

            txtSVibB.Text = dt1.Rows(9).Item("Slope")
            txtIVibB.Text = dt1.Rows(9).Item("Intercept")

            txtSLOT.Text = dt1.Rows(10).Item("Slope")
            txtILOT.Text = dt1.Rows(10).Item("Intercept")

            txtSTOT.Text = dt1.Rows(11).Item("Slope")
            txtITOT.Text = dt1.Rows(11).Item("Intercept")

            txtSLdA.Text = dt1.Rows(12).Item("Slope")
            txtILdA.Text = dt1.Rows(12).Item("Intercept")

            txtSSpeed.Text = dt1.Rows(13).Item("Slope")
            txtISpeed.Text = dt1.Rows(13).Item("Intercept")

            txtSLdB.Text = dt1.Rows(14).Item("Slope")
            txtILdB.Text = dt1.Rows(14).Item("Intercept")

        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveValuestoDB()
    End Sub

    Private Sub btnPLCLoad_Click(sender As Object, e As EventArgs) Handles btnPLCLoad.Click
        LoadValuesfromPLC()
        MessageBox.Show("All Tag values are loaded", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub btnPLCSave_Click(sender As Object, e As EventArgs) Handles btnPLCSave.Click
        SaveValuestoPLC()
        MessageBox.Show("Tag values are saved to selected Machine PLC System", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub frmScaling_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbMC1.Text = Station.MC1.mMachineName
        rbMC2.Text = Station.MC2.mMachineName
        rbMC3.Text = Station.MC3.mMachineName
        rbMC4.Text = Station.MC4.mMachineName
        rbMC1.Checked = True
        myPLC = Station.Comms.PLC1
        AllowOnlyNumbers(Me)
    End Sub

    Private Sub rbMC1_CheckedChanged(sender As Object, e As EventArgs) Handles rbMC1.CheckedChanged, rbMC2.CheckedChanged, rbMC3.CheckedChanged, rbMC4.CheckedChanged
        If rbMC1.Checked Then myPLC = Station.Comms.PLC1 : StationNo = 1
        If rbMC2.Checked Then myPLC = Station.Comms.PLC2 : StationNo = 2
        If rbMC3.Checked Then myPLC = Station.Comms.PLC3 : StationNo = 3
        If rbMC4.Checked Then myPLC = Station.Comms.PLC4 : StationNo = 4
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkLoadMul.CheckedChanged
        If chkLoadMul.Checked Then
            If MessageBox.Show("Changing this may change actual load. Do you want to Proceed?", "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                txtLoadMul.Enabled = True
                txtLoadDer.Enabled = True
                txtLoadInt.Enabled = True
                txtLoadProp.Enabled = True
            Else
                chkLoadMul.Checked = False
                txtLoadDer.Enabled = False
                txtLoadInt.Enabled = False
                txtLoadProp.Enabled = False
            End If

        End If
    End Sub

    Private Sub Label31_Click(sender As Object, e As EventArgs) Handles Label31.Click, Label40.Click, Label46.Click, Label45.Click

    End Sub

    Sub SaveValuestoDB()
        Dim constr As String = "SELECT * from scaling where StationNo=" & StationNo & " Order by idScaling "
        If GetDataMySQL(con, adp, ds, dt1, False, constr) Then
            Try
                dt1.Rows(0).Item("Slope") = txtSAB1.Text
                dt1.Rows(0).Item("Intercept") = txtIAB1.Text

                dt1.Rows(1).Item("Slope") = txtSAB2.Text
                dt1.Rows(1).Item("Intercept") = txtIAB2.Text

                dt1.Rows(2).Item("Slope") = txtSAB3.Text
                dt1.Rows(2).Item("Intercept") = txtIAB3.Text

                dt1.Rows(3).Item("Slope") = txtSAB4.Text
                dt1.Rows(3).Item("Intercept") = txtIAB4.Text

                dt1.Rows(4).Item("Slope") = txtSVibA.Text
                dt1.Rows(4).Item("Intercept") = txtIVibA.Text


                dt1.Rows(5).Item("Slope") = txtSBB1.Text
                dt1.Rows(5).Item("Intercept") = txtIBB1.Text

                dt1.Rows(6).Item("Slope") = txtSBB2.Text
                dt1.Rows(6).Item("Intercept") = txtIBB2.Text

                dt1.Rows(7).Item("Slope") = txtSBB3.Text
                dt1.Rows(7).Item("Intercept") = txtIBB3.Text

                dt1.Rows(8).Item("Slope") = txtSBB4.Text
                dt1.Rows(8).Item("Intercept") = txtIBB4.Text

                dt1.Rows(9).Item("Slope") = txtSVibB.Text
                dt1.Rows(9).Item("Intercept") = txtIVibB.Text

                dt1.Rows(10).Item("Slope") = txtSLOT.Text
                dt1.Rows(10).Item("Intercept") = txtILOT.Text

                dt1.Rows(11).Item("Slope") = txtSTOT.Text
                dt1.Rows(11).Item("Intercept") = txtITOT.Text

                dt1.Rows(12).Item("Slope") = txtSLdA.Text
                dt1.Rows(12).Item("Intercept") = txtILdA.Text

                dt1.Rows(13).Item("Slope") = txtSSpeed.Text
                dt1.Rows(13).Item("Intercept") = txtISpeed.Text

                dt1.Rows(14).Item("Slope") = txtSLdB.Text
                dt1.Rows(14).Item("Intercept") = txtILdB.Text

                cb = New MySqlCommandBuilder(adp) 'to make the ds updatable
                cb.ConflictOption = ConflictOption.OverwriteChanges
                adp.Update(dt1)
            Catch ex As Exception
                MessageBox.Show("Database:error is:" & ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

        End If
    End Sub
End Class
