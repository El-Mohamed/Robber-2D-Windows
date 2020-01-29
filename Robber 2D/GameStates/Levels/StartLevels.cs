using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Robber_2D
{
    class InGame : GameState
    {
        #region Fields
        public static Player player;
        GameMode gameMode;

        public static int CurrentWorld;
        List<World> AllWorlds;
        CollisionManager collisionManager;

        InventoryBar inventroyHelper;
        HealthBar healtbar;
        Clock clock;
        Camera2D camera;

        GameSounds gameSounds;
        SpriteFont defaultFont;
        SoundEffect pickSound, hitSound, drinkSound, jumpSound, gameOverSound, explosionSound, shootSound;
        Texture2D potionTexture, coinTexture, keyTexture, diamondTexture, healtTexture;
        List<Texture2D> allTextures;
        static public bool PlayerWon;
        static public int GAMEISDONECODE = 999;

        #endregion

        public InGame(ContentManager contentManager, GraphicsDevice graphicsDevice, Robber2D game, GameMode gameMode) : base(contentManager, graphicsDevice, game)
        {
            this.gameMode = gameMode;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(transformMatrix: camera.Transform);

            // Levels
            AllWorlds[CurrentWorld].Draw(spriteBatch);

            // Player
            player.Draw(spriteBatch);

            // Clock
            clock.Draw(spriteBatch);

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
            Texture2D playerTexture;
            int spriteSheetLength;

            if (gameMode == GameMode.Hero)
            {
                spriteSheetLength = 6;
                playerTexture = ContentManager.Load<Texture2D>("PlayerSpriteSheet");
            }
            else
            {
                spriteSheetLength = 1;
                playerTexture = ContentManager.Load<Texture2D>("PlayerTank");
            }

            Output output = new Output();
            KeyboardController playerController = new KeyboardController(output);
            Vector2 playerPosition = new Vector2();
            Vector2 playerSpeed = new Vector2(7, 0);
            Animation playerAnimation = new Animation();
            Sprite playerSprite = new Sprite(playerTexture, spriteSheetLength, playerPosition);
            Rectangle playerCollisonRectangle = new Rectangle((int)playerPosition.X, (int)playerPosition.Y, playerTexture.Width / spriteSheetLength, playerTexture.Height);
            Inventory playerInventory = new Inventory();
            player = new Player(playerSprite, playerController, playerAnimation, playerCollisonRectangle, playerSpeed, playerInventory);
            player.Respawn();

            // Other

            AllWorlds = new List<World>();
            CurrentWorld = 0;
            collisionManager = new CollisionManager();
            PlayerWon = false;
            Factory.contentManager = ContentManager;

            // SoundEffects

            pickSound = ContentManager.Load<SoundEffect>("PickSound");
            hitSound = ContentManager.Load<SoundEffect>("HitSound");
            drinkSound = ContentManager.Load<SoundEffect>("DrinkSound");
            gameOverSound = ContentManager.Load<SoundEffect>("GameOverSound");
            jumpSound = ContentManager.Load<SoundEffect>("JumpSound");
            explosionSound = ContentManager.Load<SoundEffect>("ExplosionSound");
            shootSound = ContentManager.Load<SoundEffect>("ShootSound");
            gameSounds = new GameSounds(pickSound, hitSound, drinkSound, jumpSound, gameOverSound, explosionSound, shootSound);

            // Clock

            defaultFont = ContentManager.Load<SpriteFont>("DefaultFont");
            clock = new Clock(defaultFont);

            // Camera
            camera = new Camera2D();

            // Inventory Helper 

            keyTexture = ContentManager.Load<Texture2D>("Pickable1");
            coinTexture = ContentManager.Load<Texture2D>("Pickable2");
            potionTexture = ContentManager.Load<Texture2D>("Pickable3");
            diamondTexture = ContentManager.Load<Texture2D>("Diamond");
            allTextures = new List<Texture2D>() { keyTexture, coinTexture, potionTexture, diamondTexture };
            inventroyHelper = new InventoryBar(player.Inventory, allTextures, defaultFont);

            // Healthbar

            healtTexture = ContentManager.Load<Texture2D>("Health");
            healtbar = new HealthBar(healtTexture);

            #region World1

            byte[,] ObstaclesWorld1 = new byte[,]
            {
                 {1,1,0,0,0,0,1,1 },
                 {1,1,1,1,0,1,0,0 },
                 {2,1,1,1,1,1,0,0 }
            };

            byte[,] PickablesWorld1 = new byte[,]
            {
                 {0,0,0,0,0,0,0,4 },
                 {0,0,0,1,0,0,0,0 },
                 {0,0,2,0,0,0,0,0 }
            };

            List<int> MoneySafeIdentiefiers1 = new List<int>() { 10006, };

            World world1 = new World(ObstaclesWorld1, PickablesWorld1, MoneySafeIdentiefiers1);
            world1.Create(ContentManager);
            world1.NextWorld = AllWorlds.Count + 1;
            AllWorlds.Add(world1);

            #endregion

            #region World2

            byte[,] ObstaclesWorld2 = new byte[,]
            {
                 {1,0,0,0,1,0,0,1,0,0 },
                 {1,0,0,0,1,1,1,1,0,1},
                 {1,1,2,1,1,1,1,0,1,1},
                 {1,1,0,1,0,1,1,1,0,1}
            };

            byte[,] PickablesWorld2 = new byte[,]
            {
                 {0,0,0,0,2,0,0,4,0,0 },
                 {2,0,0,0,0,1,0,0,0,0 },
                 {0,0,0,0,0,3,0,0,0,4 },
                 {0,1,0,0,0,0,0,0,0,2 }
            };

            List<int> MoneySafeIdentiefiers2 = new List<int>() { 10006, 10007 };

            World world2 = new World(ObstaclesWorld2, PickablesWorld2, MoneySafeIdentiefiers2);
            world2.Create(ContentManager);
            world2.NextWorld = AllWorlds.Count + 1;
            AllWorlds.Add(world2);

            #endregion

            #region World3

            byte[,] ObstaclesWorld3 = new byte[,]
            {
                 {1,0,0,1,0,0,1,0,1,0 },
                 {1,1,1,1,1,1,0,1,1,1 },
                 {0,1,2,1,0,1,1,1,1,1 },
            };

            byte[,] PickablesWorld3 = new byte[,]
            {
                 {0,0,0,0,0,0,2,0,4,0 },
                 {2,0,0,0,0,0,0,0,0,0 },
                 {0,0,0,0,0,1,0,0,0,2 },
            };


            byte[,] EnemiesWorld3 = new byte[,]
            {
                 {0,0,0,0,0,0,0,0,0,0 },
                 {0,0,0,1,0,0,0,0,0,0 },
                 {0,0,0,0,0,0,0,0,1,0 },
            };

            List<int> MoneySafeIdentiefiers3 = new List<int>() { 10009 };

            World world3 = new SpecialWorld(ObstaclesWorld3, PickablesWorld3, MoneySafeIdentiefiers3, EnemiesWorld3);
            world3.Create(ContentManager);
            world3.NextWorld = GAMEISDONECODE;
            AllWorlds.Add(world3);

            #endregion

        }

        public override void UnloadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {
            // Player

            if (PlayerWon)
            {
                GameStateManager.Instance.SetCurrentState(new EndScreen(ContentManager, GraphicsDevice, Game, GameResult.Won));
            }

            if (player.IsDead)
            {
                GameStateManager.Instance.SetCurrentState(new EndScreen(ContentManager, GraphicsDevice, Game, GameResult.Lost));
            }

            player.Update(gameTime);

            // Clock
            clock.Update(gameTime);
            clock.UpdatePosition(ScreenPosition.Top(player));

            // Heathbar
            healtbar.SetHealth(player);
            healtbar.UpdatePosition(ScreenPosition.RightTopCorner(player));

            // Inventory
            inventroyHelper.UpdatePosition(ScreenPosition.LeftLopCorner(player), player.Sprite.Position);

            // Camera
            camera.Follow(player);

            // Levels
            AllWorlds[CurrentWorld].Update(gameTime);
            collisionManager.CheckCollision(player, AllWorlds[CurrentWorld]);
            if (AllWorlds[CurrentWorld] is SpecialWorld)
            {
                SpecialWorld hardLevel = AllWorlds[CurrentWorld] as SpecialWorld;
                hardLevel.CreateBullets();
            }

        }
    }
}
