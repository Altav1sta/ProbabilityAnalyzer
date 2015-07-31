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

        static void P1()
        {
            Console.Write("Введите вероятность события А (от 0 до 1): ");
            double p;
            if (!Double.TryParse(Console.ReadLine(), out p) || (p < 0) || (p > 1))
            {
                Console.WriteLine("Неверно введены данные!");
                return;
            }

            Console.Write("k = ");
            int k;
            if (!Int32.TryParse(Console.ReadLine(), out k) || (k < 0))
            {
                Console.WriteLine("Неверно введены данные!");
                return;
            }

            Console.Write("n = ");
            int n;
            if (!Int32.TryParse(Console.ReadLine(), out n) || (n < k))
            {
                Console.WriteLine("Неверно введены данные!");
                return;
            }

            double ans = 0;
            for (int i = k; i <= n; i++)
            {
                ans += C(n, i) * Math.Pow(p, i) * Math.Pow(1 - p, n - i);
            }

            Console.WriteLine();
            Console.WriteLine("Вероятность составляет " + ans * 100 + "%");
        }

        static void P2()
        {
            Console.Write("Введите вероятность события А (от 0 до 1): ");
            double p;
            if (!Double.TryParse(Console.ReadLine(), out p) || (p < 0) || (p > 1))
            {
                Console.WriteLine("Неверно введены данные!");
                return;
            }

            Console.Write("Общая сумма выигрыша S = ");
            int S;
            if (!Int32.TryParse(Console.ReadLine(), out S) || (S < 0))
            {
                Console.WriteLine("Неверно введены данные!");
                return;
            }

            Console.Write("n = ");
            int n;
            if (!Int32.TryParse(Console.ReadLine(), out n) || (n < 0))
            {
                Console.WriteLine("Неверно введены данные!");
                return;
            }

            double ans = 0;
            int singlePrize = S / n;
            for (int i = 1; i <= n; i++)
            {
                ans += singlePrize * i * C(n, i) * Math.Pow(p, i) * Math.Pow(1 - p, n - i); 
            }

            Console.WriteLine();
            Console.WriteLine("Прогнозируемая сумма выигрыша составляет " + ans);
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите номер подходящей вам опции: ");
                Console.WriteLine("1 - Программа подсчитает вроятность того, что событие А наступит по крайней мере k раз за n итераций.");
                Console.WriteLine("2 - Программа подсчитает матожидание выигрыша при условии что суммарный выигрыш равен S, вероятность выиграть в одной из n итераций равна А.");
                int method;
                if (!Int32.TryParse(Console.ReadLine(), out method))
                {
                    Console.WriteLine("Неверно введены данные!");
                    Console.ReadLine();
                    continue;
                }
                switch (method)
                {
                    case 1:
                        P1();
                        break;
                    case 2:
                        P2();
                        break;
                    default:
                        Console.WriteLine("Неверно введены данные!");
                        Console.ReadLine();
                        continue;
                }
                Console.ReadLine();
            }
        }
    }
}
