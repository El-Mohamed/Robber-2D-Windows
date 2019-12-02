using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Project
{
    class StartLevel : Level
    {
        public StartLevel(byte[,] map, List<Block> allBlocks) : base(map, allBlocks)
        {
        }
    }
}
