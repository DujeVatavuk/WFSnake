using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using WFSnake.Models;

namespace WFSnake.Controllers
{
    public class LeaderboardController
    {
        public PlayerForm PlayerForm { get; set; }
        private Leaderboard _leaderboard;
        private string leaderboardFileName;

        public LeaderboardController()
        {
            leaderboardFileName = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Leaderboard.xml");

            _leaderboard = new Leaderboard();

            _LoadLeaderboard();
        }

        public void SetPlayer(string nick)
        {
            _leaderboard.SetCurrentPlayer(nick);
            Properties.Settings.Default["Nick"] = nick;
            Properties.Settings.Default.Save();
        }

        public void AddScore(int score)
        {
            _leaderboard.AddScore(score);
            _SaveLeaderboard();
        }

        public void SetControls()
        {
            if (PlayerForm == null)
            {
                return;
            }
            PlayerForm.NickTextBox.Text = Properties.Settings.Default["Nick"].ToString();
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

        private void _LoadLeaderboard()
        {
            if (File.Exists(leaderboardFileName))
            {
                StreamReader streamReader = File.OpenText(leaderboardFileName);
                Type leaderboardType = _leaderboard.GetType();
                XmlSerializer serializer = new XmlSerializer(leaderboardType);
                _leaderboard = (Leaderboard)serializer.Deserialize(streamReader); 
                streamReader.Close();
            }
            else
            {
                // inital data
                _leaderboard.Players.Add(new Player { Rank = 999, Nick = "Nick1", Score = 100 });
                _leaderboard.Players.Add(new Player { Rank = 999, Nick = "Nick2", Score = 200 });
                _leaderboard.Players.Add(new Player { Rank = 999, Nick = "Nick3", Score = 300 });
                _leaderboard.Players.Add(new Player { Rank = 999, Nick = "Nick4", Score = 400 });
                _leaderboard.Players.Add(new Player { Rank = 999, Nick = "Nick5", Score = 500 });
                _leaderboard.Players.Add(new Player { Rank = 999, Nick = "Nick6", Score = 600 });
                _leaderboard.Players.Add(new Player { Rank = 999, Nick = "Nick7", Score = 700 });
            }
        }

        private void _SaveLeaderboard()
        {
            StreamWriter streamWriter = File.CreateText(leaderboardFileName);
            Type leaderboardType = _leaderboard.GetType();
            if (leaderboardType.IsSerializable)
            {
                XmlSerializer serializer = new XmlSerializer(leaderboardType);
                serializer.Serialize(streamWriter, _leaderboard);
                streamWriter.Close();
            }
        }
    }
}
