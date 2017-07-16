using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aaron_Platformer
{
    class Frame
    {
        public Rectangle bounds;
        public Vector2 origin;
        public float scale = 1;

        public Frame(int x, int y, int width, int height)
        {
            bounds = new Rectangle(x, y, width, height);
            origin = new Vector2(bounds.Width / 2, bounds.Height);
        }
    }
}
