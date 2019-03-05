<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSuspFail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSuspFail))
        Me.rndBtnFailed = New LifeTestRig.GaryPerkin.UserControls.Buttons.RoundButton()
        Me.rndBtnSuspend = New LifeTestRig.GaryPerkin.UserControls.Buttons.RoundButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rndBtnFailed
        '
        Me.rndBtnFailed.BackColor = System.Drawing.Color.OrangeRed
        Me.rndBtnFailed.BackgroundImage = Global.LifeTestRig.My.Resources.Resources.Head
        Me.rndBtnFailed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.rndBtnFailed.BevelHeight = 2
        Me.rndBtnFailed.Font = New System.Drawing.Font("Segoe UI Symbol", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rndBtnFailed.ForeColor = System.Drawing.Color.OrangeRed
        Me.rndBtnFailed.Image = Global.LifeTestRig.My.Resources.Resources.Head
        Me.rndBtnFailed.Location = New System.Drawing.Point(241, 40)
        Me.rndBtnFailed.Name = "rndBtnFailed"
        Me.rndBtnFailed.RecessDepth = 3
        Me.rndBtnFailed.Size = New System.Drawing.Size(97, 94)
        Me.rndBtnFailed.TabIndex = 335
        Me.rndBtnFailed.Text = ""
        Me.rndBtnFailed.UseVisualStyleBackColor = False
        '
        'rndBtnSuspend
        '
        Me.rndBtnSuspend.BackColor = System.Drawing.Color.Gold
        Me.rndBtnSuspend.BackgroundImage = Global.LifeTestRig.My.Resources.Resources.Head
        Me.rndBtnSuspend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.rndBtnSuspend.BevelHeight = 2
        Me.rndBtnSuspend.Font = New System.Drawing.Font("Webdings", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.rndBtnSuspend.Image = Global.LifeTestRig.My.Resources.Resources.Head
        Me.rndBtnSuspend.Location = New System.Drawing.Point(79, 40)
        Me.rndBtnSuspend.Name = "rndBtnSuspend"
        Me.rndBtnSuspend.RecessDepth = 3
        Me.rndBtnSuspend.Size = New System.Drawing.Size(97, 94)
        Me.rndBtnSuspend.TabIndex = 334
        Me.rndBtnSuspend.Text = Nothing
        Me.rndBtnSuspend.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(278, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 340
        Me.Label3.Text = "FAIL"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 137)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(186, 13)
        Me.Label2.TabIndex = 341
        Me.Label2.Text = "SUSPEND AND REMOVE PROJECT"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.Location = New System.Drawing.Point(286, 177)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(89, 26)
        Me.Cancel_Button.TabIndex = 342
        Me.Cancel_Button.Text = "Cancel"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(10, 11)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(370, 160)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 343
        Me.PictureBox1.TabStop = False
        '
        'frmSuspFail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 208)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.rndBtnFailed)
        Me.Controls.Add(Me.rndBtnSuspend)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSuspFail"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Suspend or Fail"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rndBtnFailed As GaryPerkin.UserControls.Buttons.RoundButton
    Friend WithEvents rndBtnSuspend As GaryPerkin.UserControls.Buttons.RoundButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Cancel_Button As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
