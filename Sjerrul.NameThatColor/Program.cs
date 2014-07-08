using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorNamer;

namespace Sjerrul.NameThatColor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Translator.NameThatColor("#CEB301"));
            Console.WriteLine(Translator.NameThatColor("#ad900d"));
            Console.WriteLine(Translator.NameThatColor("#CC9900"));
            Console.WriteLine(Translator.NameThatColor("#CC0000"));
            Console.WriteLine(Translator.NameThatColor("#0077FF"));
            Console.WriteLine(Translator.NameThatColor("#33ccff"));

            Console.ReadKey();
        }
    }
}
