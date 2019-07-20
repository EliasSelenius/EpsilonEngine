using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Math;

namespace Demo {
    class NoiseMap {

        public readonly int Size;
        public readonly int Seed;

        private Random random;
        private readonly float[,] values;

        public NoiseMap(int seed, int size) {
            Seed = seed;
            Size = size;
            values = new float[Size, Size];

            Generate();
        }

        public void Generate() {
            random = new Random(Seed);
            for (int x = 0; x < Size; x++) {
                for (int y = 0; y < Size; y++) {
                    values[x, y] = (float)random.NextDouble();
                }
            }
        }

        public float this[int x, int y] {
            get => values[x, y];
        }

        public float LinearEvaluation(float x, float y) {
            var xpos = x * Size;
            var xindex1 = Floor(xpos);
            var xindex2 = Ceiling(xpos);
            return 0;
        }
    }
}
