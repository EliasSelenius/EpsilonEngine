using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonEngine {
    public class GameObject {

        public readonly Transform Transform = new Transform();

        private readonly List<Component> Components = new List<Component>();

        internal void Start() {
            for (int i = 0; i < Components.Count; i++) {
                Components[i].Start();
            }
        }

        #region AddGetRemove Components
        public void AddComp(Component c) {
            Components.Add(c);
            c.Initialize(this);
        }

        public void AddComps(params Component[] cs) {
            foreach (var item in cs) {
                AddComp(item);
            }
        }

        public Component GetComponent(Type type) => (from o in Components
                                                     where type.IsInstanceOfType(o)
                                                     select o).FirstOrDefault();

        public T GetComponent<T>() where T : Component => GetComponent(typeof(T)) as T;

        public void RemoveComp(Component c) {
            if(Components.Remove(c)) {
                c.UnbindObject();
            }
        }

        public void RemoveComp(Type type) => RemoveComp(GetComponent(type));
        public void RemoveComp<T>() where T : Component => RemoveComp(typeof(T));
        #endregion
    }
}
