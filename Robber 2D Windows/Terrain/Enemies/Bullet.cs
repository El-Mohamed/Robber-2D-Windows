using Microsoft.Xna.Framework;

namespace Robber_2D_Windows
{
    class Bullet : Block, IMover
    {
        Vector2 Speed;
        public int Damage;

        public Bullet(Sprite sprite, Rectangle collisionRectangle) : base(sprite, collisionRectangle)
        {
            Speed = new Vector2(15, 0);
            Damage = 10;
        }

        public void MoveRight()
        {
            SpriteImage.Position.X += Speed.X;
        }

        public void MoveLeft()
        {
            SpriteImage.Position.X -= Speed.X;          
        }

        public void Update(GameTime gameTime)
        {
            MoveLeft();
            CollisionRectangle = new Rectangle((int)SpriteImage.Position.X, (int)SpriteImage.Position.Y, SpriteImage.Texture1.Width, SpriteImage.Texture1.Height);
        }
    }
}
