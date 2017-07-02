using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFSnake.Models;

namespace WFSnake.Controllers
{
    public class LeaderboardController
    {
        public PlayerForm PlayerForm { get; set; }
        private Leaderboard _leaderboard;
        private RespositoryController _respositoryController;

        public LeaderboardController()
        {
            _leaderboard = new Leaderboard();
            _respositoryController = new RespositoryController();
            _leaderboard= _respositoryController.LoadLeaderboard(_leaderboard);
        }

        public void SetPlayer(string nick)
        {
            _leaderboard.SetCurrentPlayer(nick);
            _respositoryController.SaveNick(nick);
        }

        public void AddScore(int score)
        {
            _leaderboard.AddScore(score);
            _respositoryController.SaveLeaderboard(_leaderboard);
        }

        public string GetNick()
        {
            return _respositoryController.LoadNick();
        }

        public void SetControls()
        {
            if (PlayerForm == null)
            {
                return;
            }
            PlayerForm.NickTextBox.Text = GetNick();
            PlayerForm.LeaderboardDataGridView.DataSource = _leaderboard.GetLeaderboard();
        }

        public PlayerForm GetPlayerForm()
        {
            if (PlayerForm == null)
            {
                PlayerForm = new PlayerForm(this)
                {
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    StartPosition = FormStartPosition.CenterScreen
                };
            }
            return PlayerForm;
        } 
    }
}
