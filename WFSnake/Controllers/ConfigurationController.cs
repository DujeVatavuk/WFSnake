using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WFSnake.Models;

namespace WFSnake.Controllers
{
    public class ConfigurationController
    {
        public Configuration NewGameConfiguration(Configuration configuration)
        {
            configuration.Score = 0;
            configuration.Points = 100;
            configuration.GameOver = false;
            configuration.Direction = Direction.Down;

            return configuration;
        }
    }
}
