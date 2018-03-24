using OpenTK.Graphics.OpenGL;

namespace OpenGLBloxorz.Shapes
{
    public static class FloorTile
    {
        public static void Draw(double sizeUnit)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Normal3(0.0f, 1.0f, 0.0f);
            GL.Vertex3(-sizeUnit, 0, -sizeUnit);
            GL.Vertex3(sizeUnit, 0, -sizeUnit);
            GL.Vertex3(sizeUnit, 0, sizeUnit);
            GL.Vertex3(-sizeUnit, 0, sizeUnit);
            GL.End();
        }
    }
}
