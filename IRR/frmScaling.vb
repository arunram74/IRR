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

    Private Sub Bordergray(sender As Object, e As PaintEventArgs) Handles Label4.Paint, Label9.Paint, Label17.Paint, Label19.Paint, Label3.Paint, Label7.Paint, Label8.Paint, Label10.Paint, Label34.Paint, Label36.Paint, Label37.Paint, Label38.Paint
        ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.LightGray, ButtonBorderStyle.Solid)
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        LoadValuesfromDB()
    End Sub

    Sub LoadValuesfromPLC()
        txtSBA.Text = myPLC.GetTagVal("BTempA_Scale")
        txtIBA.Text = myPLC.GetTagVal("BTempA_Intercept")

        txtSBB.Text = myPLC.GetTagVal("BTempB_Scale")
        txtIBB.Text = myPLC.GetTagVal("BTempB_Intercept")

        txtSBC.Text = myPLC.GetTagVal("BTempC_Scale")
        txtIBC.Text = myPLC.GetTagVal("BTempC_Intercept")

        txtSBD.Text = myPLC.GetTagVal("BTempD_Scale")
        txtIBD.Text = myPLC.GetTagVal("BTempD_Intercept")

        txtSupSBA.Text = myPLC.GetTagVal("SBTempA_Scale")
        txtSupIBA.Text = myPLC.GetTagVal("SBTempA_Intercept")

        txtSupSBB.Text = myPLC.GetTagVal("SBTempB_Scale")
        txtSupIBB.Text = myPLC.GetTagVal("SBTempB_Intercept")

        txtSupSBC.Text = myPLC.GetTagVal("SBTempC_Scale")
        txtSupIBC.Text = myPLC.GetTagVal("SBTempC_Intercept")

        txtSupSBD.Text = myPLC.GetTagVal("SBTempD_Scale")
        txtSupIBD.Text = myPLC.GetTagVal("SBTempD_Intercept")

        txtSVibA.Text = myPLC.GetTagVal("VibA_Scale")
        txtIVibA.Text = myPLC.GetTagVal("VibA_Intercept")

        txtSVibB.Text = myPLC.GetTagVal("VibB_Scale")
        txtIVibB.Text = myPLC.GetTagVal("VibB_Intercept")

        txtSVibC.Text = myPLC.GetTagVal("VibC_Scale")
        txtIVibC.Text = myPLC.GetTagVal("VibC_Intercept")

        txtSVibD.Text = myPLC.GetTagVal("VibD_Scale")
        txtIVibD.Text = myPLC.GetTagVal("VibD_Intercept")


        txtSLOT.Text = myPLC.GetTagVal("Inlet_TempA_Scale")
        txtILOT.Text = myPLC.GetTagVal("Inlet_TempA_Intercept")

        txtSTOT.Text = myPLC.GetTagVal("OutTankTemp_Scale")
        txtITOT.Text = myPLC.GetTagVal("OutTankTemp_Intercept")



        txtSSpeed.Text = myPLC.GetTagVal("Speed_Scale")
        txtISpeed.Text = myPLC.GetTagVal("Speed_Intercept")

        txtSLd.Text = myPLC.GetTagVal("Load_Scale")
        txtILd.Text = myPLC.GetTagVal("Load_Intercept")


        'txtLoadMul.Text = myPLC.GetTagVal("LoadMul")
        'txtloadprop.Text = myPLC.GetTagVal("LoadProp")
        'txtLoadInt.Text = myPLC.GetTagVal("LoadInt")
        'txtLoadDer.Text = myPLC.GetTagVal("LoadDer")



    End Sub

    Sub SaveValuestoPLC()

        Try
            myPLC.SetTagVal("BTempA_Scale", Convert.ToSingle(txtSBA.Text))
            myPLC.SetTagVal("BTempA_Intercept", Convert.ToSingle(txtIBA.Text))

            myPLC.SetTagVal("BTempB_Scale", Convert.ToSingle(txtSBB.Text))
            myPLC.SetTagVal("BTempB_Intercept", Convert.ToSingle(txtIBB.Text))

            myPLC.SetTagVal("BTempC_Scale", Convert.ToSingle(txtSBC.Text))
            myPLC.SetTagVal("BTempC_Intercept", Convert.ToSingle(txtIBC.Text))

            myPLC.SetTagVal("BTempD_Scale", Convert.ToSingle(txtSBD.Text))
            myPLC.SetTagVal("BTempD_Intercept", Convert.ToSingle(txtIBD.Text))

            myPLC.SetTagVal("SBTempA_Scale", Convert.ToSingle(txtSupSBA.Text))
            myPLC.SetTagVal("SBTempA_Intercept", Convert.ToSingle(txtSupIBA.Text))

            myPLC.SetTagVal("SBTempB_Scale", Convert.ToSingle(txtSupSBB.Text))
            myPLC.SetTagVal("SBTempB_Intercept", Convert.ToSingle(txtSupIBB.Text))

            myPLC.SetTagVal("SBTempC_Scale", Convert.ToSingle(txtSupSBC.Text))
            myPLC.SetTagVal("SBTempC_Intercept", Convert.ToSingle(txtSupIBC.Text))

            myPLC.SetTagVal("SBTempD_Scale", Convert.ToSingle(txtSupSBD.Text))
            myPLC.SetTagVal("SBTempD_Intercept", Convert.ToSingle(txtSupIBD.Text))

            myPLC.SetTagVal("VibA_Scale", Convert.ToSingle(txtSVibA.Text))
            myPLC.SetTagVal("VibA_Intercept", Convert.ToSingle(txtIVibA.Text))

            myPLC.SetTagVal("VibB_Scale", Convert.ToSingle(txtSVibB.Text))
            myPLC.SetTagVal("VibB_Intercept", Convert.ToSingle(txtIVibB.Text))

            myPLC.SetTagVal("VibC_Scale", Convert.ToSingle(txtSVibC.Text))
            myPLC.SetTagVal("VibC_Intercept", Convert.ToSingle(txtIVibC.Text))

            myPLC.SetTagVal("VibD_Scale", Convert.ToSingle(txtSVibD.Text))
            myPLC.SetTagVal("VibD_Intercept", Convert.ToSingle(txtIVibD.Text))


            myPLC.SetTagVal("Inlet_TempA_Scale", Convert.ToSingle(txtSLOT.Text))
            myPLC.SetTagVal("Inlet_TempA_Intercept", Convert.ToSingle(txtILOT.Text))

            myPLC.SetTagVal("OutTankTemp_Scale", Convert.ToSingle(txtSTOT.Text))
            myPLC.SetTagVal("OutTankTemp_Intercept", Convert.ToSingle(txtITOT.Text))



            myPLC.SetTagVal("Speed_Scale", Convert.ToSingle(txtSSpeed.Text))
            myPLC.SetTagVal("Speed_Intercept", Convert.ToSingle(txtISpeed.Text))

            myPLC.SetTagVal("Load_Scale", Convert.ToSingle(txtSLd.Text))
            myPLC.SetTagVal("Load_Intercept", Convert.ToSingle(txtILd.Text))



            'myPLC.SetTagVal("LoadMul", Convert.ToSingle(txtLoadMul.Text))
            'myPLC.SetTagVal("LoadProp", Convert.ToSingle(txtLoadProp.Text))
            'myPLC.SetTagVal("LoadInt", Convert.ToSingle(txtLoadInt.Text))
            'myPLC.SetTagVal("LoadDer", Convert.ToSingle(txtLoadDer.Text))


            'txtLoadMul.Enabled = False
            'txtLoadProp.Enabled = False
            'txtLoadInt.Enabled = False
            'txtLoadDer.Enabled = False
            'chkLoadMul.Checked = False

        Catch ex As Exception
            MessageBox.Show("Empty or null values in inputs. Please enter a valid number", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Sub LoadValuesfromDB()
        Dim constr As String = "SELECT * from scaling where StationNo=" & StationNo & " Order by idScaling "
        If GetDataMySQL(con, adp, ds, dt1, False, constr) Then

            txtSBA.Text = dt1.Rows(0).Item("Slope")
            txtIBA.Text = dt1.Rows(0).Item("Intercept")

            txtSBB.Text = dt1.Rows(1).Item("Slope")
            txtIBB.Text = dt1.Rows(1).Item("Intercept")

            txtSBC.Text = dt1.Rows(2).Item("Slope")
            txtIBC.Text = dt1.Rows(2).Item("Intercept")

            txtSBD.Text = dt1.Rows(3).Item("Slope")
            txtIBD.Text = dt1.Rows(3).Item("Intercept")

            txtSupSBA.Text = dt1.Rows(4).Item("Slope")
            txtSupIBA.Text = dt1.Rows(4).Item("Intercept")

            txtSupSBB.Text = dt1.Rows(5).Item("Slope")
            txtSupIBB.Text = dt1.Rows(5).Item("Intercept")

            txtSupSBC.Text = dt1.Rows(6).Item("Slope")
            txtSupIBC.Text = dt1.Rows(6).Item("Intercept")

            txtSupSBD.Text = dt1.Rows(7).Item("Slope")
            txtSupIBD.Text = dt1.Rows(7).Item("Intercept")

            txtSVibA.Text = dt1.Rows(8).Item("Slope")
            txtIVibA.Text = dt1.Rows(8).Item("Intercept")

            txtSVibB.Text = dt1.Rows(9).Item("Slope")
            txtIVibB.Text = dt1.Rows(9).Item("Intercept")

            txtSVibC.Text = dt1.Rows(10).Item("Slope")
            txtIVibC.Text = dt1.Rows(10).Item("Intercept")

            txtSVibD.Text = dt1.Rows(11).Item("Slope")
            txtIVibD.Text = dt1.Rows(11).Item("Intercept")


            txtSLOT.Text = dt1.Rows(12).Item("Slope")
            txtILOT.Text = dt1.Rows(12).Item("Intercept")

            txtSTOT.Text = dt1.Rows(13).Item("Slope")
            txtITOT.Text = dt1.Rows(13).Item("Intercept")

            txtSLd.Text = dt1.Rows(14).Item("Slope")
            txtILd.Text = dt1.Rows(14).Item("Intercept")

            txtSSpeed.Text = dt1.Rows(15).Item("Slope")
            txtISpeed.Text = dt1.Rows(15).Item("Intercept")



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

        myPLC = Station.Comms.PLC1
        AllowOnlyNumbers(Me)
    End Sub



    'Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
    '    If chkLoadMul.Checked Then
    '        If MessageBox.Show("Changing this may change actual load. Do you want to Proceed?", "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
    '            txtLoadMul.Enabled = True
    '            txtLoadDer.Enabled = True
    '            txtLoadInt.Enabled = True
    '            txtLoadProp.Enabled = True
    '        Else
    '            chkLoadMul.Checked = False
    '            txtLoadDer.Enabled = False
    '            txtLoadInt.Enabled = False
    '            txtLoadProp.Enabled = False
    '        End If

    '    End If
    'End Sub

    Private Sub Label31_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click

    End Sub

    Private Sub Label26_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles txtSupSBB.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtSupSBA.TextChanged

    End Sub

    Private Sub Label30_Click(sender As Object, e As EventArgs) Handles Label30.Click

    End Sub

    Sub SaveValuestoDB()
        Dim constr As String = "SELECT * from scaling where StationNo=" & StationNo & " Order by idScaling "
        If GetDataMySQL(con, adp, ds, dt1, False, constr) Then
            Try
                dt1.Rows(0).Item("Slope") = txtSBA.Text
                dt1.Rows(0).Item("Intercept") = txtIBA.Text

                dt1.Rows(1).Item("Slope") = txtSBB.Text
                dt1.Rows(1).Item("Intercept") = txtIBB.Text

                dt1.Rows(2).Item("Slope") = txtSBC.Text
                dt1.Rows(2).Item("Intercept") = txtIBC.Text

                dt1.Rows(3).Item("Slope") = txtSBD.Text
                dt1.Rows(3).Item("Intercept") = txtIBD.Text


                dt1.Rows(4).Item("Slope") = txtSupSBA.Text
                dt1.Rows(4).Item("Intercept") = txtSupIBA.Text

                dt1.Rows(5).Item("Slope") = txtSupSBB.Text
                dt1.Rows(5).Item("Intercept") = txtSupIBB.Text

                dt1.Rows(6).Item("Slope") = txtSupSBC.Text
                dt1.Rows(6).Item("Intercept") = txtSupIBC.Text

                dt1.Rows(7).Item("Slope") = txtSupSBD.Text
                dt1.Rows(7).Item("Intercept") = txtSupIBD.Text



                dt1.Rows(8).Item("Slope") = txtSVibA.Text
                dt1.Rows(8).Item("Intercept") = txtIVibA.Text

                dt1.Rows(9).Item("Slope") = txtSVibB.Text
                dt1.Rows(9).Item("Intercept") = txtIVibB.Text

                dt1.Rows(10).Item("Slope") = txtSVibC.Text
                dt1.Rows(10).Item("Intercept") = txtIVibC.Text

                dt1.Rows(11).Item("Slope") = txtSVibD.Text
                dt1.Rows(11).Item("Intercept") = txtIVibD.Text

                dt1.Rows(12).Item("Slope") = txtSLOT.Text
                dt1.Rows(12).Item("Intercept") = txtILOT.Text

                dt1.Rows(13).Item("Slope") = txtSTOT.Text
                dt1.Rows(13).Item("Intercept") = txtITOT.Text

                dt1.Rows(14).Item("Slope") = txtSLd.Text
                dt1.Rows(14).Item("Intercept") = txtILd.Text

                dt1.Rows(15).Item("Slope") = txtSSpeed.Text
                dt1.Rows(15).Item("Intercept") = txtISpeed.Text



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
