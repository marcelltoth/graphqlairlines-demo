using AutoMapper;
using GraphQlAirlines.Api.Types;
using GraphQlAirlines.Data.Models;

namespace GraphQlAirlines.Api
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Airline, AirlineType>()
                .ForCtorParam("id", x => x.MapFrom(src => src.AirlineId))
                .ForCtorParam("countryCode", x => x.MapFrom(src => src.Country));

            CreateMap<Airport, AirportType>();

            CreateMap<Country, CountryType>();

            CreateMap<DstType, GraphQlDstType>();

            CreateMap<Route, RouteType>();
        }
    }
}