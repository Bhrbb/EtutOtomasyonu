using DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOgrenciService
    {
        
        List<Ogrenci> GetAll();
        Ogrenci Get(int id);
        Ogrenci GetByName(string Ad);
        int Add(Ogrenci ogrenci);
        int Update(Ogrenci ogrenci);
       // int Ara(string ad);
       
      // Ogrenci Get(Expression<Func<Ogrenci, bool>> filter);//filtre varsa getir yoksa hepsini getir
    }
}
