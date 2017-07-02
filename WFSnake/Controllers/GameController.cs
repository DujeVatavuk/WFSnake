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
        private DrawController _drawController;
        private LeaderboardController _leaderboardController;
        private Snake _snake;
        private Food _food;
        private Player _player;

        public GameController(GameForm gameForm)
        {
            _gameForm = gameForm;

            _configuration = new Configuration(_gameForm.CanvasPictureBox.Size.Width, _gameForm.CanvasPictureBox.Size.Height);

            _drawController = new DrawController(_configuration);

            _leaderboardController = new LeaderboardController();

            _gameForm.GameTimer.Interval = 1000 / _configuration.Speed;
            _gameForm.GameTimer.Tick += _UpdateScreen;
        }

        public void StartGame()
        {
            _gameForm.GameTimer.Stop();

            PlayerForm playerForm = _leaderboardController.GetPlayerForm();
            if (playerForm.ShowDialog() == DialogResult.OK)
            {
                _configuration.NewGameConfiguration();

                _gameForm.ScoreLabel.Text = _configuration.Score.ToString();
                _gameForm.WallDisabledCheckBox.Checked = _configuration.WallDisabled;

                _snake = new Snake(_configuration);
                _food = new Food(_configuration, _snake);

                _gameForm.GameTimer.Start();
            }
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

        public void DrawAll(Graphics canvas)
        {
            _drawController.DrawAll(canvas, _snake, _food);
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

            _snake.MoveSnake(_food);
            _gameForm.ScoreLabel.Text = _configuration.Score.ToString();
            _gameForm.NickLabel.Text = _leaderboardController.GetNick();

            if (_configuration.GameOver)
            {
                _leaderboardController.AddScore(_configuration.Score);
                MessageBox.Show(string.Format("Gotova igra \nTvoj rezultat je: {0}\nPritisni dvaput ENTER za ponovo poćeti.", _configuration.Score), "Probajte ponovo");
                StartGame();
            }

            _gameForm.CanvasPictureBox.Invalidate();
        }
    }
}
