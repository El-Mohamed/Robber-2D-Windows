using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robber_2D_Windows
{
    static class WorldFactory
    {
        // Types
        static public Rectangle CreateRectangle(int x, int y, int width, int height)
        {
            return new Rectangle(x, y, width, height);
        }

        static public Vector2 CreateVector(float x, float y)
        {
            return new Vector2(x, y);
        }

        // Obstacles
        static public Platform CreatePlatform(Sprite sprite, Rectangle collisonRectangle)
        {
            return new Platform(sprite, collisonRectangle);
        }

        static public Door CreateDoor(Sprite sprite, Rectangle collisonRectangle)
        {
            return new Door(sprite, collisonRectangle);
        }

        // Other
        static public Sprite CreateSprite(Texture2D texture, int number, Vector2 vector)
        {
            return new Sprite(texture, number, vector);
        }

        // Pickables
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
    }
}
