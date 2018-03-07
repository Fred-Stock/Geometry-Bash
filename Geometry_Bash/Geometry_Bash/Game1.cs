using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Geometry_Bash
{
    // enums for finite state machine
    enum GameState
    {
        Menu,
        Instructions,
        PlayerSelect,
        Game,
        Options,
        EndGame
    }


    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont text;

        #region Textures
        //Character Textures
        Texture2D squareTexture;
        Texture2D circleTexture;
        Texture2D diamondTexture;
        
        // button textures
        Texture2D yellowButton;
        Texture2D back;
        Texture2D instructions;
        Texture2D options;

        // character select tiles
        Texture2D squareTile;
        Texture2D circleTile;
        Texture2D diamondTile;

        // screens
        Texture2D mainMenu;
        Texture2D instructionsMenu;
        #endregion

        #region Button Rectangles
        // button rectangles
        Rectangle playButton = new Rectangle(new Point(280, 260), new Point(250, 60));
        Rectangle instructionsButton = new Rectangle(new Point(280, 330), new Point(250, 60));
        Rectangle optionsButton = new Rectangle(new Point(280, 400), new Point(250, 60));
        Rectangle backButton = new Rectangle(new Point(10, 10), new Point(100, 50));
        #endregion


        GameState gamestate = GameState.Menu;

         
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1280;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 720;   // set this value to the desired height of your window
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            



            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            // sprite font load
            text = Content.Load<SpriteFont>("text");

            // load character textures
            squareTexture = Content.Load<Texture2D>("tempCharSprites//square-diamond");
            circleTexture = Content.Load<Texture2D>("tempCharSprites//circle");
            diamondTexture = Content.Load<Texture2D>("tempCharSprites//square-diamond");

            // load button textures
            yellowButton = Content.Load<Texture2D>("Button Sprites//button_yellow");

            // screen loads
            mainMenu = Content.Load<Texture2D>("Screens//Main Menu");
            instructionsMenu = Content.Load<Texture2D>("Screens//Instructions");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here




        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            // makes sure mouse is visible
            this.IsMouseVisible = true;
            MouseState ms;
            ms = Mouse.GetState();
            Rectangle mouseLocation = new Rectangle(ms.Position, new Point(5, 5));

            // Menu
            if (gamestate == GameState.Menu)
            {
                // all other code for this state goes here

                // handles button pressing for game state
                if (mouseLocation.Intersects(playButton))
                {
                    if (ms.LeftButton == ButtonState.Pressed)
                    {
                        gamestate = GameState.PlayerSelect;
                    }
                }
                if (mouseLocation.Intersects(instructionsButton))
                {
                    if (ms.LeftButton == ButtonState.Pressed)
                    {
                        gamestate = GameState.Instructions;
                    }
                }
                if (mouseLocation.Intersects(optionsButton))
                {
                    if (ms.LeftButton == ButtonState.Pressed)
                    {
                        gamestate = GameState.Options;
                    }
                }
            }

            // Instructions
            if (gamestate == GameState.Instructions)
            {
                // all other code for this state goes here

                // handles button pressing for game state
                if (mouseLocation.Intersects(backButton))
                {
                    if (ms.LeftButton == ButtonState.Pressed)
                    {
                        gamestate = GameState.Menu;
                    }
                }
            }

            // Player Selection Screen
            if (gamestate == GameState.PlayerSelect)
            {
                // All other code for this state goes here

                // handles button pressing for game state
                if (mouseLocation.Intersects(backButton))
                {
                    if (ms.LeftButton == ButtonState.Pressed)
                    {
                        gamestate = GameState.Menu;
                    }
                }

                //if (buttonpressed) { gamestate = GameState.Game; }
            }

            // Actual Gameplay
            if (gamestate == GameState.Game)
            {
                // all other code for this state goes here


                //if (character health == 0) { gamestate = GameState.EndGame; }
            }

            // Options
            if (gamestate == GameState.Options)
            {
                // all other code for this state goes here

                // handles button pressing for game state
                if (mouseLocation.Intersects(backButton))
                {
                    if (ms.LeftButton == ButtonState.Pressed)
                    {
                        gamestate = GameState.Menu;
                    }
                }
            }

            // End Game, when someone wins
            if (gamestate == GameState.EndGame)
            {
                // all other code for this state goes here


                //if (buttonpressed) { gamestate = GameState.Menu; }
            }



            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkViolet);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            // sets stardard values for the window to help with drawing
            int windowWidth = GraphicsDevice.Viewport.Width;
            int windowHeight = GraphicsDevice.Viewport.Height;
            Point standardButtonSize = new Point(330, 60);

            // Menu
            if (gamestate == GameState.Menu)
            {
                // main menu screen
                spriteBatch.Draw(mainMenu, new Rectangle(new Point(0, 0), new Point(windowWidth, windowHeight)), Color.White);

                // fixes button locations (the rectangles)
                playButton = new Rectangle(new Point(windowWidth / 2 - standardButtonSize.X / 2, 432), standardButtonSize);
                instructionsButton = new Rectangle(new Point(windowWidth / 2 - standardButtonSize.X / 2, 530), standardButtonSize);
                optionsButton = new Rectangle(new Point(windowWidth / 2 - standardButtonSize.X / 2, 628), standardButtonSize);
            }

            // Instructions
            if (gamestate == GameState.Instructions)
            {
                //instructions menu screen
                spriteBatch.Draw(instructionsMenu, new Rectangle(new Point(0,0), new Point(windowWidth, windowHeight)), Color.White);

                //implement rectangle collison with the back button here
                
                //spriteBatch.Draw(yellowButton, backButton, Color.White);
                //spriteBatch.DrawString(text, "back", new Vector2(25, 25), Color.Black);
                //removed ^^ because back button is in a new spot
            }

            // Player Selection Screen
            if (gamestate == GameState.PlayerSelect)
            {
                spriteBatch.Draw(yellowButton, backButton, Color.White);
                spriteBatch.DrawString(text, "back", new Vector2(25, 25), Color.Black);
            }

            // Actual Gameplay
            if (gamestate == GameState.Game)
            {

            }

            // Options
            if (gamestate == GameState.Options)
            {
                spriteBatch.Draw(yellowButton, backButton, Color.White);
                spriteBatch.DrawString(text, "back", new Vector2(25, 25), Color.Black);
            }

            // End Game, when someone wins
            if (gamestate == GameState.EndGame)
            {

            }


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
