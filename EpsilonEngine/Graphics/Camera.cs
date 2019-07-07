using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonEngine.Graphics {
    public class Camera : Component {


        public readonly OpenTK.Matrix4 Projection;

        public Camera() {

            if(Game.Renderer.MainCamera == null) {
                Game.Renderer.MainCamera = this;
            }
            
            Projection = OpenTK.Matrix4.CreatePerspectiveFieldOfView(45f * (float)Nums.Angle.Deg2Rad, (float)Game.Window.Width / Game.Window.Height, .1f, 10000f);
        }

        public void ApplyToProgram(ShaderProgram p) {
            p.UniformMat4("view", OpenTK.Matrix4.LookAt(Transform.Position, Transform.Position + Transform.Forward, Transform.Up));
            p.UniformMat4("projection", this.Projection);
            p.SetVec3("viewPos", Transform.NuPos);

        }

    }
}
