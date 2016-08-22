using System;
using SteveHornseyIlly.Repository;
using SteveHornseyIlly.Model;

namespace SteveHornseyIlly
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("If this was a genuine product it should validation and have exceptions safely handled. Also it would not use a cmd input form");
            Console.WriteLine("Enter details for person 1:");

            // to skip form use below and comment out two declareNewPerson method calls.
            //var person1 = new Person
            //{
            //    Name = "Steve",
            //    DateOfBirth = new DateTime(1990, 09, 01),
            //    FavouriteColor = "Blue",
            //    CarOwned = "Jaguar",
            //    NumberOfPets = 5
            //};
            //var person2 = new Person
            //{
            //    Name = "Steve",
            //    DateOfBirth = new DateTime(1990, 09, 01),
            //    FavouriteColor = "Blue",
            //    CarOwned = "Jaguar",
            //    NumberOfPets = 5
            //};  
            var person1 = DeclareNewPerson();
            var person2 = DeclareNewPerson();

            var Compare = new ObjectComparer();
            var differnces = Compare.CompareObject(person1, person2);
            
            if (differnces.Count > 0)
            {
                Console.WriteLine("The following {0} difference(s) were found:", differnces.Count);
                for (int i = 0; i < differnces.Count; i++)
                {
                    Console.WriteLine("Property Name: {0}", differnces[i].PropertyName);
                    Console.WriteLine("Property Value: {0}", differnces[i].Value1);
                    Console.WriteLine("Other Value: {0}", differnces[i].Value2);
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Objects are the same");
            }
        }

        private static Person DeclareNewPerson()
        {
            var person = new Person();
            Console.WriteLine("Enter name:");
            person.Name = Console.ReadLine();
            
            Console.WriteLine("Enter date of birth as dd/mm/yyyy:");
            var dob = Console.ReadLine();

            person.DateOfBirth = new DateTime(int.Parse(dob.Substring(6, 4)), int.Parse(dob.Substring(3, 2)), int.Parse(dob.Substring(0, 2)));
            //No tryParse and new message to retry, but if I was doing a nice form I wouldn't have it a cmd program..

            Console.WriteLine("Enter favourite colour:");
            person.FavouriteColor = Console.ReadLine();

            Console.WriteLine("Enter car owned:");
            person.CarOwned = Console.ReadLine();

            Console.WriteLine("Enter number of pets:");
            person.NumberOfPets = int.Parse(Console.ReadLine());

            return person;
        }
    }
}
