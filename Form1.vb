Public Class MinesWordForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim TryFelix As New Felix
        MsgBox(TryFelix.Print() & TryFelix.PrintNa)
        My.Computer.Audio.Play("C:\dw.wav", AudioPlayMode.BackgroundLoop)
    End Sub
End Class
