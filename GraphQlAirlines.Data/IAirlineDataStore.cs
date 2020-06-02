using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQlAirlines.Data.Models;

namespace GraphQlAirlines.Data
{
    public interface IAirlineDataStore
    {
        Task<IEnumerable<Airline>> FetchAllAirlinesAsync();

        Task<Airline?> GetAirlineByIdAsync(int id);
        
        Task<IEnumerable<Aircraft>> FetchAllAircraftAsync();
        
        Task<IEnumerable<Airport>> FetchAllAirportsAsync();

        Task<Airport?> GetAirportByIdAsync(int id);
        
        Task<IEnumerable<Route>> FetchAllRoutesAsync();
        
        Task<IEnumerable<Route>> FetchRoutesByAirlineAsync(int airlineId);
        
        Task<IEnumerable<Route>> FetchRoutesBySourceAirportAsync(int sourceAirportId);
        
        Task<IEnumerable<Route>> FetchRoutesByDestinationAirportAsync(int destinationAirportId);

        Task<IEnumerable<Country>> FetchAllCountriesAsync();
    }
}