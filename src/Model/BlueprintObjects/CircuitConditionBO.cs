using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioBlueprintHelper.Model.BlueprintObjects
{
    public class CircuitConditionBO
    {
        public SignalIdBO FirstSignal { get; set; }

        public int Constant { get; set; }

        public string Comparator { get; set; }
    }
}
