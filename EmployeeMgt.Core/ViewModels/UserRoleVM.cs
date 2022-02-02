using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.Core.ViewModels
{
    public class UserRoleVM
    {
        public int Id { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Display(Name = "User Name")]
        [Required]
        public string UserName { get; set; }
        [Display(Name = "Date Created")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateCreated { get; set; }
        [Display(Name = "Created By")]
        [Required]
        public string CreatedBy { get; set; }
    }
}
