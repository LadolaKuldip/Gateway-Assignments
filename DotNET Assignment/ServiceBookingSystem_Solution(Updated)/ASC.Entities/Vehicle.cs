using System;
using System.ComponentModel.DataAnnotations;

namespace ASC.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Display(Name = "Vehicle")]
        public string Name { get; set; }
        public string NumberPlate { get; set; }
        public string ChassisNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Reg. Date")]
        public System.DateTime RegistrationDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Last Service")]
        public Nullable<System.DateTime> LastServiceDate { get; set; }
        public string FuelType { get; set; }

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Display(Name = "Model")]
        public int ModelId { get; set; }

        public bool IsActive { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Model Model { get; set; }
    }
}
