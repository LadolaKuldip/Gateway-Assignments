using ASC.Entities;
using System.Collections.Generic;

namespace ASC.Common
{
    public class ModelFormViewModel
    {
        public IEnumerable<Brand> brands { get; set; }

        public Model modelData { get; set; }

    }
}
