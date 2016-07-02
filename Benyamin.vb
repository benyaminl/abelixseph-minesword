'-- Used for Embed Font
Imports System.Drawing.Text
Imports System.Runtime.InteropServices
'-- Used for Embed Font

Public Class Benyamin
    ' ---- 
    '   Jangan Hanya berhenti di level programmer!
    '                           - Suhatati Tjandra 
    ' ---- 

    '-- Clear Control, kita main Clear Control supaya bisa Dynamics di VBnya

    Sub clearControl()
        MinesWordForm.Controls.Clear()
    End Sub

    '-- embed Font - Based on http://zerosandtheone.com/blogs/vb/archive/2009/11/20/vb-net-include-a-font-as-an-embedded-resource-in-your-application.aspx
    '-- Thanks for the Author
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
            StageButton(i).Left = (130 * (i - 1)) + (23 * i) '-- 23*i agak jarak terakumulasi
            AddHandler StageButton(i).MouseEnter, AddressOf PerbesarButtonStage
            AddHandler StageButton(i).MouseLeave, AddressOf PerkecilButtonStage
            StageButton(i).Parent = MinesWordForm
            '-- For test Case
            If i = 1 Then
                AddHandler StageButton(i).Click, AddressOf gameUI
            End If
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
        AddHandler ButtonBack.Click, AddressOf clearControl
        StageButton(5) = ButtonBack
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

    '------------ Bagian Game UI ------------------
    Friend GameBoard(,) As Button, StatusPanelText(3) As Label
    '-- untuk tampilkan UI Game
    Sub gameUI()
        '-- Clear Whole Control before adding the gameUI
        Call clearControl()
        '-- End of it
        '--- Panel Kanan
        ReDim GameBoard(10, 10)
        Dim BoardPanel As New Panel
        BoardPanel.Location = New Point(MinesWordForm.Width - 450, 25)
        BoardPanel.Size = New Size(425, 430)
        BoardPanel.BackColor = Color.Transparent
        BoardPanel.BackgroundImage = My.Resources.BoardBack
        BoardPanel.BackgroundImageLayout = ImageLayout.Stretch
        BoardPanel.Parent = MinesWordForm
        For i As Integer = 1 To 10
            For j As Integer = 1 To 10
                Dim GB As Button = GameBoard(i, j), x As Integer, y As Integer
                GB = New Button
                GB.Size = New Size(40, 40)
                x = 40 * (i - 1) + 12
                y = 40 * (j - 1) + 15
                GB.Location = New Point(x, y)
                GB.Text = i & "," & j
                GB.Parent = BoardPanel
                GB.FlatStyle = FlatStyle.Flat
                GB.BackgroundImage = My.Resources.button
                GB.BackgroundImageLayout = ImageLayout.Stretch
                GB.FlatAppearance.BorderSize = 0
                'Hilangkan Warna Putih Transparent, kalau dair dokumentasi itu katanya dia di paint
                GB.BackColor = Color.Black
                GB.FlatAppearance.MouseOverBackColor = Color.Yellow
                GB.FlatAppearance.MouseDownBackColor = Color.Transparent
            Next
        Next
        '--- Panel Kiri
        Dim StatusPanel As New Panel
        StatusPanel.Location = New Point(15, 25)
        StatusPanel.Size = New Size(170, 425)
        StatusPanel.BackColor = Color.Transparent
        StatusPanel.BackgroundImage = My.Resources.statusback
        StatusPanel.BackgroundImageLayout = ImageLayout.Stretch
        StatusPanel.Parent = MinesWordForm
        Dim LayerAtas(3) As Panel
        '-- Conf Font 
        '-- Skor
        Dim LA As Panel, LAText As New Label
        LA = New Panel
        LA.BackColor = Color.Transparent
        LA.Size = New Size(140, 40)
        LA.Location = New Point(15, 25)
        LayerAtas(1) = LA
        LAText.Text = "Skor : " & vbTab & " 0"
        StatusPanelText(1) = LAText
        '-- List Kata
        Dim LK As Panel, LKText As New Label
        LK = New Panel
        LK.BackColor = Color.Transparent
        LK.Size = New Size(140, 200)
        LK.Location = New Point(15, 80)
        LayerAtas(2) = LK
        LKText.Text = "Soal"
        StatusPanelText(2) = LKText
        '-- Huruf terkumpul
        Dim HT As Panel, HTText As New Label
        HT = New Panel
        HT.BackColor = Color.Transparent
        HT.Size = New Size(140, 40)
        HT.Location = New Point(15, 300)
        LayerAtas(3) = HT
        HTText.Text = "Kata Terkumpul"
        StatusPanelText(3) = HTText
        '-- Susun Huruf
        '----- Still Pending anyway
        For i As Integer = 1 To 3
            LayerAtas(i).BackgroundImage = My.Resources.paneltextback
            LayerAtas(i).BackgroundImageLayout = ImageLayout.Stretch
            LayerAtas(i).Parent = StatusPanel
            StatusPanelText(i).Location = New Point(5, 5)
            '-- This's the main Key, kalau ga Paint Formnya ga jalan Btw
            StatusPanelText(i).UseCompatibleTextRendering = True
            StatusPanelText(i).Font = CustomFont.GetInstance(15, FontStyle.Regular)
            StatusPanelText(i).ForeColor = Color.White
            StatusPanelText(i).BackColor = Color.SandyBrown
            StatusPanelText(i).Width = 130
            StatusPanelText(i).Height = 30
            StatusPanelText(i).Parent = LayerAtas(i)
        Next
    End Sub
    '------------ Bagian Game UI ------------------
End Class