using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.Core.ViewModels
{
    public class RoleVM
    {
        public int Id { get; set; }
        [Display(Name = "Role Name")]
        [Required]
        public string RoleName { get; set; }
    }
}
