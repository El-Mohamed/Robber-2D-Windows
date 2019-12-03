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
        protected List<Block> AllObstacles { get; set; }
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
            Block tempObstacle = new Platform(tempTexture, tempVector, tempCollisonRectangle);

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
                            tempObstacle = new Platform(tempTexture, tempVector, tempCollisonRectangle);
                            break;
                        case 2:
                            tempVector = new Vector2((x * tempTexture.Width), (y * tempTexture.Width) + 140);
                            tempCollisonRectangle = new Rectangle((int)tempVector.X, (int)tempVector.Y, tempTexture.Width, tempTexture.Height);
                            tempObstacle = new Door(tempTexture, tempVector, tempCollisonRectangle);
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
                obstacle.Draw(spriteBatch);
            }
        }
    }
}
