using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.Data.Models
{
    public class UserLogin
    {
        [Key]
        public Int64 Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        [DataType(DataType.Date)]
        public DateTime LoginDate { get; set; }
        public bool isActive { get; set; }
        public int LoginCount { get; set; }
    }
}
