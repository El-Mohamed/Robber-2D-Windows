using Microsoft.Xna.Framework;

namespace Robber_2D
{
    class Bullet : Block, IMover
    {
        Vector2 Speed;
        public int Damage;
        public Direction direction;

        public Bullet(Sprite sprite, Rectangle collisionRectangle) : base(sprite, collisionRectangle)
        {
            Speed = Factory.CreateVector(15, 0);
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

        public void Move()
        {
            if (direction == Direction.ToLeft)
            {
                MoveLeft();
            }

            if (direction == Direction.ToRight)
            {
                MoveRight();
            }
        }

        public void Update(GameTime gameTime)
        {
            MoveLeft();
            CollisionRectangle = Factory.CreateRectangle((int)SpriteImage.Position.X, (int)SpriteImage.Position.Y, SpriteImage.Texture1.Width, SpriteImage.Texture1.Height);
        }
    }
}
