using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlotterConversionSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotterConversionSystem.Tests
{
    [TestClass()]
    public class CompilerFaçadeTests
    {
        [TestMethod()]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ValidateExistingPathTest()
        {
            
            
            Assert.Fail();
        }
    }
}