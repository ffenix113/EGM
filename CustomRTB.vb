Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace WindowsFormsApplication1

    Public Class CustomRTB
        Inherits RichTextBox
        <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
        Public Shared Function GetScrollPos(ByVal hWnd As IntPtr, ByVal nBar As Integer) As Integer
        End Function

        <DllImport("user32.dll")> _
        Private Shared Function SetScrollPos(ByVal hWnd As IntPtr, ByVal nBar As Integer, ByVal nPos As Integer, ByVal bRedraw As Boolean) As Integer
        End Function

        Private Const SB_HORZ As Integer = &H0
        Private Const SB_VERT As Integer = &H1

        ''' <summary>
        ''' Gets and Sets the Horizontal Scroll position of the control.
        ''' </summary>
        Public Property HScrollPos() As Integer
            Get
                Return GetScrollPos(DirectCast(Me.Handle, IntPtr), SB_HORZ)
            End Get
            Set(ByVal value As Integer)
                SetScrollPos(DirectCast(Me.Handle, IntPtr), SB_HORZ, value, True)
            End Set
        End Property

        ''' <summary>
        ''' Gets and Sets the Vertical Scroll position of the control.
        ''' </summary>
        Public Property VScrollPos() As Integer
            Get
                Return GetScrollPos(DirectCast(Me.Handle, IntPtr), SB_VERT)
            End Get
            Set(ByVal value As Integer)
                SetScrollPos(DirectCast(Me.Handle, IntPtr), SB_VERT, value, True)
            End Set
        End Property
    End Class

End Namespace