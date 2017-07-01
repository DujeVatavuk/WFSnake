using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFSnake.Models
{
    class SnakeBlock
    {
        public int X { get; set; }
        public int Y { get; set; }

        public SnakeBlock()
        {
            X = 0;
            Y = 0;
        }
    }
}
