using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using GraphQlAirlines.Data.Internal;
using GraphQlAirlines.Data.Models;

namespace GraphQlAirlines.Data
{
    public class LocalFileAirlineDataStore : IAirlineDataStore
    {
        private const string DataFolder = "./Data";
        private const string AircraftFile = "planes.dat";
        private const string CountriesFile = "countries.dat";
        private const string RoutesFile = "routes.dat";
        private const string AirlinesFile = "airlines.dat";
        private const string AirportsFile = "airports.dat";
        private const string NullFieldValue = "\\N";
        private readonly AsyncLazy<DataSet> _dataSet;

        public LocalFileAirlineDataStore()
        {
            _dataSet = new AsyncLazy<DataSet>(async () => new DataSet(
                await LoadAircraftAsync(Path.Combine(DataFolder, AircraftFile)).ToListAsync(),
                await LoadAirlinesAsync(Path.Combine(DataFolder, AirlinesFile)).ToListAsync(),
                await LoadAirportsAsync(Path.Combine(DataFolder, AirportsFile)).ToListAsync(),
                await LoadRoutesAsync(Path.Combine(DataFolder, RoutesFile)).ToListAsync(),
                await LoadCountriesAsync(Path.Combine(DataFolder, CountriesFile)).ToListAsync()
            ));
        }

        public async Task<IEnumerable<Airline>> FetchAllAirlinesAsync()
        {
            return (await _dataSet).Airlines;
        }

        public async Task<Airline?> GetAirlineByIdAsync(int id)
        {
            return (await _dataSet).Airlines.FirstOrDefault(a => a.AirlineId == id);
        }

        public async Task<IEnumerable<Aircraft>> FetchAllAircraftAsync()
        {
            return (await _dataSet).Aircraft;
        }

        public async Task<IEnumerable<Airport>> FetchAllAirportsAsync()
        {
            return (await _dataSet).Airports;
        }

        public async Task<Airport?> GetAirportByIdAsync(int id)
        {
            return (await _dataSet).Airports.FirstOrDefault(a => a.AirportId == id);
        }

        public async Task<IEnumerable<Route>> FetchAllRoutesAsync()
        {
            return (await _dataSet).Routes;
        }

        private static async IAsyncEnumerable<Aircraft> LoadAircraftAsync(string path)
        {
            using var streamReader = new StreamReader(path);
            using var csvReader = new CsvReader(streamReader,
                new CsvConfiguration(CultureInfo.InvariantCulture) {HasHeaderRecord = false});
            
            while (await csvReader.ReadAsync())
                yield return new Aircraft(
                    csvReader.GetField<string>(0),
                    csvReader.GetField<string>(1),
                    csvReader.GetField<string>(2)
                );
        }
        
        private static async IAsyncEnumerable<Airline> LoadAirlinesAsync(string path)
        {
            using var streamReader = new StreamReader(path);
            using var csvReader = new CsvReader(streamReader,
                new CsvConfiguration(CultureInfo.InvariantCulture) {HasHeaderRecord = false});
            
            while (await csvReader.ReadAsync())
            {
                var alias = csvReader.GetField<string>(2);
                yield return new Airline(
                    csvReader.GetField<int>(0),
                    csvReader.GetField<string>(1),
                    alias == NullFieldValue ? null : alias,
                    csvReader.GetField<string>(3),
                    csvReader.GetField<string>(4),
                    csvReader.GetField<string>(5),
                    csvReader.GetField<string>(6),
                    csvReader.GetField<string>(7) == "Y"
                );
            }
        }
        
        
        private static async IAsyncEnumerable<Airport> LoadAirportsAsync(string path)
        {
            using var streamReader = new StreamReader(path);
            using var csvReader = new CsvReader(streamReader,
                new CsvConfiguration(CultureInfo.InvariantCulture) {HasHeaderRecord = false});

            while (await csvReader.ReadAsync())
            {
                var iata = csvReader.GetField<string>(4);
                var icao = csvReader.GetField<string>(5);
                var dstField = csvReader.GetField<string>(10);
                yield return new Airport(
                    csvReader.GetField<int>(0),
                    csvReader.GetField<string>(1),
                    csvReader.GetField<string>(2),
                    csvReader.GetField<string>(3),
                    iata == NullFieldValue ? null : iata,
                    icao == NullFieldValue ? null : icao,
                    csvReader.GetField<decimal>(6),
                    csvReader.GetField<decimal>(7),
                    csvReader.GetField<decimal>(8),
                    csvReader.GetField<decimal>(9),
                    dstField == NullFieldValue ? DstType.Unknown : ParseDst(dstField.First())
                );
            }
        }

        private static async IAsyncEnumerable<Route> LoadRoutesAsync(string path)
        {
            using var streamReader = new StreamReader(path);
            using var csvReader = new CsvReader(streamReader,
                new CsvConfiguration(CultureInfo.InvariantCulture) {HasHeaderRecord = false});

            while (await csvReader.ReadAsync())
            {
                Route route;
                
                try
                {
                    route = new Route(
                        csvReader.GetField<int>(1),
                        csvReader.GetField<int>(3),
                        csvReader.GetField<int>(5),
                        csvReader.GetField<string>(6) == "Y",
                        csvReader.GetField<int>(7),
                        csvReader.GetField<string>(8)
                    );
                }
                catch (TypeConverterException)
                {
                    // Ignore incomplete entries
                    continue;
                }
                
                yield return route;
            }
        }
        
        private static async IAsyncEnumerable<Country> LoadCountriesAsync(string path)
        {
            using var streamReader = new StreamReader(path);
            using var csvReader = new CsvReader(streamReader,
                new CsvConfiguration(CultureInfo.InvariantCulture) {HasHeaderRecord = false});

            while (await csvReader.ReadAsync())
            {
                var iso = csvReader.GetField<string>(1);
                var dafif = csvReader.GetField<string>(2);
                yield return new Country(
                    csvReader.GetField<string>(0),
                    iso == NullFieldValue ? null : iso,
                    dafif == NullFieldValue ? null : dafif
                );
            }
        }

        private static DstType ParseDst(char first)
        {
            return first switch
            {
                'E' => DstType.Europe,
                'A' => DstType.NorthAmerica,
                'S' => DstType.SouthAmerica,
                'O' => DstType.Australia,
                'Z' => DstType.NewZealand,
                'N' => DstType.None,
                _ => DstType.Unknown
            };
        }
    }
}