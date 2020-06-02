using System.Collections.Generic;
using System.Linq;
using GraphQlAirlines.Data.Models;

namespace GraphQlAirlines.Data.Internal
{
    internal class DataSet
    {
        public DataSet(IReadOnlyList<Aircraft> aircraft, IReadOnlyList<Airline> airlines,
            IReadOnlyList<Airport> airports, IReadOnlyList<Route> routes, IReadOnlyList<Country> countries)
        {
            Aircraft = aircraft;
            Airlines = airlines;
            AirlinesById = airlines.ToDictionary(a => a.AirlineId, a => a);
            Airports = airports;
            AirportsById = airports.ToDictionary(a => a.AirportId, a => a);
            Routes = routes;
            Countries = countries;
        }

        public IReadOnlyList<Aircraft> Aircraft { get; }
        public IReadOnlyList<Airline> Airlines { get; }
        public IReadOnlyDictionary<int, Airline> AirlinesById { get; }
        public IReadOnlyList<Airport> Airports { get; }

        public IReadOnlyDictionary<int, Airport> AirportsById { get; }
        public IReadOnlyList<Route> Routes { get; }

        public IReadOnlyList<Country> Countries { get; }
    }
}