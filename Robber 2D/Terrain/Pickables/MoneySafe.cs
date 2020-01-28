﻿using Microsoft.Xna.Framework;

namespace Robber_2D
{
    class MoneySafe : Block
    {
        public int KeyID;
        public int NumberOfDiamonds;

        public MoneySafe(Sprite sprite, Rectangle collisionRectangle) : base(sprite, collisionRectangle)
        {
        }
    }
}
