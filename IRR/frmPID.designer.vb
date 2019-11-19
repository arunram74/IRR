<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPID
    Inherits IRR.frmChild

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnAutoMan = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSV = New System.Windows.Forms.TextBox()
        Me.txtPress = New System.Windows.Forms.TextBox()
        Me.txtPV = New System.Windows.Forms.TextBox()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.txtDiffTime = New System.Windows.Forms.TextBox()
        Me.txtDiffGain = New System.Windows.Forms.TextBox()
        Me.txtInteg = New System.Windows.Forms.TextBox()
        Me.txtProp = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblAutoMan = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.vpbMV = New IRR.VerticalProgressBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.vpbPV = New IRR.VerticalProgressBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtLoad = New System.Windows.Forms.TextBox()
        Me.lblMV = New System.Windows.Forms.Label()
        Me.lblPV = New System.Windows.Forms.Label()
        Me.rdbMC4A = New System.Windows.Forms.RadioButton()
        Me.rdbMC2A = New System.Windows.Forms.RadioButton()
        Me.rdbMC3A = New System.Windows.Forms.RadioButton()
        Me.rdbMC1A = New System.Windows.Forms.RadioButton()
        Me.Label145 = New System.Windows.Forms.Label()
        Me.Tmr = New System.Windows.Forms.Timer(Me.components)
        Me.Label19 = New System.Windows.Forms.Label()
        Me.chkLoadMul = New System.Windows.Forms.CheckBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtLoadMul = New System.Windows.Forms.TextBox()
        Me.chkLoad = New System.Windows.Forms.CheckBox()
        Me.btnMulSave = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtMV = New System.Windows.Forms.NumericUpDown()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.txtMV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAutoMan
        '
        Me.btnAutoMan.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnAutoMan.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAutoMan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoMan.Location = New System.Drawing.Point(511, 56)
        Me.btnAutoMan.Name = "btnAutoMan"
        Me.btnAutoMan.Size = New System.Drawing.Size(122, 30)
        Me.btnAutoMan.TabIndex = 47
        Me.btnAutoMan.Text = "Auto / Manual"
        Me.btnAutoMan.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSave.Enabled = False
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(577, 427)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(113, 29)
        Me.btnSave.TabIndex = 46
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Location = New System.Drawing.Point(175, 433)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(400, 1)
        Me.Label11.TabIndex = 43
        '
        'txtSV
        '
        Me.txtSV.Enabled = False
        Me.txtSV.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSV.Location = New System.Drawing.Point(367, 420)
        Me.txtSV.Name = "txtSV"
        Me.txtSV.Size = New System.Drawing.Size(93, 29)
        Me.txtSV.TabIndex = 42
        '
        'txtPress
        '
        Me.txtPress.Enabled = False
        Me.txtPress.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPress.Location = New System.Drawing.Point(182, 210)
        Me.txtPress.Name = "txtPress"
        Me.txtPress.Size = New System.Drawing.Size(93, 29)
        Me.txtPress.TabIndex = 41
        '
        'txtPV
        '
        Me.txtPV.Enabled = False
        Me.txtPV.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPV.Location = New System.Drawing.Point(367, 210)
        Me.txtPV.Name = "txtPV"
        Me.txtPV.Size = New System.Drawing.Size(93, 29)
        Me.txtPV.TabIndex = 40
        '
        'txtFilter
        '
        Me.txtFilter.Enabled = False
        Me.txtFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFilter.Location = New System.Drawing.Point(577, 384)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(113, 29)
        Me.txtFilter.TabIndex = 39
        '
        'txtDiffTime
        '
        Me.txtDiffTime.Enabled = False
        Me.txtDiffTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiffTime.Location = New System.Drawing.Point(577, 327)
        Me.txtDiffTime.Name = "txtDiffTime"
        Me.txtDiffTime.Size = New System.Drawing.Size(113, 29)
        Me.txtDiffTime.TabIndex = 38
        '
        'txtDiffGain
        '
        Me.txtDiffGain.Enabled = False
        Me.txtDiffGain.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiffGain.Location = New System.Drawing.Point(577, 270)
        Me.txtDiffGain.Name = "txtDiffGain"
        Me.txtDiffGain.Size = New System.Drawing.Size(113, 29)
        Me.txtDiffGain.TabIndex = 37
        '
        'txtInteg
        '
        Me.txtInteg.Enabled = False
        Me.txtInteg.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInteg.Location = New System.Drawing.Point(577, 213)
        Me.txtInteg.Name = "txtInteg"
        Me.txtInteg.Size = New System.Drawing.Size(113, 29)
        Me.txtInteg.TabIndex = 36
        '
        'txtProp
        '
        Me.txtProp.Enabled = False
        Me.txtProp.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProp.Location = New System.Drawing.Point(577, 156)
        Me.txtProp.Name = "txtProp"
        Me.txtProp.Size = New System.Drawing.Size(113, 29)
        Me.txtProp.TabIndex = 35
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.LightBlue
        Me.Label20.Location = New System.Drawing.Point(578, 370)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(113, 13)
        Me.Label20.TabIndex = 31
        Me.Label20.Text = "FILTER"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label10.Location = New System.Drawing.Point(836, 83)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "20 mA"
        '
        'lblAutoMan
        '
        Me.lblAutoMan.BackColor = System.Drawing.Color.LightGreen
        Me.lblAutoMan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAutoMan.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAutoMan.Location = New System.Drawing.Point(635, 56)
        Me.lblAutoMan.Name = "lblAutoMan"
        Me.lblAutoMan.Size = New System.Drawing.Size(122, 30)
        Me.lblAutoMan.TabIndex = 32
        Me.lblAutoMan.Text = "AUTO"
        Me.lblAutoMan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label15.Location = New System.Drawing.Point(369, 404)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(83, 13)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "Ratio ( 0-16000)"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.LightBlue
        Me.Label21.Location = New System.Drawing.Point(577, 313)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(113, 13)
        Me.Label21.TabIndex = 33
        Me.Label21.Text = "DIFFERENTIAL TIME"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.LightBlue
        Me.Label18.Location = New System.Drawing.Point(578, 256)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(113, 13)
        Me.Label18.TabIndex = 28
        Me.Label18.Text = "DIFFERENTIAL GAIN"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.LightBlue
        Me.Label17.Location = New System.Drawing.Point(578, 198)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(113, 13)
        Me.Label17.TabIndex = 27
        Me.Label17.Text = "INTEGRAL"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.LightBlue
        Me.Label16.Location = New System.Drawing.Point(578, 141)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(113, 13)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "PROPORTIONAL"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label14.Location = New System.Drawing.Point(184, 194)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 13)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "Pressure"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label9.Location = New System.Drawing.Point(836, 353)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "4 mA"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label8.Location = New System.Drawing.Point(392, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "20 mA"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.Location = New System.Drawing.Point(398, 353)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "4 mA"
        '
        'vpbMV
        '
        Me.vpbMV.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.vpbMV.Location = New System.Drawing.Point(762, 89)
        Me.vpbMV.Maximum = 16000
        Me.vpbMV.Name = "vpbMV"
        Me.vpbMV.Size = New System.Drawing.Size(38, 271)
        Me.vpbMV.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Location = New System.Drawing.Point(787, 359)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 1)
        Me.Label5.TabIndex = 21
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Location = New System.Drawing.Point(787, 89)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 1)
        Me.Label6.TabIndex = 20
        '
        'vpbPV
        '
        Me.vpbPV.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.vpbPV.Location = New System.Drawing.Point(466, 89)
        Me.vpbPV.Maximum = 16000
        Me.vpbPV.Name = "vpbPV"
        Me.vpbPV.Size = New System.Drawing.Size(38, 271)
        Me.vpbPV.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(432, 359)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 1)
        Me.Label4.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(432, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 1)
        Me.Label2.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightBlue
        Me.Label1.Location = New System.Drawing.Point(522, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(227, 372)
        Me.Label1.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Location = New System.Drawing.Point(510, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(247, 394)
        Me.Label3.TabIndex = 15
        '
        'Label12
        '
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Location = New System.Drawing.Point(267, 223)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(200, 1)
        Me.Label12.TabIndex = 44
        '
        'Label13
        '
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Location = New System.Drawing.Point(787, 222)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 1)
        Me.Label13.TabIndex = 45
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label22.Location = New System.Drawing.Point(189, 404)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(31, 13)
        Me.Label22.TabIndex = 25
        Me.Label22.Text = "Load"
        '
        'txtLoad
        '
        Me.txtLoad.Enabled = False
        Me.txtLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoad.Location = New System.Drawing.Point(168, 420)
        Me.txtLoad.Name = "txtLoad"
        Me.txtLoad.Size = New System.Drawing.Size(93, 29)
        Me.txtLoad.TabIndex = 41
        '
        'lblMV
        '
        Me.lblMV.AutoSize = True
        Me.lblMV.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblMV.Location = New System.Drawing.Point(759, 363)
        Me.lblMV.Name = "lblMV"
        Me.lblMV.Size = New System.Drawing.Size(52, 13)
        Me.lblMV.TabIndex = 24
        Me.lblMV.Text = "20.00 mA"
        '
        'lblPV
        '
        Me.lblPV.AutoSize = True
        Me.lblPV.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblPV.Location = New System.Drawing.Point(457, 363)
        Me.lblPV.Name = "lblPV"
        Me.lblPV.Size = New System.Drawing.Size(52, 13)
        Me.lblPV.TabIndex = 24
        Me.lblPV.Text = "20.00 mA"
        '
        'rdbMC4A
        '
        Me.rdbMC4A.AutoSize = True
        Me.rdbMC4A.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbMC4A.Location = New System.Drawing.Point(1048, 265)
        Me.rdbMC4A.Name = "rdbMC4A"
        Me.rdbMC4A.Size = New System.Drawing.Size(64, 24)
        Me.rdbMC4A.TabIndex = 412
        Me.rdbMC4A.TabStop = True
        Me.rdbMC4A.Text = "5.4A"
        Me.rdbMC4A.UseVisualStyleBackColor = True
        '
        'rdbMC2A
        '
        Me.rdbMC2A.AutoSize = True
        Me.rdbMC2A.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbMC2A.Location = New System.Drawing.Point(1048, 129)
        Me.rdbMC2A.Name = "rdbMC2A"
        Me.rdbMC2A.Size = New System.Drawing.Size(64, 24)
        Me.rdbMC2A.TabIndex = 410
        Me.rdbMC2A.TabStop = True
        Me.rdbMC2A.Text = "5.2A"
        Me.rdbMC2A.UseVisualStyleBackColor = True
        '
        'rdbMC3A
        '
        Me.rdbMC3A.AutoSize = True
        Me.rdbMC3A.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbMC3A.Location = New System.Drawing.Point(1048, 197)
        Me.rdbMC3A.Name = "rdbMC3A"
        Me.rdbMC3A.Size = New System.Drawing.Size(64, 24)
        Me.rdbMC3A.TabIndex = 411
        Me.rdbMC3A.TabStop = True
        Me.rdbMC3A.Text = "5.3A"
        Me.rdbMC3A.UseVisualStyleBackColor = True
        '
        'rdbMC1A
        '
        Me.rdbMC1A.AutoSize = True
        Me.rdbMC1A.Checked = True
        Me.rdbMC1A.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbMC1A.Location = New System.Drawing.Point(1048, 61)
        Me.rdbMC1A.Name = "rdbMC1A"
        Me.rdbMC1A.Size = New System.Drawing.Size(64, 24)
        Me.rdbMC1A.TabIndex = 409
        Me.rdbMC1A.TabStop = True
        Me.rdbMC1A.Text = "5.1A"
        Me.rdbMC1A.UseVisualStyleBackColor = True
        '
        'Label145
        '
        Me.Label145.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label145.Location = New System.Drawing.Point(1023, 47)
        Me.Label145.Name = "Label145"
        Me.Label145.Size = New System.Drawing.Size(117, 274)
        Me.Label145.TabIndex = 413
        Me.Label145.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Tmr
        '
        Me.Tmr.Enabled = True
        Me.Tmr.Interval = 2000
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.LightBlue
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Location = New System.Drawing.Point(557, 130)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(153, 332)
        Me.Label19.TabIndex = 14
        '
        'chkLoadMul
        '
        Me.chkLoadMul.AutoSize = True
        Me.chkLoadMul.BackColor = System.Drawing.Color.LightBlue
        Me.chkLoadMul.Location = New System.Drawing.Point(530, 107)
        Me.chkLoadMul.Name = "chkLoadMul"
        Me.chkLoadMul.Size = New System.Drawing.Size(63, 17)
        Me.chkLoadMul.TabIndex = 482
        Me.chkLoadMul.Text = "Edit this"
        Me.chkLoadMul.UseVisualStyleBackColor = False
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Location = New System.Drawing.Point(134, 47)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(849, 467)
        Me.Label23.TabIndex = 413
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(147, 56)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(95, 24)
        Me.Label24.TabIndex = 25
        Me.Label24.Text = "LOAD PID"
        '
        'txtLoadMul
        '
        Me.txtLoadMul.Enabled = False
        Me.txtLoadMul.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoadMul.Location = New System.Drawing.Point(281, 420)
        Me.txtLoadMul.Name = "txtLoadMul"
        Me.txtLoadMul.Size = New System.Drawing.Size(64, 29)
        Me.txtLoadMul.TabIndex = 41
        '
        'chkLoad
        '
        Me.chkLoad.AutoSize = True
        Me.chkLoad.BackColor = System.Drawing.Color.WhiteSmoke
        Me.chkLoad.Location = New System.Drawing.Point(282, 400)
        Me.chkLoad.Name = "chkLoad"
        Me.chkLoad.Size = New System.Drawing.Size(63, 17)
        Me.chkLoad.TabIndex = 482
        Me.chkLoad.Text = "Edit this"
        Me.chkLoad.UseVisualStyleBackColor = False
        '
        'btnMulSave
        '
        Me.btnMulSave.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnMulSave.Enabled = False
        Me.btnMulSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnMulSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMulSave.Location = New System.Drawing.Point(282, 455)
        Me.btnMulSave.Name = "btnMulSave"
        Me.btnMulSave.Size = New System.Drawing.Size(64, 29)
        Me.btnMulSave.TabIndex = 46
        Me.btnMulSave.Text = "Save"
        Me.btnMulSave.UseVisualStyleBackColor = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label25.Location = New System.Drawing.Point(816, 194)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(93, 13)
        Me.Label25.TabIndex = 29
        Me.Label25.Text = "0-16000 / 4-20mA"
        '
        'txtMV
        '
        Me.txtMV.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMV.Location = New System.Drawing.Point(824, 211)
        Me.txtMV.Name = "txtMV"
        Me.txtMV.Size = New System.Drawing.Size(54, 29)
        Me.txtMV.TabIndex = 483
        Me.txtMV.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(878, 213)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(25, 24)
        Me.Label26.TabIndex = 29
        Me.Label26.Text = "%"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.IRR.My.Resources.Resources.PID_Details
        Me.PictureBox1.Location = New System.Drawing.Point(130, 517)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1020, 115)
        Me.PictureBox1.TabIndex = 484
        Me.PictureBox1.TabStop = False
        '
        'frmPID
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1435, 644)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtMV)
        Me.Controls.Add(Me.chkLoad)
        Me.Controls.Add(Me.chkLoadMul)
        Me.Controls.Add(Me.rdbMC4A)
        Me.Controls.Add(Me.rdbMC2A)
        Me.Controls.Add(Me.rdbMC3A)
        Me.Controls.Add(Me.rdbMC1A)
        Me.Controls.Add(Me.Label145)
        Me.Controls.Add(Me.btnAutoMan)
        Me.Controls.Add(Me.btnMulSave)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtSV)
        Me.Controls.Add(Me.txtLoadMul)
        Me.Controls.Add(Me.txtLoad)
        Me.Controls.Add(Me.txtPress)
        Me.Controls.Add(Me.txtPV)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.txtDiffTime)
        Me.Controls.Add(Me.txtDiffGain)
        Me.Controls.Add(Me.txtInteg)
        Me.Controls.Add(Me.txtProp)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lblAutoMan)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lblPV)
        Me.Controls.Add(Me.lblMV)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.vpbMV)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.vpbPV)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label23)
        Me.Name = "frmPID"
        CType(Me.txtMV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnAutoMan As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents txtSV As TextBox
    Friend WithEvents txtPress As TextBox
    Friend WithEvents txtPV As TextBox
    Friend WithEvents txtFilter As TextBox
    Friend WithEvents txtDiffTime As TextBox
    Friend WithEvents txtDiffGain As TextBox
    Friend WithEvents txtInteg As TextBox
    Friend WithEvents txtProp As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblAutoMan As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents vpbMV As VerticalProgressBar
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents vpbPV As VerticalProgressBar
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents txtLoad As TextBox
    Friend WithEvents lblMV As Label
    Friend WithEvents lblPV As Label
    Friend WithEvents rdbMC4A As RadioButton
    Friend WithEvents rdbMC2A As RadioButton
    Friend WithEvents rdbMC3A As RadioButton
    Friend WithEvents rdbMC1A As RadioButton
    Friend WithEvents Label145 As Label
    Friend WithEvents Tmr As Timer
    Friend WithEvents Label19 As Label
    Friend WithEvents chkLoadMul As CheckBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents txtLoadMul As TextBox
    Friend WithEvents chkLoad As CheckBox
    Friend WithEvents btnMulSave As Button
    Friend WithEvents Label25 As Label
    Friend WithEvents txtMV As NumericUpDown
    Friend WithEvents Label26 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
