using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Graphics.OpenGL4;

using Nums;
using Nums.Vectors;

namespace EpsilonEngine.Graphics {

    [Obsolete]
    public class MeshRenderer : Framework.Behaviors.Behavior {

        private readonly Data.VertexArray vao;

        private readonly Data.Buffer<float> vbo;

        private int count;

        
        public MeshRenderer(float[] poses) {
            vao = new Data.VertexArray();
            count = poses.Length;
            vbo = poses;
            vao.Bind(vbo, BufferTarget.ArrayBuffer);
            vao.AttributePointer(0, 3, VertexAttribPointerType.Float, false, Nums.Vectors.Vec3.ByteSize, 0);
        }
        
        public override void Start() {
            entity.transform.Position += OpenTK.Vector3.UnitX * 3;
        }

        double time;
        public override void Update() {

            time += 0.01;
            //entity.transform.Position = (Vec3.UnitX * (float)Math.Sin(time)) + (Vec3.UnitY * (float)Math.Cos(time));
            entity.transform.Rotate(.01f, 0f, 0f);
        }

        //private OpenTK.Matrix4 mat = OpenTK.Matrix4.Identity;

        public void Render() {

            Game.Renderer.ShaderProgram.UniformMat4("model", entity.transform.Matrix);


            vao.DrawArrays(PrimitiveType.Triangles, 0, count);
            //vao.DrawElements(PrimitiveType.Triangles, count, DrawElementsType.UnsignedInt);
        }
    }
}
