using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlotterConversionSystem.Backends;
using PlotterConversionSystem.IRTools;
using PlotterConversionSystem.TokenDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotterConversionSystem.Backends.Tests
{
    [TestClass()]
    public class HPGLWriterTests
    {
        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void BuildFileInvalidTokenTest()
        {
            // Arrange
            IWriter Writer = new HPGLWriter();
            JsonRoot json = new JsonRoot();

            // Act

            // Assert

        }
    }
}