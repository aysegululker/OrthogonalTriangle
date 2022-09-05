using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrthogonalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input number of rows");
            int rows = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            int sayi;
            int sayac = 0;
            Random random = new Random();

            for (int i = 1; i <= rows; i++)
            {
                for (int j = rows; j > i; j--)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= i; k++)
                {
                    sayi = random.Next(10, 100);
                    for (int n = 2; n <= sayi/2; n++)
                    {
                        if (sayi%n == 0)
                        {
                            sayac++;
                            break;
                        }
                    }
                    if (sayac != 0)
                    {
                        Console.Write(" " + sayi.ToString());
                         
                    }
                    else
                    {
                        Console.Write(" " + (sayi + 1).ToString());
                    }
                    //Console.Write(" *");
                }
                
                
                Console.WriteLine();
            }

            Console.Read();

        }
    }
}
