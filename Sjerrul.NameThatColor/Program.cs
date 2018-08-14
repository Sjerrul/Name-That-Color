using Sjerrul.ColorNaming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sjerrul.NameThatColor
{
    static class Program
    {
        static void Main(string[] args)
        {
            IColorNamer colorNamer = new ColorNamer();

            Console.WriteLine(colorNamer.GetColorName("#CEB301"));
            Console.WriteLine(colorNamer.GetColorName("#ad900d"));
            Console.WriteLine(colorNamer.GetColorName("#CC9900"));
            Console.WriteLine(colorNamer.GetColorName("#CC0000"));
            Console.WriteLine(colorNamer.GetColorName("#0077FF"));
            Console.WriteLine(colorNamer.GetColorName("#33ccff"));

            Console.WriteLine(colorNamer.GetColorName(0, 155, 255));

            Console.ReadKey();
        }
    }
}
