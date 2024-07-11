using _5_1;

namespace new_5_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.FormClosed += (s, args) => { this.Close(); };
            form2.Show();
        }
    }
}