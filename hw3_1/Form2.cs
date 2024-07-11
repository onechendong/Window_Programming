using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        readonly string[] analysis = { "桃花運大漲", "家庭遭逢變故", "事業平步青雲，有升官可能", "事業起伏大", "親人病情好轉", "被財神眷顧", "近期一帆風順" };
        readonly string[] suggest = { "少做壞事，夜路走多了總匯三明治",
                     "保持謙虛，一山還有一山高，雞蛋還有雞蛋糕",
                     "善待他人，不要任意嘲笑別人，除非你忍不住",
                     "早點睡覺，不要仗著自己長得醜，就任意熬夜",
                     "小心小人，可謂浮雲能蔽日，輕舟已過萬重山",
                     "不要偷懶，你在睡覺的時候，美國人還在上班阿",
                     "健康第一，定期身體檢查並謹記醫生怎麼說，doctor!",
                     "穩定情緒，今天不開心沒關係，反正明天也不會開心"};
        private void Form2_Load(object sender, EventArgs e)
        {
            label3.Text = Program.name;
            label4.Text = Program.gender;
            label6.Text = Program.birthday;
            label8.Text = Program.today;
            label10.Text = Program.pet;

            Random rd = new Random();
            label12.Text = analysis[rd.Next(8)];
            label13.Text = suggest[rd.Next(8)];
        }
    }
}
