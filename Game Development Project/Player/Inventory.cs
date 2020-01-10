using System.Collections.Generic;

namespace Game_Development_Project
{
    class Inventory
    {
        public MoneySafeKey MyKey;
        public List<Coin> MyCoins;
        public Potion MyPotion;
        public int MyDiamonds;

        public Inventory()
        {
            MyCoins = new List<Coin>();
            MyDiamonds = 0;
        }

        public bool HasWorkingKey(MoneySafe moneySafe)
        {
            if (MyKey != null && MyKey.MoneySafeID.Equals(moneySafe.KeyID))
            {
                return true;
            }
            return false;

        }

        public bool HasPlace(Block pickable)
        {
            if (pickable is MoneySafeKey)
            {
                return (MyKey == null);
            }
            if (pickable is Potion)
            {
                return (MyPotion == null);
            }
            else
            {
                return true; // Coins && Diamonds have always place
            }
        }

        public void AddItem(Block Item)
        {
            GameSounds.PlayPickSound();

            if (Item is MoneySafeKey)
            {
                MoneySafeKey doorKey = Item as MoneySafeKey;
                MoneySafeKey clone = (doorKey.Clone()) as MoneySafeKey;
                MyKey = clone;
            }
            if (Item is Coin)
            {
                Coin coin = Item as Coin;
                Coin clone = (coin.Clone()) as Coin;
                MyCoins.Add(clone);
            }
            if (Item is Potion)
            {
                Potion potion = Item as Potion;
                Potion clone = (potion.Clone()) as Potion;
                MyPotion = clone;
            }
            if (Item is MoneySafe)
            {
                MoneySafe moneySafe = Item as MoneySafe;
                MyDiamonds += moneySafe.NumberOfDiamonds;
            }
        }
    }
}
