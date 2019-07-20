using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Graphics.OpenGL4;

namespace EpsilonEngine.Graphics.Data {
    public class Texture2D : GLObj {

        public int Width { get; private set; }
        public int Height { get; private set; }

        /// <summary>
        /// This texture's pixels. <br/>
        /// Remember to invoke Apply() after altering this 
        /// </summary>
        public readonly Color8bit[,] Pixels;

        public Texture2D(int w, int h) : base(GL.GenTexture()) {
            Width = w; Height = h;
            Pixels = new Color8bit[Width, Height];
        }

        public Texture2D(System.Drawing.Bitmap b) : this(b.Width, b.Height) {
            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    Pixels[x, y] = b.GetPixel(x, y);
                }
            }
            Apply();
        }

        public void Bind() => GL.BindTexture(TextureTarget.Texture2D, Handle);

        public static void Unbind() => GL.BindTexture(TextureTarget.Texture2D, NullHandle);

        public void Apply() {
            Bind();
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, Width, Height, 0, PixelFormat.Rgba, PixelType.Byte, Pixels);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
            Unbind();
        }

        protected override void Dispose(bool manual) {
            if (manual) {
                if (HasResources) {
                    GL.DeleteTexture(Handle);
                }
            }
        }
    }
}
