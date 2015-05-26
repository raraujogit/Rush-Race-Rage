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
        SpriteFont font;
        Scene scene;
        Sprite sprite;
        float NextCarInSeconds = 0;
        float CarCounter = 0;
        public float tempo = 0;
        Random randomGenerator;
        Carro carro;
     //   int estado = 0;
        Texture2D menu;
        Texture2D gameover;
        private MouseState oldState;
        public float score = 0;

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
            font = Content.Load<SpriteFont>("score");

            scene.AddSprite(carro = new Carro(Content));

            score = 0;
            
        }

        protected override void UnloadContent()
        {
            spriteBatch.Dispose();
            scene.Dispose();
        }
        
        protected override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            MouseState newState = Mouse.GetState();

            if (carro.estado == 0)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();
                this.IsMouseVisible = true;

                if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
                {      
                    if (mouseState.Position.X > 252 && mouseState.Position.X < 452 && mouseState.Position.Y > 102 && mouseState.Position.Y < 156)
                    { 
                        carro.estado = 1; 
                    }
                    Console.WriteLine(mouseState.Position);
                    //{X:252 Y:102} canto da esquerda de cima
                    //{X:252 Y:156} canto da esquerda de baixo
                    //{X:452 Y:103} canto da direita de cima
                    //{X:451 Y:156} canto da direita de baixo
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
                    tempo += (float)gameTime.ElapsedGameTime.Milliseconds;
                    score = tempo*0.25f;

                    
                    scene.Update(gameTime);
                }
            }

            if (carro.estado == 2)
            {
                if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
                {
                    if (mouseState.Position.X > 252 && mouseState.Position.X < 452 && mouseState.Position.Y > 102 && mouseState.Position.Y < 156)
                    {
                        carro.estado = 0;
                    }
                }
            }



            base.Update(gameTime);

           
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            if (carro.estado == 0)
            {

                spriteBatch.Draw(menu, new Vector2(0, 0), Color.White);


            }

            if (carro.estado == 1)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                scene.Draw(gameTime);
                spriteBatch.DrawString(font, "Score:" + tempo*0.25, new Vector2(490, 10), Color.Azure, 0, Vector2.Zero, 1.4f, SpriteEffects.None, 0);
            }

            if (carro.estado == 2)
            {

                spriteBatch.Draw(gameover, new Vector2(0, 0), Color.White);
                spriteBatch.DrawString(font, "" +score, new Vector2(233, 119), Color.Black, 0, Vector2.Zero, 1.5f, SpriteEffects.None, 0);

            }

            

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
