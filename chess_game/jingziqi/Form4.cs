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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name1 = textBox1.Text;
            string name2 = textBox2.Text;
            Form2 form2 = new Form2(name1,name2);
            form2.Show();
            this.Close();
        }
    }
}
