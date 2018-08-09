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
        public int Number;

        public float X;
        public float Y;

        public List<WireConnection> RedConnections;
        public List<WireConnection> GreenConnections;

        public string Name { get; protected set; }

        public MapEntity(float x, float y)
        {
            X = x;
            Y = y;

            RedConnections = new List<WireConnection>();
            GreenConnections = new List<WireConnection>();
        }

        public virtual EntityBO ToBlueprintObject()
        {
            var entity = new EntityBO
            {
                EntityNumber = Number,
                Name = Name,
                Position = new PositionBO { X = X, Y = Y }
            };

            if (RedConnections.Any())
            {
                entity.Connections = new ConnectionBO
                {
                    _1 = new ConnectionPointBO
                    {
                        Red = RedConnections.Select(x => x.ToBlueprintObject()).ToArray()
                    }
                };
            }

            return entity;
        }
    }
}
