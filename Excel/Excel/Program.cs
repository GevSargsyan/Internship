using Ganss.Excel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Excel
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            List<Person> PersonsList = new List<Person>();
            var path = @"C:\Users\Gev\Desktop\Anunner.xlsx";
            var people = new ExcelMapper(path).Fetch<Person>().ToList();
            Console.WriteLine($"{new string('-', 20)}List of Persons{new string('-', 20)}");
            foreach (var item in people)
            {
                PersonsList.Add(
                    new Person
                    {
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        MiddleName=item.MiddleName,
                        Age = item.Age,
                        Gender = item.Gender

                    }
                    ) ;
                Console.WriteLine($"{++count}-{item.FirstName}\t{item.LastName}\t{item.MiddleName}\t{item.Age}\t{item.Gender}");
            }
            Console.WriteLine(new string('-',55));

            Console.WriteLine($"{new string('-', 20)}List of Adults{new string('-', 20)}");

            var adults = PersonsList.Where(x => x.Age > 18).ToList();
            count = 0;
            foreach (var item in adults)
            {
                Console.WriteLine($"{++count}-{item.FirstName}\t{item.LastName}\t{item.MiddleName}\t{item.Age}\t{item.Gender}");

            }
            Console.WriteLine(new string('-', 55));

            Console.WriteLine($"{new string('-', 20)}List of Minors{new string('-', 20)}");

            var minors = PersonsList.Where(x => x.Age<18).ToList();
            count = 0;
            foreach (var item in minors)
            {
                Console.WriteLine($"{++count}-{item.FirstName}\t{item.LastName}\t{item.MiddleName}\t{item.Age}\t{item.Gender}");

            }
            Console.WriteLine(new string('-', 55));


            Console.WriteLine($"{new string('-', 20)}List of Males{new string('-', 20)}");

            var males = PersonsList.Where(x => x.Gender=="Male").ToList();
            count = 0;
            foreach (var item in males)
            {
                Console.WriteLine($"{++count}-{item.FirstName}\t{item.LastName}\t{item.MiddleName}\t{item.Age}\t{item.Gender}");

            }
            Console.WriteLine(new string('-', 55));


            Console.WriteLine($"{new string('-', 20)}List of Females{new string('-', 20)}");

            var females = PersonsList.Where(x => x.Gender=="Female").ToList();
            count = 0;
            foreach (var item in females)
            {
                Console.WriteLine($"{++count}-{item.FirstName}\t{item.LastName}\t{item.MiddleName}\t{item.Age}\t{item.Gender}");

            }
            Console.WriteLine(new string('-', 55));

            Console.WriteLine($"{new string('-', 20)}List of Armen{new string('-', 20)}");

            var arm = PersonsList.Where(x=>x.FirstName=="Armen").ToList();
            count = 0;
            foreach (var item in arm)
            {
                Console.WriteLine($"{++count}-{item.FirstName}\t{item.LastName}\t{item.MiddleName}\t{item.Age}\t{item.Gender}");
            }

            Console.WriteLine(new string('-', 55));

            Console.WriteLine($"{new string('-', 20)}List of Hrant MiddleName{new string('-', 20)}");

            var mid = PersonsList.Where(x=>x.MiddleName=="Hranti").ToList();
            count = 0;
            foreach (var item in mid)
            {
                Console.WriteLine($"{++count}-{item.FirstName}\t{item.LastName}\t{item.MiddleName}\t{item.Age}\t{item.Gender}");
            }

            Console.WriteLine(new string('-', 55));

            Console.ReadKey();

        }
    }
}
