// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports

using Dodgem;

namespace Dodgem
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class Form1 : System.Windows.Forms.Form
	{
		
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]protected override void Dispose(bool disposing)  {
			if (disposing && components != null)  {
					components.Dispose();
			}
			base.Dispose(disposing);
		}
		
		//Required by the Windows Form Designer
		private System.ComponentModel.Container components = null;
		
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()  {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.rbtRed = new System.Windows.Forms.RadioButton();
            this.rbtBlack = new System.Windows.Forms.RadioButton();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.rbtPrem = new System.Windows.Forms.RadioButton();
            this.rbtPro = new System.Windows.Forms.RadioButton();
            this.rbtChick = new System.Windows.Forms.RadioButton();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.banco = new System.Windows.Forms.Panel();
            this.cell8 = new System.Windows.Forms.PictureBox();
            this.cell2 = new System.Windows.Forms.PictureBox();
            this.cell9 = new System.Windows.Forms.PictureBox();
            this.black2 = new System.Windows.Forms.PictureBox();
            this.black1 = new System.Windows.Forms.PictureBox();
            this.cell1 = new System.Windows.Forms.PictureBox();
            this.cell7 = new System.Windows.Forms.PictureBox();
            this.cell4 = new System.Windows.Forms.PictureBox();
            this.cell5 = new System.Windows.Forms.PictureBox();
            this.cell6 = new System.Windows.Forms.PictureBox();
            this.cell3 = new System.Windows.Forms.PictureBox();
            this.red2 = new System.Windows.Forms.PictureBox();
            this.red1 = new System.Windows.Forms.PictureBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.blackout = new System.Windows.Forms.PictureBox();
            this.redout = new System.Windows.Forms.PictureBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.bt_how = new System.Windows.Forms.Button();
            this.bt_reset = new System.Windows.Forms.Button();
            this.BtExit = new System.Windows.Forms.Button();
            this.btNew = new System.Windows.Forms.Button();
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.re_score = new System.Windows.Forms.Label();
            this.bl_score = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.banco.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cell8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cell2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cell9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.black2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.black1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cell1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cell7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cell4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cell5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cell6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cell3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.red2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.red1)).BeginInit();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blackout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redout)).BeginInit();
            this.GroupBox3.SuspendLayout();
            this.GroupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.GroupBox5);
            this.GroupBox1.Controls.Add(this.GroupBox4);
            this.GroupBox1.Location = new System.Drawing.Point(16, 15);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox1.Size = new System.Drawing.Size(267, 249);
            this.GroupBox1.TabIndex = 2;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Tuỳ chọn";
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.rbtRed);
            this.GroupBox5.Controls.Add(this.rbtBlack);
            this.GroupBox5.Location = new System.Drawing.Point(24, 156);
            this.GroupBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox5.Size = new System.Drawing.Size(219, 74);
            this.GroupBox5.TabIndex = 2;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Người chơi trước";
            // 
            // rbtRed
            // 
            this.rbtRed.AutoSize = true;
            this.rbtRed.Location = new System.Drawing.Point(107, 28);
            this.rbtRed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtRed.Name = "rbtRed";
            this.rbtRed.Size = new System.Drawing.Size(47, 21);
            this.rbtRed.TabIndex = 1;
            this.rbtRed.TabStop = true;
            this.rbtRed.Text = "Đỏ";
            this.rbtRed.UseVisualStyleBackColor = true;
            // 
            // rbtBlack
            // 
            this.rbtBlack.AutoSize = true;
            this.rbtBlack.Checked = true;
            this.rbtBlack.Location = new System.Drawing.Point(16, 28);
            this.rbtBlack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtBlack.Name = "rbtBlack";
            this.rbtBlack.Size = new System.Drawing.Size(55, 21);
            this.rbtBlack.TabIndex = 0;
            this.rbtBlack.TabStop = true;
            this.rbtBlack.Text = "Đen";
            this.rbtBlack.UseVisualStyleBackColor = true;
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.rbtPrem);
            this.GroupBox4.Controls.Add(this.rbtPro);
            this.GroupBox4.Controls.Add(this.rbtChick);
            this.GroupBox4.Location = new System.Drawing.Point(24, 36);
            this.GroupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox4.Size = new System.Drawing.Size(219, 95);
            this.GroupBox4.TabIndex = 1;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Cấp độ";
            // 
            // rbtPrem
            // 
            this.rbtPrem.AutoSize = true;
            this.rbtPrem.Location = new System.Drawing.Point(17, 57);
            this.rbtPrem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtPrem.Name = "rbtPrem";
            this.rbtPrem.Size = new System.Drawing.Size(102, 21);
            this.rbtPrem.TabIndex = 2;
            this.rbtPrem.TabStop = true;
            this.rbtPrem.Text = "Ngoại hạng";
            this.rbtPrem.UseVisualStyleBackColor = true;
            // 
            // rbtPro
            // 
            this.rbtPro.AutoSize = true;
            this.rbtPro.Location = new System.Drawing.Point(107, 23);
            this.rbtPro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtPro.Name = "rbtPro";
            this.rbtPro.Size = new System.Drawing.Size(78, 21);
            this.rbtPro.TabIndex = 1;
            this.rbtPro.TabStop = true;
            this.rbtPro.Text = "Cao thủ";
            this.rbtPro.UseVisualStyleBackColor = true;
            // 
            // rbtChick
            // 
            this.rbtChick.AutoSize = true;
            this.rbtChick.Location = new System.Drawing.Point(17, 23);
            this.rbtChick.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtChick.Name = "rbtChick";
            this.rbtChick.Size = new System.Drawing.Size(75, 21);
            this.rbtChick.TabIndex = 0;
            this.rbtChick.TabStop = true;
            this.rbtChick.Text = "Gà con";
            this.rbtChick.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label1.Location = new System.Drawing.Point(96, 0);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(4, 266);
            this.Label1.TabIndex = 2;
            // 
            // Label2
            // 
            this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label2.Location = new System.Drawing.Point(192, 0);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(4, 266);
            this.Label2.TabIndex = 3;
            // 
            // Label3
            // 
            this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label3.Location = new System.Drawing.Point(0, 89);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(288, 4);
            this.Label3.TabIndex = 3;
            // 
            // Label4
            // 
            this.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label4.Location = new System.Drawing.Point(0, 177);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(288, 4);
            this.Label4.TabIndex = 4;
            // 
            // banco
            // 
            this.banco.BackColor = System.Drawing.Color.BurlyWood;
            this.banco.Controls.Add(this.cell8);
            this.banco.Controls.Add(this.cell2);
            this.banco.Controls.Add(this.cell9);
            this.banco.Controls.Add(this.black2);
            this.banco.Controls.Add(this.black1);
            this.banco.Controls.Add(this.cell1);
            this.banco.Controls.Add(this.cell7);
            this.banco.Controls.Add(this.cell4);
            this.banco.Controls.Add(this.cell5);
            this.banco.Controls.Add(this.cell6);
            this.banco.Controls.Add(this.cell3);
            this.banco.Controls.Add(this.red2);
            this.banco.Controls.Add(this.red1);
            this.banco.Controls.Add(this.Label4);
            this.banco.Controls.Add(this.Label3);
            this.banco.Controls.Add(this.Label2);
            this.banco.Controls.Add(this.Label1);
            this.banco.Cursor = System.Windows.Forms.Cursors.Default;
            this.banco.Location = new System.Drawing.Point(53, 25);
            this.banco.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.banco.Name = "banco";
            this.banco.Size = new System.Drawing.Size(288, 266);
            this.banco.TabIndex = 1;
            this.banco.MouseDown += new System.Windows.Forms.MouseEventHandler(this.banco_MouseClick);
            // 
            // cell8
            // 
            this.cell8.BackColor = System.Drawing.Color.NavajoWhite;
            this.cell8.Location = new System.Drawing.Point(101, 182);
            this.cell8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cell8.Name = "cell8";
            this.cell8.Size = new System.Drawing.Size(87, 80);
            this.cell8.TabIndex = 8;
            this.cell8.TabStop = false;
            // 
            // cell2
            // 
            this.cell2.BackColor = System.Drawing.Color.NavajoWhite;
            this.cell2.Location = new System.Drawing.Point(101, 5);
            this.cell2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cell2.Name = "cell2";
            this.cell2.Size = new System.Drawing.Size(87, 80);
            this.cell2.TabIndex = 8;
            this.cell2.TabStop = false;
            // 
            // cell9
            // 
            this.cell9.BackColor = System.Drawing.Color.NavajoWhite;
            this.cell9.Location = new System.Drawing.Point(197, 182);
            this.cell9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cell9.Name = "cell9";
            this.cell9.Size = new System.Drawing.Size(87, 80);
            this.cell9.TabIndex = 8;
            this.cell9.TabStop = false;
            // 
            // black2
            // 
            this.black2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.black2.Image = ((System.Drawing.Image)(resources.GetObject("black2.Image")));
            this.black2.Location = new System.Drawing.Point(5, 94);
            this.black2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.black2.Name = "black2";
            this.black2.Size = new System.Drawing.Size(87, 80);
            this.black2.TabIndex = 6;
            this.black2.TabStop = false;
            this.black2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.black2_MouseClick);
            // 
            // black1
            // 
            this.black1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.black1.Image = ((System.Drawing.Image)(resources.GetObject("black1.Image")));
            this.black1.Location = new System.Drawing.Point(5, 5);
            this.black1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.black1.Name = "black1";
            this.black1.Size = new System.Drawing.Size(87, 80);
            this.black1.TabIndex = 5;
            this.black1.TabStop = false;
            this.black1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.black1_MouseClick);
            // 
            // cell1
            // 
            this.cell1.BackColor = System.Drawing.Color.NavajoWhite;
            this.cell1.Location = new System.Drawing.Point(5, 5);
            this.cell1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cell1.Name = "cell1";
            this.cell1.Size = new System.Drawing.Size(87, 80);
            this.cell1.TabIndex = 8;
            this.cell1.TabStop = false;
            // 
            // cell7
            // 
            this.cell7.BackColor = System.Drawing.Color.NavajoWhite;
            this.cell7.Location = new System.Drawing.Point(5, 182);
            this.cell7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cell7.Name = "cell7";
            this.cell7.Size = new System.Drawing.Size(87, 80);
            this.cell7.TabIndex = 8;
            this.cell7.TabStop = false;
            // 
            // cell4
            // 
            this.cell4.BackColor = System.Drawing.Color.NavajoWhite;
            this.cell4.Location = new System.Drawing.Point(5, 94);
            this.cell4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cell4.Name = "cell4";
            this.cell4.Size = new System.Drawing.Size(87, 80);
            this.cell4.TabIndex = 8;
            this.cell4.TabStop = false;
            // 
            // cell5
            // 
            this.cell5.BackColor = System.Drawing.Color.NavajoWhite;
            this.cell5.Location = new System.Drawing.Point(101, 94);
            this.cell5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cell5.Name = "cell5";
            this.cell5.Size = new System.Drawing.Size(87, 80);
            this.cell5.TabIndex = 8;
            this.cell5.TabStop = false;
            // 
            // cell6
            // 
            this.cell6.BackColor = System.Drawing.Color.NavajoWhite;
            this.cell6.Location = new System.Drawing.Point(197, 94);
            this.cell6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cell6.Name = "cell6";
            this.cell6.Size = new System.Drawing.Size(87, 80);
            this.cell6.TabIndex = 8;
            this.cell6.TabStop = false;
            // 
            // cell3
            // 
            this.cell3.BackColor = System.Drawing.Color.NavajoWhite;
            this.cell3.Location = new System.Drawing.Point(197, 5);
            this.cell3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cell3.Name = "cell3";
            this.cell3.Size = new System.Drawing.Size(87, 80);
            this.cell3.TabIndex = 8;
            this.cell3.TabStop = false;
            // 
            // red2
            // 
            this.red2.Image = ((System.Drawing.Image)(resources.GetObject("red2.Image")));
            this.red2.Location = new System.Drawing.Point(196, 182);
            this.red2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.red2.Name = "red2";
            this.red2.Size = new System.Drawing.Size(87, 80);
            this.red2.TabIndex = 7;
            this.red2.TabStop = false;
            // 
            // red1
            // 
            this.red1.Image = ((System.Drawing.Image)(resources.GetObject("red1.Image")));
            this.red1.Location = new System.Drawing.Point(101, 182);
            this.red1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.red1.Name = "red1";
            this.red1.Size = new System.Drawing.Size(87, 80);
            this.red1.TabIndex = 7;
            this.red1.TabStop = false;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.blackout);
            this.GroupBox2.Controls.Add(this.redout);
            this.GroupBox2.Controls.Add(this.banco);
            this.GroupBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.GroupBox2.Location = new System.Drawing.Point(325, 106);
            this.GroupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox2.Size = new System.Drawing.Size(403, 303);
            this.GroupBox2.TabIndex = 3;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Sàn đấu";
            this.GroupBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GroupBox2_MouseClick);
            // 
            // blackout
            // 
            this.blackout.Image = ((System.Drawing.Image)(resources.GetObject("blackout.Image")));
            this.blackout.Location = new System.Drawing.Point(349, 254);
            this.blackout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.blackout.Name = "blackout";
            this.blackout.Size = new System.Drawing.Size(40, 37);
            this.blackout.TabIndex = 3;
            this.blackout.TabStop = false;
            // 
            // redout
            // 
            this.redout.Image = ((System.Drawing.Image)(resources.GetObject("redout.Image")));
            this.redout.Location = new System.Drawing.Point(351, 25);
            this.redout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.redout.Name = "redout";
            this.redout.Size = new System.Drawing.Size(40, 37);
            this.redout.TabIndex = 2;
            this.redout.TabStop = false;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.bt_how);
            this.GroupBox3.Controls.Add(this.bt_reset);
            this.GroupBox3.Controls.Add(this.BtExit);
            this.GroupBox3.Controls.Add(this.btNew);
            this.GroupBox3.Location = new System.Drawing.Point(16, 281);
            this.GroupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox3.Size = new System.Drawing.Size(267, 128);
            this.GroupBox3.TabIndex = 4;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Thao tác";
            // 
            // bt_how
            // 
            this.bt_how.Location = new System.Drawing.Point(15, 74);
            this.bt_how.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_how.Name = "bt_how";
            this.bt_how.Size = new System.Drawing.Size(107, 32);
            this.bt_how.TabIndex = 2;
            this.bt_how.Text = "Cách chơi";
            this.bt_how.UseVisualStyleBackColor = true;
            // 
            // bt_reset
            // 
            this.bt_reset.Location = new System.Drawing.Point(136, 32);
            this.bt_reset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_reset.Name = "bt_reset";
            this.bt_reset.Size = new System.Drawing.Size(107, 32);
            this.bt_reset.TabIndex = 2;
            this.bt_reset.Text = "Reset";
            this.bt_reset.UseVisualStyleBackColor = true;
            this.bt_reset.Click += new System.EventHandler(this.bt_reset_Click);
            // 
            // BtExit
            // 
            this.BtExit.Location = new System.Drawing.Point(136, 74);
            this.BtExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtExit.Name = "BtExit";
            this.BtExit.Size = new System.Drawing.Size(107, 32);
            this.BtExit.TabIndex = 1;
            this.BtExit.Text = "Thoát";
            this.BtExit.UseVisualStyleBackColor = true;
            this.BtExit.Click += new System.EventHandler(this.BtExit_Click);
            // 
            // btNew
            // 
            this.btNew.Location = new System.Drawing.Point(15, 32);
            this.btNew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(107, 32);
            this.btNew.TabIndex = 0;
            this.btNew.Text = "Trò chơi mới";
            this.btNew.UseVisualStyleBackColor = true;
            this.btNew.Click += new System.EventHandler(this.btNew_Click);
            // 
            // GroupBox6
            // 
            this.GroupBox6.Controls.Add(this.Label7);
            this.GroupBox6.Controls.Add(this.re_score);
            this.GroupBox6.Controls.Add(this.bl_score);
            this.GroupBox6.Controls.Add(this.Label6);
            this.GroupBox6.Controls.Add(this.Label5);
            this.GroupBox6.Location = new System.Drawing.Point(325, 15);
            this.GroupBox6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox6.Size = new System.Drawing.Size(401, 91);
            this.GroupBox6.TabIndex = 5;
            this.GroupBox6.TabStop = false;
            this.GroupBox6.Text = "Tỉ số";
            // 
            // Label7
            // 
            this.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label7.Location = new System.Drawing.Point(197, 20);
            this.Label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(4, 62);
            this.Label7.TabIndex = 2;
            // 
            // re_score
            // 
            this.re_score.BackColor = System.Drawing.Color.SkyBlue;
            this.re_score.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.re_score.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.re_score.Location = new System.Drawing.Point(249, 38);
            this.re_score.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.re_score.Name = "re_score";
            this.re_score.Size = new System.Drawing.Size(84, 43);
            this.re_score.TabIndex = 1;
            this.re_score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bl_score
            // 
            this.bl_score.BackColor = System.Drawing.Color.SkyBlue;
            this.bl_score.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bl_score.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bl_score.Location = new System.Drawing.Point(65, 38);
            this.bl_score.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bl_score.Name = "bl_score";
            this.bl_score.Size = new System.Drawing.Size(84, 43);
            this.bl_score.TabIndex = 1;
            this.bl_score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(252, 18);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(72, 18);
            this.Label6.TabIndex = 0;
            this.Label6.Text = "Quân đỏ";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(61, 18);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(80, 18);
            this.Label5.TabIndex = 0;
            this.Label5.Text = "Quân đen";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(744, 434);
            this.Controls.Add(this.GroupBox6);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dodgem v1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.banco.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cell8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cell2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cell9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.black2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.black1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cell1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cell7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cell4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cell5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cell6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cell3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.red2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.red1)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.blackout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redout)).EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox6.ResumeLayout(false);
            this.GroupBox6.PerformLayout();
            this.ResumeLayout(false);

		}
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Panel banco;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.GroupBox GroupBox3;
		internal System.Windows.Forms.Button BtExit;
		internal System.Windows.Forms.Button btNew;
		internal System.Windows.Forms.GroupBox GroupBox5;
		internal System.Windows.Forms.GroupBox GroupBox4;
		internal System.Windows.Forms.RadioButton rbtPro;
		internal System.Windows.Forms.RadioButton rbtChick;
		internal System.Windows.Forms.RadioButton rbtPrem;
		internal System.Windows.Forms.RadioButton rbtRed;
		internal System.Windows.Forms.RadioButton rbtBlack;
		internal System.Windows.Forms.PictureBox black1;
		internal System.Windows.Forms.PictureBox black2;
		internal System.Windows.Forms.PictureBox red1;
		internal System.Windows.Forms.PictureBox red2;
		internal System.Windows.Forms.Button bt_how;
		internal System.Windows.Forms.Button bt_reset;
		internal System.Windows.Forms.PictureBox blackout;
		internal System.Windows.Forms.PictureBox redout;
		internal System.Windows.Forms.GroupBox GroupBox6;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.PictureBox cell8;
		internal System.Windows.Forms.PictureBox cell9;
		internal System.Windows.Forms.PictureBox cell1;
		internal System.Windows.Forms.PictureBox cell7;
		internal System.Windows.Forms.PictureBox cell4;
		internal System.Windows.Forms.PictureBox cell5;
		internal System.Windows.Forms.PictureBox cell6;
		internal System.Windows.Forms.PictureBox cell2;
		internal System.Windows.Forms.PictureBox cell3;
		internal System.Windows.Forms.Label re_score;
		internal System.Windows.Forms.Label bl_score;
		internal System.Windows.Forms.Label Label7;
		
	}
	
}
