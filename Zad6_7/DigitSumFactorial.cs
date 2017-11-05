using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad6_7
{
    public class DigitSumFactorial
    {
        public static int Factorial(int n)
        {
            if (n >= 2) return n * Factorial(n - 1);
            return 1;
        }

        public static int DigitSum(int n)
        {
            if (n > 0) return ((n % 10) + DigitSum(n / 10));
            return 0;
        }
        public static Task<int> FactorialDigitSum(int n)
        {
            return Task.Run(() => DigitSum(Factorial(n)));
        }
    }
}
