using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess.Content.Model
{
    class Ball2
    {
        public float centerX = 4;
        public float centerY = 4;

        //Bollens hastighet i x led
        public float speedX = 0.4f;
        public float speedY = 0.3f;

        //Dessa bestämmer vart bollen ska börja
        public float x = 0.3f;
        public float y = 0.2f;
        float radius = 0.1f;
    }
}
