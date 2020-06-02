using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public Task<IEnumerable<Airline>> GetAirlines()
        {
            throw new NotImplementedException();
        }
        
        public Task<IEnumerable<RouteType>> GetRoutes()
        {
            throw new NotImplementedException();
        }
    }
}