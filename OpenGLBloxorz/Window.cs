using OpenGLBloxorz.Enums;
using OpenGLBloxorz.Shapes;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Drawing;

namespace OpenGLBloxorz
{
    public class Window : GameWindow
    {
        private double cameraXAngle = -45;
        private double cameraYAngle = -45;

        private double sizeUnit = 0.075;

        private int numberOfTilesPerRow = 9;
        private Color primaryTileColor = Color.DarkGray;
        private Color secondaryTileColor = Color.DimGray;

        private Color cuboidColor = Color.LimeGreen;

        private double cuboidXPossitionFromCenter = 0;
        private double cuboidZPossitionFromCenter = 0;

        private CuboidOrientation cuboidOrientation = CuboidOrientation.Standing;

        private Mode mode = Mode.Standby;

        private double fallingSpeed = 5;

        private double translationXToRotationPoint = 0;
        private double translationZToRotationPoint = 0;

        private double cuboidFallingZDirectionAngle = 0;
        private double cuboidFallingXDirectionAngle = 0;

        private double MaxDistanceFromCenter => numberOfTilesPerRow * sizeUnit - 0.005;

        public Window() : base(600, 500, new GraphicsMode(32, 24, 0, 4), "Bloxorz") { }

        protected override void OnLoad(EventArgs e)
        {
            GL.Enable(EnableCap.Lighting);
            GL.Light(LightName.Light0, LightParameter.Ambient, new[] { 0.2f, 0.2f, 0.2f, 1.0f });
            GL.Light(LightName.Light0, LightParameter.Diffuse, new[] { 0.8f, 0.8f, 0.8f, 1.0f });
            GL.Light(LightName.Light0, LightParameter.Position, new[] { 1.0f, 0.0f, -1.0f });
            GL.Enable(EnableCap.Light0);

            GL.Enable(EnableCap.ColorMaterial);

            GL.Enable(EnableCap.DepthTest);
        }

