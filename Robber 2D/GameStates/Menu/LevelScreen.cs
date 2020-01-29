using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Robber_2D
{
    class LevelScreen : GameState, IBasicMenu
    {
        List<Button> allButtons;
        SpriteFont buttonFont;
        Texture2D buttonBorder;
        GameMode selectedGameMode;

        public LevelScreen(ContentManager contentManager, GraphicsDevice graphicsDevice, Robber2D game, GameMode selectedGameMode) : base(contentManager, graphicsDevice, game)
        {
            this.selectedGameMode = selectedGameMode;
        }

        public override void Initialize()
        {

        }

        public override void LoadContent()
        {
            allButtons = new List<Button>();
            buttonBorder = ContentManager.Load<Texture2D>("ButtonBorder");
            buttonFont = ContentManager.Load<SpriteFont>("ButtonFont");

            int leftMarginButton = (Robber2D.ScreenWidth - buttonBorder.Width) / 2;

            List<String> buttonTitles = new List<string>() { "INTRO", "EASY", "MEDUIM", "HARD" };
            int nextYPos = 400;

            for (int i = 0; i < buttonTitles.Count; i++)
            {
                Button button = new Button(buttonBorder, buttonFont)
                {
                    Text = buttonTitles[i],
                    Position = new Vector2(leftMarginButton, nextYPos)
                };

                allButtons.Add(button);
                nextYPos += 100;
            }

            allButtons[0].Click += StartIntroWorld;
            allButtons[1].Click += StartEasyWorld;
            allButtons[2].Click += StartMeduimWorld;
            allButtons[3].Click += StartHardWorld;
        }

        public override void UnloadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {
            UpdateButtons(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            DrawButtons(spriteBatch);

            spriteBatch.End();
        }

        private void StartIntroWorld(object sender, EventArgs e)
        {
            GameStateManager.Instance.SetCurrentState(new InGame(ContentManager, GraphicsDevice, Game, selectedGameMode, 0));
        }

        private void StartEasyWorld(object sender, EventArgs e)
        {
            GameStateManager.Instance.SetCurrentState(new InGame(ContentManager, GraphicsDevice, Game, selectedGameMode, 1));
        }

        private void StartMeduimWorld(object sender, EventArgs e)
        {
            GameStateManager.Instance.SetCurrentState(new InGame(ContentManager, GraphicsDevice, Game, selectedGameMode, 2));
        }

        private void StartHardWorld(object sender, EventArgs e)
        {
            GameStateManager.Instance.SetCurrentState(new InGame(ContentManager, GraphicsDevice, Game, GameMode.Tank, 3));
        }


        public void DrawButtons(SpriteBatch spriteBatch)
        {
            foreach (Button button in allButtons)
            {
                button.Draw(spriteBatch);
            }
        }

        public void UpdateButtons(GameTime gameTime)
        {
            foreach (Button button in allButtons)
            {
                button.Update(gameTime);
            }
        }
    }
}
