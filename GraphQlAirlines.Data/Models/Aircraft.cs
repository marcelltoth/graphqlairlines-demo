namespace GraphQlAirlines.Data.Models
{
    public class Aircraft
    {
        public Aircraft(string name, string iata, string icao)
        {
            Name = name;
            Iata = iata;
            Icao = icao;
        }

        /// <summary>
        ///     Full name of the aircraft.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     IATA code
        /// </summary>
        public string Iata { get; }

        /// <summary>
        ///     ICAO code
        /// </summary>
        public string Icao { get; }
    }
}