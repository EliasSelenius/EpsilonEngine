using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Graphics.OpenGL4;

namespace EpsilonEngine.Graphics {
    public class ShaderProgram : Data.GLObj {


        public static readonly Dictionary<string, ShaderType> ShaderTypes = new Dictionary<string, ShaderType>() {
            { "VertexShader", ShaderType.VertexShader },
            { "FragmentShader", ShaderType.FragmentShader }
        };

        public ShaderProgram(string src) : base(GL.CreateProgram()) {

            var shaders = new List<Shader>();
            foreach (var item in ShaderTypes) {
                if(System.Text.RegularExpressions.Regex.IsMatch(src, item.Key)) {
                    var source = src.Replace("ShaderType", item.Key);
                    shaders.Add(new Shader(item.Value, source));
                }
            }

            this.CompileAndLink(shaders);

        }


        public ShaderProgram(params Shader[] shaders) : base(GL.CreateProgram()) {
            CompileAndLink(shaders);
        }


        protected void CompileAndLink(IEnumerable<Shader> shaders) {
            foreach (var shader in shaders) {
                GL.AttachShader(Handle, shader.Handle);
            }
            GL.LinkProgram(Handle);

            var info = GL.GetProgramInfoLog(Handle);
            if (!string.IsNullOrWhiteSpace(info)) {
                Console.WriteLine(info);
            }

            foreach (var shader in shaders) {
                GL.DetachShader(Handle, shader.Handle);
                shader.Dispose();
            }
        }


        public void Use() => GL.UseProgram(Handle);

        public void SetInt(int loc, int value) => GL.ProgramUniform1(Handle, loc, value);
        public void SetInt(string loc, int value) => GL.ProgramUniform1(Handle, GL.GetUniformLocation(Handle, loc), value);

        public void SetFloat(int loc, float value) => GL.ProgramUniform1(Handle, loc, value);
        public void SetFloat(string loc, float value) => GL.ProgramUniform1(Handle, GL.GetUniformLocation(Handle, loc), value);

        public void SetDouble(int loc, double value) => GL.ProgramUniform1(Handle, loc, value);
        public void SetDouble(string loc, double value) => GL.ProgramUniform1(Handle, GL.GetUniformLocation(Handle, loc), value);

        public void SetVec3(int loc, Nums.Vectors.Vec3 value) => GL.ProgramUniform3(Handle, loc, value.x, value.y, value.z);
        public void SetVec3(string loc, Nums.Vectors.Vec3 value) => GL.ProgramUniform3(Handle, GL.GetUniformLocation(Handle, loc), value.x, value.y, value.z);

        public void UniformMat4(int loc, Nums.Mat4 mat) => GL.ProgramUniformMatrix4(Handle, loc, 1, false, mat.AsArray());
        public void UniformMat4(string name, Nums.Mat4 mat) => GL.ProgramUniformMatrix4(Handle, GL.GetUniformLocation(Handle, name), 1, false, mat.AsArray());

        public void UniformMat4(int loc, OpenTK.Matrix4 mat) => GL.ProgramUniformMatrix4(Handle, loc, false, ref mat);
        public void UniformMat4(string name, OpenTK.Matrix4 mat) => GL.ProgramUniformMatrix4(Handle, GL.GetUniformLocation(Handle, name), false, ref mat);

        public void Test() {
            float[] ary = new float[16];
            GL.GetnUniform(Handle, GL.GetUniformLocation(Handle, "transform"), 16, ary);
        }

        public int GetUniformLocation(string name) => GL.GetUniformLocation(Handle, name);

        public override void Dispose(bool manual) {
            if(HasResources) {
                if(manual) {
                    GL.DeleteProgram(Handle);
                }
            }
        }
    }
}
