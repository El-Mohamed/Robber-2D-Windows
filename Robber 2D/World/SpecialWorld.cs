using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Robber_2D
{
    class SpecialWorld : World
    {
        public List<Tank> AllTanks;
        byte[,] EnemiesArray;
        int LastTimeShooted = 0;

        public SpecialWorld(byte[,] obstaclesArray, byte[,] pickablesArray, List<int> moneySafeIdentiefiers, byte[,] enemiesArray) : base(obstaclesArray, pickablesArray, moneySafeIdentiefiers)
        {
            AllTanks = new List<Tank>();
            EnemiesArray = enemiesArray;
        }

        private void CreateTanks(ContentManager contentManager)
        {
            Texture2D tempTexture = contentManager.Load<Texture2D>("Enemy1");

            for (int x = 0; x < MapWidth; x++)
            {
                for (int y = 0; y < LevelHeight; y++)
                {
                    int BLOCK_ID = EnemiesArray[y, x];
                    string ID_STRING = Convert.ToString(BLOCK_ID);

                    if (ID_STRING != "0")
                    {
                        tempTexture = contentManager.Load<Texture2D>("Enemy" + ID_STRING);
                    }

                    // Margin between pickable and platform 
                    const int marginBottom = 1;
                    // Calculate margin to center Tank on the platform
                    int maginLeft = (150 - tempTexture.Width) / 2;
                    float xPos = (x * 150) + maginLeft;
                    float yPos = (y * SpaceBetweenPlatforms) - tempTexture.Height - marginBottom;
                    Vector2 tempVector = Factory.CreateVector(xPos, yPos);
                    Rectangle tempCollisonRectangle = Factory.CreateRectangle((int)tempVector.X, (int)tempVector.Y, tempTexture.Width, tempTexture.Height);
                    Sprite tempSprite = Factory.CreateSprite(tempTexture, 1, tempVector);

                    switch (EnemiesArray[y, x])
                    {
                        case 1:
                            Tank tempTank = WorldFactory.CreateTank(tempSprite, tempCollisonRectangle);
                            AllTanks.Add(tempTank);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void DrawTanks(SpriteBatch spriteBatch)
        {
            foreach (Tank tank in AllTanks)
            {
                tank.SpriteImage.Draw(spriteBatch);

                foreach (Bullet bullet in tank.ShootedBullets)
                {
                    bullet.SpriteImage.Draw(spriteBatch);
                }
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            DrawTanks(spriteBatch);
            base.Draw(spriteBatch);
        }

        public override void Create(ContentManager contentManager)
        {
            CreateTanks(contentManager);
            base.Create(contentManager);
        }

        public void CreateBullets()
        {
            if (LastTimeShooted >= 300)
            {
                foreach (Tank tank in AllTanks)
                {
                    tank.Shoot();
                }

                LastTimeShooted = 0;
            }
        }

        public override void Update(GameTime gameTime)
        {
            UpdateBullets(gameTime);
            LastTimeShooted += 100 * gameTime.ElapsedGameTime.Milliseconds / 500;
            base.Update(gameTime);
        }

        public void UpdateBullets(GameTime gameTime)
        {
            foreach (Tank tank in AllTanks)
            {
                foreach (Bullet bullet in tank.ShootedBullets)
                {
                    bullet.Update(gameTime);
                }
            }
        }
    }
}
