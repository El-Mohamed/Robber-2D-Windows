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
    class Healtbar
    {
        public void ShowHealth(Player player, ContentManager contentManager, SpriteBatch spriteBatch )
        {
            Texture2D healthTexture = contentManager.Load<Texture2D>("Health");
            // Get the position of the screen corner
            Vector2 position = new Vector2(player.SpriteSheet.Position.X + (Game1.ScreenWidth / 2) - 10, player.SpriteSheet.Position.Y - (Game1.ScreenHeight / 2) + 100);

            if (player.Health > 0)
            {
                for (int i = 0; i < player.Health / 10; i++)
                {
                    Vector2 tempVector = new Vector2(position.X - (i * (healthTexture.Width + 10)), position.Y);
                    Sprite tempSprite = new Sprite(healthTexture, 1, tempVector);
                    tempSprite.Draw(spriteBatch);
                }
            }

        }
    }
}
