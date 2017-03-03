using Microsoft.AspNetCore.Mvc;

namespace FisherInsuranceApi.Controllers
{
    [Route("api/claims")]
    public class ClaimsController : Controller
    {
        // POST api/claims
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            return Created("", value);
        }

        // GET api/claims/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok("The id is: " + id);
        }

        // PUT api/claims/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return NoContent();
        }
        // DELETE api/claims/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }

}