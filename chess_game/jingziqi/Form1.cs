using jingziqi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chess_game
{
    public partial class Form1 : Form
    {
        Form6 form6 = new Form6();
        public Form1(Form6 f)
        {
            InitializeComponent();
            form6 = f;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
        }

        private void btnClickThis_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if (textBox1.Text.Length > 0 && textBox1.Text.Length < 10)
            {
                label2.Text = "Hi " + name;
                label3.Text = "欢迎加入我们的游戏，让我们开始游戏吧，你希望先手游戏吗？";
                label2.Visible = true;
                label3.Visible = true;
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                button1.Visible = true;
                btnClickThis.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if (radioButton1.Checked == true)
            {
                Form5 form5 = new Form5(name,this,form6);
                form5.Show();
            }
            else if (radioButton2.Checked == true)
            {
                Form5 form5 = new Form5(name,this,form6);
                form5.Show();
            }
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                this.btnClickThis.PerformClick();
            }
        }
    }
}
