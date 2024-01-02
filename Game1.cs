using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace battleSim;

public class Game1 : Game
{
  Texture2D soulTexture;

  private GraphicsDeviceManager _graphics;
  private SpriteBatch _spriteBatch;

  private Soul Soul;
  private BattleBox BattleBox;

  public string mode;

  public Game1()
  {
    _graphics = new GraphicsDeviceManager(this);
    Content.RootDirectory = "Content";
    IsMouseVisible = true;

    mode = "bullets";

    Soul = new Soul();
    BattleBox = new BattleBox(10, 10, 96, 96);
  }

  protected override void Initialize()
  {
    // TODO: Add your initialization logic here

    _graphics.PreferredBackBufferWidth = 640;
    _graphics.PreferredBackBufferHeight = 480;
    _graphics.ApplyChanges();

    base.Initialize();
  }

  protected override void LoadContent()
  {
    _spriteBatch = new SpriteBatch(GraphicsDevice);

    // TODO: use this.Content to load your game content here

    soulTexture = Content.Load<Texture2D>("soul");
  }

  protected override void Update(GameTime gameTime)
  {
    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
      Exit();


    // TODO: Add your update logic here

    // INPUTS

    var kstate = Keyboard.GetState();

    switch (mode) {
      case "bullets":
        if (kstate.IsKeyDown(Keys.Up)) {
          Soul.movement[0] = 1;
        } else {
          Soul.movement[0] = 0;
        }
        
        if (kstate.IsKeyDown(Keys.Down)) {
          Soul.movement[1] = 1;
        } else {
          Soul.movement[1] = 0;
        }
        if (kstate.IsKeyDown(Keys.Left)) {
          Soul.movement[2] = 1;
        } else {
          Soul.movement[2] = 0;
        }
        if (kstate.IsKeyDown(Keys.Right)) {
          Soul.movement[3] = 1;
        } else {
          Soul.movement[3] = 0;
        }

        break;
    }

    Soul.Update((float)gameTime.ElapsedGameTime.TotalSeconds, BattleBox.ReturnBoundingBox());

    base.Update(gameTime);
  }

  protected override void Draw(GameTime gameTime)
  {
    GraphicsDevice.Clear(Color.Black);

    // TODO: Add your drawing code here

    // SOUL
    _spriteBatch.Begin();
    _spriteBatch.Draw(soulTexture, Soul.position, Color.White);
    _spriteBatch.End();

    base.Draw(gameTime);
  }
}
