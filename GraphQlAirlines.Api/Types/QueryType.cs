using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQlAirlines.Data;
using GraphQlAirlines.Data.Models;
using HotChocolate.Types;

namespace GraphQlAirlines.Api.Types
{
    
    // No data fields on query
    public class QueryType
    {
    }

    public class QueryResolvers
    {

        private readonly IAirlineDataStore _dataStore;

        public QueryResolvers(IAirlineDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public async Task<IEnumerable<AirlineType>> GetAirlines()
        {
            return (await _dataStore.FetchAllAirlinesAsync()).Select(a =>
                new AirlineType(a.AirlineId, a.Name, a.Iata, a.Country));
        }
        
        public Task<IEnumerable<RouteType>> GetRoutes()
        {
            throw new NotImplementedException();
        }
    }
}