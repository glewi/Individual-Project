using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlotterConversionSystem.TokenDefinitions.TinySVG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotterConversionSystem.TokenDefinitions.TinySVG.Tests
{
    [TestClass()]
    public class TinySvgLineTests
    {
        [TestMethod()]
        public void TinySvgLineValidFormatTest()
        {
            string[] attributes = new string[] { "50", "50", "40", "40" };
            var token = new TinySvgLine(attributes);

            CollectionAssert.AreEqual(attributes, token.GetParameters());
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void TinySvgLineInvalidFormatTest()
        {
            string[] attributes = new string[] { "NOT", "VALID", "VALUES", "TEST" };
            var token = new TinySvgLine(attributes);

        }

        [TestMethod()]
        public void GetIDTest()
        {
            const byte expectedID = (byte)SymbolTable.Line;
            string[] attributes = new string[] { "50", "50", "40", "40" };
            var token = new TinySvgLine(attributes);

            Assert.AreEqual(token.GetID(), expectedID);
        }

        [TestMethod()]
        public void GetNamedParametersTest()
        {
            string[] attributes = new string[] { "50", "50", "40", "40" };
            var token = new TinySvgLine(attributes);

            Dictionary<string, string> expectedrestult = new Dictionary<string, string>
            {
                {"x1", attributes[0]},
                {"y1", attributes[1]},
                {"x2", attributes[2]},
                {"y2", attributes[3]}
            };

            CollectionAssert.AreEqual(expectedrestult, token.GetNamedParameters());
        }

        [TestMethod()]
        public void GetParametersTest()
        {
            string[] attributes = new string[] { "50", "50", "40", "40" };
            var token = new TinySvgLine(attributes);

            string[] expectedrestult = new string[]
            {
                attributes[0],
                attributes[1],
                attributes[2],
                attributes[3]
            };

            CollectionAssert.AreEqual(expectedrestult, token.GetParameters());
        }

        [TestMethod()]
        public void SetStringParametersTest()
        {
            string[] attributes = new string[] { "50", "50", "40", "40" };
            var token = new TinySvgLine(attributes);

            string[] expectedrestult = new string[]
            {
                attributes[0],
                attributes[1],
                attributes[2],
                attributes[3]
            };

            CollectionAssert.AreEqual(expectedrestult, token.GetParameters());
        }
    }
}