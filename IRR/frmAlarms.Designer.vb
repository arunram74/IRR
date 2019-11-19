<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAlarms
    Inherits IRR.frmChild

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
        CType(Me.dgvAlarm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvAlarm
        '
        Me.dgvAlarm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvAlarm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAlarm.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvAlarm.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvAlarm.Location = New System.Drawing.Point(0, 12)
        Me.dgvAlarm.Name = "dgvAlarm"
        Me.dgvAlarm.ReadOnly = True
        Me.dgvAlarm.Size = New System.Drawing.Size(1435, 632)
        Me.dgvAlarm.TabIndex = 3
        '
        'frmAlarms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1435, 644)
        Me.Controls.Add(Me.dgvAlarm)
        Me.Name = "frmAlarms"
        CType(Me.dgvAlarm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvAlarm As DataGridView
End Class
