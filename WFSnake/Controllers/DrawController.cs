using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFSnake.Models;

namespace WFSnake.Controllers
{
    public class DrawController
    {
        private Configuration _configuration;
        private Graphics _canvas;
        private Snake _snake;
        private Food _food;

        public DrawController(Configuration configuration)
        {
            _configuration = configuration;
        }

        public void DrawAll(Graphics canvas, Snake snake, Food food)
        {
            _canvas = canvas;
            _snake = snake;
            _food = food;

            if (_snake == null)
            {
                return;
            }

            if (_food == null)
            {
                return;
            }

            // TODO: hranu crtamo samo ako je igra startana, a ovo ja hack
            if (_snake.Count > 0 && !_configuration.GameOver)
            {
                _DrawSnake();
                _DrawFood();
            }
        }

        private void _DrawSnake()
        {
            for (int i = 0; i < _snake.Count; i++)
            {
                if (i == 0)
                {
                    _DrawSnakeHead(i);
                }
                else
                {
                    _DrawSnakeTail(i);
                }
            }
        }

        private void _DrawSnakeHead(int i)
        {
            _canvas.FillRectangle(Brushes.DimGray,
                new Rectangle(_snake.GetBuildingBlocks[i].X * _configuration.Width,
                              _snake.GetBuildingBlocks[i].Y * _configuration.Height,
                              _configuration.Width,
                              _configuration.Height));
        }

        private void _DrawSnakeTail(int i)
        {
            _canvas.FillRectangle(Brushes.Turquoise,
                 new Rectangle(_snake.GetBuildingBlocks[i].X * _configuration.Width,
                               _snake.GetBuildingBlocks[i].Y * _configuration.Height,
                               _configuration.Width - 2,
                               _configuration.Height - 2));
        }

        private void _DrawFood()
        {
            _canvas.FillRectangle(Brushes.DeepPink,
                new Rectangle(_food.GetBuildingBlock.X * _configuration.Width,
                                _food.GetBuildingBlock.Y * _configuration.Height,
                                _configuration.Width,
                                _configuration.Height));
        }
    }
}
