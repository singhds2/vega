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
    [Route("api/Models")]
    public class ModelsController : Controller
    {
        private readonly VegaDbContext _context;

        public ModelsController(VegaDbContext context)
        {
            _context = context;
        }

        // GET: api/Models
        [HttpGet]
        public IEnumerable<MModel> GetMModel()
        {
            return _context.MModel;
        }

        // GET: api/Models/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mModel = await _context.MModel.SingleOrDefaultAsync(m => m.Id == id);

            if (mModel == null)
            {
                return NotFound();
            }

            return Ok(mModel);
        }

        // PUT: api/Models/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMModel([FromRoute] int id, [FromBody] MModel mModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(mModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MModelExists(id))
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

        // POST: api/Models
        [HttpPost]
        public async Task<IActionResult> PostMModel([FromBody] MModel mModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MModel.Add(mModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MModelExists(mModel.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMModel", new { id = mModel.Id }, mModel);
        }

        // DELETE: api/Models/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mModel = await _context.MModel.SingleOrDefaultAsync(m => m.Id == id);
            if (mModel == null)
            {
                return NotFound();
            }

            _context.MModel.Remove(mModel);
            await _context.SaveChangesAsync();

            return Ok(mModel);
        }

        private bool MModelExists(int id)
        {
            return _context.MModel.Any(e => e.Id == id);
        }
    }
}