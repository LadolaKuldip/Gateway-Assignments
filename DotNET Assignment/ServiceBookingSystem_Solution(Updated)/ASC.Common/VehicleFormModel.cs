using ASC.Entities;
using System.Collections.Generic;

namespace ASC.Common
{
    public class VehicleFormModel
    {
        public IEnumerable<Customer> customers { get; set; }
        public IEnumerable<Brand> brands { get; set; }
        public IEnumerable<Model> models { get; set; }
        public Vehicle vehicle { get; set; }
    }
}
