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
                if (player.CollisionRectangle.Intersects(currentLevel.AllPickables[i].CollisionRectangle))
                {
                    if (player.Inventory.HasPlace(currentLevel.AllPickables[i]))
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
                    if (player.CollisionRectangle.Intersects(door.CollisionRectangle) && player.Inventory.HasCorrectDoorkey())
                    {
                        Game1.CurrentLevel = currentLevel.NextLevel;
                        player.Inventory.MyKeys.RemoveAt(0);
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
                        canMoveDown = !(CheckTopCollision(player, block));
                    }

                    if (canMoveRight == true)
                    {
                        canMoveRight = !(CheckLeftCollision(player, block));
                    }

                    if (canMoveLeft == true)
                    {
                        canMoveLeft = !(CheckRightCollision(player, block));
                    }

                }
            }

            player.CanMoveDown = canMoveDown;
            player.CanMoveLeft = canMoveLeft;
            player.CanMoveRight = canMoveRight;

        }

        private void CheckMapRange(Player player, Level currentlevel)
        {
            if(player.CollisionRectangle.Top > 1100)
            {
                player.Respawn();
            }
        }


        private bool CheckTopCollision(Player player, Block block)
        {
            return (player.CollisionRectangle.Bottom + player.Speed.Y + 2 > block.CollisionRectangle.Top &&
                 player.CollisionRectangle.Top < block.CollisionRectangle.Top &&
                 player.CollisionRectangle.Right > block.CollisionRectangle.Left &&
                 player.CollisionRectangle.Left < block.CollisionRectangle.Right);
        }

        private bool CheckBottomCollision(Player player, Block block)
        {
            return (player.CollisionRectangle.Top + player.Speed.Y + 2 < block.CollisionRectangle.Bottom &&
                 player.CollisionRectangle.Bottom > block.CollisionRectangle.Bottom &&
                 player.CollisionRectangle.Right > block.CollisionRectangle.Left &&
                 player.CollisionRectangle.Left < block.CollisionRectangle.Right);
        }

        private bool CheckRightCollision(Player player, Block block)
        {
            return (player.CollisionRectangle.Left - player.Speed.X + 1 < block.CollisionRectangle.Right &&
                 player.CollisionRectangle.Right > block.CollisionRectangle.Right &&
                 player.CollisionRectangle.Bottom > block.CollisionRectangle.Top &&
                 player.CollisionRectangle.Top < block.CollisionRectangle.Bottom);
        }

        private bool CheckLeftCollision(Player player, Block block)
        {
            return (player.CollisionRectangle.Right + player.Speed.X + 1 > block.CollisionRectangle.Left &&
                player.CollisionRectangle.Left < block.CollisionRectangle.Left &&
                player.CollisionRectangle.Bottom > block.CollisionRectangle.Top &&
                player.CollisionRectangle.Top < block.CollisionRectangle.Bottom);
        }
    }
}
