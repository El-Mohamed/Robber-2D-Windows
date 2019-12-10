using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Project
{
    class Inventory
    {
        public List<MoneySafeKey> MyKeys { get; set; }
        public List<Coin> MyCoins { get; set; }
        public List<Potion> MyPotions { get; set; }
        public int MyDiamonds { get; set; }

        public Inventory()
        {
            MyKeys = new List<MoneySafeKey>();
            MyCoins = new List<Coin>();
            MyPotions = new List<Potion>();
            MyDiamonds = 0;
        }

        public bool HasWorkingKey(MoneySafe moneySafe)
        {
            if(MyKeys.Count > 0 &&MyKeys[0].MoneySafeID.Equals( moneySafe.KeyID))
            {
                return true;
            }
            return false;
           
        }

        public bool HasPlace(Block pickable)
        {
            if(pickable is MoneySafeKey)
            {
                return (MyKeys.Count < 1);
            }
            if(pickable is Potion)
            {
                return (MyPotions.Count < 1);
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
                MyKeys.Add(clone);
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
                MyPotions.Add(clone);
            }
            if(Item is MoneySafe)
            {
                MoneySafe moneySafe = Item as MoneySafe;
                MyDiamonds += moneySafe.NumberOfDiamonds;              
            }

        }
    }
}
