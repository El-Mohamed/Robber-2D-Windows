using Microsoft.Xna.Framework;
using System;

namespace Game_Development_Project
{
    class Coin : Block, ICloneable
    {
        public int Value;

        public Coin(Sprite sprite, Rectangle collisionRectangle) : base(sprite, collisionRectangle)
        {
        }

        public object Clone()
        {
            return new Coin(this.SpriteImage, this.CollisionRectangle)
            {
                Value = this.Value
            }; ;
        }
    }
}
