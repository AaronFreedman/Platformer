using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aaron_Platformer
{
    class AnimatedSprite : Basesprite
    {
        public enum State
        {
            none,
            walk,
            run,
            jump,
            leap,
            climb,
            kneel,
            die,
            shark,
            crab
        }

        //LIST of Frame objects
        private TimeSpan elapsedTime;
        public TimeSpan timeToWait = new TimeSpan(0, 0, 0, 0, 10);
        private TimeSpan timeToWait2 = new TimeSpan(0, 0, 0, 0, 50);
        private TimeSpan timeToWait4 = new TimeSpan(0, 0, 0, 0, 60);
        private TimeSpan timeToWait5 = new TimeSpan(0, 0, 0, 0, 100);
        private TimeSpan timeToWait3 = new TimeSpan(0, 0, 0, 0, 30);

        public bool ShouldFall = false;
        public int ActiveFrame;
        public List<Frame> Frames;
        public Vector2 Velocity = new Vector2(0, 0);
        public bool OnGround = true;
        public Rectangle Hitbox
        {
            get
            {
                return new Rectangle(
                    (int)(Position.X - Frames[ActiveFrame].origin.X),
                    (int)(Position.Y - Frames[ActiveFrame].origin.Y),
                    Frames[ActiveFrame].bounds.Width,
                    Frames[ActiveFrame].bounds.Height
                    );
            }
        }
        public Rectangle Foot
        {
            get
            {
                return new Rectangle(
                    (int)(Position.X - Frames[ActiveFrame].origin.X),
                    (int)(Position.Y),
                    Frames[ActiveFrame].bounds.Width,
                    10
                    );
            }
        }
        //FOOT

        public State AnimState = State.none;

        public AnimatedSprite(Texture2D pi, Vector2 po, Vector2 sp, Color tin, List<Frame> frames)
            : base(pi, po, sp, tin)
        {
            this.Frames = frames;
            ActiveFrame = 0;

            //in game1 when you create this animated sprite, manually enter all frames 
        }

        public virtual void Update(GameTime gameTime)
        {
            if (!OnGround && AnimState != State.die)
            {
                AnimState = State.jump;
            }

            if (AnimState == State.none)
            {
                Velocity = new Vector2(0, 0);
                Idle(gameTime);
            }
            if (AnimState == State.run)
            {
                Run(gameTime);
            }
            if (AnimState == State.walk)
            {
                Walk(gameTime);
            }
            if (AnimState == State.jump)
            {
                Jump(gameTime);
            }
            if (AnimState == State.kneel)
            {
                Kneel(gameTime);
            }
            if (AnimState == State.die)
            {
                Die(gameTime);
            }
            if (AnimState == State.shark)
            {
                Shark(gameTime);
            }
            if (AnimState == State.crab)
            {
                Crab(gameTime);
            }
            Position += Velocity;

        }


        public override void Draw(SpriteBatch s)
        {
            //if(this.animState == State.RUN)
            //{
            //    for (int i = 0; i < 3; i++)
            //    {
            //        s.Draw(pic, pos - (i+1) * new Vector2(frames[(activeFrame + i) % frames.Count].bounds.Width, 0), frames[(activeFrame + i) % frames.Count].bounds, tint, 0, frames[(activeFrame + i) % frames.Count].origin, 1, effect, 1);
            //    }

            //}
            s.Draw(Picture, Position, Frames[ActiveFrame].bounds, Tint, 0, Frames[ActiveFrame].origin, Frames[ActiveFrame].scale, Effect, 1);
            //s.Draw(Game1.debug, Hitbox, Color.Red * 0.49f);
        }
        public void Jump(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime;
            if (elapsedTime > timeToWait)
            {
                ActiveFrame++;
                elapsedTime = TimeSpan.Zero;
                if (ActiveFrame < 48)
                {
                    ActiveFrame = 48;
                }
                if (ActiveFrame > 53)
                {
                    AnimState = State.none;
                    ActiveFrame = 53;

                }
            }
        }

        public void Die(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime;
            if (elapsedTime > timeToWait2)
            {
                ActiveFrame++;
                elapsedTime = TimeSpan.Zero;
                if (ActiveFrame < 53)
                {
                    ActiveFrame = 53;
                }
                if (ActiveFrame > 62)
                {
                    ActiveFrame = 62;
                }
            }
        }
        public void fall()
        {
            ShouldFall = true;
            if (ShouldFall)
            {
                Position.Y += Speed.Y;
            }
        }
        public void Walk(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime;
            if (elapsedTime > timeToWait)
            {
                ActiveFrame++;
                elapsedTime = TimeSpan.Zero;
                if (ActiveFrame < 1 || ActiveFrame > 4)
                {
                    ActiveFrame = 1;
                }
            }
        }
        public void Idle(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime;
            if (elapsedTime > timeToWait)
            {
                ActiveFrame++;
                elapsedTime = TimeSpan.Zero;
                if (ActiveFrame < 0 || ActiveFrame > 21)
                {
                    ActiveFrame = 0;
                }
            }
        }
        public void Crab(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime;
            if (elapsedTime > timeToWait5)
            {
                ActiveFrame++;
                elapsedTime = TimeSpan.Zero;
                if (ActiveFrame < 0 || ActiveFrame > 6)
                {
                    ActiveFrame = 0;
                }
            }
        }
        public void Shark(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime;
            if (elapsedTime > timeToWait4)
            {
                ActiveFrame++;
                elapsedTime = TimeSpan.Zero;
                if (ActiveFrame < 0 || ActiveFrame > 5)
                {
                    ActiveFrame = 0;
                }
            }
        }
        public void Run(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime;
            if (elapsedTime > timeToWait)
            {
                ActiveFrame++;
                elapsedTime = TimeSpan.Zero;
                if (ActiveFrame < 22 || ActiveFrame > 47)
                {
                    ActiveFrame = 22;
                }
            }
        }
        public void Kneel(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime;
            if (elapsedTime > timeToWait)
            {
                ActiveFrame++;
                elapsedTime = TimeSpan.Zero;
                if (ActiveFrame < 5)
                {
                    ActiveFrame = 5;
                }
                if (ActiveFrame > 7)
                {
                    ActiveFrame = 7;
                }
            }
        }

    }
}

