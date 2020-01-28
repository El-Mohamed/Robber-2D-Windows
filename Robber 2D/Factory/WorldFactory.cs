using Microsoft.Xna.Framework;

namespace Robber_2D
{
    static class WorldFactory
    {

        static public Platform CreatePlatform(Sprite sprite, Rectangle collisonRectangle)
        {
            return new Platform(sprite, collisonRectangle);
        }

        static public Door CreateDoor(Sprite sprite, Rectangle collisonRectangle)
        {
            return new Door(sprite, collisonRectangle);
        }

        static public Coin CreateCoin(Sprite sprite, Rectangle collisonRectangle)
        {
            return new Coin(sprite, collisonRectangle)
            {
                Value = 100
            };
        }

        static public MoneySafe CreateSafe(Sprite sprite, Rectangle collisonRectangle, int keyID)
        {
            return new MoneySafe(sprite, collisonRectangle)
            {
                KeyID = keyID,
                NumberOfDiamonds = 3
            };
        }

        static public Potion CreatePotion(Sprite sprite, Rectangle collisonRectangle)
        {
            return new Potion(sprite, collisonRectangle)
            {
                SpeedAcceleration = 1 // TODO CREATE RANDOM
            };
        }

        static public MoneySafeKey CreateKey(Sprite sprite, Rectangle collisonRectangle, int moneySafeID)
        {
            return new MoneySafeKey(sprite, collisonRectangle)
            {
                MoneySafeID = moneySafeID
            };
        }

        // Enemies
        static public Tank CreateTank(Sprite sprite, Rectangle collisonRectangle)
        {
            return new Tank(sprite, collisonRectangle);
        }

        static public Bullet CreateBullet(Sprite sprite, Rectangle collisionRectangle)
        {
            return new Bullet(sprite, collisionRectangle);
        }
    }
}
