using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcIceForDon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("kaç satırlık üçgen olsun?");
            int yıldız = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= yıldız; i++)
            {
                for (int j = i; j <= yıldız; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= i; k++)
                {
                    Console.Write("*");
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

    }
}
