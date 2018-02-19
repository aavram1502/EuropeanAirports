using Domain;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services;

namespace Managers.Tests
{
    [TestClass]
    public class AirportManagerTest
    {
        private Mock<IAirportService> _airportServiceMock;
        private Mock<IDistanceService> _distanceServiceMock;

        private AirportManager _airportManager;

        [TestInitialize]
        public void Setup()
        {
            _airportServiceMock = new Mock<IAirportService>();
            _distanceServiceMock = new Mock<IDistanceService>();

            _airportManager = new AirportManager(_airportServiceMock.Object, _distanceServiceMock.Object);
        }

        [TestMethod]
        public void GetAirportsBy_ReturnsResultFromService()
        {
            // Act
            _airportManager.GetAirportsBy(string.Empty);

            // Assert
            _airportServiceMock.Verify(x => x.GetAirportsBy(string.Empty));
        }

        [TestMethod]
        public void GetAllCountryCodes_ReturnsResultFromService()
        {
            // Act
            _airportManager.GetAllCountryCodes();

            // Assert
            _airportServiceMock.Verify(x => x.GetAllCountryCodes());
        }

        [TestMethod]
        public void GetDistance_ReturnsAirportFromServiceForEachIata()
        {
            // Act
            _airportManager.GetDistance(It.IsAny<string>(), It.IsAny<string>());

            // Assert
            _airportServiceMock.Verify(x => x.GetAirportBy(It.IsAny<string>()), Times.Exactly(2));
        }

        [TestMethod]
        public void GetDistance_ReturnsZeroDistanceWhenAirportIsNull()
        {
            // Act
            var result = _airportManager.GetDistance(It.IsAny<string>(), It.IsAny<string>());

            // Assert
            result.Airport1.Should().BeNull();
            result.Airport2.Should().BeNull();
            result.Distance.Should().Be(0);
        }

        [TestMethod]
        public void GetDistance_ReturnsValueFromServiceWhenAirportsAreSet()
        {
            // Arrange
            _airportServiceMock.Setup(x => x.GetAirportBy("iata1"))
                .Returns(new Airport {Iata ="iata1"});
            _airportServiceMock.Setup(x => x.GetAirportBy("iata2"))
                .Returns(new Airport { Iata = "iata2" });
            _distanceServiceMock.Setup(x => x.GetDistance(It.IsAny<Coordinate>(), It.IsAny<Coordinate>()))
                .Returns(3);

            // Act
            var result = _airportManager.GetDistance("iata1", "iata2");

            // Assert
            result.Airport1.Iata.Should().Be("iata1");
            result.Airport2.Iata.Should().Be("iata2");
            result.Distance.Should().Be(3);
        }
    }
}
