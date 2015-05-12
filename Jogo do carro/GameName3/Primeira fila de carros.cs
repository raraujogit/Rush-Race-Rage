using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameName3
{
    class Primeira_fila_de_carros : Sprite
    { 
        public Primeira_fila_de_carros(ContentManager content)
            : base(content, "Camioneta para baixo")
        {
            this.Scale(.15f);
            this.position.Y = position.Y + 0.1f;
            SetPosition(new Vector2(-0.57f, 3));
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

                this.position.Y -= 0.01f;


            base.Update(gameTime);
        }
    }
}

