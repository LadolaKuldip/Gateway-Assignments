using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Salary { get; set; }

        [Required]
        public bool IsManager { get; set; }

        [Required]
        public int  Manager { get; set; }
        
        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
