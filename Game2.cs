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
    public partial class Game2 : Form
    {
        Help fmr_help;
        uint ticks;
        string time;
        int uNum;
        bool start = true;
        TextBox[,] game2Matrix;
        int prevNum, nxtNum;
        Random num = new Random();
        (short, short) r1Location;
        Stack<string> solNums = new Stack<string>();
        List<int> matrixNums = new List<int>(25);
        List<int> game2Nums = new List<int>(24);

        public Game2()
        {
            InitializeComponent();
            startGame();
            gameTimer.Start();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            ticks++;
            TimeSpan t = TimeSpan.FromSeconds(ticks);
            time = $"{t.Hours}h:{t.Minutes}m:{t.Seconds}s";
            g2_Time.Text = time;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmr_help = new Help();
            fmr_help.ShowDialog();
        }

        private void gameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void applicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pauseGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gameTimer.Enabled)
                gameTimer.Stop();
        }

        private void startGameTimer(object sender, EventArgs e)
        {
            if (gameTimer.Enabled == false)
                gameTimer.Start();
        }

        private void abortGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameTimer.Stop();
            var result = MessageBox.Show("Please confirm you would like to abort Game 2?", "Game Aborted!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                this.Close();
            else
                gameTimer.Start();
        }

        private void gameHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void startGame()
        {
            game2Matrix = new TextBox[,] { { this.txtBox00, this.txtBox01, this.txtBox02, this.txtBox03, this.txtBox04 }, { this.txtBox10, this.txtBox11, this.txtBox12, this.txtBox13, this.txtBox14 }, { this.txtBox20, this.txtBox21, this.txtBox22, this.txtBox23, this.txtBox24 }, { this.txtBox30, this.txtBox31, this.txtBox32, this.txtBox33, this.txtBox34 }, { this.txtBox40, this.txtBox41, this.txtBox42, this.txtBox43, this.txtBox44 } };
            int r1 = num.Next(1, 26);
            PlaceRandom(r1);
            innerSolution();
        }

        private void Check(object sender, EventArgs e)
        {
            TextBox uInput = (TextBox)sender;
            if (uInput.Text == "" == false)
            {
                try
                {
                    if (start)
                    {
                        start = false;
                        prevNum = 1; nxtNum = 2;
                    }
                    
                    //check if users input is valid
                    uNum = Int32.Parse(uInput.Text);

                    if (uNum < 2 || uNum > 25)
                    {
                        throw new Exception($"{uNum} is invalid. Please enter a number between 2-25");
                    }

                    if (game2Nums.Contains(uNum))
                    {
                        throw new Exception($"{uNum} has already been used, please choose the next number.");
                    }

                    if (CheckRowCol(uInput.Name, uInput.Text) == false)
                    {
                        throw new Exception($"{uNum} can not be placed in this location, please choose a location according to the rules.");
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
                            game2Nums.Add(uNum);
                            prevNum++; nxtNum++;
                            uInput.ReadOnly = true;
                            uInput.Leave -= Check;
                            //Console.WriteLine($"Previous Num = {prevNum}");
                            //Console.WriteLine($"Next Num = {nxtNum}");
                        }
                        if (uNum == 25)
                        {
                            gameTimer.Stop();
                            var result = MessageBox.Show("You win the game!\n\n" + $"You finished the game in {time}.",
                                "Game Over!");
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

        private bool CheckRowCol(string name, string uInput)
        {
            if (name.StartsWith("L") || name.StartsWith("R"))
            {
                string sNum = name.Substring(name.Length - 1);
                int num = Int32.Parse(sNum);
                for (int row = num; row < num + 1; row++)
                    for (int col = 0; col <= 4; col++)
                    {
                        if (uInput == game2Matrix[row, col].Text)
                            return true;
                    }
            }
            if (name.StartsWith("T") || name.StartsWith("B"))
            {
                string sNum = name.Substring(name.Length - 1);
                int num = Int32.Parse(sNum);
                for (int row = 0; row <= 4; row++)
                    for (int col = num; col < num + 1; col++)
                    {
                        if (uInput == game2Matrix[row, col].Text)
                            return true;
                    }
            }
            if (name == "CTL" || name == "CBR")
            {
                int count = 0;
                for (int row = count; row < count + 1; row++)
                {
                    for (int col = count; col < count + 1; col++)
                    {
                        if (uInput == game2Matrix[row, col].Text)
                            return true;
                    }
                    count++;
                }  
            }
            if (name == "CTR" || name == "CBL")
            {
                int count = 0, i = 4;
                for (int row = count; row < count + 1; row++)
                {
                    for (int col = i; col > i - 1; col--)
                    {
                        if (uInput == game2Matrix[row, col].Text)
                            return true;
                    }
                    count++; i--;
                }
            }
            return false;
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
                        if (game2Nums.Contains(Int32.Parse(uInput.Text)))
                        {
                            game2Nums.Remove(Int32.Parse(uInput.Text));
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
                    if (game2Matrix[row, col].Text == num.ToString())
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

        private void innerSolution()
        {
            bool start = true;
            //Clear cells except for the "1" cell
            for (int row = 0; row <= 4; row++)
                for (int col = 0; col <= 4; col++)
                {
                    if (game2Matrix[row, col].Text == "1")
                        break;
                    else
                        game2Matrix[row, col].Text = "";
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
                        if (game2Matrix[adjCells[i].Item1, adjCells[i].Item2].Text == "")
                        {
                            game2Matrix[adjCells[i].Item1, adjCells[i].Item2].Text = solNums.Pop();
                            break;
                        }
                    }
                    prevNum = 2; matrixNums.Add(2); count++;
                }
                else
                {
                    List<(int, int)> adjCells = FindAdjCells(prevNum);
                    foreach ((int, int) location in adjCells)
                    {
                        if (game2Matrix[location.Item1, location.Item2].Text == "")
                        {
                            game2Matrix[location.Item1, location.Item2].Text = solNums.Pop();
                            break;
                        }
                    }
                    matrixNums.Add(prevNum); prevNum++; count++;
                }
            }
        }

        private void PlaceRandom(int r)
        {
            switch (r)
            {
                case 1:
                    game2Matrix[0, 0].ForeColor = Color.Red;
                    game2Matrix[0, 0].Text = "1";
                    r1Location = (0, 0);
                    break;
                case 2:
                    game2Matrix[0, 1].ForeColor = Color.Red;
                    game2Matrix[0, 1].Text = "1";
                    r1Location = (0, 1);
                    break;
                case 3:
                    game2Matrix[0, 2].ForeColor = Color.Red;
                    game2Matrix[0, 2].Text = "1";
                    r1Location = (0, 2);
                    break;
                case 4:
                    game2Matrix[0, 3].ForeColor = Color.Red;
                    game2Matrix[0, 3].Text = "1";
                    r1Location = (0, 3);
                    break;
                case 5:
                    game2Matrix[0, 4].ForeColor = Color.Red;
                    game2Matrix[0, 4].Text = "1";
                    r1Location = (0, 4);
                    break;
                case 6:
                    game2Matrix[1, 0].ForeColor = Color.Red;
                    game2Matrix[1, 0].Text = "1";
                    r1Location = (1, 0);
                    break;
                case 7:
                    game2Matrix[1, 1].ForeColor = Color.Red;
                    game2Matrix[1, 1].Text = "1";
                    r1Location = (1, 1);
                    break;
                case 8:
                    game2Matrix[1, 2].ForeColor = Color.Red;
                    game2Matrix[1, 2].Text = "1";
                    r1Location = (1, 2);
                    break;
                case 9:
                    game2Matrix[1, 3].ForeColor = Color.Red;
                    game2Matrix[1, 3].Text = "1";
                    r1Location = (1, 3);
                    break;
                case 10:
                    game2Matrix[1, 4].ForeColor = Color.Red;
                    game2Matrix[1, 4].Text = "1";
                    r1Location = (1, 4);
                    break;
                case 11:
                    game2Matrix[2, 0].ForeColor = Color.Red;
                    game2Matrix[2, 0].Text = "1";
                    r1Location = (2, 0);
                    break;
                case 12:
                    game2Matrix[2, 1].ForeColor = Color.Red;
                    game2Matrix[2, 1].Text = "1";
                    r1Location = (2, 1);
                    break;
                case 13:
                    game2Matrix[2, 2].ForeColor = Color.Red;
                    game2Matrix[2, 2].Text = "1";
                    r1Location = (2, 2);
                    break;
                case 14:
                    game2Matrix[2, 3].ForeColor = Color.Red;
                    game2Matrix[2, 3].Text = "1";
                    r1Location = (2, 3);
                    break;
                case 15:
                    game2Matrix[2, 4].ForeColor = Color.Red;
                    game2Matrix[2, 4].Text = "1";
                    r1Location = (2, 4);
                    break;
                case 16:
                    game2Matrix[3, 0].ForeColor = Color.Red;
                    game2Matrix[3, 0].Text = "1";
                    r1Location = (3, 0);
                    break;
                case 17:
                    game2Matrix[3, 1].ForeColor = Color.Red;
                    game2Matrix[3, 1].Text = "1";
                    r1Location = (3, 1);
                    break;
                case 18:
                    game2Matrix[3, 2].ForeColor = Color.Red;
                    game2Matrix[3, 2].Text = "1";
                    r1Location = (3, 2);
                    break;
                case 19:
                    game2Matrix[3, 3].ForeColor = Color.Red;
                    game2Matrix[3, 3].Text = "1";
                    r1Location = (3, 3);
                    break;
                case 20:
                    game2Matrix[3, 4].ForeColor = Color.Red;
                    game2Matrix[3, 4].Text = "1";
                    r1Location = (3, 4);
                    break;
                case 21:
                    game2Matrix[4, 0].ForeColor = Color.Red;
                    game2Matrix[4, 0].Text = "1";
                    r1Location = (4, 0);
                    break;
                case 22:
                    game2Matrix[4, 1].ForeColor = Color.Red;
                    game2Matrix[4, 1].Text = "1";
                    r1Location = (4, 1);
                    break;
                case 23:
                    game2Matrix[4, 2].ForeColor = Color.Red;
                    game2Matrix[4, 2].Text = "1";
                    r1Location = (4, 2);
                    break;
                case 24:
                    game2Matrix[4, 3].ForeColor = Color.Red;
                    game2Matrix[4, 3].Text = "1";
                    r1Location = (4, 3);
                    break;
                case 25:
                    game2Matrix[4, 4].ForeColor = Color.Red;
                    game2Matrix[4, 4].Text = "1";
                    r1Location = (4, 4);
                    break;
            }
            matrixNums.Add(1);
        }
    }
}
