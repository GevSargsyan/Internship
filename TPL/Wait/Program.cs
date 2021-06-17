using System;
using System.Threading.Tasks;

namespace Wait
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(Display);
            task.Start();
            task.Wait();
            Console.WriteLine("Завершение метода Main");
            Console.ReadLine();
        }

        static void Display()
        {
            Console.WriteLine("Начало работы метода Display");

            Console.WriteLine("Завершение работы метода Display");
        }
    }
}
