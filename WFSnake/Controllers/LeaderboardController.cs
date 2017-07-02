using System;
using System.Collections.Generic;
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

        public LeaderboardController()
        {
            _leaderboard = new Leaderboard();
            Load();
        }

        public void Load()
        {
            //_leaderboard.Players.Add(new Player { Rank = 999, Nick = "Nick1", Score = 1000 });
            //_leaderboard.Players.Add(new Player { Rank = 999, Nick = "Nick2", Score = 2000 });
            //_leaderboard.Players.Add(new Player { Rank = 999, Nick = "Nick3", Score = 3000 });
            //_leaderboard.Players.Add(new Player { Rank = 999, Nick = "Nick4", Score = 4000 });
            //_leaderboard.Players.Add(new Player { Rank = 999, Nick = "Nick5", Score = 5000 });
            //_leaderboard.Players.Add(new Player { Rank = 999, Nick = "Nick6", Score = 6000 });
            //_leaderboard.Players.Add(new Player { Rank = 999, Nick = "Nick7", Score = 7000 });
            SetPlayer("Nick1");
            AddScore(1000);
            SetPlayer("Nick2");
            AddScore(2000);
            SetPlayer("Nick3");
            AddScore(3000);
            SetPlayer("Nick4");
            AddScore(4000);
            SetPlayer("Nick5");
            AddScore(5000);
            SetPlayer("Nick6");
            AddScore(6000);
            SetPlayer("Nick7");
            AddScore(7000);
            SetLeadeboard();
        }

        public void SetPlayer(string nick)
        {
            _leaderboard.SetCurrentPlayer(nick);
        }

        public void AddScore(int score)
        {
            _leaderboard.AddScore(score);
        }

        public void SetLeadeboard()
        {
            if (PlayerForm == null)
            {
                return;
            }
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
