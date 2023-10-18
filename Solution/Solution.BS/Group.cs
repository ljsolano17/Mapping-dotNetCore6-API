using Solution.DAL.EF;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.BS
{
    public class Group : ICRUD<data.Group>
    {
        private SolutionDbContext context;

        public Group(SolutionDbContext _context) { 
        
            context = _context;
        }
        public void Delete(data.Group t)
        {
            new DAL.Group(context).Delete(t);
        }

        public IEnumerable<data.Group> GetAll()
        {
            return new DAL.Group(context).GetAll();
        }

        public data.Group GetOneById(int id)
        {
            return new DAL.Group(context).GetOneById(id);
        }

        public void Insert(data.Group t)
        {
            new DAL.Group(context).Insert(t);
        }

        public void Update(data.Group t)
        {
            new DAL.Group(context).Update(t);
        }
    }
}
