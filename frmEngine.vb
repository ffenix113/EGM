Imports System.CodeDom.Compiler
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Reflection
Imports System.Diagnostics
Imports System.Threading
Imports FastColoredTextBoxNS

Public Class frmEngine

#Region "Declarations"

    'Declarations
    Public EngineTitle As String = "{Alpha} Explosive Game Maker - "
    Public EngineTitleEx As String = ".egm"
    Public EngineSetTitle As String = "Untitled"
    Public RCol = 64
    Public GCol = 64
    Public BCol = 64
    Public Startmode As Integer = 0 '0 for Windowed or 1 for full screen
    Public ScriptText() As Char
    Public ScriptText2() As Char
    Public HasBeenShown As Boolean = False
    Public CoreText As String
    Public IsDebugging As Boolean = False
    'Variables used to keep only one script window and sprite window open 
    Public ScriptCount As Integer = 0
    Public SpriteCount As Integer = 0

#End Region

#Region "Load"

    Private Sub tmrDisplay_Tick(sender As Object, e As EventArgs) Handles tmrDisplay.Tick
        'tmrDisplay.Stop()

    End Sub

    Private Sub frmEngine_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim thr As Thread = New Thread(AddressOf BasicLoadEvents)
        thr.IsBackground = True
        thr.Start()
        '=========================
        'TIPS - MERGED - LAST PIECE OF MERGING
        frmNewProject.ShowDialog()
        'BasicLoadEvents()
    End Sub

    Private Sub Me_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
    End Sub

    Public Sub BasicLoadEvents()
        CheckDirectorys()
        'Set the images of the TreeView Nodes
        Dim ImgLst As New ImageList
        ImgLst.Images.Add(My.Resources.egm_folder)
        ImgLst.Images.Add(My.Resources.script)
        ImgLst.Images.Add(My.Resources.audio)
        TreeView1.ImageList = ImgLst
        TreeView1.SelectedImageIndex = 0
        'Set and build the title
        Me.Invoke(New MethodInvoker(Function() Me.Text = EngineTitle & EngineSetTitle & EngineTitleEx))

        'Backcolor
        Dim Ctl As Control
        Dim CtlMDI As MdiClient
        For Each Ctl In Me.Controls
            Try
                CtlMDI = CType(Ctl, MdiClient)
                CtlMDI.BackColor = Color.FromArgb(64, 64, 64)
            Catch ex As Exception

            End Try
        Next

    End Sub

#End Region

