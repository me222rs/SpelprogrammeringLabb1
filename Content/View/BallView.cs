using Chess.Content.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess.Content.View
{
    //Instans av kamera och ritar ut bollen
    class BallView
    {
       
        private SpriteBatch spriteBatch;
        private Texture2D ballTexture;

        private int windowHeight;
        private int windowWidth;

        //Metod som läser in texturer som tillhör bollen
        public BallView(GraphicsDevice graphicsDevice, ContentManager content)
        {
            windowWidth = graphicsDevice.Viewport.Width;
            windowHeight = graphicsDevice.Viewport.Height;
            spriteBatch = new SpriteBatch(graphicsDevice);
 
            ballTexture = content.Load<Texture2D>("Bitmap1");
 
        }


        //Metod som ritar ut bollen
        internal void DrawBall(BallSimulation ballSimulation) {

            int vx = (int)(ballSimulation.getXPosition() * windowWidth);
            int vy = (int)(ballSimulation.getYPosition() * windowHeight);
            Rectangle destrect = new Rectangle(vx-0, vy-0, 30, 30);
            
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
