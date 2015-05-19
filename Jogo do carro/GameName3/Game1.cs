#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace GameName3
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Scene scene;
        float NextCarInSeconds = 0;
        float CarCounter = 0;
        Random randomGenerator;
        Carro carro;

        public Game1() : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            randomGenerator = new Random();
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 700;
            graphics.ApplyChanges();

            Camera.SetGraphicsDeviceManager(graphics);
            Camera.SetTarget(Vector2.Zero);
            Camera.SetWorldWidth(2);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            scene = new Scene(spriteBatch);

            SlidingBackground sand = new SlidingBackground(Content, "sand");
            scene.AddBackground(sand);

            scene.AddSprite(carro = new Carro(Content));
            
        }

        protected override void UnloadContent()
        {
            spriteBatch.Dispose();
            scene.Dispose();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (CarCounter >= NextCarInSeconds)
            {
                // enviar novo carro
                scene.AddSprite(new Primeira_fila_de_carros(Content, carro.getPosition().Y));

                Console.WriteLine("sending new car");

                CarCounter = 0f;
                NextCarInSeconds = 2f + (float) randomGenerator.NextDouble() * 8f;
            }
            CarCounter += (float) gameTime.ElapsedGameTime.TotalSeconds;
            


            scene.Update(gameTime);
            base.Update(gameTime);

           
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            scene.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
