using System;
using System.Threading.Tasks;
using GraphQlAirlines.Data.Models;

namespace GraphQlAirlines.Api.Types
{
    public class AirlineType
    {
        public AirlineType(int id, string name, string iata, string countryCode)
        {
            Id = id;
            Name = name;
            Iata = iata;
            CountryCode = countryCode;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Iata { get; set; }
        
        public string CountryCode { get; set; }
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