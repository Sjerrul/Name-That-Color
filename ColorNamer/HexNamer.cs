using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ColorNamer
{
    class HexNamer
    {
        internal static string GetNameForColor(string hex)
        {
            hex = hex.ToLower();
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream("ColorNamer.data.hex.txt");

            string line;

            using (StreamReader file = new StreamReader(stream))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains(hex))
                    {
                        string name = line.Split('\t').First();
                        name = Capitalize(name);

                        return name;
                    }
                }
            }

            return null;
        }

        private static string Capitalize(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
