using Microsoft.AspNetCore.Mvc;

namespace FisherInsuranceApi.Controllers
{
    [Route("api/life/quotes")]
    public class LifeController : Controller
    {
        // POST api/life/quotes
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            return Created("", value);
        }

        // GET api/life/quotes/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok("The id is: " + id);
        }

        // PUT api/life/quotes/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return NoContent();
        }
        // DELETE api/life/quotes/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }

}