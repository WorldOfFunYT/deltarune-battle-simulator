using System;
using System.Data;
using Microsoft.Xna.Framework;

public class Soul {

  public int[] movement = {
      0, // Up
      0, // Down
      0, // Left
      0 //  Right
      };
  public Vector2 position;

  private float speed = 75f;
  public Soul () {
    position = new Vector2(50, 50);
  }

  public void Update (float secondsSinceLastFrame, Rectangle boundingBox) { // Bounding box {x, y, width, height}
    Vector2 direction = new Vector2(movement[3] - movement[2], movement[1] - movement[0]);
    Vector2 displacement = new Vector2(speed * secondsSinceLastFrame * direction.X, speed * secondsSinceLastFrame * direction.Y); // X, Y
    position.X += displacement.X;
    position.Y += displacement.Y;

    float rightWall = boundingBox.X + boundingBox.Width;
    float bottomWall = boundingBox.Y + boundingBox.Height;
    position.X = Math.Min(Math.Max(boundingBox.X, position.X), rightWall - 16);
    position.Y = Math.Min(Math.Max(boundingBox.Y, position.Y), bottomWall - 16);
  }
}