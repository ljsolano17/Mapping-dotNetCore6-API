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
    public class FociController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        //Declaracion del automapper para poder castear los objetos
        private readonly IMapper _mapper;

        public FociController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Foci
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.Focus>>> GetFocus()
        {
            //return new Solution.BS.Focus(_context).GetAll().ToList();
            //Declaramos una variable para traer la informacion

            var aux = await new Solution.BS.Focus(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.Focus>,IEnumerable<datamodels.Focus>>(aux).ToList();

            return mapaux;
        }

        // GET: api/Foci/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.Focus>> GetFocus(int id)
        {
            //var focus = await new Solution.BS.Focus(_context).GetOneByIdWithAsync(id);

            var focus = await new Solution.BS.Focus(_context).GetOneByIdWithAsync(id);

            var mapaux = _mapper.Map<data.Focus, datamodels.Focus>(focus);

            if (mapaux == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Foci/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFocus(int id, datamodels.Focus focus)
        {
            if (id != focus.FocusId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.Focus, data.Focus>(focus);

               // var existingGroup = new Solution.BS.Focus(_context).GetOneByIdWithAsync(id);
               if(mapaux != null)
                {
                    new Solution.BS.Focus(_context).Update(mapaux);
                }
                
                
            }
            catch (Exception ee)
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
        public async Task<ActionResult<datamodels.Focus>> PostFoci(datamodels.Focus focus)
        {

            var mapaux = _mapper.Map<datamodels.Focus, data.Focus>(focus);
            new Solution.BS.Focus(_context).Insert(mapaux);

            return CreatedAtAction("GetFocus", new { id = focus.FocusId }, focus);
        }

        // DELETE: api/Foci/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.Focus>> DeleteFocus(int id)
        {

            var focus = new Solution.BS.Focus(_context).GetOneById(id);
            if (focus == null)
            {
                return NotFound();
            }

            new Solution.BS.Focus(_context).Delete(focus);
            var mapaux = _mapper.Map<data.Focus, datamodels.Focus>(focus);
            

            return mapaux;
        }

        private bool FocusExists(int id)
        {
            return (new Solution.BS.Focus(_context).GetOneById(id) != null);
        }
    }
}
