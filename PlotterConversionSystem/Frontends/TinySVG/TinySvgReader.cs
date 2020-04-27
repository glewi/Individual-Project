using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace PlotterConversionSystem.Frontends.TinySVG
{
    public static class TinySvgReader
    {
        // Would be used to read the TinySVG canvas data.
        private static string[] ReadCanvas(string @path)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Use LINQtoXML to read the TinySVG data stored at a given path.
        /// </summary>
        /// <param name="path"> The path where the TinySVG program is stored</param>
        /// <returns>A string array of TinySVG elements</returns>
        private static string[] ReadElements(string @path)
        {
            // Select all elements in the SVG tag.
            XDocument document = XDocument.Load(@path);
            IEnumerable<XElement> xml =
                from element in document.Root.Descendants()
                select element;

            // Create a new string array to store these elements.
            string[] elements = new string[xml.Count()];

            int count = 0;

            // Fill the array with XElement objects
            foreach (XElement element in xml)
            {
                elements[count] = element.ToString();
                count++;
            }

            return elements;
        }

        /// <summary>
        /// Implements the IFrontend reader interface.
        /// </summary>
        public static string[] Read(string @path)
        {
            return ReadElements(@path);
        }
    }
}
