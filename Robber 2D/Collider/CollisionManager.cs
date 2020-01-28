namespace Robber_2D
{
    class CollisionManager
    {
        public void CheckCollision(Player player, World currentLevel)
        {
            CheckPickablesCollision(player, currentLevel);
            CheckDoorCollision(player, currentLevel);
            CheckPlatformCollision(player, currentLevel);
            CheckMapRange(player, currentLevel);
            if (currentLevel is SpecialWorld)
            {
                SpecialWorld specialWorld = currentLevel as SpecialWorld;
                CheckEnemiesBulletsCollision(player, specialWorld);
                CheckPlayerBulletsCollison(player, specialWorld);
            }
        }

        private void CheckEnemiesBulletsCollision(Player player, SpecialWorld specialWorld)
        {
            foreach (Tank tank in specialWorld.AllTanks)
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

        private void CheckPlayerBulletsCollison(Player player, SpecialWorld specialWorld)
        {
            for (int i = 0; i < player.ShootedBullets.Count; i++)
            {
                Bullet bullet = player.ShootedBullets[i];
           
                for (int j = 0; j < specialWorld.AllTanks.Count; j++)
                {
                    Tank tank = specialWorld.AllTanks[j];

                    if (bullet.CollisionRectangle.Intersects(tank.CollisionRectangle))
                    {
                        tank.UpdateHealth(bullet);
                        player.ShootedBullets.RemoveAt(i);

                        if (tank.IsDestroyed)
                        {
                            specialWorld.AllTanks.RemoveAt(j);
                        }
                    }
                }
            }
        }

        private void CheckPickablesCollision(Player player, World currentLevel)
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
                            player.Inventory.Key = null;
                            currentLevel.totalMoneySafes--;
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

        private void CheckDoorCollision(Player player, World currentLevel)
        {
            foreach (Block obstacle in currentLevel.AllObstacles)
            {
                if (obstacle is Door && currentLevel.IsCompleted)
                {
                    Door door = obstacle as Door;
                    if (player.CollisionRectangle.Intersects(door.CollisionRectangle))
                    {
                        if (currentLevel.NextWorld == InGame.GAMEISDONECODE)
                        {
                            InGame.PlayerWon = true;
                        }
                        else
                        {
                            InGame.CurrentWorld = currentLevel.NextWorld;
                            player.Respawn();
                        }
                    }
                }
            }
        }

        private void CheckPlatformCollision(Player player, World level)
        {
            bool canMoveDown = true;
            bool canMoveLeft = true;
            bool canMoveRight = true;
            bool canMoveUp = true;

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

                    if (canMoveUp)
                    {
                        canMoveUp = !(RectangleHelper.CheckBottomCollision(player, block));
                    }

                }
            }

            player.CanMoveDown = canMoveDown;
            player.CanMoveLeft = canMoveLeft;
            player.CanMoveRight = canMoveRight;
            player.CanMoveUp = canMoveUp;

        }

        private void CheckMapRange(Player player, World currentlevel)
        {
            if (player.CollisionRectangle.Top > currentlevel.MapRange)
            {
                player.Respawn();
            }
        }
    }
}
