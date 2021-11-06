﻿using System;
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
        private int ticks;
        TextBox[,] matrix;
        Random num = new Random();

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
            placeRandom(r1);
        }

        private void Check(object sender, EventArgs e)
        { 
            
        }

        private void placeRandom(int r)
        {
            switch (r)
            {
                case 1:
                    matrix[0, 0].Text = "1";
                    matrix[0, 0].ForeColor = Color.Red;
                    break;
                case 2:
                    matrix[0, 1].Text = "1";
                    matrix[0, 1].ForeColor = Color.Red;
                    break;
                case 3:
                    matrix[0, 2].Text = "1";
                    matrix[0, 2].ForeColor = Color.Red;
                    break;
                case 4:
                    matrix[0, 3].Text = "1";
                    matrix[0, 3].ForeColor = Color.Red;
                    break;
                case 5:
                    matrix[0, 4].Text = "1";
                    matrix[0, 4].ForeColor = Color.Red;
                    break;
                case 6:
                    matrix[1, 0].Text = "1";
                    matrix[1, 0].ForeColor = Color.Red;
                    break;
                case 7:
                    matrix[1, 1].Text = "1";
                    matrix[1, 1].ForeColor = Color.Red;
                    break;
                case 8:
                    matrix[1, 2].Text = "1";
                    matrix[1, 2].ForeColor = Color.Red;
                    break;
                case 9:
                    matrix[1, 3].Text = "1";
                    matrix[1, 3].ForeColor = Color.Red;
                    break;
                case 10:
                    matrix[1, 4].Text = "1";
                    matrix[1, 4].ForeColor = Color.Red;
                    break;
                case 11:
                    matrix[2, 0].Text = "1";
                    matrix[2, 0].ForeColor = Color.Red;
                    break;
                case 12:
                    matrix[2, 1].Text = "1";
                    matrix[2, 1].ForeColor = Color.Red;
                    break;
                case 13:
                    matrix[2, 2].Text = "1";
                    matrix[2, 2].ForeColor = Color.Red;
                    break;
                case 14:
                    matrix[2, 3].Text = "1";
                    matrix[2, 3].ForeColor = Color.Red;
                    break;
                case 15:
                    matrix[2, 4].Text = "1";
                    matrix[2, 4].ForeColor = Color.Red;
                    break;
                case 16:
                    matrix[3, 0].Text = "1";
                    matrix[3, 0].ForeColor = Color.Red;
                    break;
                case 17:
                    matrix[3, 1].Text = "1";
                    matrix[3, 1].ForeColor = Color.Red;
                    break;
                case 18:
                    matrix[3, 2].Text = "1";
                    matrix[3, 2].ForeColor = Color.Red;
                    break;
                case 19:
                    matrix[3, 3].Text = "1";
                    matrix[3, 3].ForeColor = Color.Red;
                    break;
                case 20:
                    matrix[3, 4].Text = "1";
                    matrix[3, 4].ForeColor = Color.Red;
                    break;
                case 21:
                    matrix[4, 0].Text = "1";
                    matrix[4, 0].ForeColor = Color.Red;
                    break;
                case 22:
                    matrix[4, 1].Text = "1";
                    matrix[4, 1].ForeColor = Color.Red;
                    break;
                case 23:
                    matrix[4, 2].Text = "1";
                    matrix[4, 2].ForeColor = Color.Red;
                    break;
                case 24:
                    matrix[4, 3].Text = "1";
                    matrix[4, 3].ForeColor = Color.Red;
                    break;
                case 25:
                    matrix[4, 4].Text = "1";
                    matrix[4, 4].ForeColor = Color.Red;
                    break;
            }
        }
    }
}
