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
        private int ticks;

        public Game1()
        {
            InitializeComponent();
            gameTimer.Start();
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

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            ticks++;
            g1_Time.Text = ticks.ToString();
        }
    }
}
