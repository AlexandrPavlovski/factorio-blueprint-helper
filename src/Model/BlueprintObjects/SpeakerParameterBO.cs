using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioBlueprintHelper.Model.BlueprintObjects
{
    public class SpeakerParameterBO
    {
        public float PlaybackVolume { get; set; }

        public bool PlaybackGlobally { get; set; }

        public bool AllowPolyphony { get; set; }
    }
}
