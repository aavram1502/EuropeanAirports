using System.Web.Mvc;
using EuropeanAirports.Controllers;
using EuropeanAirports.Models;
using FluentAssertions;
using Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EuropeanAirports.Tests.Controllers
{
    [TestClass]
    public class DistanceControllerTest : BaseTest
    {
        private Mock<IAirportManager> _airportManagerMock;

        private DistanceController _distanceController;

        [TestInitialize]
        public void Setup()
        {
            _airportManagerMock = new Mock<IAirportManager>();

            _distanceController = new DistanceController(_airportManagerMock.Object);
        }

        [TestMethod]
        public void Index_ReturnsFormattedToTwoDecimalsKillometersResult()
        {
            // Act
            var result = _distanceController.Index(It.IsAny<string>(), It.IsAny<string>()) as ViewResult;
            var model = (DistanceViewModel)result?.Model;

            // Assert
            model?.Distance.Should().Be("0.00 km");
        }


        [TestMethod]
        public void Index_ReturnsResultFromAirportService()
        {
            // Act
            _distanceController.Index(It.IsAny<string>(), It.IsAny<string>());

            // Assert
            _airportManagerMock.Verify(x => x.GetDistance(It.IsAny<string>(), It.IsAny<string>()));
        }
    }
}
