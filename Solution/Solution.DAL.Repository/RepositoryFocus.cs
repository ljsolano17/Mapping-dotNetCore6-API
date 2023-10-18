using Microsoft.EntityFrameworkCore;
using Solution.DAL.EF;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;


namespace Solution.DAL.Repository
{
    public class RepositoryFocus : Repository<data.Focus>, IRepositoryFocus
    {

        //Clase que es una extensioin de repository
        //Implementa la interface IRepositoryFocus
        //Esta interface se encarga de implementar metodos que se necesitan para devolcer la informacion asociada a la tabla de FK(include)
        
        //Constructor correspondiente a la clase
        //Parametro context para poderlo recibir, cargar al Repository y utilizar en esta misma clase
        public RepositoryFocus(SolutionDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Focus>> GetAllWithAsAsync()
        {
            return await _db.Foci
                .Include(m=>m.Group)
                .ToListAsync();
           // return await _db.Foci.Include(m=>m.GroupId).ToListAsync();
        }

        public async Task<Focus> GetOneWithAsAsync(int id)
        {
            return await _db.Foci
                .Include(m => m.Group)
                .SingleOrDefaultAsync(m => m.FocusId == id);
            //return await _db.Foci
            //    .Include(m => m.Group)
            //    .SingleOrDefaultAsync(m => m.FocusId == id);

        }

        //Metodo para obtener el contexto cargado del repository y asi utilizarlo en esta clase

        private SolutionDbContext _db
        {
            get {  return dbContext as SolutionDbContext; }
        }
    }
}
