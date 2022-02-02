using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.Core.ViewModels
{
    public class UserLoginVM
    {
        public int Id { get; set; }
        [Display(Name = "User Name")]
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Display(Name = "Login Date")]
        [DataType(DataType.Date)]
        public DateTime LoginDate { get; set; }
        public bool isActive { get; set; }
        public int LoginCount { get; set; }
    }
}
