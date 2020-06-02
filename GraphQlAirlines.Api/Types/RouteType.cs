using System.Threading.Tasks;
using AutoMapper;
using GraphQlAirlines.Data;
using HotChocolate;

namespace GraphQlAirlines.Api.Types
{
    public class RouteType
    {
        public RouteType(int airlineId, int sourceAirportId, int destinationAirportId, bool codeshare, int stops)
        {
            AirlineId = airlineId;
            SourceAirportId = sourceAirportId;
            DestinationAirportId = destinationAirportId;
            Codeshare = codeshare;
            Stops = stops;
        }


        public int AirlineId { get; }

        public int SourceAirportId { get; }
        
        public int DestinationAirportId { get; }
        
        public bool Codeshare { get; }
        
        public int Stops { get; }
    }

    public class RouteResolvers
    {
        private readonly IAirlineDataStore _dataStore;
        private readonly IMapper _mapper;

        public RouteResolvers(IAirlineDataStore dataStore, IMapper mapper)
        {
            _dataStore = dataStore;
            _mapper = mapper;
        }

        public async Task<AirlineType?> GetAirline([Parent] RouteType route)
        {
            return _mapper.Map<AirlineType>(await _dataStore.GetAirlineByIdAsync(route.AirlineId));
        }
        
        public async Task<AirportType?> GetSource([Parent] RouteType route)
        {
            return _mapper.Map<AirportType>(await _dataStore.GetAirportByIdAsync(route.SourceAirportId));
        }
        
        public async Task<AirportType?> GetDestination([Parent] RouteType route)
        {
            return _mapper.Map<AirportType>(await _dataStore.GetAirportByIdAsync(route.DestinationAirportId));
        }
    }
}