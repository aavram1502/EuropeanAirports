using System.Web.Mvc;
using AutoMapper;
using Domain;
using EuropeanAirports.Models;
using Managers;

namespace EuropeanAirports.Controllers
{
    public class DistanceController : Controller
    {
        private readonly IAirportManager _airportManager;

        public DistanceController(IAirportManager airportManager)
        {
            _airportManager = airportManager;
        }

        public ActionResult Index(string iata1, string iata2)
        {
            var distance = Mapper.Map<DistanceDetails, DistanceViewModel>
                (_airportManager.GetDistance(iata1, iata2));

            return View(distance);
        }
    }
}