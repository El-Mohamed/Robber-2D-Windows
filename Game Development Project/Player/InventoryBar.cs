using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Development_Project
{
    class InventoryBar
    {
        public Inventory Inventory;
        private Texture2D CoinTexture, PotionTexture, KeyTexture, DiamondTexture;
        public Vector2 ScreenCornerPosition;
        public Vector2 PlayerPosition;

        public InventoryBar(Inventory inventory, Texture2D keyTexture, Texture2D coinTexture, Texture2D potionTexture, Texture2D diamondTexture)
        {
            CoinTexture = coinTexture;
            KeyTexture = keyTexture;
            PotionTexture = potionTexture;
            DiamondTexture = diamondTexture;
            Inventory = inventory;
        }

        public void UpdatePosition(Player player)
        {
            ScreenCornerPosition = new Vector2(player.SpriteSheet.Position.X - (Game1.ScreenWidth / 2) + 100, player.SpriteSheet.Position.Y - (Game1.ScreenHeight / 2) + 100);
            PlayerPosition = new Vector2(player.CollisionRectangle.X, player.CollisionRectangle.Y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            const int marginHorizontal = 10;
            const int marginVertical = 20;

            Vector2 tempVector;
            Sprite tempSprite;

            int NextYPos = 0;

            for (int i = 0; i < Inventory.MyDiamonds; i++)
            {
                tempVector = new Vector2(ScreenCornerPosition.X + (i * (DiamondTexture.Width + marginHorizontal)), ScreenCornerPosition.Y + NextYPos);
                tempSprite = new Sprite(DiamondTexture, 1, tempVector);
                tempSprite.Draw(spriteBatch);

            }

            NextYPos += DiamondTexture.Height + marginVertical;

            for (int i = 0; i < Inventory.MyCoins.Count; i++)
            {
                tempVector = new Vector2(ScreenCornerPosition.X + (i * (CoinTexture.Width + marginHorizontal)), ScreenCornerPosition.Y + NextYPos);
                tempSprite = new Sprite(CoinTexture, 1, tempVector);
                tempSprite.Draw(spriteBatch);
            }

            if (Inventory.MyPotion != null)
            {
                spriteBatch.Draw(PotionTexture, new Vector2(PlayerPosition.X + 70, PlayerPosition.Y - 40), null, Color.Wheat, 0f, new Vector2(0, 0), 0.5f, SpriteEffects.None, 1);
            }

            if (Inventory.MyKey != null)
            {
                spriteBatch.Draw(KeyTexture, new Vector2(PlayerPosition.X + 40, PlayerPosition.Y - 30), null, Color.Wheat, 0f, new Vector2(0, 0), 0.5f, SpriteEffects.None, 1);
            }
        }
    }
}
