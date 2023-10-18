using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solution.API.W.Models;

namespace Solution.API.W.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FociController : ControllerBase
    {
        private readonly SocialGoalContext _context;

        public FociController(SocialGoalContext context)
        {
            _context = context;
        }

        // GET: api/Foci
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Focus>>> GetFoci()
        {
          if (_context.Foci == null)
          {
              return NotFound();
          }
            return await _context.Foci.ToListAsync();
        }

        // GET: api/Foci/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Focus>> GetFocus(int id)
        {
          if (_context.Foci == null)
          {
              return NotFound();
          }
            var focus = await _context.Foci.FindAsync(id);

            if (focus == null)
            {
                return NotFound();
            }

            return focus;
        }

        // PUT: api/Foci/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFocus(int id, Focus focus)
        {
            if (id != focus.FocusId)
            {
                return BadRequest();
            }

            _context.Entry(focus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FocusExists(id))
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

        // POST: api/Foci
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Focus>> PostFocus(Focus focus)
        {
          if (_context.Foci == null)
          {
              return Problem("Entity set 'SocialGoalContext.Foci'  is null.");
          }
            _context.Foci.Add(focus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFocus", new { id = focus.FocusId }, focus);
        }

        // DELETE: api/Foci/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFocus(int id)
        {
            if (_context.Foci == null)
            {
                return NotFound();
            }
            var focus = await _context.Foci.FindAsync(id);
            if (focus == null)
            {
                return NotFound();
            }

            _context.Foci.Remove(focus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FocusExists(int id)
        {
            return (_context.Foci?.Any(e => e.FocusId == id)).GetValueOrDefault();
        }
    }
}
