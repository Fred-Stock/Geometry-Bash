﻿using Microsoft.Xna.Framework;
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

        // character textures
        Texture2D squareTexture;
        Texture2D circleTexture;
        Texture2D diamondTexture;

        GameState gamestate = GameState.Menu;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

            // load character textures
            squareTexture = Content.Load<Texture2D>("square");
            circleTexture = Content.Load<Texture2D>("circle");
            diamondTexture = Content.Load<Texture2D>("diamond");


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

            // Menu
            if (gamestate == GameState.Menu)
            {
                // all other code for this state goes here


                //if (buttonpressed) { gamestate = GameState.PlayerSelect; }
                //if (buttonpressed) { gamestate = GameState.Instructions; }
                //if (buttonpressed) { gamestate = GameState.Options; }
            }

            // Instructions
            if (gamestate == GameState.Instructions)
            {
                // all other code for this state goes here
                

                //if (buttonpressed) { gamestate = GameState.Menu; }
            }

            // Player Selection Screen
            if (gamestate == GameState.PlayerSelect)
            {
                // All other code for this state goes here


                //if (buttonpressed) { gamestate = GameState.Menu; }
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


                //if (buttonpressed) { gamestate = GameState.Menu; }
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
            GraphicsDevice.Clear(Color.Tomato);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            // Menu
            if (gamestate == GameState.Menu)
            {

            }

            // Instructions
            if (gamestate == GameState.Instructions)
            {

            }

            // Player Selection Screen
            if (gamestate == GameState.PlayerSelect)
            {

            }

            // Actual Gameplay
            if (gamestate == GameState.Game)
            {

            }

            // Options
            if (gamestate == GameState.Options)
            {

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
