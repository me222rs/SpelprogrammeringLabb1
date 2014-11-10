#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Chess.Content.View;
using Chess.Content.Model;
#endregion

namespace Chess
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        BallView ballView;
        Texture2D pixel;
        
        //Ball ball = new Ball();
        BallSimulation ballSimulation = new BallSimulation();
        Texture2D backgroundTexture;
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //Hårdkodad storlek på skärmen, ändra här för att ändra storlek

            // Storlekar på boll och ram skalar om utan problem, men går man över 720*720 så kommer det inte bli lika snyggt pga. att bilden inte är så stor
            graphics.PreferredBackBufferWidth = 512;
            graphics.PreferredBackBufferHeight = 256;

            
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
            pixel = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White });

            backgroundTexture = Content.Load<Texture2D>("Shore.jpg");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ballView = new BallView(GraphicsDevice, Content);
           
            //var size = GraphicsDevice.Viewport.Bounds;

            //Camera camera = new Camera();
            //camera.Scale(512,512);
            //float scale = camera.getScale();


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            ballSimulation.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);

            // Create any rectangle you want. Here we'll use the TitleSafeArea for fun.
            Rectangle titleSafeRectangle = GraphicsDevice.Viewport.TitleSafeArea;


            int borderSize = GraphicsDevice.Viewport.Width / 10;
            //Ritar ut bakgrundsbild och en ram omkring den
            ballView.DrawLevel(backgroundTexture, titleSafeRectangle, borderSize, Color.Black, pixel);
            // TODO: Add your drawing code here
            ballView.DrawBall(ballSimulation);
            
    
            
            base.Draw(gameTime);
        }
    }
}
