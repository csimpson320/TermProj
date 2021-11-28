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
    public partial class History : Form
    {
        List<Game> games = new List<Game>();
        public History()
        {
            InitializeComponent();
            GameHistory h = new GameHistory();
            games = h.GetHistory();

            if (games.Count == 0)
            {
                lstHistory.Items.Add("No Game History to Display!");
            }
            else
            {
                foreach (Game g in games)
                {
                    lstHistory.Items.Add($"{g.DateTime} | User:{g._User} | Game:{g._Game} | Time:{g.PlayTime} | Result:{g.Result}");
                }
            }
        }
    }
}
