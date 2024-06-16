using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les13MultiArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Mang 2 chieu 
            // kieudulieu[,] arr = new kieudulieu[so_hang, so_cot]
            /* int[,] arr = new int[3, 5]; //3 hang, 5 cot*/
            //2. kt va gan
            /*int[,] arr2 = new int[2, 3] { { 1, 2, 3 }, { 2, 3, 4 } };*/
            Random r = new Random();
            int dong = 3;
            int cot = 4;
            int[,] arr3 = new int[dong, cot];
            /*for (int i = 0; i < dong; i++)
            {
                for (int j = 0; j < cot; j++)
                {
                    *//* Console.Write(j+"\t");*//*
                    arr3[i, j] = r.Next(51);
                    Console.Write(arr3[i, j] + "\t");
                }
                Console.WriteLine();
            }*/

            for (int i = 0; i < arr3.GetLength(0); i++)
            {
                for (int j = 0; j < arr3.GetLength(1); j++)
                {
                    arr3[i, j] = r.Next(51);
                    Console.Write(arr3[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.Read();
        }

    }
}
