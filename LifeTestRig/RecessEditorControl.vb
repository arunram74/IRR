
Imports System.ComponentModel

Imports System.Drawing.Drawing2D

Imports System.Windows.Forms.Design

Namespace GaryPerkin.UserControls.Buttons
    <ToolboxItem(False)>
    Partial Public Class RecessEditorControl
        Inherits UserControl

        Public Sub New()
            InitializeComponent()
        End Sub

        Private editorService As IWindowsFormsEditorService = Nothing
        Private intrecess As Integer = 2

        Public Sub New(ByVal editorService As IWindowsFormsEditorService)
            InitializeComponent()
            Me.editorService = editorService
        End Sub

        Public Property Recess As Integer
            Get
                Return intrecess
            End Get
            Set(ByVal value As Integer)
                intrecess = value
            End Set
        End Property

        Private Sub pictureBox0_Click(ByVal sender As Object, ByVal e As EventArgs)
            intrecess = 0
            editorService.CloseDropDown()
        End Sub

        Private Sub pictureBox2_Click(ByVal sender As Object, ByVal e As EventArgs)
            intrecess = 2
            editorService.CloseDropDown()
        End Sub

        Private Sub pictureBox3_Click(ByVal sender As Object, ByVal e As EventArgs)
            intrecess = 3
            editorService.CloseDropDown()
        End Sub

        Private Sub pictureBox4_Click(ByVal sender As Object, ByVal e As EventArgs)
            intrecess = 4
            editorService.CloseDropDown()
        End Sub

        Private Sub pictureBox5_Click(ByVal sender As Object, ByVal e As EventArgs)
            intrecess = 5
            editorService.CloseDropDown()
        End Sub

        Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
            MyBase.OnPaint(pe)
            Dim selected As PictureBox = New PictureBox()
            Dim nonstandard As Boolean = False

            Select Case intrecess
                Case 0
                    selected = Me.pictureBox0
                Case 2
                    selected = Me.pictureBox2
                Case 3
                    selected = Me.pictureBox3
                Case 4
                    selected = Me.pictureBox4
                Case 5
                    selected = Me.pictureBox5
                Case Else
                    nonstandard = True
            End Select

            If Not nonstandard Then
                Dim g As Graphics = pe.Graphics

                Using pen As Pen = New Pen(Color.Gray, 1)
                    pen.DashStyle = DashStyle.Dot
                    Dim rect As Rectangle = New Rectangle(New Point(selected.Left - 2, selected.Top - 2), New Size(selected.Width + 4, selected.Height + 4))
                    g.DrawRectangle(pen, rect)
                End Using
            End If
        End Sub

        Private Sub intrecessEditorControl_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
            If e.KeyCode = Keys.Left Then
                intrecess = intrecess - 1
                If intrecess = 1 Then intrecess = 0
                If intrecess = -1 Then intrecess = 5
                Me.Invalidate()
            ElseIf e.KeyCode = Keys.Right Then
                intrecess = intrecess + 1
                If intrecess = 1 Then intrecess = 2
                If intrecess = 6 Then intrecess = 0
                Me.Invalidate()
            End If
        End Sub

        Private WithEvents pictureBox5 As PictureBox
        Private WithEvents pictureBox4 As PictureBox
        Private WithEvents pictureBox3 As PictureBox
        Private WithEvents pictureBox2 As PictureBox
        Private WithEvents pictureBox0 As PictureBox

        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RecessEditorControl))
            Me.pictureBox5 = New System.Windows.Forms.PictureBox()
            Me.pictureBox4 = New System.Windows.Forms.PictureBox()
            Me.pictureBox3 = New System.Windows.Forms.PictureBox()
            Me.pictureBox2 = New System.Windows.Forms.PictureBox()
            Me.pictureBox0 = New System.Windows.Forms.PictureBox()
            CType(Me.pictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.pictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.pictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.pictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.pictureBox0, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pictureBox5
            '
            Me.pictureBox5.Image = CType(resources.GetObject("pictureBox5.Image"), System.Drawing.Image)
            Me.pictureBox5.Location = New System.Drawing.Point(350, 55)
            Me.pictureBox5.Name = "pictureBox5"
            Me.pictureBox5.Size = New System.Drawing.Size(40, 40)
            Me.pictureBox5.TabIndex = 9
            Me.pictureBox5.TabStop = False
            '
            'pictureBox4
            '
            Me.pictureBox4.Image = CType(resources.GetObject("pictureBox4.Image"), System.Drawing.Image)
            Me.pictureBox4.Location = New System.Drawing.Point(304, 55)
            Me.pictureBox4.Name = "pictureBox4"
            Me.pictureBox4.Size = New System.Drawing.Size(40, 40)
            Me.pictureBox4.TabIndex = 8
            Me.pictureBox4.TabStop = False
            '
            'pictureBox3
            '
            Me.pictureBox3.Image = CType(resources.GetObject("pictureBox3.Image"), System.Drawing.Image)
            Me.pictureBox3.Location = New System.Drawing.Point(258, 55)
            Me.pictureBox3.Name = "pictureBox3"
            Me.pictureBox3.Size = New System.Drawing.Size(40, 40)
            Me.pictureBox3.TabIndex = 7
            Me.pictureBox3.TabStop = False
            '
            'pictureBox2
            '
            Me.pictureBox2.Image = CType(resources.GetObject("pictureBox2.Image"), System.Drawing.Image)
            Me.pictureBox2.Location = New System.Drawing.Point(212, 55)
            Me.pictureBox2.Name = "pictureBox2"
            Me.pictureBox2.Size = New System.Drawing.Size(40, 40)
            Me.pictureBox2.TabIndex = 6
            Me.pictureBox2.TabStop = False
            '
            'pictureBox0
            '
            Me.pictureBox0.Image = CType(resources.GetObject("pictureBox0.Image"), System.Drawing.Image)
            Me.pictureBox0.Location = New System.Drawing.Point(166, 55)
            Me.pictureBox0.Name = "pictureBox0"
            Me.pictureBox0.Size = New System.Drawing.Size(40, 40)
            Me.pictureBox0.TabIndex = 5
            Me.pictureBox0.TabStop = False
            '
            'RecessEditorControl
            '
            Me.Controls.Add(Me.pictureBox5)
            Me.Controls.Add(Me.pictureBox4)
            Me.Controls.Add(Me.pictureBox3)
            Me.Controls.Add(Me.pictureBox2)
            Me.Controls.Add(Me.pictureBox0)
            Me.Name = "RecessEditorControl"
            Me.Size = New System.Drawing.Size(556, 150)
            CType(Me.pictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.pictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.pictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.pictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.pictureBox0, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
    End Class
End Namespace
