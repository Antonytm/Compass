using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compass.Models;
using Sitecore.Analytics.Model;

namespace Compass.Parse
{
    public class GoogleSerializationManager : SerializationManager, ISerializationManager
    {
        public override WhoIsInformation ParseJsonString(string json)
        {
            var data = GoogleData.FromJson(json);
            if (data.Length > 0)
            {
                var address = data[0];
                var city = address.AddressComponents.Any(x => x.Types.Contains("locality"))
                    ? address.AddressComponents.First(x => x.Types.Contains("locality")).LongName
                    : "";

                var country = address.AddressComponents.Any(x => x.Types.Contains("country"))
                    ? address.AddressComponents.First(x => x.Types.Contains("country")).LongName
                    : "";

                var postalCode = address.AddressComponents.Any(x => x.Types.Contains("postal_code"))
                    ? address.AddressComponents.First(x => x.Types.Contains("postal_code")).LongName
                    : "";

                var region = address.AddressComponents.Any(x => x.Types.Contains("administrative_area_level_1"))
                    ? address.AddressComponents.First(x => x.Types.Contains("administrative_area_level_1")).LongName
                    : "";

                var latitude = address.Geometry.Location.Lat;
                var longitude = address.Geometry.Location.Lng;
                var geoIpData = new WhoIsInformation()
                {
                    City = city,
                    AreaCode = ",",
                    BusinessName = "",
                    Country = country,
                    Dns = "",
                    Isp = "",
                    IsUnknown = false,
                    Latitude = latitude,
                    Longitude = longitude,
                    MetroCode = "",
                    PostalCode = postalCode,
                    Region = region,
                    Url = ""

                };
                return geoIpData;
            }
            return null;
        }
    }
}
