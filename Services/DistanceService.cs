using System.Device.Location;
using Domain;

namespace Services
{
    public class DistanceService : IDistanceService
    {
        public double GetDistance(Coordinate fromCoordinate, Coordinate toCoordinate)
        {
            var firstCoordinate = new GeoCoordinate(fromCoordinate.Latitude, fromCoordinate.Longitude);
            var secondCoordinate = new GeoCoordinate(toCoordinate.Latitude, toCoordinate.Longitude);

            return firstCoordinate.GetDistanceTo(secondCoordinate) / 1000;
        }
    }
}
