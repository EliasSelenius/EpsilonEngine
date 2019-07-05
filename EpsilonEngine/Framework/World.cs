using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonEngine.Framework {
    public class World {

        private readonly List<Entity> entities = new List<Entity>();


        public void Start() {
            for (int i = 0; i < entities.Count; i++) {
                entities[i].Start();
            }
        }

        public void Update() {
            for (int i = 0; i < entities.Count; i++) {
                entities[i].Update();
            }
        }


        public void AddNewEntity(params Behaviors.Behavior[] behvs) {
            var e = new Entity();
            e.AddBehaviors(behvs);
            entities.Add(e);
        }

    }
}
