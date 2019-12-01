using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Project
{
    class Controller
    {
        public bool Up { get; set; }
        public bool Right { get; set; }
        public bool Down { get; set; }
        public bool Left { get; set; }
        public bool Jump { get; set; }

        public void Update()
        {
            KeyboardState stateKey = Keyboard.GetState();

            if (stateKey.IsKeyDown(Keys.Up))
            {
                Up = true;
            }
            if (stateKey.IsKeyUp(Keys.Left))
            {
                Up = false;
            }

            if (stateKey.IsKeyDown(Keys.Right))
            {
                Right = true;
            }
            if (stateKey.IsKeyUp(Keys.Right))
            {
                Right = false;
            }

            if (stateKey.IsKeyDown(Keys.Down))
            {
                Down = true;
            }
            if (stateKey.IsKeyUp(Keys.Down))
            {
                Down = false;
            }

            if (stateKey.IsKeyDown(Keys.Left))
            {
                Left = true;
            }
            if (stateKey.IsKeyUp(Keys.Left))
            {
                Left = false;
            }

        }
    }
}
