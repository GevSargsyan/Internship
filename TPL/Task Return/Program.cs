using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Return
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> task1 = new Task<int>(() => Factorial(5));
            task1.Start();

            Console.WriteLine($"Факториал числа 5 равен {task1.Result}");

            Task<Book> task2 = new Task<Book>(() =>
            {
                return new Book { Title = "Война и мир", Author = "Л. Толстой" };
            });
            task2.Start();

            Book b = task2.Result; 
            Console.WriteLine($"Название книги: {b.Title}, автор: {b.Author}");

            Console.ReadLine();
        }


        static int Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
    
            return result;
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
