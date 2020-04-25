using PlotterConversionSystem.IRTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlotterConversionSystem.Backends
{
    public class HPGLWriter : IWriter
    {
        private StringBuilder hpglbuilder = new StringBuilder();
        private const int defaultPen = 1;
        private const double resolution = 0.5;
        private const int rotation = 0;

        private string InitialiseFile()
        {
            string cmd = $"IN;\n" +
                         $"SP{defaultPen};";
            return cmd;
        }

        private string CircleCommand(SerialiseObject serialisedToken)
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

        private string RectangleCommand(SerialiseObject serialisedToken)
        {
            Dictionary<string, string> keys = serialisedToken.attributes;
            string x, y, width, height;

            keys.TryGetValue("x", out x);
            keys.TryGetValue("y", out y);
            keys.TryGetValue("width", out width);
            keys.TryGetValue("height", out height);

            string cmd = $"PU {x},{y};\n" +
                         $"ER {width},{height};\n" +
                         $"PU;";

            return cmd;
        }

        private string LineCommand(SerialiseObject serialise)
        {
            Dictionary<string, string> s = serialise.attributes;
            string x1, y1, x2, y2;

            s.TryGetValue("x1", out x1);
            s.TryGetValue("y1", out y1);
            s.TryGetValue("x2", out x2);
            s.TryGetValue("y2", out y2);

            string cmd = $"PU {x1},{y1};\n" +
                         $"PD {x2},{y2};\n" +
                         $"PU;";

            return cmd;
        }

        private string EllipseCommand(SerialiseObject serialise)
        {
            return null;
        }

        private string PolylineCommand(SerialiseObject serialise)
        {
            StringBuilder builder = new StringBuilder();
            Dictionary<string, string> s = serialise.attributes;
            string val;
            s.TryGetValue("path", out val);

            string[] points = val.Split(' ').ToArray();
            string[] initialpoint = points[0].Split(',');
            (string initx, string inity) = (initialpoint[0], initialpoint[1]);
            
            builder.AppendLine($"PU {initx},{inity};");

            string[] pair;

            for (int i = 1; i < points.Length; i++)
            {
                pair = points[i].Split(',');
                builder.AppendLine($"PD {pair[0]},{pair[1]};");
            }
            return builder.ToString();
        }

        private string PolygonCommand(SerialiseObject serialise)
        {
            StringBuilder builder = new StringBuilder();
            Dictionary<string, string> s = serialise.attributes;
            string val;
            s.TryGetValue("path", out val);

            string[] points = val.Split(' ').ToArray();
            string[] initialpoint = points[0].Split(',');
            (string initx, string inity) = (initialpoint[0], initialpoint[1]);

            builder.AppendLine($"PU {initx},{inity};");

            string[] pair;

            for (int i = 1; i < points.Length; i++)
            {
                pair = points[i].Split(',');
                builder.AppendLine($"PD {pair[0]},{pair[1]};");
            }

            builder.AppendLine($"PD {initx},{inity};\n" +
                               $"PU;");

            return builder.ToString();
        }

        public string BuildFile(JsonRoot root)
        {
            hpglbuilder.AppendLine(InitialiseFile());
            string cmd = null;

            foreach (SerialiseObject serialisedToken in root.tokenarray)
            {
                if (serialisedToken != null)
                {
                    switch (serialisedToken.tokenID)
                    {
                        case (byte)SymbolTable.Circle:
                            cmd = CircleCommand(serialisedToken);
                            hpglbuilder.AppendLine(cmd);
                            break;

                        case (byte)SymbolTable.Rectangle:
                            cmd = RectangleCommand(serialisedToken);
                            hpglbuilder.AppendLine(cmd);
                            break;

                        case (byte)SymbolTable.Line:
                            cmd = LineCommand(serialisedToken);
                            hpglbuilder.AppendLine(cmd);
                            break;

                        case (byte)SymbolTable.Polyline:
                            cmd = PolylineCommand(serialisedToken);
                            hpglbuilder.AppendLine(cmd);
                            break;

                        case (byte)SymbolTable.Polygon:
                            cmd = PolygonCommand(serialisedToken);
                            hpglbuilder.AppendLine(cmd);
                            break;

                        default:
                            // Fail silently.
                            break;
                    }
                }
            }
            return hpglbuilder.ToString();
        }
    }
}