Imports System
Module FindPath
    Public Structure state
        Public curr_state As Integer 'trang thai hien tai cua ban co
        Public BPlaying As Boolean 'quan den co dang choi hay ko
        Public value As Integer 'gia tri cua trang thai hien tai
        Public depth As Integer 'do sau hien tai
        Public Sub New(ByVal curr_state As Integer, ByVal BPlaying As Boolean, ByVal depth As Integer)
            Me.curr_state = curr_state
            value = -2
            Me.depth = depth
            Me.BPlaying = BPlaying
        End Sub
    End Structure
    Public Class NewState
        Public state_proc As ArrayList 'xu ly cac trang thai co the xay ra trong cay trang thai
        Public next_state As ArrayList 'chua cac trang thai co the co
        Public val_red() As Integer, val_Black() As Integer 'luu gia tri cua ham danh gia
        Public arr_depth() As Integer 'xu ly do sau hien tai
        Public Const MaxDepth As Integer = 21
        'Cac ham con
        Public Sub New()
            arr_depth = New Integer(MaxDepth) {}
            state_proc = New ArrayList
            next_state = New ArrayList
            val_red = New Integer(9) {}
            val_Black = New Integer(9) {}
            'Ham danh gia cua quan trang
            val_red(0) = 150
            val_red(1) = 30
            val_red(2) = 35
            val_red(3) = 40
            val_red(4) = 15
            val_red(5) = 20
            val_red(6) = 25
            val_red(7) = 0
            val_red(8) = 5
            val_red(9) = 10
            'ham danh gia cua quan den
            val_Black(0) = -150
            val_Black(1) = -10
            val_Black(2) = -25
            val_Black(3) = -40
            val_Black(4) = -5
            val_Black(5) = -20
            val_Black(6) = -35
            val_Black(7) = 0
            val_Black(8) = -15
            val_Black(9) = -30
        End Sub
        Public Function End_state(ByVal u As state, ByVal depth As Integer) As Boolean
            'Kiem tra xem 1 trang thai co phai la ket thuc hay chua
            If (u.curr_state < 100 Or (u.curr_state Mod 100 = 0) Or u.depth = depth) Then
                Return True
            End If
            Return False
        End Function
        Public Function find_next_state(ByVal u As state) As Integer
            'tim trang thai tiep theo co the co
            Dim bl1 As Integer, bl2 As Integer, re1 As Integer, re2 As Integer
            next_state.Clear()
            bl1 = u.curr_state \ 1000
            bl2 = (u.curr_state Mod 1000) \ 100
            re1 = (u.curr_state Mod 100) \ 10
            re2 = u.curr_state Mod 10
            If (u.BPlaying) Then 'neu quan den dang choi
                'quan den 1 dang choi
                If (bl1 <> 0) Then
                    If bl1 Mod 3 = 0 Then
                        next_state.Add(New state(u.curr_state - 1000 * bl1, False, u.depth + 1))
                    ElseIf bl1 + 1 <> bl2 AndAlso bl1 + 1 <> re1 AndAlso bl1 + 1 <> re2 Then
                        next_state.Add(New state(u.curr_state + 1000, False, u.depth + 1))
                    End If

                    If bl1 + 3 <= 9 AndAlso bl1 + 3 <> bl2 AndAlso bl1 + 3 <> re1 AndAlso bl1 + 3 <> re2 Then
                        next_state.Add(New state(u.curr_state + 3000, False, u.depth + 1))
                    End If
                    If bl1 - 3 >= 1 AndAlso bl1 - 3 <> bl2 AndAlso bl1 - 3 <> re1 AndAlso bl1 - 3 <> re2 Then
                        next_state.Add(New state(u.curr_state - 3000, False, u.depth + 1))
                    End If
                End If
                'quan den 2 dang choi
                If bl2 <> 0 Then
                    If bl2 Mod 3 = 0 Then
                        next_state.Add(New state(u.curr_state - 100 * bl2, False, u.depth + 1))
                    ElseIf bl2 + 1 <> bl1 AndAlso bl2 + 1 <> re1 AndAlso bl2 + 1 <> re2 Then
                        next_state.Add(New state(u.curr_state + 100, False, u.depth + 1))
                    End If

                    If bl2 + 3 <= 9 AndAlso bl2 + 3 <> bl1 AndAlso bl2 + 3 <> re1 AndAlso bl2 + 3 <> re2 Then
                        next_state.Add(New state(u.curr_state + 300, False, u.depth + 1))
                    End If
                    If bl2 - 3 >= 1 AndAlso bl2 - 3 <> bl1 AndAlso bl2 - 3 <> re1 AndAlso bl2 - 3 <> re2 Then
                        next_state.Add(New state(u.curr_state - 300, False, u.depth + 1))
                    End If
                End If
            Else 'quan do dang choi
                'quan do 1 dang choi
                If re1 <> 0 Then
                    If re1 <= 3 Then
                        next_state.Add(New state(u.curr_state - 10 * re1, True, u.depth + 1))
                    ElseIf re1 - 3 <> re2 AndAlso re1 - 3 <> bl1 AndAlso re1 - 3 <> bl2 Then
                        next_state.Add(New state(u.curr_state - 30, True, u.depth + 1))
                    End If

                    If re1 Mod 3 <> 0 AndAlso re1 + 1 <> re2 AndAlso re1 + 1 <> bl1 AndAlso re1 + 1 <> bl2 Then
                        next_state.Add(New state(u.curr_state + 10, True, u.depth + 1))
                    End If
                    If re1 Mod 3 <> 1 AndAlso re1 - 1 <> re2 AndAlso re1 - 1 <> bl1 AndAlso re1 - 1 <> bl2 Then
                        next_state.Add(New state(u.curr_state - 10, True, u.depth + 1))
                    End If
                End If
                'quan do 2 dang choi
                If re2 <> 0 Then
                    If re2 <= 3 Then
                        next_state.Add(New state(u.curr_state - re2, True, u.depth + 1))
                    ElseIf re2 - 3 <> re1 AndAlso re2 - 3 <> bl1 AndAlso re2 - 3 <> bl2 Then
                        next_state.Add(New state(u.curr_state - 3, True, u.depth + 1))
                    End If

                    If re2 Mod 3 <> 0 AndAlso re2 + 1 <> re1 AndAlso re2 + 1 <> bl1 AndAlso re2 + 1 <> bl2 Then
                        next_state.Add(New state(u.curr_state + 1, True, u.depth + 1))
                    End If
                    If re2 Mod 3 <> 1 AndAlso re2 - 1 <> re1 AndAlso re2 - 1 <> bl1 AndAlso re2 - 1 <> bl2 Then
                        next_state.Add(New state(u.curr_state - 1, True, u.depth + 1))
                    End If
                End If
            End If
            Return next_state.Count
        End Function
        Public Sub state_value(ByRef u As state)
            'tnh gia tri trang thai hien tai cua ban co thong qua ham danh gia
            Dim i As Integer
            Dim chessman As Integer() = New Integer(3) {}
            'tach vi tri cac quan co
            chessman(0) = u.curr_state \ 1000
            chessman(1) = (u.curr_state Mod 1000) \ 100
            chessman(2) = (u.curr_state Mod 100) \ 10
            chessman(3) = u.curr_state Mod 10

            u.value = 0
            ' tinh gia tri trang thai quan den
            For i = 0 To 1
                'truong hop bi chan gian tiep hoac truc tiep
                If chessman(i) Mod 3 <> 0 Then
                    If chessman(i) + 1 = chessman(2) OrElse chessman(i) + 1 = chessman(3) Then
                        u.value += 40
                    End If
                    If chessman(i) Mod 3 = 1 AndAlso (chessman(i) + 2 = chessman(2) OrElse chessman(i) + 2 = chessman(3)) Then
                        u.value += 30
                    End If
                End If
                'cac truong hop con lai
                If chessman(i) <> 0 Then
                    u.value += val_Black(chessman(i))
                Else
                    u.value += val_Black(chessman(i)) * (MaxDepth - u.depth)
                End If
            Next
            ' tinh gia tri trang thai quan do
            For i = 2 To 3
                'xet bi chan gian tiep hoac truc tiep
                If chessman(i) > 3 Then
                    If chessman(i) - 3 = chessman(0) OrElse chessman(i) - 3 = chessman(1) Then
                        u.value -= 40
                    End If
                    If chessman(i) >= 7 AndAlso (chessman(i) - 6 = chessman(0) OrElse chessman(i) - 6 = chessman(1)) Then
                        u.value -= 30
                    End If
                End If
                'cac truong hop con lai
                If chessman(i) <> 0 Then
                    u.value += val_red(chessman(i))
                Else
                    u.value += val_red(chessman(i)) * (MaxDepth - u.depth)
                End If
            Next
        End Sub
        'dua trang thai hien tai cua ban co de so sanh tim duong di
        Private Sub state_out(ByVal u As state, ByRef state_out As Integer)
            If u.BPlaying Then
                ' tim max
                If arr_depth(u.depth) < u.value Then
                    arr_depth(u.depth) = u.value
                    If u.depth = 1 Then
                        state_out = u.curr_state
                    End If
                End If
                state_proc.RemoveAt(0)
            Else
                ' tim min
                If arr_depth(u.depth) > u.value Then
                    arr_depth(u.depth) = u.value
                    If u.depth = 1 Then
                        state_out = u.curr_state
                    End If
                End If
                state_proc.RemoveAt(0)
            End If
        End Sub
        'tim duong di
        Public Sub Find_path(ByRef u0 As state, ByVal depth As Integer)
            Dim i As Integer, num_ke As Integer = 0, pos_end As Integer = -1
            ' pos_end chua vi tri can tim
            Dim u As state

            state_proc.Clear()
            state_proc.Add(u0)

            If u0.BPlaying Then
                ' den di truoc
                For i = 1 To MaxDepth - 1 Step 2
                    arr_depth(i) = 5000
                    ' tim Min
                    arr_depth(i + 1) = -5000
                    ' tim Max
                Next
                arr_depth(0) = 5000
            Else
                For i = 1 To MaxDepth - 1 Step 2
                    arr_depth(i) = -5000
                    ' tim Max
                    arr_depth(i + 1) = 5000
                    ' tim Min
                Next
                arr_depth(0) = -5000
            End If
            '=========================================
            While True
                If state_proc.Count = 0 Then
                    u0.value = pos_end
                    Exit Sub
                End If
                u = DirectCast(state_proc(0), state)
                ' xet coi u co phai trang thai ket thuc hoac la la khong
                If u.value = -2 Then
                    ' dinh u chua duoc mo rong
                    If End_state(u, depth) Then
                        ' u la trang thai ket thuc nen khong mo rong nua														
                        state_value(u)
                        ' tinh gia tri cho dinh u
                        state_out(u, pos_end)

                    Else
                        ' xet cac dinh ke dinh u																																																				
                        ' da mo rong nhung chua duoc danh gia
                        num_ke = find_next_state(u)
                        ' cac dinh ke da luu vao "ke"								
                        If num_ke <> 0 Then
                            u.value = -1
                            state_proc.RemoveAt(0)
                            state_proc.Insert(0, u)
                            ' cap nhat lai u
                            For i = 0 To num_ke - 1
                                state_proc.Insert(0, DirectCast(next_state(i), state))
                                ' dat vao dau danh sach													
                            Next
                        Else
                            ' truong hop khong tim duoc dinh nao ke
                            state_value(u)
                            If u.BPlaying Then
                                ' den thua
                                u.value += 2 * val_red(0) * (MaxDepth - u.depth)
                            Else
                                u.value += 2 * val_Black(0) * (MaxDepth - u.depth)
                            End If
                            state_out(u, pos_end)
                        End If
                    End If
                Else
                    u.value = arr_depth(u.depth + 1)
                    state_out(u, pos_end)
                    If u.BPlaying Then
                        arr_depth(u.depth + 1) = 5000
                    Else
                        arr_depth(u.depth + 1) = -5000
                    End If
                End If

            End While
        End Sub
    End Class
End Module
