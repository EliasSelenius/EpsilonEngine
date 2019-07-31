using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonEngine {
    public class Transform {

        public OpenTK.Matrix4 Matrix => OpenTK.Matrix4.CreateScale(Scale) * OpenTK.Matrix4.CreateFromQuaternion(Rotation) * OpenTK.Matrix4.CreateTranslation(Position);

        public OpenTK.Vector3 Position;
        public OpenTK.Vector3 Scale = OpenTK.Vector3.One;
        public OpenTK.Quaternion Rotation = OpenTK.Quaternion.Identity;

        public Nums.Vectors.Vec3 NuPos => new Nums.Vectors.Vec3(Position.X, Position.Y, Position.Z);

        public OpenTK.Vector3 Forward => Matrix.Column2.Xyz;
        public OpenTK.Vector3 Left => Matrix.Column0.Xyz;
        public OpenTK.Vector3 Up => Matrix.Column1.Xyz;

        public void Translate(OpenTK.Vector3 v) => Position += v;

        public void Translate(float x, float y, float z) {
            Position.X += x; Position.Y += y; Position.Z += z;
        }

        public void Translate(Nums.Vectors.Vec3 v) {
            Position.X += v.x; Position.Y += v.y; Position.Z += v.z;
        }

        public void Rotate(float x, float y, float z) {
            Rotation *= OpenTK.Quaternion.FromEulerAngles(x, y, z);
            Rotation.Normalize();
        }

        public void Rotate(OpenTK.Vector3 vec, float angle) => Rotation *= OpenTK.Quaternion.FromAxisAngle(vec, angle);
        public void Rotate(float x, float y, float z, float angle) => Rotation *= OpenTK.Quaternion.FromAxisAngle(new OpenTK.Vector3(x, y, z), angle);


        public void LookAt(OpenTK.Vector3 at) => LookAt(at, OpenTK.Vector3.UnitY);
        public void LookAt(OpenTK.Vector3 at, OpenTK.Vector3 up) {
            var zaxis = (at - Position).Normalized();
            var xaxis = OpenTK.Vector3.Cross(up, zaxis).Normalized();
            var yaxis = OpenTK.Vector3.Cross(zaxis, xaxis);

            var mat = new OpenTK.Matrix3(xaxis, yaxis, zaxis);



            Rotation = mat.ExtractRotation();

        }

    }
}
