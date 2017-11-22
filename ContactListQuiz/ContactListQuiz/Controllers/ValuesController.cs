using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ContactListQuiz.Controllers
{
    [Route("api/contacts")]
    public class ValuesController : Controller
    {

        //IActionResult

        //Declaration
        private List<Person> list = new List<Person>();

        //Konstructor
        public ValuesController()
        {
            this.list.Add(new Person(1, "Matthias", "Schalhas", "schalhas.m@gmail.com"));
            this.list.Add(new Person(2, "Matthias", "Benkner", "benkner@gmail.com"));
            this.list.Add(new Person(3, "Günther", "Öhlinger", "Oehlinger@gmail.com"));
            this.list.Add(new Person(4, "Jan", "Karl", "karl@gmail.com"));
            this.list.Add(new Person(5, "Daniel", "Barth", "barth@gmail.com"));
        }

        public List<Person> List
        {
            get { return this.list; }
        }
        
        [HttpPost]
        public IActionResult addPerson([FromBody] Person p)
        {
            if(p == null)
            {
                return BadRequest("Invalid input (e.g. required field missing or empty)"); //answer 400
            }
            list.Add(p);
            return Created("Created", "Person successfully created"); //answer 201
        }

        [HttpGet]
        public IActionResult getAllPersons()
        {
            return Ok(list);
        }

        [HttpDelete]
        [Route("{index}")]
        public IActionResult deletePerson(int index)
        {
            if (index > 0 && index < list.Count) //No Index out of bounds
            {
                var person = list.Where(p => p.Id == index);
                if(person.Count() == 0)
                {
                    return NotFound("Person not found"); //404
                }
                else
                {
                    list.RemoveAt(index);
                    return StatusCode(204, "Successful operation"); //I do not find the correct name of the method
                }
            }
            return BadRequest("Invalid ID supplied"); //400
        }

        [HttpGet]
        [Route("{nameFilter}",Name = "nameFilter")]
        public IActionResult findPersonByName(String nameFilter)
        {
            var persons = list.Where(p => p.FirstName.Equals(nameFilter) || p.LastName.Equals(nameFilter));
            if(persons.Count() == 0)
            {
                return BadRequest("Invalid or missing name");
            }

            return Ok(persons.ToList());
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetById(int id)
        {
            var person = list.FirstOrDefault(p => p.Id == id);
            if(person == null)
            {
                return NotFound();
            }
            return new ObjectResult(person);
        }
      
    }
}
