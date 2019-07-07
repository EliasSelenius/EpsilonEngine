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

            Game.ActiveScene.Init(new Camera(), new FlightMovment());

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

            var platformSize = 50;
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

            Game.Run();
        }
    }
}
