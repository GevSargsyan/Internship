using System;
using System.Threading;
using System.Threading.Tasks;

namespace Asymc_Symbols
{
    class Program
    {
        static async void Char1Async()
        {
            Console.WriteLine("Начало метода Char1Async");

            await Task.Run(() =>
            {
                for (int i = 0; i < 40; i++)
                {
                    Console.WriteLine("*");
                    Thread.Sleep(200);
                }

            });

            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine("%");
                Thread.Sleep(300);
            }
        }


        static void Main(string[] args)
        {

            Char1Async();
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("M");
                Thread.Sleep(200);
            }

            Console.Read();

        }
    }
}
