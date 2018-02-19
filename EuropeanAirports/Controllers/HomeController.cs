using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Domain;
using EuropeanAirports.Models;
using Managers;

namespace EuropeanAirports.Controllers
{
    public class HomeController : Controller
    {
        private const string FromFeedHeader = "from-feed";

        private readonly IAirportManager _airportManager;

        public HomeController(IAirportManager airportManager)
        {
            _airportManager = airportManager;
        }

        public ActionResult Index(string iso)
        {
            var airportsList = _airportManager.GetAirportsBy(iso);
            var airports = Mapper.Map<ICollection<Airport>, ICollection<AirportViewModel>>
                (airportsList.Airports);

            HttpContext.Response.AddHeader(FromFeedHeader, (!airportsList.IsExpired).ToString());

            return View(airports);
        }

        public JsonResult GetAllCountries()
        {
            var countries = _airportManager.GetAllCountryCodes();

            return new JsonResult
            {
                Data = countries,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}