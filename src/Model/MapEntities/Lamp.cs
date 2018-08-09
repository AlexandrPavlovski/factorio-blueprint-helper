using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactorioBlueprintHelper.Model.BlueprintConstatns;
using FactorioBlueprintHelper.Model.BlueprintObjects;

namespace FactorioBlueprintHelper.Model.MapEntities
{
    public class Lamp : MapEntity
    {
        public string Color;

        public Lamp(float x, float y)
            : base(x, y)
        {
            Name = EntityNames.SmallLamp;
        }

        public override EntityBO ToBlueprintObject()
        {
            EntityBO entity = base.ToBlueprintObject();

            entity.ControlBehavior = new ControlBehaviorBO
            {
                CircuitCondition = new CircuitConditionBO
                {
                    Comparator = SignalComparators.Greater,
                    Constant = 0,
                    FirstSignal = new SignalIdBO
                    {
                        Name = VirtualSignalNames.Any,
                        Type = SignalTypes.Virtual
                    }
                },
                UseColors = true
            };

            return entity;
        }
    }
}
