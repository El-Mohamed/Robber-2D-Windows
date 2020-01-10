using Microsoft.Xna.Framework;

namespace Game_Development_Project
{
    interface IMover
    {
        Vector2 Speed { get; set; }
        void MoveRight();
        void MoveLeft();
        void Update(GameTime gameTime);
    }
}
