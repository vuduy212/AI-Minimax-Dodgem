// VBConversions Note: VB project level imports
using System.Drawing;
using Microsoft.VisualBasic;
// End of VB project level imports

using Dodgem;

namespace Dodgem
{
	
	public partial class Form1
	{
		public Form1()
		{
			InitializeComponent();
			
			//Added to support default instance behavour in C#
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static Form1 defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
		public static Form1 Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new Form1();
					defaultInstance.FormClosed += new System.Windows.Forms.FormClosedEventHandler(defaultInstance_FormClosed);
				}
				
				return defaultInstance;
			}
			set
			{
				defaultInstance = value;
			}
		}
		
		static void defaultInstance_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
		{
			defaultInstance = null;
		}
		
#endregion
		int choose; //Xem quân cờ nào đang dc chọn
		int curr_l; //Vị trí hiện tại của quân cờ
		int curr_t;
		int old_x;
		int old_y;
		bool playing = false; //Kiểm tra là có đang chơi hay ko
		int[] curr_black = new int[2]; //Xem có bao nhiêu quân đen ra ngoài
		int[] curr_red = new int[2]; //xem co bao nhieu quan do ra ngoai
		FindPath.state u; //bien trang thai hien tai cua ban co
		FindPath.NewState find_path; //dung de tim duong di
		int curr_state; //luu trang thai hien tai cua 4 quan co
		bool bplaying;
		bool red_first;
		int user_depth;
		int black_score;
		int red_score;
		public void BtExit_Click(System.Object sender, System.EventArgs e)
		{
			this.Close();
		}
		private void set_score()
		{
			bl_score.Text = black_score.ToString();
			re_score.Text = red_score.ToString();
		}
		public void Form1_Load(object sender, System.EventArgs e)
		{
			black1.Visible = false;
			black2.Visible = false;
			red1.Visible = false;
			red2.Visible = false;
			redout.Visible = false;
			blackout.Visible = false;
			hide_cell();
			set_score();
			
		}
		private void reset()
		{
			
			//thiết lập các giá trị
			choose = 0;
			black1.BackColor = Color.BurlyWood;
			black2.BackColor = Color.BurlyWood;
			playing = true;
			bplaying = true;
			curr_state = 1489;
			curr_black[0] = 1;
			curr_black[1] = 4;
			curr_red[0] = 8;
			curr_red[1] = 9;
			u = new FindPath.state(1489, true, 0);
			find_path = new FindPath.NewState();
			redout.Visible = false;
			blackout.Visible = false;
			//thiết lập ban đầu cho quân đen 1
			black1.Top = 4;
			black1.Left = 4;
			black1.Enabled = true;
			black1.Visible = true;
			
			//thiết lập ban đầu cho quân đen 2
			black2.Top = 76;
			black2.Left = 4;
			black2.Enabled = true;
			black2.Visible = true;
			
			//thiết lập ban đầu cho quân đỏ 1
			red1.Top = 148;
			red1.Left = 76;
			red1.Enabled = true;
			red1.Visible = true;
			
			//thiết lập ban đầu cho quân đỏ 2
			red2.Top = 148;
			red2.Left = 148;
			red2.Enabled = true;
			red2.Visible = true;
		}
		public void btNew_Click(System.Object sender, System.EventArgs e)
		{
			btNew.Enabled = false;
			//kiem tra xem co dang choi hay ko
			if (playing)
			{
				if (Interaction.MsgBox("Do you want replay?", MsgBoxStyle.OkCancel, "Message") == MsgBoxResult.Ok)
				{
					reset();
				}
			}
			else
			{
				reset();
			}
			//kiem tra Red la nguoi choi truoc hay ko
			if (rbtRed.Checked == true)
			{
				red_first = true;
			}
			else
			{
				red_first = false;
			}
			//kiem tra level ma nguoi choi chon
			if (rbtChick.Checked == true)
			{
				user_depth = 3;
			}
			else if (rbtPro.Checked == true)
			{
				user_depth = 8;
			}
			else if (rbtPrem.Checked == true)
			{
				user_depth = 12;
			}
			//disable cac tuy chon
			rbtBlack.Enabled = false;
			rbtRed.Enabled = false;
			rbtChick.Enabled = false;
			rbtPro.Enabled = false;
			rbtPrem.Enabled = false;
			//neu red choi truoc
			if (red_first == true)
			{
				//thiet lap trang thai
				bplaying = false;
				//di chuyen quan do
				red_go();
				curr_red[0] = System.Convert.ToInt32((u.value % 100) / 10);
				curr_red[1] = u.value % 10;
				red1.Top = System.Convert.ToInt32(4 + 72 * ((curr_red[0] - 1) / 3));
				red1.Left = System.Convert.ToInt32(4 + 72 * ((curr_red[0] - 1) % 3));
				red2.Top = System.Convert.ToInt32(4 + 72 * ((curr_red[1] - 1) / 3));
				red2.Left = System.Convert.ToInt32(4 + 72 * ((curr_red[1] - 1) % 3));
				//phuc hoi trang thai
				black1.Enabled = true;
				black2.Enabled = true;
			}
			bplaying = true;
			hide_cell();
		}
		
		public void black1_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bplaying == true)
			{
				hide_cell();
				choose = 1;
				curr_l = black1.Left;
				curr_t = black1.Top;
				black1.BackColor = Color.DarkGoldenrod;
				black2.BackColor = Color.BurlyWood;
				show_path();
			}
		}
		
		public void black2_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bplaying == true)
			{
				hide_cell();
				choose = 2;
				curr_l = black2.Left;
				curr_t = black2.Top;
				black2.BackColor = Color.DarkGoldenrod;
				black1.BackColor = Color.BurlyWood;
				show_path();
			}
		}
		
		public void banco_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (choose == 1)
			{
				if ((e.X > black1.Left + 72) && (e.X < black1.Left + 144) && (e.Y < black1.Top + 72) && (e.Y > black1.Top))
				{
					black1.Left = black1.Left + 72;
					curr_state = curr_state + 1000;
					curr_black[0] = curr_black[0] + 1;
					bplaying = false;
				}
				else if ((e.Y > black1.Top + 72) && (e.Y < black1.Top + 144) && (e.X < black1.Left + 72) && (e.X > black1.Left))
				{
					black1.Top = black1.Top + 72;
					curr_state = curr_state + 3000;
					curr_black[0] = curr_black[0] + 3;
					bplaying = false;
				}
				else if ((e.Y < black1.Top) && (e.Y > black1.Top - 72) && (e.X < black1.Left + 72) && (e.X > black1.Left))
				{
					black1.Top = black1.Top - 72;
					curr_state = curr_state - 3000;
					curr_black[0] = curr_black[0] - 3;
					bplaying = false;
				}
				black1.BackColor = Color.BurlyWood;
				choose = 0;
			}
			else if (choose == 2)
			{
				if ((e.X > black2.Left + 72) && (e.X < black2.Left + 144) && (e.Y < black2.Top + 72) && (e.Y > black2.Top))
				{
					black2.Left = black2.Left + 72;
					curr_state = curr_state + 100;
					curr_black[1] = curr_black[1] + 1;
					bplaying = false;
				}
				else if ((e.Y > black2.Top + 72) && (e.Y < black2.Top + 144) && (e.X < black2.Left + 72) && (e.X > black2.Left))
				{
					black2.Top = black2.Top + 72;
					curr_state = curr_state + 300;
					curr_black[1] = curr_black[1] + 3;
					bplaying = false;
				}
				else if ((e.Y < black2.Top) && (e.Y > black2.Top - 72) && (e.X < black2.Left + 72) && (e.X > black2.Left))
				{
					black2.Top = black2.Top - 72;
					curr_state = curr_state - 300;
					curr_black[1] = curr_black[1] - 3;
					bplaying = false;
				}
				black2.BackColor = Color.BurlyWood;
				choose = 0;
			}
			hide_cell();
			if (bplaying == false && playing == true)
			{
				red_go();
				if (u.value < 0)
				{
					Interaction.MsgBox("Quân đen thắng", MsgBoxStyle.OkOnly, "Không tìm được đường đi");
					//tang diem cho quan den
					rbtRed.Checked = true;
					black_score++;
					set_score();
					btNew.Enabled = true;
					red1.Visible = false;
					red2.Visible = false;
					black1.Visible = false;
					black2.Visible = false;
					playing = false;
				}
				else
				{
					curr_red[0] = System.Convert.ToInt32((u.value % 100) / 10);
					curr_red[1] = u.value % 10;
					if (curr_red[0] == 0)
					{
						red1.Visible = false;
						red1.Enabled = false;
						redout.Visible = true;
					}
					else
					{
						red1.Top = System.Convert.ToInt32(4 + 72 * ((curr_red[0] - 1) / 3));
						red1.Left = System.Convert.ToInt32(4 + 72 * ((curr_red[0] - 1) % 3));
					}
					if (curr_red[1] == 0)
					{
						red2.Enabled = false;
						red2.Visible = false;
						redout.Visible = true;
					}
					else
					{
						red2.Top = System.Convert.ToInt32(4 + 72 * ((curr_red[1] - 1) / 3));
						red2.Left = System.Convert.ToInt32(4 + 72 * ((curr_red[1] - 1) % 3));
					}
					if (curr_red[0] == 0 && curr_red[1] == 0)
					{
						Interaction.MsgBox("Quân đỏ thắng", MsgBoxStyle.OkOnly, "Thắng");
						//tang diem cho quan do
						rbtBlack.Checked = true;
						red_score++;
						set_score();
						btNew.Enabled = true;
						black1.Visible = false;
						black2.Visible = false;
						playing = false;
					}
					else
					{
						u.BPlaying = true;
						u.depth = 0;
						u.curr_state = curr_black[0] * 1000 + curr_black[1] * 100 + curr_red[0] * 10 + curr_red[1];
						u.value = -2;
						if (find_path.find_next_state(u) == 0)
						{
							Interaction.MsgBox("Quân đỏ thắng", MsgBoxStyle.OkOnly, "Không tìm được đường đi");
							//tang diem cho quan do
							rbtBlack.Checked = true;
							red_score++;
							set_score();
							btNew.Enabled = true;
							red1.Visible = false;
							red2.Visible = false;
							black1.Visible = false;
							black2.Visible = false;
							playing = false;
						}
					}
				}
				black1.Enabled = true;
				black2.Enabled = true;
				bplaying = true;
			}
		}
		
		public void GroupBox2_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.X > banco.Left + 216 & e.Y > banco.Top & e.Y < banco.Top + 216)
			{
				if (choose == 1 & black1.Left == 148)
				{
					curr_state = curr_state - curr_black[0] * 1000;
					curr_black[0] = 0;
					black1.Visible = false;
					black1.Enabled = false;
					blackout.Visible = true;
					bplaying = false;
				}
				if (choose == 2 & black2.Left == 148)
				{
					curr_state = curr_state - curr_black[1] * 100;
					curr_black[1] = 0;
					black2.Visible = false;
					black2.Enabled = false;
					blackout.Visible = true;
					bplaying = false;
				}
			}
			hide_cell();
			if (curr_black[0] == 0 && curr_black[1] == 0)
			{
				Interaction.MsgBox("Quân đen thắng", MsgBoxStyle.OkOnly, "Thắng");
				//tang diem cho quan den
				rbtRed.Checked = true;
				black_score++;
				set_score();
				btNew.Enabled = true;
				red1.Visible = false;
				red2.Visible = false;
				playing = false;
			}
			choose = 0;
			banco_MouseClick(sender, e);
		}
		public void red_go()
		{
			black1.Enabled = false;
			black2.Enabled = false;
			u.depth = 0;
			u.BPlaying = false;
			u.curr_state = curr_black[0] * 1000 + curr_black[1] * 100 + curr_red[0] * 10 + curr_red[1];
			u.value = -2;
			find_path.Find_path(u, user_depth);
		}
		
		
		public void bt_reset_Click(System.Object sender, System.EventArgs e)
		{
			//kiem tra xem co dang choi hay ko
			if ((Interaction.MsgBox("Do you want to reset?", MsgBoxStyle.OkCancel, "Message") == MsgBoxResult.Cancel) && playing)
			{
				return;
			}
			rbtBlack.Enabled = true;
			rbtRed.Enabled = true;
			rbtChick.Enabled = true;
			rbtPro.Enabled = true;
			rbtPrem.Enabled = true;
			rbtBlack.Checked = true;
			rbtChick.Checked = true;
			rbtRed.Checked = false;
			reset();
			btNew.Enabled = true;
			black_score = 0;
			red_score = 0;
			set_score();
			playing = false;
			//giau cac quan co
			black1.Visible = false;
			black2.Visible = false;
			red1.Visible = false;
			red2.Visible = false;
			hide_cell();
		}
		
		private void hide_cell()
		{
			//khong cho hien cac duong di
			cell1.Visible = false;
			cell2.Visible = false;
			cell3.Visible = false;
			cell4.Visible = false;
			cell5.Visible = false;
			cell6.Visible = false;
			cell7.Visible = false;
			cell8.Visible = false;
			cell9.Visible = false;
			//k cho ng dung tac dong
			cell1.Enabled = false;
			cell2.Enabled = false;
			cell3.Enabled = false;
			cell4.Enabled = false;
			cell5.Enabled = false;
			cell6.Enabled = false;
			cell7.Enabled = false;
			cell8.Enabled = false;
			cell9.Enabled = false;
		}
		private void show_cell(int pos)
		{
			switch (pos)
			{
				case 1:
					cell1.Visible = true;
					break;
				case 2:
					cell2.Visible = true;
					break;
				case 3:
					cell3.Visible = true;
					break;
				case 4:
					cell4.Visible = true;
					break;
				case 5:
					cell5.Visible = true;
					break;
				case 6:
					cell6.Visible = true;
					break;
				case 7:
					cell7.Visible = true;
					break;
				case 8:
					cell8.Visible = true;
					break;
				case 9:
					cell9.Visible = true;
					break;
			}
		}
		public void show_path()
		{
			if (choose == 1)
			{
				if ((curr_black[0] + 1 != curr_black[1]) && (curr_black[0] + 1 != curr_red[0]) && (curr_black[0] + 1 != curr_red[1]) && (curr_black[0] % 3 != 0))
				{
					show_cell(curr_black[0] + 1);
				}
				if ((curr_black[0] + 3 != curr_black[1]) && (curr_black[0] + 3 != curr_red[0]) && (curr_black[0] + 3 != curr_red[1]))
				{
					show_cell(curr_black[0] + 3);
				}
				if ((curr_black[0] - 3 != curr_black[1]) && (curr_black[0] - 3 != curr_red[0]) && (curr_black[0] - 3 != curr_red[1]))
				{
					show_cell(curr_black[0] - 3);
				}
				
			}
			else if (choose == 2)
			{
				if ((curr_black[1] + 1 != curr_black[0]) && (curr_black[1] + 1 != curr_red[0]) && (curr_black[1] + 1 != curr_red[1]) && (curr_black[1] % 3 != 0))
				{
					show_cell(curr_black[1] + 1);
				}
				if ((curr_black[1] + 3 != curr_black[0]) && (curr_black[1] + 3 != curr_red[0]) && (curr_black[1] + 3 != curr_red[1]))
				{
					show_cell(curr_black[1] + 3);
				}
				if ((curr_black[1] - 3 != curr_black[0]) && (curr_black[1] - 3 != curr_red[0]) && (curr_black[1] - 3 != curr_red[1]))
				{
					show_cell(curr_black[1] - 3);
				}
			}
		}
	}
	
}
