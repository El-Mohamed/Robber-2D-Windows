using Microsoft.Xna.Framework;

namespace Game_Development_Project
{
    abstract class Block : ICollider
    {
        public Rectangle CollisionRectangle { get; set; }
        public Sprite SpriteImage;
        public int ID;

        public Block(Sprite sprite, Rectangle collisionRectangle)
        {
            SpriteImage = sprite;
            CollisionRectangle = collisionRectangle;
        }
    }
}
