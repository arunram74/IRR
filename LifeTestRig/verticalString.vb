
Imports System.ComponentModel


Namespace GaryPerkin.Utils.Text
    Public Class VerticalString
        Private Enum esaType
            Pre
            Post
            Either
        End Enum

        Private intTextSpeard As Double

        Public Property TextSpread As Double
            Get
                Return intTextSpeard
            End Get
            Set(ByVal value As Double)
                intTextSpeard = value
            End Set
        End Property

        <Description("VerticalString Constructor")>
        Public Sub New()
            intTextSpeard = 0.75F
        End Sub

        <Description("Draw Method 1 - draw string in top left of rectangle." & "Calls Method 3")>
        Public Sub Draw(ByVal g As Graphics, ByVal text As String, ByVal font As Font, ByVal brush As Brush, ByVal stringRect As Rectangle)
            Me.Draw(g, text, font, brush, stringRect.X, stringRect.Y)
        End Sub

        <Description("Draw Method 2 - draw string in rectangle according to Alignment and LineAlignment" & "Calls Method 3")>
        Public Sub Draw(ByVal g As Graphics, ByVal text As String, ByVal font As Font, ByVal brush As Brush, ByVal stringRect As Rectangle, ByVal stringStrFmt As StringFormat)
            Dim horOffset As Integer
            Dim vertOffset As Integer

            Select Case stringStrFmt.Alignment
                Case StringAlignment.Center
                    horOffset = (stringRect.Width / 2) - CInt((font.Size / 2)) - 2
                Case StringAlignment.Far
                    horOffset = (stringRect.Width - CInt(font.Size) - 2)
                Case Else
                    horOffset = 0
            End Select

            Dim textSize As Double = Me.Length(text, font)

            Select Case stringStrFmt.LineAlignment
                Case StringAlignment.Center
                    vertOffset = (stringRect.Height / 2) - CInt((textSize / 2))
                Case StringAlignment.Far
                    vertOffset = stringRect.Height - CInt(textSize) - 2
                Case Else
                    vertOffset = 0
            End Select

            Me.Draw(g, text, font, brush, stringRect.X + horOffset, stringRect.Y + vertOffset)
        End Sub

        <Description("Draw Method 3 - draw string at coordinates x, y")>
        Public Sub Draw(ByVal g As Graphics, ByVal text As String, ByVal font As Font, ByVal brush As Brush, ByVal x As Integer, ByVal y As Integer)
            Dim textChars As Char() = text.ToCharArray()
            Dim charStrFmt As StringFormat = New StringFormat()
            charStrFmt.Alignment = StringAlignment.Center
            Dim charRect As Rectangle = New Rectangle(x, y, CInt((font.Size * 1.5)), font.Height)

            For i As Integer = 0 To text.Length - 1
                charRect.Offset(0, ExtraSpaceAllowance(esaType.Pre, textChars(i), font))
                g.DrawString(textChars(i).ToString(), font, brush, charRect, charStrFmt)
                charRect.Offset(0, CInt((font.Height * intTextSpeard)))
                charRect.Offset(0, ExtraSpaceAllowance(esaType.Post, textChars(i), font))
            Next
        End Sub

        <Description("Length Method - returns vertical length of string")>
        Public Function Length(ByVal text As String, ByVal font As Font) As Integer
            Dim textChars As Char() = text.ToCharArray()
            Dim len As Integer = New Integer()

            For i As Integer = 0 To text.Length - 1
                len += CInt((font.Height * intTextSpeard))
                len += ExtraSpaceAllowance(esaType.Either, textChars(i), font)
            Next

            Return len
        End Function

        Private Function ExtraSpaceAllowance(ByVal type As esaType, ByVal ch As Char, ByVal font As Font) As Integer
            If intTextSpeard >= 1 Then Return 0
            Dim offset As Integer = 0

            If type = esaType.Pre Or type = esaType.Either Then

                If " bdfhijkltABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".IndexOf(ch) > 0 Then
                    offset += CInt((font.Height * 0.2))
                End If
            End If

            If type = esaType.Post Or type = esaType.Either Then

                If " gjpqyQ".IndexOf(ch) > 0 Then
                    offset += CInt((font.Height * 0.2))
                End If
            End If

            Return offset
        End Function
    End Class
End Namespace
