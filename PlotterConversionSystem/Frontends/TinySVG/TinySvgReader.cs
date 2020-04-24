using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace PlotterConversionSystem.Frontends.TinySVG
{
    public static class TinySvgReader
    {
        private static string[] ReadCanvas(string @path)
        {
            throw new NotImplementedException();
        }
        
        private static string[] ReadElements(string @path)
        {
            XDocument document = XDocument.Load(@path);
            IEnumerable<XElement> xml =
                from element in document.Root.Descendants()
                select element;

            string[] elements = new string[xml.Count()];

            int count = 0;

            foreach (XElement element in xml)
            {
                elements[count] = element.ToString();
                count++;
            }

            return elements;
        }

        public static string[] Read(string @path)
        {
            //var test = ReadCanvas(@path);
            return ReadElements(@path);
        }
    }
}
