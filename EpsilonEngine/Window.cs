using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
namespace EpsilonEngine {
    public class Window : OpenTK.GameWindow {

        public Window(int width, int height, string title)
            : base(width, height, OpenTK.Graphics.GraphicsMode.Default, title,
                OpenTK.GameWindowFlags.Default, OpenTK.DisplayDevice.Default, 4, 5,
                OpenTK.Graphics.GraphicsContextFlags.ForwardCompatible) {
        }


        public void Initialize() {
            this.Run();
        }

        protected override void OnLoad(EventArgs e) {
            GL.ClearColor(0, 0, 0, 1);
            Game.Load();
        }

        protected override void OnRenderFrame(FrameEventArgs e) {
            Game.Renderer.Render();
            SwapBuffers();
        }

        protected override void OnResize(EventArgs e) {
            GL.Viewport(0, 0, Width, Height);
        }

        protected override void OnUnload(EventArgs e) {
        }

        protected override void OnUpdateFrame(FrameEventArgs e) {
            Time.NextTick(e.Time);
            Input.Mouse.NextTick();
            Input.Keyboard.NextTick();
            base.OnUpdateFrame(e);
        }
    }
}
