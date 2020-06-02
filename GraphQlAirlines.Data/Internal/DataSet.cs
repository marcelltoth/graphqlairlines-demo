using System.Collections.Generic;
using GraphQlAirlines.Data.Models;

namespace GraphQlAirlines.Data.Internal
{
    internal class DataSet
    {
        public IReadOnlyList<Aircraft> Aircraft { get; set; }
        public IReadOnlyList<Airline> Airlines { get; set; }
        public IReadOnlyList<Airport> Airports { get; set; }
        public IReadOnlyList<Route> Routes { get; set; }
    }
}