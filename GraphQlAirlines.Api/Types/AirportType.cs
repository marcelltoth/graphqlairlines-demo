using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GraphQlAirlines.Data;
using GraphQlAirlines.Data.Models;
using HotChocolate;

namespace GraphQlAirlines.Api.Types
{
    public class AirportType
    {
        public AirportType(int id, string name, string city, string country, string? iata, decimal timezone,
            GraphQlDstType dst)
        {
            Id = id;
            Name = name;
            City = city;
            Country = country;
            Iata = iata;
            Timezone = timezone;
            Dst = dst;
        }

        /// <summary>
        ///     Unique OpenFlights identifier for this airport.
        /// </summary>
        public int Id { get; }

        /// <summary>
        ///     Name of airport. May or may not contain the City name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     Main city served by airport. May be spelled differently from Name.
        /// </summary>
        public string City { get; }

        /// <summary>
        ///     Country or territory where airport is located. See countries.dat to cross-reference to ISO 3166-1 codes.
        /// </summary>
        [GraphQLIgnore]
        public string Country { get; }

        /// <summary>
        ///     3-letter IATA code. Null if not assigned/unknown.
        /// </summary>
        public string? Iata { get; }

        /// <summary>
        ///     Hours offset from UTC. Fractional hours are expressed as decimals, eg. India is 5.5.
        /// </summary>
        public decimal Timezone { get; }

        /// <summary>
        ///     Daylight savings time. One of E (Europe), A (US/Canada), S (South America), O (Australia), Z (New Zealand), N
        ///     (None) or U (Unknown). See also: Help: Time
        /// </summary>
        public GraphQlDstType Dst { get; }
    }

    public class AirportResolvers
    {
        private readonly IAirlineDataStore _dataStore;
        private readonly IMapper _mapper;

        public AirportResolvers(IAirlineDataStore dataStore, IMapper mapper)
        {
            _dataStore = dataStore;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AirlineType>> GetAirlines([Parent] AirportType airport)
        {
            var routes = await GetRoutesInternal(airport);
            var airlineIds = routes.Select(r => r.AirlineId).Distinct();
            var airlines = await Task.WhenAll(airlineIds.Select(_dataStore.GetAirlineByIdAsync));
            return _mapper.Map<IEnumerable<AirlineType>>(airlines.Where(airline => airline != null));
        }

        public async Task<CountryType> GetCountry([Parent] AirportType airport)
        {
            var country = (await _dataStore.FetchAllCountriesAsync()).FirstOrDefault(c => c.Name == airport.Country);
            return country != null
                ? _mapper.Map<CountryType>(country)
                : new CountryType(airport.Country, null, null);
        }

        public async Task<IEnumerable<RouteType>> GetRoutes([Parent] AirportType airport)
        {
            var routes = await GetRoutesInternal(airport);
            return _mapper.Map<IEnumerable<RouteType>>(routes);
        }

        private async Task<IEnumerable<Route>> GetRoutesInternal(AirportType airport)
        {
            return (await _dataStore.FetchRoutesByDestinationAirportAsync(airport.Id))
                .Concat(await _dataStore.FetchRoutesBySourceAirportAsync(airport.Id));
        }
    }
}