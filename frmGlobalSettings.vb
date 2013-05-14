Imports System.Windows.Forms

Public Class frmGlobalSettings

    
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If ComboBox1.Text = "Windowed" Then
            frmEngine.Startmode = 0
        ElseIf ComboBox1.Text = "Full Screen" Then
            frmEngine.Startmode = 1
        End If
        frmEngine.EngineSetTitle = txtTitle.Text
        frmEngine.BasicLoadEvents()
        My.Settings.CompilerLanguage = ComboBox2.Text
        My.Settings.Save()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmGlobalSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            pctrCurrentIcon.Image = Image.FromFile(My.Settings.gamesicon)
        Catch ex As Exception

        End Try
        ComboBox2.Text = My.Settings.CompilerLanguage
        txtTitle.Text = frmEngine.EngineSetTitle
        If My.Settings.ShowTips = True Then
            chkbxTips.Checked = True
        Else
            chkbxTips.Checked = False
        End If
        lblDefaultColor.Text = "Default Backcolor:  " & My.Settings.defaultback
    End Sub

    Private Sub chkbxTips_CheckedChanged(sender As Object, e As EventArgs) Handles chkbxTips.CheckedChanged
        If chkbxTips.Checked = True Then
            My.Settings.ShowTips = True
        Else
            My.Settings.ShowTips = False
        End If
        My.Settings.Save()
    End Sub

    Private Sub btnColorChange_Click(sender As Object, e As EventArgs) Handles btnColorChange.Click
        ColorChooser.ShowDialog()
        Dim Chosen As String = ColorChooser.Chosen
        My.Settings.defaultback = Chosen
        My.Settings.Save()
        lblDefaultColor.Text = "Default Backcolor:  " & Chosen
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'change the icon used in our game
        OpenFileDialog1.ShowDialog()
       

    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        My.Settings.gamesicon = OpenFileDialog1.FileName
        My.Settings.Save()
        Try
            pctrCurrentIcon.Image = Image.FromFile(My.Settings.gamesicon)
        Catch ex As Exception

        End Try
    End Sub
End Class
