﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Tests")]

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

        public BirthingUnit(List<Person> people)
        {
            _people = people;
        }

        /// <summary>
        /// This function receives values in integer and create Person based upon it
        /// </summary>
        /// <param name="count">interger</param>
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
        /// <summary>
        /// This function receives boolean and returns number of Person are above 30 years if boolean is true.
        /// </summary>
        /// <param name="olderThan30">boolean</param>
        /// <returns>IEnumerable<Person></returns>
        internal IEnumerable<Person> GetBobs(bool olderThan30)
        {
            DateTime thirtyYearsAgo = DateTime.Now.AddYears(-30);

            return _people.Where(p => p.Name == "Bob" && (p.DateOfBirth >= thirtyYearsAgo || !olderThan30));
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