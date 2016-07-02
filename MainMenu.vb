Public Class MainMenu
    Dim Ben As New Benyamin
    Sub clearControl()
        MinesWordForm.Controls.Clear()
        Ben.StageButtonShow()
    End Sub

    Friend mainbutton(4) As Button
    Friend buttonimage(3) As Image
    Sub Mainmenupage()
        buttonimage(1) = My.Resources.MM_Button
        buttonimage(2) = My.Resources.MM_Button
        buttonimage(3) = My.Resources.MM_Button



        If mainbutton(1) IsNot Nothing Then
            For Each z In mainbutton
                z.Dispose()
                z = Nothing
            Next
        End If
        For i As Integer = 1 To 3
            mainbutton(i) = New Button
            mainbutton(i).FlatStyle = FlatStyle.Flat
            mainbutton(i).BackgroundImage = buttonimage(i)
            mainbutton(i).BackgroundImageLayout = ImageLayout.Stretch
            mainbutton(i).FlatAppearance.BorderSize = 0
            mainbutton(i).BackColor = Color.Transparent
            mainbutton(i).FlatAppearance.MouseOverBackColor = Color.Transparent
            mainbutton(i).FlatAppearance.MouseDownBackColor = Color.Transparent
            mainbutton(i).Width = 250
            mainbutton(i).Height = 150
            mainbutton(i).Top = (80 * (i - 1)) + (60 * i) - 30
            mainbutton(i).Left = 200
            mainbutton(i).Anchor = AnchorStyles.Top

            AddHandler mainbutton(i).MouseEnter, AddressOf PerbesarButtonmain
            AddHandler mainbutton(i).MouseLeave, AddressOf PerkecilButtonMain
            AddHandler mainbutton(i).Click, AddressOf clearControl
            mainbutton(i).Parent = MinesWordForm
        Next

        Dim AboutUS As Button
        AboutUS = New Button
        AboutUS.BackgroundImage = My.Resources.Mail
        AboutUS.BackgroundImageLayout = ImageLayout.Stretch
        AboutUS.Size = New Size(100, 100)
        AboutUS.FlatStyle = FlatStyle.Flat
        AboutUS.FlatAppearance.BorderSize = 0
        AboutUS.BackColor = Color.Transparent
        AboutUS.FlatAppearance.MouseOverBackColor = Color.Transparent
        AboutUS.FlatAppearance.MouseDownBackColor = Color.Transparent
        AboutUS.Location = New Point(10, 380)
        AboutUS.Parent = MinesWordForm

        AddHandler AboutUS.MouseEnter, AddressOf PerbesarButtonmain
        AddHandler AboutUS.MouseLeave, AddressOf PerkecilButtonMain
        AddHandler AboutUS.Click, AddressOf ShowAboutUS
        mainbutton(4) = AboutUS

        MinesWordForm.BackgroundImage = My.Resources.BG
        MinesWordForm.BackgroundImageLayout = ImageLayout.Stretch
    End Sub
    Sub PerbesarButtonmain(butt As Button, e As EventArgs)
        butt.Width += 20 : butt.Left -= 10
        butt.Height += 20 : butt.Top -= 10
    End Sub

    Sub PerkecilButtonMain(butt As Button, e As EventArgs)
        butt.Width -= 20 : butt.Left += 10
        butt.Height -= 20 : butt.Top += 10
    End Sub

    Async Sub ShowAboutUS(butt As Button, e As EventArgs)
        Dim a As Integer
        butt.Top = 0
        For i As Integer = 1 To 3
            mainbutton(i).Dispose()
        Next

        Do

            butt.Width += 58
            butt.Height += 58
            a += 1
            Await Task.Delay(50)

        Loop Until a = 8
        mainbutton(4).Dispose()
        Dim usbutton As Button
        usbutton = New Button

        usbutton.FlatStyle = FlatStyle.Flat
        usbutton.BackgroundImage = My.Resources.PESAN
        usbutton.BackgroundImageLayout = ImageLayout.Stretch
        usbutton.Size = New Size(500, 320)
        usbutton.FlatAppearance.BorderSize = 0
        usbutton.BackColor = Color.Transparent
        usbutton.FlatAppearance.MouseOverBackColor = Color.Transparent
        usbutton.FlatAppearance.MouseDownBackColor = Color.Transparent
        usbutton.Location = New Point(50, 50)


        Dim exitbutton As Button
        exitbutton = New Button
        exitbutton.FlatStyle = FlatStyle.Flat
        exitbutton.BackgroundImage = My.Resources.EXITBUTTON
        exitbutton.BackgroundImageLayout = ImageLayout.Stretch
        exitbutton.Size = New Size(60, 60)
        exitbutton.FlatAppearance.BorderSize = 0
        exitbutton.BackColor = Color.Transparent
        exitbutton.FlatAppearance.MouseOverBackColor = Color.Transparent
        exitbutton.FlatAppearance.MouseDownBackColor = Color.Transparent
        exitbutton.Top = 20
        exitbutton.Left = 520
        exitbutton.Parent = MinesWordForm
        AddHandler exitbutton.MouseEnter, AddressOf PerbesarButtonmain
        AddHandler exitbutton.MouseLeave, AddressOf PerkecilButtonMain
        usbutton.Parent = MinesWordForm
    End Sub
End Class
