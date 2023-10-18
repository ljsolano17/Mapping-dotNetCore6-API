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
    public class GroupRequestsController : ControllerBase
    {
        private readonly SocialGoalContext _context;

        public GroupRequestsController(SocialGoalContext context)
        {
            _context = context;
        }

        // GET: api/GroupRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupRequest>>> GetGroupRequests()
        {
          if (_context.GroupRequests == null)
          {
              return NotFound();
          }
            return await _context.GroupRequests.ToListAsync();
        }

        // GET: api/GroupRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupRequest>> GetGroupRequest(int id)
        {
          if (_context.GroupRequests == null)
          {
              return NotFound();
          }
            var groupRequest = await _context.GroupRequests.FindAsync(id);

            if (groupRequest == null)
            {
                return NotFound();
            }

            return groupRequest;
        }

        // PUT: api/GroupRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupRequest(int id, GroupRequest groupRequest)
        {
            if (id != groupRequest.GroupRequestId)
            {
                return BadRequest();
            }

            _context.Entry(groupRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupRequestExists(id))
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

        // POST: api/GroupRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GroupRequest>> PostGroupRequest(GroupRequest groupRequest)
        {
          if (_context.GroupRequests == null)
          {
              return Problem("Entity set 'SocialGoalContext.GroupRequests'  is null.");
          }
            _context.GroupRequests.Add(groupRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupRequest", new { id = groupRequest.GroupRequestId }, groupRequest);
        }

        // DELETE: api/GroupRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupRequest(int id)
        {
            if (_context.GroupRequests == null)
            {
                return NotFound();
            }
            var groupRequest = await _context.GroupRequests.FindAsync(id);
            if (groupRequest == null)
            {
                return NotFound();
            }

            _context.GroupRequests.Remove(groupRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroupRequestExists(int id)
        {
            return (_context.GroupRequests?.Any(e => e.GroupRequestId == id)).GetValueOrDefault();
        }
    }
}
