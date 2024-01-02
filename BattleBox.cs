using System.Security.Cryptography.X509Certificates;

public class BattleBox {
  int x;
  int y;
  int width;
  int height;
  public BattleBox (int xPos, int yPos, int boxWidth, int boxHeight) {
    x = xPos;
    y = yPos;
    width = boxWidth;
    height = boxHeight;
  }

  public int[] ReturnBoundingBox() {
    return new int[] {x, y, width, height};
  }
}