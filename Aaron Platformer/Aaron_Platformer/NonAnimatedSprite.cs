using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aaron_Platformer
{
    class NonAnimatedSprite
    {
        public Vector2 Position;

        public Rectangle Roof
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Picture.Width, 30);
            }
        }
        public Rectangle Hitbox2
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y + 10, Picture.Width, Picture.Height - 10);
            }
        }

        //Roof

        public Texture2D Picture;
        public Vector2 Speed;
        public Color Tint;

        public NonAnimatedSprite(Texture2D picture, Vector2 position, Vector2 speed, Color tint)
        {
            Picture = picture;
            Position = position;
            Speed = speed;
            Tint = tint;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Picture, Position, Tint);
            //spriteBatch.Draw(Game1.debug, Hitbox2, Color.Yellow * 0.40f);
        }
    }
}
