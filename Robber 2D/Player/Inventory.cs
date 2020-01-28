using System.Collections.Generic;

namespace Robber_2D
{
    class Inventory
    {
        public MoneySafeKey Key;
        public List<Coin> AllCoins;
        public Potion Potion;
        public int MyDiamonds = 0;

        public Inventory()
        {
            AllCoins = new List<Coin>();
        }

        public bool HasWorkingKey(MoneySafe moneySafe)
        {
            if (Key != null && Key.MoneySafeID.Equals(moneySafe.KeyID))
            {
                return true;
            }

            return false;
        }

        public bool HasPlace(Block pickable)
        {
            if (pickable is MoneySafeKey)
            {
                return (Key == null);
            }
            if (pickable is Potion)
            {
                return (Potion == null);
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
                Key = clone;
            }

            if (Item is Coin)
            {
                Coin coin = Item as Coin;
                Coin clone = (coin.Clone()) as Coin;
                AllCoins.Add(clone);
            }

            if (Item is Potion)
            {
                Potion potion = Item as Potion;
                Potion clone = (potion.Clone()) as Potion;
                Potion = clone;
            }

            if (Item is MoneySafe)
            {
                MoneySafe moneySafe = Item as MoneySafe;
                MyDiamonds += moneySafe.NumberOfDiamonds;
            }
        }
    }
}
