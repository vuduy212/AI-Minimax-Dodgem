// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;

using Dodgem;// End of VB project level imports


namespace Dodgem
{
	sealed class FindPath
	{
		public struct state
		{
			public int curr_state; //trang thai hien tai cua ban co
			public bool BPlaying; //quan den co dang choi hay ko
			public int value; //gia tri cua trang thai hien tai
			public int depth; //do sau hien tai
			public state(int curr_state, bool BPlaying, int depth)
			{
				this.curr_state = curr_state;
				value = -2;
				this.depth = depth;
				this.BPlaying = BPlaying;
			}
		}
		public class NewState
		{
			public ArrayList state_proc; //xu ly cac trang thai co the xay ra trong cay trang thai
			public ArrayList next_state; //chua cac trang thai co the co
			public int[] val_red; //luu gia tri cua ham danh gia
			public int[] val_Black;
			public int[] arr_depth; //xu ly do sau hien tai
			public const int MaxDepth = 21;
			//Cac ham con
			public NewState()
			{
				arr_depth = new int[MaxDepth+ 1];
				state_proc = new ArrayList();
				next_state = new ArrayList();
				val_red = new int[10];
				val_Black = new int[10];
				//Ham danh gia cua quan trang
				val_red[0] = 150;
				val_red[1] = 30;
				val_red[2] = 35;
				val_red[3] = 40;
				val_red[4] = 15;
				val_red[5] = 20;
				val_red[6] = 25;
				val_red[7] = 0;
				val_red[8] = 5;
				val_red[9] = 10;
				//ham danh gia cua quan den
				val_Black[0] = -150;
				val_Black[1] = -10;
				val_Black[2] = -25;
				val_Black[3] = -40;
				val_Black[4] = -5;
				val_Black[5] = -20;
				val_Black[6] = -35;
				val_Black[7] = 0;
				val_Black[8] = -15;
				val_Black[9] = -30;
			}
			public bool End_state(state u, int depth)
			{
				//Kiem tra xem 1 trang thai co phai la ket thuc hay chua
				if (u.curr_state < 100 || (u.curr_state % 100 == 0) || u.depth == depth)
				{
					return true;
				}
				return false;
			}
			public int find_next_state(state u)
			{
				//tim trang thai tiep theo co the co
				int bl1 = 0;
				int bl2 = 0;
				int re1 = 0;
				int re2 = 0;
				next_state.Clear();
				bl1 = u.curr_state / 1000;
				bl2 = System.Convert.ToInt32((u.curr_state % 1000) / 100);
				re1 = System.Convert.ToInt32((u.curr_state % 100) / 10);
				re2 = u.curr_state % 10;
				if (u.BPlaying) //neu quan den dang choi
				{
					//quan den 1 dang choi
					if (bl1 != 0)
					{
						if (bl1 % 3 == 0)
						{
							next_state.Add(new state(u.curr_state - 1000 * bl1, false, u.depth + 1));
						}
						else if (bl1 + 1 != bl2 && bl1 + 1 != re1 && bl1 + 1 != re2)
						{
							next_state.Add(new state(u.curr_state + 1000, false, u.depth + 1));
						}
						
						if (bl1 + 3 <= 9 && bl1 + 3 != bl2 && bl1 + 3 != re1 && bl1 + 3 != re2)
						{
							next_state.Add(new state(u.curr_state + 3000, false, u.depth + 1));
						}
						if (bl1 - 3 >= 1 && bl1 - 3 != bl2 && bl1 - 3 != re1 && bl1 - 3 != re2)
						{
							next_state.Add(new state(u.curr_state - 3000, false, u.depth + 1));
						}
					}
					//quan den 2 dang choi
					if (bl2 != 0)
					{
						if (bl2 % 3 == 0)
						{
							next_state.Add(new state(u.curr_state - 100 * bl2, false, u.depth + 1));
						}
						else if (bl2 + 1 != bl1 && bl2 + 1 != re1 && bl2 + 1 != re2)
						{
							next_state.Add(new state(u.curr_state + 100, false, u.depth + 1));
						}
						
						if (bl2 + 3 <= 9 && bl2 + 3 != bl1 && bl2 + 3 != re1 && bl2 + 3 != re2)
						{
							next_state.Add(new state(u.curr_state + 300, false, u.depth + 1));
						}
						if (bl2 - 3 >= 1 && bl2 - 3 != bl1 && bl2 - 3 != re1 && bl2 - 3 != re2)
						{
							next_state.Add(new state(u.curr_state - 300, false, u.depth + 1));
						}
					}
				}
				else //quan do dang choi
				{
					//quan do 1 dang choi
					if (re1 != 0)
					{
						if (re1 <= 3)
						{
							next_state.Add(new state(u.curr_state - 10 * re1, true, u.depth + 1));
						}
						else if (re1 - 3 != re2 && re1 - 3 != bl1 && re1 - 3 != bl2)
						{
							next_state.Add(new state(u.curr_state - 30, true, u.depth + 1));
						}
						
						if (re1 % 3 != 0 && re1 + 1 != re2 && re1 + 1 != bl1 && re1 + 1 != bl2)
						{
							next_state.Add(new state(u.curr_state + 10, true, u.depth + 1));
						}
						if (re1 % 3 != 1 && re1 - 1 != re2 && re1 - 1 != bl1 && re1 - 1 != bl2)
						{
							next_state.Add(new state(u.curr_state - 10, true, u.depth + 1));
						}
					}
					//quan do 2 dang choi
					if (re2 != 0)
					{
						if (re2 <= 3)
						{
							next_state.Add(new state(u.curr_state - re2, true, u.depth + 1));
						}
						else if (re2 - 3 != re1 && re2 - 3 != bl1 && re2 - 3 != bl2)
						{
							next_state.Add(new state(u.curr_state - 3, true, u.depth + 1));
						}
						
						if (re2 % 3 != 0 && re2 + 1 != re1 && re2 + 1 != bl1 && re2 + 1 != bl2)
						{
							next_state.Add(new state(u.curr_state + 1, true, u.depth + 1));
						}
						if (re2 % 3 != 1 && re2 - 1 != re1 && re2 - 1 != bl1 && re2 - 1 != bl2)
						{
							next_state.Add(new state(u.curr_state - 1, true, u.depth + 1));
						}
					}
				}
				return next_state.Count;
			}
			public void state_value(state u)
			{
				//tnh gia tri trang thai hien tai cua ban co thong qua ham danh gia
				int i = 0;
				int[] chessman = new int[4];
				//tach vi tri cac quan co
				chessman[0] = u.curr_state / 1000;
				chessman[1] = System.Convert.ToInt32((u.curr_state % 1000) / 100);
				chessman[2] = System.Convert.ToInt32((u.curr_state % 100) / 10);
				chessman[3] = u.curr_state % 10;
				
				u.value = 0;
				// tinh gia tri trang thai quan den
				for (i = 0; i <= 1; i++)
				{
					//truong hop bi chan gian tiep hoac truc tiep
					if (chessman[i] % 3 != 0)
					{
						if (chessman[i] + 1 == chessman[2] || chessman[i] + 1 == chessman[3])
						{
							u.value += 40;
						}
						if (chessman[i] % 3 == 1 && (chessman[i] + 2 == chessman[2] || chessman[i] + 2 == chessman[3]))
						{
							u.value += 30;
						}
					}
					//cac truong hop con lai
					if (chessman[i] != 0)
					{
						u.value += val_Black[chessman[i]];
					}
					else
					{
						u.value += val_Black[chessman[i]] * (MaxDepth - u.depth);
					}
				}
				// tinh gia tri trang thai quan do
				for (i = 2; i <= 3; i++)
				{
					//xet bi chan gian tiep hoac truc tiep
					if (chessman[i] > 3)
					{
						if (chessman[i] - 3 == chessman[0] || chessman[i] - 3 == chessman[1])
						{
							u.value -= 40;
						}
						if (chessman[i] >= 7 && (chessman[i] - 6 == chessman[0] || chessman[i] - 6 == chessman[1]))
						{
							u.value -= 30;
						}
					}
					//cac truong hop con lai
					if (chessman[i] != 0)
					{
						u.value += val_red[chessman[i]];
					}
					else
					{
						u.value += val_red[chessman[i]] * (MaxDepth - u.depth);
					}
				}
			}
			//dua trang thai hien tai cua ban co de so sanh tim duong di
			private void state_out(state u, ref int state_out)
			{
				if (u.BPlaying)
				{
					// tim max
					if (arr_depth[u.depth] < u.value) //tim gia tri lon nhat cua do sau duoc truyen vao
					{
						arr_depth[u.depth] = u.value;
						if (u.depth == 1)
						{
							state_out = u.curr_state;
						}
					}
					state_proc.RemoveAt(0);
				}
				else
				{
					// tim min
					if (arr_depth[u.depth] > u.value)
					{
						arr_depth[u.depth] = u.value;
						if (u.depth == 1)
						{
							state_out = u.curr_state;
						}
					}
					state_proc.RemoveAt(0);
				}
			}
			//tim duong di
			public void Find_path(state u0, int depth)
			{
				int i = 0;
				int num_ke = 0;
				int pos_end = -1;
				// pos_end chua vi tri can tim
				state u = new state();
				
				state_proc.Clear();
				state_proc.Add(u0);
				
				if (u0.BPlaying)
				{
					// den di truoc
					for (i = 1; i <= MaxDepth - 1; i += 2)
					{
						arr_depth[i] = 5000;
						// tim Min
						arr_depth[i + 1] = -5000;
						// tim Max
					}
					arr_depth[0] = 5000;
				}
				else
				{
					for (i = 1; i <= MaxDepth - 1; i += 2)
					{
						arr_depth[i] = -5000;
						// tim Max
						arr_depth[i + 1] = 5000;
						// tim Min
					}
					arr_depth[0] = -5000;
				}
				//=========================================
				while (true)
				{
					if (state_proc.Count == 0)
					{
						u0.value = pos_end;
						return;
					}
					u = (state) (state_proc[0]);
					// xet coi u co phai trang thai ket thuc hoac la la khong
					if (u.value == -2)
					{
						// dinh u chua duoc mo rong
						if (End_state(u, depth))
						{
							// u la trang thai ket thuc nen khong mo rong nua
							state_value(u);
							// tinh gia tri cho dinh u
							state_out(u, ref pos_end);
							
						}
						else
						{
							// xet cac dinh ke dinh u
							// da mo rong nhung chua duoc danh gia
							num_ke = find_next_state(u);
							// cac dinh ke da luu vao "ke"
							if (num_ke != 0)
							{
								u.value = -1;
								state_proc.RemoveAt(0);
								state_proc.Insert(0, u);
								// cap nhat lai u
								for (i = 0; i <= num_ke - 1; i++)
								{
									state_proc.Insert(0, (state) (next_state[i]));
									// dat vao dau danh sach
								}
							}
							else
							{
								// truong hop khong tim duoc dinh nao ke
								state_value(u);
								if (u.BPlaying)
								{
									// den thua
									u.value += 2 * val_red[0] * (MaxDepth - u.depth);
								}
								else
								{
									u.value += 2 * val_Black[0] * (MaxDepth - u.depth);
								}
								state_out(u, ref pos_end);
							}
						}
					}
					else
					{
						u.value = arr_depth[u.depth + 1];
						state_out(u, ref pos_end);
						if (u.BPlaying)
						{
							arr_depth[u.depth + 1] = 5000;
						}
						else
						{
							arr_depth[u.depth + 1] = -5000;
						}
					}
					
				}
			}
		}
	}
	
}
