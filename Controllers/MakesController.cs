using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Models;
using System.Net.Http;
using System.Net;


namespace vega.Controllers
{
    [Produces("application/json")]
    [Route("api/Makes")]
    public class MakesController : Controller
    {
        private readonly VegaDbContext _context;

        public MakesController(VegaDbContext context)
        {
            _context = context;
        }

        // GET: api/Makes
        [HttpGet]
          public IEnumerable<MMake> GetMMake()
         {
            
            return _context.MMake;
          }


        // GET: api/Makes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMMake([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mMake = await _context.MMake.SingleOrDefaultAsync(m => m.Id == id);

            if (mMake == null)
            {
                return NotFound();
            }

            return Ok(mMake);
        }

        // PUT: api/Makes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMMake([FromRoute] int id, [FromBody] MMake mMake)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mMake.Id)
            {
                return BadRequest();
            }

            _context.Entry(mMake).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MMakeExists(id))
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

        // POST: api/Makes
        [HttpPost]
        public async Task<IActionResult> PostMMake([FromBody] MMake mMake)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MMake.Add(mMake);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MMakeExists(mMake.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMMake", new { id = mMake.Id }, mMake);
        }

        // DELETE: api/Makes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMMake([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mMake = await _context.MMake.SingleOrDefaultAsync(m => m.Id == id);
            if (mMake == null)
            {
                return NotFound();
            }

            _context.MMake.Remove(mMake);
            await _context.SaveChangesAsync();

            return Ok(mMake);
        }

        private bool MMakeExists(int id)
        {
            return _context.MMake.Any(e => e.Id == id);
        }
    }
}