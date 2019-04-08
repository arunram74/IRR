<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReport
    Inherits LifeTestRig.frmChild

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnDataLogs = New System.Windows.Forms.Button()
        Me.btnUtility = New System.Windows.Forms.Button()
        Me.btnRunReport = New System.Windows.Forms.Button()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.cmbPrjt = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbPrjStatus = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtFromDate = New System.Windows.Forms.DateTimePicker()
        Me.dtToDate = New System.Windows.Forms.DateTimePicker()
        Me.dtFromTime = New System.Windows.Forms.DateTimePicker()
        Me.dtToTime = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btStopReason = New System.Windows.Forms.Button()
        Me.btnLubOilTemp = New System.Windows.Forms.Button()
        Me.cmbMachine = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkDate = New System.Windows.Forms.CheckBox()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnDataLogs
        '
        Me.btnDataLogs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDataLogs.Location = New System.Drawing.Point(241, 232)
        Me.btnDataLogs.Name = "btnDataLogs"
        Me.btnDataLogs.Size = New System.Drawing.Size(120, 34)
        Me.btnDataLogs.TabIndex = 8
        Me.btnDataLogs.Text = "Data Logs..."
        Me.btnDataLogs.UseVisualStyleBackColor = True
        '
        'btnUtility
        '
        Me.btnUtility.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUtility.Location = New System.Drawing.Point(641, 232)
        Me.btnUtility.Name = "btnUtility"
        Me.btnUtility.Size = New System.Drawing.Size(134, 34)
        Me.btnUtility.TabIndex = 10
        Me.btnUtility.Text = "Machine Utility..."
        Me.btnUtility.UseVisualStyleBackColor = True
        '
        'btnRunReport
        '
        Me.btnRunReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRunReport.Location = New System.Drawing.Point(441, 232)
        Me.btnRunReport.Name = "btnRunReport"
        Me.btnRunReport.Size = New System.Drawing.Size(120, 34)
        Me.btnRunReport.TabIndex = 9
        Me.btnRunReport.Text = "Run Report..."
        Me.btnRunReport.UseVisualStyleBackColor = True
        '
        'Label57
        '
        Me.Label57.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.Location = New System.Drawing.Point(76, 66)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(148, 32)
        Me.Label57.TabIndex = 361
        Me.Label57.Text = "Project ID"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbPrjt
        '
        Me.cmbPrjt.DropDownHeight = 206
        Me.cmbPrjt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrjt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPrjt.FormattingEnabled = True
        Me.cmbPrjt.IntegralHeight = False
        Me.cmbPrjt.Location = New System.Drawing.Point(243, 66)
        Me.cmbPrjt.MaxDropDownItems = 20
        Me.cmbPrjt.Name = "cmbPrjt"
        Me.cmbPrjt.Size = New System.Drawing.Size(247, 28)
        Me.cmbPrjt.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(80, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 32)
        Me.Label1.TabIndex = 363
        Me.Label1.Text = "Project Status"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbPrjStatus
        '
        Me.cmbPrjStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPrjStatus.FormattingEnabled = True
        Me.cmbPrjStatus.Location = New System.Drawing.Point(243, 107)
        Me.cmbPrjStatus.Name = "cmbPrjStatus"
        Me.cmbPrjStatus.Size = New System.Drawing.Size(247, 28)
        Me.cmbPrjStatus.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(132, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 32)
        Me.Label2.TabIndex = 363
        Me.Label2.Text = "Between"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(487, 151)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 32)
        Me.Label3.TabIndex = 366
        Me.Label3.Text = "and"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtFromDate
        '
        Me.dtFromDate.CustomFormat = "MM/dd/yyyy "
        Me.dtFromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFromDate.Location = New System.Drawing.Point(243, 154)
        Me.dtFromDate.Name = "dtFromDate"
        Me.dtFromDate.Size = New System.Drawing.Size(105, 26)
        Me.dtFromDate.TabIndex = 4
        '
        'dtToDate
        '
        Me.dtToDate.CustomFormat = "MM/dd/yyyy"
        Me.dtToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtToDate.Location = New System.Drawing.Point(554, 154)
        Me.dtToDate.Name = "dtToDate"
        Me.dtToDate.Size = New System.Drawing.Size(101, 26)
        Me.dtToDate.TabIndex = 6
        '
        'dtFromTime
        '
        Me.dtFromTime.CustomFormat = "MM/dd/yyyy "
        Me.dtFromTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtFromTime.Location = New System.Drawing.Point(354, 154)
        Me.dtFromTime.Name = "dtFromTime"
        Me.dtFromTime.ShowUpDown = True
        Me.dtFromTime.Size = New System.Drawing.Size(105, 26)
        Me.dtFromTime.TabIndex = 5
        '
        'dtToTime
        '
        Me.dtToTime.CustomFormat = "MM/dd/yyyy"
        Me.dtToTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtToTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtToTime.Location = New System.Drawing.Point(661, 154)
        Me.dtToTime.Name = "dtToTime"
        Me.dtToTime.ShowUpDown = True
        Me.dtToTime.Size = New System.Drawing.Size(101, 26)
        Me.dtToTime.TabIndex = 7
        '
        'PictureBox9
        '
        Me.PictureBox9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox9.Location = New System.Drawing.Point(55, 52)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(1193, 157)
        Me.PictureBox9.TabIndex = 369
        Me.PictureBox9.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(55, 215)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1193, 71)
        Me.PictureBox1.TabIndex = 370
        Me.PictureBox1.TabStop = False
        '
        'btStopReason
        '
        Me.btStopReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btStopReason.Location = New System.Drawing.Point(841, 232)
        Me.btStopReason.Name = "btStopReason"
        Me.btStopReason.Size = New System.Drawing.Size(131, 34)
        Me.btStopReason.TabIndex = 11
        Me.btStopReason.Text = "Stop Reason..."
        Me.btStopReason.UseVisualStyleBackColor = True
        '
        'btnLubOilTemp
        '
        Me.btnLubOilTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLubOilTemp.Location = New System.Drawing.Point(1040, 232)
        Me.btnLubOilTemp.Name = "btnLubOilTemp"
        Me.btnLubOilTemp.Size = New System.Drawing.Size(139, 34)
        Me.btnLubOilTemp.TabIndex = 12
        Me.btnLubOilTemp.Text = "Lube Oil Temp..."
        Me.btnLubOilTemp.UseVisualStyleBackColor = True
        '
        'cmbMachine
        '
        Me.cmbMachine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMachine.FormattingEnabled = True
        Me.cmbMachine.Items.AddRange(New Object() {"ALL", "5.1", "5.2", "5.3", "5.4"})
        Me.cmbMachine.Location = New System.Drawing.Point(641, 66)
        Me.cmbMachine.Name = "cmbMachine"
        Me.cmbMachine.Size = New System.Drawing.Size(174, 28)
        Me.cmbMachine.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(496, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(126, 32)
        Me.Label4.TabIndex = 361
        Me.Label4.Text = "Machine No"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkDate
        '
        Me.chkDate.AutoSize = True
        Me.chkDate.Checked = True
        Me.chkDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDate.Location = New System.Drawing.Point(813, 156)
        Me.chkDate.Name = "chkDate"
        Me.chkDate.Size = New System.Drawing.Size(127, 24)
        Me.chkDate.TabIndex = 371
        Me.chkDate.Text = "Bypass Dates"
        Me.chkDate.UseVisualStyleBackColor = True
        '
        'frmReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1435, 644)
        Me.Controls.Add(Me.chkDate)
        Me.Controls.Add(Me.btnLubOilTemp)
        Me.Controls.Add(Me.btStopReason)
        Me.Controls.Add(Me.dtToTime)
        Me.Controls.Add(Me.dtToDate)
        Me.Controls.Add(Me.dtFromTime)
        Me.Controls.Add(Me.dtFromDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbPrjStatus)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label57)
        Me.Controls.Add(Me.cmbMachine)
        Me.Controls.Add(Me.cmbPrjt)
        Me.Controls.Add(Me.btnRunReport)
        Me.Controls.Add(Me.btnUtility)
        Me.Controls.Add(Me.btnDataLogs)
        Me.Controls.Add(Me.PictureBox9)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "frmReport"
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnDataLogs As Button
    Friend WithEvents btnUtility As Button
    Friend WithEvents btnRunReport As Button
    Friend WithEvents Label57 As Label
    Friend WithEvents cmbPrjt As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbPrjStatus As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtFromDate As DateTimePicker
    Friend WithEvents dtToDate As DateTimePicker
    Friend WithEvents dtFromTime As DateTimePicker
    Friend WithEvents dtToTime As DateTimePicker
    Friend WithEvents PictureBox9 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btStopReason As Button
    Friend WithEvents btnLubOilTemp As Button
    Friend WithEvents cmbMachine As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents chkDate As CheckBox
End Class
