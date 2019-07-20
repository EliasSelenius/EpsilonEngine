using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Math;

namespace Demo {
    public static class Noise {

        public static readonly Random random = new Random();

        public static float InterpolatedRandom(float x) {
            var r1 = RandomSeed((int)Floor(x));
            var r2 = RandomSeed((int)Ceiling(x));
            return Lerp(r1, r2, x - (float)Floor(x));
        }

        public static float Lerp(float x, float y, float t) => x + (y - x) * t;

        public static float RandomSeed(int seed) => (float)new Random(seed * seed).NextDouble();

        public static float Random01() => (float)random.NextDouble();

        public static float Perlin1D(float x) {
            return (float)(x - Floor(x) + 1) * (float)((random.NextDouble() * 2) - 1);
        }

        public static float Perlin2D(float x, float z) {
            var xoff = x - Floor(x);
            var zoff = z - Floor(z);
            var rx = (float)(RandomSeed((int)x) * 2) - 1;
            var rz = (float)(RandomSeed((int)z) * 2) - 1;
            return (float)((xoff * rx) + (zoff * rz));
        }

   
    }
}
