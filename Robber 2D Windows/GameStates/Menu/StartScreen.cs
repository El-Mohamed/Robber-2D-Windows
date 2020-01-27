using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Robber_2D_Windows
{
    class StartScreen : GameState
    {
        #region Fields

        public List<Button> AllButtons;
        private Texture2D buttonBorder;
        private SpriteFont buttonFont;
        private Button startButton, androidVersionButton, exitButton;
        private Texture2D logo;
        private int leftMarginLogo;

        #endregion
        public StartScreen(ContentManager contentManager, GraphicsDevice graphicsDevice, Robber2D game) : base(contentManager, graphicsDevice, game)
        {

        }

        public override void Initialize()
        {

        }

        public override void LoadContent()
        {
            AllButtons = new List<Button>();

            buttonBorder = ContentManager.Load<Texture2D>("ButtonBorder");
            buttonFont = ContentManager.Load<SpriteFont>("ButtonFont");
            logo = ContentManager.Load<Texture2D>("Logo");

            int leftMarginButton = (Robber2D.ScreenWidth - buttonBorder.Width) / 2; // Center buttons on the screen
            leftMarginLogo = (Robber2D.ScreenWidth - logo.Width) / 2;

            startButton = new Button(buttonBorder, buttonFont)
            {
                Text = "START GAME",
                Position = new Vector2(leftMarginButton, 550)
            };
            androidVersionButton = new Button(buttonBorder, buttonFont)
            {
                Text = "GOOGLE PLAY",
                Position = new Vector2(leftMarginButton, 650)
            };
            exitButton = new Button(buttonBorder, buttonFont)
            {
                Text = "EXIT",
                Position = new Vector2(leftMarginButton, 750)
            };

            AllButtons.Add(startButton);
            AllButtons.Add(androidVersionButton);
            AllButtons.Add(exitButton);

            exitButton.Click += CloseGame;
            androidVersionButton.Click += ShowInGooglePlay;
            startButton.Click += StartGame;
        }

        private void CloseGame(object sender, EventArgs e)
        {
            Game.Exit();
        }

        private void StartGame(object sender, EventArgs e)
        {
            GameStateManager.Instance.SetCurrentState(new InGame(ContentManager, GraphicsDevice, Game));
        }

        private void ShowInGooglePlay(object sender, EventArgs e)
        {
            Process.Start("https://play.google.com/store/apps/details?id=com.mohamed.robber2D");
        }

        public override void UnloadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {
            foreach (Button button in AllButtons)
            {
                button.Update(gameTime);
            }
        }

        private void DrawLogo(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(logo, new Vector2(leftMarginLogo, 100), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            DrawLogo(spriteBatch);

            foreach (Button b in AllButtons)
            {

                b.Draw(spriteBatch);
            }

            spriteBatch.End();
        }
    }
}
