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
        [Fact]
        public void GetBobs_HasNotBobAgeUnder30_PassingTest()
        {
            List<Person> people = new List<Person>
            {
                new Person("Bob"),
                new Person("Bob")
            };
            BirthingUnit birthUnitWitoutOlderPerson = new BirthingUnit(people);

            Assert.Equal(2, birthUnitWitoutOlderPerson.GetBobs(false).ToList().Count);
        }
        [Fact]
        public void GetMarried_IfConditionCheck_PassingTest()
        {
            Person person = new Person("Valocity");

            Assert.Equal("Valocity", birthingUnit.GetMarried(person, "test"));
        }
        [Fact]
        public void GetMarried_FullNameLength_PassingTest()
        {
            Person person = new Person("Valocity");

            Assert.Equal("Valocity Assessment", birthingUnit.GetMarried(person, "Assessment"));
        }
        [Fact]
        public void GetMarried_FullNameMoreThan255_PassingTest()
        {
            string stringWithMoreThan255Char = "worirbpwoirfoivdjafoajdfoqu2-3i\t" +
                "[kd;ek;alskdp[isdkf;aeoiqoihioojqosjdfoshfkahsdlkfalkndslknxcoajsvwaevakwel;wajvpdojlcmz;" +
                "xlcmasdmoam;lefpoefpaeiohguohjavbvknaweoihaivoasdvlkajdlkvaoiefhphlkndslknvfaoirfawieajlkasdnv" +
                "laksjpoewajpoajepalsdmaooesjfpoaewjewofja;";

            string comparingString = "Valocity worirbpwoirfoivdjafoajdfoqu2-3i	[kd;ek;alskdp[isdkf;aeoiqoihioojqos" +
                "jdfoshfkahsdlkfalkndslknxcoajsvwaevakwel;wajvpdojlcmz;xlcmasdmoam;lefpoefpaeiohguohjavbvknaweoihai" +
                "voasdvlkajdlkvaoiefhphlkndslknvfaoirfawieajlkasdnvlaksjpoewajpoajepalsdmaooesjfpo";

            Person person = new Person("Valocity");

            string test = birthingUnit.GetMarried(person, stringWithMoreThan255Char);

            Assert.Equal(comparingString, birthingUnit.GetMarried(person, stringWithMoreThan255Char));
        }
    }
}
