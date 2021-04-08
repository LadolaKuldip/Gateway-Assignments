using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Common
{
    public class MechanicFormModel
    {
        public IEnumerable<Dealer> dealers { get; set; }

        public Mechanic mechanic { get; set; }
    }
}
