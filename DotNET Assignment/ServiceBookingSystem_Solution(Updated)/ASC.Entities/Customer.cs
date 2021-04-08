using System;
using System.ComponentModel.DataAnnotations;

namespace ASC.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name = "Customer")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [Display(Name = "User")]
        public string UserId { get; set; }
        public string Address { get; set; }

        [Display(Name = "Dealer")]
        public Nullable<int> DealerId { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public virtual Dealer Dealer { get; set; } 
    }
}
