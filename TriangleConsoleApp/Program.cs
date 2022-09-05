using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TriangleConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            string triangleFile = @"C:\Dosya\orthogonalTriangle.txt";
            if (File.Exists(triangleFile))
            {
                Console.WriteLine("file is found.");
            }
            else
            {
                Console.WriteLine("file is not found!");
                return;
            }


            int numOfLines = FindNumOfLines(triangleFile);

            int max = FindMaxSumOfOrthogonalTriangle(triangleFile, numOfLines);
            Console.WriteLine($"Max = {max}");

            Console.ReadLine();
        }


        static int FindNumOfLines(string path)
        {
            string[] lines = File.ReadAllLines(path);
            return lines.Length;
        }

        static bool IsPrime(int number)
        {
            int i;
            int flag = 0;
            if (number > 2)
            {
                for (i = 2; i < number; i++)
                {
                    if (number % i == 0)
                        flag = 1;
                }
                if (flag == 0)
                    return true;
                else
                    return false;
            }
            else if (number == 2)
                return true;
            else
                return false;
        }

        static int FindMaxSumOfOrthogonalTriangle(string path, int numOfLines)
        {
            int[,] triangleArr = new int[numOfLines, numOfLines];
            string[] lines = File.ReadAllLines(path);


            for (int i = 0; i < numOfLines; i++)
            {

                string[] line = lines[i].Split(' ');

                for (int j = 0; j <= i; j++)
                {
                    int number = Convert.ToInt32(line[j]);
                    if (!IsPrime(number))
                        triangleArr[i, j] = number;
                    else
                        triangleArr[i, j] = 0;
                }
            }

            if (numOfLines > 1)

                triangleArr[1, 1] = triangleArr[1, 1] + triangleArr[0, 0];
            triangleArr[1, 0] = triangleArr[1, 0] + triangleArr[0, 0];



            for (int i = 2; i < numOfLines; i++)
            {
                triangleArr[i, 0] = triangleArr[i, 0] + triangleArr[i - 1, 0];
                triangleArr[i, i] = triangleArr[i, i] + triangleArr[i - 1, i - 1];
                for (int j = 1; j < i; j++)
                {
                    if (triangleArr[i, j] + triangleArr[i - 1, j - 1] >=
                       triangleArr[i, j] + triangleArr[i - 1, j])
                        triangleArr[i, j] = triangleArr[i, j] + triangleArr[i - 1, j - 1];

                    else
                        triangleArr[i, j] = triangleArr[i, j] + triangleArr[i - 1, j];
                }
            }

            int max = triangleArr[numOfLines - 1, 0];

            int x = 1;
            while (x < numOfLines)
            {
                if (max < triangleArr[numOfLines - 1, x])
                    max = triangleArr[numOfLines - 1, x];
                x++;
            }


            return max;




        }
    }
}
