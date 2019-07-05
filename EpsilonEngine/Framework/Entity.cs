using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonEngine.Framework {
    public class Entity {

        public readonly Transform transform = new Transform();

        private List<Behaviors.Behavior> Behaviors = new List<Behaviors.Behavior>();

        public void AddBehavior(Behaviors.Behavior b) {
            Behaviors.Add(b);
            b.Init(this);
        }

        public void AddBehaviors(Behaviors.Behavior[] behvs) {
            foreach (var item in behvs) {
                AddBehavior(item);
            }
        }

        public T GetBehavior<T>() where T : Behaviors.Behavior => (T)GetBehavior(typeof(T));

        public Behaviors.Behavior GetBehavior(Type type) => (from o in Behaviors
                                                             where type.IsInstanceOfType(o)
                                                             select o).FirstOrDefault();

        public void RemoveBehavior(Behaviors.Behavior b) => Behaviors.Remove(b);
        public void RemoveBehavior(Type type) => RemoveBehavior(GetBehavior(type));
        public void RemoveBehavior<T>() where T : Behaviors.Behavior => RemoveBehavior(GetBehavior<T>());

        public void Start() {
            for (int i = 0; i < Behaviors.Count; i++) {
                Behaviors[i].Start();
            }
        }

        public void Update() {
            for (int i = 0; i < Behaviors.Count; i++) {
                Behaviors[i].Update();
            }
        }

    }
}
