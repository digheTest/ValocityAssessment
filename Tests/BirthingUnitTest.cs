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
    }
}
