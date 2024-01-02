using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Render {
  static Texture2D _pointTexture;

  public static void DrawRectangleOutline (SpriteBatch spriteBatch, Rectangle rectangle, Color color, int lineWidth) {
    if (_pointTexture == null)
      {
        _pointTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
        _pointTexture.SetData<Color>(new Color[]{Color.White});
      }
    spriteBatch.Draw(_pointTexture, new Rectangle(rectangle.X - lineWidth, rectangle.Y - lineWidth, lineWidth, rectangle.Height + lineWidth), color);
    spriteBatch.Draw(_pointTexture, new Rectangle(rectangle.X, rectangle.Y - lineWidth, rectangle.Width + lineWidth, lineWidth), color);
    spriteBatch.Draw(_pointTexture, new Rectangle(rectangle.X + rectangle.Width, rectangle.Y, lineWidth, rectangle.Height + lineWidth), color);
    spriteBatch.Draw(_pointTexture, new Rectangle(rectangle.X - lineWidth, rectangle.Y + rectangle.Height, rectangle.Width + lineWidth, lineWidth), color);

  }
}