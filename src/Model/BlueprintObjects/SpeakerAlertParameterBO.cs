using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioBlueprintHelper.Model.BlueprintObjects
{
    public class SpeakerAlertParameterBO
    {
        public bool ShowAlert { get; set; }

        public bool ShowOnMap { get; set; }

        public SignalIdBO IconSignalId { get; set; }

        public string AlertMessage { get; set; }
    }
}
