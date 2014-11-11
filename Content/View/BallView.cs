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
        GraphicsDeviceManager graphics;
        
        //Metod som läser in texturer som tillhör bollen
        public BallView(GraphicsDevice graphicsDevice, ContentManager content, int frame)
        {
            windowWidth = graphicsDevice.Viewport.Width;
            windowHeight = graphicsDevice.Viewport.Height;

            camera = new Camera(frame);
            camera.setDimensions(windowWidth, windowHeight);
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
            //int scale;
            //if (windowHeight > windowWidth)
            //{
            //    scale = windowWidth;
            //}
            //else
            //{
            //    scale = windowHeight;
            //}

            //camera.SetFrame(scale);
            
            spriteBatch.Draw(backgroundTexture,
                new Rectangle(0, 0,
                windowWidth, windowHeight), null,
                Color.White, 0, Vector2.Zero,
                SpriteEffects.None, 0);

            int frameY = 0;
            int frameX = 0;

            if(rectangleToDraw.Height > rectangleToDraw.Width){
                frameX = rectangleToDraw.Height - rectangleToDraw.Width;
            }
            if (rectangleToDraw.Width > rectangleToDraw.Height) {
                frameY = rectangleToDraw.Width - rectangleToDraw.Height;
            }


            //camera.setDimensions(rectangleToDraw.Width, rectangleToDraw.Height);

            //Hittade en tutorial för att rita ut en ram här: http://bluelinegamestudios.com/posts/drawing-a-hollow-rectangle-border-in-xna-4-0/
            
            // Rita översta linjen
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, thicknessOfBorder), borderColor);

            // Rita vänstra linjen
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), borderColor);

            // Rita högra linjen
            spriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder - frameY),
                                            rectangleToDraw.Y,
                                            thicknessOfBorder + frameY,
                                            rectangleToDraw.Height), borderColor);
            // Rita botten linjen
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X,
                                            rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder - frameX,
                                            rectangleToDraw.Width,
                                            thicknessOfBorder + frameX), borderColor);




            spriteBatch.End();
        }


        //Metod som ritar ut bollen
        internal void DrawBall(BallSimulation ballSimulation) {
            //int size = windowWidth / 10;

            Ball ball = new Ball();
            int vx = (int)(ballSimulation.getXPosition() * camera.getScale() + camera.GetFrame());
            int vy = (int)(ballSimulation.getYPosition() * camera.getScale() + camera.GetFrame());

            int size = (int)(ball.diameter * camera.getScale());
            Rectangle destrect = new Rectangle(vx - size/2, vy - size/2, size, size);
            
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
