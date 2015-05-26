using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameName3
{
    class Primeira_fila_de_carros_a_subir : Sprite
    {
        public Primeira_fila_de_carros_a_subir(ContentManager content, float y, string asset)
            : base(content, asset)
        {
            Random randomGenerator1;
            randomGenerator1 = new Random();
            this.Scale(.15f);
            // -0.57 , -0.34 , -0.11
            int pista = randomGenerator1.Next(3);
            SetPosition(new Vector2(0.16f + pista * 0.23f, y + 3));
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

            this.position.Y += 0.005f;


            base.Update(gameTime);
        }
    }
}

