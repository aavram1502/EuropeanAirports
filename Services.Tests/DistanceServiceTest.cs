using Domain;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Services.Tests
{
    [TestClass]
    public class DistanceServiceTest
    {
        [TestMethod]
        public void GetDistance_ReturnsDistanceBetweenTwoCoordinates()
        {
            // Arrange
            var service = new DistanceService();
            var coordinate1 = new Coordinate {Longitude = 12, Latitude = 44};
            var coordinate2 = new Coordinate {Longitude = 54, Latitude = 14};

            // Act
            var result = service.GetDistance(coordinate1, coordinate2);

            // Assert
            result.Should().NotBe(null);
            result.Should().BeGreaterThan(0);
        }
    }
}
