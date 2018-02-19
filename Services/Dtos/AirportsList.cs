using System.Collections.Generic;
using Domain;

namespace Services.Dtos
{
    public class AirportsList
    {
        public List<Airport> Airports { get; set; }

        public bool IsExpired { get; set; }
    }
}
