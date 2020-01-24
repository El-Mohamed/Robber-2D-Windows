using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Robber_2D_Windows
{
    class InGame : GameState
    {
        #region Fields
        public static Player player;

        public static int CurrentWorld;
        List<World> AllWorlds;
        CollisionManager collisionManager;

        InventoryBar inventroyHelper;
        HealthBar healtbar;
        Clock clock;

        GameSounds gameSounds;
        SpriteFont defaultFont;
        SoundEffect pickSound, hitSound, drinkSound, jumpSound, gameOverSound;
        Texture2D potionTexture, coinTexture, keyTexture, diamondTexture, healtTexture;
        List<Texture2D> allTextures;
        static public bool PlayerWon;
        static public int GAMEISDONECODE = 999;

        #endregion

        public InGame(ContentManager contentManager, GraphicsDevice graphicsDevice, Robber2D game) : base(contentManager, graphicsDevice, game)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            graphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(transformMatrix: Camera2D.Transform);

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

            AllWorlds = new List<World>();
            CurrentWorld = 0;
            collisionManager = new CollisionManager();
            PlayerWon = false;

            // SoundEffects
            pickSound = contentManager.Load<SoundEffect>("PickSound");
            hitSound = contentManager.Load<SoundEffect>("HitSound");
            drinkSound = contentManager.Load<SoundEffect>("DrinkSound");
            gameOverSound = contentManager.Load<SoundEffect>("GameOverSound");
            jumpSound = contentManager.Load<SoundEffect>("JumpSound");
            gameSounds = new GameSounds(pickSound, hitSound, drinkSound, jumpSound, gameOverSound);


            // Clock

            defaultFont = contentManager.Load<SpriteFont>("DefaultFont");
            clock = new Clock(defaultFont);

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
            world1.Create(contentManager);
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
            world2.Create(contentManager);
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
            world3.Create(contentManager);
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
                GameStateManager.Instance.SetCurrentState(new WinScreen(contentManager, graphicsDevice, game));
            }

            if (player.IsDead)
            {
                GameStateManager.Instance.SetCurrentState(new EndScreen(contentManager, graphicsDevice, game));
            }

            player.Update(gameTime);

            // Clock
            clock.Update(gameTime);
            clock.UpdatePosition(ScreenPositionHelper.GetScreenTop(player));

            // Heathbar
            healtbar.SetHealth(player);
            healtbar.UpdatePosition(ScreenPositionHelper.GetRightTopCorner(player));

            // Inventory
            inventroyHelper.UpdatePosition(ScreenPositionHelper.GetLeftScreenCorner(player), player.SpriteSheet.Position); 

            // Camera
            Camera2D.Follow(player);

            // Levels
            AllWorlds[CurrentWorld].Update(gameTime);
            collisionManager.CheckCollision(player, AllWorlds[CurrentWorld]);
            if (AllWorlds[CurrentWorld] is SpecialWorld)
            {
                SpecialWorld hardLevel = AllWorlds[CurrentWorld] as SpecialWorld;
                hardLevel.CreateBullets(contentManager);
            }

        }
    }
}
