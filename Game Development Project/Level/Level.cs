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
        protected List<Block> AllBlocks { get; set; }
        protected byte[,] Map { get; set; }
        protected long LevelHeight { get; }
        protected long MapWidth { get; }
        public void CreateWorld(ContentManager contentManager)
        {

            Texture2D tempTexture = contentManager.Load<Texture2D>("Block1");

            for (int x = 0; x < MapWidth; x++)
            {
                for (int y = 0; y < LevelHeight; y++)
                {
                    int BLOCK_ID = Map[y, x];
                    string ID_STRING = Convert.ToString(BLOCK_ID);
                    if (ID_STRING != "0")
                    {
                        tempTexture = contentManager.Load<Texture2D>("Block" + ID_STRING);
                    }

                    Vector2 tempVector = new Vector2();
                    Rectangle tempCollisonRectangle = new Rectangle();
                    Block temp = new Platform(tempTexture, tempVector, tempCollisonRectangle);

                    switch (Map[y, x])
                    {
                        case 1:
                            tempVector = new Vector2(x * tempTexture.Width, y * SpaceBetweenPlatforms);
                            tempCollisonRectangle = new Rectangle((int)tempVector.X, (int)tempVector.Y, tempTexture.Width, tempTexture.Height);
                            temp = new Platform(tempTexture, tempVector, tempCollisonRectangle);
                            break;
                        case 2:
                            tempVector = new Vector2((x * tempTexture.Width), (y * tempTexture.Width) + 140);
                            tempCollisonRectangle = new Rectangle((int)tempVector.X, (int)tempVector.Y, tempTexture.Width, tempTexture.Height);
                            temp = new Door(tempTexture, tempVector, tempCollisonRectangle);
                            break;
                        default:
                            break;
                    }

                    AllBlocks.Add(temp);
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            foreach (Block obstacle in AllBlocks)
            {
                obstacle.Draw(spriteBatch);
            }
        }
        public Level(byte[,] map, List<Block> allBlocks)
        {
            Map = map;
            AllBlocks = allBlocks;
            MapWidth = map.GetLength(1);
            LevelHeight = map.GetLength(0);
        }
    }
}
