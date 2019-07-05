using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonEngine.Graphics {

    public static class IRenderableExtensions {

        public static void Enable(this IRenderable renderable, bool enable) {
            if (enable) {
                if (!Game.Renderer.ActiveInstances.Contains(renderable)) {
                    Game.Renderer.ActiveInstances.Add(renderable);
                }
            } else {
                Game.Renderer.ActiveInstances.Remove(renderable);
            }
        }
    }

    public interface IRenderable {
        void Render();
    }
}
