using FactorioBlueprintHelper.Model.BlueprintConstatns;
using FactorioBlueprintHelper.Model.BlueprintObjects;
using FactorioBlueprintHelper.Model.MapEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioBlueprintHelper.Model
{
    public class Map
    {
        private MapEntity[,] _map;

        public int Width { get; private set; }
        public int Height { get; private set; }

        public MapEntity this[int x, int y]
        {
            get { return _map[x, y]; }
            set { _map[x, y] = value; }
        }

        public Map(int width, int height)
        {
            Width = width;
            Height = height;
            _map = new MapEntity[width, height];
        }

        public void FillWithSubstations()
        {
            int wModulo = Width % 18;
            int hModulo = Height % 18;
            int newWidth = Width;
            int newHeight = Height;

            bool isSizeChanged = false;
            if (wModulo != 0)
            {
                newWidth += 18 - wModulo;
                wModulo++;
                isSizeChanged = true;
            }
            if (hModulo != 0)
            {
                newHeight += 18 - hModulo;
                hModulo++;
                isSizeChanged = true;
            }
            if (isSizeChanged)
            {
                var newMap = new MapEntity[newWidth, newHeight];
                for (int x = 0; x < Width; x++)
                    for (int y = 0; y < Height; y++)
                    {
                        if (_map[x, y] != null)
                            newMap[x, y] = _map[x, y];
                    }
                _map = newMap;
                Width = newWidth;
                Height = newHeight;
            }

            int wSubsCount = Width / 18;
            int hSubsCount = Height / 18;

            for (int x = 0; x < wSubsCount; x++)
                for (int y = 0; y < hSubsCount; y++)
                {
                    var substation = new Substation(x * 18 + 8.5f, y * 18 + 8.5f);
                    _map[(int)(substation.X - 0.5f), (int)(substation.Y - 0.5f)] = substation;
                    _map[(int)(substation.X - 0.5f), (int)(substation.Y + 0.5f)] = substation;
                    _map[(int)(substation.X + 0.5f), (int)(substation.Y - 0.5f)] = substation;
                    _map[(int)(substation.X + 0.5f), (int)(substation.Y + 0.5f)] = substation;
                }
        }

        public string ToEncodedString()
        {
            var root = BlueprintFactory.GetBlueprintWithIcon();

            var entities = new List<EntityBO>();

            int centerX = Width / 2;
            int centerY = Height / 2;

            int entityNumber = 1;
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    if (_map[x, y] != null)
                    {
                        _map[x, y].Number = entityNumber++;
                    }

            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                {
                    var mapEntity = _map[x, y];
                    if (mapEntity != null)
                    {
                        entities.Add(mapEntity.ToBlueprintObject());
                    }
                }

            root.Blueprint.Entities = entities.ToArray();

            return Serializer.Encode(root);
        }
    }
}
