using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonEngine.Framework.Behaviors {
    public class CameraFlightMovment : Behavior {


        public override void Start() {
        }

        public override void Update() {

            var vec = entity.transform.Forward * Input.Keyboard.Axis(OpenTK.Input.Key.S, OpenTK.Input.Key.W) * .5f;
            vec += entity.transform.Left * Input.Keyboard.Axis(OpenTK.Input.Key.D, OpenTK.Input.Key.A) * .5f;
            entity.transform.Translate(vec);

            //entity.transform.Rotate(0, Input.Mouse.DeltaPos.X / 100, 0);

            /*
            Console.WriteLine(entity.transform.Matrix + "\n");
            Console.WriteLine(entity.transform.Forward + "\n");
            Console.WriteLine(entity.transform.Matrix * OpenTK.Vector4.UnitZ + "\n");
            */

            entity.transform.Rotate(entity.transform.Up, Input.Mouse.DeltaPos.X / 100);
            entity.transform.Rotate(entity.transform.Left, -Input.Mouse.DeltaPos.Y / 100);
            entity.transform.Rotate(entity.transform.Forward, -Input.Keyboard.Axis(OpenTK.Input.Key.Q, OpenTK.Input.Key.E) * .1f);
        }

    }
}
