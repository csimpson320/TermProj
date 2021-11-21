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
    public partial class Home : Form
    {
        Help fmr_help;
        History fmr_history;
        Game1 fmr_g1;
        Game2 fmr_g2;
        
        public Home()
        {
            InitializeComponent();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmr_help = new Help();
            fmr_help.ShowDialog();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void game1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmr_g1 = new Game1();
            fmr_g1.ShowDialog();
        }

        private void game2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmr_g2 = new Game2();
            fmr_g2.ShowDialog();
        }
    }
}
