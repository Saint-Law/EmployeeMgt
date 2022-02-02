using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.Data.Models
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
    }
}
