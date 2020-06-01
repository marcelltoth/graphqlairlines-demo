namespace GraphQlAirlines.Data.Models
{
    public class Airline
    {
        public Airline(int airlineId, string name, string alias, string iata, string icao, string callSign,
            string country, bool active)
        {
            AirlineId = airlineId;
            Name = name;
            Alias = alias;
            Iata = iata;
            Icao = icao;
            CallSign = callSign;
            Country = country;
            Active = active;
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
        ///     Alias of the airline. For example, All Nippon Airways is commonly known as ANA.
        /// </summary>
        public string Alias { get; }

        /// <summary>
        ///     2-letter IATA code, if available.
        /// </summary>
        public string Iata { get; }

        /// <summary>
        ///     3-letter ICAO code, if available.
        /// </summary>
        public string Icao { get; }

        /// <summary>
        ///     Airline callsign.
        /// </summary>
        public string CallSign { get; }

        /// <summary>
        ///     Country or territory where airline is incorporated.
        /// </summary>
        public string Country { get; }

        /// <summary>
        ///     <code>true</code> if the airline is or has until recently been operational, <code>false</code> if it is defunct.
        ///     This field is not reliable: in particular, major airlines that stopped flying long ago, but have not had their IATA
        ///     code reassigned (eg. Ansett/AN), will incorrectly show as <code>true</code>.
        /// </summary>
        public bool Active { get; }
    }
}