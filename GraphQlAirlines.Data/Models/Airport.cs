namespace GraphQlAirlines.Data.Models
{
    public class Airport
    {
        public Airport(int airportId, string name, string city, string country, string? iata,
            decimal timezone, DstType dst)
        {
            AirportId = airportId;
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
        public int AirportId { get; }

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
        public DstType Dst { get; }
    }
}