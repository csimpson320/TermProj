using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TermProj
{
    public partial class Game1 : Form
    {
        Help fmr_help;
        private uint ticks;
        TextBox[,] matrix;
        List<short> matrixNums = new List<short>(25);
        Random num = new Random();
        short prevNum;
        bool startWithR1 = false;
        //(short, short) r1Location;

        public Game1()
        {
            InitializeComponent();
            gameTimer.Start();
            matrix = new TextBox[,] { { this.txtBox00, this.txtBox01, this.txtBox02, this.txtBox03, this.txtBox04 }, { this.txtBox10, this.txtBox11, this.txtBox12, this.txtBox13, this.txtBox14 }, { this.txtBox20, this.txtBox21, this.txtBox22, this.txtBox23, this.txtBox24 }, { this.txtBox30, this.txtBox31, this.txtBox32, this.txtBox33, this.txtBox34 }, { this.txtBox40, this.txtBox41, this.txtBox42, this.txtBox43, this.txtBox44 } };
            startGame();
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            ticks++;
            g1_Time.Text = ticks.ToString();
        }

        private void gameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void applicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmr_help = new Help();
            fmr_help.ShowDialog();
        }

        private void pauseGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gameTimer.Enabled)
            {
                gameTimer.Stop();
            }
            else
            {
                gameTimer.Start();
            }
        }

        private void startGame()
        {
            int r1 = num.Next(1, 26);
            PlaceRandom(r1);
        }

        private void Check(object sender, EventArgs e)
        {
            TextBox uInput = (TextBox)sender;
            short uNum;

            if (uInput.Text != "")
            {
                try
                {
                    //check if users input is valid
                    uNum = short.Parse(uInput.Text);

                    if (uNum > 25)
                    {
                        throw new Exception("Please enter a number between 1-25");
                    }

                    if (matrixNums.Contains(uNum))
                    {
                        throw new Exception("This number has already been used, please choose the next number.");
                    }

                    if (startWithR1 == false)
                    {
                        startWithR1 = true;
                        prevNum = 1;
                    }

                    if (CheckAdjCells(uNum, prevNum) == false)
                    {
                        throw new Exception("This location is not valid, please choose another adjancent location.");
                    }
                    else
                    {
                        matrixNums.Add(uNum);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter a valid number.", "Invalid Input");
                    uInput.Clear();
                    uInput.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Invalid Input");
                    uInput.Clear();
                    uInput.Focus();
                }
            }
        }

        private (short r, short c) GetLocation(short num)
        {
            //if (startWithR1 == false)
            //{
            //    startWithR1 = true;
            //    return r1Location;
            //}
            //else
            //{
            //    for (short row = 0; row <= 4; row++)
            //        for (short col = 0; col <= 4; col++)
            //        {
            //            if (matrix[row, col].Text == num.ToString())
            //                return (row, col);
            //        }
            //}
            for (short row = 0; row <= 4; row++)
                for (short col = 0; col <= 4; col++)
                {
                    if (matrix[row, col].Text == num.ToString())
                        return (row, col);
                }
            return (-1, -1);
        }

        private List<(short, short)> FindAdjCells(short num)
        {
            (short, short) cell = GetLocation(num);
            List<(short, short)> adjCells = new List<(short, short)> { };

            if (cell.Item1 == 0 && cell.Item2 == 0)
            {
                return adjCells = new List<(short, short)> { (0, 1), (1, 0), (1, 1) };
            }
            return adjCells;
        }

        private bool CheckAdjCells(short num, short prev)
        {
            List<(short, short)> adjCells = FindAdjCells(prev);
            //int length = adjCells.Count();

            foreach ((short, short) location in adjCells)
            {
                if (matrix[location.Item1, location.Item2].Text == num.ToString())
                {
                    prevNum = num;
                    return true;
                }
                //Console.WriteLine("{0} and {1}", location.Item1, location.Item2);
            }
            return false;
        }

        private void PlaceRandom(int r)
        {
            switch (r)
            {
                case 1:
                    matrix[0, 0].ForeColor = Color.Red;
                    matrix[0, 0].ReadOnly = true;
                    matrix[0, 0].TextChanged -= Check;
                    matrix[0, 0].Text = "1";
                    break;
                //case 2:
                //    matrix[0, 1].Text = "1";
                //    matrix[0, 1].ForeColor = Color.Red;
                //    matrix[0, 1].ReadOnly = true;
                //    break;
                //case 3:
                //    matrix[0, 2].Text = "1";
                //    matrix[0, 2].ForeColor = Color.Red;
                //    matrix[0, 2].ReadOnly = true;
                //    break;
                //case 4:
                //    matrix[0, 3].Text = "1";
                //    matrix[0, 3].ForeColor = Color.Red;
                //    matrix[0, 3].ReadOnly = true;
                //    break;
                //case 5:
                //    matrix[0, 4].Text = "1";
                //    matrix[0, 4].ForeColor = Color.Red;
                //    matrix[0, 4].ReadOnly = true;
                //    break;
                //case 6:
                //    matrix[1, 0].Text = "1";
                //    matrix[1, 0].ForeColor = Color.Red;
                //    matrix[1, 0].ReadOnly = true;
                //    break;
                //case 7:
                //    matrix[1, 1].Text = "1";
                //    matrix[1, 1].ForeColor = Color.Red;
                //    matrix[1, 1].ReadOnly = true;
                //    break;
                //case 8:
                //    matrix[1, 2].Text = "1";
                //    matrix[1, 2].ForeColor = Color.Red;
                //    matrix[1, 2].ReadOnly = true;
                //    break;
                //case 9:
                //    matrix[1, 3].Text = "1";
                //    matrix[1, 3].ForeColor = Color.Red;
                //    matrix[1, 3].ReadOnly = true;
                //    break;
                //case 10:
                //    matrix[1, 4].Text = "1";
                //    matrix[1, 4].ForeColor = Color.Red;
                //    matrix[1, 4].ReadOnly = true;
                //    break;
                //case 11:
                //    matrix[2, 0].Text = "1";
                //    matrix[2, 0].ForeColor = Color.Red;
                //    matrix[2, 0].ReadOnly = true;
                //    break;
                //case 12:
                //    matrix[2, 1].Text = "1";
                //    matrix[2, 1].ForeColor = Color.Red;
                //    matrix[2, 1].ReadOnly = true;
                //    break;
                //case 13:
                //    matrix[2, 2].Text = "1";
                //    matrix[2, 2].ForeColor = Color.Red;
                //    matrix[2, 2].ReadOnly = true;
                //    break;
                //case 14:
                //    matrix[2, 3].Text = "1";
                //    matrix[2, 3].ForeColor = Color.Red;
                //    matrix[2, 3].ReadOnly = true;
                //    break;
                //case 15:
                //    matrix[2, 4].Text = "1";
                //    matrix[2, 4].ForeColor = Color.Red;
                //    matrix[2, 4].ReadOnly = true;
                //    break;
                //case 16:
                //    matrix[3, 0].Text = "1";
                //    matrix[3, 0].ForeColor = Color.Red;
                //    matrix[3, 0].ReadOnly = true;
                //    break;
                //case 17:
                //    matrix[3, 1].Text = "1";
                //    matrix[3, 1].ForeColor = Color.Red;
                //    matrix[3, 1].ReadOnly = true;
                //    break;
                //case 18:
                //    matrix[3, 2].Text = "1";
                //    matrix[3, 2].ForeColor = Color.Red;
                //    matrix[3, 2].ReadOnly = true;
                //    break;
                //case 19:
                //    matrix[3, 3].Text = "1";
                //    matrix[3, 3].ForeColor = Color.Red;
                //    matrix[3, 3].ReadOnly = true;
                //    break;
                //case 20:
                //    matrix[3, 4].Text = "1";
                //    matrix[3, 4].ForeColor = Color.Red;
                //    matrix[3, 4].ReadOnly = true;
                //    break;
                //case 21:
                //    matrix[4, 0].Text = "1";
                //    matrix[4, 0].ForeColor = Color.Red;
                //    matrix[4, 0].ReadOnly = true;
                //    break;
                //case 22:
                //    matrix[4, 1].Text = "1";
                //    matrix[4, 1].ForeColor = Color.Red;
                //    matrix[4, 1].ReadOnly = true;
                //    break;
                //case 23:
                //    matrix[4, 2].Text = "1";
                //    matrix[4, 2].ForeColor = Color.Red;
                //    matrix[4, 2].ReadOnly = true;
                //    break;
                //case 24:
                //    matrix[4, 3].Text = "1";
                //    matrix[4, 3].ForeColor = Color.Red;
                //    matrix[4, 3].ReadOnly = true;
                //    break;
                //case 25:
                //    matrix[4, 4].Text = "1";
                //    matrix[4, 4].ForeColor = Color.Red;
                //    matrix[4, 4].ReadOnly = true;
                //    break;
                default:
                    matrix[0, 0].ForeColor = Color.Red;
                    matrix[0, 0].ReadOnly = true;
                    matrix[0, 0].TextChanged -= Check;
                    matrix[0, 0].Text = "1";
                    //r1Location = (0, 0);
                    break;
            }
            matrixNums.Add(1);
        }
    }
}
