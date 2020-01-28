using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Robber_2D
{
    class World
    {
        public int NextWorld;
        Vector2 StartPosition;
        public int SpaceBetweenPlatforms = 250;
        public List<Block> AllObstacles, AllPickables;
        List<int> MoneySafeIndentifiers;
        byte[,] ObstaclesArray, PickablesArray;
        protected long LevelHeight, MapWidth;
        public int totalMoneySafes, totalKeys;

        public bool IsCompleted
        {
            get
            {
                if (totalMoneySafes == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public long MapRange => LevelHeight * 230;

        public World(byte[,] obstaclesArray, byte[,] pickablesArray, List<int> moneySafeIdentiefiers)
        {
            ObstaclesArray = obstaclesArray;
            PickablesArray = pickablesArray;
            MoneySafeIndentifiers = moneySafeIdentiefiers;
            AllObstacles = new List<Block>();
            AllPickables = new List<Block>();
            MapWidth = ObstaclesArray.GetLength(1);
            LevelHeight = ObstaclesArray.GetLength(0);
            StartPosition = Factory.CreateVector(0, 0);
        }

        public virtual void Create(ContentManager contentManager)
        {
            CreateObstacles(contentManager);
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
            Texture2D tempTexture = contentManager.Load<Texture2D>("Pickable1");

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
                    float xPos = (x * 150) + maginLeft;
                    float yPos = (y * SpaceBetweenPlatforms) - tempTexture.Height - marginBottom;
                    Vector2 tempVector = Factory.CreateVector(xPos, yPos);
                    Rectangle tempCollisonRectangle = Factory.CreateRectangle((int)tempVector.X, (int)tempVector.Y, tempTexture.Width, tempTexture.Height);
                    Sprite tempSprite = Factory.CreateSprite(tempTexture, 1, tempVector);

                    switch (PickablesArray[y, x])
                    {
                        case 1:
                            MoneySafeKey tempMoneySafeKey = WorldFactory.CreateKey(tempSprite, tempCollisonRectangle, MoneySafeIndentifiers[totalKeys]);
                            AllPickables.Add(tempMoneySafeKey as Block);
                            totalKeys++;
                            break;
                        case 2:
                            Coin tempCoin = WorldFactory.CreateCoin(tempSprite, tempCollisonRectangle);
                            AllPickables.Add(tempCoin);
                            break;
                        case 3:
                            Potion tempPotion = WorldFactory.CreatePotion(tempSprite, tempCollisonRectangle);
                            AllPickables.Add(tempPotion);
                            break;
                        case 4:
                            MoneySafe tempMoneySafe = WorldFactory.CreateSafe(tempSprite, tempCollisonRectangle, MoneySafeIndentifiers[totalMoneySafes]);
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

        protected void CreateObstacles(ContentManager contentManager)
        {
            for (int x = 0; x < MapWidth; x++)
            {
                for (int y = 0; y < LevelHeight; y++)
                {
                    // Create Platform
                    Texture2D platformTexture = contentManager.Load<Texture2D>("Block1");
                    Vector2 tempVector = Factory.CreateVector(x * platformTexture.Width, y * SpaceBetweenPlatforms);
                    Rectangle tempCollisonRectangle = Factory.CreateRectangle((int)tempVector.X, (int)tempVector.Y, platformTexture.Width, platformTexture.Height);
                    Sprite tempSprite = Factory.CreateSprite(platformTexture, 1, tempVector);
                    Block platform = WorldFactory.CreatePlatform(tempSprite, tempCollisonRectangle);

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
                            // Calculate margin to center the door on the platform
                            int maginLeft = (150 - doorTexture.Width) / 2;

                            float xPos = (x * platformTexture.Width) + maginLeft;
                            float yPos = (y * SpaceBetweenPlatforms) - doorTexture.Height;
                            Vector2 doorVector = Factory.CreateVector(xPos, yPos);

                            Rectangle doorCollisonRectangle = Factory.CreateRectangle((int)doorVector.X, (int)doorVector.Y, doorTexture.Width, doorTexture.Height);
                            Sprite doorSprite = Factory.CreateSprite(doorTexture, 1, doorVector);
                            Block door = WorldFactory.CreateDoor(doorSprite, doorCollisonRectangle);

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
