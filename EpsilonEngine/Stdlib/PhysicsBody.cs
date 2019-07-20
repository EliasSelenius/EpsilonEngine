using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nums.Vectors;

namespace EpsilonEngine.Stdlib {
    public class PhysicsBody : Component {

        public float Mass = 1;
        public Vec3 Velocity;

        public override void Update() {
            Transform.Translate(Velocity * (float)Time.Delta);
        }

        public void AddForce(Vec3 force) {
            Velocity += force / Mass;
        }

    }
}
