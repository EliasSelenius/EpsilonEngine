using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonEngine.Graphics.Data {
    public abstract class GLObj : IDisposable {

        public const int NullHandle = 0;

        public int Handle { get; private set; } = NullHandle;

        public bool HasResources => Handle != NullHandle;

        public GLObj(int h) {
            Handle = h;
        }


        ~GLObj() {
            Dispose(false);
            Handle = NullHandle;
        }

        public void Dispose() {
            Dispose(true);
            Handle = NullHandle;
            GC.SuppressFinalize(this);
        }

        protected abstract void Dispose(bool manual);

        public override string ToString() => GetType().Name + $" ({Handle})";

        public override bool Equals(object obj) => obj is GLObj && (obj as GLObj).Handle.Equals(Handle);
        public override int GetHashCode() => Handle.GetHashCode();
    }
}
