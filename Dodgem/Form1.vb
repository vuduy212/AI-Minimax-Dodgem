
Public Class Form1
    Dim choose As Integer 'Xem quân cờ nào đang dc chọn
    Dim curr_l As Integer, curr_t As Integer 'Vị trí hiện tại của quân cờ
    Dim old_x As Integer, old_y As Integer
    Dim playing As Boolean = False 'Kiểm tra là có đang chơi hay ko
    Dim curr_black(1) As Integer 'Xem có bao nhiêu quân đen ra ngoài 
    Dim curr_red(1) As Integer 'xem co bao nhieu quan do ra ngoai
    Dim u As state 'bien trang thai hien tai cua ban co
    Dim find_path As NewState 'dung de tim duong di
    Dim current_state As Integer 'luu trang thai hien tai cua 4 quan co
    Dim isBPlaying As Boolean, red_first As Boolean
    Dim game_depth As Integer
    Dim black_score As Integer, red_score As Integer
    Private Sub BtExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub set_score()
        BlackScore.Text = black_score.ToString
        RedScore.Text = red_score.ToString
    End Sub
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        black1.Visible = False
        black2.Visible = False
        red1.Visible = False
        red2.Visible = False
        RedOut.Visible = False
        BlackOut.Visible = False
        hide_cell()
        set_score()

    End Sub
    Private Sub reset()

        'thiết lập các giá trị
        choose = 0
        black1.BackColor = Color.BurlyWood
        black2.BackColor = Color.BurlyWood
        playing = True
        isBPlaying = True
        current_state = 1489
        curr_black(0) = 1
        curr_black(1) = 4
        curr_red(0) = 8
        curr_red(1) = 9
        u = New state(1489, True, 0)
        find_path = New NewState
        RedOut.Visible = False
        BlackOut.Visible = False
        'thiết lập ban đầu cho quân đen 1
        black1.Top = 4
        black1.Left = 4
        black1.Enabled = True
        black1.Visible = True

        'thiết lập ban đầu cho quân đen 2
        black2.Top = 76
        black2.Left = 4
        black2.Enabled = True
        black2.Visible = True

        'thiết lập ban đầu cho quân đỏ 1
        red1.Top = 148
        red1.Left = 76
        red1.Enabled = True
        red1.Visible = True

        'thiết lập ban đầu cho quân đỏ 2
        red2.Top = 148
        red2.Left = 148
        red2.Enabled = True
        red2.Visible = True
    End Sub
    Private Sub btNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewGame.Click
        btnNewGame.Enabled = False
        'kiem tra xem co dang choi hay ko
        If playing Then
            If (MsgBox("Replay?", MsgBoxStyle.OkCancel, "Message") = MsgBoxResult.Ok) Then
                reset()
            End If
        Else
            reset()
        End If
        'kiem tra Red la nguoi choi truoc hay ko
        If rbtRed.Checked = True Then
            red_first = True
        Else : red_first = False
        End If
        'kiem tra do sau ma nguoi choi chon
        If btn4.Checked = True Then
            game_depth = 4
        ElseIf btn6.Checked = True Then
            game_depth = 6
        ElseIf btn8.Checked = True Then
            game_depth = 8
        ElseIf btn10.Checked = True Then
            game_depth = 10
        ElseIf btn12.Checked = True Then
            game_depth = 12
        End If
        'disable cac tuy chon
        rbtBlack.Enabled = False
        rbtRed.Enabled = False
        btn4.Enabled = False
        btn8.Enabled = False
        btn6.Enabled = False
        btn10.Enabled = False
        btn12.Enabled = False
        'neu red choi truoc
        If red_first = True Then
            'thiet lap trang thai
            isBPlaying = False
            'di chuyen quan do
            red_go()
            curr_red(0) = (u.value Mod 100) \ 10
            curr_red(1) = u.value Mod 10
            red1.Top = 4 + 72 * ((curr_red(0) - 1) \ 3)
            red1.Left = 4 + 72 * ((curr_red(0) - 1) Mod 3)
            red2.Top = 4 + 72 * ((curr_red(1) - 1) \ 3)
            red2.Left = 4 + 72 * ((curr_red(1) - 1) Mod 3)
            'phuc hoi trang thai
            black1.Enabled = True
            black2.Enabled = True
        End If
        isBPlaying = True
        hide_cell()
    End Sub

    Private Sub black1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles black1.MouseClick
        If isBPlaying = True Then
            hide_cell()
            choose = 1
            curr_l = black1.Left
            curr_t = black1.Top
            black1.BackColor = Color.DarkGoldenrod
            black2.BackColor = Color.BurlyWood
            show_path()
        End If
    End Sub

    Private Sub black2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles black2.MouseClick
        If isBPlaying = True Then
            hide_cell()
            choose = 2
            curr_l = black2.Left
            curr_t = black2.Top
            black2.BackColor = Color.DarkGoldenrod
            black1.BackColor = Color.BurlyWood
            show_path()
        End If
    End Sub

    Private Sub banco_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles banco.MouseDown
        If choose = 1 Then
            If ((e.X > black1.Left + 72) And (e.X < black1.Left + 144) And (e.Y < black1.Top + 72) And (e.Y > black1.Top)) Then
                black1.Left = black1.Left + 72
                current_state = current_state + 1000
                curr_black(0) = curr_black(0) + 1
                isBPlaying = False
            ElseIf ((e.Y > black1.Top + 72) And (e.Y < black1.Top + 144) And (e.X < black1.Left + 72) And (e.X > black1.Left)) Then
                black1.Top = black1.Top + 72
                current_state = current_state + 3000
                curr_black(0) = curr_black(0) + 3
                isBPlaying = False
            ElseIf ((e.Y < black1.Top) And (e.Y > black1.Top - 72) And (e.X < black1.Left + 72) And (e.X > black1.Left)) Then
                black1.Top = black1.Top - 72
                current_state = current_state - 3000
                curr_black(0) = curr_black(0) - 3
                isBPlaying = False
            End If
            black1.BackColor = Color.BurlyWood
            choose = 0
        ElseIf choose = 2 Then
            If ((e.X > black2.Left + 72) And (e.X < black2.Left + 144) And (e.Y < black2.Top + 72) And (e.Y > black2.Top)) Then
                black2.Left = black2.Left + 72
                current_state = current_state + 100
                curr_black(1) = curr_black(1) + 1
                isBPlaying = False
            ElseIf ((e.Y > black2.Top + 72) And (e.Y < black2.Top + 144) And (e.X < black2.Left + 72) And (e.X > black2.Left)) Then
                black2.Top = black2.Top + 72
                current_state = current_state + 300
                curr_black(1) = curr_black(1) + 3
                isBPlaying = False
            ElseIf ((e.Y < black2.Top) And (e.Y > black2.Top - 72) And (e.X < black2.Left + 72) And (e.X > black2.Left)) Then
                black2.Top = black2.Top - 72
                current_state = current_state - 300
                curr_black(1) = curr_black(1) - 3
                isBPlaying = False
            End If
            black2.BackColor = Color.BurlyWood
            choose = 0
        End If
        hide_cell()
        If (isBPlaying = False AndAlso playing = True) Then
            red_go()
            If (u.value < 0) Then
                MsgBox("Black win !", MsgBoxStyle.OkOnly, "Can't find the way")
                'tang diem cho quan den
                rbtRed.Checked = True
                black_score = black_score + 1
                set_score()
                btnNewGame.Enabled = True
                red1.Visible = False
                red2.Visible = False
                black1.Visible = False
                black2.Visible = False
                playing = False
            Else
                curr_red(0) = (u.value Mod 100) \ 10
                curr_red(1) = u.value Mod 10
                If (curr_red(0) = 0) Then
                    red1.Visible = False
                    red1.Enabled = False
                    RedOut.Visible = True
                Else
                    red1.Top = 4 + 72 * ((curr_red(0) - 1) \ 3)
                    red1.Left = 4 + 72 * ((curr_red(0) - 1) Mod 3)
                End If
                If (curr_red(1) = 0) Then
                    red2.Enabled = False
                    red2.Visible = False
                    RedOut.Visible = True
                Else
                    red2.Top = 4 + 72 * ((curr_red(1) - 1) \ 3)
                    red2.Left = 4 + 72 * ((curr_red(1) - 1) Mod 3)
                End If
                If (curr_red(0) = 0 AndAlso curr_red(1) = 0) Then
                    MsgBox("Red win !", MsgBoxStyle.OkOnly, "Win")
                    'tang diem cho quan do
                    rbtBlack.Checked = True
                    red_score = red_score + 1
                    set_score()
                    btnNewGame.Enabled = True
                    black1.Visible = False
                    black2.Visible = False
                    playing = False
                Else
                    u.isBPlaying = True
                    u.depth = 0
                    u.current_state = curr_black(0) * 1000 + curr_black(1) * 100 + curr_red(0) * 10 + curr_red(1)
                    u.value = -2
                    If find_path.find_next_state(u) = 0 Then
                        MsgBox("Red win !", MsgBoxStyle.OkOnly, "Can't find the way")
                        'tang diem cho quan do
                        rbtBlack.Checked = True
                        red_score = red_score + 1
                        set_score()
                        btnNewGame.Enabled = True
                        red1.Visible = False
                        red2.Visible = False
                        black1.Visible = False
                        black2.Visible = False
                        playing = False
                    End If
                End If
            End If
            black1.Enabled = True
            black2.Enabled = True
            isBPlaying = True
        End If
    End Sub

    Private Sub GroupBox2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBoxBoard.MouseClick
        If (e.X > banco.Left + 216 And e.Y > banco.Top And e.Y < banco.Top + 216) Then
            If (choose = 1 And black1.Left = 148) Then
                current_state = current_state - curr_black(0) * 1000
                curr_black(0) = 0
                black1.Visible = False
                black1.Enabled = False
                BlackOut.Visible = True
                isBPlaying = False
            End If
            If (choose = 2 And black2.Left = 148) Then
                current_state = current_state - curr_black(1) * 100
                curr_black(1) = 0
                black2.Visible = False
                black2.Enabled = False
                BlackOut.Visible = True
                isBPlaying = False
            End If
        End If
        hide_cell()
        If curr_black(0) = 0 AndAlso curr_black(1) = 0 Then
            MsgBox("Black win !", MsgBoxStyle.OkOnly, "Win")
            'tang diem cho quan den
            rbtRed.Checked = True
            black_score = black_score + 1
            set_score()
            btnNewGame.Enabled = True
            red1.Visible = False
            red2.Visible = False
            playing = False
        End If
        choose = 0
        banco_MouseClick(sender, e)
    End Sub
    Public Sub red_go()
        black1.Enabled = False
        black2.Enabled = False
        u.depth = 0
        u.isBPlaying = False
        u.current_state = curr_black(0) * 1000 + curr_black(1) * 100 + curr_red(0) * 10 + curr_red(1)
        u.value = -2
        find_path.Find_path(u, game_depth)
    End Sub


    Private Sub bt_reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetGame.Click
        'kiem tra xem co dang choi hay ko
        If (MsgBox("Replay?", MsgBoxStyle.OkCancel, "Message") = MsgBoxResult.Cancel) And playing Then
            Exit Sub
        End If
        rbtBlack.Enabled = True
        rbtRed.Enabled = True
        btn4.Enabled = True
        btn8.Enabled = True
        btn6.Enabled = True
        btn10.Enabled = True
        btn12.Enabled = True
        rbtBlack.Checked = True
        btn4.Checked = True
        rbtRed.Checked = False
        reset()
        btnNewGame.Enabled = True
        black_score = 0
        red_score = 0
        set_score()
        playing = False
        'giau cac quan co
        black1.Visible = False
        black2.Visible = False
        red1.Visible = False
        red2.Visible = False
        hide_cell()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles btn10.CheckedChanged

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles btn12.CheckedChanged

    End Sub

    Private Sub rbtRed_CheckedChanged(sender As Object, e As EventArgs) Handles rbtRed.CheckedChanged

    End Sub
    Private Sub hide_cell()
        'khong cho hien cac duong di
        cell1.Visible = False
        cell2.Visible = False
        cell3.Visible = False
        cell4.Visible = False
        cell5.Visible = False
        cell6.Visible = False
        cell7.Visible = False
        cell8.Visible = False
        cell9.Visible = False
        'k cho ng dung tac dong
        cell1.Enabled = False
        cell2.Enabled = False
        cell3.Enabled = False
        cell4.Enabled = False
        cell5.Enabled = False
        cell6.Enabled = False
        cell7.Enabled = False
        cell8.Enabled = False
        cell9.Enabled = False
    End Sub
    Private Sub show_cell(ByVal pos As Integer)
        Select Case (pos)
            Case 1 : cell1.Visible = True
            Case 2 : cell2.Visible = True
            Case 3 : cell3.Visible = True
            Case 4 : cell4.Visible = True
            Case 5 : cell5.Visible = True
            Case 6 : cell6.Visible = True
            Case 7 : cell7.Visible = True
            Case 8 : cell8.Visible = True
            Case 9 : cell9.Visible = True
        End Select
    End Sub
    Public Sub show_path()
        If (choose = 1) Then
            If ((curr_black(0) + 1 <> curr_black(1)) AndAlso (curr_black(0) + 1 <> curr_red(0)) AndAlso (curr_black(0) + 1 <> curr_red(1)) AndAlso (curr_black(0) Mod 3 <> 0)) Then
                show_cell(curr_black(0) + 1)
            End If
            If ((curr_black(0) + 3 <> curr_black(1)) AndAlso (curr_black(0) + 3 <> curr_red(0)) AndAlso (curr_black(0) + 3 <> curr_red(1))) Then
                show_cell(curr_black(0) + 3)
            End If
            If ((curr_black(0) - 3 <> curr_black(1)) AndAlso (curr_black(0) - 3 <> curr_red(0)) AndAlso (curr_black(0) - 3 <> curr_red(1))) Then
                show_cell(curr_black(0) - 3)
            End If

        ElseIf (choose = 2) Then
            If ((curr_black(1) + 1 <> curr_black(0)) AndAlso (curr_black(1) + 1 <> curr_red(0)) AndAlso (curr_black(1) + 1 <> curr_red(1)) AndAlso (curr_black(1) Mod 3 <> 0)) Then
                show_cell(curr_black(1) + 1)
            End If
            If ((curr_black(1) + 3 <> curr_black(0)) AndAlso (curr_black(1) + 3 <> curr_red(0)) AndAlso (curr_black(1) + 3 <> curr_red(1))) Then
                show_cell(curr_black(1) + 3)
            End If
            If ((curr_black(1) - 3 <> curr_black(0)) AndAlso (curr_black(1) - 3 <> curr_red(0)) AndAlso (curr_black(1) - 3 <> curr_red(1))) Then
                show_cell(curr_black(1) - 3)
            End If
        End If
    End Sub
End Class
