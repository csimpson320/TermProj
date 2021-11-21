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
        TextBox[,] matrix;
        int prevNum, nxtNum;

        public Game2()
        {
            InitializeComponent();
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
            {
                gameTimer.Stop();
            }
            else
            {
                gameTimer.Start();
            }
        }

        private void abortGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gameHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
