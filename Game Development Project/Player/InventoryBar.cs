using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Game_Development_Project
{
    class InventoryBar
    {
        public Inventory Inventory;
        private List<Texture2D> AllTextures;
        public Vector2 ScreenCornerPosition, PlayerPosition;
        private SpriteFont TextFont;
        private Vector2 CoinPosition, KeyPosition, DiamondPosition, PotionPosition;

        public InventoryBar(Inventory inventory, List<Texture2D> allTextures, SpriteFont spriteFont)
        {
            AllTextures = allTextures;
            Inventory = inventory;
            TextFont = spriteFont;
        }

        public void UpdatePosition(Player player)
        {
            ScreenCornerPosition.X = player.SpriteSheet.Position.X - (Game1.ScreenWidth / 2) + 100;
            ScreenCornerPosition.Y = player.SpriteSheet.Position.Y - (Game1.ScreenHeight / 2) + 100;
            PlayerPosition.X = player.CollisionRectangle.X;
            PlayerPosition.Y = player.CollisionRectangle.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawKey(spriteBatch);
            DrawPotion(spriteBatch);
            DrawCoins(spriteBatch);
            DrawDiamonds(spriteBatch);  
        }

        private void DrawDiamonds(SpriteBatch spriteBatch)
        {
            string numberOfDiamonds = Convert.ToString(Inventory.MyDiamonds);
            DiamondPosition = new Vector2(ScreenCornerPosition.X, ScreenCornerPosition.Y);
            spriteBatch.Draw(AllTextures[3], DiamondPosition, null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1);
            // Draw Amount 
            DiamondPosition.X += 60;
            DiamondPosition.Y -= 10;
            spriteBatch.DrawString(TextFont, numberOfDiamonds, DiamondPosition, Color.White);
        }

        private void DrawCoins(SpriteBatch spriteBatch)
        {
            string numberOfCoins = Convert.ToString(Inventory.MyCoins.Count);
            CoinPosition.X = ScreenCornerPosition.X;
            CoinPosition.Y = ScreenCornerPosition.Y + 70;
            spriteBatch.Draw(AllTextures[1], CoinPosition, null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1);
            // Draw Amount       
            CoinPosition.X += 60;
            CoinPosition.Y -= 5;
            spriteBatch.DrawString(TextFont, numberOfCoins, CoinPosition, Color.White);
        }

        private void DrawPotion(SpriteBatch spriteBatch)
        {
            PotionPosition.X = PlayerPosition.X + 70;
            PotionPosition.Y = PlayerPosition.Y - 40;

            if (Inventory.MyPotion != null)
            {
                spriteBatch.Draw(AllTextures[2], PotionPosition, null, Color.White, 0f, new Vector2(0, 0), 0.5f, SpriteEffects.None, 1);
            }
        }

        private void DrawKey(SpriteBatch spriteBatch)
        {
            KeyPosition.X = PlayerPosition.X + 40;
            KeyPosition.Y = PlayerPosition.Y - 30;

            if (Inventory.MyKey != null)
            {
                spriteBatch.Draw(AllTextures[0], KeyPosition, null, Color.White, 0f, new Vector2(0, 0), 0.5f, SpriteEffects.None, 1);
            }
        }
    }
}
