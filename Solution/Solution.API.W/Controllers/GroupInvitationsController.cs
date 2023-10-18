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
    public class GroupInvitationsController : ControllerBase
    {
        private readonly SocialGoalContext _context;

        public GroupInvitationsController(SocialGoalContext context)
        {
            _context = context;
        }

        // GET: api/GroupInvitations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupInvitation>>> GetGroupInvitations()
        {
          if (_context.GroupInvitations == null)
          {
              return NotFound();
          }
            return await _context.GroupInvitations.ToListAsync();
        }

        // GET: api/GroupInvitations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupInvitation>> GetGroupInvitation(int id)
        {
          if (_context.GroupInvitations == null)
          {
              return NotFound();
          }
            var groupInvitation = await _context.GroupInvitations.FindAsync(id);

            if (groupInvitation == null)
            {
                return NotFound();
            }

            return groupInvitation;
        }

        // PUT: api/GroupInvitations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupInvitation(int id, GroupInvitation groupInvitation)
        {
            if (id != groupInvitation.GroupInvitationId)
            {
                return BadRequest();
            }

            _context.Entry(groupInvitation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupInvitationExists(id))
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

        // POST: api/GroupInvitations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GroupInvitation>> PostGroupInvitation(GroupInvitation groupInvitation)
        {
          if (_context.GroupInvitations == null)
          {
              return Problem("Entity set 'SocialGoalContext.GroupInvitations'  is null.");
          }
            _context.GroupInvitations.Add(groupInvitation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupInvitation", new { id = groupInvitation.GroupInvitationId }, groupInvitation);
        }

        // DELETE: api/GroupInvitations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupInvitation(int id)
        {
            if (_context.GroupInvitations == null)
            {
                return NotFound();
            }
            var groupInvitation = await _context.GroupInvitations.FindAsync(id);
            if (groupInvitation == null)
            {
                return NotFound();
            }

            _context.GroupInvitations.Remove(groupInvitation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroupInvitationExists(int id)
        {
            return (_context.GroupInvitations?.Any(e => e.GroupInvitationId == id)).GetValueOrDefault();
        }
    }
}
