using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProj
{
    class GameHistory
    {
        private const string dir = @"C:\TermProj\Files\";
        private const string path = dir + "GameHistory.csv";

        List<Game> Games = new List<Game>();

        public List<Game> GetHistory()
        {
            List<Game> history = new List<Game>();

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            if (File.Exists(path))
            {
                using (StreamReader txtIn =
                new StreamReader(
                new FileStream(path, FileMode.Open, FileAccess.Read)))
                {
                    while (txtIn.Peek() != -1)
                    {
                        string row = txtIn.ReadLine();
                        string[] cols = row.Split(',');
                        Game g = new Game();
                        g.DateTime = cols[0];
                        g._User = cols[1];
                        g._Game = cols[2];
                        g.PlayTime = cols[3];
                        g.Result = cols[4];
                        history.Add(g);
                    }
                }
            }
            return history;
        }

        public void SaveNewGame(Game newGame)
        {
            Games.Add(newGame);

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
                using (StreamWriter txtOut =
                    new StreamWriter(
                    new FileStream(path, FileMode.Append, FileAccess.Write)))
                {
                    txtOut.WriteLine($"{newGame.DateTime}, {newGame._User}, {newGame._Game}, {newGame.PlayTime}, {newGame.Result}");
                }
            }
            else
            {
                using (StreamWriter txtOut =
                    new StreamWriter(
                    new FileStream(path, FileMode.Append, FileAccess.Write)))
                {
                    txtOut.WriteLine($"{newGame.DateTime}, {newGame._User}, {newGame._Game}, {newGame.PlayTime}, {newGame.Result}");
                }
            }
        }
    }

    class Game
    {
        public string _User { get; set; }
        public string _Game { get; set; }
        public string DateTime { get; set; }
        public string PlayTime { get; set; }
        public string Result { get; set; }

        public Game()
        { }

        public Game(string u, string g, string dt, string pt, string r)
        {
            this._User = u;
            this._Game = g;
            this.DateTime = dt;
            this.PlayTime = pt;
            this.Result = r;
        }
    }
}
