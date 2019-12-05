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

        public Inventory()
        {
            MyKeys = new List<DoorKey>();
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

        }
    }
}
