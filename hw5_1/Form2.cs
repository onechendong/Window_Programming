using Microsoft.VisualBasic;
using new_5_1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace _5_1
{
    public partial class Form2 : Form
    {
        private List<Button> btn_list = new List<Button>();
        private int num=0, num2=-1;
        private int[] arr_num = new int[3];
        private Random rd = new Random();
        private int msg = 1;
        public Form2()
        {
            InitializeComponent();
        }

        private void RandomButton()
        {
            for (int i = 0; i < 3; i++)
            {
                int tmp = rd.Next(1, 36);
                arr_num[i] = GetNum(i, tmp);
            }
        }
        public int GetNum(int index, int x)
        {
            for (int j = 0; j < index; j++)
            {
                if (x == arr_num[j])
                {
                    x = rd.Next(1, 36);
                    return GetNum(index, x);
                }
            }
            return x;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = "";
            label3.Text = "";
            //出題
            RandomButton();

            //creat button list
            int row_cnt = 3;
            int col_cnt = 12;
            int btn_width = 40;
            int btn_height = 40;
            for (int row = 0; row < row_cnt; row++)
            {
                for (int col = 0; col < col_cnt; col++)
                {
                    Button btn = new Button();

                    btn.SetBounds(150 + col * btn_width, 185 + row * btn_height, btn_width, btn_height);
                    btn.Name = (row * col_cnt + col + 1).ToString();
                    btn.BackColor = Color.White;
                    if (row * col_cnt + col > -1 && row * col_cnt + col < 10)//0~9
                    {
                        btn.Text = (row * col_cnt + col).ToString();
                    }
                    else
                    {
                        btn.Text = (Convert.ToChar('A' + row * col_cnt + col - 10)).ToString();
                    }

                    btn.Click += new EventHandler(btn_Click);

                    //亮綠
                    if (int.Parse(btn.Name) == arr_num[0] || int.Parse(btn.Name) == arr_num[1] || int.Parse(btn.Name) == arr_num[2])
                    {
                        btn.BackColor = Color.LightGreen;
                    }

                    this.Controls.Add(btn);
                    btn_list.Add(btn);
                }
            }

            //開始倒數(記憶)
            timer1.Enabled = true;
            num = 5;
            timer1.Interval = 1000;

        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (num2!>-1)
            {
                if (clickedButton != null)
                {
                    //亮藍
                    clickedButton.BackColor = Color.LightBlue;
                }
            }

        }

        private void GamerTime()
        {
            label1.Text = "玩家階段";
            foreach (Button bt in btn_list)
            {
                bt.BackColor = Color.White;
            }
            //開始倒數(玩家猜)
            timer2.Enabled = true;
            num2 = 5;
            timer2.Interval = 1000;

            

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = num.ToString();
            if (num == -1)
            {
                timer1.Enabled = false;
                label2.Text = "";
                GamerTime();
            }
            num--;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // 關閉程式
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label2.Text = num2.ToString();
            if (num2 == 0)
            {
                timer2.Enabled = false;
                //對答案
                foreach (Button btn in btn_list)
                {
                    if (btn.BackColor == Color.LightBlue)
                    {
                        foreach (int i in arr_num)
                        {
                            if (btn.Name == i.ToString())
                            {
                                btn.BackColor = Color.LightGreen;
                            }
                        }
                        if (btn.BackColor == Color.LightBlue)
                        {
                            btn.BackColor = Color.Red;
                        }
                    }
                    else if (btn.BackColor == Color.White)
                    {
                        foreach (int i in arr_num)
                        {
                            if (btn.Name == i.ToString())
                            {
                                btn.BackColor = Color.Red;
                            }
                        }
                    }

                }

                //messagebox
                foreach (var item in btn_list)
                {
                    if (item.BackColor == Color.Red)
                    {
                        msg = 0;
                    }
                }
                if (msg == 0)
                {
                    DialogResult result = MessageBox.Show("You Lose!\nTry again", "", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        Form1 form1 = new Form1();
                        form1.Show();
                        form1.FormClosed += (s, args) => { this.Close(); };
                        this.Hide();
                    }
                }
                else if (msg == 1)
                {
                    DialogResult result = MessageBox.Show("You Win", "", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        Form1 form1 = new Form1();
                        form1.Show();
                        form1.FormClosed += (s, args) => { this.Close(); };
                        this.Hide();
                    }
                }

            }
            num2--;
        }
    }
}


