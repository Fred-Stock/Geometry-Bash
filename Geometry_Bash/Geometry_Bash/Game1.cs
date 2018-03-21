using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System.Collections.Generic;
using System;

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

    //enums for chracter choice
    enum Character
    {
        Square,
        Circle,
        Diamond
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

        Texture2D readyBanner;

        // screens
        Texture2D mainMenu;
        Texture2D instructionsMenu;
        Texture2D playerSelect;
        Texture2D optionsScreen;
        Texture2D levelSelect;
        Texture2D gameScreen;
        Texture2D gameOver;
        #endregion

        #region Rectangles
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

        // level select tiles
        Rectangle level1hover;
        Rectangle level2hover;

        // ready banners
        Rectangle redReadyBanner;
        Rectangle blueReadyBanner;

        // base rectangles for actual game
        Rectangle p1rec;
        Rectangle p2rec;
        #endregion


        // level loading fields
        StreamReader reader = null;
        char[,] level1;

        //player objects
        Player player1;
        Player player2;

        //create character enum refrences for the two players
        Character p1Char;
        Character p2Char;
        GameState gamestate = GameState.Menu;

        // keyboard and mouse states for "one click"
        MouseState ms;
        MouseState previousMs;
        KeyboardState kbState;
        KeyboardState previousKbState;

        // used for player select tiles
        int redPlayerTileHighlight = 0;
        int bluePlayerTileHighlight = 0;
        bool redReady = false;
        bool blueReady = false;

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

            readyBanner = Content.Load<Texture2D>("ReadyBanner");

            // screen loads
            mainMenu = Content.Load<Texture2D>("Screens//Main Menu");
            instructionsMenu = Content.Load<Texture2D>("Screens//Instructions");
            playerSelect = Content.Load<Texture2D>("Screens//Player Selection");
            optionsScreen = Content.Load<Texture2D>("Screens//Options_temp");
            levelSelect = Content.Load<Texture2D>("Screens//Level_Selection");
            gameScreen = Content.Load<Texture2D>("Screens//LevelBackground");
            gameOver = Content.Load<Texture2D>("Screens//GameOver");

            // load level 1
            try
            {
                reader = new StreamReader("Level1.txt");
                string line= "";
                int rows1 = 0;
                int cols1 = 0;
                List<string> level1CompleteRows = null;
                int firstLineCheck = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    if (firstLineCheck == 0)
                    {
                        // get rows/cols
                        string[] rowscols = line.Split(',');
                        rows1 = int.Parse(rowscols[0]);
                        cols1 = int.Parse(rowscols[1]);
                        firstLineCheck++;
                    }

                    else
                    {
                        // puts all rows into list
                        level1CompleteRows.Add(line);
                    }
                }

                level1 = new char[rows1, cols1];
                
                for (int i = 0; i < rows1; i++)
                {
                    for (int j = 0; j < cols1; j++)
                    {
                        level1[i, j] = level1CompleteRows[j][i];
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
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

                #region Selection Process
                // red player's player select
                if (!redReady)
                {
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
                }
                if (SingleKeyPress(Keys.E))
                {
                    //when the player readys up save what their character selection was
                    if (redPlayerTileHighlight == 0)
                    {
                        p1Char = Character.Square;
                    }
                    else if (redPlayerTileHighlight == 1)
                    {
                        p1Char = Character.Circle;
                    }
                    else if (redPlayerTileHighlight == 2)
                    {
                        p1Char = Character.Diamond;
                    }
                    redReady = true;

                }
                if (SingleKeyPress(Keys.Q))
                {
                    redReady = false;
                }

                // blue player's player select
                if (!blueReady)
                {
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
                }
                if (SingleKeyPress(Keys.O))
                {
                    //when the player readys up save what their character selection was
                    if (bluePlayerTileHighlight == 0)
                    {
                        p2Char = Character.Square;
                    }
                    else if (bluePlayerTileHighlight == 1)
                    {
                        p2Char = Character.Circle;
                    }
                    else if(bluePlayerTileHighlight == 2)
                    {
                        p2Char = Character.Diamond;
                    }

                    blueReady = true;
                }
                if (SingleKeyPress(Keys.U))
                {
                    blueReady = false;

                }
                #endregion

                // handles button pressing for game state
                if (mouseLocation.Intersects(backButton))
                {
                    if (SingleLeftMousePress())
                    {
                        redPlayerTileHighlight = 0;
                        bluePlayerTileHighlight = 0;
                        redReady = false;
                        blueReady = false;
                        gamestate = GameState.Menu;
                    }
                }
                if (redReady && blueReady)
                {
                    if (SingleKeyPress(Keys.Enter))
                    {
                        redReady = false;
                        blueReady = false;
                        gamestate = GameState.LevelSelect;

                        #region Player Initialization
                        //create each player and make them the correct shape based off of their character enum
                        p1rec = new Rectangle(50, 50, 50, 50);
                        p2rec = new Rectangle(50, 550, 50, 50);
                        // player 1
                        if(p1Char == Character.Square)
                        {
                            player1 = new Square(1, p1rec, redSquareTexture, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
                        }
                        else if (p1Char == Character.Circle)
                        {
                            player1 = new Circle(1, p1rec, redCircleTexture, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
                        }
                        else if (p1Char == Character.Diamond)
                        {
                            player1 = new Diamond(1, p1rec, redDiamondTexture, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
                        }
                        // player 2
                        if (p2Char == Character.Square)
                        {
                            player2 = new Square(2, p2rec, blueSquareTexture, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
                        }                                                          
                        else if (p2Char == Character.Circle)                       
                        {                                                          
                            player2 = new Circle(2, p2rec, blueCircleTexture, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
                        }
                        else if (p2Char == Character.Diamond)
                        {
                            player2 = new Diamond(2, p2rec, blueDiamondTexture, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
                        }
                        #endregion
                    }
                }

                previousKbState = kbState;
            }

            // Level Selection Screen
            if (gamestate == GameState.LevelSelect)
            {
                // All other code for this state goes here

                // handles button pressing for game state
                // press enter to go to Game state
                if (SingleKeyPress(Keys.Enter))
                { gamestate = GameState.Game; }
                // press back button to go to player select
                if (mouseLocation.Intersects(backButton))
                {
                    if (SingleLeftMousePress())
                    { gamestate = GameState.PlayerSelect; }
                }

                // ADD: transition to gameplay needed
            }

            // Actual Gameplay
            if (gamestate == GameState.Game)
            {
                // all other code for this state goes here
                player1.Move(kbState);
                player2.Move(kbState);

                player1.OutsideCollision(player1);
                player2.OutsideCollision(player2);

                player1.Attack(player1, player2, kbState);
                player2.Attack(player2, player1, kbState);

                // makes sure mouse is invisible during game
                this.IsMouseVisible = false;
                
                // pauses game
                if (SingleKeyPress(Keys.P))
                { }

                // goes to gameover if a player dies
                if (player1.Health <= 0)
                {
                    gamestate = GameState.EndGame;
                }
                else if (player2.Health <= 0)
                {
                    gamestate = GameState.EndGame;
                }
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

                // handles button pressing for game state
                if (mouseLocation.Intersects(backButton))
                {
                    if (SingleLeftMousePress())
                    {
                        gamestate = GameState.Menu;
                    }
                }
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
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

            // sets stardard values for the window to help with drawing
            int windowWidth = GraphicsDevice.Viewport.Width;
            int windowHeight = GraphicsDevice.Viewport.Height;
            Point standardButtonSize = new Point(330, 60);

            // Menu
            if (gamestate == GameState.Menu)
            {
                // main menu screen
                spriteBatch.Draw(mainMenu, new Rectangle(new Point(0, 0), new Point(windowWidth, windowHeight)), Color.White);

                // button locations (the rectangles)
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

                // handles ready banner
                redReadyBanner = new Rectangle(new Point(315, 115), new Point(900, 320));
                blueReadyBanner = new Rectangle(new Point(315, 420), new Point(900, 320));
                if (redReady)
                { spriteBatch.Draw(readyBanner, redReadyBanner, Color.White); }
                if (blueReady)
                { spriteBatch.Draw(readyBanner, blueReadyBanner, Color.White); }

                // changes back button if mouse hovers over
                if (mouseLocation.Intersects(backButton))
                { spriteBatch.Draw(back, backButton, Color.White); }
            }

            // Level Selection Screen
            if (gamestate == GameState.LevelSelect)
            {
                // draws background first
                spriteBatch.Draw(levelSelect, new Rectangle(new Point(0, 0), new Point(windowWidth, windowHeight)), Color.White);

                // buttons for each level
                level1hover = new Rectangle(new Point(278, 262), new Point(251, 193));
                level2hover = new Rectangle(new Point(753, 262), new Point(251, 193));
                if (mouseLocation.Intersects(level1hover))
                { spriteBatch.Draw(yellowButton, level1hover, Color.White); }
                if (mouseLocation.Intersects(level2hover))
                { spriteBatch.Draw(yellowButton, level2hover, Color.White); }

                // changes back button if mouse hovers over
                if (mouseLocation.Intersects(backButton))
                { spriteBatch.Draw(back, backButton, Color.White); }
            }

            // Actual Gameplay
            if (gamestate == GameState.Game)
            {
                spriteBatch.Draw(gameScreen, new Rectangle(new Point(0, 0), new Point(windowWidth, windowHeight)), Color.White);

                float transparency1 = (float)player1.Health/10;
                float transparency2 = (float)player2.Health/10;
                spriteBatch.Draw(player1.Texture, player1.HitBox, Color.White * transparency1);
                spriteBatch.Draw(player2.Texture, player2.HitBox, Color.White * transparency2);

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
                // game over screen
                spriteBatch.Draw(gameOver, new Rectangle(new Point(0, 0), new Point(windowWidth, windowHeight)), Color.White);

                // changes back button if mouse hovers over
                if (mouseLocation.Intersects(backButton))
                { spriteBatch.Draw(back, backButton, Color.White); }
            }

            //Debug Drawing
            spriteBatch.DrawString(text, Mouse.GetState().X + "," + Mouse.GetState().Y, new Vector2(5,5), Color.Wheat);



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
