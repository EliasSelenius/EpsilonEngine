using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo {
    public static class ConsoleGL {

        public static void Graph(Func<float, float> func, int width, int height) {
            StringBuilder bld = new StringBuilder();

            var graph = new char[width, height];

            float maxVal = 0;
            float minVal = 0;
            var values = new float[width];
            for (int i = 0; i < width; i++) {
                var r = func(i);
                if (r > maxVal) {
                    maxVal = r;
                } else if(r < minVal) {
                    minVal = r;
                }
                values[i] = r;
            }

            for (int i = 0; i < height; i++) {
                for (int j = 0; j < width; j++) {
                    graph[j, i] = ' ';
                }
            }

            for (int i = 0; i < width; i++) {
                
                graph[i, (int)Math.Round(values[i])] = '*';
            }

            for (int i = 0; i < height; i++) {
                for (int j = 0; j < width; j++) {
                    var c = graph[j, i];
                    bld.Append(c);
                }
                bld.AppendLine();
            }

            Console.WriteLine(bld.ToString());
        }
    }
}
