using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EpsilonEngine.Graphics;
using EpsilonEngine.Graphics.Data;


namespace EpsilonEngine.Stdlib {
    public class Plane : RenderObject {
        private VertexArray vao;
        private Buffer<float> vbo;
        private Buffer<uint> ebo;

        public override void Start() {
            base.Start();

            vbo = Primitive.Plane;
            ebo = Primitive.PlaneIndices;

            vao = new VertexArray();
            vao.Bind(vbo, OpenTK.Graphics.OpenGL4.BufferTarget.ArrayBuffer);
            vao.Bind(ebo, OpenTK.Graphics.OpenGL4.BufferTarget.ElementArrayBuffer);

            vao.AttributePointer(0, 3, OpenTK.Graphics.OpenGL4.VertexAttribPointerType.Float, false, sizeof(float) * 8, 0);
            vao.AttributePointer(1, 3, OpenTK.Graphics.OpenGL4.VertexAttribPointerType.Float, false, sizeof(float) * 8, sizeof(float) * 5);
            vao.AttributePointer(2, 2, OpenTK.Graphics.OpenGL4.VertexAttribPointerType.Float, false, sizeof(float) * 8, sizeof(float) * 3);

        }

        protected override void Draw() {
            vao.DrawElements(OpenTK.Graphics.OpenGL4.PrimitiveType.Triangles, 6, OpenTK.Graphics.OpenGL4.DrawElementsType.UnsignedInt);
        }
    }
}
