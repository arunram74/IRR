﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRunSusp
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rndBtnFail = New IRR.GaryPerkin.UserControls.Buttons.RoundButton()
        Me.rndBtnSuspend = New IRR.GaryPerkin.UserControls.Buttons.RoundButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(97, 158)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(110, 34)
        Me.btnCancel.TabIndex = 337
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(209, 125)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 339
        Me.Label1.Text = "FAIL"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(61, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 339
        Me.Label2.Text = "SUSPEND"
        '
        'rndBtnFail
        '
        Me.rndBtnFail.BackColor = System.Drawing.Color.Red
        Me.rndBtnFail.BackgroundImage = Global.IRR.My.Resources.Resources.Head
        Me.rndBtnFail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.rndBtnFail.BevelHeight = 2
        Me.rndBtnFail.Font = New System.Drawing.Font("Webdings", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.rndBtnFail.ForeColor = System.Drawing.Color.ForestGreen
        Me.rndBtnFail.Image = Global.IRR.My.Resources.Resources.Head
        Me.rndBtnFail.Location = New System.Drawing.Point(176, 31)
        Me.rndBtnFail.Name = "rndBtnFail"
        Me.rndBtnFail.RecessDepth = 3
        Me.rndBtnFail.Size = New System.Drawing.Size(97, 94)
        Me.rndBtnFail.TabIndex = 332
        Me.rndBtnFail.Tag = "Run"
        Me.rndBtnFail.Text = Nothing
        Me.rndBtnFail.UseVisualStyleBackColor = False
        '
        'rndBtnSuspend
        '
        Me.rndBtnSuspend.BackColor = System.Drawing.Color.Gold
        Me.rndBtnSuspend.BackgroundImage = Global.IRR.My.Resources.Resources.Head
        Me.rndBtnSuspend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.rndBtnSuspend.BevelHeight = 2
        Me.rndBtnSuspend.Font = New System.Drawing.Font("Webdings", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.rndBtnSuspend.Image = Global.IRR.My.Resources.Resources.Head
        Me.rndBtnSuspend.Location = New System.Drawing.Point(40, 31)
        Me.rndBtnSuspend.Name = "rndBtnSuspend"
        Me.rndBtnSuspend.RecessDepth = 3
        Me.rndBtnSuspend.Size = New System.Drawing.Size(97, 94)
        Me.rndBtnSuspend.TabIndex = 332
        Me.rndBtnSuspend.Text = Nothing
        Me.rndBtnSuspend.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(6, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(299, 146)
        Me.Label3.TabIndex = 340
        '
        'frmRunSusp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(309, 198)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.rndBtnFail)
        Me.Controls.Add(Me.rndBtnSuspend)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRunSusp"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Choose Action"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rndBtnSuspend As GaryPerkin.UserControls.Buttons.RoundButton
    Friend WithEvents btnCancel As Button
    Friend WithEvents rndBtnFail As GaryPerkin.UserControls.Buttons.RoundButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
