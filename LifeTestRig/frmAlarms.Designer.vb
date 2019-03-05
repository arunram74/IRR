<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAlarms
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
        Me.dgvAlarm = New System.Windows.Forms.DataGridView()
        Me.rbMC4 = New System.Windows.Forms.RadioButton()
        Me.rbMC3 = New System.Windows.Forms.RadioButton()
        Me.rbMC2 = New System.Windows.Forms.RadioButton()
        Me.rbMC1 = New System.Windows.Forms.RadioButton()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        CType(Me.dgvAlarm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvAlarm
        '
        Me.dgvAlarm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvAlarm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAlarm.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvAlarm.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvAlarm.Location = New System.Drawing.Point(0, 75)
        Me.dgvAlarm.Name = "dgvAlarm"
        Me.dgvAlarm.ReadOnly = True
        Me.dgvAlarm.Size = New System.Drawing.Size(1435, 569)
        Me.dgvAlarm.TabIndex = 3
        '
        'rbMC4
        '
        Me.rbMC4.AutoSize = True
        Me.rbMC4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMC4.Location = New System.Drawing.Point(757, 26)
        Me.rbMC4.Name = "rbMC4"
        Me.rbMC4.Size = New System.Drawing.Size(126, 24)
        Me.rbMC4.TabIndex = 471
        Me.rbMC4.Text = "RadioButton1"
        Me.rbMC4.UseVisualStyleBackColor = True
        '
        'rbMC3
        '
        Me.rbMC3.AutoSize = True
        Me.rbMC3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMC3.Location = New System.Drawing.Point(544, 26)
        Me.rbMC3.Name = "rbMC3"
        Me.rbMC3.Size = New System.Drawing.Size(126, 24)
        Me.rbMC3.TabIndex = 470
        Me.rbMC3.Text = "RadioButton1"
        Me.rbMC3.UseVisualStyleBackColor = True
        '
        'rbMC2
        '
        Me.rbMC2.AutoSize = True
        Me.rbMC2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMC2.Location = New System.Drawing.Point(331, 26)
        Me.rbMC2.Name = "rbMC2"
        Me.rbMC2.Size = New System.Drawing.Size(126, 24)
        Me.rbMC2.TabIndex = 469
        Me.rbMC2.Text = "RadioButton1"
        Me.rbMC2.UseVisualStyleBackColor = True
        '
        'rbMC1
        '
        Me.rbMC1.AutoSize = True
        Me.rbMC1.Checked = True
        Me.rbMC1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMC1.Location = New System.Drawing.Point(118, 26)
        Me.rbMC1.Name = "rbMC1"
        Me.rbMC1.Size = New System.Drawing.Size(126, 24)
        Me.rbMC1.TabIndex = 468
        Me.rbMC1.TabStop = True
        Me.rbMC1.Text = "RadioButton1"
        Me.rbMC1.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(34, 1)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(96, 26)
        Me.Label26.TabIndex = 472
        Me.Label26.Text = "Machine"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Location = New System.Drawing.Point(26, 16)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(1117, 43)
        Me.PictureBox3.TabIndex = 473
        Me.PictureBox3.TabStop = False
        '
        'frmAlarms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1435, 644)
        Me.Controls.Add(Me.rbMC4)
        Me.Controls.Add(Me.rbMC3)
        Me.Controls.Add(Me.rbMC2)
        Me.Controls.Add(Me.rbMC1)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.dgvAlarm)
        Me.Name = "frmAlarms"
        CType(Me.dgvAlarm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvAlarm As DataGridView
    Friend WithEvents rbMC4 As RadioButton
    Friend WithEvents rbMC3 As RadioButton
    Friend WithEvents rbMC2 As RadioButton
    Friend WithEvents rbMC1 As RadioButton
    Friend WithEvents Label26 As Label
    Friend WithEvents PictureBox3 As PictureBox
End Class
