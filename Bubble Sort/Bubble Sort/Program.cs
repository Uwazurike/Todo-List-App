using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bubble_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = { 400, 200, 500, 300, 100 };
            int newNum;
            Console.Title = ("Bubble Sort Algorithm V1");
            Console.WriteLine("\n ");
            Console.WriteLine("Here is An Array :\n ");
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.WriteLine(myArray[i]);
            }
            for (int j = 0; j <= myArray.Length - 2; j++)
            {
                for (int i = 0; i <= myArray.Length - 2; i++)
                {
                    if (myArray[i] > myArray[i + 1])
                    {
                        newNum = myArray[i + 1];
                        myArray[i + 1] = myArray[i];
                        myArray[i] = newNum;
                    }
                }
            }
            Console.WriteLine("\n ");
            Console.WriteLine("Now Its Sorted :) :");
            Console.WriteLine("\n ");
            foreach (int aray in myArray)
                Console.Write(aray + " ");
            Console.ReadLine();
        }
    }
}