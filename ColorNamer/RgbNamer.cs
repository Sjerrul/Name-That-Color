using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ColorNamer
{
    class RgbNamer
    {
        internal static string GetNameForColor(int r, int g, int b)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream("ColorNamer.data.rgb.txt");

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
    }
}
