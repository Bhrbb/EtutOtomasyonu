using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEtutService
    {
        List<Etut> GetAll();
        Etut GetById(int id);
        Etut GetByOgrenciID(int ogrenciID);
        int Add(Etut etut);
        int Update(Etut etut);
        int Delete(int id);
        Etut GetByOgrenci(string ogrenciadi);

    }
}
