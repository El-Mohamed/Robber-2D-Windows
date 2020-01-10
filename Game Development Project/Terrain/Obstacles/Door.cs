using Microsoft.Xna.Framework;

namespace Game_Development_Project
{
    class Door : Block
    {
        public Door(Sprite sprite, Rectangle collisionRectangle) : base(sprite, collisionRectangle)
        {
            ID = 2;
        }
    }
}
