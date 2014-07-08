using Christo.GFX.Conversion;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorNamer
{
    public static class Translator
    {
        public static string NameThatColor(string hexValue)
        {
            string name = HexNamer.GetNameForColor(hexValue);

            if (String.IsNullOrWhiteSpace(name))
            {
                Color color = ColorTranslator.FromHtml(hexValue);
                color = BoostSaturation(color, 1);

                name = RgbNamer.GetNameForColor(color.R, color.G, color.B);
            }

            return name;
        }

        private static Color BoostSaturation(Color color, int saturationLevel = 1)
        {
            HSL hsl = new HSL(color);
            hsl.S = 1;

            return hsl.Color;
        }
    }
}
