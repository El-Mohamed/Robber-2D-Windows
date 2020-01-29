using Microsoft.Xna.Framework.Input;

namespace Robber_2D
{
    class KeyboardController: IController
    {
        public Output Output { get; set; }

        public KeyboardController(Output output)
        {
            Output = output;
        }

        public void Update()
        {
            KeyboardState stateKey = Keyboard.GetState();

            if (stateKey.IsKeyDown(Keys.Up))
            {
                Output.Up = true;
            }
            if (stateKey.IsKeyUp(Keys.Left))
            {
                Output.Up = false;
            }

            if (stateKey.IsKeyDown(Keys.Right))
            {
                Output.Right = true;
            }
            if (stateKey.IsKeyUp(Keys.Right))
            {
                Output.Right = false;
            }

            if (stateKey.IsKeyDown(Keys.Down))
            {
                Output.Down = true;
            }
            if (stateKey.IsKeyUp(Keys.Down))
            {
                Output.Down = false;
            }

            if (stateKey.IsKeyDown(Keys.Left))
            {
                Output.Left = true;
            }
            if (stateKey.IsKeyUp(Keys.Left))
            {
                Output.Left = false;
            }

            if (stateKey.IsKeyDown(Keys.D))
            {
                Output.Drink = true;
            }
            if (stateKey.IsKeyUp(Keys.D))
            {
                Output.Drink = false;
            }

            if (stateKey.IsKeyDown(Keys.Space))
            {
                Output.Jump = true;
            }
            if (stateKey.IsKeyUp(Keys.Space))
            {
                Output.Jump = false;
            }

            if (stateKey.IsKeyDown(Keys.S))
            {
                Output.Shoot = true;
            }
            if (stateKey.IsKeyUp(Keys.S))
            {
                Output.Shoot = false;
            }
        }
    }
}
