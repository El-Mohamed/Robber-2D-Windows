using Microsoft.Xna.Framework;

namespace Game_Development_Project
{
    class Platform : Block
    {
        public Platform(Sprite sprite, Rectangle collisionRectangle) : base(sprite, collisionRectangle)
        {
            ID = 1;
        }
    }
}
