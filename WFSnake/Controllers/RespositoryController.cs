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
    public class RespositoryController
    {
        private string leaderboardFileName;

        public RespositoryController()
        {
            leaderboardFileName = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Leaderboard.xml");
        }

        public string LoadNick()
        {
            return Properties.Settings.Default["Nick"].ToString();
        }

        public void SaveNick(string nick)
        {
            Properties.Settings.Default["Nick"] = nick;
            Properties.Settings.Default.Save();
        }

        public Leaderboard LoadLeaderboard(Leaderboard leaderboard)
        {
            if (File.Exists(leaderboardFileName))
            {
                StreamReader streamReader = File.OpenText(leaderboardFileName);
                Type leaderboardType = leaderboard.GetType();
                XmlSerializer serializer = new XmlSerializer(leaderboardType);
                leaderboard = (Leaderboard)serializer.Deserialize(streamReader);
                streamReader.Close();
            }
            else
            {
                // inital data
                leaderboard.Players.Add(new Player { Rank = 999, Nick = "Nick1", Score = 100 });
                leaderboard.Players.Add(new Player { Rank = 999, Nick = "Nick2", Score = 200 });
                leaderboard.Players.Add(new Player { Rank = 999, Nick = "Nick3", Score = 300 });
                leaderboard.Players.Add(new Player { Rank = 999, Nick = "Nick4", Score = 400 });
                leaderboard.Players.Add(new Player { Rank = 999, Nick = "Nick5", Score = 500 });
                leaderboard.Players.Add(new Player { Rank = 999, Nick = "Nick6", Score = 600 });
                leaderboard.Players.Add(new Player { Rank = 999, Nick = "Nick7", Score = 700 });
            }

            return leaderboard;
        }

        public void SaveLeaderboard(Leaderboard leaderboard)
        {
            StreamWriter streamWriter = File.CreateText(leaderboardFileName);
            Type leaderboardType = leaderboard.GetType();
            if (leaderboardType.IsSerializable)
            {
                XmlSerializer serializer = new XmlSerializer(leaderboardType);
                serializer.Serialize(streamWriter, leaderboard);
                streamWriter.Close();
            }
        }
    }
}
