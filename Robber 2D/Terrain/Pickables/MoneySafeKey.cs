using Microsoft.Xna.Framework;
using System;

namespace Robber_2D
{
    class MoneySafeKey : Block, ICloneable
    {
        public int MoneySafeID;

        public MoneySafeKey(Sprite sprite, Rectangle collisionRectangle) : base(sprite, collisionRectangle)
        {
        }

        public object Clone()
        {
            return new MoneySafeKey(this.SpriteImage, this.CollisionRectangle)
            {
                MoneySafeID = this.MoneySafeID
            };
        }
    }
}
