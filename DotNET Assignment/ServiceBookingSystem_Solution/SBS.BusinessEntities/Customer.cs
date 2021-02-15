using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BusinessEntities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; }
        public string MobileNumber { get; set; }
        public string HomePhone { get; set; }
        public string EmailId { get; set; }
        public string Note { get; set; }
        public string Password { get; set; }
    }
}
