using TP3_aspnet2.Models;

namespace TP3_aspnet2.DataSource
{
    public class DAPerson
    {
        public static List<Person> Persons()
        {
            var persons = new List<Person>();
            var person = new Person()
            {
                FirstName = "Alceu",
                LastName = "Lima",
                Birthday = new DateOnly(1990, 7, 12)
            };
            persons.Add(person);
            person = new Person()
            {
                FirstName = "Professor",
                LastName = "Girafales",
                Birthday = new DateOnly(1988, 10, 23)
            };
            persons.Add(person);
            person = new Person()
            {
                FirstName = "Chavez",
                LastName = "Bonilha",
                Birthday = new DateOnly(1987, 7, 2)
            };
            persons.Add(person);
            return persons;
        }
    }
}
