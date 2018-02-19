using System.Collections.Generic;
using Domain;
using Services.Dtos;

namespace Services
{
    public interface IAirportService
    {
        AirportsList GetAirportsBy(string iso);
        Airport GetAirportBy(string iata);
        List<string> GetAllCountryCodes();
    }
}