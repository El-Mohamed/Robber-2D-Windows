using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Game_Development_Project
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        List<Level> AllLevels;
        private Camera camera;
        public static int ScreenHeight;
        public static int ScreenWidth;
        public static int CurrentLevel;
        CollisionManager collisionManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width,
                PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height
            };
            Content.RootDirectory = "Content";
            ScreenHeight = graphics.PreferredBackBufferHeight;
            ScreenWidth = graphics.PreferredBackBufferWidth;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Player 1

            int spriteSheetLength = 6;
            Texture2D playerTexture = Content.Load<Texture2D>("PlayerSpriteSheet");
            Controller playerController = new Controller();
            Vector2 playerPosition = new Vector2(3000, 200);
            Vector2 playerSpeed = new Vector2(4, 1);
            Animation playerAnimation = new Animation();
            Sprite playerSprite = new Sprite(playerTexture, 6, playerPosition);
            Rectangle playerCollisonRectangle = new Rectangle((int)playerPosition.X, (int)playerPosition.Y, playerTexture.Width / spriteSheetLength, playerTexture.Height);
            Inventory playerInventory = new Inventory();
            player = new Player(playerSprite, playerController, playerAnimation, playerCollisonRectangle, playerSpeed, playerInventory);

            // Level 1

            byte[,] ObstaclesLevel1 = new byte[,]
            {
                 {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                 {1,0,1,0,1,1,0,1,1,1,1,0,1,1,0,1,1,0,0,1,1,1,0,1},
                 {1,1,0,1,0,1,1,0,1,1,0,1,0,1,1,1,0,1,1,1,0,1,1,0},
                 {1,0,1,0,1,1,0,1,1,1,1,0,1,1,0,1,1,0,0,1,1,1,0,1},
                 {1,1,0,1,0,1,1,0,1,1,0,1,0,1,1,1,0,1,1,1,0,1,1,0},
                 {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,1},
            };

            byte[,] DoorKeysLevel1 = new byte[,]
           {
                 {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                 {1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0},
                 {0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                 {0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1},
                 {0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0},
                 {0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},

           };

            List<Block> PickablesLevel1 = new List<Block>();
            Level level1 = new StartLevel(ObstaclesLevel1, new List<Block>(), DoorKeysLevel1, PickablesLevel1);
            level1.Create(Content);
            AllLevels = new List<Level>
            {
                level1
            };

            // Other

            CurrentLevel = 0;
            camera = new Camera();
            collisionManager = new CollisionManager();

        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            camera.Follow(player);
            player.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin(transformMatrix: camera.Transform);

            AllLevels[CurrentLevel].Draw(spriteBatch);
            collisionManager.CheckCollision(player, AllLevels[CurrentLevel]);
            player.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
