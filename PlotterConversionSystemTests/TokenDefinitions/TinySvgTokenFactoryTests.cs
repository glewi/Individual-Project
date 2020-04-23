using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlotterConversionSystem.TokenDefinitions.Tests
{
    /// <summary>
    /// Unit test class for the MSTest framework on the TinySvgTokenFactory class.
    /// </summary>
    [TestClass()]
    public class TinySvgTokenFactoryTests
    {
        //[TestMethod()]
        //public void CreateRectangleTokenUsingByteTest()
        //{
        //    // Arrange
        //    var factory = new TinySvgTokenFactory();
        //    int[] parameters = new string[6] { 0, 0, 0, 0, 0, 0 };

        //    // Act 
        //    var output = factory.CreateToken((byte)SymbolTable.Rectangle, parameters);

        //    // Assert
        //    Assert.IsInstanceOfType(output, typeof(TinySvgRectangle));
        //}

        //[TestMethod()]
        //public void CreateRectangleTokenUsingStringTest()
        //{
        //    // Arrange
        //    var factory = new TinySvgTokenFactory();
        //    int[] parameters = new int[6] { 0, 0, 0, 0, 0, 0 };

        //    // Act 
        //    var output = factory.CreateToken("rect", parameters);

        //    // Assert
        //    Assert.IsInstanceOfType(output, typeof(TinySvgRectangle));
        //}

        [TestMethod()]
        public void CreateCircleTokenUsingByteTest()
        {
            // Arrange
            var factory = new TinySvgTokenFactory();
            string[] parameters = new string[3] { "0", "0", "0" };

            // Act 
            var output = factory.CreateToken((byte)SymbolTable.Circle, parameters);

            // Assert
            Assert.IsInstanceOfType(output, typeof(TinySVG.TinySvgCircle));
        }

        [TestMethod()]
        public void CreateCircleTokenUsingStringTest()
        {
            // Arrange
            var factory = new TinySvgTokenFactory();
            string[] parameters = new string[3] { "0", "0", "0" };

            // Act 
            var output = factory.CreateToken("circle", parameters);

            // Assert
            Assert.IsInstanceOfType(output, typeof(TinySVG.TinySvgCircle));
        }

        //[TestMethod()]
        //public void CreateEllipseUsingByteTokenTest()
        //{
        //    // Arrange
        //    var factory = new TinySvgTokenFactory();
        //    int[] parameters = new int[4] { 0, 0, 0, 0 };

        //    // Act 
        //    var output = factory.CreateToken((byte)SymbolTable.Ellipse, parameters);

        //    // Assert
        //    Assert.IsInstanceOfType(output, typeof(TinySvgEllipse));
        //}

        //[TestMethod()]
        //public void CreateEllipseTokenUsingStringTest()
        //{
        //    // Arrange
        //    var factory = new TinySvgTokenFactory();
        //    int[] parameters = new int[4] { 0, 0, 0, 0 };

        //    // Act 
        //    var output = factory.CreateToken("ellipse", parameters);

        //    // Assert
        //    Assert.IsInstanceOfType(output, typeof(TinySvgEllipse));
        //}

        //[TestMethod()]
        //public void CreateLineTokenUsingByteTest()
        //{
        //    // Arrange
        //    var factory = new TinySvgTokenFactory();
        //    int[] parameters = new int[3] { 0, 0, 0 };

        //    // Act 
        //    var output = factory.CreateToken((byte)SymbolTable.Line, parameters);

        //    // Assert
        //    Assert.IsInstanceOfType(output, typeof(TinySvgLine));
        //}

        //[TestMethod()]
        //public void CreateLineTokenUsingStringTest()
        //{
        //    // Arrange
        //    var factory = new TinySvgTokenFactory();
        //    int[] parameters = new int[3] { 0, 0, 0 };

        //    // Act 
        //    var output = factory.CreateToken("line", parameters);

        //    // Assert
        //    Assert.IsInstanceOfType(output, typeof(TinySvgLine));
        //}

        //[TestMethod()]
        //public void CreatePolylineTokenUsingByteTest()
        //{
        //    // Arrange
        //    var factory = new TinySvgTokenFactory();
        //    int[] parameters = new int[0];

        //    // Act 
        //    var output = factory.CreateToken((byte)SymbolTable.Polyline, parameters);

        //    // Assert
        //    Assert.IsInstanceOfType(output, typeof(TinySvgPolyline));
        //}

        //[TestMethod()]
        //public void CreatePolylineTokenUsingStringTest()
        //{
        //    // Arrange
        //    var factory = new TinySvgTokenFactory();
        //    int[] parameters = new int[0];

        //    // Act 
        //    var output = factory.CreateToken("polyline", parameters);

        //    // Assert
        //    Assert.IsInstanceOfType(output, typeof(TinySvgPolyline));
        //}

        //[TestMethod()]
        //public void CreatePolygonTokenUsingByteTest()
        //{
        //    // Arrange
        //    var factory = new TinySvgTokenFactory();
        //    int[] parameters = new int[0];

        //    // Act 
        //    var output = factory.CreateToken((byte)SymbolTable.Polygon, parameters);

        //    // Assert
        //    Assert.IsInstanceOfType(output, typeof(TinySvgPolygon));
        //}

        //[TestMethod()]
        //public void CreatePolygonTokenUsingStringTest()
        //{
        //    // Arrange
        //    var factory = new TinySvgTokenFactory();
        //    int[] parameters = new int[0];

        //    // Act 
        //    var output = factory.CreateToken("polygon", parameters);

        //    // Assert
        //    Assert.IsInstanceOfType(output, typeof(TinySvgPolygon));
        //}

        //[TestMethod()]
        //[ExpectedException(typeof(NotImplementedException))]
        //public void CreateInvalidTokenTest()
        //{
        //    // Arrange
        //    var factory = new TinySvgTokenFactory();
        //    int[] parameters = new int[0];

        //    // Act
        //    var output = factory.CreateToken(255, parameters);
        //}
    }
}