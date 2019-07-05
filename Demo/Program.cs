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
            for (int i = 0; i < 70; i++) {
                var g = Game.ActiveScene.Init(new Mesh(Primitive.Cube), new PhysicsBody());
                g.Transform.Position.X = (float)((r.NextDouble() * 2) - 1) * size;
                g.Transform.Position.Y = (float)((r.NextDouble() * 2) - 1) * size;
                g.Transform.Position.Z = (float)((r.NextDouble() * 2) - 1) * size;

                var s = (float)r.NextDouble() * 10;
                g.Transform.Scale *= s;
                var p = g.GetComponent<PhysicsBody>();
                p.Mass = s;
                p.AddForce((v - g.Transform.NuPos) * .1f);

            }


            Game.Run();
        }
    }
}
