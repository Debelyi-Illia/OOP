using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab4
{
    class Program
    {
        static LinkedList<LinkedList<int>> Calculate(int[] v1, int[] v2) 
        {
            LinkedList<LinkedList<int>> matrix = new LinkedList<LinkedList<int>>();

            foreach (int x in v1) 
            {
                LinkedList<int> row = new LinkedList<int>();
                foreach (int y in v2) 
                {
                    row.AddLast(x*y);
                }
                matrix.AddLast(row);
            }
            return matrix; 
        }
        static string ShowResult(LinkedList<LinkedList<int>> matrix)
        {
            return string.Join("\n", matrix.Select(row => string.Join(" ", row)));
        }
        static void StartVector (out int[] result)
        {
            result = new int[0];
            Console.WriteLine("Введіть розмір вектора: ");
            int.TryParse(Console.ReadLine(), out int size);
            if (size <= 0) size = 2;
            result = new int[size];
            Random random = new Random();
            for( int i=0; i<size; i++) 
            {
                result[i] = random.Next(-9, 9);
            }
         }
        static void Main(string[] args)
        {
            StartVector(out int[] v1);
            StartVector(out int[] v2);
            Console.WriteLine("Вектор 1:\n" + string.Join(" ", v1));
            Console.WriteLine("Вектор 2:\n" + string.Join("\n", v2));
            Console.WriteLine("Результат:\n" + ShowResult(Calculate(v1, v2)));
        }
    }
}
