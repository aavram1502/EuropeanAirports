using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Domain;
using EuropeanAirports.Controllers;
using EuropeanAirports.Models;
using FluentAssertions;
using Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.Dtos;

namespace EuropeanAirports.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest : BaseTest
    {
        private Mock<IAirportManager> _airportManagerMock;

        private HomeController _homeController;

        [TestInitialize]
        public void Setup()
        {
            _airportManagerMock = new Mock<IAirportManager>();

            _homeController = new HomeController(_airportManagerMock.Object) { ControllerContext = MockWebContext.BasicContext() };
        }

        [TestMethod]
        public void Index_ReturnsEmptyModelForTheView_WhenManagerReturnsNoResult()
        {
            // Arrange
            _airportManagerMock.Setup(x => x.GetAirportsBy(It.IsAny<string>()))
                .Returns(new AirportsList());

            // Act
            var result = _homeController.Index(string.Empty) as ViewResult;

            // Assert
            result.Should().NotBeNull();
        }

        [TestMethod]
        public void Index_ReturnsListOfAirports_WhenManagerReturnsResults()
        {
            // Arrange
            _airportManagerMock.Setup(x => x.GetAirportsBy(It.IsAny<string>()))
                .Returns(new AirportsList
                {
                    Airports = new List<Airport> { new Airport { Iata = "Iata1"} }
                });

            // Act
            var result = _homeController.Index(string.Empty) as ViewResult;
            var model = ((IEnumerable)result?.Model)?.Cast<AirportViewModel>().ToList();

            // Assert
            model?.FirstOrDefault()?.Iata.Should().Be("Iata1");
        }

        [TestMethod]
        public void GetAllCountries_ReturnsResultFromAirportService()
        {
            // Act
            _homeController.GetAllCountries();

            // Assert
            _airportManagerMock.Verify(x => x.GetAllCountryCodes());
        }
    }
}
