using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlotterConversionSystem.TokenDefinitions.TinySVG;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotterConversionSystem.TokenDefinitions.TinySVG.Tests
{
    [TestClass()]
    public class TinySvgCircleTests
    {
        [TestMethod()]
        public void TinySvgCircleValidTest()
        {
            string[] attributes = new string[] { "50","50","40" };
            var token = new TinySvgCircle(attributes);

            CollectionAssert.AreEqual(attributes, token.GetParameters());
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidCastException))]
        public void TinySvgCircleInvalidFormatTest()
        {
            string[] attributes = new string[] { "NOT", "VALID", "VALUES" };
            var token = new TinySvgCircle(attributes);
        }

        [TestMethod()]
        [ExpectedException(typeof(OverflowException))]
        public void TinySvgCircleNegativeUintTest()
        {
            string[] attributes = new string[] { "50", "50", "-40" };
            var token = new TinySvgCircle(attributes);
        }


        [TestMethod()]
        public void GetIDTest()
        {
            const byte expectedID = (byte)SymbolTable.Circle;
            string[] attributes = new string[] { "50", "50", "40" };
            var token = new TinySvgCircle(attributes);

            Assert.AreEqual(token.GetID(), expectedID);
        }

        [TestMethod()]
        public void GetNamedParametersTest()
        {
            string[] attributes = new string[] { "50", "50", "40" };
            var token = new TinySvgCircle(attributes);

            Dictionary<string, string> expectedrestult = new Dictionary<string, string>
            {
                {"x", attributes[0].ToString() },
                {"y", attributes[1].ToString() },
                {"r", attributes[2].ToString() }
            };

            CollectionAssert.AreEqual(expectedrestult, token.GetNamedParameters());
        }

        [TestMethod()]
        public void GetParametersTest()
        {
            string[] attributes = new string[] { "50", "50", "40" };
            var token = new TinySvgCircle(attributes);

            string[] expectedrestult = new string[]
            {
                attributes[0].ToString() ,
                attributes[1].ToString() ,
                attributes[2].ToString() 
            };

            CollectionAssert.AreEqual(expectedrestult, token.GetParameters());
        }

        [TestMethod()]
        public void SetStringParametersTest()
        {
            Assert.Fail();
        }
    }
}