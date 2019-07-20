using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Graphics.OpenGL4;

namespace EpsilonEngine.Graphics.Data {
    public class VertexArray : GLObj {

        
        public VertexArray() : base(GL.GenVertexArray()) {

        }

        public void Bind() => GL.BindVertexArray(Handle);
        public static void Unbind() => GL.BindVertexArray(NullHandle);

        public void Bind<T>(Buffer<T> buffer, BufferTarget target) where T : struct {
            Bind();
            buffer.Bind(target);
            Unbind();
        }

        public void DrawElements(PrimitiveType ptype, int count, DrawElementsType etype) {
            Bind();
            GL.DrawElements(ptype, count, etype, 0);
            Unbind();
        }

        public void DrawArrays(PrimitiveType type, int first, int count) {
            Bind();
            GL.DrawArrays(type, first, count);
            Unbind();
        }

        public void AttributePointer(int loc, int size, VertexAttribPointerType type, bool normalized, int stride, int offset) {
            Bind();
            GL.VertexAttribPointer(loc, size, type, normalized, stride, offset);
            GL.EnableVertexAttribArray(loc);
            Unbind();
        }

        protected override void Dispose(bool manual) {
            if (HasResources) {
                if(manual) {
                    GL.DeleteVertexArray(Handle);
                }
            }
        }
    }
}
