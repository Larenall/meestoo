using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using meestoo;

namespace meestoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactsController : ControllerBase
    {
        private readonly postgresContext db;

        public FactsController(postgresContext context)
        {
            db = context;
        }

        // GET: api/Facts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fact>>> GetFact()
        {
            return await db.Fact.ToListAsync();
        }

        // GET: api/Facts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fact>> GetFact(int id)
        {
            var fact = await db.Fact.FindAsync(id);

            if (fact == null)
            {
                return NotFound();
            }

            return fact;
        }

        // PUT: api/Facts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFact(int id, Fact fact)
        {
            if (id != fact.Id)
            {
                return BadRequest();
            }

            db.Entry(fact).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Facts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Fact>> PostFact(Fact fact)
        {
            db.Fact.Add(fact);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FactExists(fact.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFact", new { id = fact.Id }, fact);
        }

        // DELETE: api/Facts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Fact>> DeleteFact(int id)
        {
            var fact = await db.Fact.FindAsync(id);
            if (fact == null)
            {
                return NotFound();
            }

            db.Fact.Remove(fact);
            await db.SaveChangesAsync();

            return fact;
        }

        private bool FactExists(int id)
        {
            return db.Fact.Any(e => e.Id == id);
        }
    }
}
