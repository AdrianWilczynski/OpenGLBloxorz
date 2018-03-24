using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace OpenGLBloxorz.Shapes
{
    public static class Floor
    {
        public static void Draw(double sizeUnit, double numberOfTilesPerRow, 
            Color primaryTileColor, Color secondaryTileColor)
        {
            GL.PushMatrix();
        
            GL.Translate(-(numberOfTilesPerRow - 1) * sizeUnit, 0, -(numberOfTilesPerRow - 1) * sizeUnit);

            var colorIndex = 0;
            for (int x = 0; x < numberOfTilesPerRow; x++)
            {
                GL.PushMatrix();

                GL.Translate(x * 2 * sizeUnit, 0, 0);

                for (int z = 0; z < numberOfTilesPerRow; z++)
                {
                    GL.PushMatrix();

                    GL.Translate(0, 0, z * 2 * sizeUnit);

                    GL.Color3(colorIndex++ % 2 == 0
                        ? primaryTileColor
                        : secondaryTileColor);
                    FloorTile.Draw(sizeUnit);

                    GL.PopMatrix();
                }
                GL.PopMatrix();
            }
            GL.PopMatrix();
        }
    }
}
