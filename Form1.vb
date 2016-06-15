Public Class MinesWordForm
    Dim Ben As New Benyamin 'Importing Class Benyamin, from Benyamin Limanto
    Private Sub MinesWordForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Reducing Flicker because of button animation
        Me.DoubleBuffered = True
        Ben.StageButtonShow()
    End Sub
End Class
