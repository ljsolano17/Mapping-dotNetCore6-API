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
    public class Focus : ICRUD<data.Focus>
    {
        //Definicion de la variable que va implementar el Repositorio extendido a utilizar
        //Ya que necesitamos agregar el include en los metodos del repository

        private RepositoryFocus _repo = null;

        public Focus(SolutionDbContext solutionDbContext)
        {
            _repo = new RepositoryFocus(solutionDbContext);
        }
        public void Delete(data.Focus t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Focus> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Focus GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Focus t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Focus t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.Focus>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public async Task<data.Focus> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetOneWithAsAsync(id);
        }
    }
}
