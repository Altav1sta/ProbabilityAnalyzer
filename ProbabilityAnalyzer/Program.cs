using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbabilityAnalyzer
{
    class Program
    {
        static int Fact(int x)
        {
            return (x == 0) ? 1 : x * Fact(x - 1);
        }

        static int C(int x, int y) // биномиальный коэффициент
        {
            return Fact(x) / (Fact(y) * Fact(x - y));
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Программа подсчитает вроятность того, что событие А наступит по крайней мере k раз за n итераций.");
            
            Console.Write("Введите вероятность события А (от 0 до 1): ");
            double p;
            if (!Double.TryParse(Console.ReadLine(), out p) || (p < 0) || (p > 1))
            {
                Console.WriteLine("Неверно введены данные!");
                Console.ReadLine();
                return;
            }
            
            Console.Write("k = ");
            int k;
            if (!Int32.TryParse(Console.ReadLine(), out k) || (k < 0))
            {
                Console.WriteLine("Неверно введены данные!");
                Console.ReadLine();
                return;
            }

            Console.Write("n = ");
            int n;
            if (!Int32.TryParse(Console.ReadLine(), out n) || (n < k))
            {
                Console.WriteLine("Неверно введены данные!");
                Console.ReadLine();
                return;
            }

            double ans = 0;
            for (int i = k; i <= n; i++)
            {
                ans += C(n, i) * Math.Pow(p, i) * Math.Pow(1 - p, n - i);
            }

            Console.WriteLine();
            Console.WriteLine("Вероятность составляет " + ans * 100 + "%");
            Console.ReadLine();
        }
    }
}
