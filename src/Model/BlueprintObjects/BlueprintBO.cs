using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioBlueprintHelper.Model.BlueprintObjects
{
    public class BlueprintBO
    {
        public IconBO[] Icons { get; set; }

        public EntityBO[] Entities { get; set; }

        public TileBO[] Tiles { get; set; }

        public string Item { get; set; }

        public string Label { get; set; }

        public Int64 Version { get; set; }
    }
}
