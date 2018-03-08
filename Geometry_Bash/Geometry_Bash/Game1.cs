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
        LevelSelect,
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
        Texture2D redSquareTexture;
        Texture2D redCircleTexture;
        Texture2D redDiamondTexture;
        Texture2D blueSquareTexture;
        Texture2D blueCircleTexture;
        Texture2D blueDiamondTexture;
        
        // button textures
        Texture2D yellowButton;
        Texture2D play;
        Texture2D back;
        Texture2D instructions;
        Texture2D options;

        // character select tiles
        Texture2D blueSquareTile;
        Texture2D blueCircleTile;
        Texture2D blueDiamondTile;
        Texture2D redSquareTile;
        Texture2D redCircleTile;
        Texture2D redDiamondTile;

        // screens
        Texture2D mainMenu;
        Texture2D instructionsMenu;
        Texture2D playerSelect;
        Texture2D optionsScreen;
        #endregion

        #region Button Rectangles
        // button rectangles
        Rectangle playButton;
        Rectangle instructionsButton;
        Rectangle optionsButton;
        Rectangle backButton;

        // tile rectangles
        Rectangle blueSquare;
        Rectangle blueCircle;
        Rectangle blueDiamond;
        Rectangle redSquare;
        Rectangle redCircle;
        Rectangle redDiamond;
        #endregion


        GameState gamestate = GameState.Menu;

        MouseState ms;
        MouseState previousMs;
        KeyboardState kbState;
        KeyboardState previousKbState;

        // used for player select tiles
        int redPlayerTileHighlight = 0;
        int bluePlayerTileHighlight = 0;

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
            redSquareTexture = Content.Load<Texture2D>("CharSprites//square");
            redCircleTexture = Content.Load<Texture2D>("CharSprites//circle");
            redDiamondTexture = Content.Load<Texture2D>("CharSprites//diamond");
            blueSquareTexture = Content.Load<Texture2D>("CharSprites//square_blue");
            blueCircleTexture = Content.Load<Texture2D>("CharSprites//circle_blue");
            blueDiamondTexture = Content.Load<Texture2D>("CharSprites//diamond_blue");

            // load button textures
            yellowButton = Content.Load<Texture2D>("Button Sprites//button_yellow");
            play = Content.Load<Texture2D>("Button Sprites//play_hover");
            back = Content.Load<Texture2D>("Button Sprites//instructionsBack_hover");
            instructions = Content.Load<Texture2D>("Button Sprites//instructions_hover");
            options = Content.Load<Texture2D>("Button Sprites//options_hover");

            // player select tiles
            blueSquareTile = Content.Load<Texture2D>("Button Sprites//bluesquare_hover");
            blueCircleTile = Content.Load<Texture2D>("Button Sprites//bluecircle_hover");
            blueDiamondTile = Content.Load<Texture2D>("Button Sprites//bluediamond_hover");
            redSquareTile = Content.Load<Texture2D>("Button Sprites//redsquare_hover");
            redCircleTile = Content.Load<Texture2D>("Button Sprites//redcircle_hover");
            redDiamondTile = Content.Load<Texture2D>("Button Sprites//reddiamond_hover");


            // screen loads
            mainMenu = Content.Load<Texture2D>("Screens//Main Menu");
            instructionsMenu = Content.Load<Texture2D>("Screens//Instructions");
            playerSelect = Content.Load<Texture2D>("Screens//Player Selection");
            optionsScreen = Content.Load<Texture2D>("Screens//Options_temp");

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

            // set current kb state
            kbState = Keyboard.GetState();
            ms = Mouse.GetState();

            // makes sure mouse is visible
            this.IsMouseVisible = true;
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
                    if (SingleLeftMousePress())
                    {
                        gamestate = GameState.Menu;
                    }
                }
            }

            // Player Selection Screen
            if (gamestate == GameState.PlayerSelect)
            {
                // All other code for this state goes here

                // handles player tile choice
                if (SingleKeyPress(Keys.D))
                {
                    redPlayerTileHighlight++;

                    if (redPlayerTileHighlight > 2)
                    { redPlayerTileHighlight = 0; }
                }
                if (SingleKeyPress(Keys.A))
                {
                    redPlayerTileHighlight--;

                    if (redPlayerTileHighlight < 0)
                    { redPlayerTileHighlight = 2; }
                }
                if (SingleKeyPress(Keys.L))
                {
                    bluePlayerTileHighlight++;

                    if (bluePlayerTileHighlight > 2)
                    { bluePlayerTileHighlight = 0; }
                }
                if (SingleKeyPress(Keys.J))
                {
                    bluePlayerTileHighlight--;

                    if (bluePlayerTileHighlight < 0)
                    { bluePlayerTileHighlight = 2; }
                }

                // handles button pressing for game state
                if (mouseLocation.Intersects(backButton))
                {
                    if (SingleLeftMousePress())
                    {
                        redPlayerTileHighlight = 0;
                        bluePlayerTileHighlight = 0;
                        gamestate = GameState.Menu;
                    }
                }
                if (SingleKeyPress(Keys.Enter))
                {
                    gamestate = GameState.LevelSelect;
                }
            }

            // Level Selection Screen
            if (gamestate == GameState.LevelSelect)
            {
                // All other code for this state goes here

                // handles button pressing for game state
                if (mouseLocation.Intersects(backButton))
                {
                    if (SingleLeftMousePress())
                    {
                        gamestate = GameState.PlayerSelect;
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
                    if (SingleLeftMousePress())
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

            // save old kb state in prev.kb
            previousKbState = kbState;
            previousMs = ms;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkViolet);
            
            // mouseState for hovering
            ms = Mouse.GetState();
            Rectangle mouseLocation = new Rectangle(ms.Position, new Point(5, 5));

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
                backButton = new Rectangle(new Point(33, 628), new Point(186, 60));

                // changes button color if mouse hovers over button
                if (mouseLocation.Intersects(playButton))
                { spriteBatch.Draw(play, playButton, Color.White); }
                if (mouseLocation.Intersects(instructionsButton))
                { spriteBatch.Draw(instructions, instructionsButton, Color.White); }
                if (mouseLocation.Intersects(optionsButton))
                { spriteBatch.Draw(options, optionsButton, Color.White); }
            }

            // Instructions
            if (gamestate == GameState.Instructions)
            {
                //instructions menu screen
                spriteBatch.Draw(instructionsMenu, new Rectangle(new Point(0,0), new Point(windowWidth, windowHeight)), Color.White);
                
                // changes back button if mouse hovers over
                if (mouseLocation.Intersects(backButton))
                { spriteBatch.Draw(back, backButton, Color.White); }
            }

            // Player Selection Screen
            if (gamestate == GameState.PlayerSelect)
            {
                // draws background first
                spriteBatch.Draw(playerSelect, new Rectangle(new Point(0, 0), new Point(windowWidth, windowHeight)), Color.White);

                // adds actual rectangles for player tiles
                blueSquare = new Rectangle(new Point(290, 484), new Point(251, 193));
                blueCircle = new Rectangle(new Point(640, 484), new Point(251, 193));
                blueDiamond = new Rectangle(new Point(990, 484), new Point(251, 193));
                redSquare = new Rectangle(new Point(290, 178), new Point(251, 193));
                redCircle = new Rectangle(new Point(640, 178), new Point(251, 193));
                redDiamond = new Rectangle(new Point(990, 178), new Point(251, 193));

                // player select tiles
                if (redPlayerTileHighlight == 0)
                { spriteBatch.Draw(redSquareTile, redSquare, Color.White); }
                else if (redPlayerTileHighlight == 1)
                { spriteBatch.Draw(redCircleTile, redCircle, Color.White); }
                else if (redPlayerTileHighlight == 2)
                { spriteBatch.Draw(redDiamondTile, redDiamond, Color.White); }
                if (bluePlayerTileHighlight == 0)
                { spriteBatch.Draw(blueSquareTile, blueSquare, Color.White); }
                else if (bluePlayerTileHighlight == 1)
                { spriteBatch.Draw(blueCircleTile, blueCircle, Color.White); }
                else if (bluePlayerTileHighlight == 2)
                { spriteBatch.Draw(blueDiamondTile, blueDiamond, Color.White); }

                // changes back button if mouse hovers over
                if (mouseLocation.Intersects(backButton))
                { spriteBatch.Draw(back, backButton, Color.White); }
            }

            // Level Selection Screen
            if (gamestate == GameState.LevelSelect)
            {
                spriteBatch.Draw(yellowButton, backButton, Color.White);

                // changes back button if mouse hovers over
                if (mouseLocation.Intersects(backButton))
                { spriteBatch.Draw(back, backButton, Color.White); }

                // ADD: transition to gameplay needed
            }

            // Actual Gameplay
            if (gamestate == GameState.Game)
            {
                // CHARACTER SPRITE STUFF HERE

                // HEALTH BAR

                // SUPER METER

                // PAUSE BUTTON
            }

            // Options
            if (gamestate == GameState.Options)
            {
                // options menu screen
                spriteBatch.Draw(optionsScreen, new Rectangle(new Point(0, 0), new Point(windowWidth, windowHeight)), Color.White);

                // changes back button if mouse hovers over
                if (mouseLocation.Intersects(backButton))
                { spriteBatch.Draw(back, backButton, Color.White); }
            }

            // End Game, when someone wins
            if (gamestate == GameState.EndGame)
            {

            }


            spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// checks if a key was pressed once (last frame != current)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool SingleKeyPress(Keys key)
        {
            if (kbState.IsKeyDown(key) && previousKbState.IsKeyUp(key))
            { return true; }
            else
            { return false; }
        }

        /// <summary>
        /// checks if the right mouse button was pressed once (last frame != current)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool SingleLeftMousePress()
        {
            if (ms.LeftButton == ButtonState.Pressed && previousMs.LeftButton == ButtonState.Released)
            { return true; }
            else
            { return false; }
        }
    }
}
