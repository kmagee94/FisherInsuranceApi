using Microsoft.AspNetCore.Mvc;
using FisherInsuranceApi.Data;
using FisherInsuranceApi.Models;
using System.Linq;

namespace FisherInsuranceApi.Controllers
{
    [Route("api/quotes")]
    public class QuotesController : Controller
    {
        public readonly FisherContext db;

        public QuotesController(FisherContext context)
        {
            db=context;

        }        
        [HttpGet]
        public IActionResult GetQuotes()
        {
            return Ok(db.Quotes.Where(q=>q.Price>90));
        }
        // POST api/auto/quotes
        [HttpPost]
        public IActionResult Post([FromBody]Quote quote)
        {
            return Ok(db.Quotes.Add(quote));

        }

        // GET api/auto/quotes/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(db.Quotes.Find(id));
        }

        // PUT api/auto/quotes/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Quote quote)
        {
            return Ok(db.Quotes.Update(quote));

        }
        // DELETE api/auto/quotes/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var quoteToDelete = db.Quotes.Find(id);
             db.Quotes.Remove(quoteToDelete);
            return Ok();
        }
    }

}