#Region "Associate"

    Public Sub AssociateFiles()
        Dim extension As String = "egm"
        'Ensure the extension has a leading dot
        If Not extension.StartsWith(".") Then extension = "." & extension
        Dim fileTypeName As String = extension.Substring(1, extension.Length - 1)

        My.Computer.Registry.ClassesRoot.CreateSubKey(extension) _
            .SetValue("", fileTypeName, Microsoft.Win32.RegistryValueKind.String)
        My.Computer.Registry.ClassesRoot.CreateSubKey(fileTypeName & "\shell\open\command") _
            .SetValue("", Application.StartupPath & "\Projects\" & EngineSetTitle & ".egm" & " ""%l"" ", Microsoft.Win32.RegistryValueKind.String)
    End Sub

#End Region

#Region "Menu Items"

    Private Sub HelpToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem1.Click
        Process.Start("https://egm.codeplex.com/documentation")
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        Try
            frmNewProject.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        frmFeedback.ShowDialog()
    End Sub

    Private Sub DocumentationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DocumentationToolStripMenuItem.Click
        Try
            Process.Start(Application.StartupPath & "\EGM Documentation.pdf")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GlobalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GlobalToolStripMenuItem.Click
        frmGlobalSettings.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If My.Settings.firsttime = True Then
            My.Settings.firsttime = False
            If IsDebugging = False Then
                'Compile and then process the game
                frmScrptWndw.SaveScripts()
                FirstTimeBuildWork()
                IsDebugging = True
                ToolStripMenuItem1.Enabled = False
                ToolStripMenuItem2.Enabled = True
                tmrDebugCheck.Start()
            Else
            End If
        Else
            If IsDebugging = False Then
                'Compile and then process the game
                frmScrptWndw.SaveScripts()
                BeginBuildWork()
                IsDebugging = True
                ToolStripMenuItem1.Enabled = False
                ToolStripMenuItem2.Enabled = True
                tmrDebugCheck.Start()
            Else
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        'stop debugging the game
        If IsDebugging = True Then
            Try
                For Each p As Process In System.Diagnostics.Process.GetProcessesByName(EngineSetTitle)
                    p.Kill()
                    p.WaitForExit()
                    'now del the file
                    'My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\" & EngineSetTitle & ".exe")
                Next
                ToolStripMenuItem1.Enabled = True
                IsDebugging = False
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        'Exit the application 
        End
    End Sub

    Private Sub SpriteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpriteToolStripMenuItem.Click
        If SpriteCount = 0 Then
            Dim SpriteWndw As New frmAddSprite
            'SpriteWndw.MdiParent = Me
            SpriteWndw.Show()
            'TODO update the titles of the nodes
            TreeView1.Nodes.Add("SprName", "SprName", 0, 0)
            SpriteCount = 1
        Else
            'do nothing, it's open 
        End If
        'create new sprite window 

    End Sub

    Private Sub ScriptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScriptToolStripMenuItem.Click
        If ScriptCount = 0 Then
            'Open the script window 
            Dim ScrptWndw As New frmScrptWndw
            ' ScrptWndw.MdiParent = Me
            ScrptWndw.Show()
            TreeView1.Nodes(0).Nodes.Add("Script1")
            TreeView1.ExpandAll()
            ScriptCount = 1
        Else
            'do nothing its already open
        End If

    End Sub

    Private Sub AboutEGMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutEGMToolStripMenuItem.Click
        MsgBox("EGM - Explosive Game Maker was developed by Creative Programming © 2013 and is a Game Engine focused on the creation of 2D video Games entirely free!" & _
               vbNewLine & vbNewLine & "Updated by Author & CodePlex community.", MsgBoxStyle.Information)
    End Sub


    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        'Save
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        'save as
        SaveFileDialog1.FileName = EngineSetTitle
        SaveFileDialog1.InitialDirectory = Application.StartupPath & "\Projects\"
        SaveFileDialog1.ShowDialog()
    End Sub

    Private Sub ScriptsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScriptsToolStripMenuItem.Click
        Dim w As New frmScrptWndw
        If File.Exists(Application.StartupPath & "\Projects\" & EngineSetTitle & ".egms1") Then w.rtbScript.Text = File.ReadAllText(Application.StartupPath & "\Projects\" & EngineSetTitle & ".egms1")
        If File.Exists(Application.StartupPath & "\Projects\" & EngineSetTitle & ".egms2") Then w.rtbScript2.Text = File.ReadAllText(Application.StartupPath & "\Projects\" & EngineSetTitle & ".egms2")
        w.ShowDialog()
    End Sub

#End Region

#Region "Build/Debug"

    Public Sub CheckDirectorys()
        'This routine is used to check if the core folders are existing or not, this is critical
        If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\Projects\") = False Then
            My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\Projects\")
        End If
        If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\Published\") = False Then
            My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\Published\")
        End If
        If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\Samples\") = False Then
            My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\Samples\")
        End If
    End Sub

    Public Sub BuildCore()
        'Build all split files into one string

        Dim Startupmode1 As String = ""
        Dim startupmode2 As String = ""
        If Startmode = 0 Then
            'windowed 
            Startupmode1 = ""
            startupmode2 = ""
        ElseIf Startmode = 1 Then
            'Full screen 
            Startupmode1 = "Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None"
            startupmode2 = "Me.WindowState = FormWindowState.Maximized"
        End If
        Dim fullicon As String = "Dim Ico As New System.Drawing.Icon(""" & My.Settings.gamesicon & """)" & vbNewLine & "Me.Icon = Ico"
        Dim ReadFile As String
        ReadFile = My.Resources.EGMCore1
        Dim ReadFile2 As String
        ReadFile2 = My.Resources.EGMCore2
        Dim ReadFile3 As String
        ReadFile3 = My.Resources.EGMCore3
        Dim ReadFile4 As String
        ReadFile4 = My.Resources.EGMCore4
        Dim ReadFile5 As String
        ReadFile5 = My.Resources.EGMCore5
        Dim DefBcolor As String = My.Settings.defaultback
        Dim ColorString As String = "Me.BackColor = System.Drawing.Color." & DefBcolor
        CoreText = ReadFile & EngineSetTitle & ReadFile2 & ColorString & vbCrLf & Startupmode1 & vbCrLf & startupmode2 & vbNewLine & ScriptText & vbCrLf & ReadFile4 & vbCrLf & "Public WindowText As String = """ & EngineSetTitle & """" & vbCrLf & ReadFile3 & vbCrLf & ScriptText2 & vbNewLine & ReadFile5

    End Sub
    Public Sub FirstTimeCore()
        'Build all split files into one string

        Dim Startupmode1 As String = ""
        Dim startupmode2 As String = ""
        If Startmode = 0 Then
            'windowed 
            Startupmode1 = ""
            startupmode2 = ""
        ElseIf Startmode = 1 Then
            'Full screen 
            Startupmode1 = "Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None"
            startupmode2 = "Me.WindowState = FormWindowState.Maximized"
        End If
        Dim fullicon As String = "Dim Ico As New System.Drawing.Icon(""" & Application.StartupPath & "\" & My.Settings.gamesicon & """)" & vbNewLine & "Me.Icon = Ico"
        Dim ReadFile As String
        ReadFile = My.Resources.EGMCore1
        Dim ReadFile2 As String
        ReadFile2 = My.Resources.EGMCore2
        Dim ReadFile3 As String
        ReadFile3 = My.Resources.EGMCore3
        Dim ReadFile4 As String
        ReadFile4 = My.Resources.EGMCore4
        Dim ReadFile5 As String
        ReadFile5 = My.Resources.EGMCore5
        Dim DefBcolor As String = My.Settings.defaultback
        Dim ColorString As String = "Me.BackColor = System.Drawing.Color." & DefBcolor
        CoreText = ReadFile & EngineSetTitle & ReadFile2 & ColorString & vbCrLf & Startupmode1 & vbCrLf & startupmode2 & vbNewLine & ScriptText & vbCrLf & ReadFile4 & vbCrLf & "Public WindowText As String = """ & EngineSetTitle & """" & vbCrLf & ReadFile3 & vbCrLf & ScriptText2 & vbNewLine & ReadFile5

    End Sub

    Public Sub BeginBuildWork()
        Try
            FirstTimeCore()
            ' frmOutputTesting.txtOutput.Text = CoreText
            ' frmOutputTesting.ShowDialog()
            CompileGame(CoreText, EngineSetTitle)
        Catch ex As Exception

        End Try

    End Sub

    Public Sub FirstTimeBuildWork()
        Try
            BuildCore()
            ' frmOutputTesting.txtOutput.Text = CoreText
            ' frmOutputTesting.ShowDialog()
            CompileGame(CoreText, EngineSetTitle)
        Catch ex As Exception

        End Try

    End Sub

    Public Sub BeginMainBuildWork()
        BuildCore()
        BuildGame(CoreText, EngineSetTitle)
    End Sub

    Private Function CreateCompiler() As CodeDomProvider
        Return New VBCodeProvider()
    End Function

    Public Sub BuildGame(ByVal ToCompile As String, ByVal Title As String)

        Try
            Dim objCompilerParameters As New System.CodeDom.Compiler.CompilerParameters()
            ' Add reference
            objCompilerParameters.ReferencedAssemblies.Add("System.dll")
            objCompilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll")
            objCompilerParameters.ReferencedAssemblies.Add("Microsoft.VisualBasic.dll")
            objCompilerParameters.ReferencedAssemblies.Add("System.Drawing.dll")

            'Compile in memory
            Dim Output1 As String = Title
            objCompilerParameters.GenerateExecutable = True
            objCompilerParameters.OutputAssembly = Output1
            objCompilerParameters.CompilerOptions = "/target:winexe"
            ' objCompilerParameters.CompilerOptions = "/win32icon:" & My.Settings.gamesicon

            Dim strCode As String = ToCompile
            Dim objCompileResults As System.CodeDom.Compiler.CompilerResults = _
            CreateCompiler.CompileAssemblyFromSource(objCompilerParameters, strCode)
            If objCompileResults.Errors.HasErrors Then
                ' If an error occurs
                MsgBox("Error: Line>" & objCompileResults.Errors(0).Line - 45 & ", " & objCompileResults.Errors(0).ErrorText)
                'frmScrptWndw.rtbScript.Lines(objCompileResults.Errors(0).Line - 45)
                ToolStripMenuItem1.Enabled = True
                Exit Sub
            End If
        Catch ex As Exception

        Finally
        End Try
    End Sub
    Private err As TextStyle = New TextStyle(Brushes.Red, Nothing, FontStyle.Regular)
    Public Sub CompileGame(ByVal ToCompile As String, ByVal Title As String)

        Try
            Dim objCompilerParameters As New System.CodeDom.Compiler.CompilerParameters()
            ' Add reference
            objCompilerParameters.ReferencedAssemblies.Add("System.dll")
            objCompilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll")
            objCompilerParameters.ReferencedAssemblies.Add("Microsoft.VisualBasic.dll")
            objCompilerParameters.ReferencedAssemblies.Add("System.Drawing.dll")

            'Compile in memory
            Dim Output1 As String = Title
            objCompilerParameters.GenerateExecutable = True
            objCompilerParameters.OutputAssembly = Output1
            objCompilerParameters.CompilerOptions = "/target:winexe"
            'objCompilerParameters.CompilerOptions = "/win32icon:" & My.Settings.gamesicon

            Dim strCode As String = ToCompile
            Dim objCompileResults As System.CodeDom.Compiler.CompilerResults = _
            CreateCompiler.CompileAssemblyFromSource(objCompilerParameters, strCode)
            If objCompileResults.Errors.HasErrors Then
                ' If an error occurs
                
                Dim msg As String = ""
                For i As Integer = 0 To objCompileResults.Errors.Count - 1
                    msg = msg & "Error: Line>" & objCompileResults.Errors(i).Line - 45 & ", " & objCompileResults.Errors(i).ErrorText & vbNewLine
                    'frmScrptWndw.rtbScript.Se()
                    'Dim Text As String = frmScrptWndw.rtbScript.Lines(objCompileResults.Errors(i).Line - 45)
                    'frmScrptWndw.rtbScript(objCompileResults.Errors(i).Line - 46).BackgroundBrush = Brushes.MediumVioletRed
                Next
                MsgBox(msg)
                'MsgBox("Error: Line>" & objCompileResults.Errors(0).Line - 45 & ", " & _
                'objCompileResults.Errors(0).ErrorText)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Try
                Process.Start(Application.StartupPath & "\" & EngineSetTitle & ".exe")
            Catch ex As Exception

            End Try

        End Try
    End Sub


#End Region

#Region "Dialogs"

    Private Sub LevelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LevelToolStripMenuItem.Click
        If HasBeenShown = False Then
            frmRoom.MdiParent = Me
            frmRoom.Show()
            HasBeenShown = True
        Else

        End If
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        'load the file
        Dim ReadFile As New System.IO.StreamReader(OpenFileDialog1.FileName)
        Dim AllLines As List(Of String) = New List(Of String)
        Do While Not ReadFile.EndOfStream
            AllLines.Add(ReadFile.ReadLine())
        Loop
        ReadFile.Close()
        EngineSetTitle = ReadLine(1, AllLines)
        Startmode = ReadLine(2, AllLines)
        RCol = ReadLine(3, AllLines)
        GCol = ReadLine(4, AllLines)
        BCol = ReadLine(5, AllLines)
        BasicLoadEvents()
    End Sub

    Public Function ReadLine(lineNumber As Integer, lines As List(Of String)) As String
        Try
            Return lines(lineNumber - 1)
        Catch ex As Exception
        End Try
        Return Nothing
    End Function

    Private Sub BuildGameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuildGameToolStripMenuItem.Click
        BeginMainBuildWork()
        Try
            My.Computer.FileSystem.MoveFile(Application.StartupPath & "\" & EngineSetTitle & ".exe", Application.StartupPath & "\Published\" & EngineSetTitle & ".exe", True)
            Process.Start(Application.StartupPath & "\Published\")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        'save the file
        Dim BuildFileText As String = EngineSetTitle & vbCrLf & Startmode & vbCrLf & RCol & vbCrLf & GCol & vbCrLf & BCol & vbCrLf
        My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, BuildFileText, True)
        If My.Settings.Recent1 = "" Then
            My.Settings.Recent1 = SaveFileDialog1.FileName
        ElseIf My.Settings.Recent2 = "" Then
            My.Settings.Recent2 = SaveFileDialog1.FileName
        ElseIf My.Settings.Recent3 = "" Then
            My.Settings.Recent3 = SaveFileDialog1.FileName
        ElseIf My.Settings.Recent4 = "" Then
            My.Settings.Recent4 = SaveFileDialog1.FileName
        ElseIf My.Settings.Recent5 = "" Then
            My.Settings.Recent5 = SaveFileDialog1.FileName
        ElseIf My.Settings.Recent6 = "" Then
            My.Settings.Recent6 = SaveFileDialog1.FileName
        ElseIf My.Settings.Recent7 = "" Then
            My.Settings.Recent7 = SaveFileDialog1.FileName
        ElseIf My.Settings.Recent8 = "" Then
            My.Settings.Recent8 = SaveFileDialog1.FileName
        End If
        My.Settings.Save()
        'AssociateFiles()
    End Sub

#End Region

#Region "Misc Events"

    Private Sub trmDebugCheck_Tick(sender As Object, e As EventArgs) Handles tmrDebugCheck.Tick
        Dim isRunning As Boolean = False
        For Each p As Process In System.Diagnostics.Process.GetProcessesByName(EngineSetTitle)
            isRunning = True
        Next
        If isRunning = False Then
            IsDebugging = False
            ToolStripMenuItem1.Enabled = True
            ToolStripMenuItem2.Enabled = False
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\" & EngineSetTitle & ".exe") Then My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\" & EngineSetTitle & ".exe")
            tmrDebugCheck.Stop()
        End If
    End Sub

#End Region

#Region "Needs repairing/changing"



#End Region

#Region "Testing"

    'Public xCharacter As System.Drawing.Bitmap = System.Drawing.Image.FromFile("")
    ' Public Function DrawControlField()
    'Dim Field As New PictureBox
    '  Field.Dock = DockStyle.Fill
    '  Field.BorderStyle = BorderStyle.None
    '  Field.BackColor = Me.BackColor
    '  Me.Controls.Add(Field)
    '  Return Nothing
    ' End Function

#End Region

#Region "Updater"

    Public Sub UpdateEngine()
        Try
            Dim MyAppName As String = "Explosive Game Maker.exe"
            Dim url As String = "http://creativeprogramming.info/EGM/" & "FileUpdates371.php"
            Dim pageRequest As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            Dim pageResponse As WebResponse = pageRequest.GetResponse()
            Dim filelist As String : Dim Mainlist As String
            Using r As New StreamReader(pageResponse.GetResponseStream())
                filelist = r.ReadToEnd
                If Not IO.File.Exists(Application.StartupPath & "\" & "Updates") Then
                    IO.File.WriteAllText(Application.StartupPath & "\" & "Updates", filelist)
                End If
                Dim sr As New StreamReader(Application.StartupPath & "\" & "Updates")
                Mainlist = sr.ReadToEnd
                Dim FileLines() As String = filelist.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                Dim MainLines() As String = Mainlist.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                If Not Mainlist = filelist And Not FileLines.Length < MainLines.Length Then
                    AlreadyLatestToolStripMenuItem.Visible = False
                    Dim answer As DialogResult
                    answer = MessageBox.Show("Updates are available. Would you like to update now?", "Software Updates", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If answer = vbYes Then
                        Dim App As New Process
                        App.StartInfo.FileName = Application.StartupPath & "\" & "InfinityBlue.exe"
                        App.StartInfo.Arguments = "Update|" & MyAppName & "|" & url
                        App.Start()
                        Me.Close()
                    End If
                Else
                    AlreadyLatestToolStripMenuItem.Visible = True
                    'MsgBox("You have the lates version available.", MsgBoxStyle.Information)
                End If
            End Using
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\" & "InfinityBlueUpdate.exe") Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\" & "InfinityBlue.exe", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                My.Computer.FileSystem.RenameFile(Application.StartupPath & "\" & "InfinityBlueUpdate.exe", "InfinityBlue.exe")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CheckForUpdatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckForUpdatesToolStripMenuItem.Click
        'Experimental update. Using try catch for result
        Dim upd As Thread
        Try
            upd = New Thread(AddressOf UpdateEngine)
            upd.IsBackground = True
            upd.Start()
        Catch ex As Exception
            If upd IsNot Nothing Then upd.Join()
            UpdateEngine()
        End Try

        'UpdateEngine()
    End Sub

#End Region


End Class
