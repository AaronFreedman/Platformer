using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aaron_Platformer
{
    class Basesprite
    {
        public Vector2 Position;
        public Rectangle Hitbox2
        {
            get
            { 
                return new Rectangle((int)Position.X, (int)Position.Y, Picture.Width, Picture.Height);
            }
        }

        public Texture2D Picture;
        public Vector2 Speed;
        public Color Tint;
        public Rectangle Source;
        public Vector2 Origin;
        public Vector2 Gin;
        public SpriteEffects Effect;
        public float Rotate;


        public Basesprite(Texture2D pi, Vector2 po, Vector2 sp, Color tin)
        {
            Picture = pi;
            Position = po;
            Speed = sp;
            Tint = tin;
            Effect = SpriteEffects.None;
            Rotate = 0;
            Origin = Vector2.Zero;
            Gin = new Vector2(Hitbox2.Width / 2, Hitbox2.Height / 2);
            Source = new Rectangle(0, 0, Picture.Width, Picture.Height);
        }

        //update moves the hibox

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Picture, Position, Source, Tint, Rotate, Gin, 1, Effect, 0f);
        }
    
}
}
