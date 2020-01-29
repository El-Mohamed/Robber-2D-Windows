using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Robber_2D
{
    class StartScreen : GameState, IMenu
    {
        List<Button> allButtons;
        SpriteFont buttonFont;
        Texture2D buttonBorder, logoImage;
        int leftMarginLogo;

        public StartScreen(ContentManager contentManager, GraphicsDevice graphicsDevice, Robber2D game) : base(contentManager, graphicsDevice, game)
        {

        }

        public override void Initialize()
        {

        }

        public override void LoadContent()
        {
            // Logo

            logoImage = ContentManager.Load<Texture2D>("Logo");
            leftMarginLogo = (Robber2D.ScreenWidth - logoImage.Width) / 2;

            // Buttons

            allButtons = new List<Button>();
            buttonBorder = ContentManager.Load<Texture2D>("ButtonBorder");
            buttonFont = ContentManager.Load<SpriteFont>("ButtonFont");

            int leftMarginButton = (Robber2D.ScreenWidth - buttonBorder.Width) / 2; 

            List<String> buttonTitles = new List<string>() { "HERO MODE", "TANK MODE", "PLAY STORE", "EXIT" };
            int nextYPos = 550;

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

            allButtons[0].Click += StartGameAsHero;
            allButtons[1].Click += StartGameAsTank;
            allButtons[2].Click += OpenGooglePlay;
            allButtons[3].Click += CloseGame;
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
            DrawImages(spriteBatch);
            DrawText(spriteBatch);

            spriteBatch.End();
        }

        private void CloseGame(object sender, EventArgs e)
        {
            Game.Exit();
        }

        private void StartGameAsTank(object sender, EventArgs e)
        {
            GameStateManager.Instance.SetCurrentState(new InGame(ContentManager, GraphicsDevice, Game, GameMode.Tank));
        }

        private void StartGameAsHero(object sender, EventArgs e)
        {
            GameStateManager.Instance.SetCurrentState(new InGame(ContentManager, GraphicsDevice, Game, GameMode.Hero));
        }

        private void OpenGooglePlay(object sender, EventArgs e)
        {
            Process.Start("https://play.google.com/store/apps/details?id=com.mohamed.robber2D");
        }

        private void DrawLogo(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(logoImage, new Vector2(leftMarginLogo, 100), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1);
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

        public void DrawImages(SpriteBatch spriteBatch)
        {
            DrawLogo(spriteBatch);
        }

        public void DrawText(SpriteBatch spriteBatch)
        {

        }
    }
}
