using System.ComponentModel.DataAnnotations;

namespace ASC.Entities
{
    public class Mechanic
    {
        public int Id { get; set; }
        [Display(Name = "Mechanic")]
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        [Display(Name = "Dealer")]
        public int DealerId { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public virtual Dealer Dealer { get; set; }
    }
}
