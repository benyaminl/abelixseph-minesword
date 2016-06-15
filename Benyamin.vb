Public Class Benyamin
    '------------ Bagian Staging ------------------
    'Variable Button stage
    Friend StageButton(5) As Button, SBImage(4) As Image
    Sub StageButtonShow()
        SBImage(1) = My.Resources.stage1
        SBImage(2) = My.Resources.stage2
        SBImage(3) = My.Resources.stage3
        SBImage(4) = My.Resources.stage4
        If StageButton(1) IsNot Nothing Then
            For Each S In StageButton
                S.Dispose()
                S = Nothing
            Next
        End If
        For i As Integer = 1 To 4
            StageButton(i) = New Button
            StageButton(i).FlatStyle = FlatStyle.Flat
            StageButton(i).BackgroundImage = SBImage(i)
            StageButton(i).BackgroundImageLayout = ImageLayout.Stretch
            StageButton(i).FlatAppearance.BorderSize = 0
            'Hilangkan Warna Putih Transparent, kalau dair dokumentasi itu katanya dia di paint
            StageButton(i).BackColor = Color.Transparent
            StageButton(i).FlatAppearance.MouseOverBackColor = Color.Transparent
            StageButton(i).FlatAppearance.MouseDownBackColor = Color.Transparent
            StageButton(i).Width = 130
            StageButton(i).Height = 340
            StageButton(i).Top = 20
            StageButton(i).Left = (130 * (i - 1)) + (23 * i)
            AddHandler StageButton(i).MouseEnter, AddressOf PerbesarButtonStage
            AddHandler StageButton(i).MouseLeave, AddressOf PerkecilButtonStage
            StageButton(i).Parent = MinesWordForm
        Next
        Dim ButtonBack As Button = StageButton(5)
        ButtonBack = New Button
        ButtonBack.BackgroundImage = My.Resources.stageback
        ButtonBack.BackgroundImageLayout = ImageLayout.Stretch
        ButtonBack.Size = New Size(60, 60)
        ButtonBack.FlatStyle = FlatStyle.Flat
        ButtonBack.FlatAppearance.BorderSize = 0
        ButtonBack.BackColor = Color.Transparent
        ButtonBack.FlatAppearance.MouseOverBackColor = Color.Transparent
        ButtonBack.FlatAppearance.MouseDownBackColor = Color.Transparent
        ButtonBack.Location = New Point(MinesWordForm.Width - 100, MinesWordForm.Height - 120)
        ButtonBack.Parent = MinesWordForm
        AddHandler ButtonBack.MouseEnter, AddressOf PerbesarButtonStage
        AddHandler ButtonBack.MouseLeave, AddressOf PerkecilButtonStage
        'Seperti di Gambar, backgroundnya hitam
        MinesWordForm.BackgroundImage = My.Resources.bg2
        MinesWordForm.BackgroundImageLayout = ImageLayout.Stretch
    End Sub

    '--Untuk Ketika Hover Button
    Sub PerbesarButtonStage(butt As Button, e As EventArgs)
        butt.Width += 20 : butt.Left -= 10
        butt.Height += 20 : butt.Top -= 10
    End Sub

    Sub PerkecilButtonStage(butt As Button, e As EventArgs)
        butt.Width -= 20 : butt.Left += 10
        butt.Height -= 20 : butt.Top += 10
    End Sub
    '--Untuk Ketika Hover Button

    '------------ Bagian Staging ------------------
End Class
