namespace GraphQlAirlines.Data.Models
{
    public class Airline
    {
        public Airline(int airlineId, string name, string iata, string country)
        {
            AirlineId = airlineId;
            Name = name;
            Iata = iata;
            Country = country;
        }

        /// <summary>
        ///     Unique OpenFlights identifier for this airline.
        /// </summary>
        public int AirlineId { get; }

        /// <summary>
        ///     Name of the airline.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     2-letter IATA code, if available.
        /// </summary>
        public string Iata { get; }

        /// <summary>
        ///     Country or territory where airline is incorporated.
        /// </summary>
        public string Country { get; }
    }
}