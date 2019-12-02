using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Project
{
    interface ICollider
    {
        Rectangle CollisionRectangle { get; set ;}
    }
}
