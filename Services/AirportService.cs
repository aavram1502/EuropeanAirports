using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Domain;
using Services.Dtos;

namespace Services
{
    public class AirportService : IAirportService
    {
        private const string Europe = "EU";
        private const string AirportType = "airport";

        private readonly string _airportsJsonFeed = ConfigurationManager.AppSettings["AirportsJsonFeed"];
        private readonly int _retrieveInterval = int.Parse(ConfigurationManager.AppSettings["RetrieveInterval"]);

        private readonly AirportsList _airportsList;

        private readonly IHttpRequestService _httpRequestService;

        private DateTime? _updateDate;

        public AirportService(IPeriodicalService periodicalService, IHttpRequestService httpRequestService)
        {
            _httpRequestService = httpRequestService;
            _airportsList = new AirportsList { Airports = new List<Airport>() };

            var updateAirportsTask = periodicalService.RunPeriodically(SendRequest, TimeSpan.FromSeconds(10)); //.FromMinutes(_retrieveInterval));
        }

        public AirportsList GetAirportsBy(string iso)
        {
            _airportsList.Airports = _airportsList.Airports
                .Where(x => string.IsNullOrEmpty(iso) || x.Iso == iso)
                .ToList();
            _airportsList.IsExpired = _updateDate == null || RetrieveIntervalExceeded();

            return _airportsList;
        }

        public Airport GetAirportBy(string iata)
        {
            return _airportsList.Airports.FirstOrDefault(x =>
                string.Equals(x.Iata, iata, StringComparison.OrdinalIgnoreCase));
        }

        public List<string> GetAllCountryCodes()
        {
            return _airportsList.Airports.Select(x => x.Iso)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
        }

        private void SendRequest()
        {
            var airportResults = _httpRequestService.SendRequest<Airport>(_airportsJsonFeed);

            _airportsList.Airports = airportResults
                .Where(x =>
                    x.Continent == Europe &&
                    x.Type == AirportType)
                .ToList();
            _updateDate = DateTime.UtcNow;
        }

        private bool RetrieveIntervalExceeded()
        {
            var currentDateTime = DateTime.UtcNow;
            var timeDifference = currentDateTime.Subtract((DateTime)_updateDate);

            return timeDifference.Minutes > _retrieveInterval;
        }
    }
}