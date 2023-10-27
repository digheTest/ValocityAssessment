using System;
using System.Collegctions.Generic;// Incorrect Namespace -  It should be "System.Collections.Generic."
using System.Linq;

// Incorrect naming convention - It should follow a more conventional naming pattern,
// such as "Valocity.Utility.ProfileHelper."
namespace Utility.Valocity.ProfileHelper
{
    public class People
    {
        private static readonly DateTimeOffset Under16 = DateTimeOffset.UtcNow.AddYears(-15);
        public string Name { get; private set; }
        public DateTimeOffset DOB { get; private set; }
        public People(string name) : this(name, Under16.Date) { }
        public People(string name, DateTime dob)
        {
            Name = name;
            DOB = dob;
        }
    }

    public class BirthingUnit
    {
        // The comments in the code are quite minimal and don't provide a clear understanding of the code's purpose.
        // Provide more context in your comments.
        // Use more descriptive comments for your methods and variables. The comments should explain what the code is doing,
        // not just what the method or variable is called.
        // Consider using XML comments to provide more structured documentation for classes and methods.
        //
        /// <summary>
        /// MaxItemsToRetrieve
        /// </summary>
        private List<People> _people;

        public BirthingUnit()
        {
            _people = new List<People>();
        }

        /// <summary>
        /// GetPeoples
        /// </summary>
        /// <param name="j"></param>
        /// <returns>List<object></returns>
        public List<People> GetPeople(int i)
        {
            //Add null checks for variables or method returns that can be null, such as the return value

            for (int j = 0; j < i; j++)
            {
                try
                {
                    // Creates a dandon Name
                    string name = string.Empty;

                    //Using random.Next(0, 1) will always return 0.
                    //If you want a random choice between two options, use random.Next(0, 2).
                    var random = new Random();
                    if (random.Next(0, 1) == 0)
                    //The hardcoded values for names("Bob" and "Betty") and the name length limit(255) should be defined
                    //as constants or variables to make the code more maintainable.
                    {
                        name = "Bob";
                    }
                    else
                    {
                        name = "Betty";
                    }
                    // Adds new people to the list
                    _people.Add(new People(name, DateTime.UtcNow.Subtract(new TimeSpan(random.Next(18, 85) * 356, 0, 0, 0))));
                }
                catch (Exception e)
                {
                    //Be more specific in exception handling.
                    //Instead of throwing a generic Exception, consider creating custom exceptions or
                    //handling specific exceptions that might occur.

                    // Dont think this should ever happen
                    throw new Exception("Something failed in user creation");
                }
            }
            return _people;
        }

        private IEnumerable<People> GetBobs(bool olderThan30)
        {
            //In the this method, you can simplify the conditional expression by eliminating the ternary operator.

            return olderThan30 ? _people.Where(x => x.Name == "Bob" && x.DOB >= DateTime.Now.Subtract(new TimeSpan(30 * 356, 0, 0, 0))) : _people.Where(x => x.Name == "Bob");
        }

        public string GetMarried(People p, string lastName)
        {
            if (lastName.Contains("test"))
                return p.Name;

            //In the this method, the line(p.Name + " " + lastName).Substring(0, 255);
            //doesn't assign the result back to any variable. Make sure you assign it to a variable or return it.

            if ((p.Name.Length + lastName).Length > 255)
            {
                (p.Name + " " + lastName).Substring(0, 255);
            }

            return p.Name + " " + lastName;
        }
    }
}