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
    public partial class GameForm : Form
    {
        public GameController GameController;

        public GameForm() : base()
        {
            InitializeComponent();

            GameController = new GameController(this);
        }

        private void SnakeUpButton_Click(object sender, EventArgs e)
        {
            GameController.MoveUp();
        }

        private void SnakeDownButton_Click(object sender, EventArgs e)
        {
            GameController.MoveDown();
        }

        private void SnakeLeftButton_Click(object sender, EventArgs e)
        {
            GameController.MoveLeft();
        }

        private void SnakeRightButton_Click(object sender, EventArgs e)
        {
            GameController.MoveRight();
        }

        private void CanvasPictureBox_Paint(object sender, PaintEventArgs e)
        {
            GameController.DrawAll(e.Graphics);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (GameController.KeyCheck(keyData))
            {
                if (InputController.KeyPressed(Keys.Enter))
                {
                    GameController.StartGame();
                }

                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void SpeedTrackBar_Scroll(object sender, EventArgs e)
        {
            GameController.SetSpeed(SpeedTrackBar.Value);
        }

        private void WallEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GameController.SetWallDisabled(WallDisabledCheckBox.Checked);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            GameController.StartGame();
        }
    }
}
