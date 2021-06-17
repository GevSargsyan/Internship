using System;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel_Invoke
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.Invoke(Display,
                () => {
                    Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                    Thread.Sleep(3000);
                },
                () => Factorial(5));

            Console.ReadLine();
        }

        static void Display()
        {
            Thread.Sleep(4000);
            Console.WriteLine($"Выполняется задача {Task.CurrentId}");
        }

        static void Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Выполняется задача {Task.CurrentId}");
            Thread.Sleep(3000);
            Console.WriteLine($"Результат {result}");
        }
    }
}
