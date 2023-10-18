using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

//Estamos usando el patron Repositorio
namespace Solution.DAL.Repository
{
    //La interface es donde yo defino como mis clases se comportan
    //Como van a implementarse metodos en una clase
    //Cada vez que tenga una interface y quiera implementar los mismos metodos en otra clase, puedo hacerlo implementando la interface
    public interface IRepository <T> where T : class
    {
        //En ambito laboral me dicen si estos 2 metodos son iguales o diff?
        //Hablemos de estos metodos para saber si son iguales o cual es la diff

        //IQueryable y IEnumerable diferencia: 
        //Los 2 son familias, direccionadas a colecciones
        //IQuery pertenece a otra referencia y Ienume pertenece a System Collection
        //IQuery tiene mejor performance a la hora de hacer LinQ, sin embargo, ambos funcionan para LinQ
        //IQuery es mas nativo, mas cercano a tener alto grado de performance

        //En este punto ambos son lo mismo, devuelven todo
        IQueryable<T> AsQueryble ();

        IEnumerable<T> GetAll();

        //LinQ viene a utilizar un Expression de Linq para filtrar, digamos que el predicado es el 'Where' de un select
        //Este devuelve una lista
        IEnumerable<T> Search (Expression<Func<T,bool>> predicado);

        //Devuelve un objeto
        //Pero, que representa T en esta interface? la clase, puedo usar esta interfaz con cualquier clase
        //T se llama Collection Generics, se usa para utilizar todo lo que perteneza a clase

        T GetOne(Expression<Func<T,bool>> predicado);// Manda todo un lambda

        T GetOneById(int id);//Solo por id

        void Insert(T t);

        void Update(T t);

        void Delete(T t);

        void Commit();

        void AddRange(IEnumerable<T> t);

        void UpdateRange(IEnumerable<T> t);

        void RemoveRange(IEnumerable<T> t);

    }


}
