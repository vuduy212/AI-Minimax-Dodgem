
Public Class Form1
    Dim choose As Integer 'Xem quân cờ nào đang dc chọn
    Dim curr_l As Integer, curr_t As Integer 'Vị trí hiện tại của quân cờ
    Dim old_x As Integer, old_y As Integer
    Dim playing As Boolean = False 'Kiểm tra là có đang chơi hay ko
    Dim curr_black(1) As Integer 'Xem có bao nhiêu quân đen ra ngoài 
    Dim curr_red(1) As Integer 'xem co bao nhieu quan do ra ngoai
    Dim u As state 'bien trang thai hien tai cua ban co
    Dim find_path As NewState 'dung de tim duong di
    Dim curr_state As Integer 'luu trang thai hien tai cua 4 quan co
    Dim bplaying As Boolean, red_first As Boolean
    Dim user_depth As Integer
    Dim black_score As Integer, red_score As Integer
    Private Sub BtExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtExit.Click
        Me.Close()
    End Sub
    Private Sub set_score()
        bl_score.Text = black_score.ToString
        re_score.Text = red_score.ToString
    End Sub
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        black1.Visible = False
        black2.Visible = False
        red1.Visible = False
        red2.Visible = False
        redout.Visible = False
        blackout.Visible = False
        hide_cell()
        set_score()

    End Sub
    Private Sub reset()

        'thiết lập các giá trị
        choose = 0
        black1.BackColor = Color.BurlyWood
        black2.BackColor = Color.BurlyWood
        playing = True
        bplaying = True
        curr_state = 1489
        curr_black(0) = 1
        curr_black(1) = 4
        curr_red(0) = 8
        curr_red(1) = 9
        u = New state(1489, True, 0)
        find_path = New NewState
        redout.Visible = False
        blackout.Visible = False
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
    Private Sub btNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNew.Click
        btNew.Enabled = False
        'kiem tra xem co dang choi hay ko
        If playing Then
            If (MsgBox("Bạn vẫn đang chơi,bạn muốn chơi lại?", MsgBoxStyle.OkCancel, "Thông báo") = MsgBoxResult.Ok) Then
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
        'kiem tra level ma nguoi choi chon
        If rbtChick.Checked = True Then
            user_depth = 3
        ElseIf rbtPro.Checked = True Then
            user_depth = 8
        ElseIf rbtPrem.Checked = True Then
            user_depth = 12
        End If
        'disable cac tuy chon
        rbtBlack.Enabled = False
        rbtRed.Enabled = False
        rbtChick.Enabled = False
        rbtPro.Enabled = False
        rbtPrem.Enabled = False
        'neu red choi truoc
        If red_first = True Then
            'thiet lap trang thai
            bplaying = False
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
        bplaying = True
        hide_cell()
    End Sub

    Private Sub black1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles black1.MouseClick
        If bplaying = True Then
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
        If bplaying = True Then
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
                curr_state = curr_state + 1000
                curr_black(0) = curr_black(0) + 1
                bplaying = False
            ElseIf ((e.Y > black1.Top + 72) And (e.Y < black1.Top + 144) And (e.X < black1.Left + 72) And (e.X > black1.Left)) Then
                black1.Top = black1.Top + 72
                curr_state = curr_state + 3000
                curr_black(0) = curr_black(0) + 3
                bplaying = False
            ElseIf ((e.Y < black1.Top) And (e.Y > black1.Top - 72) And (e.X < black1.Left + 72) And (e.X > black1.Left)) Then
                black1.Top = black1.Top - 72
                curr_state = curr_state - 3000
                curr_black(0) = curr_black(0) - 3
                bplaying = False
            End If
            black1.BackColor = Color.BurlyWood
            choose = 0
        ElseIf choose = 2 Then
            If ((e.X > black2.Left + 72) And (e.X < black2.Left + 144) And (e.Y < black2.Top + 72) And (e.Y > black2.Top)) Then
                black2.Left = black2.Left + 72
                curr_state = curr_state + 100
                curr_black(1) = curr_black(1) + 1
                bplaying = False
            ElseIf ((e.Y > black2.Top + 72) And (e.Y < black2.Top + 144) And (e.X < black2.Left + 72) And (e.X > black2.Left)) Then
                black2.Top = black2.Top + 72
                curr_state = curr_state + 300
                curr_black(1) = curr_black(1) + 3
                bplaying = False
            ElseIf ((e.Y < black2.Top) And (e.Y > black2.Top - 72) And (e.X < black2.Left + 72) And (e.X > black2.Left)) Then
                black2.Top = black2.Top - 72
                curr_state = curr_state - 300
                curr_black(1) = curr_black(1) - 3
                bplaying = False
            End If
            black2.BackColor = Color.BurlyWood
            choose = 0
        End If
        hide_cell()
        If (bplaying = False AndAlso playing = True) Then
            red_go()
            If (u.value < 0) Then
                MsgBox("Quân đen thắng", MsgBoxStyle.OkOnly, "Không tìm được đường đi")
                'tang diem cho quan den
                rbtRed.Checked = True
                black_score = black_score + 1
                set_score()
                btNew.Enabled = True
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
                    redout.Visible = True
                Else
                    red1.Top = 4 + 72 * ((curr_red(0) - 1) \ 3)
                    red1.Left = 4 + 72 * ((curr_red(0) - 1) Mod 3)
                End If
                If (curr_red(1) = 0) Then
                    red2.Enabled = False
                    red2.Visible = False
                    redout.Visible = True
                Else
                    red2.Top = 4 + 72 * ((curr_red(1) - 1) \ 3)
                    red2.Left = 4 + 72 * ((curr_red(1) - 1) Mod 3)
                End If
                If (curr_red(0) = 0 AndAlso curr_red(1) = 0) Then
                    MsgBox("Quân đỏ thắng", MsgBoxStyle.OkOnly, "Thắng")
                    'tang diem cho quan do
                    rbtBlack.Checked = True
                    red_score = red_score + 1
                    set_score()
                    btNew.Enabled = True
                    black1.Visible = False
                    black2.Visible = False
                    playing = False
                Else
                    u.BPlaying = True
                    u.depth = 0
                    u.curr_state = curr_black(0) * 1000 + curr_black(1) * 100 + curr_red(0) * 10 + curr_red(1)
                    u.value = -2
                    If find_path.find_next_state(u) = 0 Then
                        MsgBox("Quân đỏ thắng", MsgBoxStyle.OkOnly, "Không tìm được đường đi")
                        'tang diem cho quan do
                        rbtBlack.Checked = True
                        red_score = red_score + 1
                        set_score()
                        btNew.Enabled = True
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
            bplaying = True
        End If
    End Sub

    Private Sub GroupBox2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox2.MouseClick
        If (e.X > banco.Left + 216 And e.Y > banco.Top And e.Y < banco.Top + 216) Then
            If (choose = 1 And black1.Left = 148) Then
                curr_state = curr_state - curr_black(0) * 1000
                curr_black(0) = 0
                black1.Visible = False
                black1.Enabled = False
                blackout.Visible = True
                bplaying = False
            End If
            If (choose = 2 And black2.Left = 148) Then
                curr_state = curr_state - curr_black(1) * 100
                curr_black(1) = 0
                black2.Visible = False
                black2.Enabled = False
                blackout.Visible = True
                bplaying = False
            End If
        End If
        hide_cell()
        If curr_black(0) = 0 AndAlso curr_black(1) = 0 Then
            MsgBox("Quân đen thắng", MsgBoxStyle.OkOnly, "Thắng")
            'tang diem cho quan den
            rbtRed.Checked = True
            black_score = black_score + 1
            set_score()
            btNew.Enabled = True
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
        u.BPlaying = False
        u.curr_state = curr_black(0) * 1000 + curr_black(1) * 100 + curr_red(0) * 10 + curr_red(1)
        u.value = -2
        find_path.Find_path(u, user_depth)
    End Sub

    
    Private Sub bt_reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_reset.Click
        'kiem tra xem co dang choi hay ko
        If (MsgBox("Bạn vẫn đang chơi,bạn muốn chơi lại?", MsgBoxStyle.OkCancel, "Thông báo") = MsgBoxResult.Cancel) And playing Then
            Exit Sub
        End If
        rbtBlack.Enabled = True
        rbtRed.Enabled = True
        rbtChick.Enabled = True
        rbtPro.Enabled = True
        rbtPrem.Enabled = True
        rbtBlack.Checked = True
        rbtChick.Checked = True
        rbtRed.Checked = False
        reset()
        btNew.Enabled = True
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

    Private Sub bt_how_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_how.Click
        how2play.ShowDialog()
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
