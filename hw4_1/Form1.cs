namespace _4_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int[] password = new int[4];

        public void CreatePassword()
        {
            for (int i = 0; i < 4; i++)
            {
                Random rd = new Random();
                password[i] = rd.Next(0, 10);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CreatePassword();
            label1.Text = "";
            //label1.Text = (password[0].ToString() + password[1].ToString() + password[2].ToString() + password[3].ToString());

            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "解鎖";
            button1.ImageList = imageList1;
            button1.ImageIndex = 0;
            button2.ImageList = imageList1;
            button2.ImageIndex = 0;
            button3.ImageList = imageList1;
            button3.ImageIndex = 0;
            button4.ImageList = imageList1;
            button4.ImageIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.ImageIndex = (button1.ImageIndex + 1) % 10;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.ImageIndex = (button2.ImageIndex + 1) % 10;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.ImageIndex = (button3.ImageIndex + 1) % 10;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.ImageIndex = (button4.ImageIndex + 1) % 10;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int cheak = 0;
            if (button1.ImageIndex == password[0])
            {
                cheak++;
            }
            if (button2.ImageIndex == password[1])
            {
                cheak++;
            }
            if (button3.ImageIndex == password[2])
            {
                cheak++;
            }
            if (button4.ImageIndex == password[3])
            {
                cheak++;
            }

            if (cheak == 4)
            {
                MessageBox.Show("解鎖成功 !", "成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                DialogResult result = MessageBox.Show("猜對" + cheak + "個位置", "失敗", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Retry)
                {
                    ;
                }
                else if (result == DialogResult.Cancel)
                {
                    MessageBox.Show("答案是" + password[0] + password[1] + password[2] + password[3], "", MessageBoxButtons.OK);
                }
            }

            cheak = 0;
        }
    }
}