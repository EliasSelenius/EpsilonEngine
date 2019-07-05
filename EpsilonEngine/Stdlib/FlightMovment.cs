using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonEngine.Stdlib {
    public class FlightMovment : Component {


        public override void Start() {
            Game.Window.CursorVisible = false;
        }

        public override void Update() {

            var vec = Transform.Forward * Input.Keyboard.Axis(OpenTK.Input.Key.S, OpenTK.Input.Key.W) * .5f;
            vec += Transform.Left * Input.Keyboard.Axis(OpenTK.Input.Key.D, OpenTK.Input.Key.A) * .5f;
            Transform.Translate(vec);

            Transform.Rotate(Transform.Up, Input.Mouse.DeltaPos.X / 100);
            Transform.Rotate(Transform.Left, -Input.Mouse.DeltaPos.Y / 100);
            Transform.Rotate(Transform.Forward, -Input.Keyboard.Axis(OpenTK.Input.Key.Q, OpenTK.Input.Key.E) * .1f);
        }

    }
}
