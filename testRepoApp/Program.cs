using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testRepoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("0 - Exit");
                Console.WriteLine("1 - Addition");
                Console.WriteLine("2 - Substraction");
                Console.WriteLine("3 - Multiplication");
                Console.WriteLine("4 - Power");
                int input = int.Parse(Console.ReadLine());
                if (input == 0)
                    break;

            }
        }
    }
}
