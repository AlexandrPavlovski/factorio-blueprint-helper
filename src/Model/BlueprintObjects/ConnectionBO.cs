using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioBlueprintHelper.Model.BlueprintObjects
{
    public class ConnectionBO
    {
        [JsonProperty(PropertyName = "1")]
        public ConnectionPointBO _1 { get; set; }

        [JsonProperty(PropertyName = "2")]
        public ConnectionPointBO _2 { get; set; }
    }
}
