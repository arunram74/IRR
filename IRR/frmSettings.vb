Imports System.ComponentModel
Imports System.Windows.Forms

Public Class frmSettings

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Dim strArr(12) As String
        Dim SettingStr As String = ""

        strArr(0) = txtStn1.Text
        strArr(1) = txtStn2.Text
        strArr(2) = txtStn3.Text
        strArr(3) = txtStn4.Text
        strArr(4) = txtStn5.Text
        strArr(5) = txtStn6.Text
        strArr(6) = txtStn7.Text
        strArr(7) = txtStn8.Text
        strArr(8) = txtStn9.Text
        strArr(9) = txtStn10.Text
        strArr(10) = txtStn11.Text
        strArr(11) = txtStn12.Text

        For i = 0 To 11
            If strArr(i) = "" Then strArr(i) = 0
            SettingStr += strArr(i) & ","
        Next
        My.Settings.Item("PLCStations") = SettingStr
        My.Settings.Item("TemplateLoc") = txtTemplateLoc.Text
        My.Settings.Item("MC1Size") = txtMC1.Text
        My.Settings.Item("MC2Size") = txtMC2.Text
        My.Settings.Item("MC3Size") = txtMC3.Text
        My.Settings.Item("MC4Size") = txtMC4.Text
        My.Settings.Item("TagTo") = TxtTagTo.Text
        My.Settings.Item("TagFrom") = TxtTagFrom.Text
        My.Settings("MonitorAfter") = CInt(nupMonAct.Value)
        My.Settings("DBName") = txtDBName.Text
        My.Settings.Save()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtMC1.Text = My.Settings("MC1Size")
        txtMC2.Text = My.Settings("MC2Size")
        txtMC3.Text = My.Settings("MC3Size")
        txtMC4.Text = My.Settings("MC4Size")
        nupMonAct.Value = My.Settings("MonitorAfter")
        TxtTagFrom.Text = My.Settings("TagFrom")
        TxtTagTo.Text = My.Settings("TagTo")
        txtDBName.Text = My.Settings("DBName")

        Dim strArr() As String

        Try
            Dim PLCStnStr As String = My.Settings.Item("PLCStations")

            strArr = PLCStnStr.Split(","c)
            txtStn1.Text = strArr(0)
            txtStn2.Text = strArr(1)
            txtStn3.Text = strArr(2)
            txtStn4.Text = strArr(3)
            txtStn5.Text = strArr(4)
            txtStn6.Text = strArr(5)
            txtStn7.Text = strArr(6)
            txtStn8.Text = strArr(7)
            txtStn9.Text = strArr(8)
            txtStn10.Text = strArr(9)
            txtStn11.Text = strArr(10)
            txtStn12.Text = strArr(11)


        Catch ex As Exception
            MessageBox.Show("Cannot Load PLC Station Settings", System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        txtTemplateLoc.Text = Templatepath

    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        FolderBrowserDialog1.ShowDialog()
        txtTemplateLoc.Text = FolderBrowserDialog1.SelectedPath & "\"
        Templatepath = txtTemplateLoc.Text


    End Sub

    Private Sub txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStn1.KeyPress, txtStn2.KeyPress, txtStn3.KeyPress, txtStn4.KeyPress, txtStn5.KeyPress, txtStn6.KeyPress, txtStn7.KeyPress, txtStn8.KeyPress, txtStn9.KeyPress, txtStn10.KeyPress, txtStn11.KeyPress, txtStn12.KeyPress, txtMC1.KeyPress, txtMC2.KeyPress, txtMC3.KeyPress, txtMC4.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub



End Class
