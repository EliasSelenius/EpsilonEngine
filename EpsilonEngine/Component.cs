using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonEngine {
    public abstract class Component {

        public GameObject GameObject { get; private set; }
        public Transform Transform => GameObject.Transform;

        internal void Initialize(GameObject o) { 
            GameObject = o ?? throw new Exception("Component already initialized");

            Game.Window.UpdateFrame += Window_UpdateFrame;
        }

        private void Window_UpdateFrame(object sender, OpenTK.FrameEventArgs e) {
            this.Update();
        }

        internal void UnbindObject() {
            GameObject = null;

            Game.Window.UpdateFrame -= Window_UpdateFrame;
        }

        public Component GetComponent(Type type) => GameObject.GetComponent(type);
        public T GetComponent<T>() where T : Component => GameObject.GetComponent<T>();
        
        public virtual void Start() { }
        public virtual void Update() { }

    }
}
