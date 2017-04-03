using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Models;


namespace vega.Controllers
{
    [Produces("application/json")]
    [Route("api/Features")]
    public class FeaturesController : Controller
    {
        private readonly VegaDbContext _context;

        public FeaturesController(VegaDbContext context)
        {
            _context = context;
        }

        // GET: api/Features
        [HttpGet]
        public IEnumerable<MFeature> GetMFeature()
        {
            return _context.MFeature;
        }

        // GET: api/Features/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMFeature([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mFeature = await _context.MFeature.SingleOrDefaultAsync(m => m.Id == id);

            if (mFeature == null)
            {
                return NotFound();
            }

            return Ok(mFeature);
        }

        // PUT: api/Features/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMFeature([FromRoute] int id, [FromBody] MFeature mFeature)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mFeature.Id)
            {
                return BadRequest();
            }

            _context.Entry(mFeature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MFeatureExists(id))
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

        // POST: api/Features
        [HttpPost]
        public async Task<IActionResult> PostMFeature([FromBody] MFeature mFeature)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MFeature.Add(mFeature);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MFeatureExists(mFeature.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMFeature", new { id = mFeature.Id }, mFeature);
        }

        // DELETE: api/Features/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMFeature([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mFeature = await _context.MFeature.SingleOrDefaultAsync(m => m.Id == id);
            if (mFeature == null)
            {
                return NotFound();
            }

            _context.MFeature.Remove(mFeature);
            await _context.SaveChangesAsync();

            return Ok(mFeature);
        }

        private bool MFeatureExists(int id)
        {
            return _context.MFeature.Any(e => e.Id == id);
        }
    }
}