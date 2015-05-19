using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;

namespace GameName3
{
    class Carro : Sprite
    { 
        public Carro(ContentManager content)
            : base(content, "Carro mustang")
        {
            this.Scale(.15f);
            this.position.Y = position.Y + 0.1f;
            this.EnableCollisions();
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime); 
        }

        public override void SetScene(Scene s)
        {
            this.scene = s;
        }

        public override void Update(GameTime gameTime)
        {
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

            Camera.SetTarget(new Vector2 (0,position.Y));

            if EnableCollisions=

            base.Update(gameTime);
        }
    }
}
