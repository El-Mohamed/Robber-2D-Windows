using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game_Development_Project
{
    class Coin : Block, ICloneable
    {
        public Coin(Sprite sprite, Rectangle collisionRectangle) : base(sprite, collisionRectangle)
        {
        }

        public int Value { get; set; }

        public object Clone()
        {
            return new Coin(this.SpriteImage, this.CollisionRectangle)
            {
                Value = this.Value
            }; ;
        }
    }
}
