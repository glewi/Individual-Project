using System;
using System.Collections.Generic;
using System.Text;
using PlotterConversionSystem.IRTools;

namespace PlotterConversionSystem.Backends
{
    public class HPGLWriter : IWriter
    {
        private StringBuilder hpglbuilder = new StringBuilder();
        private const int defaultPen = 1;
        private const double resolution = 0.5;

        private string initialiseFile()
        {
            string cmd = $"IN;\n" +
                         $"SP{defaultPen};";
            return cmd;
        }

        private string circleCommand(SerialiseObject serialisedToken)
        {
            Dictionary<string, string> keys = serialisedToken.attributes;
            string x, y, r;
            keys.TryGetValue("x", out x);
            keys.TryGetValue("y", out y);
            keys.TryGetValue("r", out r);

            string cmd = $"PU {x},{y};\n" +
                         $"CI{r},{resolution};";

            return cmd;
        }

        private string rectangleCommand(SerialiseObject serialisedToken)
        {
            Dictionary<string, string> keys = serialisedToken.attributes;
            string x, y, width, height, rx, ry;

            keys.TryGetValue("x", out x);
            keys.TryGetValue("y", out y);
            keys.TryGetValue("width", out width);
            keys.TryGetValue("height", out height);
            keys.TryGetValue("rx", out rx);
            keys.TryGetValue("ry", out ry);

            string cmd = $"PA {x},{y};\n" +
                         $"PD;\n" +
                         $"PR{x},{width};\n" +
                         $"PR{height},{width};\n" +
                         $"PR{y},{height};\n" +
                         $"PR{x},{width};\n" +
                         $"PU {x},{y};\n";

            return cmd;
        }

        private string lineCommand(SerialiseObject serialise)
        {
            Dictionary<string, string> s = serialise.attributes;
            string x1, y1, x2, y2;

            s.TryGetValue("x1", out x1);
            s.TryGetValue("y1", out y1);
            s.TryGetValue("x2", out x2);
            s.TryGetValue("y2", out y2);

            string cmd = $"PU {x1},{y1};" +
                         $"PD {x2}.{x2};" +
                         $"PU;";

            return cmd;
        }

        private string lineCommand(int x, int y)
        {
            string cmd = $"PD {x},{y};";
            return cmd;
        }

        private string polyLineCommand(SerialiseObject serialise)
        {
            Dictionary<string, string> s = serialise.attributes;
            string val;
            s.TryGetValue("points", out val);

            string cmd = "polyline goes here";
            return cmd;
        }

        private string polygonCommand(SerialiseObject serialise)
        {
            Dictionary<string, string> s = serialise.attributes;

            string val;
            s.TryGetValue("points", out val);

            string cmd = "polygon goes here";
            return cmd;
        }

        public string buildFile(JsonRoot root)
        {
            hpglbuilder.Append(initialiseFile());
            string cmd = null;

            foreach (SerialiseObject serialisedToken in root.tokenarray)
            {
                switch (serialisedToken.tokenID)
                {
                    case (byte)SymbolTable.Circle:
                        cmd = circleCommand(serialisedToken);
                        hpglbuilder.AppendLine(cmd);
                        break;

                    case (byte)SymbolTable.Rectangle:
                        cmd = rectangleCommand(serialisedToken);
                        hpglbuilder.AppendLine(cmd);
                        break;

                    case (byte)SymbolTable.Line:
                        cmd = lineCommand(serialisedToken);
                        hpglbuilder.AppendLine(cmd);
                        break;

                    case (byte)SymbolTable.Polyline:
                        cmd = polyLineCommand(serialisedToken);
                        hpglbuilder.AppendLine(cmd);
                        break;

                    case (byte)SymbolTable.Polygon:
                        cmd = polygonCommand(serialisedToken);
                        hpglbuilder.AppendLine(cmd);
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
            return hpglbuilder.ToString();
        }
    }
}