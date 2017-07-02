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

        private void SnkUp_Click(object sender, EventArgs e)
        {
            GameController.MoveUp();
        }

        private void SnkDown_Click(object sender, EventArgs e)
        {
            GameController.MoveDown();
        }

        private void SnkLeft_Click(object sender, EventArgs e)
        {
            GameController.MoveLeft();
        }

        private void SnkRight_Click(object sender, EventArgs e)
        {
            GameController.MoveRight();
        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            GameController.DrawSnake(e.Graphics);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (GameController.KeyCheck(keyData))
            {
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void TBSpeed_Scroll(object sender, EventArgs e)
        {
            GameController.SetSpeed(TBSpeed.Value);
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
