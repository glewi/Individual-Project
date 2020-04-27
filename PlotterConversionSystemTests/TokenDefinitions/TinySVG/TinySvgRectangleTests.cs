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
    public class TinySvgRectangleTests
    {
        [TestMethod()]
        public void TinySvgRectangleValidTest()
        {
            string[] attributes = new string[] { "50", "50", "100", "100", "25", "25" };
            var token = new TinySvgRectangle(attributes);

            CollectionAssert.AreEqual(attributes, token.GetParameters());
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void TinySvgRectangleInvalidFormatTest()
        {
            string[] attributes = new string[] { "NOT", "VALID", "VALUES", "SHOULD", "FAIL", "TEST" };
            var token = new TinySvgRectangle(attributes);
        }

        [TestMethod()]
        [ExpectedException(typeof(OverflowException))]
        public void TinySvgRectangleNegativeUintTest()
        {
            string[] attributes = new string[] { "50", "50", "100", "100", "-25", "-25" };
            var token = new TinySvgRectangle(attributes);
        }


        [TestMethod()]
        public void GetIDTest()
        {
            const byte expectedID = (byte)SymbolTable.Rectangle;
            string[] attributes = new string[] { "50", "50", "100", "100", "25", "25" };
            var token = new TinySvgRectangle(attributes);

            Assert.AreEqual(token.GetID(), expectedID);
        }

        [TestMethod()]
        public void GetNamedParametersTest()
        {
            string[] attributes = new string[] { "50", "50", "100", "100", "25", "25" };
            var token = new TinySvgRectangle(attributes);
            Dictionary<string,string> expectedresults = new Dictionary<string, string>
            {
                {"x", attributes[0]},
                {"y", attributes[1]},
                {"width", attributes[2]},
                {"height", attributes[3]},
                {"rx", attributes[4]},
                {"ry", attributes[5]}
            };
        }

        [TestMethod()]
        public void GetParametersTest()
        {
            string[] attributes = new string[] { "50", "50", "100", "100", "25", "25" };
            var token = new TinySvgRectangle(attributes);

            CollectionAssert.AreEqual(attributes, token.GetParameters());
        }

        [TestMethod()]
        public void SetStringParametersTest()
        {
            string[] attributes = new string[] { "50", "50", "100", "100", "25", "25" };
            var token = new TinySvgRectangle(attributes);

            string[] expectedrestult = new string[]
            {
                attributes[0],
                attributes[1],
                attributes[2],
                attributes[3],
                attributes[4],
                attributes[5]
            };

            CollectionAssert.AreEqual(expectedrestult, token.GetParameters());
        }
    }
}