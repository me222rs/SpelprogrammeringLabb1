using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess.Content.Model
{
    //Ska innehålla förflyttning och kollision
    class BallSimulation
    {
        //public void Update(float timeElapsedInSeconds) {
        //    Ball ball = new Ball();
        //    //CheckIfCollision();

        //}

        Ball ball = new Ball();

        
        internal void Update(GameTime gameTime)
        {
            
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            ball.x += elapsedTime * ball.speedX;
            ball.y += elapsedTime * ball.speedY;

            if (ball.x > 1.0f)
            {
                ball.speedX = -1.0f;
            }

            if (ball.y > 1.0f)
            {
                ball.speedY = -1.0f;
            }


            if (ball.x < 0.0f)
            {
                ball.speedX = 1.0f;
            }

            if (ball.y < 0.0f)
            {
                ball.speedY = 1.0f;
            }



        }

        //Returnerar bollens X position
        public float getXPosition() {
            return ball.x;
        }
        
        //Returnerar bollens Y position
        public float getYPosition()
        {
            return ball.y;
        }
    }
}
