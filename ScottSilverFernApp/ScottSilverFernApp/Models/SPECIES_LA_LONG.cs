using System;
using System.Collections.Generic;
using System.Text;

namespace ScottSilverFernApp.Models
{
    public class SPECIES_LA_LONG
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public string id { get; set; }

        [Newtonsoft.Json.JsonProperty("speciesName")]
        public string speciesName { get; set; }

        [Newtonsoft.Json.JsonProperty("latitude")]
        public double latitude { get; set; }

        [Newtonsoft.Json.JsonProperty("longtitude")]
        public double longtitude { get; set; }
    }
}
