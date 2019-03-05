
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Design
Imports LifeTestRig.GaryPerkin.Utils.Text
Imports System.Windows.Forms.Design


Friend Class resfinder
End Class

Namespace GaryPerkin.UserControls.Buttons
    Structure Angle
        Public Const Up As Single = 50.0F
        Public Const Down As Single = Angle.Up + 180.0F
    End Structure

    <Description("Round (Elliptical) Button Control"), ToolboxBitmap(GetType(resfinder), "RoundButton.Images.RoundButton.bmp")>
    Public Class RoundButton
        Inherits System.Windows.Forms.Button

        Public Overrides Property Text As String
            Get
                Return buttonText
            End Get
            Set(ByVal value As String)
                buttonText = value
                Me.Invalidate()
            End Set
        End Property

        Private intRecessDepth As Integer

        <Bindable(True), Category("Button Appearance"), DefaultValue(2), Description("Specifies the depth of the button's recess."), Editor(GetType(RecessEditor), GetType(System.Drawing.Design.UITypeEditor))>
        Public Property RecessDepth As Integer
            Get
                Return intRecessDepth
            End Get
            Set(ByVal value As Integer)

                If value < 0 Then
                    intRecessDepth = 0
                ElseIf value > 15 Then
                    intRecessDepth = 15
                Else
                    intRecessDepth = value
                End If

                Me.Invalidate()
            End Set
        End Property

        Private intbevelHeight As Integer

        <Bindable(True), Category("Button Appearance"), DefaultValue(0), Description("Specifies the height of the button's bevel.")>
        Public Property BevelHeight As Integer
            Get
                Return intbevelHeight
            End Get
            Set(ByVal value As Integer)

                If value < 0 Then
                    intbevelHeight = 0
                Else
                    intbevelHeight = value
                End If

                Me.Invalidate()
            End Set
        End Property

        Private intbevelDepth As Integer

        <Bindable(True), Category("Button Appearance"), DefaultValue(0), Description("Specifies the depth of the button's bevel.")>
        Public Property BevelDepth As Integer
            Get
                Return intbevelDepth
            End Get
            Set(ByVal value As Integer)

                If value < 0 Then
                    intbevelDepth = 0
                Else
                    intbevelDepth = value
                End If

                Me.Invalidate()
            End Set
        End Property

        Private intdome As Boolean

        <Bindable(True), Category("Button Appearance"), DefaultValue(False), Description("Specifies whether the button has a intdomed top.")>
        Public Property Dome As Boolean
            Get
                Return intdome
            End Get
            Set(ByVal value As Boolean)
                intdome = value
                Me.Invalidate()
            End Set
        End Property

        Public Sub New()
            Me.Name = "RoundButton"
            Me.Size = New System.Drawing.Size(50, 50)
            'Me.mouseDown += New System.Windows.Forms.MouseEventHandler(AddressOf Me.mouseDown)
            'Me.mouseUp += New System.Windows.Forms.MouseEventHandler(AddressOf Me.mouseUp)
            'AddHandler Me.Enter, New System.EventHandler(AddressOf Me.weGotFocus)
            'AddHandler Me.Leave, New System.EventHandler(AddressOf Me.weLostFocus)
            'Me.keyDown += New System.Windows.Forms.KeyEventHandler(AddressOf Me.keyDown)
            'Me.keyUp += New System.Windows.Forms.KeyEventHandler(AddressOf Me.keyUp)

            AddHandler Me.MouseDown, AddressOf emouseDown
            AddHandler Me.MouseUp, AddressOf emouseUp
            AddHandler Me.Enter, AddressOf Me.weGotFocus
            AddHandler Me.Leave, AddressOf Me.weLostFocus
            AddHandler Me.KeyDown, AddressOf ekeyDown
            AddHandler Me.KeyUp, AddressOf ekeyUp
        End Sub

        Private buttonColor As Color
        Private buttonText As String
        Private edgeBrush As LinearGradientBrush
        Private edgeBlend As Blend
        Private edgeColor1 As Color
        Private edgeColor2 As Color
        Private edgeWidth As Integer
        Private buttonPressOffset As Integer
        Private lightAngle As Single = Angle.Up
        Private cColor As Color = Color.White
        Shadows gotFocus As Boolean = False
        Private labelFont As Font
        Private vs As VerticalString
        Private labelBrush As SolidBrush
        Private labelStrFmt As StringFormat
        Private bpath As GraphicsPath
        Private gpath As GraphicsPath

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            buttonColor = Me.BackColor
            edgeColor1 = ControlPaint.Light(buttonColor)
            edgeColor2 = ControlPaint.Dark(buttonColor)
            Dim g As Graphics = e.Graphics

            g.SmoothingMode = SmoothingMode.AntiAlias
            Dim buttonRect As Rectangle = Me.ClientRectangle
            edgeWidth = GetEdgeWidth(buttonRect)
            FillBackground(g, buttonRect)

            If intRecessDepth > 0 Then
                DrawRecess(g, buttonRect)
            End If

            DrawEdges(g, buttonRect)
            ShrinkShape(g, buttonRect, edgeWidth)
            DrawButton(g, buttonRect)
            DrawText(g, buttonRect)
            SetClickableRegion()
        End Sub

        Protected Sub FillBackground(ByVal g As Graphics, ByVal rect As Rectangle)
            Dim bgRect As Rectangle = rect
            bgRect.Inflate(1, 1)
            Dim bgBrush As SolidBrush = New SolidBrush(Color.FromKnownColor(KnownColor.Control))

            bgBrush.Color = Parent.BackColor
            g.FillRectangle(bgBrush, bgRect)
            bgBrush.Dispose()
        End Sub

        Protected Overridable Sub DrawRecess(ByRef g As Graphics, ByRef recessRect As Rectangle)
            Dim recessBrush As LinearGradientBrush = New LinearGradientBrush(recessRect, ControlPaint.Dark(Parent.BackColor), ControlPaint.LightLight(Parent.BackColor), GetLightAngle(Angle.Up))
            Dim recessBlend As Blend = New Blend()
            recessBlend.Positions = New Single() {0.0F, 0.2F, 0.4F, 0.6F, 0.8F, 1.0F}
            recessBlend.Factors = New Single() {0.2F, 0.2F, 0.4F, 0.4F, 1.0F, 1.0F}
            recessBrush.Blend = recessBlend
            Dim rect2 As Rectangle = recessRect
            ShrinkShape(g, rect2, 1)
            FillShape(g, recessBrush, rect2)
            ShrinkShape(g, recessRect, intRecessDepth)
        End Sub

        Protected Overridable Sub DrawEdges(ByVal g As Graphics, ByRef edgeRect As Rectangle)
            ShrinkShape(g, edgeRect, 1)
            Dim lgbRect As Rectangle = edgeRect
            lgbRect.Inflate(1, 1)
            edgeBrush = New LinearGradientBrush(lgbRect, edgeColor1, edgeColor2, GetLightAngle(lightAngle))
            edgeBlend = New Blend()
            edgeBlend.Positions = New Single() {0.0F, 0.2F, 0.4F, 0.6F, 0.8F, 1.0F}
            edgeBlend.Factors = New Single() {.0F, .0F, 0.2F, 0.4F, 1.0F, 1.0F}
            edgeBrush.Blend = edgeBlend
            FillShape(g, edgeBrush, edgeRect)
        End Sub

        Protected Overridable Sub DrawButton(ByVal g As Graphics, ByVal buttonRect As Rectangle)
            BuildGraphicsPath(buttonRect)
            Dim pgb As PathGradientBrush = New PathGradientBrush(bpath)
            pgb.SurroundColors = New Color() {buttonColor}
            buttonRect.Offset(buttonPressOffset, buttonPressOffset)

            If intbevelHeight > 0 Then
                Dim lgbRect As Rectangle = buttonRect
                lgbRect.Inflate(1, 1)
                pgb.CenterPoint = New PointF(buttonRect.X + buttonRect.Width / 8 + buttonPressOffset, buttonRect.Y + buttonRect.Height / 8 + buttonPressOffset)
                pgb.CenterColor = cColor
                FillShape(g, pgb, buttonRect)
                ShrinkShape(g, buttonRect, intbevelHeight)
            End If

            If intbevelDepth > 0 Then
                DrawInnerBevel(g, buttonRect, intbevelDepth, buttonColor)
                ShrinkShape(g, buttonRect, intbevelDepth)
            End If

            pgb.CenterColor = buttonColor

            If intdome Then
                pgb.CenterColor = cColor
                pgb.CenterPoint = New PointF(buttonRect.X + buttonRect.Width / 8 + buttonPressOffset, buttonRect.Y + buttonRect.Height / 8 + buttonPressOffset)
            End If

            FillShape(g, pgb, buttonRect)

            If gotFocus Then
                DrawFocus(g, buttonRect)
            End If
        End Sub

        Protected Sub DrawText(ByVal g As Graphics, ByVal textRect As Rectangle)
            labelStrFmt = New StringFormat()
            labelBrush = New SolidBrush(Me.ForeColor)
            labelFont = Me.Font
            vs = New VerticalString()
            vs.TextSpread = 0.75
            Dim verticalText As Boolean = False

            If textRect.Height > textRect.Width * 2 Then
                verticalText = True
            End If

            labelStrFmt.Alignment = ConvertToHorAlign(Me.TextAlign)
            labelStrFmt.LineAlignment = ConvertToVertAlign(Me.TextAlign)

            If (Not verticalText And (labelStrFmt.LineAlignment <> StringAlignment.Center)) Or (verticalText And (labelStrFmt.Alignment <> StringAlignment.Center)) Then
                textRect.Inflate(-CInt((textRect.Width / 7.5)), -CInt((textRect.Height / 7.5)))
            End If

            textRect.Offset(buttonPressOffset, buttonPressOffset)

            If Not Me.Enabled Then
                textRect.Offset(1, 1)
                labelBrush.Color = ControlPaint.LightLight(buttonColor)
                WriteString(verticalText, g, textRect)
                textRect.Offset(-1, -1)
                labelBrush.Color = Color.Gray
            End If

            WriteString(verticalText, g, textRect)
        End Sub

        Protected Overridable Sub BuildGraphicsPath(ByVal buttonRect As Rectangle)
            bpath = New GraphicsPath()
            Dim rect2 As Rectangle = New Rectangle(buttonRect.X - 1, buttonRect.Y - 1, buttonRect.Width + 2, buttonRect.Height + 2)
            AddShape(bpath, rect2)
            AddShape(bpath, buttonRect)
        End Sub

        Protected Overridable Sub SetClickableRegion()
            gpath = New GraphicsPath()
            gpath.AddEllipse(Me.ClientRectangle)
            Me.Region = New Region(gpath)
        End Sub

        Protected Overridable Sub FillShape(ByVal g As Graphics, ByVal brush As Object, ByVal rect As Rectangle)

            If brush.[GetType]().ToString() = "System.Drawing.Drawing2D.LinearGradientBrush" Then
                g.FillEllipse(CType(brush, LinearGradientBrush), rect)
            ElseIf brush.[GetType]().ToString() = "System.Drawing.Drawing2D.PathGradientBrush" Then
                g.FillEllipse(CType(brush, PathGradientBrush), rect)
            End If
        End Sub

        Protected Overridable Sub AddShape(ByVal gpath As GraphicsPath, ByVal rect As Rectangle)
            gpath.AddEllipse(rect)
        End Sub

        Protected Overridable Sub DrawShape(ByVal g As Graphics, ByVal pen As Pen, ByVal rect As Rectangle)
            g.DrawEllipse(pen, rect)
        End Sub

        Protected Overridable Sub ShrinkShape(ByRef g As Graphics, ByRef rect As Rectangle, ByVal amount As Integer)
            rect.Inflate(-amount, -amount)
        End Sub

        Protected Overridable Sub DrawFocus(ByVal g As Graphics, ByVal rect As Rectangle)
            rect.Inflate(-2, -2)
            Dim fPen As Pen = New Pen(Color.Black)
            fPen.DashStyle = DashStyle.Dot
            DrawShape(g, fPen, rect)
        End Sub

        Protected Overridable Sub DrawInnerBevel(ByVal g As Graphics, ByVal rect As Rectangle, ByVal depth As Integer, ByVal buttonColor As Color)
            Dim lightColor As Color = ControlPaint.LightLight(buttonColor)
            Dim darkColor As Color = ControlPaint.Dark(buttonColor)
            Dim bevelBlend As Blend = New Blend()
            bevelBlend.Positions = New Single() {0.0F, 0.2F, 0.4F, 0.6F, 0.8F, 1.0F}
            bevelBlend.Factors = New Single() {0.2F, 0.4F, 0.6F, 0.6F, 1.0F, 1.0F}
            Dim lgbRect As Rectangle = rect
            lgbRect.Inflate(1, 1)
            Dim innerBevelBrush As LinearGradientBrush = New LinearGradientBrush(lgbRect, darkColor, lightColor, GetLightAngle(Angle.Up))
            innerBevelBrush.Blend = bevelBlend
            FillShape(g, innerBevelBrush, rect)
        End Sub

        Protected Function GetLightAngle(ByVal angle As Single) As Single
            Dim f As Single = 1 - CSng(Me.Width) / Me.Height
            Dim a As Single = angle - (15 * f)
            Return a
        End Function

        Protected Function GetEdgeWidth(ByVal rect As Rectangle) As Integer
            If rect.Width < 50 Or rect.Height < 50 Then
                Return 1
            Else
                Return 2
            End If
        End Function

        Protected Sub WriteString(ByVal vertical As Boolean, ByVal g As Graphics, ByVal textRect As Rectangle)
            If vertical Then
                vs.Draw(g, buttonText, labelFont, labelBrush, textRect, labelStrFmt)
            Else
                g.DrawString(buttonText, labelFont, labelBrush, textRect, labelStrFmt)
            End If
        End Sub

        Protected Function ConvertToHorAlign(ByVal ca As ContentAlignment) As StringAlignment
            If (ca = ContentAlignment.TopLeft) Or (ca = ContentAlignment.MiddleLeft) Or (ca = ContentAlignment.BottomLeft) Then
                Return StringAlignment.Near
            ElseIf (ca = ContentAlignment.TopRight) Or (ca = ContentAlignment.MiddleRight) Or (ca = ContentAlignment.BottomRight) Then
                Return StringAlignment.Far
            Else
                Return StringAlignment.Center
            End If
        End Function

        Protected Function ConvertToVertAlign(ByVal ca As ContentAlignment) As StringAlignment
            If (ca = ContentAlignment.TopLeft) Or (ca = ContentAlignment.TopCenter) Or (ca = ContentAlignment.TopRight) Then
                Return StringAlignment.Near
            ElseIf (ca = ContentAlignment.BottomLeft) Or (ca = ContentAlignment.BottomCenter) Or (ca = ContentAlignment.BottomRight) Then
                Return StringAlignment.Far
            Else
                Return StringAlignment.Center
            End If
        End Function

        Protected Sub emouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            buttonDown()
        End Sub

        Protected Sub emouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            buttonUp()
        End Sub

        Protected Sub buttonDown()
            lightAngle = Angle.Down
            buttonPressOffset = 1
            Me.Invalidate()
        End Sub

        Protected Sub buttonUp()
            lightAngle = Angle.Up
            buttonPressOffset = 0
            Me.Invalidate()
        End Sub

        Protected Sub ekeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode.ToString() = "Space" Then
                buttonDown()
            End If
        End Sub

        Protected Sub ekeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode.ToString() = "Space" Then
                buttonUp()
            End If
        End Sub

        Protected Sub weGotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
            gotFocus = True
            Me.Invalidate()
        End Sub

        Protected Sub weLostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
            gotFocus = False
            buttonUp()
            Me.Invalidate()
        End Sub
    End Class

    Public Class RecessEditor
        Inherits System.Drawing.Design.UITypeEditor

        Public Overrides Function GetEditStyle(ByVal context As ITypeDescriptorContext) As UITypeEditorEditStyle
            If context IsNot Nothing Then
                Return UITypeEditorEditStyle.DropDown
            End If

            Return MyBase.GetEditStyle(context)
        End Function

        Public Overrides Function EditValue(ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object
            If (context IsNot Nothing) AndAlso (provider IsNot Nothing) Then
                Dim editorService As IWindowsFormsEditorService = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)

                If editorService IsNot Nothing Then
                    Dim dropDownEditor As RecessEditorControl = New RecessEditorControl(editorService)
                    dropDownEditor.Recess = CInt(value)
                    editorService.DropDownControl(dropDownEditor)
                    Return dropDownEditor.Recess
                End If
            End If

            Return MyBase.EditValue(context, provider, value)
        End Function
    End Class
End Namespace
