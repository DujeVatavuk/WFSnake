using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFSnake.Models
{
    public class BuildingBlock
    {
        public int X { get; set; }
        public int Y { get; set; }

        public BuildingBlock()
        {
            X = 0;
            Y = 0;
        }
    }
}
