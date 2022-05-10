using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Dersler:IEntity
    {
        public int ID { get; set; }
        public string DersAd { get; set; }
       // public string OgretmenadSoyad { get; set; }
     //   public string OgretmenSoyad { get; set; }
    }
}
