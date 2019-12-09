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
    class InventoryHelper
    {
        public Inventory Inventory { get; set; }
        private Texture2D CoinTexture { get; set; }
        private Texture2D PotionTexture { get; set; }
        private Texture2D KeyTexture { get; set; }

        public Vector2 Position { get; set; }

        public InventoryHelper(Inventory inventory, Texture2D keyTexture, Texture2D coinTexture, Texture2D potionTexture)
        {
            CoinTexture = coinTexture;
            KeyTexture = keyTexture;
            PotionTexture = potionTexture;
            Inventory = inventory;
        }

        public void UpdatePosition(Player player)
        {
           Position = new Vector2(player.SpriteSheet.Position.X - (Game1.ScreenWidth / 2) + 100, player.SpriteSheet.Position.Y - (Game1.ScreenHeight / 2) + 100);
        }

        public void Draw( SpriteBatch spriteBatch)
        {          
            const int marginHorizontal = 10;
            const int marginVertical = 20;

            Vector2 tempVector;
            Sprite tempSprite;
            
            int NextYPos = 0;

            for (int i = 0; i < Inventory.MyKeys.Count; i++)
            {
                tempVector = new Vector2(Position.X + (i * (KeyTexture.Width + marginHorizontal)), Position.Y + NextYPos);
                tempSprite = new Sprite(KeyTexture, 1, tempVector);
                tempSprite.Draw(spriteBatch);
            }

            NextYPos += KeyTexture.Height + marginVertical;

            for (int i = 0; i < Inventory.MyCoins.Count; i++)
            {
                tempVector = new Vector2(Position.X + (i * (CoinTexture.Width + marginHorizontal)), Position.Y + NextYPos);
                tempSprite = new Sprite(CoinTexture, 1, tempVector);
                tempSprite.Draw(spriteBatch);
            }

            NextYPos += CoinTexture.Height + marginVertical;

            for (int i = 0; i < Inventory.MyPotions.Count; i++)
            {
                tempVector = new Vector2(Position.X + (i * (PotionTexture.Width + marginHorizontal)), Position.Y + NextYPos);
                tempSprite = new Sprite(PotionTexture, 1, tempVector);
                tempSprite.Draw(spriteBatch);
            }
        }
    }
}
