using System.IO;
using System.Linq;
using System.Reflection;

namespace Sjerrul.ColorNaming
{
    internal static class HexNamer
    {
        internal static string GetNameForColor(string hex)
        {
            hex = hex.ToLower();
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream("Sjerrul.ColorNaming.data.hex.txt");

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
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
