using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonEngine {
    public static class Time {

        public static double DeltaTime { get; private set; }


        public static void NextTick(double newdTime) {
            DeltaTime = newdTime;
        }

    }
}
