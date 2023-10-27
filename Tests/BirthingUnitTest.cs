using System;
using FluentAssertions;
using Xunit;
using CodingAssessment;
using CodingAssessment.Refactor;
using System.Collections.Generic;

namespace Tests
{
    public class BirthingUnitTest
    {
        BirthingUnit birthingUnit = new BirthingUnit();
        [Fact]
        public void GetPeople_SameInputOutput_PassingTest()
        {
            Assert.Equal(5, birthingUnit.GetPeople(5).Count());
        }
        [Fact]
        public void GetPeople_NotSameInputOutput_FaillingTest()
        {
            Assert.NotEqual(4, birthingUnit.GetPeople(5).Count());
        }
        [Fact]
        public void GetBobs_HasOneBobAgeUnder30_PassingTest()
        {
            List<Person> people = new List<Person>
            {
                new Person("Bob", DateTimeOffset.UtcNow.AddYears(-35).Date),
                new Person("Bob")
            };
            BirthingUnit birthUnitOneOlderPerson = new BirthingUnit(people);

            Assert.Single(birthUnitOneOlderPerson.GetBobs(true).ToList());
        }
    }
}
