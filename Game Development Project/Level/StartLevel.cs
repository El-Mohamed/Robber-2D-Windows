using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Project
{
    class StartLevel : Level
    {
        public List<Block> AllPickables { get; set; }
        public byte[,] DoorKeyArray { get; set; }

        public StartLevel(byte[,] map, List<Block> allBlocks, byte[,] doorKeyArray, List<Block> allPickables) : base(map, allBlocks)
        {
            AllPickables = allPickables;
            DoorKeyArray = doorKeyArray;
        }

        private void CreateDoorKeys(ContentManager contentManager)
        {
            for (int x = 0; x < MapWidth; x++)
            {
                for (int y = 0; y < LevelHeight; y++)
                {
                    if (DoorKeyArray[y, x] == 1)
                    {
                        Texture2D tempTexture = contentManager.Load<Texture2D>("Key");
                        Vector2 tempVector = new Vector2((x * 150) + tempTexture.Width, (y * SpaceBetweenPlatforms) - tempTexture.Height);
                        Rectangle tempCollisonRectangle = new Rectangle((int)tempVector.X, (int)tempVector.Y, tempTexture.Width, tempTexture.Height);
                        Sprite tempSprite = new Sprite(tempTexture, 1, tempVector);
                        DoorKey tempDoorKey = new DoorKey(tempSprite, tempCollisonRectangle)
                        {
                            IsRightKey = true // TODO CREATE RANDOM
                        };
                        AllPickables.Add(tempDoorKey);
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

        public override void Create(ContentManager contentManager)
        {
            base.Create(contentManager);
            CreateDoorKeys(contentManager);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.DrawWorld(spriteBatch);
            DrawPickables(spriteBatch);
        }
    }
}
