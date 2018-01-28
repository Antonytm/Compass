using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Analytics.Model;

namespace Compass.Parse
{
    public abstract class SerializationManager
    {
        public abstract WhoIsInformation ParseJsonString(string json);

        public void SetInteractionValues(string json)
        {
            var data = ParseJsonString(json);
            Sitecore.Analytics.Tracker.Current.Interaction.SetGeoData(data);
        }
    }
}
