using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compass.Parse;
using NUnit.Framework;

namespace Compass.Tests.Parse
{
    public class OpenCageSerializationManagerTests : SerializationManagerTest
    {
        [Test]
        [TestCase("parse\\openCageVinnitsa.json", "N/A", "N/A", "Vinnytsia", "Ukraine", "N/A", "N/A", false, 49.2289626, 28.5278061, "N/A", "21000-21499", "Vinnytsia Oblast", "N/A")]
        [TestCase("parse\\openCageSwakopmund.json", "N/A", "N/A", "Swakopmund", "Namibia", "N/A", "N/A", false, -22.6791826, 14.5268016, "N/A", "N/A", "Erongo Region", "N/A")]
        [TestCase("parse\\openCageLondon.json", "N/A", "N/A", "London", "United Kingdom", "N/A", "N/A", false, 51.5288507, -0.2425688, "N/A", "NW10 6UG", "England", "N/A")]
        public void Parse(string filename,
            string areaCode,
            string businessName,
            string city,
            string country,
            string isp,
            string dns,
            bool isUnknown,
            double latitude,
            double longitude,
            string metroCode,
            string postalCode,
            string region,
            string url
            )
        {
            TestDeserialization(filename, areaCode, businessName, city, country, isp, dns, isUnknown, latitude, longitude, metroCode, postalCode, region, url,
                new OpenCageSerializationManager());
        }
    }
}
