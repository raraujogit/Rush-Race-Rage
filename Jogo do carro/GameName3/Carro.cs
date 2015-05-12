using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;

namespace GameName3
{

    class Carro : Sprite
    {
        private Sprite turret;
        private float fireInterval = 0.5f;
        private float fireCounter = 0f;

        public Carro(ContentManager content)
            : base(content, "Carro mustang")
        {
            this.Scale(.15f);
            this.position.Y = position.Y + 0.1f;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
          //  turret.Draw(gameTime);
        }

        public override void SetScene(Scene s)
        {
            this.scene = s;
           // turret.SetScene(s);
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mstate = Mouse.GetState();
            Point mpos = mstate.Position;

            Vector2 tpos = Camera.WorldPoint2Pixels(position);
            float a = (float)mpos.Y - tpos.Y;
            float l = (float)mpos.X - tpos.X;
            float rot = (float)Math.Atan2(a, l);
            rot += (float)Math.PI / 2f;
           // turret.SetRotation(rot);

            fireCounter += (float)gameTime.ElapsedGameTime.TotalSeconds;
            //if (fireCounter >= fireInterval &&
              //  mstate.LeftButton == ButtonState.Pressed)
            //{
            //    Vector2 pos = this.position
            //             + new Vector2((float)Math.Sin(rot) * size.Y / 2,
            //                           (float)Math.Cos(rot) * size.Y / 2);
            //    Bullet bullet = new Bullet(cManager, pos, rot);
            //    scene.AddSprite(bullet);
            //    fireCounter = 0f;
            //}

                
                KeyboardState state = Keyboard.GetState();
                if (state.IsKeyDown(Keys.W))
                {
                    this.position.Y += 0.01f;
                    Sprite other;
                    Vector2 colPosition;
                    if (scene.Collides(this, out other, out colPosition))
                        this.position.Y -= 0.01f;
                }

                if (state.IsKeyDown(Keys.S))
                {
                    this.position.Y -= 0.005f;
                    Sprite other;
                    Vector2 colPosition;
                    if (scene.Collides(this, out other, out colPosition))
                        this.position.Y += 0.01f;
                }

                if (state.IsKeyDown(Keys.D))
                {
                    this.position.X += 0.01f;
                    Sprite other;
                    Vector2 colPosition;
                    if (scene.Collides(this, out other, out colPosition))
                        this.position.Y += 0.01f;
                }

                if (state.IsKeyDown(Keys.A))
                {
                    this.position.X -= 0.01f;
                    Sprite other;
                    Vector2 colPosition;
                    if (scene.Collides(this, out other, out colPosition))
                        this.position.Y += 0.01f;
                }

                if (state.IsKeyDown(Keys.Space))
                {
                    this.position.Y -= 0.01f;
                    Sprite other;
                    Vector2 colPosition;
                    if (scene.Collides(this, out other, out colPosition))
                        this.position.Y += 0.01f;
                }

                this.position.Y += 0.01f;

            if (position.X >= 0.66f)
            {
                position.X = 0.66f;
            }

            if (position.X <=-0.61f)
            {
                position.X = -0.61f;
            }

            

           // turret.SetPosition(this.position);
            Camera.SetTarget(new Vector2 (0,position.Y));

          //  turret.Update(gameTime);
            base.Update(gameTime);
        }
    }
}
