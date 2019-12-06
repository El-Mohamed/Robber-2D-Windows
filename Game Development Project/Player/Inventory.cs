using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Project
{
    class Inventory
    {
        public List<DoorKey> MyKeys { get; set; }
        public List<Coin> MyCoins { get; set; }
        public List<Potion> MyPotions { get; set; }

        public Inventory()
        {
            MyKeys = new List<DoorKey>();
            MyCoins = new List<Coin>();
            MyPotions = new List<Potion>();
        }

        public bool HasCorrectDoorkey()
        {
            bool CorrectKeyFound = false;

            foreach (DoorKey doorKey in MyKeys)
            {
                if(doorKey.IsCorrect)
                {
                    CorrectKeyFound = true;
                }
            }

            return CorrectKeyFound;
        }

        public void AddItem(Block Item)
        {

            if (Item is DoorKey)
            {
                DoorKey doorKey = Item as DoorKey;
                DoorKey clone = (doorKey.Clone()) as DoorKey;
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

        }
    }
}
