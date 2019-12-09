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
    class Clock
    {
        public int Time { get; set; }


        public Clock()
        {
            Time = 0;
        }


        public void Update(GameTime gameTime)
        {
            Time += gameTime.ElapsedGameTime.Milliseconds;
        }


        public void ShowTime(ContentManager contentManager,SpriteBatch spriteBatch, Player player)
        {
            Vector2 position = new Vector2(player.SpriteSheet.Position.X +10, player.SpriteSheet.Position.Y - (Game1.ScreenHeight / 2) + 100);
            SpriteFont font;
           
            font = contentManager.Load<SpriteFont>("ClockFont"); 
         

            spriteBatch.DrawString(font, "Time: " + Time/1000, position, Color.Black);

        }


    }
}
