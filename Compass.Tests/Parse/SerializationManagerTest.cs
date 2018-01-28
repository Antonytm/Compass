using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compass.Parse;
using FluentAssertions;
using NUnit.Framework;

namespace Compass.Tests.Parse
{
    public class SerializationManagerTest
    {
        public static void TestDeserialization(string filename, string areaCode, string businessName, string city,
            string country, string isp, string dns, bool isUnknown, double latitude, double longitude, string metroCode,
            string postalCode, string region, string url, ISerializationManager manager)
        {
            
            var directory = Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory);
            var path = $"{directory}\\debug\\{filename}";
            var json = File.ReadAllText(path);
            var whoIs = manager.ParseJsonString(json);

            whoIs.AreaCode.Should().Be(areaCode);
            whoIs.BusinessName.Should().Be(businessName);
            whoIs.City.Should().Be(city);
            whoIs.Country.Should().Be(country);
            whoIs.Dns.Should().Be(dns);
            whoIs.Isp.Should().Be(isp);
            whoIs.IsUnknown.Should().Be(isUnknown);
            whoIs.Latitude.Should().Be(latitude);
            whoIs.Longitude.Should().Be(longitude);
            whoIs.MetroCode.Should().Be(metroCode);
            whoIs.PostalCode.Should().Be(postalCode);
            whoIs.Region.Should().Be(region);
            whoIs.Url.Should().Be(url);
        }
    }
}
