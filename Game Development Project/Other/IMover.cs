using Microsoft.Xna.Framework;

namespace Game_Development_Project
{
    interface IMover
    {
        void MoveRight();
        void MoveLeft();
        void Update(GameTime gameTime);
    }
}
