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
        Sprite sprite;
        float NextCarInSeconds = 0;
        float CarCounter = 0;
        Random randomGenerator;
        Carro carro;
     //   int estado = 0;
        Texture2D menu;
        Texture2D gameover;
        private MouseState oldState;
        

        private string[] carros_para_descer =
        {
            "Camioneta para baixo", "carro amarelo"
        };
        private string[] carros_para_subir =
        {
            "Camioneta para cima", "carro amarelo subir"
        };
        
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

            menu = Content.Load<Texture2D>("menu");
            gameover = Content.Load<Texture2D>("gameover");

            scene.AddSprite(carro = new Carro(Content));
            
        }

        protected override void UnloadContent()
        {
            spriteBatch.Dispose();
            scene.Dispose();
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (carro.estado == 0)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();
                this.IsMouseVisible = true;

                MouseState mouseState = Mouse.GetState();
                MouseState newState = Mouse.GetState();

                if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
                {
                    
                    carro.estado = 1;
                }

                oldState = newState;

            }

            if (carro.estado == 1)
            {
                {
                    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                        Exit();

                    if (CarCounter >= NextCarInSeconds)
                    {
                        // enviar novo carro
                        int e = randomGenerator.Next(carros_para_descer.Length);
                        scene.AddSprite(new Primeira_fila_de_carros(Content, carro.getPosition().Y, carros_para_descer[e]));

                        int a = randomGenerator.Next(carros_para_subir.Length);
                        scene.AddSprite(new Primeira_fila_de_carros_a_subir(Content, carro.getPosition().Y, carros_para_subir[a]));

                        Console.WriteLine("sending new car");

                        CarCounter = 0f;
                        NextCarInSeconds = 2f + (float)randomGenerator.NextDouble() * 2f;
                    }

                    CarCounter += (float)gameTime.ElapsedGameTime.TotalSeconds;

                    
                    scene.Update(gameTime);
                }
            }


            base.Update(gameTime);

           
        }

        protected override void Draw(GameTime gameTime)
        {
            if (carro.estado == 0)
            {
                spriteBatch.Begin();

                spriteBatch.Draw(menu, new Vector2(0, 0), Color.White);

                spriteBatch.End();
            }

            if (carro.estado == 1)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                scene.Draw(gameTime);
            }

            if (carro.estado == 2)
            {
                spriteBatch.Begin();

                spriteBatch.Draw(gameover, new Vector2(0, 0), Color.White);

                spriteBatch.End();
            }

            base.Draw(gameTime);
        }
    }
}