        protected override void OnResize(EventArgs e)
        {
            if (Width > Height)
            {
                GL.Viewport((Width - Height) / 2, 0, Height, Height);
            }
            else
            {
                GL.Viewport(0, (Height - Width) / 2, Width, Width);
            }
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            if (mode == Mode.StandingCuboidFallingPositiveZDirection)
            {
                var nextCuboidPossitionFromCenter = cuboidZPossitionFromCenter + 3 * sizeUnit;

                if (nextCuboidPossitionFromCenter < MaxDistanceFromCenter)
                {
                    cuboidFallingZDirectionAngle += fallingSpeed;

                    translationXToRotationPoint = 0;
                    translationZToRotationPoint = sizeUnit;

                    if (cuboidFallingZDirectionAngle >= 90)
                    {
                        cuboidFallingZDirectionAngle = 0;
                        cuboidZPossitionFromCenter += 3 * sizeUnit;
                        mode = Mode.Standby;
                        cuboidOrientation = CuboidOrientation.LyingZAxis;
                    } 
                }
                else
                {
                    mode = Mode.Standby;
                }
            }
            else if (mode == Mode.StandingCuboidFallingNegativeZDirection)
            {
                var nextCuboidPossitionFromCenter = cuboidZPossitionFromCenter - 3 * sizeUnit;

                if (nextCuboidPossitionFromCenter > -MaxDistanceFromCenter)
                {
                    cuboidFallingZDirectionAngle -= fallingSpeed;

                    translationXToRotationPoint = 0;
                    translationZToRotationPoint = -sizeUnit;

                    if (cuboidFallingZDirectionAngle <= -90)
                    {
                        cuboidFallingZDirectionAngle = 0;
                        cuboidZPossitionFromCenter -= 3 * sizeUnit;
                        mode = Mode.Standby;
                        cuboidOrientation = CuboidOrientation.LyingZAxis;
                    } 
                }
                else
                {
                    mode = Mode.Standby;
                }
            }
            else if (mode == Mode.StandingCuboidFallingNegativeXDirection)
            {
                var nextCuboidPossitionFromCenter = cuboidXPossitionFromCenter - 3 * sizeUnit;

                if (nextCuboidPossitionFromCenter > -MaxDistanceFromCenter)
                {

                    cuboidFallingXDirectionAngle += fallingSpeed;

                    translationXToRotationPoint = -sizeUnit;
                    translationZToRotationPoint = 0;

                    if (cuboidFallingXDirectionAngle >= 90)
                    {
                        cuboidFallingXDirectionAngle = 0;
                        cuboidXPossitionFromCenter -= 3 * sizeUnit;
                        mode = Mode.Standby;
                        cuboidOrientation = CuboidOrientation.LyingXAxis;
                    }
                }
                else
                {
                    mode = Mode.Standby;
                }
            }
            else if (mode == Mode.StandingCuboidFallingPositiveXDirection)
            {
                var nextCuboidPossitionFromCenter = cuboidXPossitionFromCenter + 3 * sizeUnit;

                if (nextCuboidPossitionFromCenter < MaxDistanceFromCenter)
                {
                    cuboidFallingXDirectionAngle -= fallingSpeed;

                    translationXToRotationPoint = sizeUnit;
                    translationZToRotationPoint = 0;

                    if (cuboidFallingXDirectionAngle <= -90)
                    {
                        cuboidFallingXDirectionAngle = 0;
                        cuboidXPossitionFromCenter += 3 * sizeUnit;
                        mode = Mode.Standby;
                        cuboidOrientation = CuboidOrientation.LyingXAxis;
                    }
                }
                else
                {
                    mode = Mode.Standby;
                }
            }
            else if (mode == Mode.LyingZAxisCuboidFallingPositiveXDirection)
            {
                var nextCuboidPossitionFromCenter = cuboidXPossitionFromCenter + 2 * sizeUnit;

                if (nextCuboidPossitionFromCenter < MaxDistanceFromCenter)
                {
                    cuboidFallingXDirectionAngle -= fallingSpeed;

                    translationXToRotationPoint = sizeUnit;
                    translationZToRotationPoint = 0;

                    if (cuboidFallingXDirectionAngle <= -90)
                    {
                        cuboidFallingXDirectionAngle = 0;
                        cuboidXPossitionFromCenter += 2 * sizeUnit;
                        mode = Mode.Standby;
                        cuboidOrientation = CuboidOrientation.LyingZAxis;
                    }
                }
                else
                {
                    mode = Mode.Standby;
                }
            }
            else if (mode == Mode.LyingZAxisCuboidFallingNegativeXDirection)
            {
                var nextCuboidPossitionFromCenter = cuboidXPossitionFromCenter - 2 * sizeUnit;

                if (nextCuboidPossitionFromCenter > -MaxDistanceFromCenter)
                {
                    cuboidFallingXDirectionAngle += fallingSpeed;

                    translationXToRotationPoint = -sizeUnit;
                    translationZToRotationPoint = 0;

                    if (cuboidFallingXDirectionAngle >= 90)
                    {
                        cuboidFallingXDirectionAngle = 0;
                        cuboidXPossitionFromCenter -= 2 * sizeUnit;
                        mode = Mode.Standby;
                        cuboidOrientation = CuboidOrientation.LyingZAxis;
                    }
                }
                else
                {
                    mode = Mode.Standby;
                }
            }
            else if (mode == Mode.LyingZAxisCuboidRisingPositiveXDirection)
            {
                var nextCuboidPossitionFromCenter = cuboidZPossitionFromCenter + 3 * sizeUnit;

                if (nextCuboidPossitionFromCenter < MaxDistanceFromCenter)
                {
                    cuboidFallingZDirectionAngle += fallingSpeed;

                    translationXToRotationPoint = 0;
                    translationZToRotationPoint = 2 * sizeUnit;

                    if (cuboidFallingZDirectionAngle >= 90)
                    {
                        cuboidFallingZDirectionAngle = 0;
                        cuboidZPossitionFromCenter += 3 * sizeUnit;
                        mode = Mode.Standby;
                        cuboidOrientation = CuboidOrientation.Standing;
                    }
                }
                else
                {
                    mode = Mode.Standby;
                }
            }
            else if (mode == Mode.LyingZAxisCuboidRisingNegativeXDirection)
            {
                var nextCuboidPossitionFromCenter = cuboidZPossitionFromCenter - 3 * sizeUnit;

                if (nextCuboidPossitionFromCenter > -MaxDistanceFromCenter)
                {
                    cuboidFallingZDirectionAngle -= fallingSpeed;

                    translationXToRotationPoint = 0;
                    translationZToRotationPoint = -2 * sizeUnit;

                    if (cuboidFallingZDirectionAngle <= -90)
                    {
                        cuboidFallingZDirectionAngle = 0;
                        cuboidZPossitionFromCenter -= 3 * sizeUnit;
                        mode = Mode.Standby;
                        cuboidOrientation = CuboidOrientation.Standing;
                    }
                }
                else
                {
                    mode = Mode.Standby;
                }
            }
            else if (mode == Mode.LyingXAxisCuboidFallingPositiveZDirection)
            {
                var nextCuboidPossitionFromCenter = cuboidZPossitionFromCenter + 2 * sizeUnit;

                if (nextCuboidPossitionFromCenter < MaxDistanceFromCenter)
                {
                    cuboidFallingZDirectionAngle += fallingSpeed;

                    translationXToRotationPoint = 0;
                    translationZToRotationPoint = sizeUnit;

                    if (cuboidFallingZDirectionAngle >= 90)
                    {
                        cuboidFallingZDirectionAngle = 0;
                        cuboidZPossitionFromCenter += 2 * sizeUnit;
                        mode = Mode.Standby;
                        cuboidOrientation = CuboidOrientation.LyingXAxis;
                    }
                }
                else
                {
                    mode = Mode.Standby;
                }
            }
            else if (mode == Mode.LyingXAxisCuboidFallingNegativeZDirection)
            {
                var nextCuboidPossitionFromCenter = cuboidZPossitionFromCenter - 2 * sizeUnit;

                if (nextCuboidPossitionFromCenter > -MaxDistanceFromCenter)
                {
                    cuboidFallingZDirectionAngle -= fallingSpeed;

                    translationXToRotationPoint = 0;
                    translationZToRotationPoint = -sizeUnit;

                    if (cuboidFallingZDirectionAngle <= -90)
                    {
                        cuboidFallingZDirectionAngle = 0;
                        cuboidZPossitionFromCenter -= 2 * sizeUnit;
                        mode = Mode.Standby;
                        cuboidOrientation = CuboidOrientation.LyingXAxis;
                    }
                }
                else
                {
                    mode = Mode.Standby;
                }
            }
            else if (mode == Mode.LyingXAxisCuboidRisingNegativeZDirection)
            {
                var nextCuboidPossitionFromCenter = cuboidXPossitionFromCenter - 3 * sizeUnit;

                if (nextCuboidPossitionFromCenter > -MaxDistanceFromCenter)
                {
                    cuboidFallingXDirectionAngle += fallingSpeed;

                    translationXToRotationPoint = -2 * sizeUnit;
                    translationZToRotationPoint = 0;

                    if (cuboidFallingXDirectionAngle >= 90)
                    {
                        cuboidFallingXDirectionAngle = 0;
                        cuboidXPossitionFromCenter -= 3 * sizeUnit;
                        mode = Mode.Standby;
                        cuboidOrientation = CuboidOrientation.Standing;
                    }
                }
                else
                {
                    mode = Mode.Standby;
                }
            }
            else if (mode == Mode.LyingXAxisCuboidRisingPositiveZDirection)
            {
                var nextCuboidPossitionFromCenter = cuboidXPossitionFromCenter + 3 * sizeUnit;

                if (nextCuboidPossitionFromCenter < MaxDistanceFromCenter)
                {
                    cuboidFallingXDirectionAngle -= fallingSpeed;

                    translationXToRotationPoint = 2 * sizeUnit;
                    translationZToRotationPoint = 0;

                    if (cuboidFallingXDirectionAngle <= -90)
                    {
                        cuboidFallingXDirectionAngle = 0;
                        cuboidXPossitionFromCenter += 3 * sizeUnit;
                        mode = Mode.Standby;
                        cuboidOrientation = CuboidOrientation.Standing;
                    }
                }
                else
                {
                    mode = Mode.Standby;
                }
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.ClearColor(Color.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.LoadIdentity();

            GL.Rotate(cameraXAngle, 1, 0, 0);
            GL.Rotate(cameraYAngle, 0, 1, 0);

            GL.PushMatrix();

            GL.Translate(cuboidXPossitionFromCenter, 0, cuboidZPossitionFromCenter);

            GL.Translate(translationXToRotationPoint, 0, translationZToRotationPoint);
            GL.Rotate(cuboidFallingZDirectionAngle, 1, 0, 0);
            GL.Rotate(cuboidFallingXDirectionAngle, 0, 0, 1);
            GL.Translate(-translationXToRotationPoint, 0, -translationZToRotationPoint);

            if (cuboidOrientation == CuboidOrientation.Standing)
            {
                Cuboid.DrawStandingCuboid(sizeUnit, cuboidColor);
            }
            else if (cuboidOrientation == CuboidOrientation.LyingXAxis)
            {
                Cuboid.DrawLyingCuboidXAxis(sizeUnit, cuboidColor);
            }
            else if (cuboidOrientation == CuboidOrientation.LyingZAxis)
            {
                Cuboid.DrawLyingCuboidZAxis(sizeUnit, cuboidColor);
            }

            GL.PopMatrix();

            Floor.Draw(sizeUnit, numberOfTilesPerRow, primaryTileColor, secondaryTileColor);

            SwapBuffers();
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.W && mode == Mode.Standby && cuboidOrientation == CuboidOrientation.Standing)
            {
                mode = Mode.StandingCuboidFallingPositiveZDirection;
            }
            if (e.Key == Key.S && mode == Mode.Standby && cuboidOrientation == CuboidOrientation.Standing)
            {
                mode = Mode.StandingCuboidFallingNegativeZDirection;
            }
            if (e.Key == Key.A && mode == Mode.Standby && cuboidOrientation == CuboidOrientation.Standing)
            {
                mode = Mode.StandingCuboidFallingNegativeXDirection;
            }
            if (e.Key == Key.D && mode == Mode.Standby && cuboidOrientation == CuboidOrientation.Standing)
            {
                mode = Mode.StandingCuboidFallingPositiveXDirection;
            }

            if (e.Key == Key.W && mode == Mode.Standby && cuboidOrientation == CuboidOrientation.LyingZAxis)
            {
                mode = Mode.LyingZAxisCuboidRisingPositiveXDirection;
            }
            if (e.Key == Key.S && mode == Mode.Standby && cuboidOrientation == CuboidOrientation.LyingZAxis)
            {
                mode = Mode.LyingZAxisCuboidRisingNegativeXDirection;
            }
            if (e.Key == Key.A && mode == Mode.Standby && cuboidOrientation == CuboidOrientation.LyingZAxis)
            {
                mode = Mode.LyingZAxisCuboidFallingNegativeXDirection;
            }
            if (e.Key == Key.D && mode == Mode.Standby && cuboidOrientation == CuboidOrientation.LyingZAxis)
            {
                mode = Mode.LyingZAxisCuboidFallingPositiveXDirection;
            }

            if (e.Key == Key.W && mode == Mode.Standby && cuboidOrientation == CuboidOrientation.LyingXAxis)
            {
                mode = Mode.LyingXAxisCuboidFallingPositiveZDirection;
            }
            if (e.Key == Key.S && mode == Mode.Standby && cuboidOrientation == CuboidOrientation.LyingXAxis)
            {
                mode = Mode.LyingXAxisCuboidFallingNegativeZDirection;
            }
            if (e.Key == Key.A && mode == Mode.Standby && cuboidOrientation == CuboidOrientation.LyingXAxis)
            {
                mode = Mode.LyingXAxisCuboidRisingNegativeZDirection;
            }
            if (e.Key == Key.D && mode == Mode.Standby && cuboidOrientation == CuboidOrientation.LyingXAxis)
            {
                mode = Mode.LyingXAxisCuboidRisingPositiveZDirection;
            }


            if (e.Key == Key.Escape)
            {
                Exit();
            }
        }
    }
}

