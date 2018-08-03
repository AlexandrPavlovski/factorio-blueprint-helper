﻿using System;
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

        public override EntityBO ToBlueprintObject(int number)
        {
            EntityBO entity = base.ToBlueprintObject(number);

            entity.Connections = new ConnectionBO
            {
                _1 = new ConnectionPointBO
                {
                    Red = 
                }
            };

            return entity;
        }
    }
}
