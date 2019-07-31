using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonEngine.Input {
    public static class Keyboard {

        private static OpenTK.Input.KeyboardState state;


        internal static void NextTick() {
            state = OpenTK.Input.Keyboard.GetState();
        }

        public static bool IsKeyDown(OpenTK.Input.Key k) => state.IsKeyDown(k);
        public static bool IsKeyUp(OpenTK.Input.Key k) => state.IsKeyUp(k);


        public static int Axis(OpenTK.Input.Key a, OpenTK.Input.Key b) {
            var i = state.IsKeyDown(a) ? -1 : 0;
            return i + (state.IsKeyDown(b) ? 1 : 0);
        }

    }
}
