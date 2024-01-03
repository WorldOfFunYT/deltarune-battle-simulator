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
  private RenderTarget2D _nativeRenderTarget;

  private Soul Soul;
  private Rectangle BattleBox;

  public string mode;

  private float SCALE = 1.5f;

  public Game1()
  {
    _graphics = new GraphicsDeviceManager(this);
    Content.RootDirectory = "Content";
    IsMouseVisible = true;

    mode = "bullets";

    Soul = new Soul();
    BattleBox = new Rectangle(10, 10, 620, 460);
  }

  protected override void Initialize()
  {
    // TODO: Add your initialization logic here
    _graphics.PreferredBackBufferWidth = (int) (640.0 * SCALE);
    _graphics.PreferredBackBufferHeight = (int) (480.0 * SCALE);
    _graphics.PreferMultiSampling = false;
    _graphics.ApplyChanges();

    base.Initialize();
  }

  protected override void LoadContent()
  {
    _spriteBatch = new SpriteBatch(GraphicsDevice);

    _nativeRenderTarget = new RenderTarget2D(GraphicsDevice, 640, 480);

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

    Soul.Update((float)gameTime.ElapsedGameTime.TotalSeconds, BattleBox);

    base.Update(gameTime);
  }

  protected override void Draw(GameTime gameTime)
  {
    GraphicsDevice.Clear(Color.Black);

    // TODO: Add your drawing code here

    GraphicsDevice.SetRenderTarget(_nativeRenderTarget);

    // SOUL and battlebox
    if (mode == "bullets") {
      _spriteBatch.Begin();
      Render.DrawRectangleOutline(_spriteBatch, BattleBox, Color.White, 4);
      _spriteBatch.Draw(soulTexture, Soul.position, Color.White);
      _spriteBatch.End();
    }

    GraphicsDevice.SetRenderTarget(null);

    _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);
    _spriteBatch.Draw(_nativeRenderTarget, new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), Color.White);
    _spriteBatch.End();

    base.Draw(gameTime);
  }
}
