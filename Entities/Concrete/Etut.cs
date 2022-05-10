using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Etut:IEntity
    {
        public int ID { get; set; }
       // public string Adi { get; set; }
        public bool Durum { get; set; }
        public string Tarih { get; set; }
        public string Saat { get; set; }
      // public string OgrenciadSoyad { get; set; }
       // public string OgretmenadSoyad { get; set; }
        public string DersAd { get; set; }
        public string OgretmenAdSoyad { get; set; }
        public string OgrenciAdSoyad { get; set; }
        //public Dersler  DersID { get; set; }



    }
}
