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
        txtSAB1.Text = myPLC.GetTagVal("BATemp_Scale")
        txtIAB1.Text = myPLC.GetTagVal("BATemp_Intercept")

        txtSAB2.Text = myPLC.GetTagVal("BBTemp_Scale")
        txtIAB2.Text = myPLC.GetTagVal("BBTemp_Intercept")

        txtSAB3.Text = myPLC.GetTagVal("BCTemp_Scale")
        txtIAB3.Text = myPLC.GetTagVal("BCTemp_Intercept")

        txtSAB4.Text = myPLC.GetTagVal("BDTemp_Scale")
        txtIAB4.Text = myPLC.GetTagVal("BDTemp_Intercept")


        txtSBB1.Text = myPLC.GetTagVal("VibA_Scale")
        txtIBB1.Text = myPLC.GetTagVal("VibA_Intercept")

        txtSBB2.Text = myPLC.GetTagVal("VibB_Scale")
        txtIBB2.Text = myPLC.GetTagVal("VibB_Intercept")

        txtSBB3.Text = myPLC.GetTagVal("VibC_Scale")
        txtIBB3.Text = myPLC.GetTagVal("VibC_Intercept")

        txtSBB4.Text = myPLC.GetTagVal("VibD_Scale")
        txtIBB4.Text = myPLC.GetTagVal("VibD_Intercept")


        txtSLOT.Text = myPLC.GetTagVal("InTankTemp_Scale")
        txtILOT.Text = myPLC.GetTagVal("InTankTemp_Intercept")

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
            myPLC.SetTagVal("BATempA_Scale", Convert.ToSingle(txtSAB1.Text))
            myPLC.SetTagVal("BATempA_Intercept", Convert.ToSingle(txtIAB1.Text))

            myPLC.SetTagVal("BBTempA_Scale", Convert.ToSingle(txtSAB2.Text))
            myPLC.SetTagVal("BBTempA_Intercept", Convert.ToSingle(txtIAB2.Text))

            myPLC.SetTagVal("BCTempA_Scale", Convert.ToSingle(txtSAB3.Text))
            myPLC.SetTagVal("BCTempA_Intercept", Convert.ToSingle(txtIAB3.Text))

            myPLC.SetTagVal("BDTempA_Scale", Convert.ToSingle(txtSAB4.Text))
            myPLC.SetTagVal("BDTempA_Intercept", Convert.ToSingle(txtIAB4.Text))


            myPLC.SetTagVal("VibA_Scale", Convert.ToSingle(txtSBB1.Text))
            myPLC.SetTagVal("VibA_Intercept", Convert.ToSingle(txtIBB1.Text))

            myPLC.SetTagVal("VibB_Scale", Convert.ToSingle(txtSBB2.Text))
            myPLC.SetTagVal("VibB_Intercept", Convert.ToSingle(txtIBB2.Text))

            myPLC.SetTagVal("VibC_Scale", Convert.ToSingle(txtSBB3.Text))
            myPLC.SetTagVal("VibC_Intercept", Convert.ToSingle(txtIBB3.Text))

            myPLC.SetTagVal("VibD_Scale", Convert.ToSingle(txtSBB4.Text))
            myPLC.SetTagVal("VibD_Intercept", Convert.ToSingle(txtIBB4.Text))


            myPLC.SetTagVal("InTankTemp_Scale", Convert.ToSingle(txtSLOT.Text))
            myPLC.SetTagVal("InTankTemp_Intercept", Convert.ToSingle(txtILOT.Text))

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

            txtSAB1.Text = dt1.Rows(0).Item("Slope")
            txtIAB1.Text = dt1.Rows(0).Item("Intercept")

            txtSAB2.Text = dt1.Rows(1).Item("Slope")
            txtIAB2.Text = dt1.Rows(1).Item("Intercept")

            txtSAB3.Text = dt1.Rows(2).Item("Slope")
            txtIAB3.Text = dt1.Rows(2).Item("Intercept")

            txtSAB4.Text = dt1.Rows(3).Item("Slope")
            txtIAB4.Text = dt1.Rows(3).Item("Intercept")



            txtSBB1.Text = dt1.Rows(4).Item("Slope")
            txtIBB1.Text = dt1.Rows(4).Item("Intercept")

            txtSBB2.Text = dt1.Rows(5).Item("Slope")
            txtIBB2.Text = dt1.Rows(5).Item("Intercept")

            txtSBB3.Text = dt1.Rows(6).Item("Slope")
            txtIBB3.Text = dt1.Rows(6).Item("Intercept")

            txtSBB4.Text = dt1.Rows(7).Item("Slope")
            txtIBB4.Text = dt1.Rows(7).Item("Intercept")


            txtSLOT.Text = dt1.Rows(8).Item("Slope")
            txtILOT.Text = dt1.Rows(8).Item("Intercept")

            txtSTOT.Text = dt1.Rows(9).Item("Slope")
            txtITOT.Text = dt1.Rows(9).Item("Intercept")

            txtSLd.Text = dt1.Rows(10).Item("Slope")
            txtILd.Text = dt1.Rows(10).Item("Intercept")

            txtSSpeed.Text = dt1.Rows(11).Item("Slope")
            txtISpeed.Text = dt1.Rows(11).Item("Intercept")



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



                dt1.Rows(4).Item("Slope") = txtSBB1.Text
                dt1.Rows(4).Item("Intercept") = txtIBB1.Text

                dt1.Rows(5).Item("Slope") = txtSBB2.Text
                dt1.Rows(5).Item("Intercept") = txtIBB2.Text

                dt1.Rows(6).Item("Slope") = txtSBB3.Text
                dt1.Rows(6).Item("Intercept") = txtIBB3.Text

                dt1.Rows(7).Item("Slope") = txtSBB4.Text
                dt1.Rows(7).Item("Intercept") = txtIBB4.Text

                dt1.Rows(8).Item("Slope") = txtSLOT.Text
                dt1.Rows(8).Item("Intercept") = txtILOT.Text

                dt1.Rows(9).Item("Slope") = txtSTOT.Text
                dt1.Rows(9).Item("Intercept") = txtITOT.Text

                dt1.Rows(10).Item("Slope") = txtSLd.Text
                dt1.Rows(10).Item("Intercept") = txtILd.Text

                dt1.Rows(11).Item("Slope") = txtSSpeed.Text
                dt1.Rows(11).Item("Intercept") = txtISpeed.Text



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
