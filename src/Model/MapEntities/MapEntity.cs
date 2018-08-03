using FactorioBlueprintHelper.Model.BlueprintObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioBlueprintHelper.Model.MapEntities
{
    public abstract class MapEntity
    {
        public float X;
        public float Y;

        public string Name { get; protected set; }

        public MapEntity(float x, float y)
        {
            X = x;
            Y = y;
        }

        public virtual EntityBO ToBlueprintObject(int number)
        {
            return new EntityBO
            {
                EntityNumber = number,
                Name = Name,
                Position = new PositionBO { X = X, Y = Y }
            };
        }
    }
}
