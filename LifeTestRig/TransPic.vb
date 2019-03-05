Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

Public Class TransPic
    Inherits Control

    Public drag As Boolean = False
    Public enab As Boolean = False
    Private m_opacity As Integer = 100
    Private alpha As Integer
    Dim meSel As Boolean = False
    Dim mbordercolor As Color = Color.Red
    Dim mborder As Boolean = False

    Public Sub New()
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.Opaque, True)
        Me.BackColor = Color.Transparent
    End Sub

    Public Property Opacity As Integer
        Get

            If m_opacity > 100 Then
                m_opacity = 100
            ElseIf m_opacity < 1 Then
                m_opacity = 1
            End If

            Return Me.m_opacity
        End Get
        Set(ByVal value As Integer)
            Me.m_opacity = value

            If Me.Parent IsNot Nothing Then
                Parent.Invalidate(Me.Bounds, True)
            End If
        End Set
    End Property

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H20
            Return cp
        End Get
    End Property

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        Dim bounds As Rectangle = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Dim frmColor As Color = Me.Parent.BackColor
        Dim bckColor As Brush = Nothing
        Dim borderPen As Pen = Nothing
        alpha = (m_opacity * 255) / 100

        If drag Then
            Dim dragBckColor As Color = Nothing

            If BackColor <> Color.Transparent Then
                Dim Rb As Integer = BackColor.R * alpha / 255 + frmColor.R * (255 - alpha) / 255
                Dim Gb As Integer = BackColor.G * alpha / 255 + frmColor.G * (255 - alpha) / 255
                Dim Bb As Integer = BackColor.B * alpha / 255 + frmColor.B * (255 - alpha) / 255
                dragBckColor = Color.FromArgb(Rb, Gb, Bb)
            Else
                dragBckColor = frmColor
            End If

            alpha = 255
            bckColor = New SolidBrush(Color.FromArgb(alpha, dragBckColor))
        Else
            bckColor = New SolidBrush(Color.FromArgb(alpha, Me.BackColor))
        End If

        If Me.BackColor <> Color.Transparent Or drag Then
            g.FillRectangle(bckColor, bounds)
        End If

        borderPen = New Pen(mbordercolor)
        borderPen.Width = 4.0F
        If mborder Then g.DrawRectangle(borderPen, bounds)

        bckColor.Dispose()
        g.Dispose()
        MyBase.OnPaint(e)
    End Sub

    Protected Overrides Sub OnBackColorChanged(ByVal e As EventArgs)
        If Me.Parent IsNot Nothing Then
            Parent.Invalidate(Me.Bounds, True)
        End If

        MyBase.OnBackColorChanged(e)
    End Sub

    Protected Overrides Sub OnParentBackColorChanged(ByVal e As EventArgs)
        Me.Invalidate()
        MyBase.OnParentBackColorChanged(e)
    End Sub

    Public Sub ResizetoPanel(myPar As Panel)
        Me.Left = 0
        Me.Top = 0
        Me.Width = myPar.Width
        Me.Height = myPar.Height
    End Sub

    Public Property Selected As Boolean
        Get
            Selected = meSel
        End Get
        Set(value As Boolean)
            meSel = value
            'If meSel Then Me.m_opacity = 50 Else Me.m_opacity = 1
            'If Me.Parent IsNot Nothing Then
            '    Parent.Invalidate(Me.Bounds, True)
            'End If
        End Set
    End Property

    Public Property BorderColor As Color
        Get
            BorderColor = mbordercolor
        End Get
        Set(value As Color)
            mbordercolor = value
        End Set
    End Property

    Public Property Border As Boolean
        Get
            Border = mborder
        End Get
        Set(value As Boolean)
            mborder = value
            If Me.Parent IsNot Nothing Then
                Parent.Invalidate(Me.Bounds, True)
            End If
        End Set
    End Property
End Class
