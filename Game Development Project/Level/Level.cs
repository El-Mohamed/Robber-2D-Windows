using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Game_Development_Project
{
    class Level
    {
        public int NextLevel;
        public Vector2 StartPosition;

        protected int SpaceBetweenPlatforms = 250;
        public List<Block> AllObstacles, AllPickables;
        public List<int> MoneySafeIndentifiers;
        protected byte[,] ObstaclesArray, PickablesArray;
        protected long LevelHeight, MapWidth;

        public Level(byte[,] obstaclesArray, byte[,] pickablesArray, List<int> moneySafeIdentiefiers, List<Block> allObstacles, List<Block> allPickables)
        {
            ObstaclesArray = obstaclesArray;
            PickablesArray = pickablesArray;
            MoneySafeIndentifiers = moneySafeIdentiefiers;
            AllObstacles = allObstacles;
            AllPickables = allPickables;
            MapWidth = ObstaclesArray.GetLength(1);
            LevelHeight = ObstaclesArray.GetLength(0);
            StartPosition = new Vector2();
        }

        public virtual void Create(ContentManager contentManager)
        {
            CreateWorld(contentManager);
            CreatePickables(contentManager);
        }

        public virtual void Draw(SpriteBatch spritebatch)
        {
            DrawWorld(spritebatch);
            DrawPickables(spritebatch);
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        private void CreatePickables(ContentManager contentManager)
        {
            int totalKeys = 0;
            int totalMoneySafes = 0;
            Texture2D tempTexture = contentManager.Load<Texture2D>("Pickable1");
            Vector2 tempVector = new Vector2();
            Rectangle tempCollisonRectangle = new Rectangle();
            Sprite tempSprite = new Sprite(tempTexture, 1, tempVector);
            for (int x = 0; x < MapWidth; x++)
            {
                for (int y = 0; y < LevelHeight; y++)
                {
                    int BLOCK_ID = PickablesArray[y, x];
                    string ID_STRING = Convert.ToString(BLOCK_ID);

                    if (ID_STRING != "0")
                    {
                        tempTexture = contentManager.Load<Texture2D>("Pickable" + ID_STRING);
                    }

                    const int marginBottom = 10; // Margin between pickable and platform                                     
                    int maginLeft = (150 - tempTexture.Width) / 2; // Calculate margin to center Pickable on the platform
                    tempVector = new Vector2((x * 150) + maginLeft, (y * SpaceBetweenPlatforms) - tempTexture.Height - marginBottom);
                    tempCollisonRectangle = new Rectangle((int)tempVector.X, (int)tempVector.Y, tempTexture.Width, tempTexture.Height);
                    tempSprite = new Sprite(tempTexture, 1, tempVector);

                    switch (PickablesArray[y, x])
                    {
                        case 1:
                            MoneySafeKey tempMoneySafeKey = new MoneySafeKey(tempSprite, tempCollisonRectangle)
                            {
                                MoneySafeID = MoneySafeIndentifiers[totalKeys]
                            };
                            AllPickables.Add(tempMoneySafeKey as Block);
                            totalKeys++;
                            break;
                        case 2:
                            Coin tempCoin = new Coin(tempSprite, tempCollisonRectangle)
                            {
                                Value = 100 // TODO CREATE RANDOM
                            };
                            AllPickables.Add(tempCoin);
                            break;
                        case 3:
                            Potion tempPotion = new Potion(tempSprite, tempCollisonRectangle)
                            {
                                SpeedAcceleration = 1 // TODO CREATE RANDOM
                            };
                            AllPickables.Add(tempPotion);
                            break;
                        case 4:
                            MoneySafe tempMoneySafe = new MoneySafe(tempSprite, tempCollisonRectangle)
                            {
                                KeyID = MoneySafeIndentifiers[totalMoneySafes],
                                NumberOfDiamonds = 3 // TODO CREATE RANDOM
                            };
                            AllPickables.Add(tempMoneySafe);
                            totalMoneySafes++;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void DrawPickables(SpriteBatch spriteBatch)
        {
            foreach (Block pickable in AllPickables)
            {
                pickable.SpriteImage.Draw(spriteBatch);
            }
        }

        protected void CreateWorld(ContentManager contentManager)
        {
            Texture2D tempTexture = contentManager.Load<Texture2D>("Block1");
            Vector2 tempVector = new Vector2();
            Rectangle tempCollisonRectangle = new Rectangle();
            Sprite tempSprite = new Sprite(tempTexture, 1, tempVector);
            Block platform = new Platform(tempSprite, tempCollisonRectangle);

            for (int x = 0; x < MapWidth; x++)
            {
                for (int y = 0; y < LevelHeight; y++)
                {
                    int BLOCK_ID = ObstaclesArray[y, x];
                    string ID_STRING = Convert.ToString(BLOCK_ID);

                    if (ID_STRING != "0")
                    {
                        tempTexture = contentManager.Load<Texture2D>("Block" + ID_STRING);
                    }

                    // Creat Platform
                    Texture2D platformTexture = contentManager.Load<Texture2D>("Block1");
                    tempVector = new Vector2(x * platformTexture.Width, y * SpaceBetweenPlatforms);
                    tempCollisonRectangle = new Rectangle((int)tempVector.X, (int)tempVector.Y, platformTexture.Width, platformTexture.Height);
                    tempSprite = new Sprite(platformTexture, 1, tempVector);
                    platform = new Platform(tempSprite, tempCollisonRectangle);


                    switch (ObstaclesArray[y, x])
                    {
                        case 1:
                            // Add Platform 
                            AllObstacles.Add(platform);

                            break;
                        case 2:
                            // Add platform
                            AllObstacles.Add(platform);

                            // Create Door on the platform
                            Texture2D doorTexture = contentManager.Load<Texture2D>("Block2");

                            int maginLeft = (150 - doorTexture.Width) / 2; // Calculate margin to center the door on the platform
                            Vector2 doorVector = new Vector2((x * platformTexture.Width) + maginLeft, (y * SpaceBetweenPlatforms) - doorTexture.Height);
                            Rectangle doorCollisonRectangle = new Rectangle((int)doorVector.X, (int)doorVector.Y, doorTexture.Width, doorTexture.Height);
                            Sprite doorSprite = new Sprite(doorTexture, 1, doorVector);
                            Block door = new Door(doorSprite, doorCollisonRectangle);

                            // Add Door
                            AllObstacles.Add(door);
                            break;
                        default:
                            break;
                    }

                }
            }
        }

        protected void DrawWorld(SpriteBatch spriteBatch)
        {
            foreach (Block obstacle in AllObstacles)
            {
                obstacle.SpriteImage.Draw(spriteBatch);
            }
        }
    }
}
