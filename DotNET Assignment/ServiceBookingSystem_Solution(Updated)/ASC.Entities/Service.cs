using System.ComponentModel.DataAnnotations;

namespace ASC.Entities
{
    public class Service
    {
        public int Id { get; set; }

        [Display(Name = "Service")]
        public string Name { get; set; }
        public string Type { get; set; }

        
        public System.TimeSpan Duration { get; set; }
        public double Amount { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }
    }
}
