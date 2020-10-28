namespace QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Localization
    {
        [JsonProperty("US", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Us { get; set; }

        [JsonProperty("CZ", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Cz { get; set; }

        [JsonProperty("DE", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> De { get; set; }

        [JsonProperty("ES", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Es { get; set; }

        [JsonProperty("FR", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Fr { get; set; }

        [JsonProperty("IT", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> It { get; set; }

        [JsonProperty("PL", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Pl { get; set; }

        [JsonProperty("RU", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Ru { get; set; }

        [JsonProperty("TZM", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Tzm { get; set; }
    }
}
