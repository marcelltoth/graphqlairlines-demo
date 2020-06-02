﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GraphQlAirlines.Data;
using GraphQlAirlines.Data.Models;
using HotChocolate;

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
        private readonly IAirlineDataStore _dataStore;
        private readonly IMapper _mapper;

        public AirlineResolvers(IAirlineDataStore dataStore, IMapper mapper)
        {
            _dataStore = dataStore;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AirportType>> GetDestinations([Parent] AirlineType airline)
        {
            return await Task.WhenAll(
                (await _dataStore.FetchRoutesByAirlineAsync(airline.Id))
                .Select(route => route.DestinationAirportId)
                .Distinct()
                .Select(async airportId =>
                {
                    var airport = await _dataStore.GetAirportByIdAsync(airportId);
                    return _mapper.Map<AirportType>(airport);
                })
            );
        }
        
        public async Task<CountryType> GetOrigin([Parent] AirlineType airline)
        {
            var countries = await _dataStore.FetchAllCountriesAsync();
            return _mapper.Map<CountryType>(countries.FirstOrDefault(c => c.Name == airline.CountryCode));
        }
        
        public async Task<IEnumerable<RouteType>> GetRoutes([Parent] AirlineType airline)
        {
            var routes = await _dataStore.FetchRoutesByAirlineAsync(airline.Id);
            return _mapper.Map<IEnumerable<RouteType>>(routes);
        }
    }
}