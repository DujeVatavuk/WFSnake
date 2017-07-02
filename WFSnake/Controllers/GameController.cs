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
        private Configuration Configuration;
        private ConfigurationController ConfigurationController;

        private List<SnakeBlock> Snake = new List<SnakeBlock>();
        private SnakeBlock food = new SnakeBlock();

        public GameController(GameForm gameForm)
        {
            _gameForm = gameForm;

            ConfigurationController = new ConfigurationController();

            Configuration = new Configuration();

            _gameForm.GameTimer.Interval = 1000 / Configuration.Speed;
            _gameForm.GameTimer.Tick += UpdateScreen;
            _gameForm.GameTimer.Start();
        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            if (InputController.KeyPressed(Keys.Enter))
            {
                StartGame();
            }
            else
            {
                if (Configuration.GameOver)
                {
                    return;
                }

                if (InputController.KeyPressed(Keys.Right) && Configuration.Direction != Direction.Left)
                    Configuration.Direction = Direction.Right;
                else if (InputController.KeyPressed(Keys.Left) && Configuration.Direction != Direction.Right)
                    Configuration.Direction = Direction.Left;
                else if (InputController.KeyPressed(Keys.Up) && Configuration.Direction != Direction.Down)
                    Configuration.Direction = Direction.Up;
                else if (InputController.KeyPressed(Keys.Down) && Configuration.Direction != Direction.Up)
                    Configuration.Direction = Direction.Down;

                MovePlayer();
            }
            _gameForm.CanvasPictureBox.Invalidate();
        }

        public void StartGame()
        {
            Configuration = ConfigurationController.NewGameConfiguration(Configuration);

            Snake.Clear();
            SnakeBlock head = new SnakeBlock { X = 10, Y = 5 };
            Snake.Add(head);

            _gameForm.ScoreLabel.Text = Configuration.Score.ToString();
            _gameForm.WallDisabledCheckBox.Checked = Configuration.WallDisabled;

            GenerateFood();
        }

        private void GenerateFood()
        {
            int a = 0;
            int b = 0;
            int i = 0;
            bool T;
            int maxXPos = _gameForm.CanvasPictureBox.Size.Width / Configuration.Width;
            int maxYPos = _gameForm.CanvasPictureBox.Size.Height / Configuration.Height;

            Random random = new Random();
            food = new SnakeBlock();

            do
            {
                T = false;
                a = random.Next(0, maxXPos);
                b = random.Next(0, maxYPos);

                for (i = 0; i < Snake.Count; i++)
                {
                    if (a == Snake[i].X && b == Snake[i].Y)
                    {
                        T = true;
                        break;
                    }
                }
            } while (T);

            food.X = a;
            food.Y = b;
        }

        private void MovePlayer()
        {
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Configuration.Direction)
                    {
                        case Direction.Right:
                            Snake[i].X++;
                            break;
                        case Direction.Left:
                            Snake[i].X--;
                            break;
                        case Direction.Up:
                            Snake[i].Y--;
                            break;
                        case Direction.Down:
                            Snake[i].Y++;
                            break;
                    }

                    int maxXPos = _gameForm.CanvasPictureBox.Size.Width / Configuration.Width;
                    int maxYPos = _gameForm.CanvasPictureBox.Size.Height / Configuration.Height;

                    // Granice
                    if (!Configuration.WallDisabled)
                    {
                        if (Snake[i].X < 0 || Snake[i].Y < 0 || Snake[i].X > maxXPos || Snake[i].Y > maxYPos)
                        {
                            Die();
                        }
                    }
                    else
                    {
                        if (Snake[i].X < 0)
                        {
                            Snake[i].X = maxXPos;
                        }
                        else if (Snake[i].Y < 0)
                        {
                            Snake[i].Y = maxYPos;
                        }
                        else if (Snake[i].X >= maxXPos)
                        {
                            Snake[i].X = 0;
                        }
                        else if (Snake[i].Y >= maxYPos)
                        {
                            Snake[i].Y = 0;
                        }
                    }

                    // Sama sa sobom
                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            Die();
                        }
                    }

                    // Ji spizu
                    if (Snake[0].X == food.X && Snake[0].Y == food.Y)
                    {
                        Eat();
                    }

                }
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
        }

        private void Eat()
        {
            SnakeBlock food = new SnakeBlock();
            food.X = Snake[Snake.Count - 1].X;
            food.Y = Snake[Snake.Count - 1].Y;

            Snake.Add(food);

            Configuration.Score += Configuration.Points;
            _gameForm.ScoreLabel.Text = Configuration.Score.ToString();

            GenerateFood();
        }

        private void Die()
        {
            Configuration.GameOver = true;

            MessageBox.Show("Gotova igra \nTvoj rezultat je: " + Configuration.Score + "\nPritisni dvaput ENTER za ponovo poceti.", "Probajte ponovo");
        }

        public void MoveUp()
        {
            if (Configuration.Direction != Direction.Down)
            {
                InputController.ChangeState(Keys.Up, true);
            }
        }

        public void MoveDown()
        {
            if (Configuration.Direction != Direction.Up)
            {
                InputController.ChangeState(Keys.Down, true);
            }
        }

        public void MoveLeft()
        {
            if (Configuration.Direction != Direction.Right)
            {
                InputController.ChangeState(Keys.Left, true);
            }
        }

        public void MoveRight()
        {
            if (Configuration.Direction != Direction.Left)
            {
                InputController.ChangeState(Keys.Right, true);
            }
        }

        public void DrawSnake(Graphics canvas)
        {
            if (!Configuration.GameOver)
            {
                Brush snakeColour;

                for (int i = 0; i < Snake.Count; i++)
                {
                    if (i == 0)
                    {
                        snakeColour = Brushes.DimGray;

                        canvas.FillRectangle(snakeColour,
                        new Rectangle(Snake[i].X * Configuration.Width,
                                      Snake[i].Y * Configuration.Height,
                                      Configuration.Width, Configuration.Height));
                    }
                    else
                    {
                        snakeColour = Brushes.Turquoise;

                        canvas.FillRectangle(snakeColour,
                         new Rectangle(Snake[i].X * Configuration.Width,
                                       Snake[i].Y * Configuration.Height,
                                       Configuration.Width - 2, Configuration.Height - 2));
                    }

                    canvas.FillRectangle(Brushes.DeepPink,
                        new Rectangle(food.X * Configuration.Width,
                        food.Y * Configuration.Height, Configuration.Width, Configuration.Height));
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
            Configuration.Speed = speed;
            _gameForm.GameTimer.Interval = 1000 / Configuration.Speed;
        }

        public void SetWallDisabled(bool disabled)
        {
            Configuration.WallDisabled = disabled;
        }
    }
}
