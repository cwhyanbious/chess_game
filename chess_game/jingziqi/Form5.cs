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
    public partial class Form5 : Form
    {
        Form6 f6 = new Form6();
        Form1 f1 = new Form1();
        int[][] chessArray = new int[3][];
        int[][] tempArray = new int[3][];
        object obj = new object();
        EventArgs ea = new EventArgs();
        string result1, result2, result3;
        string player;
        int depth;
        int chess = 0;
        int dep = 1;
       
        private int Ifwin()//判断获胜函数
        {
            for (int i = 0; i <= 2; i++)
            {
                if ((chessArray[i][0] + chessArray[i][1] + chessArray[i][2] == 3) || (chessArray[0][i] + chessArray[1][i] + chessArray[2][i] == 3) || (chessArray[0][0] + chessArray[1][1] + chessArray[2][2] == 3) || (chessArray[2][0] + chessArray[1][1] + chessArray[0][2] == 3))
                {
                    return 1;
                }
                if ((chessArray[i][0] + chessArray[i][1] + chessArray[i][2] == -3) || (chessArray[0][i] + chessArray[1][i] + chessArray[2][i] == -3) || (chessArray[0][0] + chessArray[1][1] + chessArray[2][2] == -3) || (chessArray[2][0] + chessArray[1][1] + chessArray[0][2] == -3))
                {
                    return -1;
                }

                //if (chessArray[0][2] + chessArray[1][2] + chessArray[2][2] == 3 || chessArray[2][0] + chessArray[2][1] + chessArray[2][2] == 3)
                //{
                //    return 1;
                //}
                //if (chessArray[0][2] + chessArray[1][2] + chessArray[2][2] == -3 || chessArray[2][0] + chessArray[2][1] + chessArray[2][2] == -3)
                //{
                //    return -1;
                //}
                //return 0;
            }
            return 0;
        }
        private int Iftie()
        {
            if(chessArray [0][0]* chessArray[0][1]*chessArray[0][2]*chessArray[1][0]*chessArray[1][1]*chessArray[1][2]*chessArray[2][0]*chessArray[2][1]*chessArray[2][2]!=0)
                    {
                return 1;
            }
            return 0;
        }
       
        public Form5(string name1,Form1 form1,Form6 form6)
        {
            InitializeComponent();
            player = name1;
            f1 = form1;
            f6 = form6;
            depth = f6.diff;
            chessArray[0] = new int[] { 0, 0, 0 };
            chessArray[1] = new int[] { 0, 0, 0 };
            chessArray[2] = new int[] { 0, 0, 0 };
            tempArray[0]= new int[] { 0, 0, 0 };
            tempArray[1] = new int[] { 0, 0, 0 };
            tempArray[2] = new int[] { 0, 0, 0 };
            toolStripStatusLabel1.Text = "请" + name1 + "下棋";
            toolStripStatusLabel2.Text = "请电脑下棋";
            result1 = "游戏结束，" + name1 + "获胜";
            result2 = "游戏结束，电脑获胜";
            result3 = "游戏结束，双方打平";
            if (f1.radioButton1.Checked==true)
            {
                statusStrip1.Visible = true;
                statusStrip2.Visible = false;
            }
            else
            {
                statusStrip2.Visible = true;
                statusStrip1.Visible = false;
                button5.Text = "O";
                statusStrip1.Visible = true;
                statusStrip2.Visible = false;
                //label2.Visible = false;
                //label1.Visible = true;
                button5.Enabled = false;
                //chessArray[1][1] = -1;
                computer();
            }
        }
        private int Judge()
        {
            int bool1 = Ifwin();
            int bool2 = Iftie();
            if (bool1 == 1)
            {
                DialogResult r = MessageBox.Show(result1, "tips", MessageBoxButtons.OK);
                jingziqi.Record re = new jingziqi.Record();
                re.record("人机对战：" + " 电脑 VS " + player + " " + DateTime.Now.ToString() + " " + result1);
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
                re.record("人机对战："+" 电脑 VS "+player+" "+DateTime.Now.ToString() + " " + result2);
                if (r == DialogResult.OK)
                {
                    this.Close();
                    return 1;

                }
            }
            if (bool2 ==1)
            {
                DialogResult r = MessageBox.Show(result3, "tips", MessageBoxButtons.OK);
                jingziqi.Record re = new jingziqi.Record();
                re.record("人机对战：" + " 电脑 VS " + player + " " + DateTime.Now.ToString() + " " + result3);
                if (r == DialogResult.OK)
                {
                    this.Close();
                    return 1;

                }
            }
            return 0;
        }
        private int evaluate()
        {
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (chessArray[i][j] == 0)
                    {
                        tempArray[i][j] = 1;
                    }
                    else
                    {
                        tempArray[i][j] = chessArray[i][j];
                    }
                }
            }
            for (int i = 0; i < 3; i++)
            {
                count-= (tempArray[i][0] + tempArray[i][1] + tempArray[i][2]) / 3;
            }
         
            for (int i = 0; i < 3; i++)
            {
                count-= (tempArray[0][i] + tempArray[1][i] + tempArray[2][i]) / 3;
            }         
            for (int i = 0; i < 3; i++)
            {
                count-= (tempArray[0][0] + tempArray[1][1] + tempArray[2][2]) / 3;
            }
            for (int i = 0; i < 3; i++)
            {
                count-= (tempArray[2][0] + tempArray[1][1] + tempArray[2][0]) / 3;
            }
   
             for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (chessArray[i][j] == 0)
                    {
                        tempArray[i][j] = -1;
                    }
                    else
                    {
                        tempArray[i][j] = chessArray[i][j];
                    }
                }
            }       
             for (int i = 0; i < 3; i++)
            {
                count-= (tempArray[i][0] + tempArray[i][1] + tempArray[i][2]) / 3;
            }
           
             for (int i = 0; i < 3; i++)
            {
                count-= (tempArray[0][i] + tempArray[1][i] + tempArray[2][i]) / 3;
            }
           
             for (int i = 0; i < 3; i++)
            {
                count-= (tempArray[0][0] + tempArray[1][1] + tempArray[2][2]) / 3;
            }
            for (int i = 0; i < 3; i++)
            {
                count-= (tempArray[2][0] + tempArray[1][1] + tempArray[2][0]) / 3;
            }

            return count;
        }
        private int cut(ref int val, int dep, bool max)
        {

            if (dep == depth || dep + chess == 9)
                return evaluate();
            int Curval;//本层值
            int Esti_val;//估计值
            bool ifcut = false;//是否剪枝
            if (max)
                Curval = 10000;
            else
                Curval = -10000;
            for (int i = 0; i < 3 && !ifcut; i++)
                for (int j = 0; j < 3 && !ifcut; j++)
                {
                    if (chessArray[i][j] == 0)
                    {
                        //人
                        if (max)
                        {
                            chessArray[i][j] = 1;
                            if (Ifwin() == 1)
                                Esti_val = -10000;
                            else
                                Esti_val = cut(ref Curval, dep + 1, !max);
                            if (Esti_val < Curval)
                                Curval = Esti_val;
                            if (Curval <= val)
                                ifcut = true;

                        }
                        //电脑
                        else
                        {
                            chessArray[i][j] = -1;
                            if (Ifwin() == -1)
                                Esti_val = 10000;
                            else
                                Esti_val = cut(ref Curval, dep + 1, !max);
                            if (Esti_val > Curval)
                                Curval = Esti_val;
                            if (Curval >= val)
                                ifcut = true;
                        }
                        chessArray[i][j] = 0;
                    }

                }
            if (max)
            {
                if (Curval > val)
                    val = Curval;
            }
            else
            {
                if (Curval < val)
                    val = Curval;
            }
            return Curval;
        }
        private void computer()
        {
            int maxval = -10000, val = -10000;
            int x_pos=new int();
            int y_pos= new int(); ;
            bool a = true;
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                {
                    if (chessArray[x][y] == 0)
                    {
                        chessArray[x][y] = -1;
                        cut(ref val, dep, a);
                        if (Ifwin() == -1)
                        {
                            x_pos = x;
                            y_pos = y;
                            chessArray[x_pos][y_pos] = -1;
                            break;
                        }
                        

                        if (val >= maxval)
                        {
                            maxval = val;
                            x_pos = x;
                            y_pos = y;
                        }
                        val = -10000;
                        //if (evaluate() == 0)
                        //    Judge();
                        chessArray[x][y] = 0;
                        
                    }
                }
            
            chessArray[x_pos][y_pos] = -1;
            computer_click(x_pos * 3, y_pos + 1);
            val = -10000;
            maxval = -10000;
            dep = 1;
        }
        
        private void computer_click(int a,int b)
        {
            switch (a + b)
            {
                case 1:
                    button1_Click(obj, ea);
                    break;
                case 2:
                    button2_Click(obj, ea);
                    break;
                case 3:
                    button3_Click(obj, ea);
                    break;
                case 4:
                    button4_Click(obj, ea);
                    break;
                case 5:
                    button5_Click(obj, ea);
                    break;
                case 6:
                    button6_Click(obj, ea);
                    break;
                case 7:
                    button7_Click(obj, ea);
                    break;
                case 8:
                    button8_Click(obj, ea);
                    break;
                case 9:
                    button9_Click(obj, ea);
                    break;
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
                chess++;
                if (Judge() == 1)
                {
                    return;
                }
                //Judge();
                computer();
                chess++;
            }
            else if (statusStrip2.Visible == true)
            {
                button1.Text = "O";
                statusStrip1.Visible = true;
                statusStrip2.Visible = false;
                //label2.Visible = false;
                // label1.Visible = true;
                button1.Enabled = false;
                Judge();
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (statusStrip1.Visible == true)
            {
                button2.Text = "X";
                statusStrip1.Visible = false;
                statusStrip2.Visible = true;
                //label1.Visible = false;
                //label2.Visible = true;
                button2.Enabled = false;
                chessArray[0][1] = 1;
                chess++;
                if (Judge() == 1)
                {
                    return;
                }
                //Judge();
                computer();
                chess++;
            }
            else if (statusStrip2.Visible == true)
            {
                button2.Text = "O";
                statusStrip1.Visible = true;
                statusStrip2.Visible = false;
                //label2.Visible = false;
                // label1.Visible = true;
                button2.Enabled = false;
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
                chess++;
                if (Judge() == 1)
                {
                    return;
                }
                //Judge();
                computer();
                chess++;
            }
            else if (statusStrip2.Visible == true)
            {
                button3.Text = "O";
                statusStrip1.Visible = true;
                statusStrip2.Visible = false;
                //label2.Visible = false;
                //label1.Visible = true;
                button3.Enabled = false;
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
                chess++;
                if (Judge() == 1)
                {
                    return;
                }
                //Judge();
                computer();
                chess++;
            }
            else if (statusStrip2.Visible == true)
            {
                button4.Text = "O";
                statusStrip1.Visible = true;
                statusStrip2.Visible = false;
                //label2.Visible = false;
                // label1.Visible = true;
                button4.Enabled = false;
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
                chess++;
                if (Judge() == 1)
                {
                    return;
                }
                //Judge();
                computer();
                chess++;
            }
            else if (statusStrip2.Visible == true)
            {
                button5.Text = "O";
                statusStrip1.Visible = true;
                statusStrip2.Visible = false;
                //label2.Visible = false;
                //label1.Visible = true;
                button5.Enabled = false;
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
                chess++;
                if (Judge() == 1)
                {
                    return;
                }
                //Judge();
                computer();
                chess++;
            }
            else if (statusStrip2.Visible == true)
            {
                button6.Text = "O";
                statusStrip1.Visible = true;
                statusStrip2.Visible = false;
                //label2.Visible = false;
                //label1.Visible = true;
                button6.Enabled = false;
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
                chess++;
                if (Judge() == 1)
                {
                    return;
                }
                //Judge();
                computer();
                chess++;
            }
            else if (statusStrip2.Visible == true)
            {
                button7.Text = "O";
                statusStrip1.Visible = true;
                statusStrip2.Visible = false;
                //label2.Visible = false;
                //label1.Visible = true;
                button7.Enabled = false;
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
                chess++;
                if (Judge() == 1)
                {
                    return;
                }
                //Judge();
                computer();
                chess++;
            }
            else if (statusStrip2.Visible == true)
            {
                button8.Text = "O";
                statusStrip1.Visible = true;
                statusStrip2.Visible = false;
                //label2.Visible = false;
                //label1.Visible = true;
                button8.Enabled = false;
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
                chess++;
                if (Judge() == 1)
                {
                    return;
                }
                //Judge();
                computer();
                chess++;
            }
            else if (statusStrip2.Visible == true)
            {
                button9.Text = "O";
                statusStrip1.Visible = true;
                statusStrip2.Visible = false;
                //label2.Visible = false;
                //label1.Visible = true;
                button9.Enabled = false;
                Judge();
            }
            
        }
    }
}
