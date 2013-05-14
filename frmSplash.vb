Public NotInheritable Class frmSplash

   
    Private Sub frmSplash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Color.FromArgb(28, 117, 188)
    End Sub

    Private Sub tmrErrorClose_Tick(sender As Object, e As EventArgs) Handles tmrErrorClose.Tick
        Try
            Me.Close()
        Catch ex As Exception

        End Try

    End Sub
End Class
