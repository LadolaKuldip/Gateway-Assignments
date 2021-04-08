using System.ComponentModel.DataAnnotations;

namespace ASC.Entities
{
    public class Dealer
    {
        public int Id { get; set; }

        [Display(Name = "Dealer")]
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        public string UserId { get; set; }
    }
}
