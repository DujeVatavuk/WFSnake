using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFSnake.Models
{
    public class Snake
    {
        private List<BuildingBlock> _snake;
        private Configuration _configuration;

        public int Count
        {
            get { return _snake.Count; }
        }

        public List<BuildingBlock> GetBuildingBlocks
        {
            get { return _snake; }
        }

        public Snake(Configuration configuration)
        {
            _configuration = configuration;
            _snake = new List<BuildingBlock>();

            BuildingBlock head = new BuildingBlock { X = 10, Y = 5 };
            _snake.Add(head);
        }

        public void MoveSnake(Food food)
        {
            for (int i = _snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (_configuration.Direction)
                    {
                        case Direction.Right:
                            _snake[i].X++;
                            break;
                        case Direction.Left:
                            _snake[i].X--;
                            break;
                        case Direction.Up:
                            _snake[i].Y--;
                            break;
                        case Direction.Down:
                            _snake[i].Y++;
                            break;
                    }

                    int maxXPos = _configuration.MaxXPos;
                    int maxYPos = _configuration.MaxYPos;

                    // Granice
                    if (!_configuration.WallDisabled)
                    {
                        if (_snake[i].X < 0 || _snake[i].Y < 0 || _snake[i].X > maxXPos || _snake[i].Y > maxYPos)
                        {
                            _Die();
                        }
                    }
                    else
                    {
                        if (_snake[i].X < 0)
                        {
                            _snake[i].X = maxXPos;
                        }
                        else if (_snake[i].Y < 0)
                        {
                            _snake[i].Y = maxYPos;
                        }
                        else if (_snake[i].X >= maxXPos)
                        {
                            _snake[i].X = 0;
                        }
                        else if (_snake[i].Y >= maxYPos)
                        {
                            _snake[i].Y = 0;
                        }
                    }

                    // Sama sa sobom
                    for (int j = 1; j < _snake.Count; j++)
                    {
                        if (_snake[i].X == _snake[j].X && _snake[i].Y == _snake[j].Y)
                        {
                            _Die();
                        }
                    }

                    // Ji spizu
                    if (_snake[0].X == food.GetBuildingBlock.X && _snake[0].Y == food.GetBuildingBlock.Y)
                    {
                        _Eat(food);
                    }

                }
                else
                {
                    _snake[i].X = _snake[i - 1].X;
                    _snake[i].Y = _snake[i - 1].Y;
                }
            }
        }

        private void _Eat(Food food)
        {
            BuildingBlock foodBuildingBlock = new BuildingBlock();
            foodBuildingBlock.X = _snake[_snake.Count - 1].X;
            foodBuildingBlock.Y = _snake[_snake.Count - 1].Y;

            _snake.Add(foodBuildingBlock);

            _configuration.Score += _configuration.Points;

            food.GenerateFood();
        }

        private void _Die()
        {
            _configuration.GameOver = true;
        }
    }
}
