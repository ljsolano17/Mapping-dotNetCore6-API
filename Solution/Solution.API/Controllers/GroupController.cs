using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solution.DAL.EF;
using data = Solution.DO.Objects;
using AutoMapper;
using datamodels = Solution.API.DataModels;
using System.Runtime.Intrinsics.X86;

namespace Solution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly SolutionDbContext _context;

        private readonly IMapper _mapper;

        public GroupsController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.Group>>> GetGroups()
        {
            var aux =  new Solution.BS.Group(_context).GetAll();

            var mapaux = _mapper.Map<IEnumerable<data.Group>,IEnumerable<datamodels.Group>>(aux).ToList();
            
            return mapaux;

        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.Group>> GetGroup(int id)
        {
            
            var group =  new Solution.BS.Group(_context).GetOneById(id);


            if (group == null)
            {
                return NotFound();
            }

            var mapaux = _mapper.Map<data.Group, datamodels.Group>(group);

            return mapaux;
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup(int id, datamodels.Group group)
        {
            if (id != group.GroupId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.Group, data.Group>(group);
                new Solution.BS.Group(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!GroupExists(id))
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

        // POST: api/Groups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<datamodels.Group>> PostGroup(datamodels.Group group)
        {

            var mapaux = _mapper.Map<datamodels.Group, data.Group>(group);
            new Solution.BS.Group(_context).Insert(mapaux);

            return CreatedAtAction("GetGroup", new { id = group.GroupId }, group);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.Group>> DeleteGroup(int id)
        {
            
            var group = new Solution.BS.Group(_context).GetOneById(id);
            if (group == null)
            {
                return NotFound();
            }

            new Solution.BS.Group(_context).Delete(group);
            var mapaux = _mapper.Map<data.Group, datamodels.Group>(group);
            

            return mapaux;
        }

        private bool GroupExists(int id)
        {
            //Validar si existe el grupo
            return (new Solution.BS.Group(_context).GetOneById(id)!=null);
        }
    }
}
