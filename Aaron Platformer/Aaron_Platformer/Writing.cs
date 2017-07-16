using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aaron_Platformer
{
    class Writing
    {
        SpriteFont Font;
        public string Text;
        public Vector2 Position;
        Color Tint;

        public Writing (SpriteFont font, string text, Vector2 position, Color tint)
        {
            Font = font;
            Text = text;
            Position = position;
            Tint = tint;
        }
        
        public void Draw (SpriteBatch sp)
        {
            sp.DrawString(Font, Text, Position, Tint);
        }
    }
}
