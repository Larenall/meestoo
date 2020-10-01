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
    public class InfoesController : ControllerBase
    {
        private readonly postgresContext db;

        public InfoesController(postgresContext context)
        {
            db = context;
        }

        // GET: api/Infoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Info>>> GetInfo()
        {
            return await db.Info.ToListAsync();
        }

        // GET: api/Infoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Info>> GetInfo(int id)
        {
            var info = await db.Info.FindAsync(id);

            if (info == null)
            {
                return NotFound();
            }

            return info;
        }

        // PUT: api/Infoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfo(int id, Info info)
        {
            if (id != info.Id)
            {
                return BadRequest();
            }

            db.Entry(info).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoExists(id))
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

        // POST: api/Infoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Info>> PostInfo(Info info)
        {
            db.Info.Add(info);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InfoExists(info.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInfo", new { id = info.Id }, info);
        }

        // DELETE: api/Infoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Info>> DeleteInfo(int id)
        {
            var info = await db.Info.FindAsync(id);
            if (info == null)
            {
                return NotFound();
            }

            db.Info.Remove(info);
            await db.SaveChangesAsync();

            return info;
        }

        private bool InfoExists(int id)
        {
            return db.Info.Any(e => e.Id == id);
        }
    }
}
