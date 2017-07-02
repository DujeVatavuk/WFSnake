using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFSnake.Models
{
    [Serializable]
    public class Player
    {
        public int Rank { get; set; }
        public string Nick { get; set; }
        public int Score { get; set; }

        public Player()
        {
            Rank = 999;
            Nick = "Player1";
            Score = 0;
        }

        public Player(string nick)
        {
            Rank = 999;
            Nick = nick;
            Score = 0;
        }
    }
}
