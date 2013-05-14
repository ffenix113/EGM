Imports System.IO

Public Class frmAddSprite

    Public SpriteName As String
    Public SpriteTitleName As String
    Public CurrentSpritePath As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Try
            CurrentSpritePath = OpenFileDialog1.FileName
            SpriteName = OpenFileDialog1.SafeFileName
            ptrbxSpriteView.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName.ToString)
            Dim SizeX As Integer
            Dim SizeY As Integer
            SizeX = ptrbxSpriteView.BackgroundImage.Size.Width
            SizeY = ptrbxSpriteView.BackgroundImage.Size.Height
            lblSize.Text = "Size: X: " & SizeX & " Y: " & SizeY
            Dim CleanPath As String = OpenFileDialog1.SafeFileName
            System.IO.Path.GetFileNameWithoutExtension(CleanPath)
            CleanPath = System.IO.Path.GetFileNameWithoutExtension(CleanPath) & ".egmr"
            My.Computer.FileSystem.CopyFile(OpenFileDialog1.FileName, Application.StartupPath & "\Projects\Resources\" & OpenFileDialog1.SafeFileName)
            My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Projects\Resources\Misc\" & CleanPath, frmEngine.EngineSetTitle & vbCrLf & txtName.Text, False)
            ComboBox1.Items.Clear()
            LoadSpritesList()
            ComboBox1.Text = System.IO.Path.GetFileNameWithoutExtension(CleanPath)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmAddSprite_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSpritesList()
    End Sub

    Public Function ReadLine(lineNumber As Integer, lines As List(Of String)) As String
        Try
            Return lines(lineNumber - 1)
        Catch ex As Exception

        End Try
        Return Nothing
    End Function

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        UpdateCurrentSelectedSprite()
    End Sub

    Public Sub LoadSpritesList()
        Try
            Dim di As New DirectoryInfo(Application.StartupPath & "\Projects\Resources\Misc\")
            Dim fiArr As FileInfo() = di.GetFiles()
            Dim fri As FileInfo
            For Each fri In fiArr
                Dim ReadFile As New System.IO.StreamReader(fri.FullName)
                Dim AllLines As List(Of String) = New List(Of String)
                Do While Not ReadFile.EndOfStream
                    AllLines.Add(ReadFile.ReadLine())
                Loop
                ReadFile.Close()
                Dim reader = ReadLine(1, AllLines)
                If reader = frmEngine.EngineSetTitle Then
                    ComboBox1.Items.Add(System.IO.Path.GetFileNameWithoutExtension(fri.FullName))
                End If
            Next fri
        Catch ex As Exception

        End Try
       
    End Sub

    Public Sub UpdateCurrentSelectedSprite()
        Dim di As New DirectoryInfo(Application.StartupPath & "\Projects\Resources\")
        Dim fiArr As FileInfo() = di.GetFiles()
        Dim fri As FileInfo
        For Each fri In fiArr
            Dim test As String = fri.FullName
            If test.Contains(ComboBox1.Text) Then
                SpriteName = fri.FullName
                CurrentSpritePath = fri.FullName
                ptrbxSpriteView.BackgroundImage = Image.FromFile(fri.FullName)
                Dim SizeX As Integer
                Dim SizeY
                SizeX = ptrbxSpriteView.BackgroundImage.Size.Width
                SizeY = ptrbxSpriteView.BackgroundImage.Size.Height
                lblSize.Text = "Size: X: " & SizeX & " Y: " & SizeY
            End If
            'Set the image and now set the sprite name
            Dim di2 As New DirectoryInfo(Application.StartupPath & "\Projects\Resources\Misc\")
            Dim fiArr2 As FileInfo() = di2.GetFiles()
            Dim fri2 As FileInfo
            For Each fri2 In fiArr2
                Dim ReadFile As New System.IO.StreamReader(fri2.FullName)
                Dim AllLines As List(Of String) = New List(Of String)
                Do While Not ReadFile.EndOfStream
                    AllLines.Add(ReadFile.ReadLine())
                Loop
                ReadFile.Close()
                Dim test2 = fri2.FullName
                If test2.Contains(ComboBox1.Text) Then
                    Dim sprname = ReadLine(2, AllLines)
                    txtName.Text = sprname
                End If
            Next fri2
        Next fri

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            'Update the egmr file
            Dim di2 As New DirectoryInfo(Application.StartupPath & "\Projects\Resources\Misc\")
            Dim fiArr2 As FileInfo() = di2.GetFiles()
            Dim fri2 As FileInfo
            For Each fri2 In fiArr2
                Dim Check = fri2.FullName
                If Check.Contains(ComboBox1.Text) Then
                    Dim ReadFile As New System.IO.StreamReader(fri2.FullName)
                    Dim AllLines As List(Of String) = New List(Of String)
                    Do While Not ReadFile.EndOfStream
                        AllLines.Add(ReadFile.ReadLine())
                    Loop
                    ReadFile.Close()
                    Dim SpriteProjectBelongsTo As String = ReadLine(1, AllLines)
                    My.Computer.FileSystem.WriteAllText(fri2.FullName, SpriteProjectBelongsTo & vbCrLf & txtName.Text, False)
                End If
                MsgBox("Updated current sprite")
                Exit Sub
            Next fri2
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click
        Me.Close()
    End Sub

    Private Sub frmAddSprite_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frmEngine.SpriteCount = 0
    End Sub
End Class