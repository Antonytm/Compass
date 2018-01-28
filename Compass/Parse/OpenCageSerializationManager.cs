using System;
using Compass.Models;
using Sitecore.Analytics.Model;

namespace Compass.Parse
{
    public class OpenCageSerializationManager : SerializationManager, ISerializationManager
    {
        public override WhoIsInformation ParseJsonString(string json)
        {
            var data = OpenCageData.FromJson(json);
            if (data.TotalResults > 0)
            {
                var result = data.Results[0];
                var city = String.IsNullOrEmpty(result.Components.Region)? 
                    result.Components.City:
                    result.Components.Region;
                var longitude = result.Geometry.Lng;
                var latitude = result.Geometry.Lat;
                var country = result.Components.Country;
                var region = result.Components.State;
                var postalCode = result.Components.Postcode;
                var geoIpData = new WhoIsInformation()
                {
                    City = city,
                    AreaCode = "",
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
