using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioBlueprintHelper.Model.BlueprintObjects
{
    public class InfinityFilterBO
    {
        public string Name { get; set; }

        public int Count { get; set; }

        public string Mode { get; set; } // can be "at-least", "at-most", or "exactly"

        public int Index { get; set; }
    }
}
