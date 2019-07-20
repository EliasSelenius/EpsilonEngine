using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonEngine.Graphics {

    public static class IRenderableExtensions {

        public static void EnableDraw(this IRenderable renderable, bool enable) {
            if (enable) {
                if (!renderable.IsDrawingEnabled()) {
                    Game.Renderer.ActiveInstances.Add(renderable);
                }
            } else {
                Game.Renderer.ActiveInstances.Remove(renderable);
            }
        }

        public static bool IsDrawingEnabled(this IRenderable r) => Game.Renderer.ActiveInstances.Contains(r);
    }

    public interface IRenderable {
        void Render();
    }
}
