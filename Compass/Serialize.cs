using Compass.Models;
using Newtonsoft.Json;

namespace Compass
{
    public static partial class Serialize
    {
        public static string ToJson(this BingData self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this GoogleData[] self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}
