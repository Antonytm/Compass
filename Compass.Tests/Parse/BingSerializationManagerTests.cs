using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Compass.Tests.Parse
{
    [TestFixture]
    class BingSerializationManagerTests : SerializationManagerTest
    {
        [SetUp]
        protected void SetUp()
        {

        }

        [Test]
        [TestCase("parse\\bingVinnitsa.json", "N/A", "N/A", "Vinnytsia", "Ukraine", "N/A", "N/A", false, 49.23311, 28.46826, "N/A", "N/A", "Vinnytska oblast", "N/A")]
        [TestCase("parse\\bingLondon.json", "N/A", "N/A", "London", "United Kingdom", "N/A", "N/A", false, 51.4866388, -0.2077119, "N/A", "W14 9", "England", "N/A")]
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
            TestDeserialization(filename, areaCode, businessName, city, country, isp, dns, isUnknown, latitude, longitude, metroCode, postalCode, region, url);
        }
    }
}
