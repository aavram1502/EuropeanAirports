using AutoMapper;
using Domain;
using EuropeanAirports.Models;

namespace EuropeanAirports.AutomapperProfiles
{
    public class SolutionAutomapperProfile : Profile
    {
        public SolutionAutomapperProfile()
        {
            CreateMap<Airport, AirportViewModel>()
                .ForMember(m => m.Longitude, o => o.MapFrom(n => $"{n.Lon ?? 0:0.00}"))
                .ForMember(m => m.Latitude, o => o.MapFrom(n => $"{n.Lat ?? 0:0.00}"));

            CreateMap<DistanceDetails, DistanceViewModel>()
                .ForMember(m => m.Distance, o => o.MapFrom(n => $"{n.Distance:0.00} km"));
        }
    }
}