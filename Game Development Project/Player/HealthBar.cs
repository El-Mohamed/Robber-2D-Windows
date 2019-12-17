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
    class HealthBar
    {
        public Texture2D Heart { get; set; }
        public Vector2 Position { get; set; }
        public int HealthLevel { get; set; }

        public HealthBar(Texture2D heart)
        {
            Heart = heart;
            HealthLevel = 0;
        }

        public void UpdatePosition(Player player)
        {  
            Position = new Vector2(player.SpriteSheet.Position.X + (Game1.ScreenWidth / 2) - 10, player.SpriteSheet.Position.Y - (Game1.ScreenHeight / 2) + 100);
        }

        public void UpdateHealth(Player player)
        {
            HealthLevel = player.Health;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (HealthLevel > 0)
            {
                for (int i = 0; i < HealthLevel / 10; i++)
                {
                    Vector2 tempVector = new Vector2(Position.X - (i * (Heart.Width + 10)), Position.Y);
                    Sprite tempSprite = new Sprite(Heart, 1, tempVector);
                    tempSprite.Draw(spriteBatch);
                }
            }
        }
    }
}
