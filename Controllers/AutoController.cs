using Microsoft.AspNetCore.Mvc;
using FisherInsuranceApi.Data;
using FisherInsuranceApi.Models;

namespace FisherInsuranceApi.Controllers
{
    [Route("api/auto/quotes")]
    public class AutoController : Controller
    {
        private IMemoryStore db;
        public AutoController(IMemoryStore repo)
        {
            db = repo;
        }
        [HttpGet]
        public IActionResult GetQuotes()
        {
            return Ok(db.RetrieveAllQuotes);
        }
        // POST api/auto/quotes
        [HttpPost]
        public IActionResult Post([FromBody]Quote quote)
        {
            return Ok(db.CreateQuote(quote));

        }

        // GET api/auto/quotes/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(db.RetrieveQuote(id));
        }

        // PUT api/auto/quotes/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Quote quote)
        {
            return Ok(db.UpdateQuote(quote));

        }
        // DELETE api/auto/quotes/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            db.DeleteQuote(id);
            return Ok();
        }
    }

}