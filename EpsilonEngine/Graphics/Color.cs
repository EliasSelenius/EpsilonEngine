using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonEngine.Graphics {
    public struct Color8bit {
        public byte Red, Green, Blue, Alpha;

        public Color8bit(byte rgb) {
            Red = Green = Blue = rgb; Alpha = byte.MaxValue;
        }
        public Color8bit(byte rgb, byte a) {
            Red = Green = Blue = rgb; Alpha = a;
        }
        public Color8bit(byte r, byte g, byte b) {
            Red = r; Green = g; Blue = b; Alpha = byte.MaxValue;
        }
        public Color8bit(byte r, byte g, byte b, byte a) {
            Red = r; Green = g; Blue = b; Alpha = a;
        }


        public static implicit operator Color8bit(System.Drawing.Color sd) => new Color8bit(sd.R, sd.G, sd.B, sd.A);

        public static explicit operator Color8bit(Color32bit c) {
            return new Color8bit((byte)(c.Red * 255), (byte)(c.Green * 255), (byte)(c.Blue * 255), (byte)(c.Alpha * 255));
        }

        public static explicit operator Color8bit(OpenTK.Graphics.Color4 tkc) {
            return new Color8bit((byte)(tkc.R * 255), (byte)(tkc.G * 255), (byte)(tkc.B * 255), (byte)(tkc.A * 255));
        }
    }

    public struct Color32bit {
        public float Red, Green, Blue, Alpha;

        public Color32bit(float rgb) {
            Red = Green = Blue = rgb; Alpha = 1f;
        }
        public Color32bit(float rgb, float a) {
            Red = Green = Blue = rgb; Alpha = a;
        }
        public Color32bit(float r, float g, float b) {
            Red = r; Green = g; Blue = b; Alpha = 1f;
        }
        public Color32bit(float r, float g, float b, float a) {
            Red = r; Green = g; Blue = b; Alpha = a;
        }


        public static implicit operator Color32bit(Color8bit c) {
            return new Color32bit(c.Red / 255f, c.Green / 255f, c.Blue / 255f, c.Alpha / 255f);
        }
        public static implicit operator Color32bit(OpenTK.Graphics.Color4 tkc) => new Color32bit(tkc.R, tkc.G, tkc.B, tkc.A);
    }
}
