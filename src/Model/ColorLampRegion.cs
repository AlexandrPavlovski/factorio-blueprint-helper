using FactorioBlueprintHelper.Model.MapEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioBlueprintHelper.Model
{
    public class ColorLampRegion
    {
        public string Color { get; private set; }
        public List<Lamp> Lamps { get; private set; }

        public ColorLampRegion(string color)
        {
            Color = color;
            Lamps = new List<Lamp>();
        }

        public void AddLamp(Lamp lamp)
        {
            Lamps.Add(lamp);
        }
    }
}
