using System;
using System.Collections.Generic;

namespace lab9_dictionary
{
    class Program
    {
        private static Random rnd = new Random();
        static void Main()
        {
            var list = new List<Person>();
            for (int i = 1; i <= 10; i++)
            {
                var fName = "Ivan" + i;
                var lName = "Ivanov" + i;
                var tName = "Ivanovich" + i;
                var post = "Santechnik" + i;
                var salary = rnd.Next(2500, 7000);
                var bithday = new DateTime(1995, 1, 1)
                    .AddYears(rnd.Next(-10, 10))
                    .AddMonths(rnd.Next(-10, 10))
                    .AddDays(rnd.Next(-30, 30));
                list.Add(new Person(tName, lName, fName, post, salary, bithday));
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            var dictionaryPerson = new Dictionary<string, Person>();
            foreach (var item in list)
            {
                dictionaryPerson.Add(item.LastName, item);
            }

            OutputCelebrants(dictionaryPerson);
            Console.WriteLine("Введите номер месяца");
            var month = int.Parse(Console.ReadLine());
            DefineCelebrant(month, dictionaryPerson);
        }

        private static void OutputCelebrants(Dictionary<string, Person> dictionary)
        {
            for (int i = 1; i <= 12; i++)
            {
                var count = 0;
                foreach (var item in dictionary)
                {
                    if (item.Value.Birthday.Month == i)
                    {
                        count++;
                    }
                }
                Console.WriteLine($"В {i} месяце - {count} именн.");
            }
        }

        private static void DefineCelebrant(int month, Dictionary<string, Person> dictionary)
        {
            var count = 0;
            foreach (var item in dictionary)
            {
                if (item.Value.Birthday.Month == month)
                {
                    count++;
                }
            }
            if (count > 0)
            {
                Console.WriteLine($"В {month} месяце - {count} именн.");
            }
            else
            {
                Console.WriteLine("В данном месяце именниников нет.");
            }
        }
    }

}


public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ThirdName { get; set; }
    public string Post { get; set; }
    public int Salary { get; set; }
    public DateTime Birthday { get; set; }

    public Person(string firstName, string lastName, string thirdName, string post, int salary, DateTime birthday)
    {
        FirstName = firstName;
        LastName = lastName;
        ThirdName = thirdName;
        Post = post;
        Salary = salary;
        Birthday = birthday;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName} {ThirdName}, {Post}, {Salary}$, {Birthday:d}";
    }
}