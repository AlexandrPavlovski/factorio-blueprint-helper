using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioBlueprintHelper.Model.BlueprintObjects
{
    public class EntityBO
    {
        public int EntityNumber { get; set; }

        public string Name { get; set; }

        public PositionBO Position { get; set; }

        public int Direction { get; set; }

        public ConnectionBO[] Connections { get; set; }

        public ControlBehaviourBO ControlBehaviour { get; set; }

        public ItemRequestBO Items { get; set; } // TODO: find out how this works

        public string Recipe { get; set; }

        public int Bar { get; set; }

        public InfinitySettingsBO InfinitySettings { get; set; }

        public string Type { get; set; }

        public string InputPriority { get; set; }

        public string OutputPriority { get; set; } // can be "right" or "left"

        public string Filter { get; set; }

        public ItemFilterBO Filters { get; set; }

        public int OverrideStackSizesss { get; set; }

        public PositionBO DropPosition { get; set; }

        public PositionBO PickupPosition { get; set; }

        public LogisticFilterBO[] RequestFilters { get; set; }

        public bool RequestFromBuffers { get; set; }

        public SpeakerParameterBO Parameters { get; set; }

        public SpeakerParameterBO AlertParameters { get; set; }

        public bool AutoLaunch { get; set; }

        public object Variation { get; set; } // TODO: find out what is it

        public ColorBO Color { get; set; }

        public string Station { get; set; }
    }
}
