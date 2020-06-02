namespace GraphQlAirlines.Data.Models
{
    public class Route
    {
        public Route(int airlineId, int sourceAirportId, int destinationAirportId, bool codeShare, int stops, string equipment)
        {
            AirlineId = airlineId;
            SourceAirportId = sourceAirportId;
            DestinationAirportId = destinationAirportId;
            CodeShare = codeShare;
            Stops = stops;
            Equipment = equipment;
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
        ///     Y if this flight is a codeshare (that is, not operated by Airline, but another carrier), empty otherwise.
        /// </summary>
        public bool CodeShare { get; }

        /// <summary>
        ///     Number of stops on this flight (0 for direct)
        /// </summary>
        public int Stops { get; set; }

        /// <summary>
        ///     3-letter codes for plane type(s) generally used on this flight, separated by spaces
        /// </summary>
        public string Equipment { get; set; }
    }
}