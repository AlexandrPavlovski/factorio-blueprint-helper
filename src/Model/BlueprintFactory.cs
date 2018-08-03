using FactorioBlueprintHelper.Model.BlueprintConstatns;
using FactorioBlueprintHelper.Model.BlueprintObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioBlueprintHelper.Model
{
    public static class BlueprintFactory
    {
        public static BlueprintRoot GetBlueprintWithIcon()
        {
            var root = new BlueprintRoot();

            root.Blueprint = new BlueprintBO
            {
                Icons = new[] { new IconBO { Index = 1, Signal = new SignalIdBO { Type = SignalTypes.Item, Name = EntityNames.SmallLamp } } },
                Item = "blueprint",
                Version = 1
            };

            return root;
        }
    }
}
