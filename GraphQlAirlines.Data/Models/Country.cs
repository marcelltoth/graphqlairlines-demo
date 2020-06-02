namespace GraphQlAirlines.Data.Models
{
    public class Country
    {
        public Country(string name, string? isoCode, string? dafifCode)
        {
            Name = name;
            IsoCode = isoCode;
            DafifCode = dafifCode;
        }

        public string Name { get; }

        public string? IsoCode { get; }

        public string? DafifCode { get; }
    }
}