using Microsoft.Xna.Framework;

namespace Robber_2D_Windows
{
    interface IMover
    {
        void MoveRight();
        void MoveLeft();
        void Update(GameTime gameTime);
    }
}
