using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game_Development_Project
{
    class MoneySafe : Block
    {
        public int KeyID { get; set; }

        public int NumberOfDiamonds { get; set; }

        public MoneySafe(Sprite sprite, Rectangle collisionRectangle) : base(sprite, collisionRectangle)
        {
        }
    }
}
