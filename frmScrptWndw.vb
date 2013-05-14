Public Class frmScrptWndw

  

#Region "Declarations"

    Public Build As String
    Public Build2 As String
    Public xtext As String
    Public ytext As String
    Public CurrState As Boolean = True

#End Region

#Region "Editing"

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        If TabControl1.SelectedIndex = 0 Then
            rtbScript.SelectAll()
        Else
            rtbScript2.SelectAll()
        End If
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        If TabControl1.SelectedIndex = 0 Then
            rtbScript.Cut()
        Else
            rtbScript2.Cut()
        End If
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        If TabControl1.SelectedIndex = 0 Then
            rtbScript.Copy()
        Else
            rtbScript2.Copy()
        End If
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        If TabControl1.SelectedIndex = 0 Then
            rtbScript.Paste()
        Else
            rtbScript2.Paste()
        End If
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        If TabControl1.SelectedIndex = 0 Then
            rtbScript.Clear()
        Else
            rtbScript2.Clear()
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        SaveScripts()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            Process.Start(Application.StartupPath & "\EGM Documentation.pdf")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmScrptWndw_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SaveScripts()
        frmEngine.ScriptCount = 0
    End Sub

    Public Sub SaveScripts()
        My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Projects\" & frmEngine.EngineSetTitle & ".egms1", rtbScript.Text, False)
        My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Projects\" & frmEngine.EngineSetTitle & ".egms2", rtbScript2.Text, False)
        'Store the text in a variable in the engine
        If rtbScript.Text = "" Then
            'Do nothing 
        Else
            frmEngine.ScriptText = ""
            For Each ln As String In rtbScript.Lines
                frmEngine.ScriptText = frmEngine.ScriptText & vbNewLine & ln
            Next
        End If
        If rtbScript2.Text = "" Then
            'Do nothing 
        Else
            frmEngine.ScriptText2 = ""
            For Each ln As String In rtbScript2.Lines
                frmEngine.ScriptText2 = frmEngine.ScriptText2 & vbNewLine & ln
            Next
        End If
    End Sub

#End Region

