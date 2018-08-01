using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioBlueprintHelper.Model.BlueprintObjects
{
    public class BlueprintRoot
    {
        public BlueprintBookBO BlueprintBook { get; set; }

        public BlueprintBO Blueprint { get; set; }
    }
}
