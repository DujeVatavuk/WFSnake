using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFSnake.Models;

namespace WFSnake.Controllers
{
    public class GameController
    {
        private GameForm _gameForm;
        private Configuration _configuration;
        private ConfigurationController _configurationController;
        private List<SnakeBlock> _snake = new List<SnakeBlock>();
        private SnakeBlock _food = new SnakeBlock();

        public GameController(GameForm gameForm)
        {
            _gameForm = gameForm;

            _configurationController = new ConfigurationController();

            _configuration = new Configuration();

            _gameForm.GameTimer.Interval = 1000 / _configuration.Speed;
            _gameForm.GameTimer.Tick += _UpdateScreen;
            _gameForm.GameTimer.Start();
        }

        public void StartGame()
        {
            _configuration = _configurationController.NewGameConfiguration(_configuration);

            _snake.Clear();
            SnakeBlock head = new SnakeBlock { X = 10, Y = 5 };
            _snake.Add(head);

            _gameForm.ScoreLabel.Text = _configuration.Score.ToString();
            _gameForm.WallDisabledCheckBox.Checked = _configuration.WallDisabled;

            _GenerateFood();
        }

        public void MoveUp()
        {
            if (_configuration.Direction != Direction.Down)
            {
                InputController.ChangeState(Keys.Up, true);
            }
        }

        public void MoveDown()
        {
            if (_configuration.Direction != Direction.Up)
            {
                InputController.ChangeState(Keys.Down, true);
            }
        }

        public void MoveLeft()
        {
            if (_configuration.Direction != Direction.Right)
            {
                InputController.ChangeState(Keys.Left, true);
            }
        }

        public void MoveRight()
        {
            if (_configuration.Direction != Direction.Left)
            {
                InputController.ChangeState(Keys.Right, true);
            }
        }

        public void DrawSnake(Graphics canvas)
        {
            if (!_configuration.GameOver)
            {
                Brush snakeColour;

                for (int i = 0; i < _snake.Count; i++)
                {
                    if (i == 0)
                    {
                        snakeColour = Brushes.DimGray;

                        canvas.FillRectangle(snakeColour,
                        new Rectangle(_snake[i].X * _configuration.Width,
                                      _snake[i].Y * _configuration.Height,
                                      _configuration.Width, _configuration.Height));
                    }
                    else
                    {
                        snakeColour = Brushes.Turquoise;

                        canvas.FillRectangle(snakeColour,
                         new Rectangle(_snake[i].X * _configuration.Width,
                                       _snake[i].Y * _configuration.Height,
                                       _configuration.Width - 2, _configuration.Height - 2));
                    }

                    canvas.FillRectangle(Brushes.DeepPink,
                        new Rectangle(_food.X * _configuration.Width,
                        _food.Y * _configuration.Height, _configuration.Width, _configuration.Height));
                }
            }
        }

        public bool KeyCheck(Keys keyData)
        {
            if (keyData == Keys.Left || keyData == Keys.Right || keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Enter)
            {
                InputController.ChangeState(keyData, true);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetSpeed(int speed)
        {
            _configuration.Speed = speed;
            _gameForm.GameTimer.Interval = 1000 / _configuration.Speed;
        }

        public void SetWallDisabled(bool disabled)
        {
            _configuration.WallDisabled = disabled;
        }

        private void _UpdateScreen(object sender, EventArgs e)
        {
            if (InputController.KeyPressed(Keys.Enter))
            {
                StartGame();
            }
            else
            {
                if (_configuration.GameOver)
                {
                    return;
                }

                if (InputController.KeyPressed(Keys.Right) && _configuration.Direction != Direction.Left)
                    _configuration.Direction = Direction.Right;
                else if (InputController.KeyPressed(Keys.Left) && _configuration.Direction != Direction.Right)
                    _configuration.Direction = Direction.Left;
                else if (InputController.KeyPressed(Keys.Up) && _configuration.Direction != Direction.Down)
                    _configuration.Direction = Direction.Up;
                else if (InputController.KeyPressed(Keys.Down) && _configuration.Direction != Direction.Up)
                    _configuration.Direction = Direction.Down;

                _MovePlayer();
            }
            _gameForm.CanvasPictureBox.Invalidate();
        }

        private void _GenerateFood()
        {
            int a = 0;
            int b = 0;
            int i = 0;
            bool T;
            int maxXPos = _gameForm.CanvasPictureBox.Size.Width / _configuration.Width;
            int maxYPos = _gameForm.CanvasPictureBox.Size.Height / _configuration.Height;

            Random random = new Random();
            _food = new SnakeBlock();

            do
            {
                T = false;
                a = random.Next(0, maxXPos);
                b = random.Next(0, maxYPos);

                for (i = 0; i < _snake.Count; i++)
                {
                    if (a == _snake[i].X && b == _snake[i].Y)
                    {
                        T = true;
                        break;
                    }
                }
            } while (T);

            _food.X = a;
            _food.Y = b;
        }

        private void _MovePlayer()
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

                    int maxXPos = _gameForm.CanvasPictureBox.Size.Width / _configuration.Width;
                    int maxYPos = _gameForm.CanvasPictureBox.Size.Height / _configuration.Height;

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
                    if (_snake[0].X == _food.X && _snake[0].Y == _food.Y)
                    {
                        _Eat();
                    }

                }
                else
                {
                    _snake[i].X = _snake[i - 1].X;
                    _snake[i].Y = _snake[i - 1].Y;
                }
            }
        }

        private void _Eat()
        {
            SnakeBlock food = new SnakeBlock();
            food.X = _snake[_snake.Count - 1].X;
            food.Y = _snake[_snake.Count - 1].Y;

            _snake.Add(food);

            _configuration.Score += _configuration.Points;
            _gameForm.ScoreLabel.Text = _configuration.Score.ToString();

            _GenerateFood();
        }

        private void _Die()
        {
            _configuration.GameOver = true;

            MessageBox.Show("Gotova igra \nTvoj rezultat je: " + _configuration.Score + "\nPritisni dvaput ENTER za ponovo poceti.", "Probajte ponovo");
        }


    }
}
