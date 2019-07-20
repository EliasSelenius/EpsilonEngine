using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonEngine {
    public static class Time {

        public static double Delta { get; private set; }
        public static double SinceStart { get; private set; } = 0;

        public static void NextTick(double newdTime) {
            Delta = newdTime;
            SinceStart += newdTime;
        }

    }
}
