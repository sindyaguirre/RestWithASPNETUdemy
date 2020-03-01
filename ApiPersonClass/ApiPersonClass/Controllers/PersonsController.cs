using ApiPersonClass.Model;
using ApiPersonClass.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonClass.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : ControllerBase
    {

        private IPersonService _personService;
        public PersonsController(IPersonService personService) 
        {
            _personService = personService;
        }

        //GET api/vaues
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        //GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.findById(id);
            
            if (person == null) return NotFound();

            return Ok(person);
        }

        //POST api/values/5
        [HttpPost("{id}")]
        public IActionResult Post([FromBody]Person person)
        {
            
            if (person == null) return BadRequest();

            return new ObjectResult(_personService.Create(person));
        }

        //PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personService.Update(person));
        }
        //DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
