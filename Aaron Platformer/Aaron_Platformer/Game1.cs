using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Aaron_Platformer
{
    /// <summary>
    /// I made some changes
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public static Texture2D debug;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player guy;
        List<AnimatedSprite> crab = new List<AnimatedSprite>();
        List<AnimatedSprite> shark = new List<AnimatedSprite>();
        KeyboardState lks;
        Frame Blob;
        NonAnimatedSprite floor;
        NonAnimatedSprite block;
        NonAnimatedSprite flag;
        NonAnimatedSprite pole;
        NonAnimatedSprite finalPole;
        NonAnimatedSprite finalFlag;
        NonAnimatedSprite clouds;
        AnimatedSprite live1;
        AnimatedSprite live2;
        AnimatedSprite live3;
        Writing score;
        Writing youWin;
        Writing gameOver;
        int BlockPosition = 0;
        int BlockX = 800;
        int Dfm = 0;
        int Middle = 800;
        int GuyPosition = 0;
        int lives = 3;
        int count = 0;
        int faster = 7;
        int Xcount = 0;
        List<NonAnimatedSprite> blocks = new List<NonAnimatedSprite>();
        Random random = new Random();
        int CrabX = 100;
        int SharkX = 0;
        Texture2D wallTexture;
        int stg = -30;
        //list of crabs
        bool HitFlag = false;        
        bool IsHit = false;
        bool AmDead = false;
        bool HasWon = false;
        float winScale = 1.8f;
        // while # crabs < 100
        //spawn the crabs on the bottom row
        //delete crabs that intersect with blocks & other crabs

        //as you move right/left you need to move all crabs right/left just like background


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 1600;
            graphics.ApplyChanges();
            random = new Random();

            debug = new Texture2D(GraphicsDevice, 1, 1);
            debug.SetData<Color>(new Color[] { Color.White });

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            List<Frame> frames = new List<Frame>();
            //idle count:22
            frames.Add(new Frame(24, 29, 65, 108));
            frames.Add(new Frame(99, 29, 64, 108));
            frames.Add(new Frame(172, 29, 64, 108));
            frames.Add(new Frame(249, 29, 64, 108));
            frames.Add(new Frame(325, 28, 64, 109));
            frames.Add(new Frame(398, 28, 63, 109));
            frames.Add(new Frame(474, 28, 64, 109));
            frames.Add(new Frame(550, 28, 64, 109));
            frames.Add(new Frame(626, 28, 64, 109));
            frames.Add(new Frame(706, 28, 64, 109));
            frames.Add(new Frame(782, 28, 64, 109));
            frames.Add(new Frame(859, 28, 64, 109));
            frames.Add(new Frame(932, 28, 64, 109));
            frames.Add(new Frame(1005, 28, 64, 109));
            frames.Add(new Frame(1080, 28, 64, 109));
            frames.Add(new Frame(1154, 28, 64, 109));
            frames.Add(new Frame(1228, 28, 64, 109));
            frames.Add(new Frame(1304, 28, 64, 109));
            frames.Add(new Frame(1381, 29, 64, 109));
            frames.Add(new Frame(1460, 29, 64, 109));
            frames.Add(new Frame(1536, 29, 64, 109));
            frames.Add(new Frame(1614, 29, 64, 109));
            //run count:27
            frames.Add(new Frame(31, 297, 75, 106));
            frames.Add(new Frame(127, 295, 76, 106));
            frames.Add(new Frame(210, 295, 79, 106));
            frames.Add(new Frame(305, 296, 81, 106));
            frames.Add(new Frame(402, 295, 85, 103));
            frames.Add(new Frame(497, 295, 91, 101));
            frames.Add(new Frame(597, 295, 94, 101));
            frames.Add(new Frame(701, 296, 88, 102));
            frames.Add(new Frame(794, 297, 80, 103));
            frames.Add(new Frame(21, 409, 81, 104));
            frames.Add(new Frame(118, 409, 83, 104));
            frames.Add(new Frame(214, 409, 78, 105));
            frames.Add(new Frame(319, 410, 74, 106));
            frames.Add(new Frame(408, 408, 78, 107));
            frames.Add(new Frame(495, 408, 83, 107));
            frames.Add(new Frame(600, 408, 84, 106));
            frames.Add(new Frame(700, 408, 86, 107));
            frames.Add(new Frame(792, 408, 89, 106));
            frames.Add(new Frame(16, 176, 94, 101));
            frames.Add(new Frame(124, 176, 94, 103));
            frames.Add(new Frame(235, 176, 93, 104));
            frames.Add(new Frame(340, 176, 90, 105));
            frames.Add(new Frame(441, 177, 83, 106));
            frames.Add(new Frame(535, 178, 82, 106));
            frames.Add(new Frame(632, 177, 81, 105));
            frames.Add(new Frame(728, 177, 79, 106));
            frames.Add(new Frame(820, 178, 76, 105));
            //jump count:5
            frames.Add(new Frame(963, 435, 85, 103));
            frames.Add(new Frame(1063, 436, 95, 102));
            frames.Add(new Frame(1169, 438, 98, 100));
            frames.Add(new Frame(1284, 434, 91, 103));
            frames.Add(new Frame(1389, 431, 87, 106));
            //face count:1
            frames.Add(new Frame(1516, 444, 64, 53));
            //YAY! count:1 55
            frames.Add(new Frame(343, 823, 94, 109));
            //die count:9
            frames.Add(new Frame(966, 163, 79, 105));
            frames.Add(new Frame(1059, 166, 76, 96));
            frames.Add(new Frame(1151, 167, 73, 95));
            frames.Add(new Frame(1240, 167, 76, 92));
            frames.Add(new Frame(1339, 169, 78, 91));
            frames.Add(new Frame(1428, 174, 90, 90));
            frames.Add(new Frame(1638, 181, 98, 76));
            frames.Add(new Frame(1759, 182, 98, 75));
            frames.Add(new Frame(1876, 183, 98, 74));

            List<Frame> sharks = new List<Frame>();

            sharks.Add(new Frame(48, 473, 280, 153));
            sharks.Add(new Frame(428, 473, 298, 153));
            sharks.Add(new Frame(830, 473, 298, 153));
            sharks.Add(new Frame(48, 691, 280, 153));
            sharks.Add(new Frame(419, 690, 307, 153));
            sharks.Add(new Frame(830, 690, 298, 153));

            List<Frame> crabs = new List<Frame>();

            crabs.Add(new Frame(1, 1, 90, 51));
            crabs.Add(new Frame(94, 1, 94, 49));
            crabs.Add(new Frame(191, 1, 92, 47));
            crabs.Add(new Frame(286, 1, 95, 51));
            crabs.Add(new Frame(384, 1, 87, 53));
            crabs.Add(new Frame(474, 1, 96, 47));
            crabs.Add(new Frame(573, 1, 92, 53));

            wallTexture = Content.Load<Texture2D>("wall");

            blocks.Add(new NonAnimatedSprite(wallTexture, new Vector2(BlockX - 155, 485), new Vector2(0, 0), Color.AntiqueWhite));
            for (int i = 0; i < 50; i++)
            {
                GenerateBlock(BlockX);
                BlockX += 155;

            }


            do
            {
                CrabX = random.Next(700, 50000);
                AnimatedSprite crabi = new AnimatedSprite(Content.Load<Texture2D>("crab"), new Vector2(CrabX, 600), new Vector2(3, 2), Color.White, crabs);

                bool touches = false;
                for (int i = 0; i < blocks.Count; i++)
                {
                    if (crabi.Hitbox.Intersects(blocks[i].Hitbox2))
                    {
                        touches = true;
                        break;
                    }
                }

                for (int a = 0; a < crab.Count; a++)
                {
                    if (crabi != crab[a] && crabi.Hitbox.Intersects(crab[a].Hitbox))
                    {
                        touches = true;
                        break;
                    }
                }


                if (!touches)
                {
                    crab.Add(crabi);
                }
            } while (crab.Count <= 50);



            for (int i = 0; i < 100; i++)
            {
                shark.Add(new AnimatedSprite(Content.Load<Texture2D>("shark"), new Vector2(SharkX, -100), new Vector2(5, 9), Color.White, sharks));
                SharkX += 1000;
            }


            // TODO: use this.Content to load your game content here
            guy = new Player(Content.Load<Texture2D>("dude"), new Vector2(50, 712), new Vector2(4, 2), Color.White, frames);
            live1 = new Player(Content.Load<Texture2D>("dude"), new Vector2(1400, 102), new Vector2(2, 2), Color.White, frames);
            live2 = new Player(Content.Load<Texture2D>("dude"), new Vector2(1470, 102), new Vector2(2, 2), Color.White, frames);
            live3 = new Player(Content.Load<Texture2D>("dude"), new Vector2(1540, 102), new Vector2(2, 2), Color.White, frames);
            //crab = new AnimatedSprite(Content.Load<Texture2D>("crab"), new Vector2(200, 312), new Vector2(10, 2), Color.White, crabs);
            floor = new NonAnimatedSprite(Content.Load<Texture2D>("brownpixel"), new Vector2(0, 600), new Vector2(10, 0), Color.White);
            guy = new Player(Content.Load<Texture2D>("dude"), new Vector2(50, floor.Position.Y/* + (guy.Frames[guy.ActiveFrame].bounds.Height/2)*/), new Vector2(10, 2), Color.White, frames);
            block = new NonAnimatedSprite(Content.Load<Texture2D>("wall"), new Vector2(300, 485), new Vector2(10, 0), Color.AntiqueWhite);
            clouds = new NonAnimatedSprite(Content.Load<Texture2D>("cloud"), new Vector2(300, -100), new Vector2(10, 0), Color.AntiqueWhite);
            flag = new NonAnimatedSprite(Content.Load<Texture2D>("mcdonalds"), new Vector2(10018, 300), new Vector2(10, 0), Color.AntiqueWhite);
            pole = new NonAnimatedSprite(Content.Load<Texture2D>("pole"), new Vector2(10000, 250), new Vector2(10, 0), Color.AntiqueWhite);
            finalPole = new NonAnimatedSprite(Content.Load<Texture2D>("pole"), new Vector2(40000, 250), new Vector2(10, 0), Color.AntiqueWhite);
            finalFlag = new NonAnimatedSprite(Content.Load<Texture2D>("finalFlag"), new Vector2(40020, 300), new Vector2(10, 0), Color.AntiqueWhite);
            score = new Writing(Content.Load<SpriteFont>("SF1"), count.ToString(), new Vector2(20, 20), Color.AntiqueWhite);
            gameOver = new Writing(Content.Load<SpriteFont>("SF2"), ("Game Over"), new Vector2(40000000, 200), Color.Firebrick);
            youWin = new Writing(Content.Load<SpriteFont>("SF2"), ("You Won"), new Vector2(45000000000, 200), Color.Goldenrod);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        // + guy.Frames[guy.ActiveFrame].bounds.Height

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            // Allows the game to exit
            if (!(AmDead || HasWon))
            {
                
                live1.ActiveFrame = 54;
                live2.ActiveFrame = 54;
                live3.ActiveFrame = 54;
                if (ks.IsKeyDown(Keys.Up) && lks.IsKeyUp(Keys.Up) && (guy.OnGround == true) || ks.IsKeyDown(Keys.W) && lks.IsKeyUp(Keys.W) && (guy.OnGround == true))
                {
                    guy.Jump();
                }
                for (int i = 0; i < shark.Count; i++)
                {
                    shark[i].AnimState = AnimatedSprite.State.shark;
                    if (shark[i].Position.X - guy.Position.X <= stg)
                    {
                        shark[i].fall();

                    }
                }

                for (int i = 0; i < crab.Count; i++)
                {
                    crab[i].AnimState = AnimatedSprite.State.crab;
                    for (int a = 0; a < blocks.Count; a++)
                    {
                        if (crab[i].Hitbox.Intersects(blocks[a].Hitbox2))
                        {
                            crab[i].Speed.X *= -1;
                        }

                    }
                    crab[i].Position.X += crab[i].Speed.X;
                }

                if (ks.IsKeyDown(Keys.Right) && guy.Position.X <= 1600 - 45 || ks.IsKeyDown(Keys.D) && guy.Position.X <= 1600 - 45)
                {
                    bool intersects = false;
                    for (int i = 0; i < blocks.Count; i++)
                    {
                        if ((guy.Hitbox.Intersects(blocks[i].Hitbox2)))
                        {
                            intersects = true;
                            break;
                        }
                    }

                    if (!intersects)
                    {
                        guy.MoveRight();
                    }
                    Xcount += (int)guy.Speed.X;
                }
                else if (ks.IsKeyDown(Keys.Left) && guy.Position.X >= 45 || ks.IsKeyDown(Keys.A) && guy.Position.X >= 45)
                {
                    bool intersects = false;
                    for (int i = 0; i < blocks.Count; i++)
                    {
                        if ((guy.Hitbox.Intersects(blocks[i].Hitbox2)))
                        {
                            intersects = true;
                            break;
                        }
                    }

                    if (!intersects)
                    {
                        guy.MoveLeft();
                    }
                    Xcount -= (int)guy.Speed.X;
                }
                else if (guy.OnGround == true)
                {
                    guy.AnimState = AnimatedSprite.State.none;
                }
                for (int i = 0; i < crab.Count; i++)
                {
                    if (guy.Hitbox.Intersects(crab[i].Hitbox) && !IsHit && ks.IsKeyUp(Keys.C))
                    {
                        lives--;
                        IsHit = true;
                        crab.RemoveAt(i);
                        CrabX = random.Next(700, 50000);
                        crab[i].Position.X = CrabX;
                        IsHit = false;

                    }
                }
                for (int i = 0; i < shark.Count; i++)
                {
                    if (guy.Hitbox.Intersects(shark[i].Hitbox) && !IsHit && ks.IsKeyUp(Keys.C))
                    {
                        lives--;
                        IsHit = true;
                        shark[i].Position.X = SharkX;
                        SharkX += 1000;
                        IsHit = false;

                    }
                }
                if (lives == 2)
                {
                    live1.Position.X = -30000;

                }
                if (lives == 1)
                {
                    live2.Position.X = -30000;
                }
                if (lives == 0)
                {
                    AmDead = true;
                }

                if (!HitFlag && guy.Position.X > flag.Position.X + flag.Picture.Width)
                {
                    HitFlag = true;
                    flag.Picture = Content.Load<Texture2D>("hf");
                    guy.Speed.X += 3;
                    stg += 1;
                    guy.guyToWait = new TimeSpan(0, 0, 0, 0, 2);
                    count++;
                    faster-=2;
                    score.Text = count.ToString();
                }

                //if (ks.IsKeyDown(Keys.C))
                //{
                //    HitFlag = true;
                //}
                if (pole.Position.X <= -100)
                {
                    HitFlag = false;
                    pole.Position.X += 7000;
                    flag.Position.X += 7000;
                    flag.Picture = Content.Load<Texture2D>("mcdonalds");
                }
                for (int i = 0; i < blocks.Count(); i++)
                {
                    if (blocks[i].Position.X <= -200)
                    {
                        //blocks[i].Position.X = BlockX;
                        //BlockX += 115;
                        blocks.RemoveAt(i--);
                        GenerateBlock(BlockX);
                        BlockX += 155;
                    }
                }

                if (guy.Hitbox.Intersects(finalPole.Hitbox2))
                {
                    HasWon = true;
                }







                for (int i = 0; i < shark.Count; i++)
                {
                    shark[i].Update(gameTime);
                }
                for (int i = 0; i < crab.Count; i++)
                {
                    crab[i].Update(gameTime);
                }

                GuyPosition = (int)guy.Position.X;
                Dfm = GuyPosition -= Middle;
                if (Dfm >= 1)
                {
                    guy.Position.X -= Dfm;
                    for (int i = 0; i < blocks.Count; i++)
                    {
                        blocks[i].Position.X -= Dfm;
                    }
                    for (int i = 0; i < crab.Count; i++)
                    {
                        crab[i].Position.X -= Dfm;
                    }
                    for (int i = 0; i < shark.Count; i++)
                    {
                        shark[i].Position.X -= Dfm;
                    }
                    clouds.Position.X -= Dfm;
                    if (clouds.Position.X <= -500)
                    {
                        clouds.Position.X = 1900;
                    }
                    BlockX -= Dfm;
                    pole.Position.X -= Dfm;
                    finalPole.Position.X -= Dfm;
                    flag.Position.X -= Dfm;
                    finalFlag.Position.X -= Dfm;
                }
                guy.Update(gameTime, blocks);


                // TODO: Add your update logic here
                lks = ks;//Keyboard.GetState();
            }
            if (AmDead)
            {
                guy.Update(gameTime);
                //guy.Speed.X = 0;
               // guy.Speed.Y = 1;
                guy.Velocity.Y = 0;
                gameOver.Position.X = 400; 
                guy.AnimState = AnimatedSprite.State.die;
                live3.Position.X = -30000;
                guy.Floor = 1200;
                guy.Position.Y += guy.Speed.Y;
            }
            
            if (ks.IsKeyDown(Keys.R) && lks.IsKeyUp(Keys.R))
            {
                AmDead = false;
                lives = 3;
                HasWon = false;
                guy.AnimState = AnimatedSprite.State.none;
                guy.Position.X = 50;
                guy.Position.Y = 712;
                IsHit = false;
                for (int i = 0; i < blocks.Count; i++)
                {
                    blocks.RemoveAt(i);
                }
                BlockX = 800;
                for (int i = 0; i < 1; i++)
                {
                    GenerateBlock(BlockX - 155);
                    BlockX += 155;
                }
                live1.Position = new Vector2(1400, 102);
                live2.Position = new Vector2(1470, 102);
                live3.Position = new Vector2(1540, 102);
                pole.Position.X = 10000;
                flag.Position.X = 10018;
                guy.Speed.X = 10;
                guy.Speed.Y = 2;
                finalPole.Position.X = 40000;
                finalFlag.Position.X = 40020;
                gameOver.Position.X = -4000000;
                youWin.Position.X = -4000000;
                count = 0;
                score.Text = count.ToString();
            }
            if (HasWon)
            {
                //guy.Update(gameTime);
                guy.ActiveFrame = 55;
                youWin.Position.X = 450;
                guy.Frames[55].scale = winScale;
                winScale += 0.04f;
                guy.Position.Y += 2;
            }
            //guy.Speed.X+= 1;
            base.Update(gameTime);

        }
    

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
           
      
            flag.Draw(spriteBatch);
            finalFlag.Draw(spriteBatch);
            pole.Draw(spriteBatch);
            finalPole.Draw(spriteBatch);
            score.Draw(spriteBatch);
            for (int i = 0; i < crab.Count; i++)
            {
                crab[i].Draw(spriteBatch);
            }
            for (int i = 0; i < shark.Count; i++)
            {
                shark[i].Draw(spriteBatch);
            }
            floor.Draw(spriteBatch);
            clouds.Draw(spriteBatch);
            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i].Draw(spriteBatch);
            }
            live1.Draw(spriteBatch);
            live2.Draw(spriteBatch);
            live3.Draw(spriteBatch);
            guy.Draw(spriteBatch);
            gameOver.Draw(spriteBatch);
            youWin.Draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        void GenerateBlock(int x)
        {
            BlockPosition = random.Next(1, 5);
            if (BlockPosition == 2)
            {
                blocks.Add(new NonAnimatedSprite(wallTexture, new Vector2(x, 485), new Vector2(0, 0), Color.AntiqueWhite));

            }
            if (BlockPosition == 1)
            {
                blocks.Add(new NonAnimatedSprite(wallTexture, new Vector2(x, 370), new Vector2(0, 0), Color.AntiqueWhite));

            }
            if (BlockPosition == 3)
            {

            }
            if (BlockPosition == 4)
            {
                blocks.Add(new NonAnimatedSprite(wallTexture, new Vector2(x, 485), new Vector2(0, 0), Color.AntiqueWhite));
                blocks.Add(new NonAnimatedSprite(wallTexture, new Vector2(x, 370), new Vector2(0, 0), Color.AntiqueWhite));
            }
        }
    }
}