#Region "Code Inserts"

    Private Sub RoomHeightSET600ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RoomHeightSET600ToolStripMenuItem.Click
        CheckTest(0)
        If CurrState = True Then
            rtbScript.Text = RoomHeightSET600ToolStripMenuItem.Text
            TabControl1.SelectTab(0)
        Else
            rtbScript.Text = rtbScript.Text & vbCrLf & RoomHeightSET600ToolStripMenuItem.Text
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub RoomHeightGET0ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RoomHeightGET0ToolStripMenuItem.Click
        rtbScript.Text = rtbScript.Text & vbCrLf & RoomHeightGET0ToolStripMenuItem.Text
        TabControl1.SelectTab(0)
        CheckTest(0)
        If CurrState = True Then
            rtbScript.Text = RoomHeightGET0ToolStripMenuItem.Text
            TabControl1.SelectTab(0)
        Else
            rtbScript.Text = rtbScript.Text & vbCrLf & RoomHeightGET0ToolStripMenuItem.Text
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub RoomWidthSET600ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RoomWidthSET600ToolStripMenuItem.Click
        CheckTest(0)
        If CurrState = True Then
            rtbScript.Text = RoomWidthSET600ToolStripMenuItem.Text
            TabControl1.SelectTab(0)
        Else
            rtbScript.Text = rtbScript.Text & vbCrLf & RoomWidthSET600ToolStripMenuItem.Text
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub RoomWidthGET0ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RoomWidthGET0ToolStripMenuItem.Click
        CheckTest(0)
        If CurrState = True Then
            rtbScript.Text = RoomWidthGET0ToolStripMenuItem.Text
            TabControl1.SelectTab(0)
        Else
            rtbScript.Text = rtbScript.Text & vbCrLf & RoomWidthGET0ToolStripMenuItem.Text
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub RoomDimension600600ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RoomDimension600600ToolStripMenuItem.Click
        CheckTest(0)
        If CurrState = True Then
            rtbScript.Text = RoomDimension600600ToolStripMenuItem.Text
            TabControl1.SelectTab(0)
        Else
            rtbScript.Text = rtbScript.Text & vbCrLf & RoomDimension600600ToolStripMenuItem.Text
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub UpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpToolStripMenuItem.Click
        'Left up
        CheckTest(1)
        If CurrState = True Then
            rtbScript2.Text = "Public Sub LeftUp()" & vbNewLine & "'Add your code for the Left Up key event here" & vbNewLine & "End Sub"
            TabControl1.SelectTab(1)
        Else
            rtbScript2.Text = rtbScript2.Text & vbNewLine & "Public Sub LeftUp()" & vbNewLine & "'Add your code for the Left Up key event here" & vbNewLine & "End Sub"
            TabControl1.SelectTab(1)
        End If
    End Sub

    Private Sub DownToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownToolStripMenuItem.Click
        'left down
        CheckTest(1)
        If CurrState = True Then
            rtbScript2.Text = "Public Sub LeftDown()" & vbNewLine & "'Add your code for the Left Down key event here" & vbNewLine & "End Sub"
            TabControl1.SelectTab(1)
        Else
            rtbScript2.Text = rtbScript2.Text & vbNewLine & "Public Sub LeftDown()" & vbNewLine & "'Add your code for the Left Down key event here" & vbNewLine & "End Sub"
            TabControl1.SelectTab(1)
        End If
    End Sub

    Private Sub UpToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UpToolStripMenuItem1.Click
        'right up
        CheckTest(1)
        If CurrState = True Then
            rtbScript2.Text = "Public Sub RightUp()" & vbNewLine & "'Add your code for the Right Up key event here" & vbNewLine & "End Sub"
            TabControl1.SelectTab(1)
        Else
            rtbScript2.Text = rtbScript2.Text & vbNewLine & "Public Sub RightUp()" & vbNewLine & "'Add your code for the Right Up key event here" & vbNewLine & "End Sub"
            TabControl1.SelectTab(1)
        End If
    End Sub

    Private Sub DownToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DownToolStripMenuItem1.Click
        'right down
        CheckTest(1)
        If CurrState = True Then
            rtbScript2.Text = "Public Sub RightDown()" & vbNewLine & "'Add your code for the Right Down key event here" & vbNewLine & "End Sub"
            TabControl1.SelectTab(1)
        Else
            rtbScript2.Text = rtbScript2.Text & vbNewLine & "Public Sub RightDown()" & vbNewLine & "'Add your code for the Right Down key event here" & vbNewLine & "End Sub"
            TabControl1.SelectTab(1)
        End If
    End Sub

    Private Sub UpToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles UpToolStripMenuItem2.Click
        'down up
        CheckTest(1)
        If CurrState = True Then
            rtbScript2.Text = "Public Sub DownUp()" & vbNewLine & "'Add your code for the Down Up key event here" & vbNewLine & "End Sub"
            TabControl1.SelectTab(1)
        Else
            rtbScript2.Text = rtbScript2.Text & vbNewLine & "Public Sub DownUp()" & vbNewLine & "'Add your code for the Down Up key event here" & vbNewLine & "End Sub"
            TabControl1.SelectTab(1)
        End If
    End Sub

    Private Sub DownToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles DownToolStripMenuItem2.Click
        'down down
        CheckTest(1)
        If CurrState = True Then
            rtbScript2.Text = "Public Sub DownDown()" & vbNewLine & "'Add your code for the Down Down key event here" & vbNewLine & "End Sub"
            TabControl1.SelectTab(1)
        Else
            rtbScript2.Text = rtbScript2.Text & vbNewLine & "Public Sub DownDown()" & vbNewLine & "'Add your code for the Down Down key event here" & vbNewLine & "End Sub"
            TabControl1.SelectTab(1)
        End If
    End Sub

    Private Sub UpToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles UpToolStripMenuItem3.Click
        'up up
        rtbScript2.Text = rtbScript2.Text & vbNewLine & "Public Sub UpUp()" & vbNewLine & "'Add your code for the Up Up key event here" & vbNewLine & "End Sub"
        TabControl1.SelectTab(1)
    End Sub

    Private Sub DownToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles DownToolStripMenuItem3.Click
        'up down
        rtbScript2.Text = rtbScript2.Text & vbNewLine & "Public Sub UpDown()" & vbNewLine & "'Add your code for the Up Down key event here" & vbNewLine & "End Sub"
        TabControl1.SelectTab(1)
        CheckTest(1)
        If CurrState = True Then
            rtbScript2.Text = "Public Sub UpDown()" & vbNewLine & "'Add your code for the Up Down key event here" & vbNewLine & "End Sub"
            TabControl1.SelectTab(1)
        Else
            rtbScript2.Text = rtbScript2.Text & vbNewLine & "Public Sub UpDown()" & vbNewLine & "'Add your code for the Up Down key event here" & vbNewLine & "End Sub"
            TabControl1.SelectTab(1)
        End If
    End Sub

    Private Sub XLivesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XLivesToolStripMenuItem.Click
        rtbScript.Text = rtbScript.Text & vbNewLine & "xLives = 0" & vbNewLine & "'Please make sure you place this inside of a method body or you will face compiler issues"
        TabControl1.SelectTab(0)
        CheckTest(0)
        If CurrState = True Then
            rtbScript.Text = "xLives = 0" & vbNewLine & "'Please make sure you place this inside of a method body or you will face compiler issues"
            TabControl1.SelectTab(0)
        Else
            rtbScript.Text = rtbScript.Text & vbNewLine & "xLives = 0" & vbNewLine & "'Please make sure you place this inside of a method body or you will face compiler issues"
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub XScoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XScoreToolStripMenuItem.Click
        CheckTest(0)
        If CurrState = True Then
            rtbScript.Text = "xScore = 0" & vbNewLine & "'Please make sure you place this inside of a method body or you will face compiler issues"
            TabControl1.SelectTab(0)
        Else
            rtbScript.Text = rtbScript.Text & vbNewLine & "xScore = 0" & vbNewLine & "'Please make sure you place this inside of a method body or you will face compiler issues"
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub Score0TrueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Score0TrueToolStripMenuItem.Click
        CheckTest(0)
        If CurrState = True Then
            rtbScript.Text = "Score(0, True)"
            TabControl1.SelectTab(0)
        Else
            rtbScript.Text = rtbScript.Text & vbNewLine & "Score(0, True)"
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub DrawScoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DrawScoreToolStripMenuItem.Click
        CheckTest(0)
        If CurrState = True Then
            rtbScript.Text = "DrawScore()"
            TabControl1.SelectTab(0)
        Else
            rtbScript.Text = rtbScript.Text & vbNewLine & "DrawScore()"
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub LivesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LivesToolStripMenuItem.Click
        CheckTest(0)
        If CurrState = True Then
            rtbScript.Text = "Lives()"
            TabControl1.SelectTab(0)
        Else
            rtbScript.Text = rtbScript.Text & vbNewLine & "Lives()"
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub DrawSpritesprNameXlocYlocXsizeYsizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DrawSpritesprNameXlocYlocXsizeYsizeToolStripMenuItem.Click
        CheckTest(0)
        If CurrState = True Then
            rtbScript.Text = "Draw_Sprite(""sprName"", xloc, yloc, xsize, ysize)"
            TabControl1.SelectTab(0)
        Else
            rtbScript.Text = rtbScript.Text & vbNewLine & "Draw_Sprite(""sprName"", xloc, yloc, xsize, ysize)"
            TabControl1.SelectTab(0)
        End If
    End Sub

#End Region

#Region "Load Events etc."

    Private Sub frmScrptWndw_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Projects\" & frmEngine.EngineSetTitle & ".egms1") Then
            Build = My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\Projects\" & frmEngine.EngineSetTitle & ".egms1")
            Build2 = My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\Projects\" & frmEngine.EngineSetTitle & ".egms2")
            rtbScript.Text = Build
            rtbScript2.Text = Build2
        End If
    End Sub

    Public Sub CheckTest(ByVal Cont As Integer)
        If Cont = 0 Then
            'The first text editor
            If rtbScript.Text = "" Then
                CurrState = True
            Else
                CurrState = False
            End If
        Else
            If rtbScript2.Text = "" Then
                CurrState = True
            Else
                CurrState = False
            End If
        End If
    End Sub

#End Region

End Class