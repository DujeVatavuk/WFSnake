using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFSnake
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    };
    public class Settings
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Speed { get; set; }
        public int Score { get; set; }
        public int Points { get; set; }
        public bool GameOver { get; set; }
        public Direction Direction { get; set; }
        public bool WallDisabled { get; set; }

        public Settings()
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

        public void NewGameSettings()
        {
            Score = 0;
            Points = 100;
            GameOver = false;
            Direction = Direction.Down;
        }

    }
}
