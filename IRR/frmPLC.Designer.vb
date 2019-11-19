<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPLC
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ledDriveStat = New IRR.Bulb.LedBulb()
        Me.ledPnu = New IRR.Bulb.LedBulb()
        Me.ledLubLevel = New IRR.Bulb.LedBulb()
        Me.ledLubPres = New IRR.Bulb.LedBulb()
        Me.ledLubPS = New IRR.Bulb.LedBulb()
        Me.ledMotTemp = New IRR.Bulb.LedBulb()
        Me.ledHtTherm = New IRR.Bulb.LedBulb()
        Me.ledMediaLvl = New IRR.Bulb.LedBulb()
        Me.ledMCBStat = New IRR.Bulb.LedBulb()
        Me.ledBoost = New IRR.Bulb.LedBulb()
        Me.rdbMC4A = New System.Windows.Forms.RadioButton()
        Me.rdbMC2A = New System.Windows.Forms.RadioButton()
        Me.rdbMC3A = New System.Windows.Forms.RadioButton()
        Me.rdbMC1A = New System.Windows.Forms.RadioButton()
        Me.Label145 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblVibA = New System.Windows.Forms.Label()
        Me.Label143 = New System.Windows.Forms.Label()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.lblB4B = New System.Windows.Forms.Label()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.lblB3B = New System.Windows.Forms.Label()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.lblB2B = New System.Windows.Forms.Label()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.lblB1B = New System.Windows.Forms.Label()
        Me.lblOT = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.lblLub = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.lblLdA = New System.Windows.Forms.Label()
        Me.Label140 = New System.Windows.Forms.Label()
        Me.lblSpd = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblVibB = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblB4A = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblB3A = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblB2A = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblB1A = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblLDB = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Stn1 = New IRR.Bulb.LedBulb()
        Me.Stn2 = New IRR.Bulb.LedBulb()
        Me.Stn3 = New IRR.Bulb.LedBulb()
        Me.Stn4 = New IRR.Bulb.LedBulb()
        Me.Stn5 = New IRR.Bulb.LedBulb()
        Me.Stn6 = New IRR.Bulb.LedBulb()
        Me.Stn7 = New IRR.Bulb.LedBulb()
        Me.Stn8 = New IRR.Bulb.LedBulb()
        Me.Stn9 = New IRR.Bulb.LedBulb()
        Me.Stn10 = New IRR.Bulb.LedBulb()
        Me.Stn11 = New IRR.Bulb.LedBulb()
        Me.Stn12 = New IRR.Bulb.LedBulb()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.btnChkStn1 = New System.Windows.Forms.Button()
        Me.btnChkStn2 = New System.Windows.Forms.Button()
        Me.btnChkStn3 = New System.Windows.Forms.Button()
        Me.btnChkStn4 = New System.Windows.Forms.Button()
        Me.btnChkStn5 = New System.Windows.Forms.Button()
        Me.btnChkStn6 = New System.Windows.Forms.Button()
        Me.btnChkStn7 = New System.Windows.Forms.Button()
        Me.btnChkStn8 = New System.Windows.Forms.Button()
        Me.btnChkStn9 = New System.Windows.Forms.Button()
        Me.btnChkStn10 = New System.Windows.Forms.Button()
        Me.btnChkStn11 = New System.Windows.Forms.Button()
        Me.btnChkStn12 = New System.Windows.Forms.Button()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.ledEmr = New IRR.Bulb.LedBulb()
        Me.Tmr = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(280, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(183, 32)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Pneumatic Pressure"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(280, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(183, 32)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "Lube Level"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(280, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(183, 32)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "Lube Pressure"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(280, 251)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(183, 32)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "Motor Temperature"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(264, 201)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(199, 32)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "Lube Pressure Switch"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(592, 251)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(197, 32)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "Booster End of Stroke"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(606, 201)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(183, 32)
        Me.Label9.TabIndex = 81
        Me.Label9.Text = "MCB Status"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(606, 150)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(183, 32)
        Me.Label10.TabIndex = 79
        Me.Label10.Text = "Media Level"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(606, 99)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(183, 32)
        Me.Label11.TabIndex = 77
        Me.Label11.Text = "Heater Thermistor"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(606, 47)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(183, 32)
        Me.Label12.TabIndex = 75
        Me.Label12.Text = "Drive Status"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ledDriveStat
        '
        Me.ledDriveStat.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ledDriveStat.DarkColor = System.Drawing.Color.Red
        Me.ledDriveStat.DarkDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ledDriveStat.LightLightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ledDriveStat.Location = New System.Drawing.Point(813, 40)
        Me.ledDriveStat.Name = "ledDriveStat"
        Me.ledDriveStat.On = True
        Me.ledDriveStat.Size = New System.Drawing.Size(45, 45)
        Me.ledDriveStat.TabIndex = 87
        Me.ledDriveStat.Text = "LedBulb2"
        '
        'ledPnu
        '
        Me.ledPnu.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ledPnu.DarkColor = System.Drawing.Color.Lime
        Me.ledPnu.DarkDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ledPnu.LightLightColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ledPnu.Location = New System.Drawing.Point(479, 40)
        Me.ledPnu.Name = "ledPnu"
        Me.ledPnu.On = True
        Me.ledPnu.Size = New System.Drawing.Size(45, 45)
        Me.ledPnu.TabIndex = 86
        Me.ledPnu.Text = "LedBulb1"
        '
        'ledLubLevel
        '
        Me.ledLubLevel.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ledLubLevel.DarkColor = System.Drawing.Color.Lime
        Me.ledLubLevel.DarkDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ledLubLevel.LightLightColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ledLubLevel.Location = New System.Drawing.Point(479, 92)
        Me.ledLubLevel.Name = "ledLubLevel"
        Me.ledLubLevel.On = True
        Me.ledLubLevel.Size = New System.Drawing.Size(45, 45)
        Me.ledLubLevel.TabIndex = 86
        Me.ledLubLevel.Text = "LedBulb1"
        '
        'ledLubPres
        '
        Me.ledLubPres.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ledLubPres.DarkColor = System.Drawing.Color.Lime
        Me.ledLubPres.DarkDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ledLubPres.LightLightColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ledLubPres.Location = New System.Drawing.Point(479, 143)
        Me.ledLubPres.Name = "ledLubPres"
        Me.ledLubPres.On = True
        Me.ledLubPres.Size = New System.Drawing.Size(45, 45)
        Me.ledLubPres.TabIndex = 86
        Me.ledLubPres.Text = "LedBulb1"
        '
        'ledLubPS
        '
        Me.ledLubPS.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ledLubPS.DarkColor = System.Drawing.Color.Lime
        Me.ledLubPS.DarkDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ledLubPS.LightLightColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ledLubPS.Location = New System.Drawing.Point(479, 194)
        Me.ledLubPS.Name = "ledLubPS"
        Me.ledLubPS.On = True
        Me.ledLubPS.Size = New System.Drawing.Size(45, 45)
        Me.ledLubPS.TabIndex = 86
        Me.ledLubPS.Text = "LedBulb1"
        '
        'ledMotTemp
        '
        Me.ledMotTemp.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ledMotTemp.DarkColor = System.Drawing.Color.Lime
        Me.ledMotTemp.DarkDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ledMotTemp.LightLightColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ledMotTemp.Location = New System.Drawing.Point(479, 244)
        Me.ledMotTemp.Name = "ledMotTemp"
        Me.ledMotTemp.On = True
        Me.ledMotTemp.Size = New System.Drawing.Size(45, 45)
        Me.ledMotTemp.TabIndex = 86
        Me.ledMotTemp.Text = "LedBulb1"
        '
        'ledHtTherm
        '
        Me.ledHtTherm.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ledHtTherm.DarkColor = System.Drawing.Color.Lime
        Me.ledHtTherm.DarkDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ledHtTherm.LightLightColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ledHtTherm.Location = New System.Drawing.Point(813, 92)
        Me.ledHtTherm.Name = "ledHtTherm"
        Me.ledHtTherm.On = True
        Me.ledHtTherm.Size = New System.Drawing.Size(45, 45)
        Me.ledHtTherm.TabIndex = 86
        Me.ledHtTherm.Text = "LedBulb1"
        '
        'ledMediaLvl
        '
        Me.ledMediaLvl.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ledMediaLvl.DarkColor = System.Drawing.Color.Lime
        Me.ledMediaLvl.DarkDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ledMediaLvl.LightLightColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ledMediaLvl.Location = New System.Drawing.Point(813, 143)
        Me.ledMediaLvl.Name = "ledMediaLvl"
        Me.ledMediaLvl.On = True
        Me.ledMediaLvl.Size = New System.Drawing.Size(45, 45)
        Me.ledMediaLvl.TabIndex = 86
        Me.ledMediaLvl.Text = "LedBulb1"
        '
        'ledMCBStat
        '
        Me.ledMCBStat.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ledMCBStat.DarkColor = System.Drawing.Color.Lime
        Me.ledMCBStat.DarkDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ledMCBStat.LightLightColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ledMCBStat.Location = New System.Drawing.Point(813, 194)
        Me.ledMCBStat.Name = "ledMCBStat"
        Me.ledMCBStat.On = True
        Me.ledMCBStat.Size = New System.Drawing.Size(45, 45)
        Me.ledMCBStat.TabIndex = 86
        Me.ledMCBStat.Text = "LedBulb1"
        '
        'ledBoost
        '
        Me.ledBoost.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ledBoost.DarkColor = System.Drawing.Color.Lime
        Me.ledBoost.DarkDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ledBoost.LightLightColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ledBoost.Location = New System.Drawing.Point(813, 244)
        Me.ledBoost.Name = "ledBoost"
        Me.ledBoost.On = True
        Me.ledBoost.Size = New System.Drawing.Size(45, 45)
        Me.ledBoost.TabIndex = 86
        Me.ledBoost.Text = "LedBulb1"
        '
        'rdbMC4A
        '
        Me.rdbMC4A.AutoSize = True
        Me.rdbMC4A.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbMC4A.Location = New System.Drawing.Point(932, 251)
        Me.rdbMC4A.Name = "rdbMC4A"
        Me.rdbMC4A.Size = New System.Drawing.Size(64, 24)
        Me.rdbMC4A.TabIndex = 6
        Me.rdbMC4A.TabStop = True
        Me.rdbMC4A.Text = "5.4A"
        Me.rdbMC4A.UseVisualStyleBackColor = True
        '
        'rdbMC2A
        '
        Me.rdbMC2A.AutoSize = True
        Me.rdbMC2A.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbMC2A.Location = New System.Drawing.Point(932, 115)
        Me.rdbMC2A.Name = "rdbMC2A"
        Me.rdbMC2A.Size = New System.Drawing.Size(64, 24)
        Me.rdbMC2A.TabIndex = 2
        Me.rdbMC2A.TabStop = True
        Me.rdbMC2A.Text = "5.2A"
        Me.rdbMC2A.UseVisualStyleBackColor = True
        '
        'rdbMC3A
        '
        Me.rdbMC3A.AutoSize = True
        Me.rdbMC3A.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbMC3A.Location = New System.Drawing.Point(932, 183)
        Me.rdbMC3A.Name = "rdbMC3A"
        Me.rdbMC3A.Size = New System.Drawing.Size(64, 24)
        Me.rdbMC3A.TabIndex = 4
        Me.rdbMC3A.TabStop = True
        Me.rdbMC3A.Text = "5.3A"
        Me.rdbMC3A.UseVisualStyleBackColor = True
        '
        'rdbMC1A
        '
        Me.rdbMC1A.AutoSize = True
        Me.rdbMC1A.Checked = True
        Me.rdbMC1A.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbMC1A.Location = New System.Drawing.Point(932, 47)
        Me.rdbMC1A.Name = "rdbMC1A"
        Me.rdbMC1A.Size = New System.Drawing.Size(64, 24)
        Me.rdbMC1A.TabIndex = 0
        Me.rdbMC1A.TabStop = True
        Me.rdbMC1A.Text = "5.1A"
        Me.rdbMC1A.UseVisualStyleBackColor = True
        '
        'Label145
        '
        Me.Label145.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label145.Location = New System.Drawing.Point(907, 33)
        Me.Label145.Name = "Label145"
        Me.Label145.Size = New System.Drawing.Size(117, 274)
        Me.Label145.TabIndex = 408
        Me.Label145.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Location = New System.Drawing.Point(569, 33)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(307, 274)
        Me.Label13.TabIndex = 409
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Location = New System.Drawing.Point(236, 33)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(307, 274)
        Me.Label14.TabIndex = 410
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVibA
        '
        Me.lblVibA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVibA.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVibA.Location = New System.Drawing.Point(421, 445)
        Me.lblVibA.Name = "lblVibA"
        Me.lblVibA.Size = New System.Drawing.Size(68, 30)
        Me.lblVibA.TabIndex = 427
        Me.lblVibA.Text = "0"
        Me.lblVibA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label143
        '
        Me.Label143.AutoSize = True
        Me.Label143.BackColor = System.Drawing.SystemColors.Control
        Me.Label143.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label143.Location = New System.Drawing.Point(355, 450)
        Me.Label143.Name = "Label143"
        Me.Label143.Size = New System.Drawing.Size(55, 24)
        Me.Label143.TabIndex = 426
        Me.Label143.Text = "VibA"
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label81.Location = New System.Drawing.Point(831, 408)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(34, 24)
        Me.Label81.TabIndex = 425
        Me.Label81.Text = "B4"
        '
        'lblB4B
        '
        Me.lblB4B.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblB4B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblB4B.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblB4B.Location = New System.Drawing.Point(884, 405)
        Me.lblB4B.Name = "lblB4B"
        Me.lblB4B.Size = New System.Drawing.Size(68, 30)
        Me.lblB4B.TabIndex = 424
        Me.lblB4B.Text = "0"
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label83.Location = New System.Drawing.Point(669, 408)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(34, 24)
        Me.Label83.TabIndex = 423
        Me.Label83.Text = "B3"
        '
        'lblB3B
        '
        Me.lblB3B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblB3B.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblB3B.Location = New System.Drawing.Point(727, 403)
        Me.lblB3B.Name = "lblB3B"
        Me.lblB3B.Size = New System.Drawing.Size(68, 30)
        Me.lblB3B.TabIndex = 422
        Me.lblB3B.Text = "0"
        '
        'Label85
        '
        Me.Label85.AutoSize = True
        Me.Label85.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label85.Location = New System.Drawing.Point(512, 408)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(34, 24)
        Me.Label85.TabIndex = 421
        Me.Label85.Text = "B2"
        '
        'lblB2B
        '
        Me.lblB2B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblB2B.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblB2B.Location = New System.Drawing.Point(570, 403)
        Me.lblB2B.Name = "lblB2B"
        Me.lblB2B.Size = New System.Drawing.Size(68, 30)
        Me.lblB2B.TabIndex = 420
        Me.lblB2B.Text = "0"
        '
        'Label87
        '
        Me.Label87.AutoSize = True
        Me.Label87.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label87.Location = New System.Drawing.Point(363, 408)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(34, 24)
        Me.Label87.TabIndex = 419
        Me.Label87.Text = "B1"
        '
        'lblB1B
        '
        Me.lblB1B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblB1B.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblB1B.Location = New System.Drawing.Point(421, 403)
        Me.lblB1B.Name = "lblB1B"
        Me.lblB1B.Size = New System.Drawing.Size(68, 30)
        Me.lblB1B.TabIndex = 418
        Me.lblB1B.Text = "0"
        Me.lblB1B.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOT
        '
        Me.lblOT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOT.Location = New System.Drawing.Point(727, 487)
        Me.lblOT.Name = "lblOT"
        Me.lblOT.Size = New System.Drawing.Size(68, 30)
        Me.lblOT.TabIndex = 417
        Me.lblOT.Text = "0"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(568, 490)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(148, 24)
        Me.Label49.TabIndex = 416
        Me.Label49.Text = "Tank Oil Temp"
        '
        'lblLub
        '
        Me.lblLub.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLub.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLub.Location = New System.Drawing.Point(421, 487)
        Me.lblLub.Name = "lblLub"
        Me.lblLub.Size = New System.Drawing.Size(68, 30)
        Me.lblLub.TabIndex = 415
        Me.lblLub.Text = "0"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(273, 490)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(137, 24)
        Me.Label53.TabIndex = 414
        Me.Label53.Text = "Lub Oil Temp"
        '
        'lblLdA
        '
        Me.lblLdA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLdA.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLdA.Location = New System.Drawing.Point(884, 449)
        Me.lblLdA.Name = "lblLdA"
        Me.lblLdA.Size = New System.Drawing.Size(68, 26)
        Me.lblLdA.TabIndex = 413
        Me.lblLdA.Text = "0"
        Me.lblLdA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label140
        '
        Me.Label140.AutoSize = True
        Me.Label140.BackColor = System.Drawing.SystemColors.Control
        Me.Label140.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label140.Location = New System.Drawing.Point(808, 450)
        Me.Label140.Name = "Label140"
        Me.Label140.Size = New System.Drawing.Size(70, 24)
        Me.Label140.TabIndex = 412
        Me.Label140.Text = "LoadA"
        '
        'lblSpd
        '
        Me.lblSpd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSpd.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSpd.Location = New System.Drawing.Point(726, 445)
        Me.lblSpd.Name = "lblSpd"
        Me.lblSpd.Size = New System.Drawing.Size(68, 30)
        Me.lblSpd.TabIndex = 411
        Me.lblSpd.Text = "0"
        Me.lblSpd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(645, 450)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 24)
        Me.Label5.TabIndex = 419
        Me.Label5.Text = "Speed"
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Location = New System.Drawing.Point(236, 328)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(788, 222)
        Me.Label7.TabIndex = 410
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.SystemColors.Control
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(505, 450)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 24)
        Me.Label15.TabIndex = 426
        Me.Label15.Text = "VibB"
        '
        'lblVibB
        '
        Me.lblVibB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVibB.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVibB.Location = New System.Drawing.Point(570, 445)
        Me.lblVibB.Name = "lblVibB"
        Me.lblVibB.Size = New System.Drawing.Size(68, 30)
        Me.lblVibB.TabIndex = 427
        Me.lblVibB.Text = "0"
        Me.lblVibB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(830, 364)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(35, 24)
        Me.Label17.TabIndex = 435
        Me.Label17.Text = "A4"
        '
        'lblB4A
        '
        Me.lblB4A.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblB4A.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblB4A.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblB4A.Location = New System.Drawing.Point(884, 361)
        Me.lblB4A.Name = "lblB4A"
        Me.lblB4A.Size = New System.Drawing.Size(68, 30)
        Me.lblB4A.TabIndex = 434
        Me.lblB4A.Text = "0"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(668, 364)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(35, 24)
        Me.Label19.TabIndex = 433
        Me.Label19.Text = "A3"
        '
        'lblB3A
        '
        Me.lblB3A.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblB3A.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblB3A.Location = New System.Drawing.Point(727, 361)
        Me.lblB3A.Name = "lblB3A"
        Me.lblB3A.Size = New System.Drawing.Size(68, 30)
        Me.lblB3A.TabIndex = 432
        Me.lblB3A.Text = "0"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(511, 364)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(35, 24)
        Me.Label21.TabIndex = 431
        Me.Label21.Text = "A2"
        '
        'lblB2A
        '
        Me.lblB2A.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblB2A.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblB2A.Location = New System.Drawing.Point(570, 361)
        Me.lblB2A.Name = "lblB2A"
        Me.lblB2A.Size = New System.Drawing.Size(68, 30)
        Me.lblB2A.TabIndex = 430
        Me.lblB2A.Text = "0"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(362, 364)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(35, 24)
        Me.Label23.TabIndex = 429
        Me.Label23.Text = "A1"
        '
        'lblB1A
        '
        Me.lblB1A.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblB1A.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblB1A.Location = New System.Drawing.Point(421, 361)
        Me.lblB1A.Name = "lblB1A"
        Me.lblB1A.Size = New System.Drawing.Size(68, 30)
        Me.lblB1A.TabIndex = 428
        Me.lblB1A.Text = "0"
        Me.lblB1A.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.SystemColors.Control
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(809, 490)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(69, 24)
        Me.Label18.TabIndex = 412
        Me.Label18.Text = "LoadB"
        '
        'lblLDB
        '
        Me.lblLDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLDB.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLDB.Location = New System.Drawing.Point(884, 489)
        Me.lblLDB.Name = "lblLDB"
        Me.lblLDB.Size = New System.Drawing.Size(68, 26)
        Me.lblLDB.TabIndex = 413
        Me.lblLDB.Text = "0"
        Me.lblLDB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(251, 310)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(128, 32)
        Me.Label16.TabIndex = 73
        Me.Label16.Text = "Actual Values"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Stn1
        '
        Me.Stn1.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Stn1.DarkColor = System.Drawing.Color.Lime
        Me.Stn1.DarkDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Stn1.LightLightColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Stn1.Location = New System.Drawing.Point(236, 568)
        Me.Stn1.Name = "Stn1"
        Me.Stn1.On = False
        Me.Stn1.Size = New System.Drawing.Size(25, 26)
        Me.Stn1.TabIndex = 86
        Me.Stn1.Text = "LedBulb1"
        '
        'Stn2
        '
        Me.Stn2.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Stn2.DarkColor = System.Drawing.Color.Lime
        Me.Stn2.DarkDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Stn2.LightLightColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Stn2.Location = New System.Drawing.Point(305, 568)
        Me.Stn2.Name = "Stn2"
        Me.Stn2.On = False
        Me.Stn2.Size = New System.Drawing.Size(25, 26)
        Me.Stn2.TabIndex = 86
        Me.Stn2.Text = "LedBulb1"
        '
        'Stn3
        '
        Me.Stn3.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Stn3.DarkColor = System.Drawing.Color.Lime
        Me.Stn3.DarkDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Stn3.LightLightColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Stn3.Location = New System.Drawing.Point(374, 568)
        Me.Stn3.Name = "Stn3"
        Me.Stn3.On = False
        Me.Stn3.Size = New System.Drawing.Size(25, 26)
        Me.Stn3.TabIndex = 86
        Me.Stn3.Text = "LedBulb1"
        '
        'Stn4
        '
        Me.Stn4.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Stn4.DarkColor = System.Drawing.Color.Lime
        Me.Stn4.DarkDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Stn4.LightLightColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Stn4.Location = New System.Drawing.Point(443, 568)
        Me.Stn4.Name = "Stn4"
        Me.Stn4.On = False
        Me.Stn4.Size = New System.Drawing.Size(25, 26)
        Me.Stn4.TabIndex = 86
        Me.Stn4.Text = "LedBulb1"
        '
        'Stn5
        '
        Me.Stn5.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Stn5.DarkColor = System.Drawing.Color.Lime
        Me.Stn5.DarkDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Stn5.LightLightColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Stn5.Location = New System.Drawing.Point(512, 568)
        Me.Stn5.Name = "Stn5"
        Me.Stn5.On = False
        Me.Stn5.Size = New System.Drawing.Size(25, 26)
        Me.Stn5.TabIndex = 86
        Me.Stn5.Text = "LedBulb1"
        '
        'Stn6
        '
        Me.Stn6.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Stn6.DarkColor = System.Drawing.Color.Lime
        Me.Stn6.DarkDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Stn6.LightLightColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Stn6.Location = New System.Drawing.Point(581, 568)
        Me.Stn6.Name = "Stn6"
        Me.Stn6.On = False
        Me.Stn6.Size = New System.Drawing.Size(25, 26)
        Me.Stn6.TabIndex = 86
        Me.Stn6.Text = "LedBulb1"
        '
        'Stn7
        '
        Me.Stn7.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Stn7.DarkColor = System.Drawing.Color.Lime
        Me.Stn7.DarkDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Stn7.LightLightColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Stn7.Location = New System.Drawing.Point(650, 568)
        Me.Stn7.Name = "Stn7"
        Me.Stn7.On = False
        Me.Stn7.Size = New System.Drawing.Size(25, 26)
        Me.Stn7.TabIndex = 86
        Me.Stn7.Text = "LedBulb1"
        '
        'Stn8
        '
        Me.Stn8.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Stn8.DarkColor = System.Drawing.Color.Lime
        Me.Stn8.DarkDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Stn8.LightLightColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Stn8.Location = New System.Drawing.Point(719, 568)
        Me.Stn8.Name = "Stn8"
        Me.Stn8.On = False
        Me.Stn8.Size = New System.Drawing.Size(25, 26)
        Me.Stn8.TabIndex = 86
        Me.Stn8.Text = "LedBulb1"
        '
        'Stn9
        '
        Me.Stn9.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Stn9.DarkColor = System.Drawing.Color.Lime
        Me.Stn9.DarkDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Stn9.LightLightColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Stn9.Location = New System.Drawing.Point(788, 568)
        Me.Stn9.Name = "Stn9"
        Me.Stn9.On = False
        Me.Stn9.Size = New System.Drawing.Size(25, 26)
        Me.Stn9.TabIndex = 86
        Me.Stn9.Text = "LedBulb1"
        '
        'Stn10
        '
        Me.Stn10.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Stn10.DarkColor = System.Drawing.Color.Lime
        Me.Stn10.DarkDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Stn10.LightLightColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Stn10.Location = New System.Drawing.Point(857, 568)
        Me.Stn10.Name = "Stn10"
        Me.Stn10.On = False
        Me.Stn10.Size = New System.Drawing.Size(25, 26)
        Me.Stn10.TabIndex = 86
        Me.Stn10.Text = "LedBulb1"
        '
        'Stn11
        '
        Me.Stn11.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Stn11.DarkColor = System.Drawing.Color.Lime
        Me.Stn11.DarkDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Stn11.LightLightColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Stn11.Location = New System.Drawing.Point(926, 568)
        Me.Stn11.Name = "Stn11"
        Me.Stn11.On = False
        Me.Stn11.Size = New System.Drawing.Size(25, 26)
        Me.Stn11.TabIndex = 86
        Me.Stn11.Text = "LedBulb1"
        '
        'Stn12
        '
        Me.Stn12.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Stn12.DarkColor = System.Drawing.Color.Lime
        Me.Stn12.DarkDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Stn12.LightLightColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Stn12.Location = New System.Drawing.Point(995, 568)
        Me.Stn12.Name = "Stn12"
        Me.Stn12.On = False
        Me.Stn12.Size = New System.Drawing.Size(25, 26)
        Me.Stn12.TabIndex = 86
        Me.Stn12.Text = "LedBulb1"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(224, 556)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(49, 13)
        Me.Label20.TabIndex = 436
        Me.Label20.Text = "Station-1"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(293, 556)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(49, 13)
        Me.Label22.TabIndex = 436
        Me.Label22.Text = "Station-2"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(362, 556)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(49, 13)
        Me.Label24.TabIndex = 436
        Me.Label24.Text = "Station-3"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(431, 556)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(49, 13)
        Me.Label25.TabIndex = 436
        Me.Label25.Text = "Station-4"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(500, 556)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(49, 13)
        Me.Label26.TabIndex = 436
        Me.Label26.Text = "Station-5"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(569, 556)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(49, 13)
        Me.Label27.TabIndex = 436
        Me.Label27.Text = "Station-6"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(638, 556)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(49, 13)
        Me.Label28.TabIndex = 436
        Me.Label28.Text = "Station-7"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(707, 556)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(49, 13)
        Me.Label29.TabIndex = 436
        Me.Label29.Text = "Station-8"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(776, 556)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(49, 13)
        Me.Label30.TabIndex = 436
        Me.Label30.Text = "Station-9"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(842, 556)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(55, 13)
        Me.Label31.TabIndex = 436
        Me.Label31.Text = "Station-10"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(911, 556)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(55, 13)
        Me.Label32.TabIndex = 436
        Me.Label32.Text = "Station-11"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(980, 556)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(55, 13)
        Me.Label33.TabIndex = 436
        Me.Label33.Text = "Station-12"
        '
        'btnChkStn1
        '
        Me.btnChkStn1.Enabled = False
        Me.btnChkStn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnChkStn1.Location = New System.Drawing.Point(222, 600)
        Me.btnChkStn1.Name = "btnChkStn1"
        Me.btnChkStn1.Size = New System.Drawing.Size(52, 22)
        Me.btnChkStn1.TabIndex = 437
        Me.btnChkStn1.Tag = "1"
        Me.btnChkStn1.Text = "Retry"
        Me.btnChkStn1.UseVisualStyleBackColor = True
        '
        'btnChkStn2
        '
        Me.btnChkStn2.Enabled = False
        Me.btnChkStn2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnChkStn2.Location = New System.Drawing.Point(291, 600)
        Me.btnChkStn2.Name = "btnChkStn2"
        Me.btnChkStn2.Size = New System.Drawing.Size(52, 22)
        Me.btnChkStn2.TabIndex = 437
        Me.btnChkStn2.Tag = "2"
        Me.btnChkStn2.Text = "Retry"
        Me.btnChkStn2.UseVisualStyleBackColor = True
        '
        'btnChkStn3
        '
        Me.btnChkStn3.Enabled = False
        Me.btnChkStn3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnChkStn3.Location = New System.Drawing.Point(360, 600)
        Me.btnChkStn3.Name = "btnChkStn3"
        Me.btnChkStn3.Size = New System.Drawing.Size(52, 22)
        Me.btnChkStn3.TabIndex = 437
        Me.btnChkStn3.Tag = "3"
        Me.btnChkStn3.Text = "Retry"
        Me.btnChkStn3.UseVisualStyleBackColor = True
        '
        'btnChkStn4
        '
        Me.btnChkStn4.Enabled = False
        Me.btnChkStn4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnChkStn4.Location = New System.Drawing.Point(429, 600)
        Me.btnChkStn4.Name = "btnChkStn4"
        Me.btnChkStn4.Size = New System.Drawing.Size(52, 22)
        Me.btnChkStn4.TabIndex = 437
        Me.btnChkStn4.Tag = "4"
        Me.btnChkStn4.Text = "Retry"
        Me.btnChkStn4.UseVisualStyleBackColor = True
        '
        'btnChkStn5
        '
        Me.btnChkStn5.Enabled = False
        Me.btnChkStn5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnChkStn5.Location = New System.Drawing.Point(498, 600)
        Me.btnChkStn5.Name = "btnChkStn5"
        Me.btnChkStn5.Size = New System.Drawing.Size(52, 22)
        Me.btnChkStn5.TabIndex = 437
        Me.btnChkStn5.Tag = "5"
        Me.btnChkStn5.Text = "Retry"
        Me.btnChkStn5.UseVisualStyleBackColor = True
        '
        'btnChkStn6
        '
        Me.btnChkStn6.Enabled = False
        Me.btnChkStn6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnChkStn6.Location = New System.Drawing.Point(567, 600)
        Me.btnChkStn6.Name = "btnChkStn6"
        Me.btnChkStn6.Size = New System.Drawing.Size(52, 22)
        Me.btnChkStn6.TabIndex = 437
        Me.btnChkStn6.Tag = "6"
        Me.btnChkStn6.Text = "Retry"
        Me.btnChkStn6.UseVisualStyleBackColor = True
        '
        'btnChkStn7
        '
        Me.btnChkStn7.Enabled = False
        Me.btnChkStn7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnChkStn7.Location = New System.Drawing.Point(636, 600)
        Me.btnChkStn7.Name = "btnChkStn7"
        Me.btnChkStn7.Size = New System.Drawing.Size(52, 22)
        Me.btnChkStn7.TabIndex = 437
        Me.btnChkStn7.Tag = "7"
        Me.btnChkStn7.Text = "Retry"
        Me.btnChkStn7.UseVisualStyleBackColor = True
        '
        'btnChkStn8
        '
        Me.btnChkStn8.Enabled = False
        Me.btnChkStn8.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnChkStn8.Location = New System.Drawing.Point(705, 600)
        Me.btnChkStn8.Name = "btnChkStn8"
        Me.btnChkStn8.Size = New System.Drawing.Size(52, 22)
        Me.btnChkStn8.TabIndex = 437
        Me.btnChkStn8.Tag = "8"
        Me.btnChkStn8.Text = "Retry"
        Me.btnChkStn8.UseVisualStyleBackColor = True
        '
        'btnChkStn9
        '
        Me.btnChkStn9.Enabled = False
        Me.btnChkStn9.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnChkStn9.Location = New System.Drawing.Point(774, 600)
        Me.btnChkStn9.Name = "btnChkStn9"
        Me.btnChkStn9.Size = New System.Drawing.Size(52, 22)
        Me.btnChkStn9.TabIndex = 437
        Me.btnChkStn9.Tag = "9"
        Me.btnChkStn9.Text = "Retry"
        Me.btnChkStn9.UseVisualStyleBackColor = True
        '
        'btnChkStn10
        '
        Me.btnChkStn10.Enabled = False
        Me.btnChkStn10.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnChkStn10.Location = New System.Drawing.Point(843, 600)
        Me.btnChkStn10.Name = "btnChkStn10"
        Me.btnChkStn10.Size = New System.Drawing.Size(52, 22)
        Me.btnChkStn10.TabIndex = 437
        Me.btnChkStn10.Tag = "10"
        Me.btnChkStn10.Text = "Retry"
        Me.btnChkStn10.UseVisualStyleBackColor = True
        '
        'btnChkStn11
        '
        Me.btnChkStn11.Enabled = False
        Me.btnChkStn11.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnChkStn11.Location = New System.Drawing.Point(912, 600)
        Me.btnChkStn11.Name = "btnChkStn11"
        Me.btnChkStn11.Size = New System.Drawing.Size(52, 22)
        Me.btnChkStn11.TabIndex = 437
        Me.btnChkStn11.Tag = "11"
        Me.btnChkStn11.Text = "Retry"
        Me.btnChkStn11.UseVisualStyleBackColor = True
        '
        'btnChkStn12
        '
        Me.btnChkStn12.Enabled = False
        Me.btnChkStn12.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnChkStn12.Location = New System.Drawing.Point(981, 600)
        Me.btnChkStn12.Name = "btnChkStn12"
        Me.btnChkStn12.Size = New System.Drawing.Size(52, 22)
        Me.btnChkStn12.TabIndex = 437
        Me.btnChkStn12.Tag = "12"
        Me.btnChkStn12.Text = "Retry"
        Me.btnChkStn12.UseVisualStyleBackColor = True
        '
        'Label34
        '
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(95, 81)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(118, 32)
        Me.Label34.TabIndex = 73
        Me.Label34.Text = "Emergency"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ledEmr
        '
        Me.ledEmr.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ledEmr.DarkColor = System.Drawing.Color.Lime
        Me.ledEmr.DarkDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ledEmr.LightLightColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ledEmr.Location = New System.Drawing.Point(140, 40)
        Me.ledEmr.Name = "ledEmr"
        Me.ledEmr.On = True
        Me.ledEmr.Size = New System.Drawing.Size(45, 45)
        Me.ledEmr.TabIndex = 86
        Me.ledEmr.Text = "LedBulb1"
        '
        'Tmr
        '
        Me.Tmr.Enabled = True
        Me.Tmr.Interval = 5000
        '
        'frmPLC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1435, 644)
        Me.Controls.Add(Me.btnChkStn12)
        Me.Controls.Add(Me.btnChkStn11)
        Me.Controls.Add(Me.btnChkStn10)
        Me.Controls.Add(Me.btnChkStn9)
        Me.Controls.Add(Me.btnChkStn8)
        Me.Controls.Add(Me.btnChkStn7)
        Me.Controls.Add(Me.btnChkStn6)
        Me.Controls.Add(Me.btnChkStn5)
        Me.Controls.Add(Me.btnChkStn4)
        Me.Controls.Add(Me.btnChkStn3)
        Me.Controls.Add(Me.btnChkStn2)
        Me.Controls.Add(Me.btnChkStn1)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.lblB4A)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.lblB3A)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.lblB2A)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.lblB1A)
        Me.Controls.Add(Me.lblVibB)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblVibA)
        Me.Controls.Add(Me.Label143)
        Me.Controls.Add(Me.Label81)
        Me.Controls.Add(Me.lblB4B)
        Me.Controls.Add(Me.Label83)
        Me.Controls.Add(Me.lblB3B)
        Me.Controls.Add(Me.Label85)
        Me.Controls.Add(Me.lblB2B)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label87)
        Me.Controls.Add(Me.lblB1B)
        Me.Controls.Add(Me.lblOT)
        Me.Controls.Add(Me.Label49)
        Me.Controls.Add(Me.lblLub)
        Me.Controls.Add(Me.Label53)
        Me.Controls.Add(Me.lblLDB)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.lblLdA)
        Me.Controls.Add(Me.Label140)
        Me.Controls.Add(Me.lblSpd)
        Me.Controls.Add(Me.rdbMC4A)
        Me.Controls.Add(Me.rdbMC2A)
        Me.Controls.Add(Me.rdbMC3A)
        Me.Controls.Add(Me.rdbMC1A)
        Me.Controls.Add(Me.Label145)
        Me.Controls.Add(Me.ledDriveStat)
        Me.Controls.Add(Me.ledBoost)
        Me.Controls.Add(Me.Stn12)
        Me.Controls.Add(Me.Stn11)
        Me.Controls.Add(Me.Stn10)
        Me.Controls.Add(Me.Stn9)
        Me.Controls.Add(Me.Stn5)
        Me.Controls.Add(Me.Stn8)
        Me.Controls.Add(Me.Stn4)
        Me.Controls.Add(Me.Stn7)
        Me.Controls.Add(Me.Stn3)
        Me.Controls.Add(Me.Stn6)
        Me.Controls.Add(Me.Stn2)
        Me.Controls.Add(Me.Stn1)
        Me.Controls.Add(Me.ledEmr)
        Me.Controls.Add(Me.ledMotTemp)
        Me.Controls.Add(Me.ledMCBStat)
        Me.Controls.Add(Me.ledMediaLvl)
        Me.Controls.Add(Me.ledLubPS)
        Me.Controls.Add(Me.ledHtTherm)
        Me.Controls.Add(Me.ledLubPres)
        Me.Controls.Add(Me.ledLubLevel)
        Me.Controls.Add(Me.ledPnu)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label7)
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Name = "frmPLC"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents ledDriveStat As Bulb.LedBulb
    Friend WithEvents ledPnu As Bulb.LedBulb
    Friend WithEvents ledLubLevel As Bulb.LedBulb
    Friend WithEvents ledLubPres As Bulb.LedBulb
    Friend WithEvents ledLubPS As Bulb.LedBulb
    Friend WithEvents ledMotTemp As Bulb.LedBulb
    Friend WithEvents ledHtTherm As Bulb.LedBulb
    Friend WithEvents ledMediaLvl As Bulb.LedBulb
    Friend WithEvents ledMCBStat As Bulb.LedBulb
    Friend WithEvents ledBoost As Bulb.LedBulb
    Friend WithEvents rdbMC4A As RadioButton
    Friend WithEvents rdbMC2A As RadioButton
    Friend WithEvents rdbMC3A As RadioButton
    Friend WithEvents rdbMC1A As RadioButton
    Friend WithEvents Label145 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents lblVibA As Label
    Friend WithEvents Label143 As Label
    Friend WithEvents Label81 As Label
    Friend WithEvents lblB4B As Label
    Friend WithEvents Label83 As Label
    Friend WithEvents lblB3B As Label
    Friend WithEvents Label85 As Label
    Friend WithEvents lblB2B As Label
    Friend WithEvents Label87 As Label
    Friend WithEvents lblB1B As Label
    Friend WithEvents lblOT As Label
    Friend WithEvents Label49 As Label
    Friend WithEvents lblLub As Label
    Friend WithEvents Label53 As Label
    Friend WithEvents lblLdA As Label
    Friend WithEvents Label140 As Label
    Friend WithEvents lblSpd As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents lblVibB As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents lblB4A As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents lblB3A As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents lblB2A As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents lblB1A As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents lblLDB As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Stn1 As Bulb.LedBulb
    Friend WithEvents Stn2 As Bulb.LedBulb
    Friend WithEvents Stn3 As Bulb.LedBulb
    Friend WithEvents Stn4 As Bulb.LedBulb
    Friend WithEvents Stn5 As Bulb.LedBulb
    Friend WithEvents Stn6 As Bulb.LedBulb
    Friend WithEvents Stn7 As Bulb.LedBulb
    Friend WithEvents Stn8 As Bulb.LedBulb
    Friend WithEvents Stn9 As Bulb.LedBulb
    Friend WithEvents Stn10 As Bulb.LedBulb
    Friend WithEvents Stn11 As Bulb.LedBulb
    Friend WithEvents Stn12 As Bulb.LedBulb
    Friend WithEvents Label20 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents btnChkStn1 As Button
    Friend WithEvents btnChkStn2 As Button
    Friend WithEvents btnChkStn3 As Button
    Friend WithEvents btnChkStn4 As Button
    Friend WithEvents btnChkStn5 As Button
    Friend WithEvents btnChkStn6 As Button
    Friend WithEvents btnChkStn7 As Button
    Friend WithEvents btnChkStn8 As Button
    Friend WithEvents btnChkStn9 As Button
    Friend WithEvents btnChkStn10 As Button
    Friend WithEvents btnChkStn11 As Button
    Friend WithEvents btnChkStn12 As Button
    Friend WithEvents Label34 As Label
    Friend WithEvents ledEmr As Bulb.LedBulb
    Friend WithEvents Tmr As Timer
End Class
