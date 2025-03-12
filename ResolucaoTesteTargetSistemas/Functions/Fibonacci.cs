using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Threading.Tasks;

namespace ResolucaoTesteTargetSistemas.Functions
{
    public class Fibonacci
    {
        public static bool CalcularFibonacci(int numero)
        {
            if (numero == 0 || numero == 1)
                return true;
            
            int a = 0, b = 1, c = 0;

            while (c < numero) {
                c = a + b;
                a = b;
                b = c;
            }

            if (c == numero) return true;
            else return false;
        }
    }
}