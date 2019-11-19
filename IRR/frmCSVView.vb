Imports System.Windows.Forms
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel

Public Class Viewer
    Public CsvFilePath As String
    Public SaveAsFileName As String
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmCSVView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadtoGrid(csvGrid, CsvFilePath, True)
    End Sub

    Private Sub btnSaveAs_Click(sender As Object, e As EventArgs) Handles btnSaveAs.Click
        SaveFileDialog1.Filter = "xlsx Files (*.xlsx*)|*.xlsx"
        SaveFileDialog1.FileName = SaveAsFileName
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            ' My.Computer.FileSystem.CopyFile(CsvFilePath, SaveFileDialog1.FileName)
            Cursor.Current = Cursors.WaitCursor
            ConvertCSVToExcel(CsvFilePath, SaveFileDialog1.FileName)
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Public Sub ConvertCSVToExcel(Fromcsv As String, Toxlsx As String)
        Dim Exl As New Excel.Application()
        Try
            Dim wb1 As Excel.Workbook = Exl.Workbooks.Open(Fromcsv, Format:=4)
            Exl.DisplayAlerts = False
            wb1.SaveAs(Toxlsx, FileFormat:=XlFileFormat.xlOpenXMLWorkbook)
            wb1.Close()
            Exl.Quit()
        Catch ex As Exception
            Exl.DisplayAlerts = False
            Exl.Quit()
            MessageBox.Show(ex.Message.ToString, System.Reflection.MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
