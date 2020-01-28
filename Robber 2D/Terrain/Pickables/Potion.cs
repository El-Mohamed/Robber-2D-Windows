using Microsoft.Xna.Framework;
using System;

namespace Robber_2D
{
    class Potion : Block, ICloneable
    {
        public int SpeedAcceleration;

        public Potion(Sprite sprite, Rectangle collisionRectangle) : base(sprite, collisionRectangle)
        {
        }

        public object Clone()
        {
            return new Potion(this.SpriteImage, this.CollisionRectangle)
            {
                SpeedAcceleration = this.SpeedAcceleration
            };
        }
    }
}
