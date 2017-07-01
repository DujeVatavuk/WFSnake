using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFSnake.Models
{
    public class Configuration
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Speed { get; set; }
        public int Score { get; set; }
        public int Points { get; set; }
        public bool GameOver { get; set; }
        public Direction Direction { get; set; }
        public bool WallDisabled { get; set; }

        public Configuration()
        {
            Width = 20;
            Height = 20;
            Speed = 20;
            Score = 0;
            Points = 100;
            GameOver = false;
            Direction = Direction.Down;
            WallDisabled = true;
        }
    }
}
