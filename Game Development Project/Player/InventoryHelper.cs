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

        public InventoryHelper(Inventory inventory)
        {
            this.Inventory = inventory;
        }

        public void ShowInventroy(ContentManager content, Vector2 position, SpriteBatch spriteBatch)
        {
            Texture2D keyTexture = content.Load<Texture2D>("Pickable1");
            Texture2D coinTexture = content.Load<Texture2D>("Pickable2");
            Texture2D potionTexture = content.Load<Texture2D>("Pickable3");
            const int marginHorizontal = 10;
            const int marginVertical = 20;

            Vector2 tempVector;
            Sprite tempSprite;

            int NextYPos = 0;

            for (int i = 0; i < Inventory.MyKeys.Count; i++)
            {
                tempVector = new Vector2(position.X + (i * (keyTexture.Width + marginHorizontal)), position.Y + NextYPos);
                tempSprite = new Sprite(keyTexture, 1, tempVector);
                tempSprite.Draw(spriteBatch);            
            }

            NextYPos += keyTexture.Height + marginVertical;

            for (int i = 0; i < Inventory.MyCoins.Count; i++)
            {
                tempVector = new Vector2(position.X + (i * (coinTexture.Width + marginHorizontal)), position.Y + NextYPos);
                tempSprite = new Sprite(coinTexture, 1, tempVector);
                tempSprite.Draw(spriteBatch);
               
            }

            NextYPos += coinTexture.Height + marginVertical;

            for (int i = 0; i < Inventory.MyPotions.Count; i++)
            {
                tempVector = new Vector2(position.X + (i * (potionTexture.Width + marginHorizontal)), position.Y +NextYPos);
                tempSprite = new Sprite(potionTexture, 1, tempVector);
                tempSprite.Draw(spriteBatch);
            }
        }
    }



}
