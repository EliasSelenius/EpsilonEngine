using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonEngine.Framework.Behaviors {
    public abstract class Behavior {

        public Entity entity { get; private set; }

        public void Init(Entity e) {
            entity = e;
        }


        public virtual void Start() { }
        public virtual void Update() { }

    }
}
