using System;
using System.Threading.Tasks;
using GraphQlAirlines.Data.Models;

namespace GraphQlAirlines.Api.Types
{
    public class RouteType
    {
        public RouteType(int airlineId, int sourceAirportId, int destinationAirportId, bool codeShare, int stops, string equipment)
        {
            AirlineId = airlineId;
            SourceAirportId = sourceAirportId;
            DestinationAirportId = destinationAirportId;
            Codeshare = codeShare;
            Stops = stops;
            Equipment = equipment;
        }


        public int AirlineId { get; }

        public int SourceAirportId { get; }
        
        public int DestinationAirportId { get; }
        
        public bool Codeshare { get; }
        
        public int Stops { get; }
        
        public string Equipment { get; }
    }

    public class RouteResolvers
    {
        public async Task<Airline> GetAirline()
        {
            throw new NotImplementedException();
        }
        
        public async Task<Airline> GetSource()
        {
            throw new NotImplementedException();
        }
        
        public async Task<Airline> GetDestination()
        {
            throw new NotImplementedException();
        }
    }
}