using System;
using System.Threading.Tasks;
using GraphQlAirlines.Data.Models;

namespace GraphQlAirlines.Api.Types
{
    public class AirlineType
    {
        public AirlineType(int id, string name, string? alias, string iata, string icao, string callsign,
            string countryCode, bool active)
        {
            Id = id;
            Name = name;
            Alias = alias;
            Iata = iata;
            Icao = icao;
            Callsign = callsign;
            CountryCode = countryCode;
            Active = active;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string? Alias { get; set; }

        public string Iata { get; set; }

        public string Icao { get; set; }

        public string Callsign { get; set; }

        public string CountryCode { get; set; }
        
        public bool Active { get; set; }
    }

    public class AirlineResolvers
    {
        public async Task<Airport> GetDestinations()
        {
            throw new NotImplementedException();
        }
        
        public async Task<Country> GetOrigin()
        {
            throw new NotImplementedException();
        }
        
        public async Task<Country> GetRoutes()
        {
            throw new NotImplementedException();
        }
    }
}