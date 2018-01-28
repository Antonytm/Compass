using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compass.Models;
using Sitecore.Analytics.Model;

namespace Compass.Parse
{
    public interface ISerializationManager
    {
        WhoIsInformation ParseJsonString(string json);
        void SetInteractionValues(string json);
    }

    public class BingSerializationManager : SerializationManager, ISerializationManager
    {
        public override WhoIsInformation ParseJsonString(string json)
        {
            var data = BingData.FromJson(json);
            var city = String.IsNullOrEmpty(data.Address.District) ?
                data.Address.Locality :
                data.Address.District;
            var longitude = data.Location.Longitude;
            var latitude = data.Location.Latitude;
            var country = data.Address.CountryRegion;
            var region = data.Address.AdminDistrict;
            var postalCode = data.Address.PostalCode;
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
    }
}
