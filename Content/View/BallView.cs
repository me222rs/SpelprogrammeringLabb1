using Chess.Content.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess.Content.View
{
    //Instans av kamera och ritar ut bollen
    class BallView : Game
    {
       
        private SpriteBatch spriteBatch;
        private Texture2D ballTexture;
        private int frameOffset = 50;
        private int windowHeight;
        private int windowWidth;
        private Camera camera;

        //Metod som läser in texturer som tillhör bollen
        public BallView(GraphicsDevice graphicsDevice, ContentManager content)
        {
            windowWidth = graphicsDevice.Viewport.Width;
            windowHeight = graphicsDevice.Viewport.Height;

            camera = new Camera(windowWidth, windowHeight);
            spriteBatch = new SpriteBatch(graphicsDevice);
 
            ballTexture = content.Load<Texture2D>("Ball");
 
        }
        //Metod som ritar ut banan
        internal void DrawLevel(Texture2D backgroundTexture, Rectangle rectangleToDraw, int thicknessOfBorder, Color borderColor, Texture2D pixel) {
           
            //var screenCenter = new Vector2(windowWidth / 2, windowHeight / 2);
            //var textureCenter = new Vector2(
            //    backgroundTexture.Width / 2,
            //    backgroundTexture.Height / 2);

            spriteBatch.Begin();
            // Ritar ut bakgrundsbilden
            spriteBatch.Draw(backgroundTexture,
                new Rectangle(0, 0,
                windowWidth, windowHeight), null,
                Color.White, 0, Vector2.Zero,
                SpriteEffects.None, 0);

            //Hittade en tutorial för att rita ut en ram här: http://bluelinegamestudios.com/posts/drawing-a-hollow-rectangle-border-in-xna-4-0/
            
            // Rita översta linjen
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, thicknessOfBorder), borderColor);

            // Rita vänstra linjen
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), borderColor);

            // Rita högra linjen
            spriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder),
                                            rectangleToDraw.Y,
                                            thicknessOfBorder,
                                            rectangleToDraw.Height), borderColor);
            // Rita botten linjen
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X,
                                            rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder,
                                            rectangleToDraw.Width,
                                            thicknessOfBorder), borderColor);




            spriteBatch.End();
        }


        //Metod som ritar ut bollen
        internal void DrawBall(BallSimulation ballSimulation) {
            int size = windowWidth / 10;
            int vx = (int)(ballSimulation.getXPosition() * windowWidth);
            int vy = (int)(ballSimulation.getYPosition() * windowHeight);
            Rectangle destrect = new Rectangle(vx - size, vy - size, size * 2, size * 2);
            
            spriteBatch.Begin();
            spriteBatch.Draw(ballTexture, destrect, Color.White);
            spriteBatch.End();

            //layer1.borderLeft = 0;
            //layer1.borderRight = 640;
            //layer1.borderTop = 0;
            //layer1.borderBottom = 640;
        }
    }
}
