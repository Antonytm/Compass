using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compass.Models;
using Sitecore.Analytics.Model;

namespace Compass.Parse
{
    public class BingSerializationManager:SerializationManager
    {
        public override WhoIsInformation ParseJsonString(string json)
        {
            var data = BingData.FromJson(json);
            var city = data.Address.Locality;
            var longitude = data.Location.Longitude;
            var latitude = data.Location.Latitude;
            var country = data.Address.CountryRegion;
            var region = data.Address.CountryRegion;
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
                PostalCode = "",
                Region = region,
                Url = ""
                           
            };
            return geoIpData;
        }
    }
}
