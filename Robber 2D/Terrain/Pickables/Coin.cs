using Microsoft.Xna.Framework;
using System;

namespace Robber_2D
{
    class Coin : Block, ICloneable
    {
        public int Value;

        public Coin(Sprite sprite, Rectangle collisionRectangle) : base(sprite, collisionRectangle)
        {
        }

        public object Clone()
        {
            return new Coin(this.Sprite, this.CollisionRectangle)
            {
                Value = this.Value
            }; ;
        }
    }
}
