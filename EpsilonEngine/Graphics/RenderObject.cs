using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonEngine.Graphics {
    public abstract class RenderObject : Component, IRenderable {



        public override void Start() {
            this.EnableDraw(true);
        }

        public void Render() {
            Game.Renderer.ShaderProgram.UniformMat4("model", Transform.Matrix);
            Draw();
        }

        protected abstract void Draw();

        public bool Enabled {
            get => Game.Renderer.ActiveInstances.Contains(this);
            set => this.EnableDraw(value);
        }

    }
}
