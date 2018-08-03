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

            var colorRegions = new List<ColorLampRegion>();
            foreach (var group in colorGroups)
            {
                while (group.Value.Count != 0)
                {
                    var region = new ColorLampRegion(group.Key);
                    BuildConnectionTreeAndFillRegion(region, group.Value, map, group.Value.First());
                    colorRegions.Add(region);
                }
            }

            return map.ToEncodedString();
        }

        private void BuildConnectionTreeAndFillRegion(ColorLampRegion region, List<Lamp> colorLampGroup, Map map, Lamp lamp)
        {
            Lamp neighbourLamp = CreateConnectionToNeighbour(-1, -1, lamp, map);
            if (neighbourLamp != null)
            {
                region.AddLamp(neighbourLamp);
                BuildConnectionTreeAndFillRegion(region, colorLampGroup, map, neighbourLamp);
            }
            neighbourLamp = CreateConnectionToNeighbour( 0, -1, lamp, map);
            if (neighbourLamp != null)
            {
                region.AddLamp(neighbourLamp);
                BuildConnectionTreeAndFillRegion(region, colorLampGroup, map, neighbourLamp);
            }
            neighbourLamp = CreateConnectionToNeighbour( 1, -1, lamp, map);
            if (neighbourLamp != null)
            {
                region.AddLamp(neighbourLamp);
                BuildConnectionTreeAndFillRegion(region, colorLampGroup, map, neighbourLamp);
            }
            neighbourLamp = CreateConnectionToNeighbour(-1,  0, lamp, map);
            if (neighbourLamp != null)
            {
                region.AddLamp(neighbourLamp);
                BuildConnectionTreeAndFillRegion(region, colorLampGroup, map, neighbourLamp);
            }
            neighbourLamp = CreateConnectionToNeighbour( 1,  0, lamp, map);
            if (neighbourLamp != null)
            {
                region.AddLamp(neighbourLamp);
                BuildConnectionTreeAndFillRegion(region, colorLampGroup, map, neighbourLamp);
            }
            neighbourLamp = CreateConnectionToNeighbour(-1,  1, lamp, map);
            if (neighbourLamp != null)
            {
                region.AddLamp(neighbourLamp);
                BuildConnectionTreeAndFillRegion(region, colorLampGroup, map, neighbourLamp);
            }
            neighbourLamp = CreateConnectionToNeighbour( 0,  1, lamp, map);
            if (neighbourLamp != null)
            {
                region.AddLamp(neighbourLamp);
                BuildConnectionTreeAndFillRegion(region, colorLampGroup, map, neighbourLamp);
            }
            neighbourLamp = CreateConnectionToNeighbour( 1,  1, lamp, map);
            if (neighbourLamp != null)
            {
                region.AddLamp(neighbourLamp);
                BuildConnectionTreeAndFillRegion(region, colorLampGroup, map, neighbourLamp);
            }

            colorLampGroup.Remove(lamp);
        }

        private Lamp CreateConnectionToNeighbour(int neighbourX, int neighbourY, Lamp lamp, Map map)
        {
            int x = (int)lamp.X + neighbourX;
            int y = (int)lamp.Y + neighbourY;

            if (x < 0 || y < 0 || x > map.Width || y > map.Height)
                return null;

            var neighbourLamp = map[x, y] as Lamp;
            if (neighbourLamp != null && neighbourLamp.Color == lamp.Color)
            {
                if (neighbourLamp.RedConnections.Any(c => c.Second != lamp) || 
                    lamp.RedConnections.Any(c => c.Second != neighbourLamp))
                {
                    lamp.RedConnections.Add(new WireConnection(lamp, neighbourLamp));
                    neighbourLamp.RedConnections.Add(new WireConnection(neighbourLamp, lamp));
                    return neighbourLamp;
                }
            }
            else
            {
                // this is border lamp
            }

            return null;
        }
    }
}
