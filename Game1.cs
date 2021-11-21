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
        uint ticks;
        string time;
        int uNum;
        TextBox[,] matrix;
        List<int> matrixNums = new List<int>(25);
        Random num = new Random();
        int prevNum, nxtNum;
        bool startWithR1 = false;
        (short, short) r1Location;
        Stack<string> solNums = new Stack<string>();

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
            TimeSpan t = TimeSpan.FromSeconds(ticks);
            time = $"{t.Hours}h:{t.Minutes}m:{t.Seconds}s";
            g1_Time.Text = time;
        }

        private void gameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void applicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void abortGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (uInput.Text == "" == false)
            {
                try
                {
                    if (startWithR1 == false)
                    {
                        startWithR1 = true;
                        prevNum = 1; nxtNum = 2;
                    }

                    //check if users input is valid
                    uNum = Int32.Parse(uInput.Text);

                    if (uNum < 2 || uNum > 25)
                    {
                        throw new Exception($"{uNum} is invalid. Please enter a number between 2-25");
                    }

                    if (matrixNums.Contains(uNum))
                    {
                        throw new Exception($"{uNum} has already been used, please choose the next number.");
                    }

                    if (CheckAdjCells(uNum, prevNum) == false)
                    {
                        Console.WriteLine($"Previous Num = {prevNum}");
                        throw new Exception($"{uNum} can not be placed in this location, please choose an adjancent location.");
                    }
                    else
                    {
                        if (uNum != nxtNum)
                        {
                            //Console.WriteLine($"Previous Num = {prevNum}");
                            //Console.WriteLine($"Next Num = {nxtNum}");
                            throw new Exception($"You must enter the next sequential number, please enter {nxtNum}");
                        }
                        else
                        {
                            matrixNums.Add(uNum);
                            prevNum++; nxtNum++;
                            uInput.ReadOnly = true;
                            uInput.Leave -= Check;
                            //Console.WriteLine($"Previous Num = {prevNum}");
                            //Console.WriteLine($"Next Num = {nxtNum}");
                        }
                        if (uNum == 25)
                        {
                            gameTimer.Stop();
                            var result = MessageBox.Show("You win the game!\n" +
                                $"You finished the game in {time}.\n" + "Would you like to start Game 2?", 
                                "Game Over!", MessageBoxButtons.YesNo);
                            if (result == DialogResult.No)
                            {
                                this.Close();
                            }
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter a valid number.", "Invalid Input!");
                    uInput.Clear();
                    uInput.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Invalid Input!");
                    uInput.Clear();
                    uInput.Focus();
                }
            }
        }

        private void Clear(object sender, EventArgs e)
        {
            TextBox uInput = (TextBox)sender;
            try
            {
                if (uInput.Text != "")
                {
                    if (uInput.Text != prevNum.ToString())
                    {
                        throw new Exception("Must clear numbers in reverse order if wish to change location.");
                    }
                    else
                    {
                        if (matrixNums.Contains(Int32.Parse(uInput.Text)))
                        {
                            matrixNums.Remove(Int32.Parse(uInput.Text));
                        }
                        prevNum--; nxtNum--;
                        uInput.Clear();
                        uInput.ReadOnly = false;
                        uInput.Leave += Check;
                        //Console.WriteLine($"Previous Num = {prevNum}");
                        //Console.WriteLine($"Next Num = {nxtNum}");
                    }
                }
                else
                {
                    throw new Exception("There is no number to clear.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
        }

        private (int r, int c) GetLocation(int num)
        {
            for (int row = 0; row <= 4; row++)
                for (int col = 0; col <= 4; col++)
                {
                    if (matrix[row, col].Text == num.ToString())
                        return (row, col);
                }
            return (-1, -1);
        }

        private List<(int, int)> FindAdjCells(int num)
        {
            (int, int) cell = GetLocation(num);
            List<(int, int)> adjCells = new List<(int, int)> { };

            if (cell.Item1 == 0 && cell.Item2 == 0) //TOP LEFT EDGE CELL
            {
                return adjCells = new List<(int, int)> { (0, 1), (1, 0), (1, 1) };
            }
            else if (cell.Item1 == 4 && cell.Item2 == 0) //BOTTOM LEFT EDGE CELL
            {
                return adjCells = new List<(int, int)> { (3, 0), (3, 1), (4, 1) };
            }
            else if (cell.Item1 == 4 && cell.Item2 == 4) //BOTTOM RIGHT EDGE CELL
            {
                return adjCells = new List<(int, int)> { (4, 3), (3, 4), (3, 3) };
            }
            else if (cell.Item1 == 0 && cell.Item2 == 4) //TOP RIGHT EDGE CELL
            {
                return adjCells = new List<(int, int)> { (1, 3), (0, 3), (1, 4) };
            }
            else if ((cell.Item1 >= 1 && cell.Item1 <= 3) && (cell.Item2 >= 1 && cell.Item2 <= 3)) //INNER MIDDLE CELLS
            {
                return adjCells = new List<(int, int)> { (cell.Item1 - 1, cell.Item2), (cell.Item1 - 1, cell.Item2 - 1), (cell.Item1, cell.Item2 - 1), (cell.Item1 + 1, cell.Item2 - 1), (cell.Item1 + 1, cell.Item2), (cell.Item1, cell.Item2 + 1), (cell.Item1 + 1, cell.Item2 + 1), (cell.Item1 - 1, cell.Item2 + 1) };
            }
            else if ((cell.Item1 >= 1 && cell.Item1 <= 3) && cell.Item2 == 0) //LEFT INNER WALL CELLS
            {
                return adjCells = new List<(int, int)> { (cell.Item1 - 1, cell.Item2), (cell.Item1 - 1, cell.Item2 + 1), (cell.Item1, cell.Item2 + 1), (cell.Item1 + 1, cell.Item2), (cell.Item1 + 1, cell.Item2 + 1) };
            }
            else if (cell.Item1 == 0 && (cell.Item2 >= 1 && cell.Item2 <= 3)) //TOP INNER WALL CELLS
            {
                return adjCells = new List<(int, int)> { (cell.Item1, cell.Item2 - 1), (cell.Item1 + 1, cell.Item2 - 1), (cell.Item1 + 1, cell.Item2), (cell.Item1, cell.Item2 + 1), (cell.Item1 + 1, cell.Item2 + 1) };
            }
            else if ((cell.Item1 >= 1 && cell.Item1 <= 3) && cell.Item2 == 4) //RIGHT INNER WALL CELLS
            {
                return adjCells = new List<(int, int)> { (cell.Item1 + 1, cell.Item2), (cell.Item1 + 1, cell.Item2 - 1), (cell.Item1, cell.Item2 - 1), (cell.Item1 - 1, cell.Item2 - 1), (cell.Item1 - 1, cell.Item2) };
            }
            else if (cell.Item1 == 4 && (cell.Item2 >= 1 && cell.Item2 <= 3)) //BOTTOM INNER WALL CELLS
            {
                return adjCells = new List<(int, int)> { (cell.Item1, cell.Item2 - 1), (cell.Item1 - 1, cell.Item2 - 1), (cell.Item1 - 1, cell.Item2), (cell.Item1, cell.Item2 + 1), (cell.Item1 - 1, cell.Item2 + 1) };
            }
            return adjCells;
        }

        private bool CheckAdjCells(int num, int prev)
        {
            List<(int, int)> adjCells = FindAdjCells(prev);
            //int length = adjCells.Count();

            foreach ((int, int) location in adjCells)
            {
                if (matrix[location.Item1, location.Item2].Text == num.ToString())
                {
                    return true;
                }
                //Console.WriteLine("{0} and {1}", location.Item1, location.Item2);
            }
            return false;
        }

        private void gameSolutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool start = true;
            //Clear cells except for the "1" cell
            for (int row = 0; row <= 4; row++)
                for (int col = 0; col <= 4; col++)
                {
                    if (matrix[row, col].Text == "1")
                        break;
                    else
                        matrix[row, col].Clear();
                }

            for (int i = 25; i > 1; i--)
            {
                solNums.Push(i.ToString());
            }

            matrixNums = new List<int>(25);
            matrixNums.Add(1);
            int count = 0;

            while (matrixNums.Count() != 25)
            {
                if (start)
                {
                    prevNum = 1; start = false;
                    List<(int, int)> adjCells = FindAdjCells(prevNum);
                    for (int i = 0; i < adjCells.Count(); i++)
                    {
                        if (matrix[adjCells[i].Item1, adjCells[i].Item2].Text == "")
                        {
                            matrix[adjCells[i].Item1, adjCells[i].Item2].Text = solNums.Pop();
                            matrix[adjCells[i].Item1, adjCells[i].Item2].ReadOnly = true;
                            matrix[adjCells[i].Item1, adjCells[i].Item2].DoubleClick -= Clear;
                            matrix[adjCells[i].Item1, adjCells[i].Item2].Leave -= Check;
                            matrix[adjCells[i].Item1, adjCells[i].Item2].Click -= pauseGameToolStripMenuItem_Click;
                            break;
                        }
                    }
                    prevNum = 2; matrixNums.Add(2); count++;
                }
                else
                {
                    Console.WriteLine(prevNum.ToString() + "  | else TOP");
                    List<(int, int)> adjCells = FindAdjCells(prevNum);
                    foreach ((int, int) location in adjCells)
                    {
                        if (matrix[location.Item1, location.Item2].Text == "")
                        {
                            matrix[location.Item1, location.Item2].Text = solNums.Pop();
                            matrix[location.Item1, location.Item2].ReadOnly = true;
                            matrix[location.Item1, location.Item2].DoubleClick -= Clear;
                            matrix[location.Item1, location.Item2].Leave -= Check;
                            matrix[location.Item1, location.Item2].Click -= pauseGameToolStripMenuItem_Click;
                            break;
                        }
                    }
                    matrixNums.Add(prevNum); prevNum++; count++;
                    Console.WriteLine(prevNum.ToString() + "  | else BOTTOM");
                }
            }
            if (matrixNums.Count() == 25)
                gameTimer.Stop();
        }

        private void PlaceRandom(int r)
        {
            switch (r)
            {
                case 1:
                    matrix[0, 0].ForeColor = Color.Red;
                    matrix[0, 0].ReadOnly = true;
                    matrix[0, 0].Leave -= Check;
                    matrix[0, 0].Text = "1";
                    r1Location = (0, 0);
                    break;
                case 2:
                    matrix[0, 1].ForeColor = Color.Red;
                    matrix[0, 1].ReadOnly = true;
                    matrix[0, 1].Leave -= Check;
                    matrix[0, 1].Text = "1";
                    r1Location = (0, 1);
                    break;
                case 3:
                    matrix[0, 2].ForeColor = Color.Red;
                    matrix[0, 2].ReadOnly = true;
                    matrix[0, 2].Leave -= Check;
                    matrix[0, 2].Text = "1";
                    r1Location = (0, 2);
                    break;
                case 4:
                    matrix[0, 3].ForeColor = Color.Red;
                    matrix[0, 3].ReadOnly = true;
                    matrix[0, 3].Leave -= Check;
                    matrix[0, 3].Text = "1";
                    r1Location = (0, 3);
                    break;
                case 5:
                    matrix[0, 4].ForeColor = Color.Red;
                    matrix[0, 4].ReadOnly = true;
                    matrix[0, 4].Leave -= Check;
                    matrix[0, 4].Text = "1";
                    r1Location = (0, 4);
                    break;
                case 6:
                    matrix[1, 0].ForeColor = Color.Red;
                    matrix[1, 0].ReadOnly = true;
                    matrix[1, 0].Leave -= Check;
                    matrix[1, 0].Text = "1";
                    r1Location = (1, 0);
                    break;
                case 7:
                    matrix[1, 1].ForeColor = Color.Red;
                    matrix[1, 1].ReadOnly = true;
                    matrix[1, 1].Leave -= Check;
                    matrix[1, 1].Text = "1";
                    r1Location = (1, 1);
                    break;
                case 8:
                    matrix[1, 2].ForeColor = Color.Red;
                    matrix[1, 2].ReadOnly = true;
                    matrix[1, 2].Leave -= Check;
                    matrix[1, 2].Text = "1";
                    r1Location = (1, 2);
                    break;
                case 9:
                    matrix[1, 3].ForeColor = Color.Red;
                    matrix[1, 3].ReadOnly = true;
                    matrix[1, 3].Leave -= Check;
                    matrix[1, 3].Text = "1";
                    r1Location = (1, 3);
                    break;
                case 10:
                    matrix[1, 4].ForeColor = Color.Red;
                    matrix[1, 4].ReadOnly = true;
                    matrix[1, 4].Leave -= Check;
                    matrix[1, 4].Text = "1";
                    r1Location = (1, 4);
                    break;
                case 11:
                    matrix[2, 0].ForeColor = Color.Red;
                    matrix[2, 0].ReadOnly = true;
                    matrix[2, 0].Leave -= Check;
                    matrix[2, 0].Text = "1";
                    r1Location = (2, 0);
                    break;
                case 12:
                    matrix[2, 1].ForeColor = Color.Red;
                    matrix[2, 1].ReadOnly = true;
                    matrix[2, 1].Leave -= Check;
                    matrix[2, 1].Text = "1";
                    r1Location = (2, 1);
                    break;
                case 13:
                    matrix[2, 2].ForeColor = Color.Red;
                    matrix[2, 2].ReadOnly = true;
                    matrix[2, 2].Leave -= Check;
                    matrix[2, 2].Text = "1";
                    r1Location = (2, 2);
                    break;
                case 14:
                    matrix[2, 3].ForeColor = Color.Red;
                    matrix[2, 3].ReadOnly = true;
                    matrix[2, 3].Leave -= Check;
                    matrix[2, 3].Text = "1";
                    r1Location = (2, 3);
                    break;
                case 15:
                    matrix[2, 4].ForeColor = Color.Red;
                    matrix[2, 4].ReadOnly = true;
                    matrix[2, 4].Leave -= Check;
                    matrix[2, 4].Text = "1";
                    r1Location = (2, 4);
                    break;
                case 16:
                    matrix[3, 0].ForeColor = Color.Red;
                    matrix[3, 0].ReadOnly = true;
                    matrix[3, 0].Leave -= Check;
                    matrix[3, 0].Text = "1";
                    r1Location = (3, 0);
                    break;
                case 17:
                    matrix[3, 1].ForeColor = Color.Red;
                    matrix[3, 1].ReadOnly = true;
                    matrix[3, 1].Leave -= Check;
                    matrix[3, 1].Text = "1";
                    r1Location = (3, 1);
                    break;
                case 18:
                    matrix[3, 2].ForeColor = Color.Red;
                    matrix[3, 2].ReadOnly = true;
                    matrix[3, 2].Leave -= Check;
                    matrix[3, 2].Text = "1";
                    r1Location = (3, 2);
                    break;
                case 19:
                    matrix[3, 3].ForeColor = Color.Red;
                    matrix[3, 3].ReadOnly = true;
                    matrix[3, 3].Leave -= Check;
                    matrix[3, 3].Text = "1";
                    r1Location = (3, 3);
                    break;
                case 20:
                    matrix[3, 4].ForeColor = Color.Red;
                    matrix[3, 4].ReadOnly = true;
                    matrix[3, 4].Leave -= Check;
                    matrix[3, 4].Text = "1";
                    r1Location = (3, 4);
                    break;
                case 21:
                    matrix[4, 0].ForeColor = Color.Red;
                    matrix[4, 0].ReadOnly = true;
                    matrix[4, 0].Leave -= Check;
                    matrix[4, 0].Text = "1";
                    r1Location = (4, 0);
                    break;
                case 22:
                    matrix[4, 1].ForeColor = Color.Red;
                    matrix[4, 1].ReadOnly = true;
                    matrix[4, 1].Leave -= Check;
                    matrix[4, 1].Text = "1";
                    r1Location = (4, 1);
                    break;
                case 23:
                    matrix[4, 2].ForeColor = Color.Red;
                    matrix[4, 2].ReadOnly = true;
                    matrix[4, 2].Leave -= Check;
                    matrix[4, 2].Text = "1";
                    r1Location = (4, 2);
                    break;
                case 24:
                    matrix[4, 3].ForeColor = Color.Red;
                    matrix[4, 3].ReadOnly = true;
                    matrix[4, 3].Leave -= Check;
                    matrix[4, 3].Text = "1";
                    r1Location = (4, 3);
                    break;
                case 25:
                    matrix[4, 4].ForeColor = Color.Red;
                    matrix[4, 4].ReadOnly = true;
                    matrix[4, 4].Leave -= Check;
                    matrix[4, 4].Text = "1";
                    r1Location = (4, 4);
                    break;
                    //default:
                    //    matrix[0, 1].ForeColor = Color.Red;
                    //    matrix[0, 1].ReadOnly = true;
                    //    matrix[0, 1].TextChanged -= Check;
                    //    matrix[0, 1].Text = "1";
                    //    //r1Location = (0, 0);
                    //    break;
            }
            matrixNums.Add(1);
        }
    }
}
