using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Graphics.OpenGL4;

namespace EpsilonEngine.Graphics {
    public class Shader : Data.GLObj {

        public Shader(ShaderType type, string src) : base(GL.CreateShader(type)) {
            GL.ShaderSource(Handle, src);
            GL.CompileShader(Handle);

            var info = GL.GetShaderInfoLog(Handle);
            if(!string.IsNullOrWhiteSpace(info)) {
                Console.WriteLine(info); // TODO: add proper logger (with scriptor maybe?)
            }

            //Console.WriteLine("Compiling: " + type + "\n\n" + src);

        }

        public override void Dispose(bool manual) {
            if(HasResources) {
                GL.DeleteShader(Handle);
            }
        }
    }
}
