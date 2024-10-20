using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Platform.Windows;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirineiV_temaCLI
{
    class Window3D : GameWindow
    {
        KeyboardState previousKeyboard;
        MouseState previousMouseState;
        Randomizer rando;
        Color DEFAULT_BKG_COLOR = Color.SkyBlue;
        public Window3D() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;

            DisplayHelp();
            rando = new Randomizer();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //Setare culoare de fundal
            GL.ClearColor(DEFAULT_BKG_COLOR);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            //Setam Viewport
            GL.Viewport(0, 0, this.Width, this.Height);

            //Setam Perspectiva
            Matrix4 pers = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)Width/(float)Height, 1, 250);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref pers);

            //Setam Camera
            Matrix4 camera = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref camera);

        }


        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            //Logic Code
            KeyboardState currentKeyboard = Keyboard.GetState();
            MouseState currentMouseState = Mouse.GetState();

            if (currentKeyboard[Key.Escape])
            {
                Exit();
            }
            if (currentKeyboard[Key.H] && !previousKeyboard[Key.H])
            {
                DisplayHelp();
            }

            if (currentKeyboard[Key.B] && !previousKeyboard[Key.B])
            {
                GL.ClearColor(rando.GenerateRandomColor());
            }

            if (currentKeyboard[Key.R] && !previousKeyboard[Key.R])
            {
                GL.ClearColor(DEFAULT_BKG_COLOR);
            }
            //Randomizam Culoarea Backgroundului atunci cand Mouseul se misca
            if (currentMouseState != previousMouseState)
            {
                GL.ClearColor(rando.GenerateRandomColor());
            }

            previousMouseState = currentMouseState;
            previousKeyboard = currentKeyboard;
            //End Logic Code
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            //Render Code

            //End Render Code

            SwapBuffers();
        }
        private void DisplayHelp()
        {
            Console.WriteLine("\n  Menu");
            Console.WriteLine("Esc - Exit");
            Console.WriteLine("H - Help");
            Console.WriteLine("B - Random Color");
            Console.WriteLine("R - Reset Color");

        }
    }
}
