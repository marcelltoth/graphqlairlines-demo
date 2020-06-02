using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GraphQlAirlines.Data;

namespace GraphQlAirlines.Api.Types
{
    
    // No data fields on query
    public class QueryType
    {
    }

    public class QueryResolvers
    {

        private readonly IAirlineDataStore _dataStore;
        private readonly IMapper _mapper;

        public QueryResolvers(IAirlineDataStore dataStore, IMapper mapper)
        {
            _dataStore = dataStore;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AirlineType>> GetAirlines(int? offset, int? limit)
        {
            return (await _dataStore.FetchAllAirlinesAsync())
                .Skip(offset ?? 0)
                .Take(Math.Min(limit ?? 10, 100))
                .Select(_mapper.Map<AirlineType>);
        }
        
        public async Task<IEnumerable<RouteType>> GetRoutes(int? offset, int? limit)
        {
            return (await _dataStore.FetchAllRoutesAsync())
                .Skip(offset ?? 0)
                .Take(Math.Min(limit ?? 10, 100))
                .Select(_mapper.Map<RouteType>);
        }
    }
}