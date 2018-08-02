using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioBlueprintHelper.Model
{
    public static class LampColors
    {
        public static Color Black = Color.FromArgb(255, 0, 0, 0);
        public static Color White = Color.FromArgb(255, 255, 255, 255);
        public static Color Red = Color.FromArgb(255, 255, 35, 8);
        public static Color Green = Color.FromArgb(255, 15, 255, 30);
        public static Color Blue = Color.FromArgb(255, 40, 35, 255);
        public static Color Yellow = Color.FromArgb(255, 255, 255, 40);
        public static Color Magenta = Color.FromArgb(255, 255, 30, 255);
        public static Color Cyan = Color.FromArgb(255, 0, 255, 255);

        public static Color[] AllColors = new[] { Black, White, Red, Green, Blue, Yellow, Magenta, Cyan };
    }
}
