using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.DAL.Repository
{
    public interface IRepositoryFocus: IRepository<data.Focus>
    {
        Task<IEnumerable<data.Focus>> GetAllWithAsAsync();

        Task<data.Focus> GetOneWithAsAsync(int id);

    }
}
