using PlotterConversionSystem.IRTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlotterConversionSystem.Backends
{
    /// <summary>
    /// The class responsible for the HPGL output.
    /// </summary>
    public class HPGLWriter : IWriter
    {
        // Create a stringbuilder to make the final command string and set
        // some deafault parameters.
        private StringBuilder hpglbuilder = new StringBuilder();
        private const int defaultPen = 1;
        private const double resolution = 0.5;

        /// <summary>
        /// Write the commands that initialise a HPGL file.
        /// </summary>
        private string InitialiseFile()
        {
            string cmd = $"IN;\n" +
                         $"SP{defaultPen};";
            return cmd;
        }

        /// <summary>
        /// Build a string that represents a HPGL circle.
        /// </summary>
        /// <param name="serialisedToken"> The token to utilise. </param>
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

        /// <summary>
        /// Build a string that represents a HPGL rectangle.
        /// </summary>
        /// <param name="serialisedToken"> The token to utilise. </param>
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

        /// <summary>
        /// Build a string that represents a HPGL line.
        /// </summary>
        /// <param name="serialisedToken"> The token to utilise. </param>
        private string LineCommand(SerialiseObject serialisedToken)
        {
            Dictionary<string, string> s = serialisedToken.attributes;
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

        /// <summary>
        /// Build a string that represents a HPGL ellipse.
        /// </summary>
        /// <param name="serialisedToken"> The token to utilise. </param>
        private string EllipseCommand(SerialiseObject serialiseToken)
        {
            // Not implemented but fails silently.
            return null;
        }

        /// <summary>
        /// Build a string that represents a HPGL polyline.
        /// </summary>
        /// <param name="serialisedToken">The token to utilised</param>
        private string PolylineCommand(SerialiseObject serialisedToken)
        {
            StringBuilder builder = new StringBuilder();
            Dictionary<string, string> s = serialisedToken.attributes;
            string val;
            s.TryGetValue("path", out val);

            // Split all the coordinates in the path string.
            string[] points = val.Split(' ').ToArray();

            // Split the X and Y value from the first coordinate.
            string[] initialpoint = points[0].Split(',');
            (string initx, string inity) = (initialpoint[0], initialpoint[1]);
            
            // Append the first line.
            builder.AppendLine($"PU {initx},{inity};");

            string[] pair;

            for (int i = 1; i < points.Length; i++)
            {
                // Split each coordinate string into its numbers.
                pair = points[i].Split(',');
                builder.AppendLine($"PD {pair[0]},{pair[1]};");
            }
            return builder.ToString();
        }

        /// <summary>
        /// Build a string that represents a HPGL polyline.
        /// </summary>
        /// <param name="serialisedToken">The token to utilised</param>
        private string PolygonCommand(SerialiseObject serialisedToken)
        {
            StringBuilder builder = new StringBuilder();
            Dictionary<string, string> s = serialisedToken.attributes;
            string val;
            s.TryGetValue("path", out val);
            // Split all the coordinates in the path string.
            string[] points = val.Split(' ').ToArray();

            // Split the X and Y value from the first coordinate.
            string[] initialpoint = points[0].Split(',');
            (string initx, string inity) = (initialpoint[0], initialpoint[1]);

            // Append the first line.
            builder.AppendLine($"PU {initx},{inity};");

            string[] pair;

            for (int i = 1; i < points.Length; i++)
            {
                // Split each coordinate string into its numbers.
                pair = points[i].Split(',');
                builder.AppendLine($"PD {pair[0]},{pair[1]};");
            }

            // Close the polygon.
            builder.AppendLine($"PD {initx},{inity};\n" +
                               $"PU;");

            return builder.ToString();
        }

        /// <summary>
        /// The entrypoint for building an HPGL file.
        /// </summary>
        /// <param name="root"> The JsonRoot object that is used to generated the file. </param>
        public string BuildFile(JsonRoot root)
        {
            hpglbuilder.AppendLine(InitialiseFile());
            string cmd = null;

            // For every token in the JsonRoot array
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

                        case (byte)SymbolTable.Ellipse:
                            EllipseCommand(serialisedToken);
                            Console.WriteLine("Ellipses are not support at this time.  Press any key to continue...");
                            Console.ReadKey();
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