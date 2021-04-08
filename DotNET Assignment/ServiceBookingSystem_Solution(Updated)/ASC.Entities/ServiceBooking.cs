using System;
using System.ComponentModel.DataAnnotations;

namespace ASC.Entities
{
    public class ServiceBooking
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime BookingDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> ReturnDate { get; set; }
        public double TotalAmmount { get; set; }
        public string Status { get; set; }
        public string PickupAddress { get; set; }
        public string DropAddress { get; set; }
        public string Feedback { get; set; }

        [Display(Name = "Vehicle")]
        public int VehicleId { get; set; }

        [Display(Name = "Dealer")]
        public int DealerId { get; set; }

        [Display(Name = "Mechanic")]
        public Nullable<int> MechanicId { get; set; }
        public Nullable<bool> PayDone { get; set; }
        public string PayMethod { get; set; }
        public string PayId { get; set; }

        public virtual Dealer Dealer { get; set; }
        public virtual Mechanic Mechanic { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
