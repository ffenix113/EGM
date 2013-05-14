Public Class frmTips

    Public CurrentTip As Integer
    Public Tip0 As String = "Did you know you can create your own scripts? This feature is for advanced users but can be useful for more advanced functions in your game. GO to Create > Script. More information on the EGM Language can be found in the help documents."
    Public Tip1 As String = "This is the second tip and is reserved for when it is needed"
    Public Tip2 As String = "This is the third tip and is reserved for when it is needed"
    Public Tip3 As String = "This is the fourth tip and is reserved for when it is needed"
    Public Tip4 As String = "This is the fifth tip and is reserved for when it is needed"
    Public Tip5 As String = "This is the sixth tip and is reserved for when it is needed"

    Private Sub frmTips_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.ShowTips = True Then
            chkStartup.Checked = True
        Else
            chkStartup.Checked = False
        End If
        'Show a random tip 
        Randomize()
        CurrentTip = 5 * Rnd()
        ShowTip(CurrentTip)
    End Sub

    Private Sub chkStartup_CheckedChanged(sender As Object, e As EventArgs) Handles chkStartup.CheckedChanged
        If chkStartup.Checked = True Then
            My.Settings.ShowTips = True
        Else
            My.Settings.ShowTips = False
        End If
        My.Settings.Save()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        frmNewProject.ShowDialog()
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
End Class