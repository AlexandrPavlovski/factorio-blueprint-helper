using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioBlueprintHelper.Model.BlueprintObjects
{
    public class SignalIdBO
    {
        public string Type { get; set; } // can be "item", "fluid", "virtual"

        public string Name { get; set; }
    }
}
