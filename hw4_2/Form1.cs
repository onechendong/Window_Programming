

using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography;

namespace _4_2
{
    public partial class Form1 : Form
    {
        private List<Button> btn_list = new List<Button>();
        public int money = 100, seed = 5, fertilizer = 5, fruit = 0;
        public bool have_watter = false, have_seed = false, have_fertilizer = false, have_sickle = false;
        public bool[] already_water = { false, false, false, false, false, false, false, false, false, false, false, false, false, false };
        public bool[] already_fertilizer = { false, false, false, false, false, false, false, false, false, false, false, false, false, false };
        public bool[] already_seed = { false, false, false, false, false, false, false, false, false, false, false, false, false, false };
        public int[] land_state = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0};
        public Form1()
        {
            InitializeComponent();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = money.ToString();
            label4.Text = seed.ToString();
            label6.Text = fertilizer.ToString();
            label8.Text = fruit.ToString();

            //creat button list
            int row_cnt = 4;
            int col_cnt = 3;
            int btn_width = 100;
            int btn_height = 100;

            for (int row = 0; row < row_cnt; row++)
            {
                for (int col = 0; col < col_cnt; col++)
                {
                    Button btn = new Button();

                    btn.Text = "";
                    btn.SetBounds(9 + col * btn_width, 6 + row * btn_height, btn_width, btn_height);
                    btn.Name = "btn" + (row * col_cnt + col + 1);
                    btn.Image = imageList1.Images[0];

                    btn.Click += new EventHandler(btn_Click);

                    tabPage1.Controls.Add(btn);
                    btn_list.Add(btn);

                }
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button click_button = sender as Button;
            string btn_name = click_button.Name;
            switch (btn_name)
            {
                case "btn1":
                    ActionToButton(1);
                    click_button.Image = imageList1.Images[land_state[1]];
                    break;

                case "btn2":
                    ActionToButton(2);
                    click_button.Image = imageList1.Images[land_state[2]];
                    break;

                case "btn3":
                    ActionToButton(3);
                    click_button.Image = imageList1.Images[land_state[3]];
                    break;

                case "btn4":
                    ActionToButton(4);
                    click_button.Image = imageList1.Images[land_state[4]];
                    break;

                case "btn5":
                    ActionToButton(5);
                    click_button.Image = imageList1.Images[land_state[5]];
                    break;

                case "btn6":
                    ActionToButton(6);
                    click_button.Image = imageList1.Images[land_state[6]];
                    break;

                case "btn7":
                    ActionToButton(7);
                    click_button.Image = imageList1.Images[land_state[7]];
                    break;

                case "btn8":
                    ActionToButton(8);
                    click_button.Image = imageList1.Images[land_state[8]];
                    break;

                case "btn9":
                    ActionToButton(9);
                    click_button.Image = imageList1.Images[land_state[9]];
                    break;

                case "btn10":
                    ActionToButton(10);
                    click_button.Image = imageList1.Images[land_state[10]];
                    break;

                case "btn11":
                    ActionToButton(11);
                    click_button.Image = imageList1.Images[land_state[11]];
                    break;

                case "btn12":
                    ActionToButton(12);
                    click_button.Image = imageList1.Images[land_state[12]];
                    break;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                if (seed <= 0)
                {
                    MessageBox.Show("種子用完了", "警告", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    radioButton2.Checked = false;
                }
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                if (fertilizer <= 0)
                {
                    MessageBox.Show("肥料用完了", "警告", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    radioButton3.Checked = false;
                }
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void ActionToButton(int i)
        {
            if (radioButton1.Checked == true)
            {
                if (already_seed[i] == true && already_water[i] == false && land_state[i] != 0 && land_state[i] != 3)
                {
                    already_water[i] = true;
                    radioButton1.Checked = false;
                }
            }
            else if (radioButton2.Checked == true)
            {
                if (land_state[i] == 0)
                {
                    already_seed[i] = true;
                    land_state[i]++;
                    radioButton2.Checked = false;
                    seed--;
                }
            }
            else if (radioButton3.Checked == true)
            {
                if (already_seed[i] == true && already_fertilizer[i] == false && land_state[i] != 0 && land_state[i] != 3)
                {
                    already_fertilizer[i] = true;
                    radioButton3.Checked = false;
                    fertilizer--;
                }
            }
            else if (radioButton4.Checked == true)
            {
                if (land_state[i] == 3)
                {
                    fruit++;
                    land_state[i] = 0;
                    already_seed[i] = false;
                    already_fertilizer[i] = false;
                    already_water[i] = false;
                    radioButton4.Checked = false;
                }
            }

            if (already_water[i] == true && already_fertilizer[i] == true)
            {
                land_state[i]++;
                already_water[i] = false;
                already_fertilizer[i] = false;
            }
            //click_button.Image = imageList1.Images[land_state[1]];
            label4.Text = seed.ToString();
            label6.Text = fertilizer.ToString();
            label8.Text = fruit.ToString();
        }
        private void button13_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                if (fruit > 0)
                {
                    fruit -= 1;
                    money += 40;
                }
            }
            if(checkBox1.Checked == true)
            {
                if (money >= 10)
                {
                    seed += 1;
                    money-= 10;
                }
            }
            if (checkBox2.Checked == true)
            {
                if(money >= 10)
                {
                    fertilizer += 1;
                    money -= 10;
                }
            }
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            label2.Text = money.ToString();
            label4.Text = seed.ToString();
            label6.Text = fertilizer.ToString();
            label8.Text = fruit.ToString();
        }
    }
}