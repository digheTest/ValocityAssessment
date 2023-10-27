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
        /// <summary>
        /// MaxItemsToRetrieve
        /// </summary>
        private List<Person> _people;

        public BirthingUnit()
        {
            _people = new List<Person>();
        }

        /// <summary>
        /// GetPeoples
        /// </summary>
        /// <param name="j"></param>
        /// <returns>List<object></returns>
        public List<Person> GetPeople(int i)
        {
            for (int j = 0; j < i; j++)
            {
                try
                {
                    // Creates a dandon Name
                    string name = string.Empty;
                    var random = new Random();
                    if (random.Next(0, 1) == 0) {
                        name = "Bob";
                    }
                    else {
                        name = "Betty";
                    }
                    // Adds new people to the list
                    _people.Add(new Person(name, DateTime.UtcNow.Subtract(new TimeSpan(random.Next(18, 85) * 356, 0, 0, 0))));
                }
                catch (Exception e)
                {
                    // Dont think this should ever happen
                    throw new Exception("Something failed in user creation");
                }
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