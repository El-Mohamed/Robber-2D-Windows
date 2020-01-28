using Microsoft.Xna.Framework;

namespace Robber_2D
{
    interface IMover
    {
        void MoveRight();
        void MoveLeft();
        void Update(GameTime gameTime);
    }
}
