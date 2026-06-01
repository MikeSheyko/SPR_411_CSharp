using System;
using System.Collections.Generic;
using System.Text;

namespace _12_1_Delegates
{
    public class ArrayOperations
    {
        public List<int> GetEven(int[] array)
        {
            return array.Where(x => x % 2 == 0).ToList();
        }

        public List<int> GetOdd(int[] array)
        {
            return array.Where(x => x % 2 != 0).ToList();
        }

        public List<int> GetPrime(int[] array)
        {
            return array.Where(IsPrime).ToList();
        }

        public List<int> GetFibonacci(int[] array)
        {
            return array.Where(IsFibonacci).ToList();
        }

        private bool IsPrime(int n)
        {
            if (n < 2) return false;

            for (int i = 2; i * i <= n; i++)
                if (n % i == 0)
                    return false;

            return true;
        }

        private bool IsFibonacci(int n)
        {
            bool IsPerfectSquare(int x)
            {
                int s = (int)Math.Sqrt(x);
                return s * s == x;
            }

            return IsPerfectSquare(5 * n * n + 4) || IsPerfectSquare(5 * n * n - 4);
        }
    }
}
