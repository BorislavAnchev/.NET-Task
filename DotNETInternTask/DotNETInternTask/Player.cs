using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DotNETInternTask
{
    class Player
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("PlayerSince")]
        public int PlayerSince { get; set; }

        [JsonProperty("Position")]
        public string Position { get; set; }

        [JsonProperty("Rating")]
        public double Rating { get; set; }
    }
}
