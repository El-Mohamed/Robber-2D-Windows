using Microsoft.Xna.Framework.Input;

namespace Robber_2D
{
    class Controller
    {
        public bool Up, Down, Left, Right, Space, D;

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

            if (stateKey.IsKeyDown(Keys.D))
            {
                D = true;
            }
            if (stateKey.IsKeyUp(Keys.D))
            {
                D = false;
            }

            if (stateKey.IsKeyDown(Keys.Space))
            {
                Space = true;
            }
            if (stateKey.IsKeyUp(Keys.Space))
            {
                Space = false;
            }
        }
    }
}
