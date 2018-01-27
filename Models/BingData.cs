using Newtonsoft.Json;

namespace Compass.Models
{
    public partial class BingData
    {
        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("bestView")]
        public BestView BestView { get; set; }

        [JsonProperty("entityType")]
        public string EntityType { get; set; }

        [JsonProperty("location")]
        public Center Location { get; set; }

        [JsonProperty("locations")]
        public Center[] Locations { get; set; }

        [JsonProperty("matchCode")]
        public string MatchCode { get; set; }

        [JsonProperty("matchConfidence")]
        public string MatchConfidence { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Address
    {
        [JsonProperty("addressLine")]
        public string AddressLine { get; set; }

        [JsonProperty("adminDistrict")]
        public string AdminDistrict { get; set; }

        [JsonProperty("countryRegion")]
        public string CountryRegion { get; set; }

        [JsonProperty("formattedAddress")]
        public string FormattedAddress { get; set; }

        [JsonProperty("locality")]
        public string Locality { get; set; }
    }

    public partial class BestView
    {
        [JsonProperty("center")]
        public Center Center { get; set; }

        [JsonProperty("width")]
        public double Width { get; set; }

        [JsonProperty("height")]
        public double Height { get; set; }

        [JsonProperty("crs")]
        public Crs Crs { get; set; }

        [JsonProperty("bounds")]
        public double[] Bounds { get; set; }
    }

    public partial class Center
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("altitude")]
        public long Altitude { get; set; }

        [JsonProperty("altitudeReference")]
        public long AltitudeReference { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("precision")]
        public string Precision { get; set; }
    }

    public partial class Crs
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("bounds")]
        public long[] Bounds { get; set; }
    }

    public partial class BingData
    {
        public static BingData FromJson(string json) => JsonConvert.DeserializeObject<BingData>(json, Converter.Settings);
    }
}
