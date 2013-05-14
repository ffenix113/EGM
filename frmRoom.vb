Public Class frmRoom

    Private Sub frmRoom_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frmEngine.HasBeenShown = False
    End Sub

    Private Sub frmRoom_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        Dim pctr As New PictureBox
        pctr.BackgroundImage = Image.FromFile(Application.StartupPath & "\Projects\Resources\block2.png")
        pctr.Size = New Size(frmAddSprite.ptrbxSpriteView.Width, frmAddSprite.ptrbxSpriteView.Height)
        pctr.Location = New Point(e.X, e.Y)
        pctr.BackgroundImageLayout = ImageLayout.Zoom
        Me.Controls.Add(pctr)
    End Sub
End Class