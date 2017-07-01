using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using WFSnake.Models;
using WFSnake.Controllers;

namespace WFSnake
{
    public partial class Form1 : Form
    {
        public ConfigurationController ConfigurationController;



        private List<SnakeBlock> Snake = new List<SnakeBlock>();
        private SnakeBlock food = new SnakeBlock();

        public Configuration Configuration;

        public Form1() : base()
        {
            InitializeComponent();

            ConfigurationController = new ConfigurationController();


            Configuration = new Configuration();

            gameTimer.Interval = 1000 / Configuration.Speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();
            //StartGame();
        }

        private void StartGame()
        {
            Configuration = ConfigurationController.NewGameConfiguration(Configuration);

            Snake.Clear();
            SnakeBlock head = new SnakeBlock { X = 10, Y = 5 };
            Snake.Add(head);

            lblScore.Text = Configuration.Score.ToString();
            WallDisabledCheckBox.Checked = Configuration.WallDisabled;

            GenerateFood();
        }

        private void GenerateFood()
        {
            int a = 0;
            int b = 0;
            int i = 0;
            bool T;
            int maxXPos = pbCanvas.Size.Width / Configuration.Width;
            int maxYPos = pbCanvas.Size.Height / Configuration.Height;

            Random random = new Random();
            food = new SnakeBlock();
            /*A: //Vise nije bitno
            a = random.Next(0, maxXPos);
            b = random.Next(0, maxYPos);

            for (i = 0; i < Snake.Count; i++) 
            {
                if(a == Snake[i].X && b == Snake[i].Y)
                {
                    goto A;
                }
            }*/
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

        private void SnkUp_Click(object sender, EventArgs e)
        {
            Button Q = (Button)sender;
            if (Configuration.Direction != Direction.Down)
            {
                //Settings.direction = Direction.Up;
                InputController.ChangeState(Keys.Up, true);
            }
        }

        private void SnkDown_Click(object sender, EventArgs e)
        {
            Button W = (Button)sender;
            if (Configuration.Direction != Direction.Up)
            {
                //Settings.direction = Direction.Down;
                InputController.ChangeState(Keys.Down, true);
            }
        }

        private void SnkLeft_Click(object sender, EventArgs e)
        {
            Button E = (Button)sender;
            if (Configuration.Direction != Direction.Right)
            {
                //Settings.direction = Direction.Left;
                InputController.ChangeState(Keys.Left, true);
            }

        }

        private void SnkRight_Click(object sender, EventArgs e)
        {
            Button r = (Button)sender;
            if (Configuration.Direction != Direction.Left)
            {
                //Settings.direction = Direction.Right;
                InputController.ChangeState(Keys.Right, true);
            }

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
            pbCanvas.Invalidate();
        }


        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (!Configuration.GameOver)
            {
                Brush snakeColour;

                for (int i = 0; i < Snake.Count; i++)
                {
                    if (i == 0)
                    {
                        snakeColour = Brushes.DimGray;

                        canvas.FillRectangle(snakeColour,
                        new System.Drawing.Rectangle(Snake[i].X * Configuration.Width,
                                      Snake[i].Y * Configuration.Height,
                                      Configuration.Width, Configuration.Height));
                    }
                    else
                    {
                        snakeColour = Brushes.Turquoise;

                        canvas.FillRectangle(snakeColour,
                         new System.Drawing.Rectangle(Snake[i].X * Configuration.Width,
                                       Snake[i].Y * Configuration.Height,
                                       Configuration.Width - 2, Configuration.Height - 2));
                    }


                    canvas.FillRectangle(Brushes.DeepPink,
                        new System.Drawing.Rectangle(food.X * Configuration.Width,
                        food.Y * Configuration.Height, Configuration.Width, Configuration.Height));
                }
            }
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

                    int maxXPos = pbCanvas.Size.Width / Configuration.Width;
                    int maxYPos = pbCanvas.Size.Height / Configuration.Height;

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
            lblScore.Text = Configuration.Score.ToString();

            GenerateFood();
        }

        private void Die()
        {
            Configuration.GameOver = true;

            MessageBox.Show("Gotova igra \nTvoj rezultat je: " + Configuration.Score + "\nPritisni dvaput ENTER za ponovo poceti.", "Probajte ponovo");
        }

        //private void Form1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    this.Focus();
        //    Input.ChangeState(e.KeyCode, true);
        //    this.UpdateScreen(sender, e);
        //    e.Handled = true;
        //}

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left || keyData == Keys.Right || keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Enter)
            {
                InputController.ChangeState(keyData, true);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        //private void Form1_KeyUp(object sender, KeyEventArgs e)
        //{
        //    Input.ChangeState(e.KeyCode, false);
        //}

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pbCanvas_Click(object sender, EventArgs e)
        {

        }

        private void TBSpeed_Scroll(object sender, EventArgs e)
        {
            Configuration.Speed = TBSpeed.Value;
            gameTimer.Interval = 1000 / Configuration.Speed;
        }

        private void WallEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Configuration.WallDisabled = WallDisabledCheckBox.Checked;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartGame();
        }
    }
}
