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
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string MobileNo { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime? DateofBirth { get; set; }
        public string Department { get; set; }  
        [DataType(DataType.Date)]
        public DateTime? DateCreated { get; set; }
    }
}
