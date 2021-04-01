using Newtonsoft.Json;
using System;


namespace BridgeMonitor.Models
{
    public class Closurse
    {
        [JsonProperty("boat_name")]
        public string BoatName;

        [JsonProperty("closing_type")]
        public string ClosingType;

        [JsonProperty("closing_date")]
        public DateTime ClosingDate;

        [JsonProperty("reopening_date")]
        public DateTime ReopeningDate;
    }
}
