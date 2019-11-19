Public Class frmPID
    Dim PIDManual As Boolean = False
    Private Sub frmPID_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        rdbMC1A.Text = My.Settings("MC1Size")
        rdbMC2A.Text = My.Settings("MC2Size")
        rdbMC3A.Text = My.Settings("MC3Size")
        rdbMC4A.Text = My.Settings("MC4Size")
        rdbMC1A.Checked = True



        vpbPV.Minimum = 0
        vpbPV.Maximum = 16100
        vpbMV.Minimum = 0
        vpbMV.Maximum = 16100
        AllowOnlyNumbers(Me)

        txtMV.Text = (Station.MC.PLC.GetTagVal("PIDMV") / 16000) * 100
    End Sub



    Private Sub txtPV_TextChanged(sender As Object, e As EventArgs) Handles txtPV.TextChanged
        Dim val As Integer = If(txtPV.Text <> "", CInt(txtPV.Text), 0)
        lblPV.Text = Format((val / 1000) + 4, "###0.00") & " mA"
        If val > 16000 Then val = 16000
        If val < 0 Then val = 0
        vpbPV.Value = val

    End Sub

    Private Sub rdbMC1B_CheckedChanged(sender As Object, e As EventArgs) Handles rdbMC1A.CheckedChanged, rdbMC2A.CheckedChanged, rdbMC3A.CheckedChanged, rdbMC4A.CheckedChanged
        HandleChecks()
    End Sub

    Sub HandleChecks()
        'If rdbMC1A.Checked Then
        '    CurrentHead = Station.MC1.HeadA

        'ElseIf rdbMC2A.Checked Then
        '    CurrentHead = Station.MC2.HeadA

        'ElseIf rdbMC3A.Checked Then
        '    CurrentHead = Station.MC3.HeadA

        'ElseIf rdbMC4A.Checked Then
        '    CurrentHead = Station.MC4.HeadA

        'End If

    End Sub

    Private Sub Tmr_Tick(sender As Object, e As EventArgs) Handles Tmr.Tick
        PIDManual = Station.MC.PLC.GetTagVal("PIDManual")
        If PIDManual Then
            lblAutoMan.Text = "MANUAL"
            lblAutoMan.BackColor = Color.LightYellow
            txtMV.Enabled = True

        Else
            lblAutoMan.Text = "AUTO"
            lblAutoMan.BackColor = Color.LightGreen
            txtMV.Enabled = False
        End If


        txtLoad.Text = Station.MC.PLC.GetTagVal("PIDLoad")
        txtPress.Text = Station.MC.PLC.GetTagVal("PIDPress")
        txtSV.Text = Station.MC.PLC.GetTagValUint16("PIDSV")
        txtPV.Text = Station.MC.PLC.GetTagValUint16("PIDPV")

        If Not txtMV.Enabled Then txtMV.Text = (Station.MC.PLC.GetTagVal("PIDMV") / 16000) * 100

        If Not txtLoadMul.Enabled Then txtLoadMul.Text = Station.MC.PLC.GetTagVal("LoadMul")

        If Not txtProp.Enabled Then txtProp.Text = Station.MC.PLC.GetTagVal("PIDProp")
        If Not txtProp.Enabled Then txtInteg.Text = Station.MC.PLC.GetTagVal("PIDInt")
        If Not txtProp.Enabled Then txtDiffGain.Text = Station.MC.PLC.GetTagVal("PIDDiffGain")
        If Not txtProp.Enabled Then txtDiffTime.Text = Station.MC.PLC.GetTagVal("PIDDiffTime")
        If Not txtProp.Enabled Then txtFilter.Text = Station.MC.PLC.GetTagVal("PIDFilt")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnAutoMan.Click
        PIDManual = Station.MC.PLC.GetTagVal("PIDManual")
        If PIDManual Then Station.MC.PLC.SetTagVal("PIDManual", 0) Else Station.MC.PLC.SetTagVal("PIDManual", 1)
        'If PIDManual Then PIDManual = False Else PIDManual = True
    End Sub

    Private Sub chkLoadMul_CheckedChanged(sender As Object, e As EventArgs) Handles chkLoadMul.CheckedChanged
        If chkLoadMul.Checked Then
            If MessageBox.Show("Changing this may change actual load. Do you want to Proceed?", "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                txtProp.Enabled = True
                txtInteg.Enabled = True
                txtDiffGain.Enabled = True
                txtDiffTime.Enabled = True
                txtFilter.Enabled = True
                btnSave.Enabled = True
            Else
                txtProp.Enabled = False
                txtInteg.Enabled = False
                txtDiffGain.Enabled = False
                txtDiffTime.Enabled = False
                txtFilter.Enabled = False
                btnSave.Enabled = False
                chkLoadMul.Checked = False
            End If
        Else
            txtProp.Enabled = False
            txtInteg.Enabled = False
            txtDiffGain.Enabled = False
            txtDiffTime.Enabled = False
            txtFilter.Enabled = False
            btnSave.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        txtProp.Enabled = False
        txtInteg.Enabled = False
        txtDiffGain.Enabled = False
        txtDiffTime.Enabled = False
        txtFilter.Enabled = False
        chkLoadMul.Checked = False
        Station.MC.PLC.SetTagVal("PIDProp", If(txtProp.Text <> "", CInt(txtProp.Text), 0))
        Station.MC.PLC.SetTagVal("PIDInt", If(txtInteg.Text <> "", CInt(txtInteg.Text), 0))
        Station.MC.PLC.SetTagVal("PIDDiffGain", If(txtDiffGain.Text <> "", CInt(txtDiffGain.Text), 0))
        Station.MC.PLC.SetTagVal("PIDDiffTime", If(txtDiffTime.Text <> "", CInt(txtDiffTime.Text), 0))
        Station.MC.PLC.SetTagVal("PIDFilt", If(txtFilter.Text <> "", CInt(txtFilter.Text), 0))
        Station.MC.PLC.SetTagVal("PIDReset", 1)
    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click

    End Sub

    Private Sub chkLoad_CheckedChanged(sender As Object, e As EventArgs) Handles chkLoad.CheckedChanged
        If chkLoad.Checked Then
            If MessageBox.Show("Changing this may change actual load. Do you want to Proceed?", "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                txtLoadMul.Enabled = True
                btnMulSave.Enabled = True

            Else
                chkLoadMul.Checked = False
                txtLoadMul.Enabled = False
            End If

        End If
    End Sub

    Private Sub btnMulSave_Click(sender As Object, e As EventArgs) Handles btnMulSave.Click
        Station.MC.PLC.SetTagVal("LoadMul", Convert.ToSingle(txtLoadMul.Text))
        btnMulSave.Enabled = False
        chkLoad.Checked = False
        txtLoadMul.Enabled = False
    End Sub


    Private Sub txtMV_TextChanged(sender As Object, e As EventArgs) Handles txtMV.TextChanged
        'Dim val As Integer = If(txtMV.Text <> "", CInt(txtMV.Text), 0)
        Dim val As Integer = (16000 * txtMV.Value) / 100
        If val > 16000 Then val = 16000
        If val < 0 Then val = 0
        vpbMV.Value = val
        lblMV.Text = Format((val / 1000) + 4, "###0.00") & " mA"
        Station.MC.PLC.SetTagVal("PIDMV", val)
    End Sub
End Class
