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
            if (currentLevel is Level)
            {                
                CheckPickablesCollision(player, currentLevel);
                CheckDoorCollision(player, currentLevel);
            }
        }

        private void CheckPickablesCollision(Player player, Level currentLevel)
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

        private void CheckDoorCollision(Player player, Level currentLevel)
        {
            foreach (Block obstacle in currentLevel.AllObstacles)
            {
                if(obstacle is Door)
                {
                    Door door = obstacle as Door;
                    if (player.CollisionRectangle.Intersects(door.CollisionRectangle) && player.Inventory.HasCorrectDoorkey())
                    {                       
                        Game1.CurrentLevel = currentLevel.NextLevel;
                        player.Respawn();
                    }

                }
            }
        }

    }
}
