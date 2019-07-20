using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Graphics.OpenGL4;

namespace EpsilonEngine.Graphics.Data {
    public class Buffer<T> : GLObj where T : struct {

        public Buffer() : base(GL.GenBuffer()) {

        }

        public Buffer(BufferTarget target, T[] data, BufferUsageHint hint = BufferUsageHint.StaticDraw) : this() {
            Init(target, data, hint);
        }

        public void Bind(BufferTarget target) => GL.BindBuffer(target, Handle);
        public static void Unbind(BufferTarget target) => GL.BindBuffer(target, NullHandle);

        public void Init(BufferTarget target, T[] data, BufferUsageHint hint = BufferUsageHint.StaticDraw) {
            Bind(target);
            GL.BufferData(target, System.Runtime.InteropServices.Marshal.SizeOf(typeof(T)) * data.Length, data, hint);
            Unbind(target);
        }

        public static implicit operator Buffer<T>(T[] ts) => new Buffer<T>(BufferTarget.ArrayBuffer, ts);


        protected override void Dispose(bool manual) {
            if (manual) { GL.DeleteBuffer(Handle); }
        }
    }
}
