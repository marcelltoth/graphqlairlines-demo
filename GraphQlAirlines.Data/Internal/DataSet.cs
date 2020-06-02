using System.Collections.Generic;
using GraphQlAirlines.Data.Models;

namespace GraphQlAirlines.Data.Internal
{
    internal class DataSet
    {
        public DataSet(IReadOnlyList<Aircraft> aircraft, IReadOnlyList<Airline> airlines, IReadOnlyList<Airport> airports, IReadOnlyList<Route> routes, IReadOnlyList<Country> countries)
        {
            Aircraft = aircraft;
            Airlines = airlines;
            Airports = airports;
            Routes = routes;
            Countries = countries;
        }

        public IReadOnlyList<Aircraft> Aircraft { get; }
        public IReadOnlyList<Airline> Airlines { get; }
        public IReadOnlyList<Airport> Airports { get; }
        public IReadOnlyList<Route> Routes { get; }
        
        public IReadOnlyList<Country> Countries { get; }
    }
}