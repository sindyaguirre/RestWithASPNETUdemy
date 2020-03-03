using ApiPersonClass.Model;
using ApiPersonClass.Business;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonClass.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonsController : ControllerBase
    {

        private IPersonBusiness _personBusiness;
        public PersonsController(IPersonBusiness personBusiness) 
        {
            _personBusiness = personBusiness;
        }

        //GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        //GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personBusiness.findById(id);
            
            if (person == null) return NotFound();

            return Ok(person);
        }

        //POST api/values/5
        [HttpPost("{id}")]
        public IActionResult Post([FromBody]Person person)
        {
            
            if (person == null) return BadRequest();

            return new ObjectResult(_personBusiness.Create(person));
        }

        //PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]Person person)
        {
            if (person == null) return BadRequest();
            var updatePerson = _personBusiness.Update(person);
            if (updatePerson == null) return BadRequest();
            return new ObjectResult(_personBusiness.Update(person));
        }
        //DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
