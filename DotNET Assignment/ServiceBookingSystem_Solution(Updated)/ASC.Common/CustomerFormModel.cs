using ASC.Entities;
using System.Collections.Generic;

namespace ASC.Common
{
    public class CustomerFormModel
    {
        public IEnumerable<Dealer> dealers { get; set; }

        public Customer customer { get; set; }
    }
}
