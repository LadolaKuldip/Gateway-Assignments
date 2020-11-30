using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace SourceControlAssignment1.Models
{
    public class UserRegistration
    {
        [Key]
        [ScaffoldColumn(false)]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please Enter Your Name")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email ID is Required")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Confirm Email is Required")]
        [DataType(DataType.EmailAddress)]
        [System.ComponentModel.DataAnnotations.Compare("Email", ErrorMessage = "Email Not Matched")]
        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage = "Phone no. is Required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please Enter valid Phone Number.")]
        public string PhoneNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Age is Required")]
        [CustomAttribute.MinAge(18)]
        public int Age { get; set; }

        [CustomAttribute.SexValidation(ErrorMessage = "Select your sex")]
        public string Sex { get; set; }

        [Url]
        [Display(Name = "User's GitHub URL")]
        public string URL { get; set; }
    }

}