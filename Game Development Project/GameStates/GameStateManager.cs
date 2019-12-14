using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Project
{
    class GameStateManager
    {
        private IGameState currentGameState;
        private static GameStateManager instance;
  
        public static GameStateManager Instance => instance ?? (instance = new GameStateManager());

        public void Update(GameTime gameTime)
        {
            try
            {
                currentGameState.Update(gameTime);
            }
            catch (Exception e)
            {

            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            try
            {
                currentGameState.Draw(spriteBatch);
            }
            catch
            {

            }
        }

        public void UnloadContent()
        {
            currentGameState.UnloadContent();
        }

        public IGameState GetCurrentState()
        {
            return currentGameState;
        }

        public void SetCurrentState(IGameState state)
        {
            try
            {
                currentGameState = state;
                currentGameState.Initialize();
                currentGameState.LoadContent();
            }
            catch (Exception e)
            {

            }
        }
    }
}
