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

namespace WFSnake
{
    public partial class Form1 : Form
    {
        private List<Rectangle> Snake = new List<Rectangle>();
        private Rectangle food = new Rectangle();

        public Settings Settings = new Settings();

        public Form1() : base()
        {
            InitializeComponent();

            new Settings();

            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();

            SpeechSynthesizer sSynth = new SpeechSynthesizer();
            PromptBuilder pBuilder = new PromptBuilder();
            SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine();

            Choices sList = new Choices();
            sList.Add(new string[] { "left", "up", "down", "right", "exit", "restart" });
            Grammar gr = new Grammar(new GrammarBuilder(sList));
            try
            {
                sRecognize.RequestRecognizerUpdate();
                sRecognize.LoadGrammar(gr);
                sRecognize.SpeechRecognized += sRecognize_speechRecognized;
                sRecognize.SetInputToDefaultAudioDevice();
                sRecognize.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch
            {
                return;
            }

            //StartGame();
        }

        private void sRecognize_speechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text == "up")
            {
                if (Settings.Direction != Direction.Down)
                    Input.ChangeState(Keys.Up, true);
            }
            else if (e.Result.Text == "down")
            {
                if (Settings.Direction != Direction.Up)
                    Input.ChangeState(Keys.Down, true);
            }
            else if (e.Result.Text == "left")
            {
                if (Settings.Direction != Direction.Right)
                    Input.ChangeState(Keys.Left, true);
            }
            else if (e.Result.Text == "right")
            {
                if (Settings.Direction != Direction.Left)
                    Input.ChangeState(Keys.Right, true);
            }
            else if (e.Result.Text == "exit")
            {
                Application.Exit();
            }
            else if (e.Result.Text == "restart")
            {
                Application.Restart();
            }
        }

        private void StartGame()
        {
            Settings.NewGameSettings();

            Snake.Clear();
            Rectangle head = new Rectangle { X = 10, Y = 5 };
            Snake.Add(head);

            lblScore.Text = Settings.Score.ToString();
            WallDisabledCheckBox.Checked = Settings.WallDisabled;

            GenerateFood();
        }

        private void GenerateFood()
        {
            int a = 0;
            int b = 0;
            int i = 0;
            bool T;
            int maxXPos = pbCanvas.Size.Width / Settings.Width;
            int maxYPos = pbCanvas.Size.Height / Settings.Height;

            Random random = new Random();
            food = new Rectangle();
            /*A:
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
            if (Settings.Direction != Direction.Down)
            {
                //Settings.direction = Direction.Up;
                Input.ChangeState(Keys.Up, true);
            }
        }

        private void SnkDown_Click(object sender, EventArgs e)
        {
            Button W = (Button)sender;
            if (Settings.Direction != Direction.Up)
            {
                //Settings.direction = Direction.Down;
                Input.ChangeState(Keys.Down, true);
            }
        }

        private void SnkLeft_Click(object sender, EventArgs e)
        {
            Button E = (Button)sender;
            if (Settings.Direction != Direction.Right)
            {
                //Settings.direction = Direction.Left;
                Input.ChangeState(Keys.Left, true);
            }

        }

        private void SnkRight_Click(object sender, EventArgs e)
        {
            Button r = (Button)sender;
            if (Settings.Direction != Direction.Left)
            {
                //Settings.direction = Direction.Right;
                Input.ChangeState(Keys.Right, true);
            }

        }


        private void UpdateScreen(object sender, EventArgs e)
        {
            if (Input.KeyPressed(Keys.Enter))
            {
                StartGame();
            }
            else
            {
                if (Settings.GameOver)
                {
                    return;
                }


                if (Input.KeyPressed(Keys.Right) && Settings.Direction != Direction.Left)
                    Settings.Direction = Direction.Right;
                else if (Input.KeyPressed(Keys.Left) && Settings.Direction != Direction.Right)
                    Settings.Direction = Direction.Left;
                else if (Input.KeyPressed(Keys.Up) && Settings.Direction != Direction.Down)
                    Settings.Direction = Direction.Up;
                else if (Input.KeyPressed(Keys.Down) && Settings.Direction != Direction.Up)
                    Settings.Direction = Direction.Down;

                MovePlayer();
            }
            pbCanvas.Invalidate();
        }


        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (!Settings.GameOver)
            {
                Brush snakeColour;

                for (int i = 0; i < Snake.Count; i++)
                {
                    if (i == 0)
                    {
                        snakeColour = Brushes.DimGray;

                        canvas.FillRectangle(snakeColour,
                        new System.Drawing.Rectangle(Snake[i].X * Settings.Width,
                                      Snake[i].Y * Settings.Height,
                                      Settings.Width, Settings.Height));
                    }
                    else
                    {
                        snakeColour = Brushes.Turquoise;

                        canvas.FillRectangle(snakeColour,
                         new System.Drawing.Rectangle(Snake[i].X * Settings.Width,
                                       Snake[i].Y * Settings.Height,
                                       Settings.Width - 2, Settings.Height - 2));
                    }


                    canvas.FillRectangle(Brushes.DeepPink,
                        new System.Drawing.Rectangle(food.X * Settings.Width,
                        food.Y * Settings.Height, Settings.Width, Settings.Height));
                }
            }
        }

        private void MovePlayer()
        {
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.Direction)
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

                    int maxXPos = pbCanvas.Size.Width / Settings.Width;
                    int maxYPos = pbCanvas.Size.Height / Settings.Height;

                    // Granice
                    if (!Settings.WallDisabled)
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
            Rectangle food = new Rectangle();
            food.X = Snake[Snake.Count - 1].X;
            food.Y = Snake[Snake.Count - 1].Y;

            Snake.Add(food);

            Settings.Score += Settings.Points;
            lblScore.Text = Settings.Score.ToString();

            GenerateFood();
        }

        private void Die()
        {
            Settings.GameOver = true;

            MessageBox.Show("Gotova igra \nTvoj rezultat je: " + Settings.Score + "\nPritisni dvaput ENTER za ponovo poceti.", "Probajte ponovo");
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
                Input.ChangeState(keyData, true);
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
            Settings.Speed = TBSpeed.Value;
            gameTimer.Interval = 1000 / Settings.Speed;
        }

        private void WallEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.WallDisabled = WallDisabledCheckBox.Checked;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartGame();
        }
    }
}
