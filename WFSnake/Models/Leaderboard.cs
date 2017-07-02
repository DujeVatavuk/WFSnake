using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFSnake.Models
{
    [Serializable]
    public class Leaderboard
    {
        public List<Player> Players;
        public Player CurrentPlayer { get; set; }

        public Leaderboard()
        {
            Players = new List<Player>();
        }

        public Player SetCurrentPlayer(string nick)
        {
            CurrentPlayer = Players
                .OrderByDescending(p => p.Score)
                .FirstOrDefault(p => p.Nick == nick);

            if (CurrentPlayer == null)
            {
                CurrentPlayer = new Player(nick);
                Players.Add(CurrentPlayer);
            }
            return CurrentPlayer;
        }

        public void AddScore(int score)
        {
            if (score > CurrentPlayer.Score)
            {
                CurrentPlayer.Score = score;
            }
        }

        public List<Player> GetLeaderboard()
        {
            Players = Players.OrderByDescending(p => p.Score)
                //.ThenBy(p => p.Rank)
                .Select((p, i) => new Player {
                    Rank = (i + 1),
                    Nick = p.Nick,
                    Score = p.Score })
                .ToList();

            return Players;
        }
    }
}
