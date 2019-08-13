<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.toolStrp = New System.Windows.Forms.ToolStrip()
        Me.toolbtnDefault = New System.Windows.Forms.ToolStripButton()
        Me.toolbtnNewProj = New System.Windows.Forms.ToolStripButton()
        Me.toolBtnOpenPrj = New System.Windows.Forms.ToolStripButton()
        Me.toolBtnModifyPrj = New System.Windows.Forms.ToolStripButton()
        Me.toolBtnComplete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.toolStrplblHead = New System.Windows.Forms.ToolStripLabel()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.toolbtnCommSettings = New System.Windows.Forms.ToolStripButton()
        Me.toolbtnScale = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel()
        Me.toolBtnPID = New System.Windows.Forms.ToolStripButton()
        Me.toolBtnPLC = New System.Windows.Forms.ToolStripButton()
        Me.toolBtnCharts = New System.Windows.Forms.ToolStripButton()
        Me.toolBtnReports = New System.Windows.Forms.ToolStripButton()
        Me.toolStrpAlarm = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.StsStrp = New System.Windows.Forms.StatusStrip()
        Me.pnlBtm = New System.Windows.Forms.Panel()
        Me.dgvAlarmMain = New System.Windows.Forms.DataGridView()
        Me.lblAlarmCaption = New System.Windows.Forms.Label()
        Me.bkgrndWrkr1 = New System.ComponentModel.BackgroundWorker()
        Me.bkgrndWrkr2 = New System.ComponentModel.BackgroundWorker()
        Me.bkgrndWrkr3 = New System.ComponentModel.BackgroundWorker()
        Me.bkgrndWrkr4 = New System.ComponentModel.BackgroundWorker()
        Me.TmrAlarm = New System.Windows.Forms.Timer(Me.components)
        Me.TmrLubOil = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.toolStrp.SuspendLayout()
        Me.pnlBtm.SuspendLayout()
        CType(Me.dgvAlarmMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'toolStrp
        '
        Me.toolStrp.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.toolStrp.ImageScalingSize = New System.Drawing.Size(64, 64)
        Me.toolStrp.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolbtnDefault, Me.toolbtnNewProj, Me.toolBtnOpenPrj, Me.toolBtnModifyPrj, Me.toolBtnComplete, Me.ToolStripLabel3, Me.ToolStripLabel1, Me.toolStrplblHead, Me.toolStripSeparator, Me.ToolStripLabel5, Me.toolbtnCommSettings, Me.toolbtnScale, Me.ToolStripSeparator1, Me.ToolStripLabel2, Me.ToolStripLabel6, Me.toolBtnPID, Me.toolBtnPLC, Me.toolBtnCharts, Me.toolBtnReports, Me.toolStrpAlarm, Me.ToolStripSeparator2, Me.ToolStripLabel4, Me.ToolStripButton1})
        Me.toolStrp.Location = New System.Drawing.Point(0, 0)
        Me.toolStrp.Name = "toolStrp"
        Me.toolStrp.Size = New System.Drawing.Size(1162, 71)
        Me.toolStrp.TabIndex = 2
        Me.toolStrp.Text = "ToolStrip1"
        '
        'toolbtnDefault
        '
        Me.toolbtnDefault.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolbtnDefault.Image = CType(resources.GetObject("toolbtnDefault.Image"), System.Drawing.Image)
        Me.toolbtnDefault.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolbtnDefault.Name = "toolbtnDefault"
        Me.toolbtnDefault.Size = New System.Drawing.Size(68, 68)
        Me.toolbtnDefault.Text = "Home"
        '
        'toolbtnNewProj
        '
        Me.toolbtnNewProj.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolbtnNewProj.Image = CType(resources.GetObject("toolbtnNewProj.Image"), System.Drawing.Image)
        Me.toolbtnNewProj.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolbtnNewProj.Name = "toolbtnNewProj"
        Me.toolbtnNewProj.Size = New System.Drawing.Size(68, 68)
        Me.toolbtnNewProj.Text = "New Project"
        '
        'toolBtnOpenPrj
        '
        Me.toolBtnOpenPrj.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolBtnOpenPrj.Image = Global.LifeTestRig.My.Resources.Resources.Open
        Me.toolBtnOpenPrj.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBtnOpenPrj.Name = "toolBtnOpenPrj"
        Me.toolBtnOpenPrj.Size = New System.Drawing.Size(68, 68)
        Me.toolBtnOpenPrj.Text = "Open Existing Project"
        '
        'toolBtnModifyPrj
        '
        Me.toolBtnModifyPrj.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolBtnModifyPrj.Image = Global.LifeTestRig.My.Resources.Resources.edit
        Me.toolBtnModifyPrj.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBtnModifyPrj.Name = "toolBtnModifyPrj"
        Me.toolBtnModifyPrj.Size = New System.Drawing.Size(68, 68)
        Me.toolBtnModifyPrj.Text = "Modify Project"
        '
        'toolBtnComplete
        '
        Me.toolBtnComplete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolBtnComplete.Image = Global.LifeTestRig.My.Resources.Resources.Complete
        Me.toolBtnComplete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBtnComplete.Name = "toolBtnComplete"
        Me.toolBtnComplete.Size = New System.Drawing.Size(68, 68)
        Me.toolBtnComplete.Text = "Complete Project"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(28, 68)
        Me.ToolStripLabel3.Text = "       "
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.AutoSize = False
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(50, 68)
        Me.ToolStripLabel1.Text = "    "
        '
        'toolStrplblHead
        '
        Me.toolStrplblHead.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolStrplblHead.Name = "toolStrplblHead"
        Me.toolStrplblHead.Size = New System.Drawing.Size(28, 68)
        Me.toolStrplblHead.Text = "       "
        Me.toolStrplblHead.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 71)
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(28, 68)
        Me.ToolStripLabel5.Text = "       "
        Me.ToolStripLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'toolbtnCommSettings
        '
        Me.toolbtnCommSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolbtnCommSettings.Image = Global.LifeTestRig.My.Resources.Resources.communication1
        Me.toolbtnCommSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolbtnCommSettings.Name = "toolbtnCommSettings"
        Me.toolbtnCommSettings.Size = New System.Drawing.Size(68, 68)
        Me.toolbtnCommSettings.Text = "Settings"
        '
        'toolbtnScale
        '
        Me.toolbtnScale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolbtnScale.Image = Global.LifeTestRig.My.Resources.Resources.Scale
        Me.toolbtnScale.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolbtnScale.Name = "toolbtnScale"
        Me.toolbtnScale.Size = New System.Drawing.Size(68, 68)
        Me.toolbtnScale.Text = "Scale"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 71)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.AutoSize = False
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(50, 68)
        Me.ToolStripLabel2.Text = "    "
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(28, 68)
        Me.ToolStripLabel6.Text = "       "
        Me.ToolStripLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'toolBtnPID
        '
        Me.toolBtnPID.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolBtnPID.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolBtnPID.Image = Global.LifeTestRig.My.Resources.Resources.PID
        Me.toolBtnPID.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBtnPID.Name = "toolBtnPID"
        Me.toolBtnPID.Size = New System.Drawing.Size(68, 68)
        Me.toolBtnPID.Text = "       "
        Me.toolBtnPID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.toolBtnPID.ToolTipText = "Load PID"
        '
        'toolBtnPLC
        '
        Me.toolBtnPLC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolBtnPLC.Image = Global.LifeTestRig.My.Resources.Resources.PLC
        Me.toolBtnPLC.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBtnPLC.Name = "toolBtnPLC"
        Me.toolBtnPLC.Size = New System.Drawing.Size(68, 68)
        Me.toolBtnPLC.Text = "PLC Status"
        '
        'toolBtnCharts
        '
        Me.toolBtnCharts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolBtnCharts.Image = Global.LifeTestRig.My.Resources.Resources.charts
        Me.toolBtnCharts.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBtnCharts.Name = "toolBtnCharts"
        Me.toolBtnCharts.Size = New System.Drawing.Size(68, 68)
        Me.toolBtnCharts.Text = "Graphs"
        '
        'toolBtnReports
        '
        Me.toolBtnReports.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolBtnReports.Image = Global.LifeTestRig.My.Resources.Resources.report
        Me.toolBtnReports.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBtnReports.Name = "toolBtnReports"
        Me.toolBtnReports.Size = New System.Drawing.Size(68, 68)
        Me.toolBtnReports.Text = "Reports"
        '
        'toolStrpAlarm
        '
        Me.toolStrpAlarm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStrpAlarm.Image = Global.LifeTestRig.My.Resources.Resources.Alarm
        Me.toolStrpAlarm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStrpAlarm.Name = "toolStrpAlarm"
        Me.toolStrpAlarm.Size = New System.Drawing.Size(68, 68)
        Me.toolStrpAlarm.Text = "Alarms"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 71)
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(19, 68)
        Me.ToolStripLabel4.Text = "    "
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(68, 68)
        Me.ToolStripButton1.Text = "ToolStrpInfo"
        '
        'StsStrp
        '
        Me.StsStrp.Location = New System.Drawing.Point(0, 551)
        Me.StsStrp.Name = "StsStrp"
        Me.StsStrp.Size = New System.Drawing.Size(1162, 22)
        Me.StsStrp.TabIndex = 3
        Me.StsStrp.Text = "StatusStrip1"
        '
        'pnlBtm
        '
        Me.pnlBtm.Controls.Add(Me.dgvAlarmMain)
        Me.pnlBtm.Controls.Add(Me.lblAlarmCaption)
        Me.pnlBtm.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBtm.Location = New System.Drawing.Point(0, 455)
        Me.pnlBtm.Name = "pnlBtm"
        Me.pnlBtm.Size = New System.Drawing.Size(1162, 96)
        Me.pnlBtm.TabIndex = 6
        '
        'dgvAlarmMain
        '
        Me.dgvAlarmMain.AllowUserToAddRows = False
        Me.dgvAlarmMain.AllowUserToDeleteRows = False
        Me.dgvAlarmMain.AllowUserToResizeRows = False
        Me.dgvAlarmMain.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvAlarmMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAlarmMain.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvAlarmMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvAlarmMain.Location = New System.Drawing.Point(0, 68)
        Me.dgvAlarmMain.MultiSelect = False
        Me.dgvAlarmMain.Name = "dgvAlarmMain"
        Me.dgvAlarmMain.Size = New System.Drawing.Size(1162, 28)
        Me.dgvAlarmMain.TabIndex = 1
        '
        'lblAlarmCaption
        '
        Me.lblAlarmCaption.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblAlarmCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAlarmCaption.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblAlarmCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlarmCaption.Location = New System.Drawing.Point(0, 0)
        Me.lblAlarmCaption.Name = "lblAlarmCaption"
        Me.lblAlarmCaption.Size = New System.Drawing.Size(1162, 21)
        Me.lblAlarmCaption.TabIndex = 0
        Me.lblAlarmCaption.Text = "Alarm"
        '
        'bkgrndWrkr1
        '
        Me.bkgrndWrkr1.WorkerReportsProgress = True
        Me.bkgrndWrkr1.WorkerSupportsCancellation = True
        '
        'bkgrndWrkr2
        '
        Me.bkgrndWrkr2.WorkerReportsProgress = True
        Me.bkgrndWrkr2.WorkerSupportsCancellation = True
        '
        'bkgrndWrkr3
        '
        Me.bkgrndWrkr3.WorkerReportsProgress = True
        Me.bkgrndWrkr3.WorkerSupportsCancellation = True
        '
        'bkgrndWrkr4
        '
        Me.bkgrndWrkr4.WorkerReportsProgress = True
        Me.bkgrndWrkr4.WorkerSupportsCancellation = True
        '
        'TmrAlarm
        '
        Me.TmrAlarm.Enabled = True
        Me.TmrAlarm.Interval = 10000
        '
        'TmrLubOil
        '
        Me.TmrLubOil.Enabled = True
        Me.TmrLubOil.Interval = 10000
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.LifeTestRig.My.Resources.Resources.actemium_logo
        Me.PictureBox1.Location = New System.Drawing.Point(1279, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(131, 20)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1162, 573)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.pnlBtm)
        Me.Controls.Add(Me.StsStrp)
        Me.Controls.Add(Me.toolStrp)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmMain"
        Me.Tag = "  "
        Me.Text = "Life Test Rig - Timken India"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.toolStrp.ResumeLayout(False)
        Me.toolStrp.PerformLayout()
        Me.pnlBtm.ResumeLayout(False)
        CType(Me.dgvAlarmMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents toolStrp As ToolStrip
    Friend WithEvents StsStrp As StatusStrip
    Friend WithEvents toolbtnNewProj As ToolStripButton
    Friend WithEvents toolbtnCommSettings As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents pnlBtm As Panel
    Friend WithEvents lblAlarmCaption As Label
    Friend WithEvents dgvAlarmMain As DataGridView
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents toolbtnScale As ToolStripButton
    Friend WithEvents toolStrpAlarm As ToolStripButton
    Friend WithEvents bkgrndWrkr1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents toolBtnOpenPrj As ToolStripButton
    Friend WithEvents toolBtnModifyPrj As ToolStripButton
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents toolStrplblHead As ToolStripLabel
    Friend WithEvents ToolStripLabel5 As ToolStripLabel
    Friend WithEvents toolBtnCharts As ToolStripButton
    Friend WithEvents toolBtnReports As ToolStripButton
    Friend WithEvents toolbtnDefault As ToolStripButton
    Friend WithEvents toolBtnPLC As ToolStripButton
    Friend WithEvents bkgrndWrkr2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents bkgrndWrkr3 As System.ComponentModel.BackgroundWorker
    Friend WithEvents bkgrndWrkr4 As System.ComponentModel.BackgroundWorker
    Friend WithEvents TmrAlarm As Timer
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents ToolStripLabel6 As ToolStripLabel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents toolBtnComplete As ToolStripButton
    Friend WithEvents TmrLubOil As Timer
    Friend WithEvents toolBtnPID As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripLabel4 As ToolStripLabel
    Friend WithEvents ToolStripButton1 As ToolStripButton
End Class
