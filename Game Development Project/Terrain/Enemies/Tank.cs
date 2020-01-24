using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Robber_2D_Windows
{
    class Tank : Block
    {
        public List<Bullet> ShootedBullets;

        public Tank(Sprite sprite, Rectangle collisionRectangle) : base(sprite, collisionRectangle)
        {
            ShootedBullets = new List<Bullet>();
        }

        public void Shoot(ContentManager contentManager, Vector2 tankPosition)
        {
            const int Offset = 10; // Bullets need to shooted out of the gun
            Texture2D bulletTexture = contentManager.Load<Texture2D>("Bullet");
            Vector2 bulletPosition = new Vector2(tankPosition.X, tankPosition.Y + Offset);
            Rectangle bulletCollisoionRectangle = new Rectangle((int)bulletPosition.X, (int)bulletPosition.Y, bulletTexture.Width, bulletTexture.Height);
            Sprite sprite = new Sprite(bulletTexture, 1, bulletPosition);
            ShootedBullets.Add(new Bullet(sprite, bulletCollisoionRectangle));
        }

    }
}
