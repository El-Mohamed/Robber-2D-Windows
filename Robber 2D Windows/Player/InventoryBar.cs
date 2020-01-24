using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Robber_2D_Windows
{
    class InventoryBar
    {
        Inventory Inventory;
        List<Texture2D> AllTextures;
        public Vector2 ScreenCornerPosition, PlayerHeadPosition;
        SpriteFont Font;
        Vector2 CoinPosition, KeyPosition, DiamondPosition, PotionPosition;

        public InventoryBar(Inventory inventory, List<Texture2D> allTextures, SpriteFont font)
        {
            AllTextures = allTextures;
            Inventory = inventory;
            Font = font;
        }

        public void UpdatePosition(Vector2 screenCornerPosition, Vector2 playerHeadPosition)
        {
            ScreenCornerPosition = screenCornerPosition;
            PlayerHeadPosition = playerHeadPosition;
            UpdateTexturePositions();
        }

        private void UpdateTexturePositions()
        {
            UpdateDiamondPosition();
            UpdateCoinPosition();
            UpdatePotionPosition();
            UpdateKeyPosition();
        }

        private void UpdateDiamondPosition()
        {
            DiamondPosition = ScreenCornerPosition;
        }

        private void UpdateCoinPosition()
        {
            CoinPosition.X = ScreenCornerPosition.X;
            CoinPosition.Y = ScreenCornerPosition.Y + 70;
        }

        private void UpdateKeyPosition()
        {
            KeyPosition.X = PlayerHeadPosition.X + 40;
            KeyPosition.Y = PlayerHeadPosition.Y - 30;
        }

        private void UpdatePotionPosition()
        {
            PotionPosition.X = PlayerHeadPosition.X + 70;
            PotionPosition.Y = PlayerHeadPosition.Y - 40;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawDiamond(spriteBatch);
            DrawCoin(spriteBatch);
            DrawPotion(spriteBatch);
            DrawKey(spriteBatch);
        }

        private void DrawDiamond(SpriteBatch spriteBatch)
        {
            // Draw Texture   
            spriteBatch.Draw(AllTextures[3], DiamondPosition, null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1);
            // Draw Amount 
            string numberOfDiamonds = Convert.ToString(Inventory.MyDiamonds);
            DiamondPosition.X += 60;
            DiamondPosition.Y -= 10;
            spriteBatch.DrawString(Font, numberOfDiamonds, DiamondPosition, Color.White);
        }

        private void DrawCoin(SpriteBatch spriteBatch)
        {
            // Draw Texture       
            spriteBatch.Draw(AllTextures[1], CoinPosition, null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1);
            // Draw Amount     
            string numberOfCoins = Convert.ToString(Inventory.MyCoins.Count);
            CoinPosition.X += 60;
            CoinPosition.Y -= 5;
            spriteBatch.DrawString(Font, numberOfCoins, CoinPosition, Color.White);
        }

        private void DrawPotion(SpriteBatch spriteBatch)
        {
            if (Inventory.MyPotion != null)
            {
                spriteBatch.Draw(AllTextures[2], PotionPosition, null, Color.White, 0f, new Vector2(0, 0), 0.5f, SpriteEffects.None, 1);
            }
        }

        private void DrawKey(SpriteBatch spriteBatch)
        {
            if (Inventory.MyKey != null)
            {
                spriteBatch.Draw(AllTextures[0], KeyPosition, null, Color.White, 0f, new Vector2(0, 0), 0.5f, SpriteEffects.None, 1);
            }
        }
    }
}
