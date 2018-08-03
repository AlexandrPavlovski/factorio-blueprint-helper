using FactorioBlueprintHelper.Model.BlueprintObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioBlueprintHelper.Model.MapEntities
{
    public class WireConnection
    {
        public MapEntity First { get; private set; }
        public MapEntity Second { get; private set; }

        public WireConnection(MapEntity first, MapEntity second)
        {
            if (first == second)
                throw new ArgumentException("Provided entities are equal. Connection cannot be made from entity to itself");

            First = first;
            Second = second;
        }

        public ConnectionDataBO ToBlueprintObject()
        {
            var data = new ConnectionDataBO
            {
                EntityId = Second.;
            };
        }
    }
}
