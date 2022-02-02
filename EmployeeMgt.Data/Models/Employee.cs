using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.Data.Models
{
    public class Employee
    {
        [Key]
        public Int64 Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "User Name")]
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string MobileNo { get; set; }
        public DateTime? DateofBirth { get; set; }
        public string Department { get; set; }  
        [DataType(DataType.Date)]
        public DateTime? DateCreated { get; set; }
    }
}
