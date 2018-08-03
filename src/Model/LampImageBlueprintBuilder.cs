using FactorioBlueprintHelper.Model.BlueprintConstatns;
using FactorioBlueprintHelper.Model.BlueprintObjects;
using FactorioBlueprintHelper.Model.MapEntities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioBlueprintHelper.Model
{
    public class LampImageBlueprintBuilder
    {
        public LampImageBlueprintBuilder() { }

        public string CreateColoredLampsImageBluepring(ImageWorker imageWorker)
        {
            var bmp = imageWorker.Bitmap;
            var map = new Map(bmp.Width, bmp.Height);
            var colorGroups = new Dictionary<string, List<Lamp>>();

            map.FillWithSubstations();

            for (int x = 0; x < bmp.Width; x++)
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);
                    if (pixelColor.A > 240) // ignoring semi-transparent pixels
                    {
                        string lampColor = LampColors.ColorToSignalLookup[imageWorker.GetClosestLampColor(x, y)];
                        var lamp = new Lamp(x, y)
                        {
                            Color = lampColor
                        };

                        if (map[x, y] == null)
                        {
                            map[x, y] = lamp;

                            if (colorGroups.ContainsKey(lampColor) == false)
                                colorGroups[lampColor] = new List<Lamp>();
                            colorGroups[lampColor].Add(lamp);
                        }
                    }
                }

            return map.ToEncodedString();
        }
    }
}
