using AutoMapper;
using EuropeanAirports.AutomapperProfiles;

namespace EuropeanAirports
{
    public class AutomapperConfig
    {
        public static void LoadAutomapperProfile()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<SolutionAutomapperProfile>();
            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}