using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Robber_2D
{
    class Tank : Block
    {
        public List<Bullet> ShootedBullets;

        public Tank(Sprite sprite, Rectangle collisionRectangle) : base(sprite, collisionRectangle)
        {
            ShootedBullets = new List<Bullet>();
        }

        public void Shoot()
        {
            const int Offset = 10; // Bullets need to shooted out of the gun
            Texture2D bulletTexture = Factory.CreateTexture("Bullet");
            Vector2 bulletPosition = Factory.CreateVector(SpriteImage.Position.X, SpriteImage.Position.Y + Offset);
            Rectangle bulletCollisoionRectangle = Factory.CreateRectangle((int)bulletPosition.X, (int)bulletPosition.Y, bulletTexture.Width, bulletTexture.Height);
            Sprite sprite = Factory.CreateSprite(bulletTexture, 1, bulletPosition);
            Bullet bullet = WorldFactory.CreateBullet(sprite, CollisionRectangle);
            ShootedBullets.Add(bullet);
        }
    }
}
