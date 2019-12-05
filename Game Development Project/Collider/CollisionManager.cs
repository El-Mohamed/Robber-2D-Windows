using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Project
{
    class CollisionManager
    {

        public void CheckCollision(Player player, Level currentLevel)
        {
            if (currentLevel is StartLevel)
            {
                StartLevel startLevel = currentLevel as StartLevel;
                CheckPickablesCollision(player, startLevel);
            }
        }

        private void CheckPickablesCollision(Player player, StartLevel currentLevel)
        {
            bool hasCollided = false;
            int itemIndex = 0;

            for (int i = 0; i < currentLevel.AllPickables.Count; i++)
            {
                if (player.CollisionRectangle.Intersects(currentLevel.AllPickables[i].CollisionRectangle))
                {
                    itemIndex = i;
                    hasCollided = true;
                }
            }

            if (hasCollided)
            {
                player.Inventory.AddItem(currentLevel.AllPickables[itemIndex]);
                currentLevel.AllPickables.RemoveAt(itemIndex);
            }
        }

    }
}
