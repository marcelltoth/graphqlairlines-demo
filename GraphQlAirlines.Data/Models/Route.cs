namespace GraphQlAirlines.Data.Models
{
    public class Route
    {
        public Route(int airlineId, int sourceAirportId, int destinationAirportId, bool codeShare, int stops)
        {
            AirlineId = airlineId;
            SourceAirportId = sourceAirportId;
            DestinationAirportId = destinationAirportId;
            CodeShare = codeShare;
            Stops = stops;
        }

        /// <summary>
        ///     Unique OpenFlights identifier for airline (see Airline).
        /// </summary>
        public int AirlineId { get; }

        /// <summary>
        ///     Unique OpenFlights identifier for source airport (see Airport)
        /// </summary>
        public int SourceAirportId { get; }

        /// <summary>
        ///     Unique OpenFlights identifier for destination airport (see Airport)
        /// </summary>
        public int DestinationAirportId { get; }

        /// <summary>
        ///     <code>true</code> if this flight is a codeshare (that is, not operated by Airline, but another carrier),
        ///     <code>false</code> otherwise.
        /// </summary>
        public bool CodeShare { get; }

        /// <summary>
        ///     Number of stops on this flight (0 for direct)
        /// </summary>
        public int Stops { get; }
    }
}