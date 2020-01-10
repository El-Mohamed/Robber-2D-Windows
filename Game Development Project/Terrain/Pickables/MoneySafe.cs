using Microsoft.Xna.Framework;

namespace Game_Development_Project
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
