using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP3_aspnet2.DataSource;
using TP3_aspnet2.Models;
using PersonModel = TP3_aspnet2.Models.Person;

namespace TP3_aspnet2.Controllers
{
    public class Person : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            var lstPersons = DAPerson.Persons();
            return View(lstPersons);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection person_data)
        {
            try
            {
                PersonModel person = new();
                var birthday = Convert.ToDateTime(person_data["Birthday"]);

                person.FirstName = person_data["FirstName"];
                person.LastName = person_data["LastName"];
                person.Birthday = new DateOnly(birthday.Year, birthday.Month, birthday.Day);

                var persons = DAPerson.Persons();
                persons.Add(person);

                return View("Index", persons);
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(string LastName)
        {
            var persons = DAPerson.Persons();
            var person = persons.First(p => p.LastName == LastName);
            return View(person);
        }

        // POST: Person/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IFormCollection LastName)
        {
            try
            {
                 return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(string LastName)
        {
            var persons = DAPerson.Persons();
            persons.Remove(persons.First(p => p.LastName == LastName));

            return View("Index", persons);
        }

        // POST: Person/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(IFormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
