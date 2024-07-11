namespace _3_1
{

    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            label7.Text = "";

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "")
            {
                label7.Text = "此欄未填寫";
            }
            else
            {
                label7.Text = "";
                Program.name = textBox1.Text;
            }

            if (textBox2.Text == "")
            {
                label8.Text = "此欄未填寫";
            }
            else if (textBox2.Text != "男" && textBox2.Text != "女")
            {
                label8.Text = "輸入應為男or女";
            }
            else
            {
                label8.Text = "";
                Program.gender = textBox2.Text;
            }

            if (textBox3.Text == "")
            {
                label9.Text = "此欄未填寫";
            }
            else
            {
                label9.Text = "";
                Program.birthday=textBox3.Text;
            }

            if (textBox4.Text == "")
            {
                label10.Text = "此欄未填寫";
            }
            else
            {
                label10.Text = "";
                Program.today=textBox4.Text;
            }

            if (textBox5.Text == "")
            {
                label11.Text = "此欄未填寫";
            }
            else if (textBox5.Text != "貓" && textBox5.Text != "狗")
            {
                label11.Text = "輸入應為貓or狗";
            }
            else
            {
                label11.Text = "";
                Program.pet = textBox5.Text;
            }

            if(label7.Text==""&& label8.Text == "" && label9.Text == "" && label10.Text == "" && label11.Text == "")
            {
                Form2 f1 = new Form2();
                this.Hide();
                f1.Show();
            }
            
        }
    }
}