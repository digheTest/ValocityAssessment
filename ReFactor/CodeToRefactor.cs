using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingAssessment.Refactor
{
    public class Person
    {
        private static readonly DateTimeOffset Under16 = DateTimeOffset.UtcNow.AddYears(-15);
        public string Name { get; private set; }
        public DateTimeOffset DateOfBirth { get; private set; }

        public Person(string name) : this(name, Under16.Date)
        {
        }

        public Person(string name, DateTime dob)
        {
            Name = name;
            DateOfBirth = dob;
        }
    }

    public class BirthingUnit
    {

        private List<Person> _people;
        private static readonly List<string> names = new List<string> { "Bob", "Betty" };

        public BirthingUnit()
        {
            _people = new List<Person>();
        }

        /// <summary>
        /// This method receives values in integer and create Person based upon it
        /// </summary>
        /// <param name="count"></param>
        /// <returns>List<Person></returns>
        public List<Person> GetPeople(int count)
        {
            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                string name = names[random.Next(0, 2)];
                DateTime dob = DateTime.Now.AddYears(DateTime.UtcNow.Subtract(new TimeSpan(random.Next(18, 85) * 356, 0, 0, 0)).Year);

                _people.Add(new Person(name, dob));
            }

            return _people;
        }

        private IEnumerable<Person> GetBobs(bool olderThan30)
        {
            return olderThan30 ? _people.Where(x => x.Name == "Bob" && x.DateOfBirth >= DateTime.Now.Subtract(new TimeSpan(30 * 356, 0, 0, 0))) : _people.Where(x => x.Name == "Bob");
        }

        public string GetMarried(Person p, string lastName)
        {
            if (lastName.Contains("test"))
                return p.Name;
            if ((p.Name.Length + lastName).Length > 255)
            {
                (p.Name + " " + lastName).Substring(0, 255);
            }

            return p.Name + " " + lastName;
        }
    }
}