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
        [ExpectedException(typeof(InvalidCastException))]
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
            Assert.Fail();
        }

        [TestMethod()]
        public void GetParametersTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetStringParametersTest()
        {
            Assert.Fail();
        }
    }
}