using System.Collections.Generic;
using Domain;
using Services;
using Services.Dtos;

namespace Managers
{
    public class AirportManager : IAirportManager
    {
        private readonly IAirportService _airportService;
        private readonly IDistanceService _distanceService;

        public AirportManager(IAirportService airportService, IDistanceService distanceService)
        {
            _airportService = airportService;
            _distanceService = distanceService;
        }

        public AirportsList GetAirportsBy(string iso)
        {
            return _airportService.GetAirportsBy(iso);
        }

        public List<string> GetAllCountryCodes()
        {
            return _airportService.GetAllCountryCodes();
        }

        public DistanceDetails GetDistance(string iata1, string iata2)
        {
            var airport1 = _airportService.GetAirportBy(iata1);
            var airport2 = _airportService.GetAirportBy(iata2);

            var distance = airport1 == null || airport2 == null ? 0 :
                _distanceService.GetDistance(airport1.Coordinates, airport2.Coordinates);

            return new DistanceDetails
            {
                Airport1 = airport1,
                Airport2 = airport2,
                Distance = distance
            };
        }
    }
}
