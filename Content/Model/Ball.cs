using Chess.Content.View;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess.Content.Model
{
    class Ball
    {
        public float centerX = 4;
        public float centerY = 4;

        //Bollens hastighet i x led
        public float speedX = 0.1f;
        public float speedY = 0.2f;

        //Dessa bestämmer vart bollen ska börja
        public float x = 0.5f;
        public float y = 0.5f;
        public float diameter = 0.1f;




    }
}
