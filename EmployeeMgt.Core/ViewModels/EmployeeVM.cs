using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.Core.ViewModels
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name must be Supplied")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name must be Supplied")]
        public string LastName { get; set; }
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone Number is Required")]
        public string MobileNo { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime? DateofBirth { get; set; }
        public string Department { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateCreated { get; set; }

    }
}
