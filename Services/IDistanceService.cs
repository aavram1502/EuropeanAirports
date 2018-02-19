using Domain;

namespace Services
{
    public interface IDistanceService
    {
        double GetDistance(Coordinate fromCoordinate, Coordinate toCoordinate);
    }
}
