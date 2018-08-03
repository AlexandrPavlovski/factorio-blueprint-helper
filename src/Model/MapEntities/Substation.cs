using FactorioBlueprintHelper.Model.BlueprintConstatns;
using FactorioBlueprintHelper.Model.BlueprintObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioBlueprintHelper.Model.MapEntities
{
    public class Substation : MapEntity
    {
        public Substation(float x, float y)
            : base(x, y)
        {
            Name = EntityNames.Substation;
        }
    }
}
