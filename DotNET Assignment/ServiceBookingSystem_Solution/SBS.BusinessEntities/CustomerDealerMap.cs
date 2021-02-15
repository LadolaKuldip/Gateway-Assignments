using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BusinessEntities
{
    public class CustomerDealerMap
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int DealerId { get; set; }
    }
}
