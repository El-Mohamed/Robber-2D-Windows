using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Game_Development_Project
{
    class InGame : GameState
    {
        #region Fields
        public static Player player;

        public static int CurrentLevel;
        List<Level> AllLevels;
        CollisionManager collisionManager;

        InventoryBar inventroyHelper;
        HealthBar healtbar;

        GameSounds gameSounds;
        SpriteFont defaultFont;
        SoundEffect pickSound, hitSound, drinkSound, jumpSound, gameOverSound;
        Texture2D potionTexture, coinTexture, keyTexture, diamondTexture, healtTexture;
        List<Texture2D> allTextures;

        #endregion

        public InGame(ContentManager contentManager, GraphicsDevice graphicsDevice, Game1 game) : base(contentManager, graphicsDevice, game)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            graphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(transformMatrix: Camera2D.Transform);

            // Levels
            AllLevels[CurrentLevel].Draw(spriteBatch);

            // Player
            player.Draw(spriteBatch);

            // Clock
            Clock.Draw(spriteBatch);

            // Healtbar
            healtbar.Draw(spriteBatch);

            // Inventory
            inventroyHelper.Draw(spriteBatch);

            spriteBatch.End();
        }

        public override void Initialize()
        {

        }

        public override void LoadContent()
        {
            // Player 1

            int spriteSheetLength = 6;
            Texture2D playerTexture = contentManager.Load<Texture2D>("PlayerSpriteSheet");
            Controller playerController = new Controller();
            Vector2 playerPosition = new Vector2();
            Vector2 playerSpeed = new Vector2(7, 0);
            Animation playerAnimation = new Animation();
            Sprite playerSprite = new Sprite(playerTexture, 6, playerPosition);
            Rectangle playerCollisonRectangle = new Rectangle((int)playerPosition.X, (int)playerPosition.Y, playerTexture.Width / spriteSheetLength, playerTexture.Height);
            Inventory playerInventory = new Inventory();
            player = new Player(playerSprite, playerController, playerAnimation, playerCollisonRectangle, playerSpeed, playerInventory);
            player.Respawn();

            // Other

            AllLevels = new List<Level>();
            CurrentLevel = 0;
            collisionManager = new CollisionManager();

            // SoundEffects
            pickSound = contentManager.Load<SoundEffect>("PickSound");
            hitSound = contentManager.Load<SoundEffect>("HitSound");
            drinkSound = contentManager.Load<SoundEffect>("DrinkSound");
            gameOverSound = contentManager.Load<SoundEffect>("GameOverSound");
            jumpSound = contentManager.Load<SoundEffect>("JumpSound");
            gameSounds = new GameSounds(pickSound, hitSound, drinkSound, jumpSound, gameOverSound);


            // Clock

            defaultFont = contentManager.Load<SpriteFont>("DefaultFont");
            Clock.SpriteFont = defaultFont;

            // Inventory Helper 

            keyTexture = contentManager.Load<Texture2D>("Pickable1");
            coinTexture = contentManager.Load<Texture2D>("Pickable2");
            potionTexture = contentManager.Load<Texture2D>("Pickable3");
            diamondTexture = contentManager.Load<Texture2D>("Diamond");
            allTextures = new List<Texture2D>() { keyTexture, coinTexture, potionTexture, diamondTexture };
            inventroyHelper = new InventoryBar(player.Inventory, allTextures, defaultFont);

            // Healthbar

            healtTexture = contentManager.Load<Texture2D>("Health");
            healtbar = new HealthBar(healtTexture);

            #region Level0

            byte[,] ObstaclesLevel0 = new byte[,]
            {
                 {1,1,0,0,0,0,1,1 },
                 {1,1,1,1,0,1,0,0 },
                 {2,1,1,1,1,1,0,0 }
            };

            byte[,] PickablesLevel0 = new byte[,]
            {
                 {0,0,0,0,0,0,0,4 },
                 {0,0,0,1,0,0,0,0 },
                 {0,0,0,0,0,0,0,0 }
            };

            List<int> MoneySafeIndetifiers0 = new List<int>() { 10006, };

            Level level0 = new Level(ObstaclesLevel0, PickablesLevel0, MoneySafeIndetifiers0, new List<Block>(), new List<Block>());
            level0.Create(contentManager);
            level0.NextLevel = AllLevels.Count + 1;
            AllLevels.Add(level0);

            #endregion

            #region Level1

            byte[,] ObstaclesLevel1 = new byte[,]
            {
                 {1,0,1,0,0,0,0,1,0,0 },
                 {1,0,0,0,1,1,1,1,0,1},
                 {1,1,2,1,1,1,1,0,1,1},
                 {1,1,0,1,0,1,1,1,0,1}
            };

            byte[,] PickablesLevel1 = new byte[,]
            {
                 {0,0,0,0,0,0,0,4,0,0 },
                 {0,0,0,0,0,1,0,0,0,0 },
                 {0,0,0,0,0,0,0,0,0,4 },
                 {0,1,0,0,0,0,0,0,0,0 }
            };

            List<int> MoneySafeIndetifiers1 = new List<int>() { 10006, 10007 };

            Level level1 = new Level(ObstaclesLevel1, PickablesLevel1, MoneySafeIndetifiers1, new List<Block>(), new List<Block>());
            level1.Create(contentManager);
            level1.NextLevel = AllLevels.Count + 1;
            AllLevels.Add(level1);

            #endregion

            #region Level3

            byte[,] ObstaclesLevel2 = new byte[,]
            {
                 {1,0,0,1,0,0,1,0,1,0 },
                 {1,1,1,1,1,1,0,1,1,1 },
                 {0,1,2,1,0,1,1,1,1,1 },
            };

            byte[,] PickablesLevel2 = new byte[,]
            {
                 {0,0,0,2,0,0,2,0,4,0 },
                 {0,0,3,0,0,0,0,0,0,0 },
                 {0,0,0,0,0,1,0,0,0,0 },
            };


            byte[,] EnemiesArray2 = new byte[,]
            {
                 {0,0,0,0,0,0,0,0,0,0 },
                 {0,0,0,1,0,0,0,0,0,0 },
                 {0,0,0,0,0,0,0,0,1,0 },
            };

            List<int> MoneySafeIndetifiers2 = new List<int>() { 10009 };

            Level level2 = new HardLevel(ObstaclesLevel2, PickablesLevel2, MoneySafeIndetifiers2, EnemiesArray2, new List<Block>(), new List<Block>(), new List<Tank>());
            level2.Create(contentManager);
            level2.NextLevel = AllLevels.Count + 1;
            AllLevels.Add(level2);

            #endregion

        }

        public override void UnloadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {
            // Player

            if (player.IsDead)
            {
                GameStateManager.Instance.SetCurrentState(new EndScreen(contentManager, graphicsDevice, game));
            }

            player.Update(gameTime);

            // Clock
            Clock.UpdateTime(gameTime);
            Clock.UpdatePosition(player);

            // Heathbar
            healtbar.UpdateHealth(player);
            healtbar.UpdatePosition(player);

            // Inventory
            inventroyHelper.UpdatePosition(player);

            // Camera
            Camera2D.Follow(player);

            // Levels
            AllLevels[CurrentLevel].Update(gameTime);
            collisionManager.CheckCollision(player, AllLevels[CurrentLevel]);
            if (AllLevels[CurrentLevel] is HardLevel)
            {
                HardLevel hardLevel = AllLevels[CurrentLevel] as HardLevel;
                hardLevel.CreateBullets(contentManager);
            }

        }
    }
}
