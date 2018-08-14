using Christo.GFX.Conversion;
using Sjerrul.ColorNaming;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sjerrul.ColorNaming
{
    public class ColorNamer : IColorNamer
    {
        public string GetColorName(string hexValue)
        {
            string name = HexNamer.GetNameForColor(hexValue);

            if (String.IsNullOrWhiteSpace(name))
            {
                Color color = ColorTranslator.FromHtml(hexValue);
                color = BoostSaturation(color);

                name = this.GetColorName(color.R, color.G, color.B);
            }

            return name;
        }

        public string GetColorName(int r, int g, int b)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream("Sjerrul.ColorNaming.data.rgb.txt");

            string line;

            using (StreamReader file = new StreamReader(stream))
            {
                string RgbToMatch = String.Format("{0}, {1}, {2}", r, g, b);
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains(RgbToMatch))
                    {
                        return line.Split(' ').Last();
                    }
                }
            }

            return null;
        }

        private static Color BoostSaturation(Color color)
        {
            HSL hsl = new HSL(color);
            hsl.S = 1;

            return hsl.Color;
        }
    }
}
