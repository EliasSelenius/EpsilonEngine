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
            Renderer = new Graphics.Renderer();
            ActiveScene = new Scene();
        }

        public static void Run() {
            Window.Initialize();
        }

        public static void Load() {
            Renderer.ShaderProgram = new Graphics.ShaderProgram(Graphics.Shaders.BasicLightShader);
            Renderer.ShaderProgram.SetVec3("objectColor", Vec3.One);
            Renderer.ShaderProgram.SetVec3("lightColor", Vec3.One);
            Renderer.ShaderProgram.SetVec3("lightPos", Vec3.Zero);
            ActiveScene.Start();
        }
        
    }
}
