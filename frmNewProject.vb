Public Class frmNewProject

    Public FileToOpen As String
    Public sample As Boolean = False
    'TIPS - MERGED
    Public CurrentTip As Integer
    Public Tip0 As String = "Did you know you can create your own scripts? This feature is for advanced users but can be useful for more advanced functions in your game. GO to Create > Script. More information on the EGM Language can be found in the help documents."
    Public Tip1 As String = "This is the second tip and is reserved for when it is needed"
    Public Tip2 As String = "This is the third tip and is reserved for when it is needed"
    Public Tip3 As String = "This is the fourth tip and is reserved for when it is needed"
    Public Tip4 As String = "This is the fifth tip and is reserved for when it is needed"
    Public Tip5 As String = "This is the sixth tip and is reserved for when it is needed"
    'TIPS - END

    Private Sub btnBlank_Click(sender As Object, e As EventArgs) Handles btnBlank.Click
        frmEngine.EngineSetTitle = "Untitled"
        frmScrptWndw.rtbScript.Text = ""
        frmScrptWndw.rtbScript2.Text = ""
        frmScrptWndw.SaveScripts()
        frmEngine.BasicLoadEvents()
        Me.Close()
        frmEngine.UpdateEngine()
    End Sub

    Private Sub btnRecent1_Click(sender As Object, e As EventArgs) Handles btnRecent1.Click
        FileToOpen = My.Settings.Recent1
        LoadProject()
    End Sub

    Private Sub btnRecent2_Click(sender As Object, e As EventArgs) Handles btnRecent2.Click
        FileToOpen = My.Settings.Recent2
        LoadProject()
    End Sub

    Private Sub btnRecent3_Click(sender As Object, e As EventArgs) Handles btnRecent3.Click
        FileToOpen = My.Settings.Recent3
        LoadProject()
    End Sub

    Private Sub btnRecent4_Click(sender As Object, e As EventArgs) Handles btnRecent4.Click
        FileToOpen = My.Settings.Recent4
        LoadProject()
    End Sub

    Private Sub btnRecent5_Click(sender As Object, e As EventArgs) Handles btnRecent5.Click
        FileToOpen = My.Settings.Recent5
        LoadProject()
    End Sub

    Private Sub btnRecent6_Click(sender As Object, e As EventArgs) Handles btnRecent6.Click
        FileToOpen = My.Settings.Recent6
        LoadProject()
    End Sub

    Private Sub btnRecent7_Click(sender As Object, e As EventArgs) Handles btnRecent7.Click
        FileToOpen = My.Settings.Recent7
        LoadProject()
    End Sub

    Private Sub btnRecent8_Click(sender As Object, e As EventArgs) Handles btnRecent8.Click
        FileToOpen = My.Settings.Recent8
        LoadProject()
    End Sub

    Private Sub frmNewProject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'TIPS - MERGED
            chkStartup.Checked = My.Settings.ShowTips
            If My.Settings.ShowTips = True Then
                'frmTips.ShowDialog()
                'Show a random tip 
                Randomize()
                CurrentTip = 5 * Rnd()
                ShowTip(CurrentTip)
                chkStartup.Checked = True
            Else
                btnNext.Enabled = False
                btnPrev.Enabled = False
                txtTips.Enabled = False
                chkStartup.Checked = False
            End If
            
            'TIPS - END
            If My.Settings.Recent1 = "" Then
                btnRecent1.Enabled = False
            End If
            If My.Settings.Recent2 = "" Then
                btnRecent2.Enabled = False
            End If
            If My.Settings.Recent3 = "" Then
                btnRecent3.Enabled = False
            End If
            If My.Settings.Recent4 = "" Then
                btnRecent4.Enabled = False
            End If
            If My.Settings.Recent5 = "" Then
                btnRecent5.Enabled = False
            End If
            If My.Settings.Recent6 = "" Then
                btnRecent6.Enabled = False
            End If
            If My.Settings.Recent7 = "" Then
                btnRecent7.Enabled = False
            End If
            If My.Settings.Recent8 = "" Then
                btnRecent8.Enabled = False
            End If
            Dim inf1 As New IO.FileInfo(My.Settings.Recent1)
            btnRecent1.Text = inf1.Name
            Dim inf2 As New IO.FileInfo(My.Settings.Recent2)
            btnRecent2.Text = inf2.Name
            Dim inf3 As New IO.FileInfo(My.Settings.Recent3)
            btnRecent3.Text = inf3.Name
            Dim inf4 As New IO.FileInfo(My.Settings.Recent4)
            btnRecent4.Text = inf4.Name
            Dim inf5 As New IO.FileInfo(My.Settings.Recent5)
            btnRecent5.Text = inf5.Name
            Dim inf6 As New IO.FileInfo(My.Settings.Recent6)
            btnRecent6.Text = inf6.Name
            Dim inf7 As New IO.FileInfo(My.Settings.Recent7)
            btnRecent7.Text = inf7.Name
            Dim inf8 As New IO.FileInfo(My.Settings.Recent8)
            btnRecent8.Text = inf8.Name
        Catch ex As Exception

        End Try
        
    End Sub

    Function LoadProject()
        Try
            Dis()
            Dim ReadFile As New System.IO.StreamReader(FileToOpen)
            Dim AllLines As List(Of String) = New List(Of String)
            Do While Not ReadFile.EndOfStream
                AllLines.Add(ReadFile.ReadLine())
            Loop
            ReadFile.Close()
            frmEngine.EngineSetTitle = frmEngine.ReadLine(1, AllLines)
            frmEngine.Startmode = frmEngine.ReadLine(2, AllLines)
            frmEngine.RCol = frmEngine.ReadLine(3, AllLines)
            frmEngine.GCol = frmEngine.ReadLine(4, AllLines)
            frmEngine.BCol = frmEngine.ReadLine(5, AllLines)
            frmEngine.BasicLoadEvents()
            WriteScript()
            Me.Close()
            Return Nothing
        Catch ex As Exception
            En()
        End Try
        Return Nothing
    End Function

    Public Sub WriteScript()
        Try
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Projects\" & frmEngine.EngineSetTitle & ".egms1") Then
                frmScrptWndw.Build = My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\Projects\" & frmEngine.EngineSetTitle & ".egms1")
                frmScrptWndw.Build2 = My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\Projects\" & frmEngine.EngineSetTitle & ".egms2")
                frmScrptWndw.rtbScript.Text = frmScrptWndw.Build
                frmScrptWndw.Text = frmScrptWndw.Build2
            End If
            My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Projects\" & frmEngine.EngineSetTitle & ".egms1", frmScrptWndw.rtbScript.Text, False)
            My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Projects\" & frmEngine.EngineSetTitle & ".egms2", frmScrptWndw.rtbScript2.Text, False)
            'Store the text in a variable in the engine
            If frmScrptWndw.rtbScript.Text = "" Then
                'Do nothing 
            Else
                frmEngine.ScriptText = ""
                For Each ln As String In frmScrptWndw.rtbScript.Lines
                    frmEngine.ScriptText = frmEngine.ScriptText & vbNewLine & ln
                Next
            End If
            If frmScrptWndw.rtbScript2.Text = "" Then
                'Do nothing 
            Else
                frmEngine.ScriptText2 = ""
                For Each ln As String In frmScrptWndw.rtbScript2.Lines
                    frmEngine.ScriptText2 = frmEngine.ScriptText2 & vbNewLine & ln
                Next
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub btnSample1_Click(sender As Object, e As EventArgs) Handles btnSample1.Click
        'open key events project
        Try
            FileToOpen = Application.StartupPath & "\Samples\sample1.egm"
            LoadProject()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSample2_Click(sender As Object, e As EventArgs) Handles btnSample2.Click
        'draw sprites sample
        Try
            FileToOpen = Application.StartupPath & "\Samples\sample2.egm"
            LoadProject()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSample3_Click(sender As Object, e As EventArgs) Handles btnSample3.Click
        'dimensions
        Try
            FileToOpen = Application.StartupPath & "\Samples\sample3.egm"
            LoadProject()
        Catch ex As Exception
        End Try
    End Sub
    'TIPS - MERGED
    Private Sub chkStartup_CheckedChanged(sender As Object, e As EventArgs) Handles chkStartup.Click
        My.Settings.ShowTips = Not My.Settings.ShowTips
        My.Settings.Save()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        'Me.Close()
        'frmNewProject.ShowDialog()
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        'Previous Tip
        If CurrentTip >= 1 Then
            CurrentTip -= 1
            ShowTip(CurrentTip)
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        'Next Tip
        If CurrentTip <= 4 Then
            CurrentTip += 1
            ShowTip(CurrentTip)
        End If
    End Sub

    Public Function ShowTip(ByVal Tip As Integer)
        If Tip = 0 Then
            txtTips.Text = Tip0
        ElseIf Tip = 1 Then
            txtTips.Text = Tip1
        ElseIf Tip = 2 Then
            txtTips.Text = Tip2
        ElseIf Tip = 3 Then
            txtTips.Text = Tip3
        ElseIf Tip = 4 Then
            txtTips.Text = Tip4
        ElseIf Tip = 5 Then
            txtTips.Text = Tip5
        End If
        Return Nothing
    End Function
    'TIPS - END

    Private Sub frmNewProject_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        En()
    End Sub
    Private Sub En()
        btnBlank.Enabled = True
        btnSample1.Enabled = True
        btnSample2.Enabled = True
        btnSample3.Enabled = True
        Me.Refresh()
    End Sub
    Private Sub Dis()
        btnBlank.Enabled = False
        btnSample1.Enabled = False
        btnSample2.Enabled = False
        btnSample3.Enabled = False
        Me.Refresh()
    End Sub
End Class