using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Ogrenci : IEntity
    {
        public int ID { get; set; }
        public string OgrenciAdSoyad { get; set; }
        public string Sinifi { get; set; }
        public string TelNo { get; set; }


       
    }
}
