'Option Strict On
Imports System
Imports System.Windows.Forms
Imports System.Windows.Forms.Form
Imports System.Windows.Forms.Button
Imports System.Windows.Forms.Application
Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Drawing.Image
Imports System.Diagnostics.Process
Imports System.IO.DirectoryInfo
Imports System.IO.FileInfo
Imports System.IO.Path
Imports System.IO.StreamReader
Imports System.Collections.Generic



Public Class EntryPoint
    Public Shared Sub Main(args As [String]())
        Dim FrmMain As New frmGame
        System.Windows.Forms.Application.Run(FrmMain)
    End Sub
End Class

Public Class frmGame
    Inherits System.Windows.Forms.Form


    Sub New()
        Application.EnableVisualStyles()
        'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'Me.WindowState = FormWindowState.Maximized
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Untitled"
        Me.BackColor = System.Drawing.Color.Beige




        Room_Dimension(600, 600)


    End Sub
    'Dec will go here
    Public WindowText As String = "Untitled"



    'Core functions

    Private Sub Me_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
    End Sub

    Public CallLeftUp As String = "LeftUp"
    Public CallRightUp As String = "RightUp"
    Public CallDownUp As String = "DownUp"
    Public CallUpUp As String = "UpUp"
    Public CallLeftDown As String = "LeftDown"
    Public CallRightDown As String = "RightDown"
    Public CallDownDown As String = "DownDown"
    Public CallUpDown As String = "UpDown"

    Public DrawCharacter As Boolean = False
    Public ThisCharacter As String
    Public CharacterSizeX As Integer
    Public CharacterSizeY As Integer
    Public CharacterLocationX As Integer
    Public CharacterLocationY As Integer
    Public CharacterDrawLocation As System.Drawing.Bitmap = System.Drawing.Image.FromFile(ThisCharacter)

    Private Sub Me_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp

        Try
            If e.KeyValue = Keys.Left Then
                CallByName(Me, CallLeftUp, CallType.Method)
            End If
            If e.KeyValue = Keys.Right Then
                CallByName(Me, CallRightUp, CallType.Method)
            End If
            If e.KeyValue = Keys.Down Then
                CallByName(Me, CallDownUp, CallType.Method)
            End If
            If e.KeyValue = Keys.Up Then
                CallByName(Me, CallUpUp, CallType.Method)
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyValue = Keys.Left Then
                CallByName(Me, CallLeftDown, CallType.Method)
            End If
            If e.KeyValue = Keys.Right Then
                CallByName(Me, CallRightDown, CallType.Method)
            End If
            If e.KeyValue = Keys.Down Then
                CallByName(Me, CallDownDown, CallType.Method)
            End If
            If e.KeyValue = Keys.Up Then
                CallByName(Me, CallUpDown, CallType.Method)
            End If
        Catch ex As Exception

        End Try


    End Sub
    Public Function Room_Height(rType As String, rSize As Integer)
        If rType = "GET" Then
            Dim x As Integer
            x = Height
            Return x
        ElseIf rType = "SET" Then
            Height = rSize
        End If
        Return Nothing
    End Function
    Public Function Room_Width(rType As String, rSize As Integer)
        If rType = "GET" Then
            Dim x As Integer
            x = Width
            Return x
        ElseIf rType = "SET" Then
            Width = rSize
        End If
        Return Nothing
    End Function
    Public Function Room_Dimension(xSize As Integer, ySize As Integer)
        Width = xSize
        Height = ySize
        Return Nothing
    End Function
    Public xScore As Integer = 0
    Public Function Score(rScore As Integer, rRelative As Boolean)
        If rRelative = True Then
            xScore += rScore
        Else
            xScore = rScore
        End If
        Return Nothing
    End Function
    Public Function DrawScore()
        Me.Text = WindowText & " |  Score: " & xScore
        Return Nothing
    End Function
    Public xLives As Integer = 3
    Public lblLives As New label
    Public Function Lives()
        lblLives.Text = "Lives: " & xLives
        lblLives.ForeColor = Color.White
        lblLives.Location = New Point(15, 15)
        Dim f As New System.Drawing.Font("Calibri", 12)
        lblLives.Font = f
        Me.Controls.Add(lblLives)
        Return Nothing
    End Function
    Public Function ReadLine(lineNumber As Integer, lines As List(Of String)) As String
        Return lines(lineNumber - 1)
    End Function
    Public Function Draw_Sprite(SpriteName As String, Xx As Integer, Yy As Integer, xSize As Integer, ySize As Integer)
        Dim di As New System.IO.DirectoryInfo(Application.StartupPath & "\Projects\Resources\Misc\")
        Dim fiArr As System.IO.FileInfo() = di.GetFiles()
        Dim fri As System.IO.FileInfo
        For Each fri In fiArr
            Dim ReadFile As New System.IO.StreamReader(fri.FullName)
            Dim AllLines As List(Of String) = New List(Of String)
            Do While Not ReadFile.EndOfStream
                AllLines.Add(ReadFile.ReadLine())
            Loop
            ReadFile.Close()
            Dim Reader = ReadLine(2, AllLines)
            If Reader = SpriteName Then
                'We've found our Sprite, use the file name of the egmr file to find the image
                Dim di2 As New System.IO.DirectoryInfo(Application.StartupPath & "\Projects\Resources\")
                Dim fiArr2 As System.IO.FileInfo() = di2.GetFiles()
                Dim fri2 As System.IO.FileInfo
                For Each fri2 In fiArr2
                    Dim Test As String = fri2.FullName
                    If Test.Contains(System.IO.Path.GetFileNameWithoutExtension(fri.FullName)) Then
                        Dim Cntr As New PictureBox
                        Cntr.BackColor = Me.BackColor
                        Cntr.BackGroundImage = System.Drawing.Image.FromFile(Test)
                        Cntr.Width = xSize
                        Cntr.Height = ySize
                        Cntr.Location = New Point(Xx, Yy)
                        Me.Controls.Add(Cntr)
                    End If
                Next fri2
            End If
        Next fri
        Return Nothing
    End Function
    'Public Function Draw_Spr(SpriteName As String, Xx As Integer, Yy As Integer, xSize As Integer, ySize As Integer)
    '    Dim di As New System.IO.DirectoryInfo(Application.StartupPath & "\Projects\Resources\Misc\")
    '    Dim fiArr As System.IO.FileInfo() = di.GetFiles()
    '    Dim fri As System.IO.FileInfo
    '    For Each fri In fiArr
    '        Dim ReadFile As New System.IO.StreamReader(fri.FullName)
    '        Dim AllLines As List(Of String) = New List(Of String)
    '        Do While Not ReadFile.EndOfStream
    '            AllLines.Add(ReadFile.ReadLine())
    '        Loop
    '        ReadFile.Close()
    '        Dim Reader = ReadLine(2, AllLines)
    '        If Reader = SpriteName Then
    '            'We've found our Sprite, use the file name of the egmr file to find the image
    '            Dim di2 As New System.IO.DirectoryInfo(Application.StartupPath & "\Projects\Resources\")
    '            Dim fiArr2 As System.IO.FileInfo() = di2.GetFiles()
    '            Dim fri2 As System.IO.FileInfo
    '            For Each fri2 In fiArr2
    '                CharacterLocationX = Xx
    '                CharacterLocationY = Yy
    '                CharacterSizeX = xSize
    '                CharacterSizeY = ySize
    '                ThisCharacter = fri2.FullName
    '                DrawCharacter = True
    '                Me.Invalidate()
    '            Next fri2
    '        End If
    '    Next fri
    '    Return Nothing
    'End Function

    'Private Sub Me_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
    '    Try
    '        If DrawCharacter = True Then
    '            e.Graphics.DrawImage(CharacterDrawLocation, CharacterLocationX, CharacterLocationY, CharacterSizeX, CharacterSizeY)
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub

End Class
'script to go here now....