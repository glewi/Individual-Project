using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace PlotterConversionSystem.Frontends.TinySVG
{
    public static class TinySvgReader
    {
        public static string[] Read(string @path)
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
    }
}
