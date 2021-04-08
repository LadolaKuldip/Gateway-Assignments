using System.ComponentModel.DataAnnotations;

namespace ASC.Entities
{
    public class Brand
    {
        public int Id { get; set; }

        [Display(Name = "Brand")]
        public string Name { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }
    }
}
