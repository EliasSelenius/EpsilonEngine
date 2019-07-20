using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nums.Vectors;

namespace EpsilonEngine {
    public static class Game {

        public static readonly Window Window;
        public static readonly Graphics.Renderer Renderer;

        public static Scene ActiveScene { get; set; }

        static Game() {
            Window = new Window(1600, 900, "Untitled");
            Window.WindowState = OpenTK.WindowState.Maximized;
            Renderer = new Graphics.Renderer();
            ActiveScene = new Scene();
        }

        public static void Run() {
            Window.Initialize();
        }

        public static void Load() {
            Renderer.ShaderProgram = new Graphics.ShaderProgram(Graphics.Shaders.LightShader);
            ActiveScene.Start();
        }
        
    }
}
