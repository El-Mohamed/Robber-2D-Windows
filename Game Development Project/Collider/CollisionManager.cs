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

            // kan korter
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
            bool onSurface = false;
            bool Left = true;
            bool Right = true;

            foreach (Block block in level.AllObstacles)
            {

                if (!(block is Door))
                {
                   

                    if (onSurface == false)
                    {
                        onSurface = CheckTopCollision(player, block);
                    }

                    if (Right == true  )
                    {
                        Right = !(CheckLeftCollision(player, block));
                    }
                  
                    if (Left == true )
                    {
                        Left = !(CheckRightCollision(player, block));
                    }

                }

            }

            player.SetFallSpeed(onSurface);
            player.canGoLeft = Left;
            player.canGoRight = Right;

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
            return (player.CollisionRectangle.Left - player.Speed.X +1 < block.CollisionRectangle.Right &&
                 player.CollisionRectangle.Right > block.CollisionRectangle.Right &&
                 player.CollisionRectangle.Bottom > block.CollisionRectangle.Top &&
                 player.CollisionRectangle.Top < block.CollisionRectangle.Bottom);
        }


        private bool CheckLeftCollision(Player player, Block block)
        {
            return (player.CollisionRectangle.Right + player.Speed.X +1 > block.CollisionRectangle.Left &&
                player.CollisionRectangle.Left < block.CollisionRectangle.Left &&
                player.CollisionRectangle.Bottom > block.CollisionRectangle.Top &&
                player.CollisionRectangle.Top < block.CollisionRectangle.Bottom);
        }




    }
}
