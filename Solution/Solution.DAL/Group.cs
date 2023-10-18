using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class Group : ICRUD<data.Group>
    {

        private Repository<data.Group> _repo = null;
        public Group(SolutionDbContext solutionDbContext) { 
        
            _repo = new Repository<data.Group>(solutionDbContext);

        }

        public void Delete(data.Group t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Group> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Group GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Group t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Group t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
