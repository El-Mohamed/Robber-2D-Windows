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
        public StartLevel(byte[,] obstaclesArray, byte[,] pickablesArray, List<Block> allObstacles, List<Block> allPickables) : base(obstaclesArray, pickablesArray, allObstacles, allPickables)
        {
        }

        public override void Create(ContentManager contentManager)
        {
            base.Create(contentManager);
           
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.DrawWorld(spriteBatch);
          
        }
    }
}
