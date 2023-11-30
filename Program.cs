using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

class Program
{
    class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    class CRUDOperationWithPerson
    {
        private List<Person> arrPerson = new List<Person>();
        private int newID = 0;
        public void CreatePerson(string name, string surname)
        {
            var person = new Person()
            {
                ID = newID++,
                Name = name,
                Surname = surname
            };
            arrPerson.Add(person);
            Console.WriteLine($"Person {person.Name}, {person.Surname} with: {person.ID}");
        }

        public void WriteAllPerson()
        {
            foreach (var person in arrPerson)
            {
                Console.WriteLine($"{person.Name} {person.Surname} -> {person.ID}");
            }
        }

        public void UpdatePerson(int id, string NewName, string NewSurname)
        {
            var person = arrPerson.Find(person => person.ID == id);
            if (person != null)
            {
                person.Name = NewName;
                person.Surname = NewSurname;
                Console.WriteLine($"Updated: id -> {person.ID}, NewName: {person.Name}, NewSurName: {person.Surname}");
            }
            else
            {
                Console.WriteLine("Not person find");
            }
        }

        public void DeletePerson(int id)
        {
            var detePerson = arrPerson.Find(person => person.ID == id);
            if (detePerson != null)
            {
                arrPerson.Remove(detePerson);
                Console.WriteLine($"Deleted person with {detePerson.ID}");
            }
            else
            {
                Console.WriteLine("Person not found");
            }
        }
    }
    
    static void Main()
    {
        CRUDOperationWithPerson person = new CRUDOperationWithPerson();

        while (true)
        {
            Console.WriteLine("1. Add new Person");
            Console.WriteLine("2. Delete Person");
            Console.WriteLine("3. Update Person");
            Console.WriteLine("4. Write all Person");
            Console.WriteLine("Input number:");

            Console.WriteLine("Write number at 1 to 4:");

            int number;
            while (!int.TryParse(Console.ReadLine(), out number) || number < 1 || number > 4)
            {
                Console.WriteLine("Write correct number at 1 to 4:");
            }

            switch (number)
            {
                case 1:
                    Console.WriteLine("Ok. Ready to create new Person");
                    Console.WriteLine("Enter your name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter your surname:");
                    string surname = Console.ReadLine();
                    person.CreatePerson(name, surname);
                    break;
                case 2:
                    Console.WriteLine("Ok. Ready to delete  Person");
                    Console.WriteLine("Enter your Id:");
                    int deletID;
                    while (!int.TryParse(Console.ReadLine(), out deletID))
                    {
                        Console.WriteLine("Enter correct ID:");
                    }
                    person.DeletePerson(deletID);
                    Console.WriteLine($"Deleted Peson with ID: {deletID}");
                    break;
                case 3:
                    Console.WriteLine("Ok. Ready to update  Person");
                    Console.WriteLine("Enter your Id:");
                    int updateID;
                    while (!int.TryParse(Console.ReadLine(), out updateID))
                    {
                        Console.WriteLine("Enter correct ID:");
                    }
                    Console.WriteLine("Enter your new name:");
                    string newName = Console.ReadLine();
                    Console.WriteLine("Enter your new surname:");
                    string newSurname = Console.ReadLine();
                    person.UpdatePerson(updateID, newName, newSurname);
                    break;
                case 4:
                    person.WriteAllPerson();
                    break;
                default:
                    Console.WriteLine("Что-то пошло не так.");
                    break;
            }
        }
    }
}


