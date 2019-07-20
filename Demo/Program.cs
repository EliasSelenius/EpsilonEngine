using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EpsilonEngine;
using EpsilonEngine.Stdlib;
using EpsilonEngine.Input;
using EpsilonEngine.Graphics;

using Nums;
using Nums.Vectors;

namespace Demo {
    class Program {
        static void Main(string[] args) {

            Game.ActiveScene.Init(new Camera(), new FlightMovment(), new GameController());

            int size = 100;
            var v = Vec3.Zero;
            var r = new Random();
            var amountOfPhysicsubes = 0;
            for (int i = 0; i < amountOfPhysicsubes; i++) {
                var g = Game.ActiveScene.Init(new Mesh(Primitive.CubePosAndNormals), new PhysicsBody());
                g.Transform.Position.X = (float)((r.NextDouble() * 2) - 1) * size;
                g.Transform.Position.Y = (float)((r.NextDouble() * 2) - 1) * size;
                g.Transform.Position.Z = (float)((r.NextDouble() * 2) - 1) * size;

                var s = (float)r.NextDouble() * 10;
                g.Transform.Scale *= s;
                var p = g.GetComponent<PhysicsBody>();
                p.Mass = s;
                p.AddForce((v - g.Transform.NuPos) * .1f);

            }

            var platformSize = 10;
            var platform = Game.ActiveScene.Init(new Mesh(Primitive.CubePosAndNormals));
            platform.Transform.Scale.X = platformSize;
            platform.Transform.Scale.Z = platformSize;
            platform.Transform.Position.Y = -5;
            for (int i = 0; i < 15; i++) {
                var col = Game.ActiveScene.Init(new Mesh(Primitive.CubePosAndNormals));
                col.Transform.Position.X = r.Next(-platformSize, platformSize) / 2;
                col.Transform.Position.Z = r.Next(-platformSize, platformSize) / 2;
                col.Transform.Scale.Y = r.Next(10, 20);
            }


            var chunk = Game.ActiveScene.Init(new TerrainChunk());
            chunk.Transform.Position.Y = -8;

            var plane = Game.ActiveScene.Init(new Plane());
            plane.Transform.Position.Y = 10;
            plane.Transform.Scale.Xz *= 10;

            for (int i = 0; i < 100; i++) {
                Console.WriteLine( i + "  :  " + Demo.Noise.RandomSeed(i));
            }

            ConsoleGL.Graph(x => (float)Math.Sin(x) + 1, 150, 20);
            ConsoleGL.Graph(x => Demo.Noise.RandomSeed((int)x) * 4f, 150, 20);

            

            Game.Run();
        }
        public static float Noise(float x) => NormSin(x) * Random(x); 
        static float Random(float x) {
            return (float)new Random((int)x).NextDouble();
        }
        static float NormSin(float x) {
            return (float)Math.Sin(x * Math.PI);
        }

        class GameController : Component {


            public override void Start() {

                Game.Renderer.ShaderProgram.SetVec3("material.ambient", new Vec3(1, .5f, .31f));
                Game.Renderer.ShaderProgram.SetVec3("material.diffuse", new Vec3(1, .5f, .31f));
                Game.Renderer.ShaderProgram.SetVec3("material.specular", new Vec3(.5f, .5f, .5f));
                Game.Renderer.ShaderProgram.SetFloat("material.shininess", 32f);

                Game.Renderer.ShaderProgram.SetVec3("light.ambient", new Vec3(0.2f));
                Game.Renderer.ShaderProgram.SetVec3("light.diffuse", new Vec3(.5f));
                Game.Renderer.ShaderProgram.SetVec3("light.specular", new Vec3(1));
            }

            public override void Update() {
                //Game.Renderer.ShaderProgram.SetVec3("lightColor", new Vec3((float)(Math.Sin(Time.SinceStart) + 1 ) / 2f, (float)(Math.Sin(Time.SinceStart / 2f) + 1) / 2f, (float)(Math.Sin(Time.SinceStart / 3f) + 1) / 2f));
                Game.Renderer.ShaderProgram.SetVec3("light.position", new Vec3((float)Math.Cos(Time.SinceStart), 0, (float)Math.Sin(Time.SinceStart)) * 20);

                var v = new Vec3((float)Math.Sin(Time.SinceStart * 2), (float)Math.Sin(Time.SinceStart * 0.7f), (float)Math.Sin(Time.SinceStart * 1.3f));
                //Game.Renderer.ShaderProgram.SetVec3("light.ambient", v * .2f);
                //Game.Renderer.ShaderProgram.SetVec3("light.diffuse", v * .5f);
            }
        }
    }
}
