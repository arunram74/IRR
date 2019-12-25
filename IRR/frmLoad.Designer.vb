<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLoad
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.dgvLoad = New System.Windows.Forms.DataGridView()
        Me.graphLoad = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.btnReturn = New IRR.GaryPerkin.UserControls.Buttons.RoundButton()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.bndSrcLoad = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtCurStp = New System.Windows.Forms.TextBox()
        Me.btnDeleteRow = New System.Windows.Forms.Button()
        Me.btnClearRow = New System.Windows.Forms.Button()
        Me.btnUpdateRow = New System.Windows.Forms.Button()
        Me.btnAddNewRow = New System.Windows.Forms.Button()
        Me.nupRunMin = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nupEndLoad = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.nupRunSec = New System.Windows.Forms.NumericUpDown()
        Me.nupSec = New System.Windows.Forms.NumericUpDown()
        Me.nupMin = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.nupRunHr = New System.Windows.Forms.NumericUpDown()
        Me.nupHr = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.lblMcHead = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnopnTmpLoc = New System.Windows.Forms.Button()
        Me.btnCopyFromTemplate = New System.Windows.Forms.Button()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.cmbTemplates = New System.Windows.Forms.ComboBox()
        Me.lblB4 = New System.Windows.Forms.Label()
        Me.lblB3 = New System.Windows.Forms.Label()
        Me.lblB2 = New System.Windows.Forms.Label()
        Me.lblB1 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.lblLub = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.lblPartNo = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.lblMake = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.lblTestID = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        CType(Me.dgvLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.graphLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bndSrcLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.nupRunMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupEndLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupRunSec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupSec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupRunHr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupHr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvLoad
        '
        Me.dgvLoad.AllowUserToAddRows = False
        Me.dgvLoad.AllowUserToDeleteRows = False
        Me.dgvLoad.AllowUserToResizeColumns = False
        Me.dgvLoad.AllowUserToResizeRows = False
        Me.dgvLoad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLoad.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvLoad.Location = New System.Drawing.Point(36, 207)
        Me.dgvLoad.MultiSelect = False
        Me.dgvLoad.Name = "dgvLoad"
        Me.dgvLoad.Size = New System.Drawing.Size(642, 224)
        Me.dgvLoad.TabIndex = 112
        '
        'graphLoad
        '
        ChartArea1.Name = "ChartArea1"
        Me.graphLoad.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.graphLoad.Legends.Add(Legend1)
        Me.graphLoad.Location = New System.Drawing.Point(694, 208)
        Me.graphLoad.Name = "graphLoad"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.graphLoad.Series.Add(Series1)
        Me.graphLoad.Size = New System.Drawing.Size(454, 424)
        Me.graphLoad.TabIndex = 132
        Me.graphLoad.Text = "Chart1"
        '
        'Label35
        '
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(44, 11)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(173, 26)
        Me.Label35.TabIndex = 331
        Me.Label35.Text = "Project Information"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox8
        '
        Me.PictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox8.Location = New System.Drawing.Point(36, 22)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(955, 107)
        Me.PictureBox8.TabIndex = 332
        Me.PictureBox8.TabStop = False
        '
        'PictureBox9
        '
        Me.PictureBox9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox9.Location = New System.Drawing.Point(36, 135)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(955, 67)
        Me.PictureBox9.TabIndex = 354
        Me.PictureBox9.TabStop = False
        '
        'btnReturn
        '
        Me.btnReturn.BackgroundImage = Global.IRR.My.Resources.Resources.Head
        Me.btnReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnReturn.BevelHeight = 2
        Me.btnReturn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnReturn.Font = New System.Drawing.Font("Segoe UI Symbol", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReturn.Image = Global.IRR.My.Resources.Resources.Head
        Me.btnReturn.Location = New System.Drawing.Point(1018, 25)
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.RecessDepth = 3
        Me.btnReturn.Size = New System.Drawing.Size(125, 125)
        Me.btnReturn.TabIndex = 14
        Me.btnReturn.Text = "↺"
        Me.btnReturn.UseVisualStyleBackColor = True
        '
        'PictureBox7
        '
        Me.PictureBox7.Location = New System.Drawing.Point(1013, 22)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(135, 180)
        Me.PictureBox7.TabIndex = 357
        Me.PictureBox7.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtCurStp)
        Me.Panel1.Controls.Add(Me.btnDeleteRow)
        Me.Panel1.Controls.Add(Me.btnClearRow)
        Me.Panel1.Controls.Add(Me.btnUpdateRow)
        Me.Panel1.Controls.Add(Me.btnAddNewRow)
        Me.Panel1.Controls.Add(Me.nupRunMin)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.nupEndLoad)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.nupRunSec)
        Me.Panel1.Controls.Add(Me.nupSec)
        Me.Panel1.Controls.Add(Me.nupMin)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.nupRunHr)
        Me.Panel1.Controls.Add(Me.nupHr)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.PictureBox4)
        Me.Panel1.Location = New System.Drawing.Point(12, 440)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(676, 214)
        Me.Panel1.TabIndex = 358
        '
        'txtCurStp
        '
        Me.txtCurStp.Enabled = False
        Me.txtCurStp.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurStp.Location = New System.Drawing.Point(203, 7)
        Me.txtCurStp.Name = "txtCurStp"
        Me.txtCurStp.Size = New System.Drawing.Size(51, 29)
        Me.txtCurStp.TabIndex = 152
        '
        'btnDeleteRow
        '
        Me.btnDeleteRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteRow.Location = New System.Drawing.Point(527, 149)
        Me.btnDeleteRow.Name = "btnDeleteRow"
        Me.btnDeleteRow.Size = New System.Drawing.Size(120, 34)
        Me.btnDeleteRow.TabIndex = 13
        Me.btnDeleteRow.Text = "Delete..."
        Me.btnDeleteRow.UseVisualStyleBackColor = True
        '
        'btnClearRow
        '
        Me.btnClearRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearRow.Location = New System.Drawing.Point(368, 149)
        Me.btnClearRow.Name = "btnClearRow"
        Me.btnClearRow.Size = New System.Drawing.Size(120, 34)
        Me.btnClearRow.TabIndex = 12
        Me.btnClearRow.Text = "Clear"
        Me.btnClearRow.UseVisualStyleBackColor = True
        '
        'btnUpdateRow
        '
        Me.btnUpdateRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateRow.Location = New System.Drawing.Point(209, 149)
        Me.btnUpdateRow.Name = "btnUpdateRow"
        Me.btnUpdateRow.Size = New System.Drawing.Size(120, 34)
        Me.btnUpdateRow.TabIndex = 11
        Me.btnUpdateRow.Text = "Update"
        Me.btnUpdateRow.UseVisualStyleBackColor = True
        '
        'btnAddNewRow
        '
        Me.btnAddNewRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddNewRow.Location = New System.Drawing.Point(50, 149)
        Me.btnAddNewRow.Name = "btnAddNewRow"
        Me.btnAddNewRow.Size = New System.Drawing.Size(120, 34)
        Me.btnAddNewRow.TabIndex = 10
        Me.btnAddNewRow.Text = "Add New Row"
        Me.btnAddNewRow.UseVisualStyleBackColor = True
        '
        'nupRunMin
        '
        Me.nupRunMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nupRunMin.Location = New System.Drawing.Point(485, 97)
        Me.nupRunMin.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.nupRunMin.Name = "nupRunMin"
        Me.nupRunMin.Size = New System.Drawing.Size(47, 29)
        Me.nupRunMin.TabIndex = 8
        Me.nupRunMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(315, 193)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(341, 11)
        Me.Label7.TabIndex = 146
        Me.Label7.Text = "* Run Duration - Last step until Machine stops"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(229, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 26)
        Me.Label2.TabIndex = 146
        Me.Label2.Text = "* Run Duration"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nupEndLoad
        '
        Me.nupEndLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nupEndLoad.Location = New System.Drawing.Point(134, 46)
        Me.nupEndLoad.Maximum = New Decimal(New Integer() {38000, 0, 0, 0})
        Me.nupEndLoad.Name = "nupEndLoad"
        Me.nupEndLoad.Size = New System.Drawing.Size(85, 29)
        Me.nupEndLoad.TabIndex = 3
        Me.nupEndLoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(31, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(177, 29)
        Me.Label3.TabIndex = 142
        Me.Label3.Text = "Step Details. Sl No -"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(29, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 29)
        Me.Label5.TabIndex = 141
        Me.Label5.Text = "End Load"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(225, 49)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(143, 26)
        Me.Label22.TabIndex = 140
        Me.Label22.Text = "Load Duration"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nupRunSec
        '
        Me.nupRunSec.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nupRunSec.Location = New System.Drawing.Point(567, 96)
        Me.nupRunSec.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.nupRunSec.Name = "nupRunSec"
        Me.nupRunSec.Size = New System.Drawing.Size(47, 29)
        Me.nupRunSec.TabIndex = 9
        Me.nupRunSec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nupSec
        '
        Me.nupSec.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nupSec.Location = New System.Drawing.Point(567, 46)
        Me.nupSec.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.nupSec.Name = "nupSec"
        Me.nupSec.Size = New System.Drawing.Size(47, 29)
        Me.nupSec.TabIndex = 6
        Me.nupSec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nupMin
        '
        Me.nupMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nupMin.Location = New System.Drawing.Point(485, 46)
        Me.nupMin.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.nupMin.Name = "nupMin"
        Me.nupMin.Size = New System.Drawing.Size(47, 29)
        Me.nupMin.TabIndex = 5
        Me.nupMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(546, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 26)
        Me.Label6.TabIndex = 137
        Me.Label6.Text = "S"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(546, 47)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(26, 26)
        Me.Label17.TabIndex = 137
        Me.Label17.Text = "S"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(461, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 26)
        Me.Label4.TabIndex = 136
        Me.Label4.Text = "M"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(461, 47)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(26, 26)
        Me.Label16.TabIndex = 136
        Me.Label16.Text = "M"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nupRunHr
        '
        Me.nupRunHr.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nupRunHr.Location = New System.Drawing.Point(403, 96)
        Me.nupRunHr.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nupRunHr.Name = "nupRunHr"
        Me.nupRunHr.Size = New System.Drawing.Size(47, 29)
        Me.nupRunHr.TabIndex = 7
        Me.nupRunHr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nupHr
        '
        Me.nupHr.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nupHr.Location = New System.Drawing.Point(403, 46)
        Me.nupHr.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nupHr.Name = "nupHr"
        Me.nupHr.Size = New System.Drawing.Size(47, 29)
        Me.nupHr.TabIndex = 4
        Me.nupHr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(381, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 26)
        Me.Label1.TabIndex = 135
        Me.Label1.Text = "H"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(381, 47)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(26, 26)
        Me.Label15.TabIndex = 135
        Me.Label15.Text = "H"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(374, 90)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(254, 42)
        Me.PictureBox1.TabIndex = 138
        Me.PictureBox1.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Location = New System.Drawing.Point(374, 40)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(254, 42)
        Me.PictureBox3.TabIndex = 138
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox4.Location = New System.Drawing.Point(24, 19)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(642, 173)
        Me.PictureBox4.TabIndex = 139
        Me.PictureBox4.TabStop = False
        '
        'lblMcHead
        '
        Me.lblMcHead.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMcHead.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblMcHead.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMcHead.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblMcHead.Location = New System.Drawing.Point(1174, 0)
        Me.lblMcHead.Name = "lblMcHead"
        Me.lblMcHead.Size = New System.Drawing.Size(87, 644)
        Me.lblMcHead.TabIndex = 359
        Me.lblMcHead.Text = "lblMcHead"
        Me.lblMcHead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnopnTmpLoc)
        Me.Panel2.Controls.Add(Me.btnCopyFromTemplate)
        Me.Panel2.Controls.Add(Me.Label57)
        Me.Panel2.Controls.Add(Me.cmbTemplates)
        Me.Panel2.Location = New System.Drawing.Point(64, 146)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(859, 51)
        Me.Panel2.TabIndex = 360
        '
        'btnopnTmpLoc
        '
        Me.btnopnTmpLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnopnTmpLoc.Location = New System.Drawing.Point(654, 9)
        Me.btnopnTmpLoc.Name = "btnopnTmpLoc"
        Me.btnopnTmpLoc.Size = New System.Drawing.Size(141, 34)
        Me.btnopnTmpLoc.TabIndex = 2
        Me.btnopnTmpLoc.Text = "Open Location..."
        Me.btnopnTmpLoc.UseVisualStyleBackColor = True
        '
        'btnCopyFromTemplate
        '
        Me.btnCopyFromTemplate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopyFromTemplate.Location = New System.Drawing.Point(511, 9)
        Me.btnCopyFromTemplate.Name = "btnCopyFromTemplate"
        Me.btnCopyFromTemplate.Size = New System.Drawing.Size(120, 34)
        Me.btnCopyFromTemplate.TabIndex = 1
        Me.btnCopyFromTemplate.Text = "Copy From..."
        Me.btnCopyFromTemplate.UseVisualStyleBackColor = True
        '
        'Label57
        '
        Me.Label57.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.Location = New System.Drawing.Point(79, 8)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(215, 32)
        Me.Label57.TabIndex = 357
        Me.Label57.Text = "Load Template"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbTemplates
        '
        Me.cmbTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTemplates.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTemplates.FormattingEnabled = True
        Me.cmbTemplates.Location = New System.Drawing.Point(313, 12)
        Me.cmbTemplates.Name = "cmbTemplates"
        Me.cmbTemplates.Size = New System.Drawing.Size(174, 28)
        Me.cmbTemplates.TabIndex = 0
        '
        'lblB4
        '
        Me.lblB4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblB4.Location = New System.Drawing.Point(929, 75)
        Me.lblB4.Name = "lblB4"
        Me.lblB4.Size = New System.Drawing.Size(34, 26)
        Me.lblB4.TabIndex = 373
        Me.lblB4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblB3
        '
        Me.lblB3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblB3.Location = New System.Drawing.Point(892, 75)
        Me.lblB3.Name = "lblB3"
        Me.lblB3.Size = New System.Drawing.Size(34, 26)
        Me.lblB3.TabIndex = 372
        Me.lblB3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblB2
        '
        Me.lblB2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblB2.Location = New System.Drawing.Point(855, 75)
        Me.lblB2.Name = "lblB2"
        Me.lblB2.Size = New System.Drawing.Size(34, 26)
        Me.lblB2.TabIndex = 371
        Me.lblB2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblB1
        '
        Me.lblB1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblB1.Location = New System.Drawing.Point(818, 75)
        Me.lblB1.Name = "lblB1"
        Me.lblB1.Size = New System.Drawing.Size(34, 26)
        Me.lblB1.TabIndex = 370
        Me.lblB1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label49
        '
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(694, 75)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(118, 26)
        Me.Label49.TabIndex = 374
        Me.Label49.Text = "Bearings"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label59
        '
        Me.Label59.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.Location = New System.Drawing.Point(934, 48)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(30, 26)
        Me.Label59.TabIndex = 368
        Me.Label59.Text = "HD"
        Me.Label59.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label58
        '
        Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.Location = New System.Drawing.Point(896, 48)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(30, 26)
        Me.Label58.TabIndex = 367
        Me.Label58.Text = "HC"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label56
        '
        Me.Label56.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.Location = New System.Drawing.Point(861, 48)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(30, 26)
        Me.Label56.TabIndex = 369
        Me.Label56.Text = "HB"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label51
        '
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(823, 48)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(30, 26)
        Me.Label51.TabIndex = 366
        Me.Label51.Text = "HA"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLub
        '
        Me.lblLub.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLub.Location = New System.Drawing.Point(494, 77)
        Me.lblLub.Name = "lblLub"
        Me.lblLub.Size = New System.Drawing.Size(147, 26)
        Me.lblLub.TabIndex = 364
        Me.lblLub.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label45
        '
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(370, 77)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(118, 26)
        Me.Label45.TabIndex = 365
        Me.Label45.Text = "Lubrication"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPartNo
        '
        Me.lblPartNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartNo.Location = New System.Drawing.Point(494, 49)
        Me.lblPartNo.Name = "lblPartNo"
        Me.lblPartNo.Size = New System.Drawing.Size(147, 26)
        Me.lblPartNo.TabIndex = 362
        Me.lblPartNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label47
        '
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(370, 49)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(118, 26)
        Me.Label47.TabIndex = 363
        Me.Label47.Text = "Part No"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMake
        '
        Me.lblMake.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMake.Location = New System.Drawing.Point(182, 77)
        Me.lblMake.Name = "lblMake"
        Me.lblMake.Size = New System.Drawing.Size(147, 26)
        Me.lblMake.TabIndex = 360
        Me.lblMake.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label39
        '
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(58, 77)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(118, 26)
        Me.Label39.TabIndex = 361
        Me.Label39.Text = "Make"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTestID
        '
        Me.lblTestID.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTestID.Location = New System.Drawing.Point(182, 49)
        Me.lblTestID.Name = "lblTestID"
        Me.lblTestID.Size = New System.Drawing.Size(147, 26)
        Me.lblTestID.TabIndex = 359
        Me.lblTestID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label36
        '
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(58, 49)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(118, 26)
        Me.Label36.TabIndex = 358
        Me.Label36.Text = "Test ID"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmLoad
        '
        Me.CancelButton = Me.btnReturn
        Me.ClientSize = New System.Drawing.Size(1261, 644)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblB4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lblB3)
        Me.Controls.Add(Me.lblMcHead)
        Me.Controls.Add(Me.lblB2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblB1)
        Me.Controls.Add(Me.btnReturn)
        Me.Controls.Add(Me.Label49)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label59)
        Me.Controls.Add(Me.Label58)
        Me.Controls.Add(Me.graphLoad)
        Me.Controls.Add(Me.Label56)
        Me.Controls.Add(Me.dgvLoad)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.PictureBox9)
        Me.Controls.Add(Me.lblLub)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.lblPartNo)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label47)
        Me.Controls.Add(Me.lblTestID)
        Me.Controls.Add(Me.lblMake)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.PictureBox8)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLoad"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Load"
        CType(Me.dgvLoad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.graphLoad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bndSrcLoad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.nupRunMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupEndLoad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupRunSec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupSec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupRunHr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupHr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvLoad As DataGridView
    Friend WithEvents graphLoad As DataVisualization.Charting.Chart
    Friend WithEvents Label35 As Label
    Friend WithEvents PictureBox8 As PictureBox
    Friend WithEvents PictureBox9 As PictureBox
    Friend WithEvents btnReturn As GaryPerkin.UserControls.Buttons.RoundButton
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents bndSrcLoad As BindingSource
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtCurStp As TextBox
    Friend WithEvents btnDeleteRow As Button
    Friend WithEvents btnClearRow As Button
    Friend WithEvents btnUpdateRow As Button
    Friend WithEvents btnAddNewRow As Button
    Friend WithEvents nupRunMin As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents nupEndLoad As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents nupSec As NumericUpDown
    Friend WithEvents nupMin As NumericUpDown
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents nupHr As NumericUpDown
    Friend WithEvents Label15 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents lblMcHead As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnCopyFromTemplate As Button
    Friend WithEvents Label57 As Label
    Friend WithEvents cmbTemplates As ComboBox
    Friend WithEvents btnopnTmpLoc As Button
    Friend WithEvents nupRunSec As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents nupRunHr As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents lblB4 As Label
    Friend WithEvents lblB3 As Label
    Friend WithEvents lblB2 As Label
    Friend WithEvents lblB1 As Label
    Friend WithEvents Label49 As Label
    Friend WithEvents Label59 As Label
    Friend WithEvents Label58 As Label
    Friend WithEvents Label56 As Label
    Friend WithEvents Label51 As Label
    Friend WithEvents lblLub As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents lblPartNo As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents lblMake As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents lblTestID As Label
    Friend WithEvents Label36 As Label
End Class
