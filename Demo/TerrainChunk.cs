using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EpsilonEngine;
using EpsilonEngine.Graphics;
using EpsilonEngine.Graphics.Data;

using static System.Math;

namespace Demo {
    class TerrainChunk : RenderObject {

        private VertexArray vao;
        private Buffer<float> vbo;
        private Buffer<uint> ebo;

        private static int size = 256;
        private static int numTriangles => ((size - 1) * (size - 1)) * 2;

        private int count;

        private NoiseMap map;

        public override void Start() {
            this.EnableDraw(true); // set to be rendered

            map = new NoiseMap(0, size);

            vao = new VertexArray();
            vbo = GenVertices();
            vao.Bind(vbo, OpenTK.Graphics.OpenGL4.BufferTarget.ArrayBuffer);
            vao.AttributePointer(0, 3, OpenTK.Graphics.OpenGL4.VertexAttribPointerType.Float, false, sizeof(float) * 6, 0);
            vao.AttributePointer(1, 3, OpenTK.Graphics.OpenGL4.VertexAttribPointerType.Float, false, sizeof(float) * 6, sizeof(float) * 3);
            ebo = GenIndices();
            vao.Bind(ebo, OpenTK.Graphics.OpenGL4.BufferTarget.ElementArrayBuffer);

        }


        uint[] GenIndices() {
            List<uint> res = new List<uint>();
            for (int x = 0; x < size-1; x++) {
                for (int z = 0; z < size-1; z++) {
                    // face 1:
                    res.Add((uint)(x + z * size));
                    res.Add((uint)(x + 1 + z * size));
                    res.Add((uint)((x + z * size) + size+1));

                    // face 2:
                    res.Add((uint)(x + z * size));
                    res.Add((uint)((x + z * size) + size + 1));
                    res.Add((uint)(x + size + z * size));
                }

            }
            count = res.Count;
            return res.ToArray();
        }

        float[] GenVertices() {
            List<float> verts = new List<float>();
            for (int x = 0; x < size; x++) {
                for (int z = 0; z < size; z++) {
                    var xpos = x - size / 2f;
                    var zpos = z - size / 2f;
                    verts.Add(xpos);
                    verts.Add(map.LinearEvaluation(x / size, z / size));
                    verts.Add(zpos);

                    // Normal
                    verts.Add(0);
                    verts.Add(1);
                    verts.Add(0);
                }
            }
            return verts.ToArray();
        }

        static Random random = new Random();
        float Noise(float x, float z) {
            //return Random(x) * 3;
            return Demo.Noise.Perlin2D(x / 20f, z / 20f) * 5f;
            //return Demo.Noise.RandomSeed((int)x);
            //return Demo.Noise.Random01();
            //return (float)new Random((int)(x * z)).NextDouble() * 5f;
            //return (float)(Sin(x / 3f) + Cos(z));
        }

        float Random(float x) {
            var r = new Random((int)x * 100).NextDouble();
            return (float)(Sin(x * (PI / 2)) * r);
        }

        protected override void Draw() {
            vao.DrawElements(OpenTK.Graphics.OpenGL4.PrimitiveType.Triangles, count, OpenTK.Graphics.OpenGL4.DrawElementsType.UnsignedInt);
            
        }
    }
}
