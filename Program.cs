using System;
using System.Collections.Generic;

namespace Linq
{
    internal class Program
    {
       static int[] arr = { 1, 2, 3, 4, 5 };
        static int fact = 1;
        private static void Main(string[] args)
        {

           int res= factorial(arr.Length - 1);
            Console.WriteLine(res); 
            Console.ReadLine();
        }
       static int factorial(int n)
        {
            if(n==0)
            {
                return n ; 
            }

            factorial(n - 1);
            fact = fact * arr[n];
            return fact;

        }

    }
}
