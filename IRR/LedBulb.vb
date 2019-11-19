Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Diagnostics

Namespace Bulb
    Partial Public Class LedBulb
        Inherits Control

        Private _color As Color
        Private _on As Boolean = True
        Private _reflectionColor As Color = Color.FromArgb(180, 255, 255, 255)
        Private _surroundColor As Color() = New Color() {Color.FromArgb(0, 255, 255, 255)}
        Private _timer As Timer = New Timer()

        <DefaultValue(GetType(Color), "153, 255, 54")>
        Public Property Color As Color
            Get
                Return _color
            End Get
            Set(ByVal value As Color)
                _color = value
                'Arun
                Me.LightLightColor = ControlPaint.LightLight(_color)
                Me.DarkColor = ControlPaint.Dark(_color)
                Me.DarkDarkColor = ControlPaint.DarkDark(_color)
                Me.Invalidate()
            End Set
        End Property

        Public Property DarkColor As Color
        Public Property DarkDarkColor As Color
        Public Property LightLightColor As Color

        Public Property [On] As Boolean
            Get
                Return _on
            End Get
            Set(ByVal value As Boolean)
                _on = value
                Me.Invalidate()
            End Set
        End Property

        Public Sub New()
            SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint Or ControlStyles.SupportsTransparentBackColor, True)
            Me.Color = Color.FromArgb(255, 153, 255, 54)
            AddHandler _timer.Tick, New EventHandler(Sub(ByVal sender As Object, ByVal e As EventArgs)
                                                         Me.[On] = Not Me.[On]
                                                     End Sub)
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            Dim offScreenBmp As Bitmap = New Bitmap(Me.ClientRectangle.Width, Me.ClientRectangle.Height)

            Using g As System.Drawing.Graphics = Graphics.FromImage(offScreenBmp)
                g.SmoothingMode = SmoothingMode.HighQuality
                drawControl(g, Me.[On])
                e.Graphics.DrawImageUnscaled(offScreenBmp, 0, 0)
            End Using
        End Sub

        Private Sub drawControl(ByVal g As Graphics, ByVal [on] As Boolean)
            Dim lightColor As Color = If(([on]), Me.Color, Color.FromArgb(150, Me.DarkColor))
            Dim darkColor As Color = If(([on]), Me.DarkColor, Me.DarkDarkColor)
            Dim width As Integer = Me.Width - (Me.Padding.Left + Me.Padding.Right) - 2
            Dim height As Integer = Me.Height - (Me.Padding.Top + Me.Padding.Bottom) - 2
            Dim diameter As Integer = Math.Min(width, height)
            diameter = Math.Max(diameter - 1, 1)

            'Arun
            If _on Then
                Dim lrectangle = New Rectangle(Me.Padding.Left, Me.Padding.Top, diameter, diameter)
                g.FillEllipse(New SolidBrush(LightLightColor), lrectangle)
                'DarkDarkColor = darkColor
            End If
            'end Arun
            Dim rectangle = New Rectangle(Me.Padding.Left + 4, Me.Padding.Top + 4, diameter - 8, diameter - 8)
            g.FillEllipse(New SolidBrush(darkColor), rectangle)
            Dim path = New GraphicsPath()
            path.AddEllipse(rectangle)
            Dim pathBrush = New PathGradientBrush(path)
            pathBrush.CenterColor = lightColor
            pathBrush.SurroundColors = New Color() {Color.FromArgb(0, lightColor)}
            g.FillEllipse(pathBrush, rectangle)
            Dim offset = Convert.ToInt32(diameter * 0.15F)
            Dim diameter1 = Convert.ToInt32(rectangle.Width * 0.8F)
            Dim whiteRect = New Rectangle(rectangle.X - offset, rectangle.Y - offset, diameter1, diameter1)
            Dim path1 = New GraphicsPath()
            path1.AddEllipse(whiteRect)
            Dim pathBrush1 = New PathGradientBrush(path)
            pathBrush1.CenterColor = _reflectionColor
            pathBrush1.SurroundColors = _surroundColor
            g.FillEllipse(pathBrush1, whiteRect)
            g.SetClip(Me.ClientRectangle)
            If Me.[On] Then g.DrawEllipse(New Pen(Color.FromArgb(85, Color.Black), 1.0F), rectangle)
        End Sub

        Public Sub Blink(ByVal milliseconds As Integer)
            If milliseconds > 0 Then
                Me.[On] = True
                _timer.Interval = milliseconds
                _timer.Enabled = True
            Else
                _timer.Enabled = False
                Me.[On] = False
            End If
        End Sub
    End Class
End Namespace
