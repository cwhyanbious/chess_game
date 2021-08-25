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
    public partial class Form2 : Form
    {
        int[][] chessArray = new int[3][];
        string result1, result2, result3;
        string player1, player2;
        
        public Form2(string name1,string name2)
        {
            InitializeComponent();
            player1 = name1;
            player2 = name2;
            toolStripStatusLabel1.Text= "请" + name1 + "下棋";
            toolStripStatusLabel2.Text="请" + name2 + "下棋";
            result1 = "游戏结束，" + name1 + "获胜";
            result2= "游戏结束，" + name2 + "获胜";
            result3 = "游戏结束，双方打平";
            statusStrip1.Visible = true;
            statusStrip2.Visible = false;
            chessArray[0] = new int[] { 0, 0, 0 };
            chessArray[1] = new int[] { 0, 0, 0 };
            chessArray[2] = new int[] { 0, 0, 0 };
            //label1.Text = "请" + name1 + "下棋";
            //label2.Text = "请" + name2 + "下棋";
            //label1.Visible = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private int Ifwin()//判断获胜函数
        {
            for (int i = 0; i <= 2; i++)
            {
                if ((chessArray[i][0]+chessArray[i][1]+chessArray[i][2] == 3) || (chessArray[0][i]+chessArray[1][i]+chessArray[2][i] == 3)|| (chessArray[0][0]+chessArray[1][1]+chessArray[2][2] == 3) || (chessArray[2][0]+chessArray[1][1]+chessArray[0][2] == 3))
                {
                    return 1;
                }
                if ((chessArray[i][0] + chessArray[i][1] + chessArray[i][2] == -3) || (chessArray[0][i] + chessArray[1][i] + chessArray[2][i] == -3)|| (chessArray[0][0] + chessArray[1][1] + chessArray[2][2] == -3) || (chessArray[2][0] + chessArray[1][1] + chessArray[0][2] == -3))
                {
                    return -1;
                } 
                if(chessArray [0][2]+chessArray[1][2]+chessArray[2][2]==3|| chessArray[2][0] + chessArray[2][1] + chessArray[2][2] == 3)
                {
                    return 1;
                }
                if (chessArray[0][2] + chessArray[1][2] + chessArray[2][2] == -3 || chessArray[2][0] + chessArray[2][1] + chessArray[2][2] == -3)
                {
                    return -1;
                }
                return 0;
            }
            return 0;
        }
        private int Iftie()
        {
            if (chessArray[0][0] * chessArray[0][1] * chessArray[0][2] * chessArray[1][0] * chessArray[1][1] * chessArray[1][2] * chessArray[2][0] * chessArray[2][1] * chessArray[2][2] != 0)
            {
                return 1;
            }
            return 0;
        }
        private int Judge()
        {
            int bool1 = Ifwin();
            int bool2 = Iftie();
            if (bool1 == 1)
            {
                DialogResult r = MessageBox.Show(result1, "tips", MessageBoxButtons.OK);
                jingziqi.Record re = new jingziqi.Record();
                re.record("玩家对战："+player1+" VS "+player2 + DateTime.Now.ToString() + " " + result1);
                if (r == DialogResult.OK)
                {
                    this.Close();
                    return 1;
                }

            }
            if (bool1 == -1)
            {
                DialogResult r = MessageBox.Show(result2, "tips", MessageBoxButtons.OK);
                jingziqi.Record re = new jingziqi.Record();
                re.record("玩家对战：" + player1 + " VS " + player2 + DateTime.Now.ToString() + " " + result2);
                if (r == DialogResult.OK)
                {
                    this.Close();
                    return 1;

                }
            }
            if (bool2 == 1)
            {
                DialogResult r = MessageBox.Show(result3, "tips", MessageBoxButtons.OK);
                jingziqi.Record re = new jingziqi.Record();
                re.record("玩家对战：" + player1 + " VS " + player2 +" "+ DateTime.Now.ToString() + " " + result3);
                if (r == DialogResult.OK)
                {
                    this.Close();
                    return 1;

                }
            }
            return 0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
           if(statusStrip1.Visible==true) //label1.Visible == true
            {
                button2.Text = "X";
                statusStrip1.Visible = false;
                statusStrip2.Visible = true;
                //label1.Visible = false;
                //label2.Visible = true;
                button2.Enabled = false;
                chessArray[0][1] = 1;
                Judge();
            }
           else if (statusStrip2.Visible==true) //label2.Visible == true
            {
                button2.Text = "O";
                statusStrip1.Visible = true;
                statusStrip2.Visible = false;
                // label2.Visible = false;
                // label1.Visible = true;
                button2.Enabled = false;
                chessArray[0][1] = -1;
                Judge();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (statusStrip1.Visible == true)
            {
                button1.Text = "X";
                statusStrip1.Visible = false;
                statusStrip2.Visible = true;
                //label1.Visible = false;
                //label2.Visible = true;
                button1.Enabled = false;
                chessArray[0][0] = 1;
                Judge();
            }
            else if (statusStrip2.Visible == true)
            {
                button1.Text = "O";
                statusStrip1.Visible = true;
                statusStrip2.Visible = false;
                //label2.Visible = false;
                // label1.Visible = true;
                button1.Enabled = false;
                chessArray[0][0] = -1;
                Judge();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (statusStrip1.Visible == true)
            {
                button3.Text = "X";
                statusStrip1.Visible = false;
                statusStrip2.Visible = true;
                //label1.Visible = false;
                //label2.Visible = true;
                button3.Enabled = false;
                chessArray[0][2] = 1;
                Judge();
            }
            else if (statusStrip2.Visible == true)
            {
                button3.Text = "O";
                statusStrip1.Visible = true;
                statusStrip2.Visible = false;
                //label2.Visible = false;
                //label1.Visible = true;
                button3.Enabled = false;
                chessArray[0][2] = -1;
                Judge();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (statusStrip1.Visible == true)
            {
                button4.Text = "X";
                statusStrip1.Visible = false;
                statusStrip2.Visible = true;
                //label1.Visible = false;
                // label2.Visible = true;
                button4.Enabled = false;
                chessArray[1][0] = 1;
                Judge();
            }
            else if (statusStrip2.Visible == true)
            {
                button4.Text = "O";
                statusStrip1.Visible = true;
                statusStrip2.Visible = false;
                //label2.Visible = false;
                // label1.Visible = true;
                button4.Enabled = false;
                chessArray[1][0] = -1;
                Judge();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (statusStrip1.Visible == true)
            {
                button5.Text = "X";
                statusStrip1.Visible = false;
                statusStrip2.Visible = true;
                //label1.Visible = false;
                //label2.Visible = true;
                button5.Enabled = false;
                chessArray[1][1] = 1;
                Judge();
            }
            else if (statusStrip2.Visible == true)
            {
                button5.Text = "O";
                statusStrip1.Visible = true;
                statusStrip2.Visible = false;
                //label2.Visible = false;
                //label1.Visible = true;
                button5.Enabled = false;
                chessArray[1][1] = -1;
                Judge();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (statusStrip1.Visible == true)
            {
                button6.Text = "X";
                statusStrip1.Visible = false;
                statusStrip2.Visible = true;
                // label1.Visible = false;
                //label2.Visible = true;
                button6.Enabled = false;
                chessArray[1][2] = 1;
                Judge();
            }
            else if (statusStrip2.Visible == true)
            {
                button6.Text = "O";
                statusStrip1.Visible = true;
                statusStrip2.Visible = false;
                //label2.Visible = false;
                //label1.Visible = true;
                button6.Enabled = false;
                chessArray[1][2] = -1;
                Judge();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (statusStrip1.Visible == true)
            {
                button7.Text = "X";
                statusStrip1.Visible = false;
                statusStrip2.Visible = true;
                // label1.Visible = false;
                //label2.Visible = true;
                button7.Enabled = false;
                chessArray[2][0] = 1;
                Judge();
            }
            else if (statusStrip2.Visible == true)
            {
                button7.Text = "O";
                statusStrip1.Visible = true;
                statusStrip2.Visible = false;
                //label2.Visible = false;
                //label1.Visible = true;
                button7.Enabled = false;
                chessArray[2][0] = -1;
                Judge();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (statusStrip1.Visible == true)
            {
                button8.Text = "X";
                statusStrip1.Visible = false;
                statusStrip2.Visible = true;
                // label1.Visible = false;
                // label2.Visible = true;
                button8.Enabled = false;
                chessArray[2][1] = 1;
                Judge();
            }
            else if (statusStrip2.Visible == true)
            {
                button8.Text = "O";
                statusStrip1.Visible = true;
                statusStrip2.Visible = false;
                //label2.Visible = false;
                //label1.Visible = true;
                button8.Enabled = false;
                chessArray[2][1] = -1;
                Judge();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (statusStrip1.Visible == true)
            {
                button9.Text = "X";
                statusStrip1.Visible = false;
                statusStrip2.Visible = true;
                //label1.Visible = false;
                // label2.Visible = true;
                button9.Enabled = false;
                chessArray[2][2] = 1;
                Judge();
            }
            else if (statusStrip2.Visible == true)
            {
                button9.Text = "O";
                statusStrip1.Visible = true;
                statusStrip2.Visible = false;
                //label2.Visible = false;
                //label1.Visible = true;
                button9.Enabled = false;
                chessArray[2][2] = -1;
                Judge();
            }
        }
    }
}
