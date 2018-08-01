using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioBlueprintHelper.Model.BlueprintObjects
{
    public class BlueprintBookBO
    {
        public BlueprintBO[] Blueprints { get; set; }

        public string Item { get; set; }

        public string Label { get; set; }

        public int ActiveIndex { get; set; }

        public Int64 Version { get; set; }
    }
}
