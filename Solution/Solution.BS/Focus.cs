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
    public class Focus : ICRUD<data.Focus>
    {
        private SolutionDbContext _repo = null;

        public Focus(SolutionDbContext solutionDbContext)
        {

            _repo = solutionDbContext;
        }
        public void Delete(data.Focus t)
        {
            new DAL.Focus(_repo).Delete(t);
        }

        public IEnumerable<data.Focus> GetAll()
        {
            return new DAL.Focus(_repo).GetAll();
        }

        public data.Focus GetOneById(int id)
        {
            return new DAL.Focus(_repo).GetOneById(id);
        }

        public void Insert(data.Focus t)
        {
            new DAL.Focus(_repo).Insert(t);
        }

        public void Update(data.Focus t)
        {
            new DAL.Focus(_repo).Update(t);
        }

        public async Task<IEnumerable<data.Focus>> GetAllWithAsync()
        {
            return await new DAL.Focus(_repo).GetAllWithAsync();
        }

        public async Task<data.Focus> GetOneByIdWithAsync(int id)
        {
            return await new DAL.Focus(_repo).GetOneByIdWithAsync(id);
        }
    }
}
