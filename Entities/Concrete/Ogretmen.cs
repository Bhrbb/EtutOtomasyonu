using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Ogretmen:IEntity
    {

        public int ID { get; set; }
        public string OgretmenAdSoyad { get; set; }
        public string BransAd { get; set; }

        //brans ID

    }
}
