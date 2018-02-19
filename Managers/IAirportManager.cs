using System.Collections.Generic;
using Domain;
using Services.Dtos;

namespace Managers
{
    public interface IAirportManager
    {
        AirportsList GetAirportsBy(string iso);
        DistanceDetails GetDistance(string iata1, string iata2);
        List<string> GetAllCountryCodes();
    }
}