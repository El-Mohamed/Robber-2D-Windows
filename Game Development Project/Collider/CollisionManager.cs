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
            CheckPickablesCollision(player, currentLevel);
            CheckDoorCollision(player, currentLevel);
            CheckPlatformCollision(player, currentLevel);
            CheckMapRange(player, currentLevel);
            if (currentLevel is HardLevel)
            {
                HardLevel hardLevel = currentLevel as HardLevel;
                CheckBulletsCollison(player, hardLevel);
            }
        }

        private void CheckBulletsCollison(Player player, HardLevel hardLevel)
        {
            foreach (Tank tank in hardLevel.AllTanks)
            {
                for (int i = 0; i < tank.ShootedBullets.Count; i++)
                {
                    if (tank.ShootedBullets[i].CollisionRectangle.Intersects(player.CollisionRectangle))
                    {
                        player.UpdateHealth(tank.ShootedBullets[i]);
                        tank.ShootedBullets.RemoveAt(i);
                    }
                }
            }
        }

        private void CheckPickablesCollision(Player player, Level currentLevel)
        {
            for (int i = 0; i < currentLevel.AllPickables.Count; i++)
            {
                if (player.CollisionRectangle.Intersects(currentLevel.AllPickables[i].CollisionRectangle) && player.Inventory.HasPlace(currentLevel.AllPickables[i]))
                {
                    if (currentLevel.AllPickables[i] is MoneySafe)
                    {
                        MoneySafe temp = currentLevel.AllPickables[i] as MoneySafe;
                        if (player.Inventory.HasWorkingKey(temp))
                        {
                            player.Inventory.AddItem(currentLevel.AllPickables[i]);
                            currentLevel.AllPickables.RemoveAt(i);
                            player.Inventory.MyKey = null;
                        }
                    }
                    else
                    {
                        player.Inventory.AddItem(currentLevel.AllPickables[i]);
                        currentLevel.AllPickables.RemoveAt(i);
                    }
                }
            }
        }

        private void CheckDoorCollision(Player player, Level currentLevel)
        {
            foreach (Block obstacle in currentLevel.AllObstacles)
            {
                if (obstacle is Door)
                {
                    Door door = obstacle as Door;
                    if (player.CollisionRectangle.Intersects(door.CollisionRectangle))
                    {
                        InGame.CurrentLevel = currentLevel.NextLevel;
                        player.Respawn();
                    }
                }
            }
        }

        private void CheckPlatformCollision(Player player, Level level)
        {
            bool canMoveDown = true;
            bool canMoveLeft = true;
            bool canMoveRight = true;

            foreach (Block block in level.AllObstacles)
            {
                if (!(block is Door))
                {
                    if (canMoveDown == true)
                    {
                        canMoveDown = !(RectangleHelper.CheckTopCollision(player, block));
                    }

                    if (canMoveRight == true)
                    {
                        canMoveRight = !(RectangleHelper.CheckLeftCollision(player, block));
                    }

                    if (canMoveLeft == true)
                    {
                        canMoveLeft = !(RectangleHelper.CheckRightCollision(player, block));
                    }

                }
            }

            player.CanMoveDown = canMoveDown;
            player.CanMoveLeft = canMoveLeft;
            player.CanMoveRight = canMoveRight;

        }

        private void CheckMapRange(Player player, Level currentlevel)
        {
            if(player.CollisionRectangle.Top > 1600)
            {
                player.Respawn();
            }
        }


    }
}
