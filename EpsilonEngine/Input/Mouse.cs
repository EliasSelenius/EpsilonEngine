using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonEngine.Input {
    public static class Mouse {

        private static OpenTK.Input.MouseState state;

        public static OpenTK.Vector2 LastPos { get; private set; }
        public static OpenTK.Vector2 Pos => new OpenTK.Vector2(state.X, state.Y);
        public static OpenTK.Vector2 DeltaPos => Pos - LastPos;

        public static void NextTick() {
            LastPos = Pos;
            state = OpenTK.Input.Mouse.GetState();
        }


    }
}
