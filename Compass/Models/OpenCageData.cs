using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Compass.Models
{
    public partial class OpenCageData
    {
        [JsonProperty("documentation")]
        public string Documentation { get; set; }

        [JsonProperty("licenses")]
        public License[] Licenses { get; set; }

        [JsonProperty("rate")]
        public Rate Rate { get; set; }

        [JsonProperty("results")]
        public Result[] Results { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("stay_informed")]
        public StayInformed StayInformed { get; set; }

        [JsonProperty("thanks")]
        public string Thanks { get; set; }

        [JsonProperty("timestamp")]
        public Timestamp Timestamp { get; set; }

        [JsonProperty("total_results")]
        public long TotalResults { get; set; }
    }

    public partial class License
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class Rate
    {
        [JsonProperty("limit")]
        public long Limit { get; set; }

        [JsonProperty("remaining")]
        public long Remaining { get; set; }

        [JsonProperty("reset")]
        public long Reset { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("annotations")]
        public Annotations Annotations { get; set; }

        [JsonProperty("bounds")]
        public Bounds Bounds { get; set; }

        [JsonProperty("components")]
        public Components Components { get; set; }

        [JsonProperty("confidence")]
        public long Confidence { get; set; }

        [JsonProperty("formatted")]
        public string Formatted { get; set; }

        [JsonProperty("geometry")]
        public Northeast Geometry { get; set; }
    }

    public partial class Annotations
    {
        [JsonProperty("DMS")]
        public Dms Dms { get; set; }

        [JsonProperty("MGRS")]
        public string Mgrs { get; set; }

        [JsonProperty("Maidenhead")]
        public string Maidenhead { get; set; }

        [JsonProperty("Mercator")]
        public Mercator Mercator { get; set; }

        [JsonProperty("OSM")]
        public Osm Osm { get; set; }

        [JsonProperty("callingcode")]
        public long Callingcode { get; set; }

        [JsonProperty("currency")]
        public Currency Currency { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonProperty("geohash")]
        public string Geohash { get; set; }

        [JsonProperty("qibla")]
        public double Qibla { get; set; }

        [JsonProperty("sun")]
        public Sun Sun { get; set; }

        [JsonProperty("timezone")]
        public Timezone Timezone { get; set; }

        [JsonProperty("what3words")]
        public What3Words What3Words { get; set; }
    }

    public partial class Currency
    {
        [JsonProperty("alternate_symbols")]
        public string[] AlternateSymbols { get; set; }

        [JsonProperty("decimal_mark")]
        public string DecimalMark { get; set; }

        [JsonProperty("disambiguate_symbol")]
        public string DisambiguateSymbol { get; set; }

        [JsonProperty("html_entity")]
        public string HtmlEntity { get; set; }

        [JsonProperty("iso_code")]
        public string IsoCode { get; set; }

        [JsonProperty("iso_numeric")]
        public long IsoNumeric { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("smallest_denomination")]
        public long SmallestDenomination { get; set; }

        [JsonProperty("subunit")]
        public string Subunit { get; set; }

        [JsonProperty("subunit_to_unit")]
        public long SubunitToUnit { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("symbol_first")]
        public long SymbolFirst { get; set; }

        [JsonProperty("thousands_separator")]
        public string ThousandsSeparator { get; set; }
    }

    public partial class Dms
    {
        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("lng")]
        public string Lng { get; set; }
    }

    public partial class Mercator
    {
        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }
    }

    public partial class Osm
    {
        [JsonProperty("edit_url")]
        public string EditUrl { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class Sun
    {
        [JsonProperty("rise")]
        public Rise Rise { get; set; }

        [JsonProperty("set")]
        public Rise Set { get; set; }
    }

    public partial class Rise
    {
        [JsonProperty("apparent")]
        public long Apparent { get; set; }

        [JsonProperty("astronomical")]
        public long Astronomical { get; set; }

        [JsonProperty("civil")]
        public long Civil { get; set; }

        [JsonProperty("nautical")]
        public long Nautical { get; set; }
    }

    public partial class Timezone
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("now_in_dst")]
        public long NowInDst { get; set; }

        [JsonProperty("offset_sec")]
        public long OffsetSec { get; set; }

        [JsonProperty("offset_string")]
        public long OffsetString { get; set; }

        [JsonProperty("short_name")]
        public string ShortName { get; set; }
    }

    public partial class What3Words
    {
        [JsonProperty("words")]
        public string Words { get; set; }
    }

    public partial class Bounds
    {
        [JsonProperty("northeast")]
        public Northeast Northeast { get; set; }

        [JsonProperty("southwest")]
        public Northeast Southwest { get; set; }
    }

    public partial class Northeast
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }
    }

    public partial class Components
    {
        [JsonProperty("ISO_3166-1_alpha-2")]
        public string Iso31661_Alpha2 { get; set; }

        [JsonProperty("_type")]
        public string PurpleType { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("postcode")]
        public string Postcode { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("restaurant")]
        public string Restaurant { get; set; }

        [JsonProperty("road")]
        public string Road { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("suburb")]
        public string Suburb { get; set; }
    }

    public partial class Status
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public partial class StayInformed
    {
        [JsonProperty("blog")]
        public string Blog { get; set; }

        [JsonProperty("twitter")]
        public string Twitter { get; set; }
    }

    public partial class Timestamp
    {
        [JsonProperty("created_http")]
        public string CreatedHttp { get; set; }

        [JsonProperty("created_unix")]
        public long CreatedUnix { get; set; }
    }

    public partial class OpenCageData
    {
        public static OpenCageData FromJson(string json) => JsonConvert.DeserializeObject<OpenCageData>(json, Converter.Settings);
    }
}
