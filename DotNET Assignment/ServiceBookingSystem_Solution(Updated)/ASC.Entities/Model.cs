using System.ComponentModel.DataAnnotations;

namespace ASC.Entities
{
    public class Model
    {
        public int Id { get; set; }

        [Display(Name = "Model")]
        public string Name { get; set; }

        [Display(Name = "Actice")]
        public bool IsActive { get; set; }

        [Display(Name = "Brand")]
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }
    }
}
