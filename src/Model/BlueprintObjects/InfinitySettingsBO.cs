using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioBlueprintHelper.Model.BlueprintObjects
{
    public class InfinitySettingsBO
    {
        public InfinityFilterBO[] Filters { get; set; }

        public bool RemoveUnfilteredItems { get; set; }
    }
}
