using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace Game_Development_Project
{
    class Level
    {
        protected int PlatformSpace = 180;
        protected List<Block> AllBlocks { get; set; }
        protected byte[,] Map { get; set; }
        protected long LevelHeight { get; }
        protected long MapWidth { get; }
        public void CreateWorld(ContentManager contentManager) {

            for (int x = 0; x < MapWidth; x++)
            {
                for (int y = 0; y < LevelHeight; y++)
                {
                    int BLOCK_ID = Map[y, x];
                    string ID_STRING = Convert.ToString(BLOCK_ID);
                    Texture2D tempTexture = contentManager.Load<Texture2D>("Block" + ID_STRING);
                    Vector2 tempVector;

                    switch (Map[y,x])
                    {
                        case 1:
                            tempVector = new Vector2(x * tempTexture.Width, y * PlatformSpace);
                            AllBlocks.Add(new Platform(tempTexture, tempVector));
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch) {

            foreach (Block obstacle in AllBlocks)
            {
                obstacle.Draw(spriteBatch);
            }
        }
        public Level( byte[,] map, List<Block> allBlocks)
        {
            Map = map;
            AllBlocks = allBlocks;
            MapWidth = map.GetLength(1);
            LevelHeight = map.GetLength(0);
        }
    }
}
