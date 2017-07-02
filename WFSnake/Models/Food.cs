using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFSnake.Models
{
    public class Food
    {
        private Configuration _configuration;
        private Snake _snake;
        private BuildingBlock _food = new BuildingBlock();
        public BuildingBlock GetBuildingBlock
        {
            get { return _food; }
        }

        public Food(Configuration configuration, Snake snake)
        {
            _configuration = configuration;
            _snake = snake;
            GenerateFood();
        }

        public void GenerateFood()
        {
            int a = 0;
            int b = 0;
            int i = 0;
            bool T;

            Random random = new Random();
            _food = new BuildingBlock();

            int _maxXPos = _configuration.MaxXPos;
            int _maxYPos = _configuration.MaxYPos;

            do
            {
                T = false;
                a = random.Next(0, _maxXPos);
                b = random.Next(0, _maxYPos);

                for (i = 0; i < _snake.Count; i++)
                {
                    if (a == _snake.GetBuildingBlocks[i].X && b == _snake.GetBuildingBlocks[i].Y)
                    {
                        T = true;
                        break;
                    }
                }
            } while (T);

            _food.X = a;
            _food.Y = b;
        }
    }
}
