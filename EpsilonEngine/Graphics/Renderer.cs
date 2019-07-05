using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Graphics.OpenGL4;

namespace EpsilonEngine.Graphics {
    public class Renderer {

        public readonly List<IRenderable> ActiveInstances = new List<IRenderable>();
        public ShaderProgram ShaderProgram;
        public Camera MainCamera;

        public void Render() {

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            ShaderProgram.Use();
            MainCamera.ApplyToProgram(ShaderProgram);

            for (int i = 0; i < ActiveInstances.Count; i++) {
                ActiveInstances[i].Render();
            }

            GL.Flush();

        }

    }
}
