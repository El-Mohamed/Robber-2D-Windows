using Microsoft.Xna.Framework;

namespace Robber_2D_Windows
{
    class Platform : Block
    {
        public Platform(Sprite sprite, Rectangle collisionRectangle) : base(sprite, collisionRectangle)
        {
            ID = 1;
        }
    }
}
