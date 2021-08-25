using chess_game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jingziqi
{
    public partial class Form6 : Form
    {
        public int diff = 2;
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            diff = 2;
            Form1 form1 = new Form1(this);
            form1.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            diff = 3;
            Form1 form1 = new Form1(this);
            form1.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            diff = 4;
            Form1 form1 = new Form1(this);
            form1.Show();
            this.Close();
        }
    }
}
