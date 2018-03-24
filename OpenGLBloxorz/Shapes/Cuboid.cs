using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace OpenGLBloxorz.Shapes
{
    public static class Cuboid
    {
        public static void DrawStandingCuboid(double sizeUnit, Color color)
        {
            GL.Color3(color);

            // Front face
            GL.Begin(PrimitiveType.Quads);
            GL.Normal3(0.0f, 0.0f, -1.0f);
            GL.Vertex3(sizeUnit, 0, -sizeUnit);
            GL.Vertex3(sizeUnit, 4 * sizeUnit, -sizeUnit);
            GL.Vertex3(-sizeUnit, 4 * sizeUnit, -sizeUnit);
            GL.Vertex3(-sizeUnit, 0, -sizeUnit);
            GL.End();

            // Back face
            GL.Begin(PrimitiveType.Quads);
            GL.Normal3(0.0f, 0.0f, 1.0f);
            GL.Vertex3(sizeUnit, 0, sizeUnit);
            GL.Vertex3(sizeUnit, 4 * sizeUnit, sizeUnit);
            GL.Vertex3(-sizeUnit, 4 * sizeUnit, sizeUnit);
            GL.Vertex3(-sizeUnit, 0, sizeUnit);
            GL.End();

            // Right face
            GL.Begin(PrimitiveType.Quads);
            GL.Normal3(1.0f, 0.0f, 0.0f);
            GL.Vertex3(sizeUnit, 0, -sizeUnit);
            GL.Vertex3(sizeUnit, 4 * sizeUnit, -sizeUnit);
            GL.Vertex3(sizeUnit, 4 * sizeUnit, sizeUnit);
            GL.Vertex3(sizeUnit, 0, sizeUnit);
            GL.End();

            // Left face
            GL.Begin(PrimitiveType.Quads);
            GL.Normal3(-1.0f, 0.0f, 0.0f);
            GL.Vertex3(-sizeUnit, 0, sizeUnit);
            GL.Vertex3(-sizeUnit, 4 * sizeUnit, sizeUnit);
            GL.Vertex3(-sizeUnit, 4 * sizeUnit, -sizeUnit);
            GL.Vertex3(-sizeUnit, 0, -sizeUnit);
            GL.End();

            // Top face
            GL.Begin(PrimitiveType.Quads);
            GL.Normal3(0.0f, 1.0f, 0.0f);
            GL.Vertex3(sizeUnit, 4 * sizeUnit, sizeUnit);
            GL.Vertex3(sizeUnit, 4 * sizeUnit, -sizeUnit);
            GL.Vertex3(-sizeUnit, 4 * sizeUnit, -sizeUnit);
            GL.Vertex3(-sizeUnit, 4 * sizeUnit, sizeUnit);
            GL.End();

            // Bottom face
            GL.Begin(PrimitiveType.Quads);
            GL.Normal3(0.0f, -1.0f, 0.0f);
            GL.Vertex3(sizeUnit, 0, -sizeUnit);
            GL.Vertex3(sizeUnit, 0, sizeUnit);
            GL.Vertex3(-sizeUnit, 0, sizeUnit);
            GL.Vertex3(-sizeUnit, 0, -sizeUnit);
            GL.End();
        }

        public static void DrawLyingCuboidXAxis(double sizeUnit, Color color)
        {
            GL.Color3(color);

            // Front face
            GL.Begin(PrimitiveType.Quads);
            GL.Normal3(0.0f, 0.0f, -1.0f);
            GL.Vertex3(2 * sizeUnit, 0, -sizeUnit);
            GL.Vertex3(2 * sizeUnit, 2 * sizeUnit, -sizeUnit);
            GL.Vertex3(2 * -sizeUnit, 2 * sizeUnit, -sizeUnit);
            GL.Vertex3(2 * -sizeUnit, 0, -sizeUnit);
            GL.End();

            // Back face
            GL.Begin(PrimitiveType.Quads);
            GL.Normal3(0.0f, 0.0f, 1.0f);
            GL.Vertex3(2 * sizeUnit, 0, sizeUnit);
            GL.Vertex3(2 * sizeUnit, 2 * sizeUnit, sizeUnit);
            GL.Vertex3(2 * -sizeUnit, 2 * sizeUnit, sizeUnit);
            GL.Vertex3(2 * -sizeUnit, 0, sizeUnit);
            GL.End();

            // Right face
            GL.Begin(PrimitiveType.Quads);
            GL.Normal3(1.0f, 0.0f, 0.0f);
            GL.Vertex3(2 * sizeUnit, 0, -sizeUnit);
            GL.Vertex3(2 * sizeUnit, 2 * sizeUnit, -sizeUnit);
            GL.Vertex3(2 * sizeUnit, 2 * sizeUnit, sizeUnit);
            GL.Vertex3(2 * sizeUnit, 0, sizeUnit);
            GL.End();

            // Left face
            GL.Begin(PrimitiveType.Quads);
            GL.Normal3(-1.0f, 0.0f, 0.0f);
            GL.Vertex3(2 * -sizeUnit, 0, sizeUnit);
            GL.Vertex3(2 * -sizeUnit, 2 * sizeUnit, sizeUnit);
            GL.Vertex3(2 * -sizeUnit, 2 * sizeUnit, -sizeUnit);
            GL.Vertex3(2 * -sizeUnit, 0, -sizeUnit);
            GL.End();

            // Top face
            GL.Begin(PrimitiveType.Quads);
            GL.Normal3(0.0f, 1.0f, 0.0f);
            GL.Vertex3(2 * sizeUnit, 2 * sizeUnit, sizeUnit);
            GL.Vertex3(2 * sizeUnit, 2 * sizeUnit, -sizeUnit);
            GL.Vertex3(2 * -sizeUnit, 2 * sizeUnit, -sizeUnit);
            GL.Vertex3(2 * -sizeUnit, 2 * sizeUnit, sizeUnit);
            GL.End();

            // Bottom face
            GL.Begin(PrimitiveType.Quads);
            GL.Normal3(0.0f, -1.0f, 0.0f);
            GL.Vertex3(2 * sizeUnit, 0, -sizeUnit);
            GL.Vertex3(2 * sizeUnit, 0, sizeUnit);
            GL.Vertex3(2 * -sizeUnit, 0, sizeUnit);
            GL.Vertex3(2 * -sizeUnit, 0, -sizeUnit);
            GL.End();
        }

        public static void DrawLyingCuboidZAxis(double sizeUnit, Color color)
        {
            GL.PushMatrix();

            GL.Rotate(90, 0, 1, 0);
            DrawLyingCuboidXAxis(sizeUnit, color);

            GL.PopMatrix();
        }
    }
}
