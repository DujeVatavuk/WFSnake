using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFSnake.Controllers;

namespace WFSnake
{
    public partial class PlayerForm : Form
    {
        private LeaderboardController _leaderboardController;


        public PlayerForm(LeaderboardController leaderboardController)
        {
            InitializeComponent();

            _leaderboardController = leaderboardController;
            _leaderboardController.SetControls();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            string nick = NickTextBox.Text.Trim();
            //if (string.IsNullOrEmpty(nick))
            //{
            //    nick = "Player1";
            //}
            _leaderboardController.SetPlayer(nick);
        }

        private void PlayerForm_Shown(object sender, EventArgs e)
        {
            _leaderboardController.SetControls();
        }
    }
}
