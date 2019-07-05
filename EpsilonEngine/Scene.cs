using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonEngine {
    public class Scene {

        public readonly List<GameObject> GameObjects = new List<GameObject>();

        private bool _hasStarted = false;

        internal void Start() {
            for (int i = 0; i < GameObjects.Count; i++) {
                GameObjects[i].Start();
            }
            _hasStarted = true;
        }


        public GameObject Init(params Component[] comps) {
            var g = new GameObject();
            g.AddComps(comps);
            GameObjects.Add(g);
            if (_hasStarted) {
                g.Start();
            }
            return g;
        }

    }
}
