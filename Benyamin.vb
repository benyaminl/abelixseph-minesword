Public Class Benyamin
    Friend StageButton(4) As Button
    Sub Stage()
        If StageButton IsNot Nothing Then

        End If
        For i As Integer = 1 To 4
            StageButton(i) = New Button
            StageButton(i).Width = 200
            StageButton(i).Height = 200
        Next
    End Sub
End Class
