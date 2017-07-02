using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFSnake.Models
{
    public class BuildingBlock
    {
        public int X { get; set; }
        public int Y { get; set; }

        public BuildingBlockType Type { get; set; }

        public BuildingBlock()
        {
            X = 0;
            Y = 0;
            Type = BuildingBlockType.SnakeTail;
        }

        public Brush GetColor()
        {
            switch (Type)
            {
                case BuildingBlockType.SnakeHead:
                    return Brushes.DimGray;
                case BuildingBlockType.SnakeTail:
                    return Brushes.Turquoise;
                case BuildingBlockType.Food:
                    return Brushes.DeepPink;
                default:
                    return Brushes.Turquoise;
            }          
        }
    }
}
