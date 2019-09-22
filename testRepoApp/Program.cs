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
            int i = 45;
            while (true)
            {
                Console.WriteLine("totally changed system!");
                Console.WriteLine("0 - trolo");
                
                int input = Convert.ToInt32(Console.ReadLine());
                if (input == 3)
                    continue;
                else if (input > i)
                    break;

            }
        }
    }
}
