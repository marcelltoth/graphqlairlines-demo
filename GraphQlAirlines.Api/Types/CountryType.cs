namespace GraphQlAirlines.Api.Types
{
    public class CountryType
    {
        public CountryType(string name, string? isoCode, string? dafifCode)
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