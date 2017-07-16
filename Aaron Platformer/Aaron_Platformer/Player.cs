using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aaron_Platformer
{
    class Player : AnimatedSprite

    {
        public int Gravity = 2;
        public float Floor = 600;
        float JumpPower = -30;
        public TimeSpan guyToWait;
        //4 extra hitboxes, one for each side of the player (and platform)
        //if your bottom hitbox intersects a platforms top hitbox -> make the top of the hitbox the new ground
        //if your bottom hitbox is NOT intersecting with any platform, set ground back to the original value
        public Player(Texture2D pi, Vector2 po, Vector2 sp, Color tin, List<Frame> frames)
            : base(pi, po, sp, tin, frames)
        {
            guyToWait = timeToWait;
        }

        public void MoveRight()
        {
            Effect = SpriteEffects.None;
            AnimState = State.run;
            Position.X += Speed.X;
        }
        public void MoveLeft()
        {
            Effect = SpriteEffects.FlipHorizontally;
            AnimState = State.run;
            Position.X -= Speed.X;

        }
        public void Jump()
        {
            if (AnimState != State.die)
            {
                AnimState = State.jump;
            }         
            Velocity = new Vector2(0, JumpPower);
            Floor = 600;
            OnGround = false;
        }

        public void Update(GameTime gameTime, List<NonAnimatedSprite> blocks)
        {
            base.Update(gameTime);

            if (OnGround)
            {
                bool fallen = true;
                for (int i = 0; i < blocks.Count; i++)
                {
                    if (Foot.Intersects(blocks[i].Roof))
                    {
                        fallen = false;
                    }
                }

                if (fallen)
                {
                    OnGround = false;
                    Floor = 600;
                }

            }

            if (!OnGround)
            {
                Velocity.Y += Gravity;

                for (int i = 0; i < blocks.Count; i++)
                {
                    if (Foot.Intersects(blocks[i].Roof) && Velocity.Y > 0)
                    {
                        Floor = blocks[i].Position.Y;
                    }
                }

                if (Position.Y >= Floor)
                {
                    OnGround = true;
                    Velocity = new Vector2(0, 0);
                    Position.Y = Floor + 1;
                }
            }


            //if onGround = false
            //if you collide with a brick, set Floor = top of brick & onGround = true & Velocity = 0 & position.Y = top of brick

            //!onGround
            //if you do NOT collide with any brick: set floor = 600, onGround = false



        }

        //if (
        /*if (ks.IsKeyDown(Keys.Right) && guy.Position.X <= 1600 - 45)
            {
                guy.Effect = SpriteEffects.None;
                guy.Position.X += guy.Speed.X;
                guy.AnimState = AnimatedSprite.State.run;

            }
            if (ks.IsKeyDown(Keys.D))
            {
                guy.AnimState = AnimatedSprite.State.die;
            }
            if (ks.IsKeyDown(Keys.Left) && guy.Position.X >= 45)
            {
                guy.Effect = SpriteEffects.FlipHorizontally;
                guy.Position.X -= guy.Speed.X;
                guy.AnimState = AnimatedSprite.State.run;
            }


            if (ks.IsKeyDown(Keys.Up) && lks.IsKeyUp(Keys.Up) && (guy.OnGround == true))
            {
                guy.AnimState = AnimatedSprite.State.jump;
                guy.Velocity = new Vector2(0, -30);
                //circle.velocity = new Vector2(0, -5);
                //circle.pos.Y = guy.pos.Y;
            }
            if (guy.Position.Y/* + (guy.Frames[guy.ActiveFrame].bounds.Height/2) < floor.Position.Y)
            {
                guy.OnGround = false;
            }
            else if (guy.Position.Y /* + (guy.Frames[guy.ActiveFrame].bounds.Height/2) >= floor.Position.Y)
            {
                guy.OnGround = true;
                //guy.Velocity = new Vector2(0, 0);
                //floor.Position.Y - (guy.Frames[guy.ActiveFrame].bounds.Height/2)
                guy.Position.Y = floor.Position.Y/* + (guy.Frames[guy.ActiveFrame].bounds.Height/2);
            }
            if (!guy.OnGround)
            {
              //  guy.Velocity.Y += Gravity;

            }
            */


    }
}
