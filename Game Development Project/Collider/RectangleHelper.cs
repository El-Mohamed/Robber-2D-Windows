using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Project
{
    class RectangleHelper
    {

        static public bool CheckTopCollision(Player player, Block block)
        {
            return (player.CollisionRectangle.Bottom + player.Speed.Y + 10 > block.CollisionRectangle.Top &&
                 player.CollisionRectangle.Top < block.CollisionRectangle.Top &&
                 player.CollisionRectangle.Right > block.CollisionRectangle.Left &&
                 player.CollisionRectangle.Left < block.CollisionRectangle.Right);
        }

        static public bool CheckBottomCollision(Player player, Block block)
        {
            return (player.CollisionRectangle.Top + player.Speed.Y - 1 < block.CollisionRectangle.Bottom &&
                 player.CollisionRectangle.Bottom > block.CollisionRectangle.Bottom &&
                 player.CollisionRectangle.Right > block.CollisionRectangle.Left &&
                 player.CollisionRectangle.Left < block.CollisionRectangle.Right);
        }

        static public bool CheckRightCollision(Player player, Block block)
        {
            return (player.CollisionRectangle.Left - player.Speed.X + 1 < block.CollisionRectangle.Right &&
                 player.CollisionRectangle.Right > block.CollisionRectangle.Right &&
                 player.CollisionRectangle.Bottom > block.CollisionRectangle.Top &&
                 player.CollisionRectangle.Top < block.CollisionRectangle.Bottom);
        }

        static public bool CheckLeftCollision(Player player, Block block)
        {
            return (player.CollisionRectangle.Right + player.Speed.X + 1 > block.CollisionRectangle.Left &&
                player.CollisionRectangle.Left < block.CollisionRectangle.Left &&
                player.CollisionRectangle.Bottom > block.CollisionRectangle.Top &&
                player.CollisionRectangle.Top < block.CollisionRectangle.Bottom);
        }
    }
}
