using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchClient
{
    public class SmartwatchData
    {
        public int activityTimeMinutes { get; set; }
        public int distanceMeters { get; set; }
        public float energyBurnedKcal { get; set; }
        public int heartBeat { get; set; }
        public Meta meta { get; set; }
        public int steps { get; set; }
    }

    public class Meta
    {
        public string device { get; set; }
        public string periodRange { get; set; }
        public int updateFrequencySeconds { get; set; }
    }
}
