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
        public List<DoorKey> AllKeys { get; set; }
        public byte[,] DoorKeyArray { get; set; }
  
        public StartLevel(byte[,] map, List<Block> allBlocks, byte[,] doorKeyArray, List<DoorKey> allKeys) : base(map, allBlocks)
        {
            AllKeys = allKeys;
            DoorKeyArray = doorKeyArray;
        }

        private void CreateDoorKeys(ContentManager contentManager)
        {
            for (int x = 0; x < MapWidth; x++)
            {
                for (int y = 0; y < LevelHeight; y++)
                {
                    if(DoorKeyArray[y,x] == 1)
                    {
                        Texture2D tempTexture = contentManager.Load<Texture2D>("Key");
                        Vector2 tempVector = new Vector2((x * 150) + tempTexture.Width, (y * SpaceBetweenPlatforms) - tempTexture.Height); 
                        Rectangle tempCollisonRectangle = new Rectangle((int)tempVector.X, (int)tempVector.Y, tempTexture.Width, tempTexture.Height);
                        DoorKey tempDoorKey = new DoorKey(tempTexture, tempVector, tempCollisonRectangle);
                        AllKeys.Add(tempDoorKey);
                    }
                }
            }
        }

        private void DrawDoorKeys(SpriteBatch spriteBatch)
        {
            foreach (DoorKey key in AllKeys)
            {
                key.Draw(spriteBatch);
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
            DrawDoorKeys(spriteBatch);

        }
    }
}
