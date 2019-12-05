using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Content;

namespace Game_Development_Project
{
    class Level
    {
        protected int SpaceBetweenPlatforms = 210;
        public List<Block> AllObstacles { get; set; }
        protected byte[,] ObstaclesArray { get; set; }
        protected long LevelHeight { get; }
        protected long MapWidth { get; }

        public Level(byte[,] obstaclesArray, List<Block> allBlocks)
        {
            ObstaclesArray = obstaclesArray;
            AllObstacles = allBlocks;
            MapWidth = ObstaclesArray.GetLength(1);
            LevelHeight = ObstaclesArray.GetLength(0);
        }

        public virtual void Create(ContentManager contentManager)
        {
            CreateWorld(contentManager);
        }

        public virtual void Draw(SpriteBatch spritebatch)
        {
            DrawWorld(spritebatch);
        }

        protected void CreateWorld(ContentManager contentManager)
        {
            Texture2D tempTexture = contentManager.Load<Texture2D>("Block1");
            Vector2 tempVector = new Vector2();
            Rectangle tempCollisonRectangle = new Rectangle();
            Sprite tempSprite = new Sprite(tempTexture, 1, tempVector);
            Block tempObstacle = new Platform(tempSprite, tempCollisonRectangle);

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

                    switch (ObstaclesArray[y, x])
                    {
                        case 1:
                            tempVector = new Vector2(x * tempTexture.Width, y * SpaceBetweenPlatforms);
                            tempCollisonRectangle = new Rectangle((int)tempVector.X, (int)tempVector.Y, tempTexture.Width, tempTexture.Height);
                            tempSprite = new Sprite(tempTexture, 1, tempVector);
                            tempObstacle = new Platform(tempSprite, tempCollisonRectangle);
                            break;
                        case 2:
                            tempVector = new Vector2((x * tempTexture.Width), (y * tempTexture.Width) + 140);
                            tempCollisonRectangle = new Rectangle((int)tempVector.X, (int)tempVector.Y, tempTexture.Width, tempTexture.Height);
                            tempSprite = new Sprite(tempTexture, 1, tempVector);
                            tempObstacle = new Door(tempSprite, tempCollisonRectangle);
                            break;
                        default:
                            break;
                    }

                    AllObstacles.Add(tempObstacle);
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
