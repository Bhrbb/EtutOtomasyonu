using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRepository<T>
    {

        List<T> GetAll();
        List<T>GetAll1(Expression<Func<T, bool>> expression);//where ile filtreleyenler
        T Get(int id);
        T Find(Expression<Func<T,bool>>expression);//filtreli getirme
        int Add(T entity);
        int Update(T entity);
        int Delete(int id);



    }
}
