using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class OgretmenEtut:IEntity
    {
        public Etut etut { get; set; }
        public Ogretmen Ogretmen { get; set; }
        public int ID { get; set ; }
    }
}
