using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTerminal
{
    public class Utility
    {
       public static string GetString(string message)
        {
            Console.WriteLine(message);
            string value = Console.ReadLine()!;
            return value;
        }

        public static int GetInt(string message)
        
        {
            Console.WriteLine(message);
            int value = int.Parse(Console.ReadLine()!);
            return value;
        }

        public void ShowStar()
        {
            Console.WriteLine("**************************************");
        }

        public static void ShowError(string error)
        {
            Console.WriteLine("-------------------");
            Console.WriteLine(error);
            Console.WriteLine("-------------------");
        }
        public static double GetDouble(string message)
        {
            Console.WriteLine(message);
            double value = double.Parse(Console.ReadLine()!);
            return value;
        }
       
    }
}
