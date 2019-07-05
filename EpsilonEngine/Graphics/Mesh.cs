using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EpsilonEngine.Graphics.Data;
using Nums;
using Nums.Vectors;

namespace EpsilonEngine.Graphics {
    public class Mesh : RenderObject {

        private readonly VertexArray vao = new VertexArray();
        private readonly Buffer<float> vbo;

        private readonly int Count;

        public Mesh(float[] b) {
            Count = b.Length;
            vbo = b;
            vao.Bind(vbo, OpenTK.Graphics.OpenGL4.BufferTarget.ArrayBuffer);
            vao.AttributePointer(0, 3, OpenTK.Graphics.OpenGL4.VertexAttribPointerType.Float, false, sizeof(float) * 3, 0);
        }

        protected override void Draw() {
            vao.DrawArrays(OpenTK.Graphics.OpenGL4.PrimitiveType.Triangles, 0, Count);
        }
    }
}
