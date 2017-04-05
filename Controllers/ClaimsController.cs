using FisherInsuranceApi.Models;
using FisherInsuranceApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace FisherInsuranceApi.Controllers
{
    [Route("api/claims")]
    public class ClaimsController : Controller
    {

        private readonly FisherContext db;
        public ClaimsController(FisherContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult GetClaims()
        {
            return Ok(db.Claims);
        }
        // POST api/claims


        [HttpPost]
        public IActionResult Post([FromBody] Claim claim)
        {
            var newClaim = db.Claims.Add(claim);
            db.SaveChanges();

            return CreatedAtRoute("GetClaim", new { id = claim.Id }, claim);
        }


        // GET api/claims/5
        [HttpGet("{id}", Name = "GetClaim")]
        public IActionResult Get(int id)
        {
            return Ok(db.Claims.Find(id));
        }

        // PUT api/claims/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Claim claim)
        {
            var newClaim = db.Claims.Find(id);
            if (newClaim == null)
            {
                return NotFound();
            }
            newClaim = claim;
            newClaim.Id = id;
            db.SaveChanges();
            return Ok(newClaim);
        }
        // DELETE api/claims/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var claimToDelete = db.Claims.Find(id);
            if (claimToDelete == null)
            {
                return NotFound();
            }

            try
            {
                db.Claims.Remove(claimToDelete);
                db.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                //log
                return BadRequest();
            }

            return NoContent();
        }
    }
}
