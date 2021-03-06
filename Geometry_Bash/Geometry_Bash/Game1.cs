﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System.Collections.Generic;
using System;
using System.Media;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

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
        Pause,
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
        GameTime gameTime;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont text;


        //rectangle list to hold where walls are
        List<Rectangle> wallsList;

        //collectible list to hold what collectibles are on the stage
        List<Collectable> collectables;

        //timer int
        int timer;
        #region Textures
        //Character Textures
        Texture2D redSquareTexture;
        Texture2D redCircleTexture;
        Texture2D redDiamondTexture;
        Texture2D blueSquareTexture;
        Texture2D blueCircleTexture;
        Texture2D blueDiamondTexture;

        //character special textures
        Texture2D redCircleAttackTexture;
        Texture2D blueCircleAttackTexture;
        Texture2D redCircleAttackTexture_15;
        Texture2D redCircleAttackTexture_30;
        Texture2D blueCircleAttackTexture_15;
        Texture2D blueCircleAttackTexture_30;
        Texture2D redDiamondParticles;
        Texture2D blueDiamondParticles;
        Texture2D redDiamondParticles_45;
        Texture2D blueDiamondParticles_45;
        Texture2D collectible;
        
        // button textures
        Texture2D yellowButton;
        Texture2D play;
        Texture2D back;
        Texture2D instructions;
        Texture2D options;
        Texture2D player1_wins;
        Texture2D player2_wins;

        // character select tiles
        Texture2D blueSquareTile;
        Texture2D blueCircleTile;
        Texture2D blueDiamondTile;
        Texture2D redSquareTile;
        Texture2D redCircleTile;
        Texture2D redDiamondTile;
        Texture2D levelTile;
        Texture2D readyBanner;

        // screens
        Texture2D mainMenu;
        Texture2D instructionsMenu;
        Texture2D playerSelect;
        Texture2D optionsScreen;
        Texture2D levelSelect;
        Texture2D gameScreen;
        Texture2D gameOver;
        Texture2D pauseMenu;

        Texture2D wall;
        Texture2D collectable;
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

        #region Level Loading Fields
        StreamReader reader = null;
        char[,] level1;
        char[,] level2;
        string line = "";
        int rows1 = 0;
        int cols1 = 0;
        int rows2 = 0;
        int cols2 = 0;
        List<string> level1CompleteRows = new List<string>();
        List<string> level2CompleteRows = new List<string>();
        int levelChoice = 0;
        #endregion

        #region options/stats fields
        StreamWriter writer = null;
        OptionsMenu optionsform = new OptionsMenu();
        int[] stats = new int[9];
        int[] squareStats = new int[3];
        int[] circleStats = new int[3];
        int[] diamondStats = new int[3];
        #endregion


        //random variable to control random events\
        Random rng;

        //player objects
        Player player1;
        Player player2;

        //create retangles to store the players previous position
        Rectangle prevPos1;
        Rectangle prevPos2;

        // rectangles for hitbox
        Rectangle p1leftX;
        Rectangle p1rightX;
        Rectangle p1topY;
        Rectangle p1bottomY;
        Rectangle p2leftX;
        Rectangle p2rightX;
        Rectangle p2topY;
        Rectangle p2bottomY;

        //create character enum refrences for the two players
        Character p1Char;
        Character p2Char;
        GameState gamestate = GameState.Menu;

        // keyboard, gamepad, and mouse states for "one click"
        MouseState ms;
        MouseState previousMs;
        KeyboardState kbState;
        KeyboardState previousKbState;
        GamePadState gpState;

        // used for player select tiles
        int redPlayerTileHighlight = 0;
        int bluePlayerTileHighlight = 0;
        bool redReady = false;
        bool blueReady = false;

        //Used for keeping track of passing frames
        private FrameCounter _frameCounter = new FrameCounter();

        //int to count each frame one for both players
        int count1;
        int count2;

        //music
        int playNum = 0;
        int playNum2 = 0;
        int playNum3 = 0;
        private Song menuMusic;
        private Song gameMusic;
        private Song endMusic;

        //UI
        private Texture2D healthBar;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1280;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 720;   // set this value to the desired height of your window
            graphics.ApplyChanges();
            gameTime = new GameTime();
            timer = 0;
            rng = new Random();
            collectables = new List<Collectable>();
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

            #region Level Loading
            // load level 1
            try
            {
                reader = new StreamReader(File.OpenRead("Level1.txt"));
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
            catch (Exception ex)
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

            // load level 2
            try
            {
                reader = new StreamReader(File.OpenRead("Level2.txt"));
                int firstLineCheck = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    if (firstLineCheck == 0)
                    {
                        // get rows/cols
                        string[] rowscols = line.Split(',');
                        rows2 = int.Parse(rowscols[0]);
                        cols2 = int.Parse(rowscols[1]);
                        firstLineCheck++;
                    }

                    else
                    {
                        // puts all rows into list
                        level2CompleteRows.Add(line);
                    }
                }

                level2 = new char[rows2, cols2];

                for (int i = 0; i < rows2; i++)
                {
                    for (int j = 0; j < cols2; j++)
                    {
                        level2[i, j] = level2CompleteRows[j][i];
                    }
                }
            }
            catch (Exception ex)
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
            #endregion

            // set default stat values
            
            try
            {
                writer = new StreamWriter("../../../../stats.txt");
                string output = 10 + "," + 10 + "," + 10 + "," + 3 + "," + 3 + "," + 4 + "," + 5 + "," + 5 + "," + 5;
                writer.Write(output);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                
                //writer.Close();
                
            }
            writer.Close();

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
            redSquareTexture = Content.Load<Texture2D>("CharSprites//sqaure");
            redCircleTexture = Content.Load<Texture2D>("CharSprites//circle");
            redDiamondTexture = Content.Load<Texture2D>("CharSprites//diamond");
            blueSquareTexture = Content.Load<Texture2D>("CharSprites//sqaure_blue");
            blueCircleTexture = Content.Load<Texture2D>("CharSprites//circle_blue");
            blueDiamondTexture = Content.Load<Texture2D>("CharSprites//diamond_blue");

            //load character special textures
            redCircleAttackTexture = Content.Load<Texture2D>("CharSprites//circle_ult");
            blueCircleAttackTexture = Content.Load<Texture2D>("CharSprites//circle_blue_ult");
            redCircleAttackTexture_15 = Content.Load<Texture2D>("CharSprites//circle_ult_15");
            redCircleAttackTexture_30 = Content.Load<Texture2D>("CharSprites//circle_ult_30");
            blueCircleAttackTexture_15 = Content.Load<Texture2D>("CharSprites//circle_blue_ult_15");
            blueCircleAttackTexture_30 = Content.Load<Texture2D>("CharSprites//circle_blue_ult_30");
            redDiamondParticles = Content.Load<Texture2D>("CharSprites//diamond_red_shards");
            blueDiamondParticles = Content.Load<Texture2D>("CharSprites//diamond_blue_shards");
            redDiamondParticles_45 = Content.Load<Texture2D>("CharSprites//diamond_red_shard_45");
            blueDiamondParticles_45 = Content.Load<Texture2D>("CharSprites//diamond_blue_shard_45");
            collectible = Content.Load<Texture2D>("CharSprites//collectable");

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
            levelTile = Content.Load<Texture2D>("Button Sprites//levelSelectHover");
            readyBanner = Content.Load<Texture2D>("ReadyBanner");
            player1_wins = Content.Load<Texture2D>("Screens//player1_wins");
            player2_wins = Content.Load<Texture2D>("Screens//player2_wins");

            // screen loads
            mainMenu = Content.Load<Texture2D>("Screens//Main Menu");
            instructionsMenu = Content.Load<Texture2D>("Screens//Instructions");
            playerSelect = Content.Load<Texture2D>("Screens//Player Selection");
            optionsScreen = Content.Load<Texture2D>("Screens//Options_temp");
            levelSelect = Content.Load<Texture2D>("Screens//Level_Selection");
            gameScreen = Content.Load<Texture2D>("Screens//LevelBackground");
            gameOver = Content.Load<Texture2D>("Screens//GameOver");
            pauseMenu = Content.Load<Texture2D>("Screens//Pause Menu_p");

            // walls
            wall = Content.Load<Texture2D>("TopBarrier");

            //collectable
            collectable = Content.Load<Texture2D>("CharSprites//collectable");

            //music and sounds
            menuMusic = Content.Load<Song>("Sounds//menuTheme");
            gameMusic = Content.Load<Song>("Sounds//gameTheme");
            endMusic = Content.Load<Song>("Sounds//endScreen");

            //UI
            healthBar = Content.Load<Texture2D>("whiteRect");
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

            //music
            if (gamestate == GameState.Menu || gamestate == GameState.Instructions || gamestate == GameState.PlayerSelect || gamestate == GameState.LevelSelect)
            {
                if(playNum == 0)
                {
                    MediaPlayer.Stop();
                    playNum++;
                    MediaPlayer.Play(menuMusic);
                }
            }
            else if(gamestate == GameState.EndGame)
            {
                
                if(playNum3 == 0)
                {
                    MediaPlayer.Stop();
                    playNum3++;
                    MediaPlayer.Play(endMusic);
                }
                
                
            }
            else
            {
                if(playNum2 == 0)
                {
                    playNum2++;
                    MediaPlayer.Stop();
                    MediaPlayer.Play(gameMusic);
                }
                
            }


            // Menu
            if (gamestate == GameState.Menu)
            {
                // all other code for this state goes here
                playNum3 = 0;

                // handles button pressing for game state
                if (mouseLocation.Intersects(playButton))
                {
                    if (ms.LeftButton == ButtonState.Pressed)
                    {
                        bluePlayerTileHighlight = 0;
                        redPlayerTileHighlight = 0;

                        // load stats
                        try
                        {
                            reader = new StreamReader("../../../../stats.txt");

                            while ((line = reader.ReadLine()) != null)
                            {
                                string[] stringStats = line.Split(',');

                                for (int i = 0; i < stringStats.Length; i++)
                                {
                                    stats[i] = int.Parse(stringStats[i]);
                                }
                            }

                            // square
                            squareStats[0] = stats[0];
                            squareStats[1] = stats[3];
                            squareStats[2] = stats[6];
                            // circle
                            circleStats[0] = stats[1];
                            circleStats[1] = stats[4];
                            circleStats[2] = stats[7];
                            // diamond
                            diamondStats[0] = stats[2];
                            diamondStats[1] = stats[5];
                            diamondStats[2] = stats[8];
                        }
                        catch (Exception ex)
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
                        optionsform.ShowDialog();
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
                        p1rec = new Rectangle(9*40, 8*40, 50, 50);
                        p2rec = new Rectangle(22*40, 8*40, 50, 50);
                        // player 1
                        if(p1Char == Character.Square)
                        {
                            player1 = new Square(1, p1rec, redSquareTexture, GraphicsDevice.Viewport.Width - 2, GraphicsDevice.Viewport.Height - 2, squareStats);
                           
                        }
                        else if (p1Char == Character.Circle)
                        {
                            player1 = new Circle(1, p1rec, redCircleTexture, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, circleStats);
                        }
                        else if (p1Char == Character.Diamond)
                        {
                            player1 = new Diamond(1, p1rec, redDiamondTexture, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, diamondStats);
                        }
                        // player 2
                        if (p2Char == Character.Square)
                        {
                            player2 = new Square(2, p2rec, blueSquareTexture, GraphicsDevice.Viewport.Width - 2, GraphicsDevice.Viewport.Height - 2, squareStats);
                        }                                                          
                        else if (p2Char == Character.Circle)                       
                        {                                                          
                            player2 = new Circle(2, p2rec, blueCircleTexture, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, circleStats);
                        }
                        else if (p2Char == Character.Diamond)
                        {
                            player2 = new Diamond(2, p2rec, blueDiamondTexture, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, diamondStats);
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
                // press back button to go to player select
                if (mouseLocation.Intersects(backButton))
                {
                    if (SingleLeftMousePress())
                    {
                        bluePlayerTileHighlight = 0;
                        redPlayerTileHighlight = 0;
                        gamestate = GameState.PlayerSelect;
                    }
                }
                // click your level choice and goes to game with that level
                if (mouseLocation.Intersects(level1hover))
                {
                    if (SingleLeftMousePress())
                    {
                        levelChoice = 1;
                        gamestate = GameState.Game;
                    }
                }
                if (mouseLocation.Intersects(level2hover))
                {
                    if (SingleLeftMousePress())
                    {
                        levelChoice = 2;
                        gamestate = GameState.Game;
                    }
                }

                // ADD: transition to gameplay needed
            }

            // Actual Gameplay
            if (gamestate == GameState.Game)
            {
                // makes sure mouse is invisible during game
                this.IsMouseVisible = false;

                wallsList = new List<Rectangle>();
                for(int i = 0; i < level2.GetLength(1); i++)
                {
                    for (int k = 0; k < level2.GetLength(0); k++)
                    {
                        if (level1[k, i] == 'x')
                        {
                            wallsList.Add(new Rectangle(new Point(40 * k, 40 * i), new Point(40, 40)));
                        }
                    }
                }

                #region Player Methods
                // player movement
                player1.Move(kbState, gpState);
                player2.Move(kbState, gpState);
                
                // collision with edge of screen
                player1.OutsideCollision(player1);
                player2.OutsideCollision(player2);

                // attacking
                player1.Attack(player1, player2, kbState, gpState, 1, gameTime.ElapsedGameTime.TotalSeconds);
                player2.Attack(player2, player1, kbState, gpState, 2, gameTime.ElapsedGameTime.TotalSeconds);

                // nothing yet
                player1.Step(player1, player2, kbState, gameTime.ElapsedGameTime.TotalSeconds);
                player2.Step(player2, player1, kbState, gameTime.ElapsedGameTime.TotalSeconds);
                #endregion

                //collectibles
                if(timer >= rng.Next(300, 600) && collectables.Count == 0)
                {
                       collectables.Add(new Collectable(BoostType.health, collectable,
                           new Rectangle(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2, 20, 20)));
                    timer = 0;
                }
                for (int i = 0; i < collectables.Count; i++)
                {
                    if (collectables[i].PickedUp(player1))
                    {
                        collectables.RemoveAt(i);
                        i--;
                    }
                    else if (collectables[i].PickedUp(player2))
                    { 
                        collectables.RemoveAt(i);
                        i--;
                    }
                }
                timer++;
                #region Diamond Projectiles

                
                if (player1 is Diamond)
                {
                    ProjMove(player1.ProjList);
                }
                if (player2 is Diamond)
                {                  
                    ProjMove(player2.ProjList);
                }
                #endregion

                // makes sure mouse is invisible during game
                this.IsMouseVisible = false;
                
                // pauses game
                if (SingleKeyPress(Keys.Space))
                {
                    gamestate = GameState.Pause;
                }

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

            // Paused
            if (gamestate == GameState.Pause)
            {
                // unpauses game
                if (SingleKeyPress(Keys.P))
                {
                    gamestate = GameState.Game;
                }
            }

            // End Game, when someone wins
            if (gamestate == GameState.EndGame)
            {
                // all other code for this state goes here

                //ints for music playing
                playNum = 0;
                playNum2 = 0;

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

        //helper method for projectiles
        private void ProjMove(List<Projectile> projList)
        {
            if (projList.Count != 0)
            {

                for (int i = 0; i < projList.Count; i++)
                {
                    Rectangle temp = projList[i].HitBox;
                    if (projList[i].Direction == 0)
                    {
                        temp.X += projList[i].Speed;
                    }
                    else if (projList[i].Direction == 1)
                    {
                        temp.Y += projList[i].Speed;
                    }
                    else if (projList[i].Direction == 2)
                    {
                        temp.X -= projList[i].Speed;
                    }
                    else if (projList[i].Direction == 3)
                    {
                        temp.Y -= projList[i].Speed;
                    }
                    projList[i].HitBox = temp;
                }
                
            }
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
                level1hover = new Rectangle(new Point(162, 266), new Point(320, 180));
                level2hover = new Rectangle(new Point(800, 266), new Point(320, 180));
                if (mouseLocation.Intersects(level1hover))
                { spriteBatch.Draw(levelTile, level1hover, Color.White); }
                if (mouseLocation.Intersects(level2hover))
                { spriteBatch.Draw(levelTile, level2hover, Color.White); }

                // changes back button if mouse hovers over
                if (mouseLocation.Intersects(backButton))
                { spriteBatch.Draw(back, backButton, Color.White); }

                #region Level Drawing
                LevelDrawWall(level1, 162, 266);
                LevelDrawWall(level2, 800, 266);
                
                #endregion
            }

            // Actual Gameplay
            if (gamestate == GameState.Game)
            {

                // background
                spriteBatch.Draw(gameScreen, new Rectangle(new Point(0, 0), new Point(windowWidth, windowHeight)), Color.White);

                #region Wall Drawing
                // Draws the right level choice
                // walls if level 1
                if (levelChoice == 1)
                {
                    GameDrawWall(level1);
                }
                // walls if level 2
                else if (levelChoice == 2)
                {
                    GameDrawWall(level2);
                    
                }

                #endregion

                //draw collectibles
                for(int i = 0; i < collectables.Count; i++)
                {
                    spriteBatch.Draw(collectables[i].Texture, collectables[i].SAP, collectables[i].Color);
                }

                // Draw Players
                float transparency1 = (float)player1.Health / 10;
                float transparency2 = (float)player2.Health / 10;

                Vector2 player1Origin = new Vector2(player1.Texture.Width / 2f, player1.Texture.Height / 2f);
                Rectangle player1SourceRectangle = new Rectangle(0, 0, player1.Texture.Width, player1.Texture.Height);
                Vector2 player2Origin = new Vector2(player2.Texture.Width / 2f, player2.Texture.Height / 2f);
                Rectangle player2SourceRectangle = new Rectangle(0, 0, player2.Texture.Width, player2.Texture.Height);

                //commented out because it messes up player1 hitbox so it does line up with the sprite 
                //spriteBatch.Draw(player1.Texture, player1.HitBox, player1SourceRectangle, Color.White * transparency1, player1.Rotation, player1Origin, SpriteEffects.None, 1);
                spriteBatch.Draw(player1.Texture, player1.HitBox, Color.White);
                spriteBatch.Draw(player2.Texture, player2.HitBox, Color.White);


                // float transparency1 = (float)player1.Health / 10;
                // float transparency2 = (float)player2.Health / 10;
                // spriteBatch.Draw(player1.Texture, player1.HitBox, Color.White * transparency1);
                // spriteBatch.Draw(player2.Texture, player2.HitBox, Color.White * transparency2);

                #region swap sprites for circle attack
                //set gamepade to first players controller
                gpState = GamePad.GetState(PlayerIndex.One);
                if (player1 is Circle && (kbState.IsKeyDown(Keys.Q) || gpState.IsButtonDown(Buttons.X)))
                {
                    if(count1 % 12 == 0)
                    {
                        player1.Texture = redCircleAttackTexture;
                    }
                    else if(count1 % 12 == 4)
                    {
                        player1.Texture = redCircleAttackTexture_15;
                    }
                    else if(count1 % 12 == 8)
                    {
                        player1.Texture = redCircleAttackTexture_30;
                    }
                    count1++;
                }
                else if (player1 is Circle && (kbState.IsKeyUp(Keys.Q) || gpState.IsButtonUp(Buttons.X)))
                {
                    player1.Texture = redCircleTexture;
                }
                //set gpstate to the second players controller
                gpState = GamePad.GetState(PlayerIndex.Two);
                if (player2 is Circle && (kbState.IsKeyDown(Keys.U) || gpState.IsButtonDown(Buttons.X)))
                {
                    if (count2 % 12 == 0)
                    {
                        player2.Texture = blueCircleAttackTexture;
                    }
                    else if (count2 % 12 == 4)
                    { 
                        player2.Texture = blueCircleAttackTexture_15;
                    }
                    else if (count1 % 12 == 8)
                    {
                        player2.Texture = blueCircleAttackTexture_30;
                    }
                    count2++;
                }
                else if (player2 is Circle && (kbState.IsKeyUp(Keys.U) || gpState.IsButtonUp(Buttons.X)))
                {
                    player2.Texture = blueCircleTexture;
                }
                #endregion

                #region diamond attack sprites
                if (player1 is Diamond)
                {
                    for (int i = 0; i < player1.ProjList.Count; i++)
                    {
                       
                       spriteBatch.Draw(redDiamondParticles, player1.ProjList[i].HitBox, Color.White);

                    }

                }
                if (player2 is Diamond)
                {
                    for (int i = 0; i < player2.ProjList.Count; i++)
                    {

                        spriteBatch.Draw(blueDiamondParticles, player2.ProjList[i].HitBox, Color.White);

                    }

                }
                //if (player2 is Diamond && player2.Proj2.Active)
                //{
                //    spriteBatch.Draw(blueDiamondParticles, player2.Proj1.HitBox, Color.White);
                //}
                #endregion

                prevPos1 = player1.HitBox;
                prevPos2 = player2.HitBox;
                // Health Bar
                

                

                Color healthBarColor = new Color(0, 1.0f, 0);
                spriteBatch.Draw(healthBar, new Rectangle(player1.HitBox.X, player1.HitBox.Y - 5, (int)player1.Health * 5, 10),Color.Green);
                spriteBatch.Draw(healthBar,new Rectangle(player2.HitBox.X,player2.HitBox.Y-5, (int)player2.Health * 5,10),Color.Green);

                // PAUSE BUTTON
            }

            // Paused
            if (gamestate == GameState.Pause)
            {
                #region Wall Drawing
                // Draws the right level choice
                // walls if level 1
                
                if (levelChoice == 1)
                {
                    PauseDrawWall(level1);
                    
                }
                // walls if level 2
                else if (levelChoice == 2)
                {
                    PauseDrawWall(level2);
                   
                }
                #endregion

                // Draw Players
                float transparency1 = (float)player1.Health / 10;
                float transparency2 = (float)player2.Health / 10;
                Vector2 player1Origin = new Vector2(player1.Texture.Width / 2f, player1.Texture.Height / 2f);
                Rectangle player1SourceRectangle = new Rectangle(0, 0, player1.Texture.Width, player1.Texture.Height);
                Vector2 player2Origin = new Vector2(player2.Texture.Width / 2f, player2.Texture.Height / 2f);
                Rectangle player2SourceRectangle = new Rectangle(0, 0, player2.Texture.Width, player2.Texture.Height);
                spriteBatch.Draw(player1.Texture, player1.HitBox, player1SourceRectangle, Color.White * transparency1, player1.Rotation, player1Origin, SpriteEffects.None, 1);
                spriteBatch.Draw(player2.Texture, player2.HitBox, Color.White * transparency2);

                // foreground
                spriteBatch.Draw(pauseMenu, new Rectangle(new Point(0, 0), new Point(windowWidth, windowHeight)), Color.White);
            }

            // End Game, when someone wins
            if (gamestate == GameState.EndGame)
            {
                // game over screen
                spriteBatch.Draw(gameOver, new Rectangle(new Point(0, 0), new Point(windowWidth, windowHeight)), Color.White);

                if(player1.Health<= 0)
                {
                    spriteBatch.Draw(player2_wins, new Vector2(windowWidth/2 - 750/2, 300), Color.White);
                }
                else
                {
                    spriteBatch.Draw(player1_wins, new Vector2(windowWidth/2 - 750/2, 300), Color.White);
                }
                // changes back button if mouse hovers over
                if (mouseLocation.Intersects(backButton))
                { spriteBatch.Draw(back, backButton, Color.White); }
            }

            
            #region Debug Drawing

            //Drawing mouse coordinates
            //spriteBatch.DrawString(text, Mouse.GetState().X + "," + Mouse.GetState().Y, new Vector2(5,5), Color.Wheat);
            //
            ////drawing fps
            //var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            //_frameCounter.Update(deltaTime);
            //var fps = string.Format("FPS: {0}", _frameCounter.AverageFramesPerSecond);
            //spriteBatch.DrawString(text, fps, new Vector2(5, 20), Color.Wheat);
            //
            ////drawing movelocked
            //if (gamestate == GameState.Game) { 
            //spriteBatch.DrawString(text, "Player 1 Movelocked: "  + player1.MoveLocked, new Vector2(5, 30), Color.Wheat);
            //spriteBatch.DrawString(text, "Player 2 Movelocked: "  + player2.MoveLocked, new Vector2(5, 40), Color.Wheat);
            //}


            #endregion
            
            spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// method to draw levels during level select
        /// </summary>
        /// <param name="levelMatrix">level to draw</param>
        /// <param name="offsetX">offset in the x direction</param>
        /// <param name="offsetY">offset in the y direction</param>
        public void LevelDrawWall(char[,] levelMatrix, int offsetX, int offsetY)
        {
            for (int i = 0; i < levelMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < levelMatrix.GetLength(1); j++)
                {
                    if (levelMatrix[i, j] == 'x')
                    {
                        spriteBatch.Draw(wall, new Rectangle(new Point(offsetX + 10 * i, offsetY + 10 * j), new Point(10, 10)), Color.Black);
                    }
                }
            }
        }

        public void PauseDrawWall(Char[,] levelMatrix)
        {
            for (int i = 0; i < levelMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < levelMatrix.GetLength(1); j++)
                {
                    if (levelMatrix[i, j] == 'x')
                    {
                        spriteBatch.Draw(wall, new Rectangle(new Point(40 * i, 40 * j), new Point(40, 40)), Color.Black);
                    }
                }
            }
        }

        //helper method to draw levels and do wall collision during game
        public void GameDrawWall(char[,] levelMatrix)
        {
            for (int i = 0; i < levelMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < levelMatrix.GetLength(1); j++)
                {
                    if (levelMatrix[i, j] == 'x')
                    {
                        spriteBatch.Draw(wall, new Rectangle(new Point(40 * i, 40 * j), new Point(40, 40)), Color.White);
                        Rectangle wallRect = new Rectangle(new Point(40 * i, 40 * j), new Point(40, 40));
                        p1leftX = new Rectangle(new Point(player1.HitBox.X - 1, player1.HitBox.Y), new Point(1, player1.HitBox.Height));
                        p1rightX = new Rectangle(new Point(player1.HitBox.X + player1.HitBox.Width, player1.HitBox.Y), new Point(1, player1.HitBox.Height));
                        p1topY = new Rectangle(new Point(player1.HitBox.X, player1.HitBox.Y - 1), new Point(player1.HitBox.Width, 1));
                        p1bottomY = new Rectangle(new Point(player1.HitBox.X, player1.HitBox.Y + player1.HitBox.Height), new Point(player1.HitBox.Width, 1));
                        p2leftX = new Rectangle(new Point(player2.HitBox.X - 1, player2.HitBox.Y), new Point(1, player2.HitBox.Height));
                        p2rightX = new Rectangle(new Point(player2.HitBox.X + player2.HitBox.Width, player2.HitBox.Y), new Point(1, player2.HitBox.Height));
                        p2topY = new Rectangle(new Point(player2.HitBox.X, player2.HitBox.Y - 1), new Point(player2.HitBox.Width, 1));
                        p2bottomY = new Rectangle(new Point(player2.HitBox.X, player2.HitBox.Y + player2.HitBox.Height), new Point(player2.HitBox.Width, 1));

                        // X Check
                        if (p1leftX.Intersects(wallRect) || p1rightX.Intersects(wallRect))
                        {
                            Rectangle temp = player1.HitBox;
                            temp.X = prevPos1.X;
                            player1.HitBox = temp;
                        }
                        if (p2leftX.Intersects(wallRect) || p2rightX.Intersects(wallRect))
                        {
                            Rectangle temp = player2.HitBox;
                            temp.X = prevPos2.X;
                            player2.HitBox = temp;
                        }

                        // Y check
                        if (p1topY.Intersects(wallRect) || p1bottomY.Intersects(wallRect))
                        {
                            Rectangle temp = player1.HitBox;
                            temp.Y = prevPos1.Y;
                            player1.HitBox = temp;
                        }
                        if (p2topY.Intersects(wallRect) || p2bottomY.Intersects(wallRect))
                        {
                            Rectangle temp = player2.HitBox;
                            temp.Y = prevPos2.Y;
                            player2.HitBox = temp;
                        }


                        #region Diamond Projectile Collision
                        if (player1 is Diamond)
                        {
                            for (int k = 0; k < player1.ProjList.Count; k++)
                            {

                                if (player1 is Diamond && player1.ProjList[k].HitBox.Intersects(new Rectangle(new Point(40 * i, 40 * j), new Point(40, 40))))
                                {
                                    player1.ProjList.RemoveAt(k);
                                    k--;
                                }

                            }
                        }
                        if (player2 is Diamond)
                        {
                            for (int o = 0; o < player2.ProjList.Count; o++)
                            {
                                if (player2 is Diamond && player2.ProjList[o].HitBox.Intersects(new Rectangle(new Point(40 * i, 40 * j), new Point(40, 40))))
                                {
                                    player2.ProjList.RemoveAt(o);
                                    o--;
                                }
                            }
                        }
                        #endregion
                    }
                }
            }
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
